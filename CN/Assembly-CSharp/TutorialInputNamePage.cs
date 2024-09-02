// Decompiled with JetBrains decompiler
// Type: TutorialInputNamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    if (!this.isLocalCheck || !char.IsControl(addedChar) && (addedChar < '\uE000' || addedChar > '\uF8FF'))
      return addedChar;
    Debug.Log((object) ("invalid input char=" + (object) addedChar + " : " + (object) (int) addedChar));
    return char.MinValue;
  }

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialInputNamePage.\u003CShow\u003Ec__Iterator7A7()
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
        int coin = SMManager.Get<Player>().coin;
        Persist.tutorial.Data.PlayerName = player_name;
        this.sdkRoleEvent(player_name, coin);
        this.NextPage();
      }
      else
        this.alert(Consts.GetInstance().tutorial_fail_player_name);
    }));
  }

  private void sdkRoleEvent(string player_name, int coin)
  {
    SDKExtraObj sdkExtraObj = new SDKExtraObj();
    sdkExtraObj.roleId = SDK.instance.GetPlayID();
    sdkExtraObj.roleName = player_name;
    DDebug.Log("createRoleEvent");
    string balance = coin.ToString();
    SDK.instance.createRoleExtra(string.Empty, sdkExtraObj.roleName, "Android", string.Empty, balance);
  }

  private void alert(string message)
  {
    this.isProcessing = false;
    this.advice.SetMessage((string) null, "#background black\n" + message);
    this.advice.Show();
  }
}
