// Decompiled with JetBrains decompiler
// Type: Guild0281BuildingInvestmentConfirmDialogController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using UnityEngine;

#nullable disable
public class Guild0281BuildingInvestmentConfirmDialogController : MonoBehaviour
{
  [SerializeField]
  private UILabel investmentDescriptionLabel;
  [SerializeField]
  private UILabel rankBeforeLabel;
  [SerializeField]
  private UILabel rankAfterLabel;
  [SerializeField]
  private UILabel status1BeforeTitleLabel;
  [SerializeField]
  private UILabel status2BeforeTitleLabel;
  [SerializeField]
  private UILabel status1AfterTitleLabel;
  [SerializeField]
  private UILabel status2AfterTitleLabel;
  [SerializeField]
  private UILabel status1BeforeLabel;
  [SerializeField]
  private UILabel status2BeforeLabel;
  [SerializeField]
  private UILabel status1AfterLabel;
  [SerializeField]
  private UILabel status2AfterLabel;
  [SerializeField]
  private GameObject moneyNotEnoughCaution;
  [SerializeField]
  private UILabel priceLabel;
  [SerializeField]
  private UILabel possessionLabel;
  [SerializeField]
  private UIButton confirmButton;
  private GuildHq selectedFacility;
  private Guild0281FacilityInfoController facilityInfoController;
  private bool isProcessingInvestment;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Initialize(
    GuildHq selectedFacility,
    Guild0281FacilityInfoController facilityInfoController)
  {
    this.selectedFacility = selectedFacility;
    this.facilityInfoController = facilityInfoController;
    this.investmentDescriptionLabel.SetTextLocalize(selectedFacility.base_name + Consts.GetInstance().Guild0281MENU_FACILITY_INVESTMENT_DIALOG_DESCRIPTION);
    this.rankBeforeLabel.SetTextLocalize(selectedFacility.rank);
    this.rankAfterLabel.SetTextLocalize(selectedFacility.rank + 1);
    string text1;
    string text2;
    GuildBaseBonusType? nullable1;
    GuildBaseBonusType? nullable2;
    switch (selectedFacility.base_type)
    {
      case GuildBaseType.walls:
        text1 = Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_HIT_POINT;
        text2 = string.Empty;
        nullable1 = new GuildBaseBonusType?(GuildBaseBonusType.hit_point);
        nullable2 = new GuildBaseBonusType?();
        break;
      case GuildBaseType.tower:
        text1 = Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_PHYSICAL_ATK;
        text2 = Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_MAGICAL_ATK;
        nullable1 = new GuildBaseBonusType?(GuildBaseBonusType.physical_attack);
        nullable2 = new GuildBaseBonusType?(GuildBaseBonusType.magic_attack);
        break;
      case GuildBaseType.scaffold:
        text1 = Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_ACCURACY_RATE;
        text2 = Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_AVOIDANCE;
        nullable1 = new GuildBaseBonusType?(GuildBaseBonusType.accuracy_rate);
        nullable2 = new GuildBaseBonusType?(GuildBaseBonusType.avoidance);
        break;
      default:
        Debug.LogError((object) "The type of the selected facility does not exist!");
        return;
    }
    this.status1BeforeTitleLabel.SetTextLocalize(text1);
    this.status1AfterTitleLabel.SetTextLocalize(text1);
    this.status2BeforeTitleLabel.SetTextLocalize(text2);
    this.status2AfterTitleLabel.SetTextLocalize(text2);
    foreach (GuildBaseBonus bonuse in selectedFacility.bonuses)
    {
      if ((bonuse.bonus_type != nullable1.GetValueOrDefault() ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
        this.status1BeforeLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
      else if ((bonuse.bonus_type != nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        this.status2BeforeLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
    }
    foreach (GuildBaseBonus guildBaseBonus in MasterData.GuildBaseBonusList)
    {
      if (guildBaseBonus.base_rank == selectedFacility.rank + 1)
      {
        if ((guildBaseBonus.bonus_type != nullable1.GetValueOrDefault() ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
          this.status1AfterLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(guildBaseBonus.bonus_grade));
        else if ((guildBaseBonus.bonus_type != nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
          this.status2AfterLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(guildBaseBonus.bonus_grade));
      }
    }
    if (!nullable2.HasValue)
    {
      ((Component) this.status2BeforeTitleLabel).gameObject.SetActive(false);
      ((Component) this.status2AfterTitleLabel).gameObject.SetActive(false);
      ((Component) this.status2AfterLabel).gameObject.SetActive(false);
      ((Component) this.status2BeforeLabel).gameObject.SetActive(false);
    }
    int nextPrice = selectedFacility.next_price;
    int money = PlayerAffiliation.Current.guild.money;
    this.priceLabel.SetTextLocalize(nextPrice);
    this.possessionLabel.SetTextLocalize(money);
    if (money < nextPrice)
    {
      this.confirmButton.isEnabled = false;
      this.possessionLabel.color = Color.red;
      this.moneyNotEnoughCaution.SetActive(true);
    }
    else
    {
      this.confirmButton.isEnabled = true;
      this.possessionLabel.color = Color.white;
      this.moneyNotEnoughCaution.SetActive(false);
    }
  }

  public void OnConfirmButtonClicked()
  {
    if (this.isProcessingInvestment)
      return;
    this.isProcessingInvestment = true;
    this.facilityInfoController.InvestFacility(this.selectedFacility);
  }

  public void OnCancelButtonClicked() => Singleton<PopupManager>.GetInstance().dismiss();
}
