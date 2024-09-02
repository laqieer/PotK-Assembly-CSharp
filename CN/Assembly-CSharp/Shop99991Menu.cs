// Decompiled with JetBrains decompiler
// Type: Shop99991Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop99991Menu : BackButtonMenuBase
{
  public Shop0079Menu menu0079;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtDescription04;
  [SerializeField]
  private UILabel TxtDescription05;
  [SerializeField]
  private UILabel TxtDescription06;
  [SerializeField]
  private UILabel TxtDescription07;
  [SerializeField]
  private UILabel TxtPopuptitle;

  public Player player { get; set; }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
    PaymentListener.ShowInputBirthday(false);
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    PaymentListener.PopupDismiss();
    PaymentListener.ShowInputBirthday(true);
  }

  [DebuggerHidden]
  private IEnumerator popup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop99991Menu.\u003Cpopup\u003Ec__Iterator4B3()
    {
      \u003C\u003Ef__this = this
    };
  }
}
