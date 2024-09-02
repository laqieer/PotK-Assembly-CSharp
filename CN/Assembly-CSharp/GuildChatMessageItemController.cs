// Decompiled with JetBrains decompiler
// Type: GuildChatMessageItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
            ((Component) this.guildMasterIcon).gameObject.SetActive(false);
            ((Component) this.guildSubmasterIcon).gameObject.SetActive(false);
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
    }
  }

  public void InitializeSimpleMessageItem(GuildChatMessageData messageData)
  {
    this.originalMessageData = messageData;
    Color white;
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
    else
    {
      // ISSUE: explicit constructor call
      ((Color) ref white).\u002Ector(1f, 0.706f, 0.0f);
      this.messageContent.supportEncoding = true;
    }
    string text1 = this.originalMessageData.senderName;
    if (text1.Length > 8)
      text1 = text1.Substring(0, 7) + Consts.GetInstance().GUILD_CHAT_ELLIPSIS;
    this.senderName.SetTextLocalize(text1);
    this.senderName.color = white;
    string text2 = !this.originalMessageData.isDeleted ? this.originalMessageData.messageContent : string.Empty;
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
    ((MonoBehaviour) Singleton<CommonRoot>.GetInstance().guildChatManager).StartCoroutine(this.ChatMessageClickedHandler(this.originalMessageData));
  }

  [DebuggerHidden]
  private IEnumerator ChatMessageClickedHandler(GuildChatMessageData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatMessageItemController.\u003CChatMessageClickedHandler\u003Ec__IteratorA53()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }

  public void OnLogMessageClicked()
  {
    Debug.Log((object) ("<color=yellow>Scene name: </color>" + this.originalMessageData.transition.scene_name));
    if (this.originalMessageData.transition.scene_name != "dlg_guild_bbs" && this.originalMessageData.transition.scene_name != "guild028_1" && this.originalMessageData.transition.scene_name != "guild028_4" && (this.originalMessageData.membership == null || this.originalMessageData.transition.scene_name != "guild028_6" && this.originalMessageData.transition.scene_name != "guild028_2"))
      return;
    ((MonoBehaviour) Singleton<CommonRoot>.GetInstance().guildChatManager).StartCoroutine(this.LogMessageClickedHandler(this.originalMessageData));
  }

  [DebuggerHidden]
  private IEnumerator LogMessageClickedHandler(GuildChatMessageData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatMessageItemController.\u003CLogMessageClickedHandler\u003Ec__IteratorA54()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }
}
