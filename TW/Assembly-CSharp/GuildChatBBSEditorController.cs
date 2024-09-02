﻿// Decompiled with JetBrains decompiler
// Type: GuildChatBBSEditorController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildChatBBSEditorController : MonoBehaviour
{
  [SerializeField]
  private UILabel textMessage;
  [SerializeField]
  private UIInput inputField;
  [SerializeField]
  private UILabel characterCountLabel;
  [SerializeField]
  private UIButton confirmButton;
  private GuildChatManager guildChatManager;
  private bool isSendingBBSContent;

  private void Start() => this.inputField.isSelected = true;

  private void Update()
  {
  }

  public void InitializeBBSEditorDialog()
  {
    this.guildChatManager = Singleton<CommonRoot>.GetInstance().guildChatManager;
    this.inputField.value = PlayerAffiliation.Current.guild.private_message;
    this.isSendingBBSContent = false;
  }

  public void OnBBSEditorCancelButtonClicked()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.guildChatManager.OpenBBSViewerDialog();
  }

  public void OnBBSEditorConfirmButtonClicked()
  {
    if (this.isSendingBBSContent)
      return;
    this.isSendingBBSContent = true;
    this.StartCoroutine(this.UpdateBBSMessage());
  }

  [DebuggerHidden]
  private IEnumerator UpdateBBSMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatBBSEditorController.\u003CUpdateBBSMessage\u003Ec__IteratorB1C()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ErrorCallback(WebAPI.Response.UserError error)
  {
    this.isSendingBBSContent = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Code == "GLD011")
      this.StartCoroutine(this.OpenNGWordDialog());
    else if (error.Code == "GLD015")
    {
      Singleton<PopupManager>.GetInstance().dismiss();
      Singleton<CommonRoot>.GetInstance().guildChatManager.StartMaintenanceMode();
    }
    else
      WebAPI.DefaultUserErrorCallback(error);
  }

  [DebuggerHidden]
  private IEnumerator OpenNGWordDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GuildChatBBSEditorController.\u003COpenNGWordDialog\u003Ec__IteratorB1D dialogCIteratorB1D = new GuildChatBBSEditorController.\u003COpenNGWordDialog\u003Ec__IteratorB1D();
    return (IEnumerator) dialogCIteratorB1D;
  }

  public void OnInputContentChanged()
  {
    this.characterCountLabel.SetTextLocalize(this.textMessage.text.Length.ToString() + "/" + (object) this.inputField.characterLimit);
    this.textMessage.SetTextLocalize(this.inputField.value);
    this.confirmButton.isEnabled = !this.inputField.value.isEmptyOrWhitespace();
  }
}
