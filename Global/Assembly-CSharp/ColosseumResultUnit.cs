// Decompiled with JetBrains decompiler
// Type: ColosseumResultUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
public class ColosseumResultUnit : MonoBehaviour
{
  private const float LINK_WIDTH = 120f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 0.882352948f;
  [SerializeField]
  private UILabel TxtUnitEXP;
  [SerializeField]
  private GameObject LinkChar;
  [SerializeField]
  private GameObject LinkBugu;
  [SerializeField]
  private GameObject DirBuguRankUP;
  [SerializeField]
  private GameObject DirProficiency;
  [SerializeField]
  private GameObject DirUnitLevelUP;
  [SerializeField]
  private GameObject DirWeaponRankUP;
  [SerializeField]
  private GameObject DirWeaponBroken;
  [SerializeField]
  private GameObject ProficiencyBefore;
  [SerializeField]
  private GameObject ProficiencyAfter;
  [SerializeField]
  private GameObject UnitExpGauge;
  [SerializeField]
  private GameObject WeaponExpGauge;
  [SerializeField]
  private GameObject WeaponBreakIcon;
  [SerializeField]
  private GameObject MVPIcon;
  [SerializeField]
  private GameObject DeathIcon;
  private bool IsGearBreak;
  private bool IsGearBreakStopAnim;
  private bool IsGearRankUp;
  private int GearBeforeLv;
  private int GearAfterLv;
  private int GetUnitEXP;
  private List<Tuple<bool, GearGearSkill>> gearUpgradeSkills;
  private PlayerItem gear;
  private PlayerUnit beforeUnit;
  private PlayerUnit afterUnit;

  public int GetUnitExp => this.GetUnitEXP;

  public PlayerUnit BeforeUnit => this.beforeUnit;

  public PlayerUnit AfterUnit => this.afterUnit;

  public List<Tuple<bool, GearGearSkill>> GearUpgradeSkills => this.gearUpgradeSkills;

  public PlayerItem Gear => this.gear;

