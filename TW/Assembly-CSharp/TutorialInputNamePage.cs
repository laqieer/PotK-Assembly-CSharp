// Decompiled with JetBrains decompiler
// Type: TutorialInputNamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Bode;
using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialInputNamePage : TutorialPageBase
{
  private const int max_name_length = 8;
  [SerializeField]
  private string defaultName = "phantom";
  [SerializeField]
  private string message;
  [SerializeField]
  private GameObject popup;
  [SerializeField]
  private UI2DSprite background;
  [SerializeField]
  private UIInput input;
  [SerializeField]
  private bool isLocalCheck;
  private bool isProcessing;
  private Future<WebAPI.Response.PlayerSignup> signeup;

  private void Start()
  {
  }

  public override void Init(TutorialProgress progress_, TutorialAdvice advice_, GameObject root_)
  {
    base.Init(progress_, advice_, root_);
    this.input.onValidate = new UIInput.OnValidate(this.onValidate);
  }

  public override void ReleaseResources()
  {
    if (!Object.op_Implicit((Object) this.background.sprite2D))
      return;
    Object.Destroy((Object) this.background.sprite2D);
    this.background.sprite2D = (Sprite) null;
  }

  private char onValidate(string text, int charIndex, char addedChar)
  {
    return !this.isLocalCheck || !char.IsControl(addedChar) && (addedChar < '\uE000' || addedChar > '\uF8FF') ? addedChar : char.MinValue;
  }

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialInputNamePage.\u003CShow\u003Ec__Iterator872()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnOk()
  {
    if (this.isProcessing)
      return;
    this.isProcessing = true;
    string player_name = this.input.value;
    this.popup.SetActive(false);
    WebAPI.TutorialTutorialValid(player_name, (Action<WebAPI.Response.UserError>) (error =>
    {
      this.popup.SetActive(true);
      this.alert(error.Reason);
    })).RunOn<WebAPI.Response.TutorialTutorialValid>((MonoBehaviour) this, (Action<WebAPI.Response.TutorialTutorialValid>) (result =>
    {
      this.popup.SetActive(true);
      if (result.is_valid)
      {
        SMManager.Get<Player>().name = player_name;
        Persist.tutorial.Data.PlayerName = player_name;
        this.sdkRoleEvent(player_name);
        this.NextPage();
      }
      else
        this.alert(Consts.GetInstance().tutorial_fail_player_name);
    }));
  }

  private void sdkRoleEvent(string player_name)
  {
    SDKExtraObj sdkExtraObj = new SDKExtraObj();
    sdkExtraObj.roleId = SDK.instance.GetPlayID();
    sdkExtraObj.roleName = player_name;
    DDebug.Log(nameof (sdkRoleEvent));
    sdkExtraObj.zoneId = "Android";
    LCMNative_Android.createRole(sdkExtraObj.roleId, sdkExtraObj.roleName, sdkExtraObj.zoneId);
  }

  private void alert(string message)
  {
    this.isProcessing = false;
    this.advice.SetMessage((string) null, "#background black\n" + message);
    this.advice.Show();
  }
}
