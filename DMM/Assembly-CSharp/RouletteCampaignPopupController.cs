// Decompiled with JetBrains decompiler
// Type: RouletteCampaignPopupController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class RouletteCampaignPopupController : MonoBehaviour
{
  private string campaignURL;

  public void Init(string campaignURL) => this.campaignURL = campaignURL;

  public void OnTapApply() => Application.OpenURL(this.campaignURL);

  public void OnTapReturn()
  {
    ModalWindow.ShowYesNo("確認", Consts.GetInstance().ROULETTE_CLOSE_CAMPAIGN_POPUP_CONTENT, (System.Action) (() =>
    {
      Singleton<PopupManager>.GetInstance().closeAllWithoutAnim();
      Singleton<NGSceneManager>.GetInstance().backScene();
    }), (System.Action) (() => this.gameObject.SetActive(true)));
    this.gameObject.SetActive(false);
  }
}
