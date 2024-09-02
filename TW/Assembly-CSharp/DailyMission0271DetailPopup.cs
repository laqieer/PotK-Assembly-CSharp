// Decompiled with JetBrains decompiler
// Type: DailyMission0271DetailPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class DailyMission0271DetailPopup : BackButtonMonoBehaiviour
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
  private UILabel progressLabel;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollView;
  private DailyMission0271PanelRoot.DailyMissionView view;
  private string changeSchene;
  private int? arg1;

  [DebuggerHidden]
  public IEnumerator Init(DailyMission0271PanelRoot.DailyMissionView v, DailyMission0271Panel panel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271DetailPopup.\u003CInit\u003Ec__Iterator6B8()
    {
      v = v,
      \u003C\u0024\u003Ev = v,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();

  public void onTry()
  {
    bool flag = true;
    if (!string.IsNullOrEmpty(this.changeSchene))
    {
      if (this.changeSchene == "mypage001_8_2")
        Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) this.arg1);
      else if (this.changeSchene == "quest002_4")
      {
        PlayerStoryQuestS[] source = SMManager.Get<PlayerStoryQuestS[]>();
        if (this.arg1.HasValue && MasterData.QuestStoryS.ContainsKey(this.arg1.Value) && ((IEnumerable<PlayerStoryQuestS>) source).Any<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x._quest_story_s == this.arg1.Value)))
          Quest00240723Scene.ChangeScene0024(false, MasterData.QuestStoryS[this.arg1.Value].quest_l_QuestStoryL);
        else
          Quest00240723Scene.ChangeScene0024(false, ((IEnumerable<PlayerStoryQuestS>) source).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (x => x.quest_story_s.quest_l_QuestStoryL)).Max());
      }
      else if (this.changeSchene == "quest002_20" || this.changeSchene == "quest002_19" || this.changeSchene == "quest002_26")
      {
        if (this.arg1.HasValue)
        {
          this.StartCoroutine(this.onBannerEventConnection(this.changeSchene, this.arg1.Value));
          flag = false;
        }
        else
          Quest00217Scene.ChangeScene(false);
      }
      else if (this.changeSchene == "gacha006_3")
      {
        if (this.arg1.HasValue)
          Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, false, (object) this.arg1.Value);
        else
          Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene);
      }
      else if (this.changeSchene == "shop007_21")
        Shop00721Scene.changeScene(false, true);
      else if (this.changeSchene == "quest002_30")
        Quest00230Scene.ChangeScene(false, this.arg1.Value);
      else if (this.changeSchene.StartsWith("colosseum023"))
      {
        if (!SMManager.Get<Player>().GetFeatureColosseum() || !SMManager.Get<Player>().GetReleaseColosseum())
        {
          Singleton<PopupManager>.GetInstance().onDismiss();
          this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().DAILY_MISSION_0271_POPUP_TITLE, Consts.GetInstance().DAILY_MISSION_0271_COLOSSEUM));
          flag = false;
        }
        else
          Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true);
      }
      else
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true);
    }
    if (!flag)
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  [DebuggerHidden]
  private IEnumerator onBannerEventConnection(string changeSchene, int sID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271DetailPopup.\u003ConBannerEventConnection\u003Ec__Iterator6B9()
    {
      sID = sID,
      changeSchene = changeSchene,
      \u003C\u0024\u003EsID = sID,
      \u003C\u0024\u003EchangeSchene = changeSchene
    };
  }
}
