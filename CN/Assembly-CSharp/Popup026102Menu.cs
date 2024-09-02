// Decompiled with JetBrains decompiler
// Type: Popup026102Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup026102Menu : NGMenuBase
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  [SerializeField]
  private UILabel message2;
  [SerializeField]
  private UILabel himeMessage;
  [SerializeField]
  private UILabel himeNum;

  public void Init()
  {
    Player player = SMManager.Get<Player>();
    this.title.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_102_TITLE);
    this.message.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_102_MESSAGE);
    this.message2.SetTextLocalize(string.Format(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_102_MESSAGE2, (object) player.mp, (object) player.mp_max));
    this.himeMessage.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_102_HIME_MESSAGE);
    this.himeNum.SetTextLocalize(player.coin);
  }

  public virtual void IbtnYes()
  {
    if (SMManager.Get<Player>().coin > 0)
      this.StartCoroutine(this.MpRecovery());
    else
      this.StartCoroutine(this.ShowStoneAlert());
  }

  public virtual void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  [DebuggerHidden]
  private IEnumerator MpRecovery()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026102Menu.\u003CMpRecovery\u003Ec__Iterator957 recoveryCIterator957 = new Popup026102Menu.\u003CMpRecovery\u003Ec__Iterator957();
    return (IEnumerator) recoveryCIterator957;
  }

  [DebuggerHidden]
  private IEnumerator ShowStoneAlert()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026102Menu.\u003CShowStoneAlert\u003Ec__Iterator958 alertCIterator958 = new Popup026102Menu.\u003CShowStoneAlert\u003Ec__Iterator958();
    return (IEnumerator) alertCIterator958;
  }
}
