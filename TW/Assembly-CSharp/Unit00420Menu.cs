// Decompiled with JetBrains decompiler
// Type: Unit00420Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00420Menu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject[] slcPrincessTypes;
  [SerializeField]
  private GameObject dynTumn;
  [SerializeField]
  private GameObject[] dirSozaibases;
  [SerializeField]
  private UILabel TxtHimeEnforceNumer;
  [SerializeField]
  private UILabel TxtHimeEnforceDenom;
  [SerializeField]
  private UILabel TxtHimeEnforceMaxNumer;
  [SerializeField]
  private GameObject[] StatusGaugeBases;
  [SerializeField]
  private UILabel TxtZeny;
  [SerializeField]
  private UIButton ibtnReset;
  [SerializeField]
  private UIButton ibtnReinforceAnimFade01;
  private GameObject rarityAlertPopupPrefab;
  private GameObject resetAlertPopupPrefab;
  private GameObject unitIconPrefab;
  private GameObject detailIconPrefab;
  private GameObject skillTypeIconPrefab;
  private GameObject statusGaugePrefab;
  private PlayerUnit baseUnit;
  private PlayerUnit[] selectUnit = new PlayerUnit[5];

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator LoadResource()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420Menu.\u003CLoadResource\u003Ec__Iterator2F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    bool updateBaseIcon = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420Menu.\u003CInit\u003Ec__Iterator2F4()
    {
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      updateBaseIcon = updateBaseIcon,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003EupdateBaseIcon = updateBaseIcon,
      \u003C\u003Ef__this = this
    };
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
      this.baseUnit.hp.level_up_max_status,
      this.baseUnit.strength.level_up_max_status,
      this.baseUnit.intelligence.level_up_max_status,
      this.baseUnit.vitality.level_up_max_status,
      this.baseUnit.mind.level_up_max_status,
      this.baseUnit.agility.level_up_max_status,
      this.baseUnit.dexterity.level_up_max_status,
      this.baseUnit.lucky.level_up_max_status
    };
    int[] numArray3 = new int[8]
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
    int[] numArray4 = new int[8]
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
    int[] numArray5 = new int[8]
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
    int[] numArray6 = new int[8]
    {
      this.baseUnit.unit.buildup_limit_release_id.hp_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.strength_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.intelligence_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.vitality_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.mind_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.agility_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.dexterity_limit_release_cnt,
      this.baseUnit.unit.buildup_limit_release_id.lucky_limit_release_cnt
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
    int num = ((IEnumerable<GameObject>) this.StatusGaugeBases).Count<GameObject>();
    for (int index = 0; index < num; ++index)
    {
      GameObject statusGaugeBase = this.StatusGaugeBases[index];
      statusGaugeBase.transform.Clear();
      prefabGauge.CloneAndGetComponent<Unit00420StatusGauge>(statusGaugeBase).Init(this.baseUnit, materialPlayerUnits, composeTypeArray[index], numArray1[index], numArray2[index], numArray3[index], numArray4[index], numArray5[index], numArray6[index], flagArray[index]);
      NGTween.playTweens(NGTween.findTweenersAll(statusGaugeBase, false), 0);
    }
  }

  private void ChangeSozaiSelect(PlayerUnit baseUnit, PlayerUnit[] selectUnit)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Unit00487Scene.changeScene(false, baseUnit, selectUnit);
  }

  public void IbtnReset()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowResetAlertPopup());
  }

  [DebuggerHidden]
  private IEnumerator ShowResetAlertPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420Menu.\u003CShowResetAlertPopup\u003Ec__Iterator2F5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnEnforce()
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
    {
      Unit004832Menu component = Singleton<PopupManager>.GetInstance().open(this.rarityAlertPopupPrefab).GetComponent<Unit004832Menu>();
      component.mode = Unit00468Scene.Mode.Unit00420;
      this.changeSceneForPopup(component, rarityList, this.baseUnit, this.selectUnit);
    }
    else
      this.StartCoroutine(this.enforce());
  }

  private void changeSceneForPopup(
    Unit004832Menu popupMenu,
    List<PlayerUnit> rarityList,
    PlayerUnit baseUnit,
    PlayerUnit[] selectUnit)
  {
    this.StartCoroutine(popupMenu.SetSelectedUnitIcons(new Func<List<PlayerUnit>, WebAPI.Response.UnitCompose, Dictionary<string, object>>(this.setShowPopupData), rarityList.ToArray(), baseUnit, selectUnit));
  }

  [DebuggerHidden]
  public IEnumerator enforce()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420Menu.\u003Cenforce\u003Ec__Iterator2F6()
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
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_12", false, (object) materialList, (object) resultList, (object) otherList, (object) showPopupData, (object) Unit00468Scene.Mode.Unit00420);
  }
}
