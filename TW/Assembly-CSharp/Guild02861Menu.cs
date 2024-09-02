// Decompiled with JetBrains decompiler
// Type: Guild02861Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02861Menu : Guild0286Scroll
{
  private const int iconWidth = 620;
  private const int iconHeight = 175;
  private const int iconColumnValue = 1;
  private const int iconRowValue = 12;
  private const int iconScreenValue = 8;
  private const int iconMaxValue = 12;
  private const int MAX_SEND = 60;
  [SerializeField]
  private UIButton ibtnSendAll;
  private ModalWindow popup;
  [SerializeField]
  private GameObject noGiftTxt;

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Guild0281Scene.ChangeSceneGuildTop();
  }

  public void onButtonReceive()
  {
    if (this.IsPushAndSet())
      return;
    Guild0286Scene.ChangeScene();
  }

  public void onButtonSendAll()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.SendAll());
  }

  private void onButtonSend(GuildMemberGift gift)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.SendConnection(gift));
  }

  private void CheckAllSend()
  {
    if (this.memberGifts.Length == 0)
    {
      this.ibtnSendAll.isEnabled = false;
      this.noGiftTxt.SetActive(true);
    }
    else
    {
      this.ibtnSendAll.isEnabled = true;
      this.noGiftTxt.SetActive(false);
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(GuildMemberGift[] gifts)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02861Menu.\u003CInit\u003Ec__Iterator7C0()
    {
      gifts = gifts,
      \u003C\u0024\u003Egifts = gifts,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SendConnection(GuildMemberGift gift)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02861Menu.\u003CSendConnection\u003Ec__Iterator7C1()
    {
      gift = gift,
      \u003C\u0024\u003Egift = gift,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SendAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02861Menu.\u003CSendAll\u003Ec__Iterator7C2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