  [DebuggerHidden]
  public IEnumerator OnUnitLevelup(GameObject obj, int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumResultUnit.\u003COnUnitLevelup\u003Ec__Iterator527()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  private void OutUnitLevelup() => this.DirUnitLevelUP.SetActive(false);

  public void SetDeath()
  {
    if (!Object.op_Inequality((Object) this.DeathIcon, (Object) null))
      return;
    this.DeathIcon.SetActive(true);
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit beforeUnit, PlayerUnit afterUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumResultUnit.\u003CInit\u003Ec__Iterator528()
    {
      beforeUnit = beforeUnit,
      afterUnit = afterUnit,
      \u003C\u0024\u003EbeforeUnit = beforeUnit,
      \u003C\u0024\u003EafterUnit = afterUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadUnitPrefab(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumResultUnit.\u003CLoadUnitPrefab\u003Ec__Iterator529()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadGearPrefab(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumResultUnit.\u003CLoadGearPrefab\u003Ec__Iterator52A()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  public void SetProficiency(int gearKindId, PlayerUnit before, PlayerUnit after)
  {
    PlayerUnitGearProficiency unitGearProficiency1 = ((IEnumerable<PlayerUnitGearProficiency>) before.gear_proficiencies).Where<PlayerUnitGearProficiency>((Func<PlayerUnitGearProficiency, bool>) (x => x.gear_kind_id == gearKindId)).ToArray<PlayerUnitGearProficiency>()[0];
    PlayerUnitGearProficiency unitGearProficiency2 = ((IEnumerable<PlayerUnitGearProficiency>) after.gear_proficiencies).Where<PlayerUnitGearProficiency>((Func<PlayerUnitGearProficiency, bool>) (x => x.gear_kind_id == gearKindId)).ToArray<PlayerUnitGearProficiency>()[0];
    this.GearBeforeLv = unitGearProficiency1.level;
    this.GearAfterLv = unitGearProficiency2.level;
    ((Component) this.ProficiencyBefore.transform.FindChild(string.Format("dyn_IconRank_{0}", (object) MasterData.UnitProficiency[unitGearProficiency1.level].proficiency))).gameObject.SetActive(true);
    this.DirProficiency.SetActive(true);
    this.ProficiencyBefore.SetActive(true);
    ((IEnumerable<UITweener>) this.ProficiencyBefore.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != 1)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public GaugeRunner GetUnitExpGaugeRunner(Func<GameObject, int, IEnumerator> levelupCallback)
  {
    float before = (float) this.beforeUnit.exp / (float) (this.beforeUnit.exp + this.beforeUnit.exp_next);
    float after = (float) this.afterUnit.exp / (float) (this.afterUnit.exp + this.afterUnit.exp_next);
    int loopNum = this.afterUnit.level - this.beforeUnit.level;
    Func<GameObject, int, IEnumerator> levelupCallback1 = new Func<GameObject, int, IEnumerator>(this.OnUnitLevelup);
    if (levelupCallback != null)
      levelupCallback1 = levelupCallback;
    return new GaugeRunner(this.UnitExpGauge, before, after, loopNum, levelupCallback1);
  }

  public GaugeRunner GetGearExpGaugeRunner(
    Dictionary<int, PlayerItem> beforePlayerGears,
    Dictionary<int, PlayerItem> afterPlayerGears,
    Func<GameObject, int, IEnumerator> levelupCallback)
  {
    if (this.afterUnit.equippedGear == (PlayerItem) null)
      return (GaugeRunner) null;
    if (!((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Any<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == this.afterUnit.equippedGear.id)))
    {
      Debug.LogError((object) ("ColosseumBattleResult: 装備武具が見つからない (id: " + (object) this.afterUnit.equippedGear.id + ")"));
      return (GaugeRunner) null;
    }
    PlayerItem playerItem;
    if (!beforePlayerGears.TryGetValue(this.afterUnit.equippedGear.id, out playerItem))
      return (GaugeRunner) null;
    PlayerItem after;
    if (!afterPlayerGears.TryGetValue(this.afterUnit.equippedGear.id, out after))
      return (GaugeRunner) null;
    this.gear = after;
    if (after.gear_level > playerItem.gear_level)
      this.IsGearRankUp = true;
    if (this.afterUnit.equippedGear != (PlayerItem) null && afterPlayerGears.ContainsKey(this.afterUnit.equippedGear.id) && afterPlayerGears[this.afterUnit.equippedGear.id].broken)
    {
      this.IsGearBreak = true;
      if (beforePlayerGears[this.afterUnit.equippedGear.id].broken)
      {
        this.IsGearBreakStopAnim = true;
        this.ShowWeaponBreak();
        this.WeaponBreakStopAnimation();
      }
    }
    if (after.skills.Length > 0 && this.IsGearRankUp)
    {
      this.gearUpgradeSkills = new List<Tuple<bool, GearGearSkill>>();
      for (int i = 0; i < after.skills.Length; ++i)
      {
        GearGearSkill gearGearSkill = ((IEnumerable<GearGearSkill>) playerItem.skills).FirstOrDefault<GearGearSkill>((Func<GearGearSkill, bool>) (x => x.skill_group == after.skills[i].skill_group));
        if (gearGearSkill == null)
          this.gearUpgradeSkills.Add(new Tuple<bool, GearGearSkill>(true, after.skills[i]));
        else if (gearGearSkill.ID != after.skills[i].ID)
          this.gearUpgradeSkills.Add(new Tuple<bool, GearGearSkill>(false, after.skills[i]));
      }
    }
    return new GaugeRunner(this.WeaponExpGauge, (float) playerItem.gear_exp / (float) (playerItem.gear_exp + playerItem.gear_exp_next), (float) after.gear_exp / (float) (after.gear_exp + after.gear_exp_next), after.gear_level - playerItem.gear_level, levelupCallback);
  }

  public void OpenAfterProficiency()
  {
    if (this.GearBeforeLv == this.GearAfterLv)
      return;
    ((Component) this.ProficiencyAfter.transform.FindChild(string.Format("dyn_IconRank_{0}", (object) MasterData.UnitProficiency[this.GearAfterLv].proficiency))).gameObject.SetActive(true);
    this.ProficiencyAfter.SetActive(true);
    this.DirBuguRankUP.SetActive(true);
    this.Invoke("OutProficiencyRankUp", 1f);
    ((IEnumerable<UITweener>) this.DirBuguRankUP.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    ((IEnumerable<UITweener>) this.ProficiencyAfter.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    ((IEnumerable<UITweener>) this.ProficiencyBefore.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != 0)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  private void OutProficiencyRankUp() => this.DirBuguRankUP.SetActive(false);

  public void SetMVP(bool active) => this.MVPIcon.SetActive(active);

  public void ShowUnitExp()
  {
    ((Component) this.TxtUnitEXP).gameObject.SetActive(false);
    if (this.GetUnitEXP <= 0)
      return;
    ((Component) this.TxtUnitEXP).gameObject.SetActive(true);
    this.TxtUnitEXP.SetTextLocalize("ＥＸＰ＋" + this.GetUnitEXP.ToString());
    ((IEnumerable<UITweener>) ((Component) this.TxtUnitEXP).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public void ShowWeaponRankUp()
  {
    if (!this.IsGearRankUp)
      return;
    this.DirWeaponRankUP.SetActive(true);
    this.Invoke("OutWeaponRankUp", 1f);
  }

  private void OutWeaponRankUp() => this.DirWeaponRankUP.SetActive(false);

  public bool ShowWeaponBreak()
  {
    if (this.IsGearBreak)
      this.DirWeaponBroken.SetActive(true);
    return this.IsGearBreak;
  }

  public bool IsWeaponBreakStopAnim() => this.IsGearBreakStopAnim;

  public void WeaponBreakStopAnimation()
  {
    ((IEnumerable<UITweener>) this.DirWeaponBroken.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.delay = 0.0f;
      x.duration = 0.0f;
    }));
  }

  public bool ShowGearUpgradeSkill()
  {
    return this.gearUpgradeSkills != null && this.gearUpgradeSkills.Count > 0;
  }

  public bool IsLevelUP() => this.afterUnit.level > this.beforeUnit.level;

  public bool IsProficiencyLevelUp() => this.GearBeforeLv < this.GearAfterLv;
}
