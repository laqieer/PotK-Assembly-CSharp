// Decompiled with JetBrains decompiler
// Type: Shop99982Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop99982Menu : BackButtonMenuBase
{
  private GameObject prefab99983;
  public string year;
  public string month;
  public string day;

  public void Init(string year, string month, string day)
  {
    this.year = year;
    this.month = month;
    this.day = day;
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    PaymentListener.SendAge(int.Parse(this.year), int.Parse(this.month), int.Parse(this.day));
    PaymentListener.PopupDismiss();
    PaymentListener.PopupDismiss();
  }

  [DebuggerHidden]
  private IEnumerator popup99983()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop99982Menu.\u003Cpopup99983\u003Ec__Iterator418()
    {
      \u003C\u003Ef__this = this
    };
  }
}
