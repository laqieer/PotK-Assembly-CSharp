// Decompiled with JetBrains decompiler
// Type: DailyMission0271Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGHorizontalScrollParts scrollParts;
  [SerializeField]
  private DailyMission0271MissionRoot missonRoot;
  private PlayerBingo[] enablePlayerBingos;
  private PlayerBingo selectedPlayerBingo;
  private GameObject rewardPopup;

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CInit\u003Ec__Iterator6BA()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void onItemChanged(int selected)
  {
    this.IsPush = true;
    this.StartCoroutine(this.SetBingoPanel(this.enablePlayerBingos[selected], true));
  }

  [DebuggerHidden]
  private IEnumerator SetBingoPanel(PlayerBingo playerBingoData, bool isCheckObject = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CSetBingoPanel\u003Ec__Iterator6BB()
    {
      playerBingoData = playerBingoData,
      \u003C\u0024\u003EplayerBingoData = playerBingoData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetPlayerBingoData(PlayerBingo playerBingo)
  {
    for (int index = 0; index < this.enablePlayerBingos.Length; ++index)
    {
      if (this.enablePlayerBingos[index] == this.selectedPlayerBingo)
        this.enablePlayerBingos[index] = playerBingo;
    }
    this.selectedPlayerBingo = playerBingo;
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator selectCompRewardAsync(int groupId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CselectCompRewardAsync\u003Ec__Iterator6BC()
    {
      groupId = groupId,
      \u003C\u0024\u003EgroupId = groupId,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnLeftArrow()
  {
    if (this.IsPushAndSet() || this.scrollParts.selected <= 0)
      return;
    this.scrollParts.setItemPosition(this.scrollParts.selected - 1);
  }

  public void IbtnRightArrow()
  {
    if (this.IsPushAndSet() || this.scrollParts.selected >= this.scrollParts.PartsCnt)
      return;
    this.scrollParts.setItemPosition(this.scrollParts.selected + 1);
  }

  public void IbtnCompleteReward()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowCompleteReward());
  }

  [DebuggerHidden]
  private IEnumerator ShowCompleteReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CShowCompleteReward\u003Ec__Iterator6BD()
    {
      \u003C\u003Ef__this = this
    };
  }
}
