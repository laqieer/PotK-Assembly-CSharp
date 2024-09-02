// Decompiled with JetBrains decompiler
// Type: Story00191Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.Unity;
using GameCore;
using gu3.Device;
using System;
using System.Collections;
using System.Collections.Generic;
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
    Story00191Menu.\u003COpen01271\u003Ec__Iterator452 open01271CIterator452 = new Story00191Menu.\u003COpen01271\u003Ec__Iterator452();
    return (IEnumerator) open01271CIterator452;
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

  public void IbtnFacebookLogin() => this.StartCoroutine(this.IbtnFacebookLoginConfirm());

  [DebuggerHidden]
  public IEnumerator IbtnFacebookLoginConfirm()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191Menu.\u003CIbtnFacebookLoginConfirm\u003Ec__Iterator453()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnFacebookLogout()
  {
    PopupCommonYesNo.Show(Consts.Lookup("FACEBOOK_LOGOUT_CONFIRM_TITLE"), Consts.Lookup("FACEBOOK_LOGOUT_CONFIRM_DESCRIPTION"), (System.Action) (() =>
    {
      FB.LogOut();
      Persist.auth.Data.ResetAllAuthInfo();
      Persist.auth.Flush();
      Persist.notification.Delete();
      this.StartCoroutine(this.LogoutResult());
    }), (System.Action) (() => Singleton<PopupManager>.GetInstance().onDismiss()));
  }

  [DebuggerHidden]
  public IEnumerator LogoutResult()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191Menu.\u003CLogoutResult\u003Ec__Iterator454()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnFacebookLoginStart()
  {
    if (!FB.IsInitialized)
      FB.Init((InitDelegate) (() =>
      {
        Debug.Log((object) "FB init complete");
        FB.ActivateApp();
      }));
    else
      FB.ActivateApp();
    FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
    {
      "public_profile",
      "email",
      "user_friends"
    }, new FacebookDelegate<ILoginResult>(this.FacebookLoginCallback));
  }

  public void FacebookLoginCallback(ILoginResult result)
  {
    if (FB.IsLoggedIn)
      WebAPI.AuthDeviceFacebookSSO((Action<string, string>) ((DeviceID, SecretKey) =>
      {
        Debug.LogError((object) "FB device already exist!  get account info and populate persist data!");
        PopupCommonYesNo.Show(Consts.Lookup("FACEBOOK_CONNECT"), Consts.Lookup("FACEBOOK_CONNECT_DESCRIPTION"), (System.Action) (() =>
        {
          Singleton<PopupManager>.GetInstance().onDismiss();
          Persist.auth.Data.DeviceID = DeviceID;
          Persist.auth.Data.SecretKey = SecretKey;
          Persist.auth.Data.FBLoginStatus = true;
          Persist.auth.Flush();
          this.StartCoroutine(this.LoginResult());
        }), (System.Action) (() => Singleton<PopupManager>.GetInstance().onDismiss()));
      }), (Action<string>) (FBNoDeviceError =>
      {
        if (!(FBNoDeviceError == "FBと連携なし"))
          return;
        WebAPI.AccountRelateFacebookSSO((System.Action) (() =>
        {
          Persist.auth.Data.FBLoginStatus = true;
          Persist.auth.Flush();
          this.StartCoroutine(this.LoginResult());
        }), (Action<string>) (error => Debug.LogError((object) ("Facebook account linking Failure! " + error))));
      }));
    else
      Debug.LogError((object) "FB Login fail");
  }

  [DebuggerHidden]
  public IEnumerator LoginResult()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191Menu.\u003CLoginResult\u003Ec__Iterator455()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Close() => Singleton<PopupManager>.GetInstance().onDismiss();

  public void ShowAchievementsUI() => Singleton<SocialManager>.GetInstance().ShowAchievementsUI();

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

  public void IbtnOffisialsite() => DeviceManager.OpenUrl(Consts.Lookup("OFFICAL_SITE_URL"));

  [DebuggerHidden]
  private IEnumerator bulkDownLoadCheck()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00191Menu.\u003CbulkDownLoadCheck\u003Ec__Iterator456()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doBulkDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story00191Menu.\u003CdoBulkDownload\u003Ec__Iterator457 downloadCIterator457 = new Story00191Menu.\u003CdoBulkDownload\u003Ec__Iterator457();
    return (IEnumerator) downloadCIterator457;
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
