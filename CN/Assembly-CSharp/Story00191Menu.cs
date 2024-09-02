// Decompiled with JetBrains decompiler
// Type: Story00191Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00191Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private GameObject BtnCredit;

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

  public void Init()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
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

  public void IbtnFriend()
  {
    if (this.IsPushAndSet())
      return;
    Friend0081Scene.ChangeScene(true);
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
    Story00191Menu.\u003COpen01271\u003Ec__Iterator4F3 open01271CIterator4F3 = new Story00191Menu.\u003COpen01271\u003Ec__Iterator4F3();
    return (IEnumerator) open01271CIterator4F3;
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
    return (IEnumerator) new Story00191Menu.\u003CbulkDownLoadCheck\u003Ec__Iterator4F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doBulkDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story00191Menu.\u003CdoBulkDownload\u003Ec__Iterator4F5 downloadCIterator4F5 = new Story00191Menu.\u003CdoBulkDownload\u003Ec__Iterator4F5();
    return (IEnumerator) downloadCIterator4F5;
  }

  public void IbtnAsct()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_18());
  }

  public void IbtnAs()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_19());
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

  public void IbtnDataFix()
  {
    if (this.IsPush)
      return;
    Singleton<NGGameDataManager>.GetInstance().isCallHomeUpdateAllData = true;
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGGameDataManager>.GetInstance().StartSceneAsyncProxy((Action<NGGameDataManager.StartSceneProxyResult>) (_ => Singleton<CommonRoot>.GetInstance().isLoading = false));
  }
}
