// Decompiled with JetBrains decompiler
// Type: Guild028322Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Guild028322Popup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel popupDesc;
  private Guild0283Menu menu;

  public void Initialize(Guild0283Menu menu)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.menu = menu;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_CONFIRM_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_DESC5));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().closeAll();

  private IEnumerator DismissGuild()
  {
    Guild028322Popup guild028322Popup = this;
    Singleton<PopupManager>.GetInstance().closeAllWithoutAnim();
    while (Singleton<PopupManager>.GetInstance().isOpenNoFinish)
      yield return (object) null;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    // ISSUE: reference to a compiler-generated method
    Future<WebAPI.Response.GuildDissolute> ft = WebAPI.GuildDissolute(false, new System.Action<WebAPI.Response.UserError>(guild028322Popup.\u003CDismissGuild\u003Eb__5_0));
    IEnumerator e = ft.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (ft.Result != null)
    {
      if (Persist.guildHeaderChat.Exists)
      {
        Persist.guildHeaderChat.Data.reset();
        Persist.guildHeaderChat.Flush();
      }
      if (Persist.guildEventCheck.Exists)
      {
        Persist.guildEventCheck.Data.reset();
        Persist.guildEventCheck.Flush();
      }
      Singleton<NGGameDataManager>.GetInstance().chatDataList.Clear();
      Singleton<CommonRoot>.GetInstance().GetNormalHeaderComponent().headerChat.ChatReset();
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      Singleton<CommonRoot>.GetInstance().loadingMode = 0;
      Guild02811Scene.ChangeScene();
    }
  }

  public void onYesButton() => this.StartCoroutine(this.DismissGuild());
}
