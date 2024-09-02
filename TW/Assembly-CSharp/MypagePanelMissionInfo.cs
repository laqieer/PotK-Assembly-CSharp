// Decompiled with JetBrains decompiler
// Type: MypagePanelMissionInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class MypagePanelMissionInfo : MonoBehaviour
{
  [SerializeField]
  private UILabel titel;
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private CreateIconObject iconBase;
  private BingoMission bingoMission;

  [DebuggerHidden]
  public IEnumerator InitPanelMissionInfo(int panel_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypagePanelMissionInfo.\u003CInitPanelMissionInfo\u003Ec__Iterator9DD()
    {
      panel_id = panel_id,
      \u003C\u0024\u003Epanel_id = panel_id,
      \u003C\u003Ef__this = this
    };
  }

  public void onMissionInfo()
  {
    if (this.bingoMission == null || string.IsNullOrEmpty(this.bingoMission.scene_name))
      return;
    string sceneName = this.bingoMission.scene_name;
    int? arg1 = this.bingoMission.scene_arg;
    switch (sceneName)
    {
      case "mypage001_8_2":
        Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) arg1);
        break;
      case "quest002_4":
        PlayerStoryQuestS[] source = SMManager.Get<PlayerStoryQuestS[]>();
        if (arg1.HasValue && MasterData.QuestStoryS.ContainsKey(arg1.Value) && ((IEnumerable<PlayerStoryQuestS>) source).Any<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x._quest_story_s == arg1.Value)))
        {
          Quest00240723Scene.ChangeScene0024(false, MasterData.QuestStoryS[arg1.Value].quest_l_QuestStoryL);
          break;
        }
        Quest00240723Scene.ChangeScene0024(false, ((IEnumerable<PlayerStoryQuestS>) source).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (x => x.quest_story_s.quest_l_QuestStoryL)).Max());
        break;
      case "quest002_20":
      case "quest002_19":
      case "quest002_26":
        if (arg1.HasValue)
        {
          this.StartCoroutine(this.onBannerEventConnection(sceneName, arg1.Value));
          break;
        }
        Quest00217Scene.ChangeScene(false);
        break;
      case "gacha006_3":
        if (arg1.HasValue)
        {
          Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, false, (object) arg1.Value);
          break;
        }
        Singleton<NGSceneManager>.GetInstance().changeScene(sceneName);
        break;
      case "shop007_21":
        Shop00721Scene.changeScene(false, true);
        break;
      case "quest002_30":
        Quest00230Scene.ChangeScene(false, arg1.Value);
        break;
      default:
        if (sceneName.StartsWith("colosseum023"))
        {
          if (!SMManager.Get<Player>().GetFeatureColosseum() || !SMManager.Get<Player>().GetReleaseColosseum())
          {
            this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().DAILY_MISSION_0271_POPUP_TITLE, Consts.GetInstance().DAILY_MISSION_0271_COLOSSEUM));
            break;
          }
          Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true);
          break;
        }
        Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true);
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator onBannerEventConnection(string changeSchene, int sID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypagePanelMissionInfo.\u003ConBannerEventConnection\u003Ec__Iterator9DE()
    {
      sID = sID,
      changeSchene = changeSchene,
      \u003C\u0024\u003EsID = sID,
      \u003C\u0024\u003EchangeSchene = changeSchene
    };
  }
}
