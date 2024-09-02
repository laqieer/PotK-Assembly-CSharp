// Decompiled with JetBrains decompiler
// Type: NGWeb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
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
  }

  [DebuggerHidden]
  private IEnumerator apiErrorDispatch(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiErrorDispatch\u003Ec__IteratorB65()
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
    return (IEnumerator) new NGWeb.\u003CapiAuthTokenErrorDispatch\u003Ec__IteratorB66()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }

  [DebuggerHidden]
  private IEnumerator apiClientErrorCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CapiClientErrorCallback\u003Ec__IteratorB67()
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
    return (IEnumerator) new NGWeb.\u003CapiServerErrorCallback\u003Ec__IteratorB68()
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
    return (IEnumerator) new NGWeb.\u003CapiRetryOutErrorCallback\u003Ec__IteratorB69()
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
    else if (error.Reason.Contains(Consts.GetInstance().server_not_found))
      ModalWindow.Show(error.Code, Consts.GetInstance().temporarily_not_open, (System.Action) (() =>
      {
        Debug.Log((object) "on ok callback() on ok button");
        WebQueue.UnLock();
      }));
    else
      ModalWindow.Show(error.Code, error.Reason, (System.Action) (() =>
      {
        if (Object.op_Equality((Object) Singleton<PopupManager>.GetInstanceOrNull(), (Object) null) || !Singleton<PopupManager>.GetInstance().isOpen)
        {
          NGSceneManager instanceOrNull = Singleton<NGSceneManager>.GetInstanceOrNull();
          if (Object.op_Inequality((Object) instanceOrNull, (Object) null))
          {
            NGSceneBase sceneBase = instanceOrNull.sceneBase;
            if (Object.op_Inequality((Object) sceneBase, (Object) null))
              sceneBase.IsPush = false;
          }
        }
        Debug.Log((object) "on ok callback() on ok button");
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
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.RestartGame();
  }

  public void ShowTranferModalWindow(System.Action yes, System.Action no)
  {
    this.StartCoroutine(this.ShowTranferModalWindowCore(yes, no));
  }

  [DebuggerHidden]
  private IEnumerator ShowTranferModalWindowCore(System.Action yes, System.Action no)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGWeb.\u003CShowTranferModalWindowCore\u003Ec__IteratorB6A()
    {
      yes = yes,
      no = no,
      \u003C\u0024\u003Eyes = yes,
      \u003C\u0024\u003Eno = no
    };
  }
}
