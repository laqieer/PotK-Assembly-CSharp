// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ResultBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal abstract class ResultBase : IInternalResult, IResult
  {
    internal const long CancelDialogCode = 4201;
    internal const string ErrorCodeKey = "error_code";
    internal const string ErrorMessageKey = "error_message";

    internal ResultBase(ResultContainer result)
    {
      string errorValue = ResultBase.GetErrorValue(result.ResultDictionary);
      bool cancelledValue = ResultBase.GetCancelledValue(result.ResultDictionary);
      string callbackId = ResultBase.GetCallbackId(result.ResultDictionary);
      this.Init(result, errorValue, cancelledValue, callbackId);
    }

    internal ResultBase(ResultContainer result, string error, bool cancelled)
    {
      this.Init(result, error, cancelled, (string) null);
    }

    public virtual string Error { get; protected set; }

    public virtual IDictionary<string, object> ResultDictionary { get; protected set; }

    public virtual string RawResult { get; protected set; }

    public virtual bool Cancelled { get; protected set; }

    public virtual string CallbackId { get; protected set; }

    protected long? CanvasErrorCode { get; private set; }

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "Error",
          this.Error
        },
        {
          "RawResult",
          this.RawResult
        },
        {
          "Cancelled",
          this.Cancelled.ToString()
        }
      });
    }

    protected void Init(ResultContainer result, string error, bool cancelled, string callbackId)
    {
      this.RawResult = result.RawResult;
      this.ResultDictionary = result.ResultDictionary;
      this.Cancelled = cancelled;
      this.Error = error;
      this.CallbackId = callbackId;
      if (this.ResultDictionary == null)
        return;
      long num;
      if (this.ResultDictionary.TryGetValue<long>("error_code", out num))
      {
        this.CanvasErrorCode = new long?(num);
        if (num == 4201L)
          this.Cancelled = true;
      }
      string str;
      if (!this.ResultDictionary.TryGetValue<string>("error_message", out str))
        return;
      this.Error = str;
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
