// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ResultContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class ResultContainer
  {
    private const string CanvasResponseKey = "response";

    public ResultContainer(IDictionary<string, object> dictionary)
    {
      this.RawResult = dictionary.ToJson();
      this.ResultDictionary = dictionary;
      if (!Constants.IsWeb)
        return;
      this.ResultDictionary = this.GetWebFormattedResponseDictionary(this.ResultDictionary);
    }

    public ResultContainer(string result)
    {
      this.RawResult = result;
      if (string.IsNullOrEmpty(result))
        return;
      this.ResultDictionary = (IDictionary<string, object>) (Json.Deserialize(result) as Dictionary<string, object>);
      if (!Constants.IsWeb)
        return;
      this.ResultDictionary = this.GetWebFormattedResponseDictionary(this.ResultDictionary);
    }

    public string RawResult { get; private set; }

    public IDictionary<string, object> ResultDictionary { get; set; }

    private IDictionary<string, object> GetWebFormattedResponseDictionary(
      IDictionary<string, object> resultDictionary)
    {
      IDictionary<string, object> responseDictionary;
      if (!resultDictionary.TryGetValue<IDictionary<string, object>>("response", out responseDictionary))
        return resultDictionary;
      object obj;
      if (resultDictionary.TryGetValue("callback_id", out obj))
        responseDictionary["callback_id"] = obj;
      return responseDictionary;
    }
  }
}
