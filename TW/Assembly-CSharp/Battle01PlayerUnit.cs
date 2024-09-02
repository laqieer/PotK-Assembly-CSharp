// Decompiled with JetBrains decompiler
// Type: Battle01PlayerUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PlayerUnit : BattleMonoBehaviour
{
  [SerializeField]
  private NGTweenGaugeScale hpGauge;
  [SerializeField]
  private UI2DSprite character;
  [SerializeField]
  private Battle01UnitCounter counter;
  [SerializeField]
  private GameObject dropout;
  [SerializeField]
  private Battle01PVPRespawnCount pvpRespawnCount;
  private BL.BattleModified<BL.PhaseState> phaseModified;
  private BL.BattleModified<BL.Skill> ougiModified;
  private BL.BattleModified<BL.UnitPosition> positionModified;
  private BL.BattleModified<BL.Unit> modified;
  private UnitIcon unitIcon;
  [SerializeField]
  private UIWidget rootWidget;
  public bool isViewCounter;

  public bool isViewDropout
  {
    get => this.dropout.activeSelf;
    set
    {
      if (this.dropout.activeSelf == value)
        return;
      this.dropout.SetActive(value);
    }
  }

  private void Awake() => ((Behaviour) this.character).enabled = false;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PlayerUnit.\u003CStart_Battle\u003Ec__Iterator91E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PlayerUnit.\u003ConInitAsync\u003Ec__Iterator91F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(BL.Unit unit, bool isGray)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PlayerUnit.\u003CdoSetIcon\u003Ec__Iterator920()
    {
      unit = unit,
      isGray = isGray,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisGray = isGray,
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null || !Object.op_Inequality((Object) this.unitIcon, (Object) null))
      return;
    bool flag1 = this.modified.isChangedOnce();
    BL.Unit unit = this.modified.value;
    bool flag2 = this.isViewCounter && unit.hasOugi && (!this.battleManager.isPvp || !unit.isDead);
    if (flag1)
    {
      this.StartCoroutine(this.doSetIcon(unit, this.positionModified.value.isCompleted));
      this.hpGauge.setValue(!unit.isDead ? unit.hp : 0, unit.parameter.Hp);
      this.counter.isActive = flag2;
      this.isViewDropout = unit.isDead;
    }
    if (flag2 && (flag1 || this.phaseModified.isChangedOnce() || this.ougiModified.isChangedOnce()))
      this.counter.setCount(this.ougiModified.value.useTurn - this.phaseModified.value.absoluteTurnCount);
    if (this.battleManager.isOvo && flag1)
    {
      if (unit.isDead)
      {
        ((Component) this.pvpRespawnCount).gameObject.SetActive(true);
        this.pvpRespawnCount.setCount(unit.pvpRespawnCount);
      }
      else
        ((Component) this.pvpRespawnCount).gameObject.SetActive(false);
    }
    if (!this.positionModified.isChangedOnce())
      return;
    this.unitIcon.Gray = this.positionModified.value.isCompleted;
  }

  public void setUnit(BL.Unit unit)
  {
    this.hpGauge.setValue(!unit.isDead ? unit.hp : 0, unit.parameter.Hp, false);
    this.modified = BL.Observe<BL.Unit>(unit);
    this.ougiModified = BL.Observe<BL.Skill>(unit.ougi);
    this.positionModified = BL.Observe<BL.UnitPosition>(Singleton<NGBattleManager>.GetInstance().environment.core.getUnitPosition(unit));
  }

  public BL.Unit getUnit() => this.modified != null ? this.modified.value : (BL.Unit) null;
}
