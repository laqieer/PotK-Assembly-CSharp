// Decompiled with JetBrains decompiler
// Type: GuideUnitDeteilIndicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
public class GuideUnitDeteilIndicator : MonoBehaviour
{
  [SerializeField]
  private UILabel txt_Pullout;
  [SerializeField]
  private UILabel txt_Skillname;
  [SerializeField]
  private UILabel txt_Skillexplanation;
  [SerializeField]
  private UILabel txt_defeat_num;
  [SerializeField]
  private UILabel txt_Pullout_num;
  [SerializeField]
  private UILabel txt_Jobname;
  [SerializeField]
  private UI3DModel ui3DModel;
  [SerializeField]
  private List<BattleSkillIcon> dyn_Unit_Skill = new List<BattleSkillIcon>();
  [SerializeField]
  private List<UIButton> UiButtonList = new List<UIButton>();
  [SerializeField]
  private GameObject floatingSkillDialog;
  private List<BattleskillSkill> battleSkillList = new List<BattleskillSkill>();
  private GameObject SkillDialog;
  private Action<BattleskillSkill> showSkillDialog;

  [DebuggerHidden]
  public IEnumerator Set(
    UnitUnit unit,
    PlayerUnitHistory history,
    UnitUnit[] commonUnitList,
    PlayerUnitHistory[] historyList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuideUnitDeteilIndicator.\u003CSet\u003Ec__Iterator556()
    {
      unit = unit,
      commonUnitList = commonUnitList,
      historyList = historyList,
      history = history,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EcommonUnitList = commonUnitList,
      \u003C\u0024\u003EhistoryList = historyList,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u003Ef__this = this
    };
  }

  public void SetPullout(UnitUnit unit, UnitUnit[] commonUnitList, PlayerUnitHistory[] historyList)
  {
    int defeat = 0;
    ((IEnumerable<PlayerUnitHistory>) historyList).ForEach<PlayerUnitHistory>((Action<PlayerUnitHistory>) (obj =>
    {
      if (obj.unit_id != unit.ID)
        return;
      defeat += obj.defeat;
    }));
    if (defeat > 99999)
      defeat = 99999;
    this.txt_Pullout.SetTextLocalize(defeat);
  }

  public void SetJobName(UnitUnit unit) => this.txt_Jobname.SetTextLocalize(unit.job.name);

  public void SetLeaderSkill(UnitUnit unit)
  {
    List<UnitLeaderSkill> list = ((IEnumerable<UnitLeaderSkill>) MasterData.UnitLeaderSkillList).Where<UnitLeaderSkill>((Func<UnitLeaderSkill, bool>) (x => x.unit.ID == unit.ID)).ToList<UnitLeaderSkill>();
    if (list.Count == 0)
    {
      this.txt_Skillname.alignment = NGUIText.Alignment.Center;
      this.txt_Skillname.SetTextLocalize("-");
      this.txt_Skillexplanation.SetTextLocalize(string.Empty);
    }
    else
    {
      this.txt_Skillname.alignment = NGUIText.Alignment.Left;
      this.txt_Skillname.SetTextLocalize(list[0].skill.name);
      this.txt_Skillexplanation.SetTextLocalize(list[0].skill.description);
    }
  }

  [DebuggerHidden]
  public IEnumerator InitSkillDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuideUnitDeteilIndicator.\u003CInitSkillDialog\u003Ec__Iterator557()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetSkillIcon(UnitUnit unit, PlayerUnitHistory history)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuideUnitDeteilIndicator.\u003CSetSkillIcon\u003Ec__Iterator558()
    {
      unit = unit,
      history = history,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitSkill(
    UnitSkill[] unitSkills,
    List<BattleSkillIcon> dyn_Unit_Skill,
    List<BattleskillSkill> battleSkillList,
    PlayerUnitHistory history)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuideUnitDeteilIndicator.\u003CSetUnitSkill\u003Ec__Iterator559()
    {
      dyn_Unit_Skill = dyn_Unit_Skill,
      battleSkillList = battleSkillList,
      history = history,
      unitSkills = unitSkills,
      \u003C\u0024\u003Edyn_Unit_Skill = dyn_Unit_Skill,
      \u003C\u0024\u003EbattleSkillList = battleSkillList,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u0024\u003EunitSkills = unitSkills,
      \u003C\u003Ef__this = this
    };
  }

  private void SetSkillDeteilEvent(
    BattleskillSkill skillskill,
    BattleSkillIcon WeaponSkill,
    UIButton WeaponSkillButton)
  {
    if (this.showSkillDialog == null)
    {
      Battle0171111Event dialog = this.SkillDialog.Clone(this.floatingSkillDialog.transform).GetComponentInChildren<Battle0171111Event>();
      ((Component) ((Component) dialog).transform.parent).gameObject.SetActive(false);
      this.showSkillDialog = (Action<BattleskillSkill>) (skill =>
      {
        dialog.setData(skill);
        dialog.setSkillLv(0, skill.upper_level);
        dialog.Show();
      });
    }
    if (skillskill == null)
      return;
    this.StartCoroutine(WeaponSkill.Init(skillskill));
    EventDelegate.Add(WeaponSkillButton.onClick, (EventDelegate.Callback) (() => this.showSkillDialog(skillskill)));
  }

  [DebuggerHidden]
  public IEnumerator SetModel(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuideUnitDeteilIndicator.\u003CSetModel\u003Ec__Iterator55A()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }
}
