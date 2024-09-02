// Decompiled with JetBrains decompiler
// Type: Friend00810Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.Unity.Example;
using GameCore;
using gu3.Device;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00810Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel InpFriendid;
  [SerializeField]
  protected UILabel TxtExplanation;
  [SerializeField]
  protected UILabel TxtId;
  [SerializeField]
  protected UILabel TxtMyid;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIInput InpUI;

  private void Awake() => ((Component) this).gameObject.AddComponent<MainMenu>();

  [DebuggerHidden]
  private IEnumerator BackSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00810Menu.\u003CBackSceneAsync\u003Ec__Iterator50E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnFacebookInvite()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_80", true);
  }

  public void IbtnShareWithTwitter() => SocialListener.ShareWithTwitter();

  public virtual void IbtnBnr()
  {
    DeviceManager.OpenUrl(Consts.GetInstance().INVITE_CAMPAIGN_BANNER_URL + SMManager.Get<Player>().short_id);
    Debug.Log((object) ("openURL:" + Consts.GetInstance().INVITE_CAMPAIGN_BANNER_URL + SMManager.Get<Player>().short_id));
  }

  public virtual void IbtnCopy()
  {
    if (this.IsPushAndSet())
      return;
    Clipboard.setText(SMManager.Get<Player>().short_id.ToString());
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.USERCODE_COPY_TITLE, instance.USERCODE_COPY, (System.Action) (() => this.IsPush = false));
  }

  [DebuggerHidden]
  private IEnumerator SearchUser(string short_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00810Menu.\u003CSearchUser\u003Ec__Iterator50F()
    {
      short_id = short_id,
      \u003C\u0024\u003Eshort_id = short_id,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnSearch()
  {
    if (this.InpUI.value.Length <= 0 || this.IsPushAndSet())
      return;
    this.StartCoroutine(this.SearchUser(this.InpUI.value));
  }

  [DebuggerHidden]
  private IEnumerator openPopup00812()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00810Menu.\u003CopenPopup00812\u003Ec__Iterator510 popup00812CIterator510 = new Friend00810Menu.\u003CopenPopup00812\u003Ec__Iterator510();
    return (IEnumerator) popup00812CIterator510;
  }

  public void SetBtnInviteResp()
  {
    GameObject gameObject = GameObject.Find("Friend00810Friend00810Scene UI Root/MainPanel/Bottom/GO_FbInvite/ibtn_FBInvite");
    if (!Object.op_Implicit((Object) gameObject))
      return;
    UIButton component1 = gameObject.GetComponent<UIButton>();
    if (!Object.op_Implicit((Object) component1))
      return;
    EventDelegate.Set(component1.onClick, (EventDelegate.Callback) (() =>
    {
      MainMenu component2 = ((Component) this).gameObject.GetComponent<MainMenu>();
      if (Object.op_Implicit((Object) component2))
        component2.FbInviteFriend();
      else
        Debug.LogError((object) "friend_00810_fb_动态获取脚本错误");
    }));
  }

  public void setKeyboardTypeNumber()
  {
    this.InpUI.keyboardType = UIInput.KeyboardType.NumberPad;
    this.InpUI.characterLimit = 10;
  }

  private void setId(UILabel label, string id) => label.SetTextLocalize(id);

  public void setTxtId(string id) => this.setId(this.TxtId, id);

  public void setInpFriendid(string id) => this.setId(this.InpFriendid, id);

  public void onChangeInpFriendid() => this.setInpFriendid(this.InpUI.value);

  public void RestoreInputLabelForNonMobileDevices() => this.InpUI.label = this.InpFriendid;
}
