// Decompiled with JetBrains decompiler
// Type: Invite0131Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Invite0131Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel InpId01;
  [SerializeField]
  protected UILabel InpId02;
  [SerializeField]
  protected UILabel TxtAttention;
  [SerializeField]
  protected UILabel TxtInviteId;
  [SerializeField]
  protected UILabel TxtItemget;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtUserId;
  [SerializeField]
  private UIInput InpUI;

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnInviteWithTwitter() => SocialListener.ShareWithTwitter();

  public virtual void IbtnInvite()
  {
    DeviceManager.OpenUrl(Consts.GetInstance().INVITE_CAMPAIGN_BANNER_URL + SMManager.Get<Player>().short_id);
  }

  [DebuggerHidden]
  private IEnumerator openPopup00132()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Invite0131Menu.\u003CopenPopup00132\u003Ec__Iterator5C0 popup00132CIterator5C0 = new Invite0131Menu.\u003CopenPopup00132\u003Ec__Iterator5C0();
    return (IEnumerator) popup00132CIterator5C0;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00135(string str)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Invite0131Menu.\u003CopenPopup00135\u003Ec__Iterator5C1()
    {
      str = str,
      \u003C\u0024\u003Estr = str
    };
  }

  [DebuggerHidden]
  private IEnumerator InvitationAcceptAscync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Invite0131Menu.\u003CInvitationAcceptAscync\u003Ec__Iterator5C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnSend()
  {
    if (this.InpUI.value.Length < 1 || this.IsPushAndSet())
      return;
    this.StartCoroutine(this.InvitationAcceptAscync());
  }

  public void setKeyboardTypeNumber()
  {
    this.InpUI.keyboardType = UIInput.KeyboardType.NumberPad;
    this.InpUI.characterLimit = 10;
  }

  private void setId(UILabel label, string id) => label.SetTextLocalize(id);

  public void setInpId02(string id) => this.setId(this.InpId02, id);

  public void setInpId01(string id) => this.setId(this.InpId01, id);

  public void onChangeInpId01() => this.setInpId01(this.InpUI.value);
}
