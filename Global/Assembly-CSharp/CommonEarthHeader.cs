// Decompiled with JetBrains decompiler
// Type: CommonEarthHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CommonEarthHeader : NGMenuBase
{
  [SerializeField]
  private UILabel txtChapterNum;
  [SerializeField]
  private UILabel txtChapterName;
  [SerializeField]
  private UILabel txtQuestName;
  [SerializeField]
  private UILabel txtZeny;
  private BL.BattleModified<EarthQuestProgress> questProgressModified;
  private BL.BattleModified<BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>>> userPropertiesModified;

  private void Awake()
  {
  }

  public void Reset()
  {
    EarthDataManager instance = Singleton<EarthDataManager>.GetInstance();
    EarthQuestProgress questProgress = instance.questProgress;
    BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>> mUserProperties = instance.mUserProperties;
    this.questProgressModified = BL.Observe<EarthQuestProgress>(questProgress);
    this.userPropertiesModified = BL.Observe<BL.ClassValue<Dictionary<MasterDataTable.CommonRewardType, int>>>(mUserProperties);
    this.UpdateQuestProgressInfomation();
  }

  private void Start() => this.Reset();

  private void Update()
  {
    if (this.questProgressModified.isChangedOnce())
      this.UpdateQuestProgressInfomation();
    if (!this.userPropertiesModified.isChangedOnce())
      return;
    this.UpdateZeny();
  }

  private void UpdateQuestProgressInfomation()
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    EarthQuestProgress questProgress = instanceOrNull.questProgress;
    this.txtChapterNum.SetTextLocalize(questProgress.currentEpisode.chapter.chapter);
    this.txtChapterName.SetTextLocalize(questProgress.currentEpisode.chapter.chapter_name);
    this.txtQuestName.SetTextLocalize(questProgress.currentEpisode.episode_name);
    this.txtZeny.SetTextLocalize(instanceOrNull.GetProperty(MasterDataTable.CommonRewardType.money));
  }

  private void UpdateZeny()
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    this.txtZeny.SetTextLocalize(instanceOrNull.GetProperty(MasterDataTable.CommonRewardType.money));
  }
}
