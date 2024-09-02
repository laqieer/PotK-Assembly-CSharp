// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.Pay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class Pay : MenuBase
  {
    private string payProduct = string.Empty;

    protected override void GetGui()
    {
      this.LabelAndTextField("Product: ", ref this.payProduct);
      if (this.Button("Call Pay"))
        this.CallFBPay();
      GUILayout.Space(10f);
    }

    private void CallFBPay()
    {
      FB.Canvas.Pay(this.payProduct, callback: new FacebookDelegate<IPayResult>(((MenuBase) this).HandleResult));
    }
  }
}
