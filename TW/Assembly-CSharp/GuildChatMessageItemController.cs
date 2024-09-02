// Decompiled with JetBrains decompiler
// Type: GuildChatMessageItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildChatMessageItemController : MonoBehaviour
{
  private const int nameMaxLengthInSimpleView = 8;
  private const int contentMaxLengthInSimpleView = 19;
  [SerializeField]
  private UILabel messageContent;
  [SerializeField]
  private UILabel senderName;
  [SerializeField]
  private UILabel senderName2;
  [SerializeField]
  private UILabel sendTime;
  [SerializeField]
  private UILabel colon;
  [SerializeField]
  private UI2DSprite senderIcon;
  [SerializeField]
  private UIButton messageButton;
  [SerializeField]
  private UISprite guildMasterIcon;
  [SerializeField]
  private UISprite guildSubmasterIcon;
  [SerializeField]
  private UISprite stampImage;
  public GuildChatMessageData originalMessageData;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void InitializeDetailedMessageItem(GuildChatMessageData messageData)
  {
    this.originalMessageData = messageData;
    this.sendTime.SetTextLocalize(messageData.GetFormattedSendTime());
    if (this.originalMessageData.isDeleted)
      return;
    if (this.originalMessageData.messageType == GuildChatMessageData.GuildChatMessageType.MemberStamp || this.originalMessageData.messageType == GuildChatMessageData.GuildChatMessageType.PlayerStamp)
      Singleton<CommonRoot>.GetInstance().guildChatManager.SetStampSprite(this.stampImage, this.originalMessageData.stampID);
    else
      this.messageContent.SetTextLocalize(this.originalMessageData.messageContent);
    if (this.originalMessageData.messageType != GuildChatMessageData.GuildChatMessageType.SystemLog)
    {
      Singleton<CommonRoot>.GetInstance().guildChatManager.SetSprite(this.senderIcon, this.originalMessageData.spriteID);
      this.senderName.SetTextLocalize(this.originalMessageData.senderName);
      this.senderName2.SetTextLocalize(this.originalMessageData.senderName);
      ((Component) this.guildMasterIcon).gameObject.SetActive(false);
      ((Component) this.guildSubmasterIcon).gameObject.SetActive(false);
      ((Component) this.senderName).gameObject.SetActive(false);
      ((Component) this.senderName2).gameObject.SetActive(false);
      if (this.originalMessageData.membership != null)
      {
        switch (this.originalMessageData.membership.role)
        {
          case GuildRole.sub_master:
            ((Component) this.guildSubmasterIcon).gameObject.SetActive(true);
            ((Component) this.senderName2).gameObject.SetActive(true);
            break;
          case GuildRole.master:
            ((Component) this.guildMasterIcon).gameObject.SetActive(true);
            ((Component) this.senderName2).gameObject.SetActive(true);
            break;
          default:
            ((Component) this.senderName).gameObject.SetActive(true);
            break;
        }
      }
      else
        ((Component) this.senderName).gameObject.SetActive(true);
    }
    switch (this.originalMessageData.messageType)
    {
      case GuildChatMessageData.GuildChatMessageType.PlayerChat:
      case GuildChatMessageData.GuildChatMessageType.MemberChat:
        EventDelegate.Set(this.messageButton.onClick, new EventDelegate.Callback(this.OnChatMessageClicked));
        break;
      case GuildChatMessageData.GuildChatMessageType.PlayerLog:
      case GuildChatMessageData.GuildChatMessageType.MemberLog:
      case GuildChatMessageData.GuildChatMessageType.SystemLog:
        EventDelegate.Set(this.messageButton.onClick, new EventDelegate.Callback(this.OnLogMessageClicked));
        break;
      case GuildChatMessageData.GuildChatMessageType.PlayerStamp:
      case GuildChatMessageData.GuildChatMessageType.MemberStamp:
        EventDelegate.Set(this.messageButton.onClick, new EventDelegate.Callback(this.OnStampMessageClicked));
        break;
    }
  }

  public void InitializeSimpleMessageItem(GuildChatMessageData messageData)
  {
    this.originalMessageData = messageData;
    Color white = Color.white;
    if (messageData.messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat || messageData.messageType == GuildChatMessageData.GuildChatMessageType.MemberChat)
    {
      white = Color.white;
      this.messageContent.supportEncoding = false;
    }
    else if (messageData.messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)
    {
      // ISSUE: explicit constructor call
      ((Color) ref white).\u002Ector(0.278f, 0.776f, 0.349f);
      this.messageContent.supportEncoding = true;
    }
    else if (messageData.messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog || messageData.messageType == GuildChatMessageData.GuildChatMessageType.MemberLog)
    {
      // ISSUE: explicit constructor call
      ((Color) ref white).\u002Ector(1f, 0.706f, 0.0f);
      this.messageContent.supportEncoding = true;
    }
    else if (messageData.messageType == GuildChatMessageData.GuildChatMessageType.PlayerStamp || messageData.messageType == GuildChatMessageData.GuildChatMessageType.MemberStamp)
    {
      white = Color.white;
      this.messageContent.supportEncoding = false;
    }
    string text1 = this.originalMessageData.senderName;
    if (text1.Length > 8)
      text1 = text1.Substring(0, 7) + Consts.GetInstance().GUILD_CHAT_ELLIPSIS;
    this.senderName.SetTextLocalize(text1);
    this.senderName.color = white;
    string empty = string.Empty;
    string text2 = messageData.messageType == GuildChatMessageData.GuildChatMessageType.PlayerStamp || messageData.messageType == GuildChatMessageData.GuildChatMessageType.MemberStamp ? Consts.GetInstance().GUILD_CHAT_SIMPLE_MESSAGE_STAMP_SENT : (!this.originalMessageData.isDeleted ? this.originalMessageData.messageContent : string.Empty);
    if (text2.Length > 19)
      text2 = text2.Substring(0, 18) + Consts.GetInstance().GUILD_CHAT_ELLIPSIS;
    this.messageContent.SetTextLocalize(text2);
    this.messageContent.color = white;
    this.colon.color = white;
  }

  public void InitializeMemberLogItem(GuildChatMessageData messageData)
  {
    this.originalMessageData = messageData;
    this.sendTime.SetTextLocalize(messageData.GetFormattedSendTime());
    this.messageContent.SetTextLocalize(this.originalMessageData.messageContent);
  }

  public void UpdateDisplayingSendTime()
  {
    this.sendTime.SetTextLocalize(this.originalMessageData.GetFormattedSendTime());
  }

  public void OnChatMessageClicked()
  {
    if (this.originalMessageData.membership == null)
      return;
    this.StartCoroutine(this.ChatMessageClickedHandler(this.originalMessageData));
  }

  [DebuggerHidden]
  private IEnumerator ChatMessageClickedHandler(GuildChatMessageData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatMessageItemController.\u003CChatMessageClickedHandler\u003Ec__IteratorB31()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }

  public void OnLogMessageClicked()
  {
    Debug.Log((object) ("<color=yellow>Scene name: </color>" + this.originalMessageData.transition.scene_name));
    if (this.originalMessageData.transition.scene_name != "dlg_guild_bbs" && this.originalMessageData.transition.scene_name != "guild028_1" && this.originalMessageData.transition.scene_name != "guild028_4" && (this.originalMessageData.transition.scene_name != "guild028_6" && this.originalMessageData.transition.scene_name != "guild028_2" || this.originalMessageData.membership == null))
      return;
    this.StartCoroutine(this.LogMessageClickedHandler(this.originalMessageData));
  }

  [DebuggerHidden]
  private IEnumerator LogMessageClickedHandler(GuildChatMessageData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatMessageItemController.\u003CLogMessageClickedHandler\u003Ec__IteratorB32()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }

  private void OnStampMessageClicked()
  {
  }
}
