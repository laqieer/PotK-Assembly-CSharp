// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.MethodArguments
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class MethodArguments
  {
    private IDictionary<string, object> arguments = (IDictionary<string, object>) new Dictionary<string, object>();

    public MethodArguments()
      : this((IDictionary<string, object>) new Dictionary<string, object>())
    {
    }

    public MethodArguments(MethodArguments methodArgs)
      : this(methodArgs.arguments)
    {
    }

    private MethodArguments(IDictionary<string, object> arguments) => this.arguments = arguments;

    public void AddPrimative<T>(string argumentName, T value) where T : struct
    {
      this.arguments[argumentName] = (object) value;
    }

    public void AddNullablePrimitive<T>(string argumentName, T? nullable) where T : struct
    {
      if (!nullable.HasValue || !nullable.HasValue)
        return;
      this.arguments[argumentName] = (object) nullable.Value;
    }

    public void AddString(string argumentName, string value)
    {
      if (string.IsNullOrEmpty(value))
        return;
      this.arguments[argumentName] = (object) value;
    }

    public void AddCommaSeparatedList(string argumentName, IEnumerable<string> value)
    {
      if (value == null)
        return;
      this.arguments[argumentName] = (object) value.ToCommaSeparateList();
    }

    public void AddDictionary(string argumentName, IDictionary<string, object> dict)
    {
      if (dict == null)
        return;
      this.arguments[argumentName] = (object) MethodArguments.ToStringDict(dict);
    }

    public void AddList<T>(string argumentName, IEnumerable<T> list)
    {
      if (list == null)
        return;
      this.arguments[argumentName] = (object) list;
    }

    public void AddUri(string argumentName, Uri uri)
    {
      if (!(uri != (Uri) null) || string.IsNullOrEmpty(uri.AbsoluteUri))
        return;
      this.arguments[argumentName] = (object) uri.ToString();
    }

    public string ToJsonString() => Json.Serialize((object) this.arguments);

    private static Dictionary<string, string> ToStringDict(IDictionary<string, object> dict)
    {
      if (dict == null)
        return (Dictionary<string, string>) null;
      Dictionary<string, string> stringDict = new Dictionary<string, string>();
      foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dict)
        stringDict[keyValuePair.Key] = keyValuePair.Value.ToString();
      return stringDict;
    }
  }
}
