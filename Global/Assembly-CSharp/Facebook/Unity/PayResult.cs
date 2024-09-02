// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.PayResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class PayResult : ResultBase, IPayResult, IResult
  {
    internal const long CancelPaymentFlowCode = 1383010;

    internal PayResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      if (!this.CanvasErrorCode.HasValue || this.CanvasErrorCode.Value != 1383010L)
        return;
      this.Cancelled = true;
    }

    public long ErrorCode => this.CanvasErrorCode.GetValueOrDefault();

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "ErrorCode",
          this.ErrorCode.ToString()
        }
      });
    }
  }
}
