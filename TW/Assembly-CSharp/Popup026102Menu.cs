// Decompiled with JetBrains decompiler
// Type: Popup026102Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Popup026102Menu.\u003CMpRecovery\u003Ec__IteratorA2C recoveryCIteratorA2C = new Popup026102Menu.\u003CMpRecovery\u003Ec__IteratorA2C();
    return (IEnumerator) recoveryCIteratorA2C;
  }

  [DebuggerHidden]
  private IEnumerator ShowStoneAlert()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup026102Menu.\u003CShowStoneAlert\u003Ec__IteratorA2D alertCIteratorA2D = new Popup026102Menu.\u003CShowStoneAlert\u003Ec__IteratorA2D();
    return (IEnumerator) alertCIteratorA2D;
  }
}
