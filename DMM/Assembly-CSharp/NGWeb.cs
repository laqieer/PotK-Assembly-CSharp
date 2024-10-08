﻿// Decompiled with JetBrains decompiler
// Type: NGWeb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using GameCore.FastMiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NGWeb : Singleton<NGWeb>
{
  protected override void Initialize()
  {
  }

  private void Start()
  {
    WebAPI.DefaultUserErrorCallback = new System.Action<WebAPI.Response.UserError>(this.apiUserErrorCallback);
    WebQueue.FailAuthTokenCallback = new Func<WebError, IEnumerator>(this.apiAuthTokenErrorDispatch);
    WebQueue.FailCallback = new Func<WebError, IEnumerator>(this.apiErrorDispatch);
    WebQueue.SafetyFailCallback = new Func<WebError, IEnumerator>(this.apiSafetyErrorDispatch);
    WebQueue.Logger = new System.Action<object>(Debug.Log);
  }

  private IEnumerator apiErrorDispatch(WebError error)
  {
    IEnumerator e;
    if (error.IsClientError())
    {
      e = this.apiClientErrorCallback(error);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else if (error.IsServerError())
    {
      e = this.apiServerErrorCallback(error);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else
    {
      e = this.apiRetryOutErrorCallback(error);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  private IEnumerator apiSafetyErrorDispatch(WebError error)
  {
    Consts instance = Consts.GetInstance();
    string title = instance.API_ERROR_SAFETY_TITLE;
    string message = instance.API_ERROR_SAFETY_MESSAGE;
    try
    {
      if (Json.Deserialize(error.Response.Bytes) is Dictionary<string, object> dictionary)
      {
        object obj;
        if (dictionary.TryGetValue("code", out obj))
        {
          if (!(obj is string str))
            str = title;
          title = str;
        }
        if (dictionary.TryGetValue("reason", out obj))
        {
          if (!(obj is string str))
            str = message;
          message = str;
        }
      }
    }
    catch (Exception ex)
    {
      Debug.LogException(ex);
    }
    error.Request.DropPacketAndIgnoreCallback();
    WebQueue.Lock();
    ModalWindow.Show(title, message, (System.Action) (() => this.changeErrorPage(error)));
    yield break;
  }

  private IEnumerator apiAuthTokenErrorDispatch(WebError error)
  {
    Consts instance = Consts.GetInstance();
    WebQueue.Lock();
    ModalWindow.Show(instance.API_AUTHTOKEN_ERROR_TITLE, instance.API_AUTHTOKEN_ERROR_MESSAGE, (System.Action) (() =>
    {
      Persist.auth.Data.ResetAllAuthInfo();
      Persist.auth.Flush();
      error.Request.DropPacketAndIgnoreCallback();
      WebQueue.UnLock();
      StartScript.Restart();
    }));
    yield break;
  }

  private IEnumerator apiClientErrorCallback(WebError error)
  {
    Consts instance = Consts.GetInstance();
    string title = instance.API_CLIENT_ERROR_TITLE;
    string message = instance.API_CLIENT_ERROR_MESSAGE;
    try
    {
      if (Json.Deserialize(error.Response.Bytes) is Dictionary<string, object> dictionary)
      {
        object obj;
        if (dictionary.TryGetValue("code", out obj))
        {
          if (!(obj is string str))
            str = title;
          title = str;
        }
        if (dictionary.TryGetValue("reason", out obj))
        {
          if (!(obj is string str))
            str = message;
          message = str;
        }
      }
    }
    catch (Exception ex)
    {
      Debug.LogException(ex);
    }
    error.Request.DropPacketAndIgnoreCallback();
    WebQueue.Lock();
    ModalWindow.Show(title, message, (System.Action) (() => this.changeErrorPage(error)));
    yield break;
  }

  private IEnumerator apiServerErrorCallback(WebError error)
  {
    Consts instance = Consts.GetInstance();
    WebQueue.Lock();
    ModalWindow.ShowRetryTitle(instance.API_SERVER_ERROR_TITLE, instance.API_SERVER_ERROR_MESSAGE, (System.Action) (() => error.Request.Retry()), (System.Action) (() =>
    {
      error.Request.DropPacketAndIgnoreCallback();
      this.changeErrorPage(error);
    }));
    yield break;
  }

  private IEnumerator apiRetryOutErrorCallback(WebError error)
  {
    error.Request.RestRetryCount = 1;
    Consts instance = Consts.GetInstance();
    WebQueue.Lock();
    ModalWindow.Show(instance.API_RETRYOUT_ERROR_TITLE, instance.API_RETRYOUT_ERROR_MESSAGE, (System.Action) (() => error.Request.Retry()));
    yield break;
  }

  private void MNT999orBAN001orBAN002(WebAPI.Response.UserError error)
  {
    if ((UnityEngine.Object) Singleton<CommonRoot>.GetInstance() != (UnityEngine.Object) null)
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    CommonRoot instance1 = Singleton<CommonRoot>.GetInstance();
    if ((UnityEngine.Object) instance1 != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) instance1.gameObject);
    NGSceneManager instance2 = Singleton<NGSceneManager>.GetInstance();
    if ((UnityEngine.Object) instance2 != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) instance2.gameObject);
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
        if (((UnityEngine.Object) Singleton<PopupManager>.GetInstanceOrNull() == (UnityEngine.Object) null ? 1 : (!Singleton<PopupManager>.GetInstance().isOpen ? 1 : 0)) != 0)
        {
          NGSceneManager instanceOrNull = Singleton<NGSceneManager>.GetInstanceOrNull();
          if ((UnityEngine.Object) instanceOrNull != (UnityEngine.Object) null)
          {
            NGSceneBase sceneBase = instanceOrNull.sceneBase;
            if ((UnityEngine.Object) sceneBase != (UnityEngine.Object) null)
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
    if ((UnityEngine.Object) instance != (UnityEngine.Object) null)
      instance.RestartGame();
    else
      SceneManager.LoadScene("startup000_6");
  }

  public void ShowTranferModalWindow(System.Action yes, System.Action no) => this.StartCoroutine(this.ShowTranferModalWindowCore(yes, no));

  private IEnumerator ShowTranferModalWindowCore(System.Action yes, System.Action no)
  {
    yield return (object) null;
    ModalWindow.ShowYesNo(Consts.GetInstance().user_transfer_title, Consts.GetInstance().user_transfer_text, yes, no);
  }
}
