// Decompiled with JetBrains decompiler
// Type: WebResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text;
using UniLinq;

#nullable disable
public class WebResponse
{
  public int Status;
  public string Header;
  public byte[] Bytes;
  private string _body;
  public Dictionary<string, object> Json;

  public string Body
  {
    get
    {
      if (string.IsNullOrEmpty(this._body) && this.Bytes != null)
        this._body = Encoding.UTF8.GetString(this.Bytes);
      return this._body;
    }
    set => this._body = value;
  }

  public static WebResponse Zero()
  {
    return new WebResponse()
    {
      Status = 0,
      Header = string.Empty,
      Bytes = (byte[]) null,
      _body = string.Empty,
      Json = new Dictionary<string, object>()
    };
  }

  public string getJsonStringOrNull(string key) => this.getJsonValueObject(key) as string;

  public int? getJsonIntOrNull(string key)
  {
    return this.getJsonValueObject(key) is long jsonValueObject ? new int?((int) jsonValueObject) : new int?();
  }

  public string getJsonStringOrNull(string[] keys)
  {
    return ((IEnumerable<string>) keys).Select<string, object>((Func<string, object>) (x => this.getJsonValueObject(x))).FirstOrDefault<object>((Func<object, bool>) (x => x != null)) as string;
  }

  public object getJsonValueObject(string keyWithDot)
  {
    Dictionary<string, object> dictionary = this.Json;
    object jsonValueObject = (object) null;
    string str = keyWithDot;
    char[] chArray = new char[1]{ '.' };
    foreach (string key in str.Split(chArray))
    {
      if (dictionary == null)
        return (object) null;
      if (dictionary.TryGetValue(key, out jsonValueObject))
        dictionary = jsonValueObject as Dictionary<string, object>;
    }
    return jsonValueObject;
  }

  public static WebResponse FromHTTPResponse(HTTP.Response rawResponse)
  {
    WebResponse webResponse = new WebResponse();
    webResponse.Bytes = rawResponse.Bytes;
    webResponse.Status = rawResponse.status;
    foreach (string str in rawResponse.headers.GetAll("Content-Type"))
    {
      if (str.Contains("application/json"))
      {
        webResponse.Json = (Dictionary<string, object>) GameCore.FastMiniJSON.Json.Deserialize(rawResponse.Bytes);
        break;
      }
    }
    if (webResponse.Json == null)
    {
      Debug.LogWarning((object) ("response is not json " + webResponse.Body));
      webResponse.Json = new Dictionary<string, object>();
    }
    return webResponse;
  }
}
