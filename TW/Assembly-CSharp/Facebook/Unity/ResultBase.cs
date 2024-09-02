// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ResultBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal abstract class ResultBase : IInternalResult, IResult
  {
    internal ResultBase(string result)
    {
      string error = (string) null;
      bool cancelled = false;
      string callbackId = (string) null;
      if (!string.IsNullOrEmpty(result) && Json.Deserialize(result) is Dictionary<string, object> result1)
      {
        this.ResultDictionary = (IDictionary<string, object>) result1;
        error = ResultBase.GetErrorValue((IDictionary<string, object>) result1);
        cancelled = ResultBase.GetCancelledValue((IDictionary<string, object>) result1);
        callbackId = ResultBase.GetCallbackId((IDictionary<string, object>) result1);
      }
      this.Init(result, error, cancelled, callbackId);
    }

    internal ResultBase(string result, string error, bool cancelled)
    {
      this.Init(result, error, cancelled, (string) null);
    }

    public virtual string Error { get; protected set; }

    public virtual IDictionary<string, object> ResultDictionary { get; protected set; }

    public virtual string RawResult { get; protected set; }

    public virtual bool Cancelled { get; protected set; }

    public virtual string CallbackId { get; protected set; }

    public override string ToString()
    {
      return string.Format("[BaseResult: Error={0}, Result={1}, RawResult={2}, Cancelled={3}]", (object) this.Error, (object) this.ResultDictionary, (object) this.RawResult, (object) this.Cancelled);
    }

    protected void Init(string result, string error, bool cancelled, string callbackId)
    {
      this.RawResult = result;
      this.Cancelled = cancelled;
      this.Error = error;
      this.CallbackId = callbackId;
    }

    private static string GetErrorValue(IDictionary<string, object> result)
    {
      if (result == null)
        return (string) null;
      string str;
      return result.TryGetValue<string>("error", out str) ? str : (string) null;
    }

    private static bool GetCancelledValue(IDictionary<string, object> result)
    {
      object obj;
      if (result == null || !result.TryGetValue("cancelled", out obj))
        return false;
      bool? nullable1 = obj as bool?;
      if (nullable1.HasValue)
        return nullable1.HasValue && nullable1.Value;
      if (obj is string str)
        return Convert.ToBoolean(str);
      int? nullable2 = obj as int?;
      return nullable2.HasValue && nullable2.HasValue && nullable2.Value != 0;
    }

    private static string GetCallbackId(IDictionary<string, object> result)
    {
      if (result == null)
        return (string) null;
      string str;
      return result.TryGetValue<string>("callback_id", out str) ? str : (string) null;
    }
  }
}
