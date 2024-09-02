// Decompiled with JetBrains decompiler
// Type: DailyMission02712DetailPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission02712DetailPopup : BackButtonMenuBase
{
  [SerializeField]
  private GameObject button1;
  [SerializeField]
  private GameObject button2;
  [SerializeField]
  private GameObject rewardIcon;
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private UILabel detailLabel;
  [SerializeField]
  private UILabel rewardNameLabel;
  [SerializeField]
  private UILabel progressLabel;
  [SerializeField]
  private GameObject dirThumbImage;
  private DailyMission02712Panel panelObject;
  private DailyMission02712Menu.DailyMissionView view;
  private string changeSchene;

  [DebuggerHidden]
  public IEnumerator Init(DailyMission02712Menu.DailyMissionView v, DailyMission02712Panel panel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712DetailPopup.\u003CInit\u003Ec__Iterator5CD()
    {
      v = v,
      panel = panel,
      \u003C\u0024\u003Ev = v,
      \u003C\u0024\u003Epanel = panel,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void onTry()
  {
    if (this.view.isReviewMission)
      this.StartCoroutine(this.callReviewApi());
    else if (this.view.bingo_id == 1 && this.view.panel_id == 1)
    {
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_3", true, (object) 2);
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
    else if (this.changeSchene == "quest002_4")
    {
      Quest00240723Scene.ChangeScene0024(true, 1);
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
    else if (this.changeSchene.StartsWith("colosseum023"))
    {
      if (!SMManager.Get<Player>().GetFeatureColosseum() || !SMManager.Get<Player>().GetReleaseColosseum())
      {
        Singleton<PopupManager>.GetInstance().onDismiss();
        this.StartCoroutine(PopupCommon.Show(Consts.Lookup("DAILY_MISSION_0271_POPUP_TITLE"), Consts.Lookup("DAILY_MISSION_0271_COLOSSEUM")));
      }
      else
      {
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true);
        Singleton<PopupManager>.GetInstance().onDismiss();
      }
    }
    else
    {
      Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true);
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
  }

  [DebuggerHidden]
  private IEnumerator callReviewApi()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712DetailPopup.\u003CcallReviewApi\u003Ec__Iterator5CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadThumb(Bingo2RewardEntity reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712DetailPopup.\u003CloadThumb\u003Ec__Iterator5CF()
    {
      reward = reward,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u003Ef__this = this
    };
  }
}
