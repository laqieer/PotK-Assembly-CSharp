// Decompiled with JetBrains decompiler
// Type: Unit00483Menu
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
public class Unit00483Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtLv;
  [SerializeField]
  protected UILabel TxtProbability;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtZeny;
  [SerializeField]
  protected UILabel TxtHimeEnforceNumer;
  [SerializeField]
  protected UILabel TxtHimeEnforceDenom;
  [SerializeField]
  private GameObject[] StatusGaugeBase;
  private GameObject RarityAlertPopupPrefab;
  public GameObject[] linkSozaibase;
  public GameObject limitBreak;
  public GameObject[] limitBreakIcon;
  public GameObject slc_Limitbreak;
  public GameObject charcter;
  public UISprite[] princessType;
  public UISprite[] limitBreakBlue;
  public UISprite[] limitBreakGreen;
  public GameObject composeBtn;
  public GameObject[] skillObject;
  public GameObject[] skillUpObject;
  private GameObject skillTypeIconPrefab;
  private PlayerUnit[] selectUnit = new PlayerUnit[5];
  private PlayerUnit baseUnit;
  private GameObject skillDetailDialogPrefab;
  [SerializeField]
  private GameObject floatingSkillDialog;
  private Battle0171111Event floatingSkillDialogObject;
  private Action<BattleskillSkill> showSkillDialog;
  private Action<int, int> showSkillLevel;

  private Dictionary<int, float> SkillLevelUpRatio(
    PlayerUnit baseUnit,
    PlayerUnit[] materialUnits,
    Dictionary<int, int> playerSkillDict)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1007 ratioCAnonStorey1007 = new Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1007();
    // ISSUE: reference to a compiler-generated field
    ratioCAnonStorey1007.baseUnit = baseUnit;
    // ISSUE: reference to a compiler-generated field
    ratioCAnonStorey1007.data = new Dictionary<int, float>();
    // ISSUE: reference to a compiler-generated field
    foreach (BattleskillSkill battleSkill in ratioCAnonStorey1007.baseUnit.GetBattleSkills())
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      ratioCAnonStorey1007.data[ratioCAnonStorey1007.baseUnit.evolutionSkill(battleSkill).ID] = 0.0f;
    }
    if (materialUnits.Length < 1)
    {
      // ISSUE: reference to a compiler-generated field
      return ratioCAnonStorey1007.data;
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    List<PlayerUnitSkills> list = ((IEnumerable<PlayerUnitSkills>) ratioCAnonStorey1007.baseUnit.skills).Where<PlayerUnitSkills>(new Func<PlayerUnitSkills, bool>(ratioCAnonStorey1007.\u003C\u003Em__F8E)).ToList<PlayerUnitSkills>();
    foreach (PlayerUnit materialUnit in materialUnits)
    {
      PlayerUnit material = materialUnit;
      // ISSUE: reference to a compiler-generated field
      if (material.unit.same_character_id == ratioCAnonStorey1007.baseUnit.unit.same_character_id)
      {
        Dictionary<int, int> materialSkillDict = material.GetAcquireSkillsDictionary();
        list.ForEach((Action<PlayerUnitSkills>) (x =>
        {
          int id = baseUnit.evolutionSkill(x.skill).ID;
          if (materialSkillDict.ContainsKey(id) && materialSkillDict[id] > 0)
          {
            data[id] = 100f;
          }
          else
          {
            if ((double) material.unit.rarity.skill_levelup_rate <= (double) data[x.skill_id])
              return;
            data[id] = (float) material.unit.rarity.skill_levelup_rate;
          }
        }));
      }
      else
        list.ForEach((Action<PlayerUnitSkills>) (x =>
        {
          // ISSUE: variable of a compiler-generated type
          Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1007 ratioCAnonStorey1007_1 = ratioCAnonStorey1007;
          // ISSUE: variable of a compiler-generated type
          Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1009 ratioCAnonStorey1009_1 = this;
          PlayerUnitSkills x1 = x;
          BattleskillSkill battleskillSkill = baseUnit.evolutionSkill(x1.skill);
          if (UnitDetailIcon.IsSkillUpMaterial(material.unit, baseUnit))
          {
            // ISSUE: variable of a compiler-generated type
            Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1007 ratioCAnonStorey1007_2 = ratioCAnonStorey1007;
            // ISSUE: variable of a compiler-generated type
            Unit00483Menu.\u003CSkillLevelUpRatio\u003Ec__AnonStorey1009 ratioCAnonStorey1009_2 = this;
            // ISSUE: reference to a compiler-generated field
            UnitSkillupSetting skillupSetting = ((IEnumerable<UnitSkillupSetting>) MasterData.UnitSkillupSettingList).FirstOrDefault<UnitSkillupSetting>((Func<UnitSkillupSetting, bool>) (y => y.material_unit_id == ratioCAnonStorey1009_2.material.unit.ID));
            bool flag = battleskillSkill.skill_type == (BattleskillSkillType) material.unit.skillup_type || material.unit.skillup_type == UnitDetailIcon.SKILL_ID_ALL;
            if (skillupSetting != null && skillupSetting.skill_group.HasValue)
            {
              IEnumerable<int> source = ((IEnumerable<UnitSkillupSkillGroupSetting>) MasterData.UnitSkillupSkillGroupSettingList).Where<UnitSkillupSkillGroupSetting>((Func<UnitSkillupSkillGroupSetting, bool>) (y => y.group_id == skillupSetting.skill_group.Value)).Select<UnitSkillupSkillGroupSetting, int>((Func<UnitSkillupSkillGroupSetting, int>) (y => y.skill_id));
              flag = flag && source.Contains<int>(battleskillSkill.ID);
            }
            if (!flag || !data.ContainsKey(battleskillSkill.ID))
              return;
            float num = 20f;
            if (skillupSetting != null)
              num = skillupSetting.levelup_ratio * 100f;
            if ((double) num <= (double) data[battleskillSkill.ID])
              return;
            data[battleskillSkill.ID] = num;
          }
          else
          {
            if (material.skills == null)
              return;
            PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) material.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (y => x1.skill_id == y.skill_id));
            if (playerUnitSkills == null || !data.ContainsKey(battleskillSkill.ID))
              return;
            float num = UnitSkillLevelUpProbability.Probability(x1.level, playerUnitSkills.level) * 100f;
            if ((double) num <= (double) data[battleskillSkill.ID])
              return;
            data[battleskillSkill.ID] = num;
          }
        }));
    }
    // ISSUE: reference to a compiler-generated field
    return ratioCAnonStorey1007.data;
  }

  [DebuggerHidden]
  private IEnumerator CreateSkillDetailDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Menu.\u003CCreateSkillDetailDialog\u003Ec__Iterator37B()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void SetPrice(PlayerUnit basePlayerUnit, PlayerUnit[] select)
  {
    this.TxtZeny.SetTextLocalize(CalcUnitCompose.priceCompose(basePlayerUnit, select).ToString());
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit basePlayerUnit, PlayerUnit[] materialPlayerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Menu.\u003CInit\u003Ec__Iterator37C()
    {
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void setEnterBtnStatus(PlayerUnit[] _selectUnit)
  {
    this.composeBtn.GetComponent<UIButton>().isEnabled = _selectUnit.Length > 0;
  }

  private void setStatusGaug(GameObject prefabGauge, PlayerUnit[] materialPlayerUnits)
  {
    CalcUnitCompose.ComposeType[] composeTypeArray = new CalcUnitCompose.ComposeType[8]
    {
      CalcUnitCompose.ComposeType.HP,
      CalcUnitCompose.ComposeType.STRENGTH,
      CalcUnitCompose.ComposeType.INTELLIGENCE,
      CalcUnitCompose.ComposeType.VITALITY,
      CalcUnitCompose.ComposeType.MIND,
      CalcUnitCompose.ComposeType.AGILITY,
      CalcUnitCompose.ComposeType.DEXTERITY,
      CalcUnitCompose.ComposeType.LUCKY
    };
    int[] numArray1 = new int[8]
    {
      this.baseUnit.total_hp,
      this.baseUnit.total_strength,
      this.baseUnit.total_intelligence,
      this.baseUnit.total_vitality,
      this.baseUnit.total_mind,
      this.baseUnit.total_agility,
      this.baseUnit.total_dexterity,
      this.baseUnit.total_lucky
    };
    int[] numArray2 = new int[8]
    {
      this.baseUnit.hp.compose,
      this.baseUnit.strength.compose,
      this.baseUnit.intelligence.compose,
      this.baseUnit.vitality.compose,
      this.baseUnit.mind.compose,
      this.baseUnit.agility.compose,
      this.baseUnit.dexterity.compose,
      this.baseUnit.lucky.compose
    };
    int[] numArray3 = new int[8]
    {
      this.baseUnit.hp.buildup,
      this.baseUnit.strength.buildup,
      this.baseUnit.intelligence.buildup,
      this.baseUnit.vitality.buildup,
      this.baseUnit.mind.buildup,
      this.baseUnit.agility.buildup,
      this.baseUnit.dexterity.buildup,
      this.baseUnit.lucky.buildup
    };
    bool[] flagArray = new bool[8]
    {
      this.baseUnit.hp.is_max,
      this.baseUnit.strength.is_max,
      this.baseUnit.intelligence.is_max,
      this.baseUnit.vitality.is_max,
      this.baseUnit.mind.is_max,
      this.baseUnit.agility.is_max,
      this.baseUnit.dexterity.is_max,
      this.baseUnit.lucky.is_max
    };
    int num = ((IEnumerable<GameObject>) this.StatusGaugeBase).Count<GameObject>();
    for (int index = 0; index < num; ++index)
    {
      GameObject gameObject = this.StatusGaugeBase[index];
      gameObject.transform.Clear();
      prefabGauge.CloneAndGetComponent<Unit00483StatusGauge>(gameObject).Init(this.baseUnit, materialPlayerUnits, composeTypeArray[index], numArray1[index], numArray2[index], numArray3[index], flagArray[index]);
      NGTween.playTweens(NGTween.findTweenersAll(gameObject, false), 0);
    }
  }

  private void setLimitBreak(PlayerUnit basePlayerUnit, int limitBreakCount)
  {
    this.limitBreak.SetActive(true);
    foreach (Component component in this.limitBreakBlue)
      component.gameObject.SetActive(false);
    foreach (Component component in this.limitBreakGreen)
      component.gameObject.SetActive(false);
    for (int index = 0; index < basePlayerUnit.breakthrough_count; ++index)
      ((Component) this.limitBreakBlue[index]).gameObject.SetActive(true);
    for (int breakthroughCount = basePlayerUnit.breakthrough_count; breakthroughCount < basePlayerUnit.breakthrough_count + limitBreakCount; ++breakthroughCount)
    {
      UISprite uiSprite = this.limitBreakGreen[breakthroughCount];
      ((Component) uiSprite).gameObject.SetActive(true);
      NGTween.playTweens(NGTween.findTweenersAll(((Component) uiSprite).gameObject, false), 0);
    }
    if (basePlayerUnit.unit.breakthrough_limit != 0)
      return;
    this.slc_Limitbreak.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator CreateSkillIcon(BattleskillSkill sk, int idx, int unitSkillLv, int needLv)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Menu.\u003CCreateSkillIcon\u003Ec__Iterator37D()
    {
      idx = idx,
      unitSkillLv = unitSkillLv,
      needLv = needLv,
      sk = sk,
      \u003C\u0024\u003Eidx = idx,
      \u003C\u0024\u003EunitSkillLv = unitSkillLv,
      \u003C\u0024\u003EneedLv = needLv,
      \u003C\u0024\u003Esk = sk,
      \u003C\u003Ef__this = this
    };
  }

  private void DisplaySkillLevelUpArrow(int idx, float rate)
  {
    if ((double) rate <= 0.0)
    {
      this.skillUpObject[idx].SetActive(false);
    }
    else
    {
      this.skillUpObject[idx].SetActive(true);
      string str1 = "slc_SkillUP";
      string str2 = (double) rate >= 40.0 ? ((double) rate >= 70.0 ? ((double) rate >= 100.0 ? str1 + "4" : str1 + "3") : str1 + "2") : str1 + "1";
      this.skillUpObject[idx].transform.GetChildren().ForEach<Transform>((Action<Transform>) (x => ((Component) x).gameObject.SetActive(false)));
      Transform child = this.skillUpObject[idx].transform.FindChild(str2);
      if (Object.op_Inequality((Object) child, (Object) null))
        ((Component) child).gameObject.SetActive(true);
    }
    NGTween.playTweens(NGTween.findTweenersAll(this.skillUpObject[idx], false), 0);
  }

  [DebuggerHidden]
  private IEnumerator setSkillIcon(PlayerUnit basePlayerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Menu.\u003CsetSkillIcon\u003Ec__Iterator37E()
    {
      basePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u003Ef__this = this
    };
  }

  private int calcComposeSuccessProb(PlayerUnit[] playerUnits)
  {
    int ret = 0;
    ((IEnumerable<PlayerUnit>) playerUnits).ForEach<PlayerUnit>((Action<PlayerUnit>) (pu =>
    {
      if (pu.unit.IsBuildup)
        ret += 100;
      else if (pu.unit.rarity.index == 0)
        ret += 5;
      else if (pu.unit.rarity.index == 1)
        ret += 10;
      else if (pu.unit.rarity.index == 2)
        ret += 50;
      else
        ret += 100;
    }));
    if (ret > 100)
      ret = 100;
    return ret;
  }

  protected virtual void ChangeSozaiSelect(PlayerUnit _baseUnit, PlayerUnit[] _selectUnit)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Unit00486Scene.changeScene(false, _baseUnit, _selectUnit);
  }

  [DebuggerHidden]
  public IEnumerator combine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Menu.\u003Ccombine\u003Ec__Iterator37F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public Dictionary<string, object> setShowPopupData(
    List<PlayerUnit> resultList,
    WebAPI.Response.UnitCompose param)
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    dictionary["unlockQuests"] = (object) param.unlock_quests;
    Func<List<int>, List<int>, int> func = (Func<List<int>, List<int>, int>) ((list1, list2) =>
    {
      int num1 = 0;
      foreach (int num2 in list1)
      {
        if (!list2.Contains(num2))
          num1 = num2;
      }
      return num1;
    });
    List<int> list3 = ((IEnumerable<PlayerUnitSkills>) resultList[0].GetAcquireSkills()).Select<PlayerUnitSkills, int>((Func<PlayerUnitSkills, int>) (x => x.skill_id)).ToList<int>();
    List<int> list4 = ((IEnumerable<PlayerUnitSkills>) resultList[1].GetAcquireSkills()).Select<PlayerUnitSkills, int>((Func<PlayerUnitSkills, int>) (x => x.skill_id)).ToList<int>();
    dictionary["beforeSkillId"] = (object) func(list3, list4);
    dictionary["afterSkillId"] = (object) func(list4, list3);
    return dictionary;
  }

  protected virtual void changeSceneForCombine(
    List<PlayerUnit> materialList,
    List<PlayerUnit> resultList,
    List<int> otherList,
    Dictionary<string, object> showPopupData)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_12", false, (object) materialList, (object) resultList, (object) otherList, (object) showPopupData);
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnChange()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnCombine()
  {
    if (this.IsPushAndSet())
      return;
    List<PlayerUnit> rarityList = new List<PlayerUnit>();
    ((IEnumerable<PlayerUnit>) this.selectUnit).ForEach<PlayerUnit>((Action<PlayerUnit>) (x =>
    {
      if (x.unit.rarity.index < 2)
        return;
      rarityList.Add(x);
    }));
    if (rarityList.Count<PlayerUnit>() != 0)
      this.changeSceneForPopup(Singleton<PopupManager>.GetInstance().open(this.RarityAlertPopupPrefab).GetComponent<Unit004832Menu>(), rarityList, this.baseUnit, this.selectUnit);
    else
      this.StartCoroutine(this.combine());
  }

  protected virtual void changeSceneForPopup(
    Unit004832Menu popupMenu,
    List<PlayerUnit> rarityList,
    PlayerUnit baseUnit,
    PlayerUnit[] selectUnit)
  {
    this.StartCoroutine(popupMenu.SetSelectedUnitIcons(new Func<List<PlayerUnit>, WebAPI.Response.UnitCompose, Dictionary<string, object>>(this.setShowPopupData), rarityList.ToArray(), baseUnit, selectUnit));
  }
}
