// Decompiled with JetBrains decompiler
// Type: Quest00231Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00231Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry scrollContainerAll;
  [SerializeField]
  private NGxScrollMasonry scrollContainerPersonal;
  [SerializeField]
  private NGxScrollMasonry scrollContainerGuild;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtRewardRecevieLimit;
  [SerializeField]
  private UILabel txtHuntingPoint;
  [SerializeField]
  private UILabel txtHuntingPointValue;
  [SerializeField]
  private UILabel txtHuntingPointAll;
  [SerializeField]
  private UILabel txtHuntingPointAllValue;
  [SerializeField]
  private UILabel txtHuntingPointGuild;
  [SerializeField]
  private UILabel txtHuntingPointGuildValue;
  [SerializeField]
  private GameObject dir_hunting_point_personal;
  [SerializeField]
  private GameObject dirHuntingPointAll;
  [SerializeField]
  private GameObject dirHuntingPointGuild;
  [SerializeField]
  private SpreadColorButton ibtnAll;
  [SerializeField]
  private SpreadColorButton ibtnPresonal;
  [SerializeField]
  private SpreadColorButton ibtnGuild;
  [SerializeField]
  private GameObject dir_none_guild_member;
  private bool isGuild;
  private EventPointType listType = EventPointType.all;
  private GameObject marginPrefab;

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void onBtnAll()
  {
    if (this.listType == EventPointType.all)
      return;
    this.ResetScrollObject(EventPointType.all);
  }

  public void onBtnPersonal()
  {
    if (this.listType == EventPointType.personal)
      return;
    this.ResetScrollObject(EventPointType.personal);
  }

  public void onBtnGuild()
  {
    if (this.listType == EventPointType.guild)
      return;
    this.ResetScrollObject(EventPointType.guild);
  }

  private void ResetScrollObject(EventPointType type)
  {
    this.listType = type;
    if (this.listType == EventPointType.all)
    {
      ((Component) this.scrollContainerAll).gameObject.SetActive(true);
      ((Component) this.scrollContainerGuild).gameObject.SetActive(false);
      ((Component) this.scrollContainerPersonal).gameObject.SetActive(false);
      this.ibtnAll.SetColor(Color.white);
      this.ibtnPresonal.SetColor(Color.gray);
    }
    else if (this.listType == EventPointType.personal)
    {
      ((Component) this.scrollContainerPersonal).gameObject.SetActive(true);
      this.ibtnPresonal.SetColor(Color.white);
      if (this.isGuild)
      {
        ((Component) this.scrollContainerGuild).gameObject.SetActive(false);
        this.ibtnGuild.SetColor(Color.gray);
      }
      else
      {
        ((Component) this.scrollContainerAll).gameObject.SetActive(false);
        this.ibtnAll.SetColor(Color.gray);
      }
    }
    else
    {
      if (this.listType != EventPointType.guild)
        return;
      ((Component) this.scrollContainerGuild).gameObject.SetActive(true);
      ((Component) this.scrollContainerAll).gameObject.SetActive(false);
      ((Component) this.scrollContainerPersonal).gameObject.SetActive(false);
      this.ibtnGuild.SetColor(Color.white);
      this.ibtnPresonal.SetColor(Color.gray);
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.EventTop eventInfo,
    PunitiveExpeditionEventReward[] rewardList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00231Menu.\u003CInit\u003Ec__Iterator29E()
    {
      eventInfo = eventInfo,
      rewardList = rewardList,
      \u003C\u0024\u003EeventInfo = eventInfo,
      \u003C\u0024\u003ErewardList = rewardList,
      \u003C\u003Ef__this = this
    };
  }

  public void BtnNotGuildMember()
  {
    if (this.IsPushAndSet())
      return;
    Guild02811Scene.ChangeScene();
  }
}
