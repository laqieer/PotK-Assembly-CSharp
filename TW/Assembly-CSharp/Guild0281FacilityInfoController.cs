// Decompiled with JetBrains decompiler
// Type: Guild0281FacilityInfoController
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
public class Guild0281FacilityInfoController : MonoBehaviour
{
  [SerializeField]
  private UILabel unitExperienceLabel;
  [SerializeField]
  private UILabel playerExperienceLabel;
  [SerializeField]
  private UILabel moneyLabel;
  [SerializeField]
  private UILabel rewardDropLabel;
  [SerializeField]
  private GameObject bonusIcon;
  [SerializeField]
  private UILabel scaffoldRankLabel;
  [SerializeField]
  private UILabel scaffoldStatus1TitleLabel;
  [SerializeField]
  private UILabel scaffoldStatus1ValueLabel;
  [SerializeField]
  private UILabel scaffoldStatus2TitleLabel;
  [SerializeField]
  private UILabel scaffoldStatus2ValueLabel;
  [SerializeField]
  private UILabel wallsRankLabel;
  [SerializeField]
  private UILabel wallsStatus1TitleLabel;
  [SerializeField]
  private UILabel wallsStatus1ValueLabel;
  [SerializeField]
  private UILabel wallsStatus2ValueLabel;
  [SerializeField]
  private UILabel towerRankLabel;
  [SerializeField]
  private UILabel towerStatus1TitleLabel;
  [SerializeField]
  private UILabel towerStatus1ValueLabel;
  [SerializeField]
  private UILabel towerStatus2TitleLabel;
  [SerializeField]
  private UILabel towerStatus2ValueLabel;
  [SerializeField]
  private GameObject scaffoldInvestmentIcon;
  [SerializeField]
  private GameObject wallsInvestmentIcon;
  [SerializeField]
  private GameObject towerInvestmentIcon;
  [SerializeField]
  private UIButton scaffoldInvestmentButton;
  [SerializeField]
  private UIButton wallsInvestmentButton;
  [SerializeField]
  private UIButton towerInvestmentButton;
  [SerializeField]
  private Transform scaffoldLevelUpEffectContainer;
  [SerializeField]
  private Transform wallsLevelUpEffectContainer;
  [SerializeField]
  private Transform towerLevelUpEffectContainer;
  private GameObject buildingInvestmentConfirmDialogPrefab;
  private GameObject facilityLevelUpEffectPrefab;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003CInitializeAsync\u003Ec__Iterator6DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadFacilityInvestDialogPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003CLoadFacilityInvestDialogPrefab\u003Ec__Iterator6DD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadFacilityLevelUpEffectPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003CLoadFacilityLevelUpEffectPrefab\u003Ec__Iterator6DE()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void RefreshGuildFacilityStatus()
  {
    GuildLevelBonus levelBonus = PlayerAffiliation.Current.guild.level_bonus;
    Color color1;
    Color color2;
    if (levelBonus.campaign_flag)
    {
      this.bonusIcon.SetActive(true);
      // ISSUE: explicit constructor call
      ((Color) ref color1).\u002Ector(1f, 1f, 1f, 1f);
      Color color3;
      // ISSUE: explicit constructor call
      ((Color) ref color3).\u002Ector(1f, 1f, 0.0f, 1f);
      Color color4;
      // ISSUE: explicit constructor call
      ((Color) ref color4).\u002Ector(1f, 0.64f, 0.0f, 1f);
      // ISSUE: explicit constructor call
      ((Color) ref color2).\u002Ector(1f, 1f, 1f, 1f);
      Color color5;
      // ISSUE: explicit constructor call
      ((Color) ref color5).\u002Ector(1f, 0.35f, 0.0f, 1f);
      Color color6;
      // ISSUE: explicit constructor call
      ((Color) ref color6).\u002Ector(1f, 0.64f, 0.0f, 1f);
      this.unitExperienceLabel.applyGradient = true;
      this.playerExperienceLabel.applyGradient = true;
      this.moneyLabel.applyGradient = true;
      this.rewardDropLabel.applyGradient = true;
      this.scaffoldStatus1ValueLabel.applyGradient = true;
      this.scaffoldStatus2ValueLabel.applyGradient = true;
      this.towerStatus1ValueLabel.applyGradient = true;
      this.towerStatus2ValueLabel.applyGradient = true;
      this.wallsStatus1ValueLabel.applyGradient = true;
      this.wallsStatus2ValueLabel.applyGradient = true;
      this.unitExperienceLabel.gradientTop = color3;
      this.unitExperienceLabel.gradientBottom = color4;
      this.playerExperienceLabel.gradientTop = color3;
      this.playerExperienceLabel.gradientBottom = color4;
      this.moneyLabel.gradientTop = color3;
      this.moneyLabel.gradientBottom = color4;
      this.rewardDropLabel.gradientTop = color3;
      this.rewardDropLabel.gradientBottom = color4;
      this.scaffoldStatus1ValueLabel.gradientTop = color5;
      this.scaffoldStatus1ValueLabel.gradientBottom = color6;
      this.scaffoldStatus2ValueLabel.gradientTop = color5;
      this.scaffoldStatus2ValueLabel.gradientBottom = color6;
      this.towerStatus1ValueLabel.gradientTop = color5;
      this.towerStatus1ValueLabel.gradientBottom = color6;
      this.towerStatus2ValueLabel.gradientTop = color5;
      this.towerStatus2ValueLabel.gradientBottom = color6;
      this.wallsStatus1ValueLabel.gradientTop = color5;
      this.wallsStatus1ValueLabel.gradientBottom = color6;
      this.wallsStatus2ValueLabel.gradientTop = color5;
      this.wallsStatus2ValueLabel.gradientBottom = color6;
    }
    else
    {
      this.bonusIcon.SetActive(false);
      // ISSUE: explicit constructor call
      ((Color) ref color1).\u002Ector(1f, 1f, 1f, 1f);
      // ISSUE: explicit constructor call
      ((Color) ref color2).\u002Ector(0.0f, 0.0f, 0.0f, 1f);
      this.unitExperienceLabel.applyGradient = false;
      this.playerExperienceLabel.applyGradient = false;
      this.moneyLabel.applyGradient = false;
      this.rewardDropLabel.applyGradient = false;
      this.scaffoldStatus1ValueLabel.applyGradient = false;
      this.scaffoldStatus2ValueLabel.applyGradient = false;
      this.towerStatus1ValueLabel.applyGradient = false;
      this.towerStatus2ValueLabel.applyGradient = false;
      this.wallsStatus1ValueLabel.applyGradient = false;
      this.wallsStatus2ValueLabel.applyGradient = false;
    }
    this.unitExperienceLabel.color = color1;
    this.playerExperienceLabel.color = color1;
    this.moneyLabel.color = color1;
    this.rewardDropLabel.color = color1;
    this.scaffoldStatus1ValueLabel.color = color2;
    this.scaffoldStatus2ValueLabel.color = color2;
    this.towerStatus1ValueLabel.color = color2;
    this.towerStatus2ValueLabel.color = color2;
    this.wallsStatus1ValueLabel.color = color2;
    this.wallsStatus2ValueLabel.color = color2;
    this.unitExperienceLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(levelBonus.unit_exp));
    this.playerExperienceLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(levelBonus.player_exp));
    this.moneyLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(levelBonus.money));
    this.rewardDropLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(levelBonus.item));
    GuildMembership guildMembership = ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).FirstOrDefault<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
    if (guildMembership != null && (guildMembership.role == GuildRole.master || guildMembership.role == GuildRole.sub_master))
    {
      this.scaffoldInvestmentIcon.SetActive(true);
      this.wallsInvestmentIcon.SetActive(true);
      this.towerInvestmentIcon.SetActive(true);
      this.scaffoldInvestmentButton.isEnabled = true;
      this.wallsInvestmentButton.isEnabled = true;
      this.towerInvestmentButton.isEnabled = true;
    }
    else
    {
      this.scaffoldInvestmentIcon.SetActive(false);
      this.wallsInvestmentIcon.SetActive(false);
      this.towerInvestmentIcon.SetActive(false);
      this.scaffoldInvestmentButton.isEnabled = false;
      this.wallsInvestmentButton.isEnabled = false;
      this.towerInvestmentButton.isEnabled = false;
    }
    foreach (GuildHq hq in PlayerAffiliation.Current.guild.hqs)
    {
      switch (hq.base_type)
      {
        case GuildBaseType.walls:
          this.wallsRankLabel.SetTextLocalize(hq.rank);
          foreach (GuildBaseBonus bonuse in hq.bonuses)
          {
            if (bonuse.bonus_type == GuildBaseBonusType.hit_point)
            {
              this.wallsStatus1TitleLabel.SetTextLocalize(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_HIT_POINT);
              this.wallsStatus1ValueLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
            }
          }
          break;
        case GuildBaseType.tower:
          this.towerRankLabel.SetTextLocalize(hq.rank);
          foreach (GuildBaseBonus bonuse in hq.bonuses)
          {
            if (bonuse.bonus_type == GuildBaseBonusType.physical_attack)
            {
              this.towerStatus1TitleLabel.SetTextLocalize(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_PHYSICAL_ATK);
              this.towerStatus1ValueLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
            }
            else if (bonuse.bonus_type == GuildBaseBonusType.magic_attack)
            {
              this.towerStatus2TitleLabel.SetTextLocalize(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_MAGICAL_ATK);
              this.towerStatus2ValueLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
            }
          }
          break;
        case GuildBaseType.scaffold:
          this.scaffoldRankLabel.SetTextLocalize(hq.rank);
          foreach (GuildBaseBonus bonuse in hq.bonuses)
          {
            if (bonuse.bonus_type == GuildBaseBonusType.accuracy_rate)
            {
              this.scaffoldStatus1TitleLabel.SetTextLocalize(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_ACCURACY_RATE);
              this.scaffoldStatus1ValueLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
            }
            else if (bonuse.bonus_type == GuildBaseBonusType.avoidance)
            {
              this.scaffoldStatus2TitleLabel.SetTextLocalize(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS_TITLE_AVOIDANCE);
              this.scaffoldStatus2ValueLabel.SetTextLocalize(Guild0281FacilityInfoController.GetFormattedStatusValue(bonuse.bonus_grade));
            }
          }
          break;
        default:
          Debug.LogError((object) "The type of facility does not exist!");
          return;
      }
    }
  }

  public void OnScaffoldInvestmentButtonClicked()
  {
    this.OpenFacilityInvestmentDialog(GuildBaseType.scaffold);
  }

  public void OnWallsInvestmentButtonClicked()
  {
    this.OpenFacilityInvestmentDialog(GuildBaseType.walls);
  }

  public void OnTowerInvestmentButtonClicked()
  {
    this.OpenFacilityInvestmentDialog(GuildBaseType.tower);
  }

  public void OpenFacilityInvestmentDialog(GuildBaseType investmentFacilityType)
  {
    if (((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>().IsPushAndSet())
      return;
    GuildHq selectedFacility = (GuildHq) null;
    foreach (GuildHq hq in PlayerAffiliation.Current.guild.hqs)
    {
      if (hq.base_type == investmentFacilityType)
      {
        selectedFacility = hq;
        break;
      }
    }
    if (selectedFacility.rank < selectedFacility.max_rank && PlayerAffiliation.Current.guild.appearance.level >= selectedFacility.guild_level_cap)
      this.StartCoroutine(this.OpenFacilityInvestmentDialog(selectedFacility));
    else
      ModalWindow.Show(Consts.GetInstance().Guild0281MENU_FACILITY_RANK_MAX_DIALOG_TITLE, Consts.GetInstance().Guild0281MENU_FACILITY_RANK_MAX_DIALOG_CONTENT, (System.Action) (() =>
      {
        if (!Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) || !Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>(), (Object) null))
          return;
        ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>().IsPush = false;
      }));
  }

  [DebuggerHidden]
  private IEnumerator OpenFacilityInvestmentDialog(GuildHq selectedFacility)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003COpenFacilityInvestmentDialog\u003Ec__Iterator6DF()
    {
      selectedFacility = selectedFacility,
      \u003C\u0024\u003EselectedFacility = selectedFacility,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator OnInvestmentFinished(GuildHq selectedFacility)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003COnInvestmentFinished\u003Ec__Iterator6E0()
    {
      selectedFacility = selectedFacility,
      \u003C\u0024\u003EselectedFacility = selectedFacility,
      \u003C\u003Ef__this = this
    };
  }

  private void ShowFacilityLevelUpEffect(GuildBaseType facilityType)
  {
    Transform upEffectContainer;
    switch (facilityType)
    {
      case GuildBaseType.walls:
        upEffectContainer = this.wallsLevelUpEffectContainer;
        break;
      case GuildBaseType.tower:
        upEffectContainer = this.towerLevelUpEffectContainer;
        break;
      case GuildBaseType.scaffold:
        upEffectContainer = this.scaffoldLevelUpEffectContainer;
        break;
      default:
        Debug.LogError((object) "The type of facility does not exist!");
        return;
    }
    foreach (Component component in upEffectContainer)
      Object.Destroy((Object) component.gameObject);
    Object.Destroy((Object) this.facilityLevelUpEffectPrefab.Clone(upEffectContainer), 5f);
  }

  public static string GetFormattedStatusValue(int value, bool isValueOnly = false)
  {
    if (isValueOnly)
      return value.ToString();
    return Consts.Format(Consts.GetInstance().Guild0281MENU_FACILITY_STATUS, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (value),
        (object) value
      }
    });
  }

  public void ClearFacilityLevelUpEffects()
  {
    foreach (Component component in this.scaffoldLevelUpEffectContainer)
      Object.Destroy((Object) component.gameObject);
    foreach (Component component in this.wallsLevelUpEffectContainer)
      Object.Destroy((Object) component.gameObject);
    foreach (Component component in this.towerLevelUpEffectContainer)
      Object.Destroy((Object) component.gameObject);
  }

  public void InvestFacility(GuildHq selectedFacility)
  {
    this.StartCoroutine(this.InvestFacilityCoroutine(selectedFacility));
  }

  [DebuggerHidden]
  private IEnumerator InvestFacilityCoroutine(GuildHq selectedFacility)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281FacilityInfoController.\u003CInvestFacilityCoroutine\u003Ec__Iterator6E1()
    {
      selectedFacility = selectedFacility,
      \u003C\u0024\u003EselectedFacility = selectedFacility,
      \u003C\u003Ef__this = this
    };
  }
}
