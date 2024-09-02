// Decompiled with JetBrains decompiler
// Type: NGWeb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class NGWeb : Singleton<NGWeb>
{
  protected override void Initialize()
  {
  }

  private void Start()
  {
    WebAPI.DefaultUserErrorCallback = new Action<WebAPI.Response.UserError>(this.apiUserErrorCallback);
    WebQueue.FailAuthTokenCallback = new Func<WebError, IEnumerator>(this.apiAuthTokenErrorDispatch);
    WebQueue.FailCallback = new Func<WebError, IEnumerator>(this.apiErrorDispatch);
    WebQueue.Logger = new Action<object>(Debug.Log);
    this.StartCoroutine(WebQueue.RunWorker());
  }

  [DebuggerHidden]
  private IEnumerator apiErrorDispatch(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiErrorDispatch\u003Ec__Iterator8F1()
    {
      error = error,
      \u003C\u0024\u003Eerror = error,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator apiAuthTokenErrorDispatch(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiAuthTokenErrorDispatch\u003Ec__Iterator8F2()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }

  [DebuggerHidden]
  private IEnumerator apiClientErrorCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiClientErrorCallback\u003Ec__Iterator8F3()
    {
      error = error,
      \u003C\u0024\u003Eerror = error,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator apiServerErrorCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiServerErrorCallback\u003Ec__Iterator8F4()
    {
      error = error,
      \u003C\u0024\u003Eerror = error,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator apiRetryOutErrorCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiRetryOutErrorCallback\u003Ec__Iterator8F5()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }

  private void MNT999orBAN001orBAN002(WebAPI.Response.UserError error)
  {
    if (Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstance(), (Object) null))
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    CommonRoot instance1 = Singleton<CommonRoot>.GetInstance();
    if (Object.op_Inequality((Object) instance1, (Object) null))
      Object.Destroy((Object) ((Component) instance1).gameObject);
    NGSceneManager instance2 = Singleton<NGSceneManager>.GetInstance();
    if (Object.op_Inequality((Object) instance2, (Object) null))
      Object.Destroy((Object) ((Component) instance2).gameObject);
    if (error.Code == "MNT999")
      SceneManager.LoadScene("startup000_6_2");
    else if (error.Code == "BAN001")
    {
      SceneManager.LoadScene("startup000_6_3");
    }
    else
    {
      if (!(error.Code == "BAN002"))
        return;
      SceneManager.LoadScene("startup000_6_3");
    }
  }

  private void apiUserErrorCallback(WebAPI.Response.UserError error)
  {
    if (error.Code == "MNT999" || error.Code == "BAN001" || error.Code == "BAN002")
      this.MNT999orBAN001orBAN002(error);
    else
      ModalWindow.Show(error.Code, error.Reason, (System.Action) (() =>
      {
        if (!Object.op_Equality((Object) Singleton<PopupManager>.GetInstanceOrNull(), (Object) null) && Singleton<PopupManager>.GetInstance().isOpen)
          return;
        NGSceneManager instanceOrNull = Singleton<NGSceneManager>.GetInstanceOrNull();
        if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
          return;
        NGSceneBase sceneBase = instanceOrNull.sceneBase;
        if (!Object.op_Inequality((Object) sceneBase, (Object) null))
          return;
        sceneBase.IsPush = false;
      }));
  }

  private void changeErrorPage(WebError error)
  {
    if (error.Request.IsAuthAccessToken)
    {
      Debug.LogError((object) "fail get access token. so clear request queue(exclude auth queue).");
      WebQueue.ClearRequestQueue();
    }
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.RestartGame();
    else
      SceneManager.LoadScene("startup000_6");
  }

  public void ShowTranferModalWindow(System.Action yes, System.Action no)
  {
    this.StartCoroutine(this.ShowTranferModalWindowCore(yes, no));
  }

  [DebuggerHidden]
  private IEnumerator ShowTranferModalWindowCore(System.Action yes, System.Action no)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CShowTranferModalWindowCore\u003Ec__Iterator8F6()
    {
      yes = yes,
      no = no,
      \u003C\u0024\u003Eyes = yes,
      \u003C\u0024\u003Eno = no
    };
  }
}
