// Decompiled with JetBrains decompiler
// Type: Versus02612ScrollRewardBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02612ScrollRewardBox : MonoBehaviour
{
  [SerializeField]
  private int betweenMargin;
  [SerializeField]
  private int belowMargin;
  [SerializeField]
  private Transform[] targetParents;
  [SerializeField]
  private Transform dirTarget;
  [SerializeField]
  private UISprite slcState;
  [SerializeField]
  private UILabel slcStateDescription;
  [SerializeField]
  private GameObject slcGotReward;
  [SerializeField]
  private GameObject slcNotGotReward;
  private GameObject emblemPrefab;
  private GameObject rewardPrefab;
  private static readonly string[] spriteName = new string[5]
  {
    "slc_ClassUp.png__GUI__026_12_sozai__026_12_sozai_prefab",
    "slc_ClassStayed.png__GUI__026_12_sozai__026_12_sozai_prefab",
    "slc_ClassDown.png__GUI__026_12_sozai__026_12_sozai_prefab",
    "slc_ClassTitle.png__GUI__026_12_sozai__026_12_sozai_prefab",
    "slc_ClassNew.png__GUI__026_12_sozai__026_12_sozai_prefab"
  };

  [DebuggerHidden]
  public IEnumerator Init(
    IEnumerable<WebAPI.Response.PvpSeasonCloseClass_rewards> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator62F()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<PvpClassReward> data, bool reached_class)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator630()
    {
      data = data,
      reached_class = reached_class,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Ereached_class = reached_class,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    IEnumerable<WebAPI.Response.PvpRankingCloseRanking_rewards> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator631()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(IEnumerable<PvpRankingReward> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator632()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<QuestScoreRankingReward> data, int scoreCampaignID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator633()
    {
      data = data,
      scoreCampaignID = scoreCampaignID,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EscoreCampaignID = scoreCampaignID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<QuestScoreAchivementReward> data, int[] achivement_cleard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator634()
    {
      data = data,
      achivement_cleard = achivement_cleard,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Eachivement_cleard = achivement_cleard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<WebAPI.Response.QuestscoreRewardRewards> data, int scoreCampaignID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator635()
    {
      data = data,
      scoreCampaignID = scoreCampaignID,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EscoreCampaignID = scoreCampaignID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<PunitiveExpeditionEventReward> data, bool all, bool isClear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator636()
    {
      data = data,
      all = all,
      isClear = isClear,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Eall = all,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(IEnumerable<QuestScoreTotalReward> data, int total_score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator637()
    {
      data = data,
      total_score = total_score,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Etotal_score = total_score,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Init(
    List<Versus02612ScrollRewardBox.RewardData> data,
    string spriteName,
    string spriteDescription = "",
    bool? gotReward = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator638()
    {
      spriteName = spriteName,
      spriteDescription = spriteDescription,
      gotReward = gotReward,
      data = data,
      \u003C\u0024\u003EspriteName = spriteName,
      \u003C\u0024\u003EspriteDescription = spriteDescription,
      \u003C\u0024\u003EgotReward = gotReward,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private class RewardData
  {
    public int rewardID;
    public MasterDataTable.CommonRewardType type;
    public string txt;
  }
}
