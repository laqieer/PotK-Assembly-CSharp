// Decompiled with JetBrains decompiler
// Type: Popup02681Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02681Menu : Popup02681MenuBase
{
  protected System.Action onCallback;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private GameObject link_icon;

  [DebuggerHidden]
  public IEnumerator Init(Versus0268Menu.PvpParam.BonusReward reward, int totalWin)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02681Menu.\u003CInit\u003Ec__Iterator95E()
    {
      reward = reward,
      totalWin = totalWin,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003EtotalWin = totalWin,
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnOK()
  {
    base.IbtnOK();
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;
}
