// Decompiled with JetBrains decompiler
// Type: Quest00230Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00230Menu : BackButtonMenuBase
{
  private const int NEXT_REWARD_OBJECT_INDEX_ALL = 0;
  private const int NEXT_REWARD_OBJECT_INDEX_PERSONAL = 1;
  private const int NEXT_REWARD_OBJECT_INDEX_GUILD = 2;
  private const int TARGET_ICON_MIN = 3;
  [SerializeField]
  private UILabel txtTitleLabe;
  [SerializeField]
  private UI2DSprite slcEventAnimFade01;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private GameObject dirHuntingSolo;
  [SerializeField]
  private UILabel txtPlayerPointTitleLabe;
  [SerializeField]
  private UILabel txtPlayerPointLabe;
  [SerializeField]
  private GameObject dirHuntingTotal;
  [SerializeField]
  private UILabel txtTotalPointTitleLabe;
  [SerializeField]
  private UILabel txtTotalPointLabe;
  [SerializeField]
  private GameObject dirHuntingGuildTotal;
  [SerializeField]
  private UILabel txtGuildTotalPointTitleLabe;
  [SerializeField]
  private UILabel txtGuildTotalPointLabe;
  [SerializeField]
  private UILabel txtEventTermLabel;
  [SerializeField]
  private UILabel txtRewardReciveTermLabel;
  [SerializeField]
  private GameObject dirRewardReachedEnd;
  [SerializeField]
  private GameObject dirRewardRecieveTime;
  [SerializeField]
  private GameObject dirPointBonus;
  [SerializeField]
  private NGHorizontalScrollParts indicatorContainerAnimFade01;
  [SerializeField]
  private Quest00230NextRewardObject[] nextRewardObjects;
  [SerializeField]
  private BattleUI05PunitiveExpeditionResultMenu battleUI05PunitiveExpeditionResultMenu;
  private GameObject targetUnitPrefab;
  private GameObject targetUnitDetailPrefab;
  private GameObject targetUnitQuestListPrefab;
  private bool isInit = true;
  private EventInfo eventInfo;
  private WebAPI.Response.EventTop eventTopInfo;
  private Description description;
  [SerializeField]
  private GameObject dir_GuildFind;
  private PunitiveExpeditionEventReward[] rewardList;
  private List<int> enableNextRewardObjectIndexList;
  private int nowDisplayNextRewardIndex;
  private bool isGuild;

  protected override void Update()
  {
    base.Update();
    this.indicatorContainerAnimFade01.leftArrow.SetActive(true);
    this.indicatorContainerAnimFade01.rightArrow.SetActive(true);
    if (this.indicatorContainerAnimFade01.selected <= 1)
      this.indicatorContainerAnimFade01.leftArrow.SetActive(false);
    if (this.indicatorContainerAnimFade01.selected < this.indicatorContainerAnimFade01.PartsCnt - 2)
      return;
    this.indicatorContainerAnimFade01.rightArrow.SetActive(false);
  }

  public override void onBackButton()
  {
    if (Singleton<PopupManager>.GetInstance().isOpen)
      Singleton<PopupManager>.GetInstance().dismiss();
    else if (Singleton<CommonRoot>.GetInstance().guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.DetailedView)
      Singleton<CommonRoot>.GetInstance().guildChatManager.OnBackButtonClicked();
    else
      this.IbtnBack();
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnHelp()
  {
    if (this.IsPushAndSet())
      return;
    Quest00228Scene.ChangeScene(this.description, true);
  }

  public void IbtnLeftArrow()
  {
    if (this.indicatorContainerAnimFade01.selected <= 0)
      return;
    this.indicatorContainerAnimFade01.setItemPosition(this.indicatorContainerAnimFade01.selected - 1);
  }

  public void IbtnRightArrow()
  {
    if (this.indicatorContainerAnimFade01.selected >= this.indicatorContainerAnimFade01.PartsCnt)
      return;
    this.indicatorContainerAnimFade01.setItemPosition(this.indicatorContainerAnimFade01.selected + 1);
  }

  public void IbtnRewardList()
  {
    if (this.IsPushAndSet())
      return;
    Quest00231Scene.ChangeScene(this.eventTopInfo, this.rewardList, true);
  }

  public void ShowTargetDetail(EnemyTopInfo[] infos)
  {
    this.StartCoroutine(this.ShowTargetDetailAsync(infos));
  }

  [DebuggerHidden]
  private IEnumerator ShowTargetDetailAsync(EnemyTopInfo[] infos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00230Menu.\u003CShowTargetDetailAsync\u003Ec__Iterator299()
    {
      infos = infos,
      \u003C\u0024\u003Einfos = infos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(EventInfo eventInfo, WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00230Menu.\u003CInit\u003Ec__Iterator29A()
    {
      eventInfo = eventInfo,
      eventTopInfo = eventTopInfo,
      \u003C\u0024\u003EeventInfo = eventInfo,
      \u003C\u0024\u003EeventTopInfo = eventTopInfo,
      \u003C\u003Ef__this = this
    };
  }

  private void NextRewardDisplay()
  {
    int num = this.nowDisplayNextRewardIndex + 1;
    if (num >= this.enableNextRewardObjectIndexList.Count<int>())
      num = 0;
    if (num == this.nowDisplayNextRewardIndex)
      return;
    this.nextRewardObjects[this.enableNextRewardObjectIndexList[this.nowDisplayNextRewardIndex]].Hidden();
    this.nowDisplayNextRewardIndex = num;
  }

  private void NextRewardDisplayWait() => this.Invoke("NextRewardDisplay", 5f);

  private void NextRewardDisplayStart()
  {
    this.nextRewardObjects[this.enableNextRewardObjectIndexList[this.nowDisplayNextRewardIndex]].Display();
  }

  public void BtnGuildFind()
  {
    if (this.IsPushAndSet())
      return;
    Guild02811Scene.ChangeScene();
  }
}
