// Decompiled with JetBrains decompiler
// Type: Versus02612ScrollRewardBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator678()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator679()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67A()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67B()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67C()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67D()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67E()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator67F()
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
  public IEnumerator Init(List<GvgWholeRewardMaster> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator680()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(IEnumerable<QuestScoreTotalReward> data, int total_score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator681()
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
    return (IEnumerator) new Versus02612ScrollRewardBox.\u003CInit\u003Ec__Iterator682()
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
    public bool isGuildReward;
  }
}
