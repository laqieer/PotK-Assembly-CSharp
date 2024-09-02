// Decompiled with JetBrains decompiler
// Type: GuildChatContextMenuDialogController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class GuildChatContextMenuDialogController : MonoBehaviour
{
  private GuildChatMessageData originalData;
  [SerializeField]
  private UILabel playerNameLabel;
  [SerializeField]
  private UILabel customizedButtonLabel;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Initialize(GuildChatMessageData data)
  {
    this.originalData = data;
    if (Object.op_Inequality((Object) this.playerNameLabel, (Object) null))
      this.playerNameLabel.SetTextLocalize(this.originalData.senderName);
    if (!Object.op_Inequality((Object) this.customizedButtonLabel, (Object) null))
      return;
    switch (this.originalData.transition.scene_name)
    {
      case "dlg_guild_bbs":
        this.customizedButtonLabel.SetTextLocalize(Consts.GetInstance().GUILD_CHAT_CUSTOMIZED_BUTTON_TITLE_BBS);
        break;
      case "guild028_4":
        this.customizedButtonLabel.SetTextLocalize(Consts.GetInstance().GUILD_CHAT_CUSTOMIZED_BUTTON_TITLE_GUILD_TITLE);
        break;
      case "guild028_6":
        this.customizedButtonLabel.SetTextLocalize(Consts.GetInstance().GUILD_CHAT_CUSTOMIZED_BUTTON_TITLE_GIFT);
        break;
      case "guild028_2":
        this.customizedButtonLabel.SetTextLocalize(Consts.GetInstance().GUILD_CHAT_CUSTOMIZED_BUTTON_TITLE_GUILD_MAP);
        break;
      case "guild028_1":
        this.customizedButtonLabel.SetTextLocalize(Consts.GetInstance().GUILD_CHAT_CUSTOMIZED_BUTTON_TITLE_GUILD_HQ);
        break;
    }
  }

  public void OnCloseButtonClicked() => Singleton<PopupManager>.GetInstance().dismiss();

  public void OnMemberDetailButtonClicked()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Singleton<CommonRoot>.GetInstance().guildChatManager.OnCloseButtonClicked();
    Guild0282Scene.ChangeSceneOrMemberFocus(this.originalData.membership, (Guild0282Menu) null);
  }

  public void OnCustomizedButtonClicked()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    string sceneName = this.originalData.transition.scene_name;
    if (sceneName.StartsWith("dlg"))
    {
      if (!(sceneName == "dlg_guild_bbs"))
        return;
      Singleton<CommonRoot>.GetInstance().guildChatManager.OpenBBSViewerDialog();
    }
    else
    {
      switch (sceneName)
      {
        case "guild028_4":
          Guild0284Scene.ChangeScene();
          break;
        case "guild028_6":
          Guild0286Scene.ChangeScene();
          break;
        case "guild028_2":
          Singleton<CommonRoot>.GetInstance().guildChatManager.OnCloseButtonClicked();
          Guild0282Scene.ChangeSceneOrMemberFocus(this.originalData.membership, (Guild0282Menu) null);
          break;
        case "guild028_1":
          Guild0281Menu component = ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0281Menu>();
          Guild0281Scene.ChangeSceneHQTop(menu: component);
          if (!Object.op_Inequality((Object) component, (Object) null))
            break;
          Singleton<CommonRoot>.GetInstance().guildChatManager.CloseDetailedChat();
          break;
      }
    }
  }
}
