// Decompiled with JetBrains decompiler
// Type: Transfer01271Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public class Transfer01271Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;

  public void Init() => ((Component) this.scroll.scrollView).transform.localPosition = Vector3.zero;

  public void IbtnPopupPublish()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Consts c = Consts.GetInstance();
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    WebAPI.AuthPasscode((Action<string, int>) ((code, expire) =>
    {
      DateTime timeLimit = DateTime.Now.AddSeconds((double) expire);
      Transfer01272Scene.ChangeScene(true, code, timeLimit);
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    }), (Action<string>) (error =>
    {
      this.StartCoroutine(PopupCommon.Show(c.API_CLIENT_ERROR_TITLE, c.PASSCODE_ERROR_MESSAGE));
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    }));
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
