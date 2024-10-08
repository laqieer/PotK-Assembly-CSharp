﻿// Decompiled with JetBrains decompiler
// Type: SeaTalkReply
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using UnityEngine;

public class SeaTalkReply : MonoBehaviour
{
  private const int TEXT_BASE_DIFF_HEIGHT = 30;
  [SerializeField]
  private UISprite baseSprite;
  [SerializeField]
  private UILabel replyLabel;
  public UIButton replyButton;
  [HideInInspector]
  public CallMessage CallMessage;
  private System.Action<CallMessage> onReplyAction;
  private bool isPush;

  public void Init(
    CallMessage callMessage,
    System.Action<CallMessage> onReplyAction,
    TalkUnitInfo talkUnitInfo,
    PlayerTalkMessage playerTalkMessage)
  {
    this.CallMessage = callMessage;
    this.onReplyAction = onReplyAction;
    this.replyLabel.text = SeaTalkCommon.GetReplaceMessage(callMessage.text, talkUnitInfo, playerTalkMessage);
    this.baseSprite.height = this.replyLabel.height + 30;
    this.isPush = false;
  }

  public float GetHeight() => (float) this.baseSprite.height;

  public void OnReply()
  {
    if (this.IsPushAndSet())
      return;
    this.onReplyAction(this.CallMessage);
  }

  public void OnCall()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Sea030HomeMenu.IsAutoCallButton = true;
    Sea030HomeScene.ChangeScene(false);
  }

  private bool IsPushAndSet()
  {
    if (this.isPush)
      return true;
    this.isPush = true;
    return false;
  }
}
