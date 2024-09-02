// Decompiled with JetBrains decompiler
// Type: Story00191FAQMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00191FAQMenu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private GameObject BtnCredit;
  private bool backBlock;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBase()
  {
  }

  public virtual void IbtnBaseWithoutIcon()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public void Init() => this.backBlock = false;

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    this.changeScene("mypage", false, true);
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnStory()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  public void IbtnColosseumTitle()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("title024_1", true);
  }

  public void IbtnBook()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_1", true);
  }

  public void IbtnOption()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("setting010_1", true);
  }

  [DebuggerHidden]
  private IEnumerator Open01271()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story00191FAQMenu.\u003COpen01271\u003Ec__Iterator546 open01271CIterator546 = new Story00191FAQMenu.\u003COpen01271\u003Ec__Iterator546();
    return (IEnumerator) open01271CIterator546;
  }

  public void IbtnTransfer()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Open01271());
  }

  public void IbtnInvite()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("invite013_1", true);
  }

  public void IbtnSerialcode()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("serial014_1", true);
  }

  public void IbtnColaboSerialcode()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("colabo025_1", true);
  }

  public void IbtnHelp()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_1", true);
  }

  public void IbtnBeginnerNavi()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_5", true);
  }

  public void IbtnPurchase()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("purchase016_2", true);
  }

  public void IbtnUsepolicy()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_17", true);
  }

  public void IbtnCopyright()
  {
    if (this.IsPushAndSet())
      return;
    Mypage00113Scene.changeScene(true);
  }

  public void IbtnCredit()
  {
  }

  public void IbtnBulkDownload()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.bulkDownLoadCheck());
  }

  public void showBtnCredit(bool isShow) => this.BtnCredit.SetActive(isShow);

  public void IbtnOffisialsite()
  {
    Debug.Log((object) "Go to the offical site.");
    DeviceManager.OpenUrl(Consts.GetInstance().OFFICAL_SITE_URL);
  }

  [DebuggerHidden]
  private IEnumerator bulkDownLoadCheck()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191FAQMenu.\u003CbulkDownLoadCheck\u003Ec__Iterator547()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doBulkDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191FAQMenu.\u003CdoBulkDownload\u003Ec__Iterator548()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Open00718()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story00191FAQMenu.\u003COpen00718\u003Ec__Iterator549 open00718CIterator549 = new Story00191FAQMenu.\u003COpen00718\u003Ec__Iterator549();
    return (IEnumerator) open00718CIterator549;
  }

  public void IbtnAsct()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Open00718());
  }

  [DebuggerHidden]
  private IEnumerator Open00719()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story00191FAQMenu.\u003COpen00719\u003Ec__Iterator54A open00719CIterator54A = new Story00191FAQMenu.\u003COpen00719\u003Ec__Iterator54A();
    return (IEnumerator) open00719CIterator54A;
  }

  public void IbtnAs()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Open00719());
  }

  public void IbtnBlacklist()
  {
  }

  public void IbtnInviteFriend()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_12", true);
  }

  public void IbtnLobi()
  {
    if (DeviceManager.CanLaunchIntent(Consts.GetInstance().LOBI_INTENT))
      DeviceManager.OpenUrl(Consts.GetInstance().LOBI_OPEN_APPLI_SCHEME);
    else
      DeviceManager.OpenUrl(Consts.GetInstance().LOBI_OPEN_WEBPAGE_SCHEME);
  }
}
