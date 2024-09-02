// Decompiled with JetBrains decompiler
// Type: FacebookLogin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.Unity;
using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FacebookLogin : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected GameObject FBButtonLogin;
  [SerializeField]
  protected GameObject FBButtonLogout;
  [SerializeField]
  private UIScrollView scrollView;
  private GameObject yesNoPopup;
  private UIButton[] buttons = new UIButton[0];
  private CoroutineData<bool> FBCoroutine;

  public void Init()
  {
    if (Persist.auth.Data.FBLoginStatus)
    {
      this.TxtTitle.SetText(Consts.Lookup("FACEBOOK_LOGOUT_TOPPAGE_TITLE"));
      this.TxtDescription.SetText(Consts.Lookup("FACEBOOK_LOGOUT_TOPPAGE_DESCRIPTION"));
      this.FBButtonLogin.SetActive(false);
      this.FBButtonLogout.SetActive(true);
    }
    else
    {
      this.TxtTitle.SetText(Consts.Lookup("FACEBOOK_LOGIN_TOPPAGE_TITLE"));
      this.TxtDescription.SetText(Consts.Lookup("FACEBOOK_LOGIN_TOPPAGE_DESCRIPTION"));
      this.FBButtonLogin.SetActive(true);
      this.FBButtonLogout.SetActive(false);
    }
    ((Component) this).gameObject.SetActive(true);
    this.scrollView.ResetPosition();
    this.buttons = ((Component) this).GetComponentsInChildren<UIButton>();
    foreach (UIButton button in this.buttons)
      button.isEnabled = true;
  }

  private void StartUpdate()
  {
    if (this.FBCoroutine != null && this.FBCoroutine.Running)
      return;
    FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
    {
      "public_profile",
      "email",
      "user_friends"
    }, new FacebookDelegate<ILoginResult>(this.AuthCallback));
    this.FBCoroutine = this.StartCoroutine<bool>(this.GenericUpdate());
  }

  private void StopUpdate() => this.StopCoroutine("GenericUpdate");

  [DebuggerHidden]
  private IEnumerator GenericUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FacebookLogin.\u003CGenericUpdate\u003Ec__Iterator145()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void InActive()
  {
    ((Component) ((Component) this).transform.root).GetComponent<TopSceneEN>().NextStateForStartGame();
    ((Component) ((Component) this).transform.root).GetComponent<TopSceneEN>().CloseFacebookPopup();
    if (this.FBCoroutine == null)
      return;
    this.FBCoroutine.Stop();
  }

  private void Awake()
  {
    if (!FB.IsInitialized)
      FB.Init((InitDelegate) (() => FB.ActivateApp()));
    else
      FB.ActivateApp();
  }

  public void FBlogin() => this.StartUpdate();

  private void AuthCallback(ILoginResult result)
  {
    if (FB.IsLoggedIn)
    {
      foreach (UIButton button in this.buttons)
        button.isEnabled = false;
      WebAPI.AuthDeviceFacebookSSO((Action<string, string>) ((DeviceID, SecretKey) =>
      {
        Debug.Log((object) "FB device already exist!  get account info and populate persist data!");
        Persist.auth.Data.DeviceID = DeviceID;
        Persist.auth.Data.SecretKey = SecretKey;
        Persist.auth.Data.FBLoginStatus = true;
        Persist.auth.Flush();
        this.InActive();
      }), (Action<string>) (FBNoDeviceError =>
      {
        if (!(FBNoDeviceError == "FBと連携なし"))
          return;
        WebAPI.AccountRelateFacebookSSO((System.Action) (() =>
        {
          Persist.auth.Data.FBLoginStatus = true;
          Persist.auth.Flush();
          this.InActive();
        }), (Action<string>) (error => Debug.LogError((object) ("FB relate Failure! " + error))));
      }));
    }
    else
    {
      Debug.LogError((object) "FB Login fail");
      this.FBCoroutine.Stop();
    }
  }

  public void FBlogout()
  {
    this.yesNoPopup = ((Component) ModalWindow.ShowYesNo(Consts.Lookup("FACEBOOK_LOGOUT_CONFIRM_TITLE"), Consts.Lookup("FACEBOOK_LOGOUT_CONFIRM_DESCRIPTION"), (System.Action) (() =>
    {
      FB.LogOut();
      Persist.auth.Data.ResetAllAuthInfo();
      Persist.auth.Flush();
      Persist.notification.Delete();
      ModalWindow.Show(Consts.Lookup("FACEBOOK_LOGOUT_SUCCESS_TITLE"), Consts.Lookup("FACEBOOK_LOGOUT_SUCCESS_DESCRIPTION"), (System.Action) (() => this.StartCoroutine(StartScript.Restart(0.1f))));
    }), (System.Action) (() => Object.DestroyObject((Object) this.yesNoPopup)))).gameObject;
  }
}
