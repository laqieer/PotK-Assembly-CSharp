// Decompiled with JetBrains decompiler
// Type: Shop99982Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

  private void update()
  {
  }

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
    Debug.Log((object) ("Shop99982Menu IbtnPopupYes year =" + this.year));
    Debug.Log((object) ("Shop99982Menu IbtnPopupYes month =" + this.month));
    Debug.Log((object) ("Shop99982Menu IbtnPopupYes day =" + this.day));
    PaymentListener.SendAge(int.Parse(this.year), int.Parse(this.month), int.Parse(this.day));
    PaymentListener.PopupDismiss();
    PaymentListener.PopupDismiss();
  }

  [DebuggerHidden]
  private IEnumerator popup99983()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop99982Menu.\u003Cpopup99983\u003Ec__Iterator502()
    {
      \u003C\u003Ef__this = this
    };
  }
}
