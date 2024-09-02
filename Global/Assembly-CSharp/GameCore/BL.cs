// Decompiled with JetBrains decompiler
// Type: GameCore.BL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using AI.Logic;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class BL
  {
    public BL.ClassValue<List<BL.AIUnit>> aiUnitPositions;
    public BL.ClassValue<List<BL.AIUnit>> aiUnits;
    public BL.ClassValue<List<BL.AIUnit>> aiActionUnits;
    public BL.ClassValue<Queue<BL.AIUnit>> aiActionOrder;
    public BL.ClassValue<List<BL.AIUnit>> aiDeads;
    public int aiActionMax;
    public BL.Condition condition;
    [NonSerialized]
    private List<BL.Unit> loseUnitList;
    [NonSerialized]
    private BattleVictoryAreaCondition[] _winAreaCache;
    [NonSerialized]
    private BattleVictoryAreaCondition[] _loseAreaCache;
    public BL.StructValue<int> dropMoney;
    public BL.StructValue<int> dropItem;
    public BL.StructValue<int> dropUnit;
    public BL.ClassValue<List<BL.UnitPosition>> unitPositions;
    [SerializeField]
    private BL.Panel[,] fieldMatrix;
    public BL.Stage stage;
    public BL.ClassValue<BL.Panel> fieldCurrent;
    public BL.ClassValue<List<BL.FieldEffect>> fieldEffectList;
    private BL.Intimate intimate;
    public BL.StructValue<bool> isAutoBattle;
    public BL.ClassValue<List<BL.Item>> itemList;
    public BL.ClassValue<List<BL.Item>> itemListInBattle;
    public BattleInfo battleInfo;
    public XorShift randomBase;
    public int randomCount;
    public XorShift random;
    public int continueCount;
    public bool isWin;
    public int currentWave;
    [NonSerialized]
    private Dictionary<int, Dictionary<int, List<BL.AttackStatusCacheContainer>>> mAttackStatusCacheDic;
    [NonSerialized]
    private Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> mRouteDic;
    [NonSerialized]
    private Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> mRouteDic_IM;
    public BL.PhaseState phaseState;
    public BL.StructValue<bool> firstCompleted;
    public BL.ClassValue<List<BL.UnitPosition>> playerActionUnits;
    public BL.ClassValue<List<BL.UnitPosition>> neutralActionUnits;
    public BL.ClassValue<List<BL.UnitPosition>> enemyActionUnits;
    public BL.ClassValue<List<BL.UnitPosition>> completedActionUnits;
    public BL.ClassValue<List<BL.UnitPosition>> spawnUnits;
    public BL.ClassValue<List<BL.Story>> storyList;
    public BL.ClassValue<List<BL.Unit>> playerUnits;
    public BL.ClassValue<List<BL.Unit>> neutralUnits;
    public BL.ClassValue<List<BL.Unit>> enemyUnits;
    public BL.CurrentUnit unitCurrent;
    public BL.StructValue<bool> isViewDengerArea;
    public BL.StructValue<int> sight;
    public BL.StructValue<bool> isViewUnitType;
    private BL.ForceID[] playerTarget;
    private List<BL.Panel> mDangerAria;

    public BL()
    {
      this.aiUnitPositions = new BL.ClassValue<List<BL.AIUnit>>((List<BL.AIUnit>) null);
      this.aiUnits = new BL.ClassValue<List<BL.AIUnit>>((List<BL.AIUnit>) null);
      this.aiActionUnits = new BL.ClassValue<List<BL.AIUnit>>((List<BL.AIUnit>) null);
      this.aiActionOrder = new BL.ClassValue<Queue<BL.AIUnit>>((Queue<BL.AIUnit>) null);
      this.aiDeads = new BL.ClassValue<List<BL.AIUnit>>((List<BL.AIUnit>) null);
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    public List<BL.AIUnit> getTargetAIUnits(BL.AIUnit aiUnit)
    {
      return this.getTargetAIUnits(this.getTargetForce(aiUnit.unitPosition.unit));
    }

    public List<BL.AIUnit> getTargetAIUnits(BL.ForceID[] forceIds)
    {
      List<BL.AIUnit> targetAiUnits = new List<BL.AIUnit>();
      foreach (BL.AIUnit aiUnit in this.aiUnitPositions.value)
      {
        if (((IEnumerable<BL.ForceID>) forceIds).Contains<BL.ForceID>(aiUnit.getForceID(this)) && aiUnit.hp > 0)
          targetAiUnits.Add(aiUnit);
      }
      return targetAiUnits;
    }

    public bool isMoveOKAI(
      BL.Panel panel,
      BL.Unit unit,
      bool isRebirth,
      bool enabledIgnoreMoveCost,
      int moveCost)
    {
      if (!this.isMoveOKPanel(panel, unit, enabledIgnoreMoveCost, moveCost))
        return false;
      BL.UnitPosition fieldUnitAi = this.getFieldUnitAI(panel.row, panel.column);
      return fieldUnitAi == null || fieldUnitAi.unit == unit || this.getForceID(fieldUnitAi.unit) == this.getForceID(unit) || fieldUnitAi.unit.isDead || isRebirth;
    }

    public static int panelIndex(BL.AIUnit unit) => BL.panelIndex(unit.row, unit.column);

    public static int panelIndex(BL.Panel panel) => BL.panelIndex(panel.row, panel.column);

    public static int panelIndex(int row, int column) => row * 10000 + column;

    public BL.UnitPosition getFieldUnitAI(int row, int column)
    {
      foreach (BL.AIUnit fieldUnitAi in this.aiUnitPositions.value)
      {
        if (fieldUnitAi.row == row && fieldUnitAi.column == column)
          return (BL.UnitPosition) fieldUnitAi;
      }
      return (BL.UnitPosition) null;
    }

    public BL.UnitPosition getFieldUnitAI(BL.Panel panel)
    {
      return this.getFieldUnitAI(panel.row, panel.column);
    }

    public BL.AIUnit getAIUnit(BL.Unit unit)
    {
      foreach (BL.AIUnit aiUnit in this.aiUnitPositions.value)
      {
        if (aiUnit.unit == unit)
          return aiUnit;
      }
      return (BL.AIUnit) null;
    }

    public static int fieldDistance(BL.AIUnit p1, BL.AIUnit p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(BL.AIUnit p1, BL.Panel p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(BL.Panel p1, BL.AIUnit p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public BL.Unit getBossUnit()
    {
      if (this.condition.type != BL.ConditionType.bossdown)
        return (BL.Unit) null;
      foreach (BL.Unit bossUnit in this.enemyUnits.value)
      {
        if (bossUnit.playerUnit.id == this.condition.bossId)
          return bossUnit;
      }
      return (BL.Unit) null;
    }

    public bool bossUnitp(BL.Unit unit) => this.getBossUnit() == unit;

    public BL.GameoverType getGamevoerType()
    {
      if (this.condition.condition.gameover_type_guest == 0)
        return BL.GameoverType.alldown;
      return this.condition.condition.gameover_type_guest == 1 ? BL.GameoverType.guestdown : BL.GameoverType.playerdown;
    }

    public List<BL.Unit> getLoseUnitList()
    {
      if (this.loseUnitList == null)
      {
        this.loseUnitList = new List<BL.Unit>();
        if (!string.IsNullOrEmpty(this.condition.condition.lose_on_unit_dead))
        {
          int result;
          IEnumerable<int> unitIDList = ((IEnumerable<string>) this.condition.condition.lose_on_unit_dead.Split(',')).Select<string, int>((Func<string, int>) (x => int.TryParse(x, out result) ? result : 0)).Where<int>((Func<int, bool>) (id => id > 0));
          this.loseUnitList.AddRange(this.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.playerUnit.is_enemy && !x.playerUnit.is_gesut && unitIDList.Contains<int>(x.index + 1))));
        }
        if (!string.IsNullOrEmpty(this.condition.condition.lose_on_gesut_dead))
        {
          int result;
          IEnumerable<int> gesutIDList = ((IEnumerable<string>) this.condition.condition.lose_on_gesut_dead.Split(',')).Select<string, int>((Func<string, int>) (x => int.TryParse(x, out result) ? result : 0)).Where<int>((Func<int, bool>) (id => id > 0));
          this.loseUnitList.AddRange(this.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.playerUnit.is_enemy && x.playerUnit.is_gesut && gesutIDList.Contains<int>(x.playerUnit.id))));
        }
      }
      return this.loseUnitList;
    }

    public List<BL.UnitPosition> getWinAreaUnitPositions()
    {
      if (this._winAreaCache == null)
        this._winAreaCache = this.condition.winAreaConditoin;
      return this.getConditionAreaUnitPositions(this._winAreaCache);
    }

    public List<BL.UnitPosition> getLoseAreaUnitPositions()
    {
      if (this._loseAreaCache == null)
        this._loseAreaCache = this.condition.loseAreaConditoin;
      return this.getConditionAreaUnitPositions(this._loseAreaCache);
    }

    public List<BL.UnitPosition> getConditionAreaUnitPositions(
      BattleVictoryAreaCondition[] area_condition)
    {
      List<BL.UnitPosition> areaUnitPositions = new List<BL.UnitPosition>();
      if (area_condition != null && area_condition.Length > 0)
      {
        foreach (BattleVictoryAreaCondition victoryAreaCondition in area_condition)
        {
          BL.UnitPosition fieldUnit = this.getFieldUnit(victoryAreaCondition.area_y, victoryAreaCondition.area_x);
          if (fieldUnit != null)
            areaUnitPositions.Add(fieldUnit);
        }
      }
      return areaUnitPositions;
    }

    public BL.UnitPosition currentUnitPosition
    {
      get
      {
        return this.unitCurrent.unit == null ? new BL.UnitPosition() : this.getUnitPosition(this.unitCurrent.unit);
      }
    }

    public void initializeFeild(int stageId)
    {
      this.stage = new BL.Stage(stageId);
      this.fieldMatrix = new BL.Panel[this.stage.stage.map_height, this.stage.stage.map_width];
    }

    public void setFeildPanel(
      int row,
      int column,
      int landformId,
      int fieldEventId,
      BL.DropData fieldEvent,
      BattleVictoryAreaCondition[] winArea = null,
      BattleVictoryAreaCondition[] loseArea = null,
      BattleReinforcement[] battleReinforcements = null)
    {
      this.fieldMatrix[row, column] = new BL.Panel(row, column, landformId, fieldEventId, fieldEvent, winArea, loseArea, battleReinforcements);
    }

    public void setCurrentField(int row, int column)
    {
      this.fieldCurrent.value = this.fieldMatrix[row, column];
    }

    public void setCurrentField(BL.Panel panel) => this.setCurrentField(panel.row, panel.column);

    public BL.UnitPosition getFieldUnit(int row, int column, bool original = false)
    {
      foreach (BL.UnitPosition fieldUnit in this.unitPositions.value)
      {
        int num1 = !original ? fieldUnit.row : fieldUnit.originalRow;
        int num2 = !original ? fieldUnit.column : fieldUnit.originalColumn;
        if (fieldUnit.unit.isEnable && !fieldUnit.unit.isDead && num1 == row && num2 == column)
          return fieldUnit;
      }
      return (BL.UnitPosition) null;
    }

    public BL.UnitPosition getFieldUnit(BL.Panel panel, bool original = false)
    {
      return this.getFieldUnit(panel.row, panel.column, original);
    }

    public BL.UnitPosition[] getFieldUnits(int row, int column, bool original = false, bool isDead = false)
    {
      List<BL.UnitPosition> source = new List<BL.UnitPosition>();
      foreach (BL.UnitPosition unitPosition in this.unitPositions.value)
      {
        int num1 = !original ? unitPosition.row : unitPosition.originalRow;
        int num2 = !original ? unitPosition.column : unitPosition.originalColumn;
        if (unitPosition.unit.isEnable && (!isDead && !unitPosition.unit.isDead || isDead && unitPosition.unit.isDead) && num1 == row && num2 == column)
          source.Add(unitPosition);
      }
      return source.Any<BL.UnitPosition>() ? source.ToArray() : (BL.UnitPosition[]) null;
    }

    public BL.UnitPosition[] getFieldUnits(BL.Panel panel, bool original = false, bool isDead = false)
    {
      return this.getFieldUnits(panel.row, panel.column, original, isDead);
    }

    public BL.UnitPosition getUnitPositionById(int id)
    {
      foreach (BL.UnitPosition unitPositionById in this.unitPositions.value)
      {
        if (unitPositionById.id == id)
          return unitPositionById;
      }
      return (BL.UnitPosition) null;
    }

    public List<BL.Unit> getForceUnitList(BL.ForceID forceID)
    {
      switch (forceID)
      {
        case BL.ForceID.player:
          return this.playerUnits.value;
        case BL.ForceID.neutral:
          return this.neutralUnits.value;
        case BL.ForceID.enemy:
          return this.enemyUnits.value;
        default:
          return (List<BL.Unit>) null;
      }
    }

    public int getFieldHeight() => this.fieldMatrix.GetLength(0);

    public int getFieldWidth() => this.fieldMatrix.GetLength(1);

    public BL.Panel getFieldPanel(int row, int column)
    {
      return row < 0 || row >= this.getFieldHeight() || column < 0 || column >= this.getFieldWidth() ? (BL.Panel) null : this.fieldMatrix[row, column];
    }

    public IEnumerable<BL.Panel> getAllPanel() => ((IEnumerable) this.fieldMatrix).Cast<BL.Panel>();

    public BL.Panel getFieldPanel(BL.UnitPosition up, bool original = false)
    {
      return original ? this.getFieldPanel(up.originalRow, up.originalColumn) : this.getFieldPanel(up.row, up.column);
    }

    public bool isMoveOKPanel(
      BL.Panel panel,
      BL.Unit unit,
      bool enabledIgnoreMoveCost,
      int moveCost)
    {
      return panel != null && BattleFuncs.getMoveCost(panel, unit, enabledIgnoreMoveCost) <= moveCost;
    }

    private List<BL.UnitPosition> getFieldUnits(int row, int column, bool original = false)
    {
      List<BL.UnitPosition> fieldUnits = new List<BL.UnitPosition>();
      foreach (BL.UnitPosition unitPosition in this.unitPositions.value)
      {
        int num1 = !original ? unitPosition.row : unitPosition.originalRow;
        int num2 = !original ? unitPosition.column : unitPosition.originalColumn;
        if (unitPosition.unit.isEnable && !unitPosition.unit.isDead && num1 == row && num2 == column)
          fieldUnits.Add(unitPosition);
      }
      return fieldUnits;
    }

    public bool isMoveOK(
      BL.Panel panel,
      BL.Unit unit = null,
      bool isRebirth = false,
      bool enabledIgnoreMoveCost = false,
      int moveCost = -1)
    {
      if (unit == null)
        unit = this.unitCurrent.unit;
      if (moveCost == -1)
        moveCost = this.getUnitPosition(unit).moveCost;
      if (!this.isMoveOKPanel(panel, unit, enabledIgnoreMoveCost, moveCost))
        return false;
      if (isRebirth)
        return true;
      BL.UnitPosition fieldUnit = this.getFieldUnit(panel.row, panel.column, true);
      return fieldUnit == null || fieldUnit.unit == unit || this.getForceID(fieldUnit.unit) == this.getForceID(unit);
    }

    public bool isMoveOK(
      int row,
      int column,
      BL.Unit unit = null,
      bool isRebirth = false,
      bool enabledIgnoreMoveCost = false)
    {
      return this.isMoveOK(this.getFieldPanel(row, column), unit, isRebirth, enabledIgnoreMoveCost);
    }

    public BL.UnitPosition getUnitPosition(BL.Unit unit)
    {
      return this.unitPositions.value.Find((Predicate<BL.UnitPosition>) (up => up.unit == unit));
    }

    public void lookDirection(BL.UnitPosition s, BL.UnitPosition d)
    {
      if (s.row == d.row)
      {
        if (s.column == d.column)
          return;
        if (s.column > d.column)
          s.direction = 270f;
        else
          s.direction = 90f;
      }
      else if (s.row > d.row)
        s.direction = 180f;
      else
        s.direction = 0.0f;
    }

    public void lookDirection(BL.UnitPosition s, BL.Unit d)
    {
      this.lookDirection(s, this.getUnitPosition(d));
    }

    public void lookDirection(BL.Unit s, BL.Unit d)
    {
      this.lookDirection(this.getUnitPosition(s), this.getUnitPosition(d));
    }

    public static int fieldDistance(BL.Panel p1, BL.Panel p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(BL.UnitPosition p1, BL.UnitPosition p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(BL.UnitPosition p1, BL.Panel p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(BL.Panel p1, BL.UnitPosition p2)
    {
      return BL.fieldDistance(p1.row, p1.column, p2.row, p2.column);
    }

    public static int fieldDistance(int r1, int c1, int r2, int c2)
    {
      return Mathf.Abs(r1 - r2) + Mathf.Abs(c1 - c2);
    }

    public BL.UnitPosition fieldForceUnit(
      int row,
      int column,
      BL.ForceID[] targetForce,
      bool isAI)
    {
      BL.UnitPosition unitPosition = !isAI ? this.getFieldUnit(row, column) : this.getFieldUnitAI(row, column);
      if (unitPosition == null)
        return (BL.UnitPosition) null;
      return ((IEnumerable<BL.ForceID>) targetForce).Contains<BL.ForceID>(this.getForceID(unitPosition.unit)) ? unitPosition : (BL.UnitPosition) null;
    }

    public BL.Phase getChangePhaseToPanel(BL.UnitPosition up)
    {
      BL.Panel fieldPanel = this.getFieldPanel(up.originalRow, up.originalColumn);
      return fieldPanel != null ? fieldPanel.getChangePhaseToPanel(this.getForceID(up.unit)) : BL.Phase.none;
    }

    public int[] getReinforcementIDsToPanel(BL.UnitPosition up)
    {
      return this.getFieldPanel(up.originalRow, up.originalColumn)?.getReinforcementIDsToPanel(this.getForceID(up.unit));
    }

    public List<BL.FieldEffect> getFieldEffects(BL.FieldEffectType type)
    {
      List<BL.FieldEffect> fieldEffects = new List<BL.FieldEffect>();
      if (this.fieldEffectList == null)
        return fieldEffects;
      foreach (BL.FieldEffect fieldEffect in this.fieldEffectList.value)
      {
        if (fieldEffect.type == type)
          fieldEffects.Add(fieldEffect);
      }
      return fieldEffects;
    }

    public void initializeIntimate()
    {
      BL.Unit[] array = this.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.is_helper && !x.playerUnit.is_gesut)).ToArray<BL.Unit>();
      foreach (BL.Unit unit1 in array)
      {
        BL.Unit unit = unit1;
        this.intimate.add(this.getForceID(unit), unit, ((IEnumerable<BL.Unit>) array).Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.index != unit.index)).ToArray<BL.Unit>(), 5);
      }
    }

    public void initializeIntimatePvp()
    {
      BL.Unit[] array1 = this.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.is_helper && !x.playerUnit.is_gesut)).ToArray<BL.Unit>();
      foreach (BL.Unit unit1 in array1)
      {
        BL.Unit unit = unit1;
        this.intimate.add(this.getForceID(unit), unit, ((IEnumerable<BL.Unit>) array1).Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.index != unit.index)).ToArray<BL.Unit>(), 5);
      }
      BL.Unit[] array2 = this.enemyUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.is_helper && !x.playerUnit.is_gesut)).ToArray<BL.Unit>();
      foreach (BL.Unit unit2 in array2)
      {
        BL.Unit unit = unit2;
        this.intimate.add(this.getForceID(unit), unit, ((IEnumerable<BL.Unit>) array2).Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.index != unit.index)).ToArray<BL.Unit>(), 5);
      }
    }

    public void updateIntimateByAttack(BL.UnitPosition attackerPosition)
    {
      List<BL.UnitPosition> neighbors = BattleFuncs.getNeighbors(attackerPosition);
      this.intimate.add(this.getForceID(attackerPosition.unit), attackerPosition.unit, neighbors.Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>(), 5);
    }

    public void updateIntimateByDefense(BL.Unit deadUnit)
    {
      if (deadUnit.hp > 0)
        return;
      BL.ForceID forceId = this.getForceID(deadUnit);
      List<BL.Unit> source = forceId != BL.ForceID.player ? this.enemyUnits.value : this.playerUnits.value;
      this.intimate.add(forceId, deadUnit, source.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.index != deadUnit.index && !x.is_helper && !x.playerUnit.is_gesut)).ToArray<BL.Unit>(), 2);
    }

    public Tuple<int, int, int>[] getPlayerIntimateResult()
    {
      return this.intimate.intimateDic.Where<KeyValuePair<Tuple<BL.ForceID, int, int>, int>>((Func<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, bool>) (x => x.Key.Item1 == BL.ForceID.player)).Select<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, Tuple<int, int, int>>((Func<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, Tuple<int, int, int>>) (x => Tuple.Create<int, int, int>(x.Key.Item2, x.Key.Item3, x.Value))).ToArray<Tuple<int, int, int>>();
    }

    public Tuple<int, int, int>[] getEnemyIntimateResult()
    {
      return this.intimate.intimateDic.Where<KeyValuePair<Tuple<BL.ForceID, int, int>, int>>((Func<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, bool>) (x => x.Key.Item1 == BL.ForceID.enemy)).Select<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, Tuple<int, int, int>>((Func<KeyValuePair<Tuple<BL.ForceID, int, int>, int>, Tuple<int, int, int>>) (x => Tuple.Create<int, int, int>(x.Key.Item2, x.Key.Item3, x.Value))).ToArray<Tuple<int, int, int>>();
    }

    public void useItemWith(BL.Item item, BL.Unit unit, Action<List<BL.Unit>> f, BL env)
    {
      if (item.amount == 0)
        return;
      int level = 1 + unit.enabledSkillEffect(BattleskillEffectLogicEnum.add_supply_level).Sum<BL.SkillEffect>((Func<BL.SkillEffect, int>) (x => x.baseSkillLevel));
      List<BL.Unit> unitList = this.setSkillEffect(item.item.skill, level, new List<BL.Unit>()
      {
        unit
      }, env);
      f(unitList);
      --item.amount;
      if (item.amount != 0)
        return;
      this.itemListInBattle.value.Remove(item);
      this.itemListInBattle.commit();
    }

    public List<BL.Unit> getItemTargetUnits(BL.Item item)
    {
      List<BL.Unit> itemTargetUnits = new List<BL.Unit>();
      if (item.item.skill.target_type != BattleskillTargetType.dead_player_single)
      {
        foreach (BL.Unit unit in this.playerUnits.value)
        {
          if (unit.isEnable && !unit.isDead && !unit.skillEffects.HasEffect(item.item.skill))
            itemTargetUnits.Add(unit);
        }
      }
      else
      {
        foreach (BL.Unit unit in this.playerUnits.value)
        {
          if (unit.isEnable && unit.isDead)
            itemTargetUnits.Add(unit);
        }
      }
      return itemTargetUnits;
    }

    public void nextRandom()
    {
      ++this.randomCount;
      this.random = new XorShift(this.randomBase);
      for (int index = 0; index < this.randomCount * 10; ++index)
      {
        int num = (int) this.random.Next();
      }
    }

    private Dictionary<int, Dictionary<int, List<BL.AttackStatusCacheContainer>>> attackStatusCacheDic
    {
      get
      {
        if (this.mAttackStatusCacheDic == null)
          this.mAttackStatusCacheDic = new Dictionary<int, Dictionary<int, List<BL.AttackStatusCacheContainer>>>();
        return this.mAttackStatusCacheDic;
      }
    }

    public void attackStatusCacheGC()
    {
      if (this.mAttackStatusCacheDic == null)
        return;
      foreach (Dictionary<int, List<BL.AttackStatusCacheContainer>> dictionary in this.mAttackStatusCacheDic.Values)
      {
        foreach (List<BL.AttackStatusCacheContainer> statusCacheContainerList in dictionary.Values)
        {
          HashSet<BL.AttackStatusCacheContainer> statusCacheContainerSet = new HashSet<BL.AttackStatusCacheContainer>();
          foreach (BL.AttackStatusCacheContainer statusCacheContainer in statusCacheContainerList)
          {
            if (statusCacheContainer.checkReadCount(0))
              statusCacheContainer.resetReadCount();
            else
              statusCacheContainerSet.Add(statusCacheContainer);
          }
          foreach (BL.AttackStatusCacheContainer statusCacheContainer in statusCacheContainerSet)
            statusCacheContainerList.Remove(statusCacheContainer);
        }
      }
    }

    private bool getAttackStatusCacheDicList(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      out Dictionary<int, List<BL.AttackStatusCacheContainer>> dd)
    {
      return this.attackStatusCacheDic.TryGetValue(this.makeAttackStatusCacheKey(attack, attackPanel, defense, defensePanel), out dd);
    }

    private void addAttackStatusCacheDicList(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      int attackHp,
      bool isAttack,
      bool isHeal,
      int move_distance,
      int move_range,
      AttackStatus[] data)
    {
      int key1 = this.makeAttackStatusCacheKey(attack, attackPanel, defense, defensePanel);
      int key2 = this.makeDistanceKey(move_distance, move_range);
      List<BL.AttackStatusCacheContainer> statusCacheContainerList = (List<BL.AttackStatusCacheContainer>) null;
      Dictionary<int, List<BL.AttackStatusCacheContainer>> dictionary1;
      if (this.attackStatusCacheDic.TryGetValue(key1, out dictionary1))
      {
        if (dictionary1.TryGetValue(key2, out statusCacheContainerList))
        {
          foreach (BL.AttackStatusCacheContainer statusCacheContainer in statusCacheContainerList)
          {
            if (statusCacheContainer.checkBaseValues(isAttack, isHeal))
            {
              statusCacheContainer.setData(attack, defense, attackNeighbors, defenseNeighbors, attackHp, data);
              return;
            }
          }
        }
        if (statusCacheContainerList == null)
          dictionary1[key2] = statusCacheContainerList = new List<BL.AttackStatusCacheContainer>();
        statusCacheContainerList.Add(new BL.AttackStatusCacheContainer(attack, defense, attackNeighbors, defenseNeighbors, attackHp, isAttack, isHeal, data));
      }
      else
      {
        Dictionary<int, List<BL.AttackStatusCacheContainer>> dictionary2 = new Dictionary<int, List<BL.AttackStatusCacheContainer>>();
        (dictionary2[key2] = new List<BL.AttackStatusCacheContainer>()).Add(new BL.AttackStatusCacheContainer(attack, defense, attackNeighbors, defenseNeighbors, attackHp, isAttack, isHeal, data));
        this.mAttackStatusCacheDic[key1] = dictionary2;
      }
    }

    public bool getAttackStatusCache(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      int attackHp,
      bool isAttack,
      bool isHeal,
      int move_distance,
      int move_range,
      out AttackStatus[] ret)
    {
      Dictionary<int, List<BL.AttackStatusCacheContainer>> dd;
      if (!this.getAttackStatusCacheDicList(attack, attackPanel, defense, defensePanel, out dd))
      {
        ret = (AttackStatus[]) null;
        return false;
      }
      int key = this.makeDistanceKey(move_distance, move_range);
      List<BL.AttackStatusCacheContainer> statusCacheContainerList;
      if (dd.TryGetValue(key, out statusCacheContainerList))
      {
        foreach (BL.AttackStatusCacheContainer statusCacheContainer in statusCacheContainerList)
        {
          if (statusCacheContainer.checkBaseValues(isAttack, isHeal))
          {
            ret = statusCacheContainer.data;
            return statusCacheContainer.checkValues(attack, defense, attackNeighbors, defenseNeighbors, attackHp);
          }
        }
      }
      ret = (AttackStatus[]) null;
      return false;
    }

    public AttackStatus[] setAttackStatusCache(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      int attackHp,
      bool isAttack,
      bool isHeal,
      int move_distance,
      int move_range,
      AttackStatus[] data)
    {
      this.addAttackStatusCacheDicList(attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, attackHp, isAttack, isHeal, move_distance, move_range, data);
      return data;
    }

    private int makePanelId(BL.Panel panel) => panel.landformID;

    private int makeUnitId(BL.ISkillEffectListUnit unit)
    {
      return unit is BL.AIUnit ? (unit as BL.AIUnit).id : this.getUnitPosition(unit.originalUnit).id;
    }

    private int makeAttackStatusCacheKey(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel)
    {
      return this.makeUnitId(attack) * 100 * 200 * 200 * 100 + this.makeUnitId(defense) * 200 * 200 * 100 + this.makePanelId(attackPanel) * 200 * 100 + this.makePanelId(defensePanel) * 100 + BL.fieldDistance(attackPanel, defensePanel);
    }

    private int makeDistanceKey(int move, int range) => move * 1000 + range;

    public HashSet<BL.ISkillEffectListUnit> getCharismaTargetUnits(
      BL.ISkillEffectListUnit unit,
      int row,
      int column)
    {
      HashSet<BL.ISkillEffectListUnit> charismaTargetUnits = new HashSet<BL.ISkillEffectListUnit>();
      foreach (BL.SkillEffect enabledCharismaEffect in BattleFuncs.getEnabledCharismaEffects(unit))
      {
        BL.ForceID[] forceIds = enabledCharismaEffect.effect.GetInt("effect_target") != 0 ? (this.getForceID(unit.originalUnit) != BL.ForceID.player ? BattleFuncs.ForceIDArrayPlayer : BattleFuncs.ForceIDArrayEnemy) : (this.getForceID(unit.originalUnit) != BL.ForceID.player ? BattleFuncs.ForceIDArrayEnemy : BattleFuncs.ForceIDArrayPlayer);
        foreach (BL.UnitPosition target in BattleFuncs.getTargets(row, column, new int[2]
        {
          enabledCharismaEffect.effect.GetInt("min_range"),
          enabledCharismaEffect.effect.GetInt("max_range")
        }, forceIds, (unit is BL.AIUnit ? 1 : 0) != 0))
          charismaTargetUnits.Add(!(target is BL.AIUnit) ? (BL.ISkillEffectListUnit) target.unit : target as BL.ISkillEffectListUnit);
      }
      return charismaTargetUnits;
    }

    private Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> routeDic
    {
      get
      {
        if (this.mRouteDic == null)
          this.mRouteDic = new Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>>();
        return this.mRouteDic;
      }
    }

    private Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> routeDic_IM
    {
      get
      {
        if (this.mRouteDic_IM == null)
          this.mRouteDic_IM = new Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>>();
        return this.mRouteDic_IM;
      }
    }

    public void clearRouteCache()
    {
      this.mRouteDic = (Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>>) null;
      this.mRouteDic_IM = (Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>>) null;
    }

    public Tuple<List<BL.Panel>, int> getTargetRouteWithCache(
      BL.UnitPosition u,
      BL.Panel panel,
      BL.Panel target,
      bool im)
    {
      Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> dictionary = !im ? this.routeDic : this.routeDic_IM;
      UnitMoveType moveType = u.unit.unit.job.move_type;
      if (dictionary.ContainsKey(moveType))
      {
        if (dictionary[moveType].ContainsKey(panel.id))
        {
          if (dictionary[moveType][panel.id].ContainsKey(target.id))
            return dictionary[moveType][panel.id][target.id];
        }
        else if (dictionary[moveType].ContainsKey(target.id) && dictionary[moveType][target.id].ContainsKey(panel.id))
        {
          Tuple<List<BL.Panel>, int> tuple = dictionary[moveType][target.id][panel.id];
          return this.setRouteDic(moveType, panel.id, target.id, new Tuple<List<BL.Panel>, int>(tuple.Item1.AsEnumerable<BL.Panel>().Reverse<BL.Panel>().ToList<BL.Panel>(), tuple.Item2), im);
        }
      }
      int cost;
      Tuple<List<BL.Panel>, int> r = new Tuple<List<BL.Panel>, int>(this.fieldDistanceShortestPath(u, panel, target, im, out cost), cost);
      return this.setRouteDic(moveType, panel.id, target.id, r, im);
    }

    private Tuple<List<BL.Panel>, int> setRouteDic(
      UnitMoveType mtype,
      int id1,
      int id2,
      Tuple<List<BL.Panel>, int> r,
      bool im)
    {
      Dictionary<UnitMoveType, Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>> dictionary = !im ? this.routeDic : this.routeDic_IM;
      if (!dictionary.ContainsKey(mtype))
      {
        dictionary[mtype] = new Dictionary<int, Dictionary<int, Tuple<List<BL.Panel>, int>>>();
        dictionary[mtype][id1] = new Dictionary<int, Tuple<List<BL.Panel>, int>>();
      }
      else if (!dictionary[mtype].ContainsKey(id1))
        dictionary[mtype][id1] = new Dictionary<int, Tuple<List<BL.Panel>, int>>();
      dictionary[mtype][id1][id2] = r;
      return r;
    }

    private List<BL.Panel> fieldDistanceShortestPath(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      bool enabledIgnoreMoveCost,
      out int cost)
    {
      BattleFuncs.AsterNode[] nodes = up.asterNodeCache[!enabledIgnoreMoveCost ? 0 : 1];
      int startIdx;
      int goalIdx;
      BattleFuncs.getNodesStartAndGoal(nodes, start, goal, out startIdx, out goalIdx);
      return BattleFuncs.createRouteWithCost(up.unit, nodes, goalIdx, startIdx, out cost, enabledIgnoreMoveCost);
    }

    private Tuple<List<BL.Panel>, int> getRouteTuple(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      HashSet<BL.Panel> movepanels,
      HashSet<BL.Panel> completePanels = null,
      bool isCache = true)
    {
      BL.Panel panel = (BL.Panel) null;
      float num1 = 1E+17f;
      if (completePanels == null)
        completePanels = movepanels;
      if (!completePanels.Contains(goal))
      {
        foreach (BL.Panel completePanel in completePanels)
        {
          if (completePanel == goal)
            panel = goal;
          int num2 = completePanel.column - goal.column;
          int num3 = completePanel.row - goal.row;
          int num4 = num2 * num2 + num3 * num3;
          if ((double) num4 < (double) num1)
          {
            panel = completePanel;
            num1 = (float) num4;
          }
        }
        goal = panel;
      }
      bool flag = up.unit.HasEnabledSkillEffect(BattleskillEffectLogicEnum.ignore_move_cost);
      if (isCache)
        return this.getTargetRouteWithCache(up, start, goal, flag);
      int startIdx;
      int goalIdx;
      BattleFuncs.AsterNode[] nodes = BattleFuncs.createNodes((IEnumerable<BL.Panel>) movepanels, up.unit, start, goal, out startIdx, out goalIdx, flag);
      int cost;
      return new Tuple<List<BL.Panel>, int>(BattleFuncs.createRouteWithCost(up.unit, nodes, goalIdx, startIdx, out cost, flag), cost);
    }

    public List<BL.Panel> getRouteWithCache(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      HashSet<BL.Panel> movepanels,
      HashSet<BL.Panel> completePanels = null)
    {
      return this.getRouteTuple(up, start, goal, movepanels, completePanels).Item1;
    }

    public int getRouteCostWithCache(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      HashSet<BL.Panel> movepanels,
      HashSet<BL.Panel> completePanels = null)
    {
      return this.getRouteTuple(up, start, goal, movepanels, completePanels).Item2;
    }

    public List<BL.Panel> getRouteNonCache(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      HashSet<BL.Panel> movepanels,
      HashSet<BL.Panel> completePanels = null)
    {
      return this.getRouteTuple(up, start, goal, movepanels, completePanels, false).Item1;
    }

    public int getRouteCostNonCache(
      BL.UnitPosition up,
      BL.Panel start,
      BL.Panel goal,
      HashSet<BL.Panel> movepanels,
      HashSet<BL.Panel> completePanels = null)
    {
      return this.getRouteTuple(up, start, goal, movepanels, completePanels, false).Item2;
    }

    public void useMagicBulletWith(
      BL.MagicBullet mb,
      int attack,
      BL.Unit unit,
      List<BL.Unit> targets,
      Action<BL.Unit, int> f,
      BL env)
    {
      this.setSkillEffect(mb.skill, 1, targets, env);
      int healHpTotal = 0;
      foreach (BL.Unit target in targets)
      {
        foreach (BattleskillEffect effect in mb.skill.Effects)
        {
          if (effect.effect_logic.Enum == BattleskillEffectLogicEnum.power_heal)
          {
            int hp = target.hp;
            target.hp += attack;
            healHpTotal += target.hp - hp;
          }
        }
      }
      unit.hp -= mb.cost;
      int hp1 = unit.hp;
      if (BattleFuncs.applyServantsJoy((BL.ISkillEffectListUnit) unit, healHpTotal))
        f(unit, hp1);
      else
        f((BL.Unit) null, 0);
      this.getUnitPosition(unit).actionActionUnit(this);
    }

    private List<BL.UnitPosition> getExecuteSkillEffectsTargets(
      BL.UnitPosition up,
      int[] range,
      BL.ForceID forceId)
    {
      if (range[1] != 999)
        return BattleFuncs.getTargets(up.row, up.column, range, BattleFuncs.getForceIDArray(forceId));
      BL.ClassValue<List<BL.UnitPosition>> actionUnits = this.getActionUnits(up);
      return actionUnits != null ? actionUnits.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (u => range[0] == 0 || u != up)).ToList<BL.UnitPosition>() : new List<BL.UnitPosition>();
    }

    public List<BL.ExecuteSkillEffectResult> executeSkillEffects(BL.UnitPosition up)
    {
      List<BL.ExecuteSkillEffectResult> skillEffectResultList = new List<BL.ExecuteSkillEffectResult>();
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.self_recovery))
      {
        if (BattleFuncs.getTargets(up.row, up.column, new int[2]
        {
          1,
          skillEffect.effect.GetInt("range")
        }, BattleFuncs.getForceIDArray(this.getForceID(up.unit))).Count == 0)
        {
          BL.ExecuteSkillEffectResult skillEffectResult = new BL.ExecuteSkillEffectResult()
          {
            skill = skillEffect.baseSkill
          };
          float num = skillEffect.effect.GetFloat("percentage") + (float) (skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio")) / 100f;
          skillEffectResult.target_prev_hps.Add(up.unit.hp);
          up.unit.hp += Mathf.CeilToInt((float) up.unit.parameter.Hp * num);
          skillEffectResult.targets.Add(up);
          skillEffectResult.target_hps.Add(up.unit.hp);
          skillEffectResultList.Add(skillEffectResult);
        }
      }
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.range_recovery))
      {
        List<BL.UnitPosition> targets = BattleFuncs.getTargets(up.row, up.column, new int[2]
        {
          1,
          skillEffect.effect.GetInt("range")
        }, BattleFuncs.getForceIDArray(this.getForceID(up.unit)));
        BL.ExecuteSkillEffectResult skillEffectResult = new BL.ExecuteSkillEffectResult()
        {
          skill = skillEffect.baseSkill
        };
        foreach (BL.UnitPosition unitPosition in targets)
        {
          int num = skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
          skillEffectResult.target_prev_hps.Add(unitPosition.unit.hp);
          unitPosition.unit.hp += num;
          skillEffectResult.targets.Add(unitPosition);
          skillEffectResult.target_hps.Add(unitPosition.unit.hp);
        }
        skillEffectResultList.Add(skillEffectResult);
      }
      Dictionary<BattleskillSkill, BL.ExecuteSkillEffectResult> dictionary = new Dictionary<BattleskillSkill, BL.ExecuteSkillEffectResult>();
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.ratio_recovery))
      {
        if (!dictionary.ContainsKey(skillEffect.baseSkill))
          dictionary[skillEffect.baseSkill] = new BL.ExecuteSkillEffectResult()
          {
            skill = skillEffect.baseSkill
          };
        List<BL.UnitPosition> skillEffectsTargets = this.getExecuteSkillEffectsTargets(up, new int[2]
        {
          skillEffect.effect.GetInt("min_range"),
          skillEffect.effect.GetInt("max_range")
        }, this.getForceID(up.unit));
        BL.ExecuteSkillEffectResult skillEffectResult = dictionary[skillEffect.baseSkill];
        foreach (BL.UnitPosition unitPosition in skillEffectsTargets)
        {
          if ((skillEffect.effect.GetInt("job_id") == 0 || skillEffect.effect.GetInt("job_id") == unitPosition.unit.job.ID) && (skillEffect.effect.GetInt("gear_kind_id") == 0 || skillEffect.effect.GetInt("gear_kind_id") == unitPosition.unit.unit.kind.ID) && (skillEffect.effect.GetInt("element") == 0 || (CommonElement) skillEffect.effect.GetInt("element") == unitPosition.unit.playerUnit.GetElement()))
          {
            float num = skillEffect.effect.GetFloat("percentage") + (float) ((double) skillEffect.baseSkillLevel * (double) skillEffect.effect.GetFloat("skill_ratio") / 100.0);
            int index = skillEffectResult.targets.IndexOf(unitPosition);
            if (index == -1)
            {
              skillEffectResult.target_prev_hps.Add(unitPosition.unit.hp);
              unitPosition.unit.hp += (int) Math.Ceiling((Decimal) ((float) unitPosition.unit.parameter.Hp * num));
              skillEffectResult.targets.Add(unitPosition);
              skillEffectResult.target_hps.Add(unitPosition.unit.hp);
            }
            else
            {
              unitPosition.unit.hp += (int) Math.Ceiling((Decimal) ((float) unitPosition.unit.parameter.Hp * num));
              skillEffectResult.target_hps[index] = unitPosition.unit.hp;
            }
          }
        }
      }
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.fix_recovery))
      {
        if (!dictionary.ContainsKey(skillEffect.baseSkill))
          dictionary[skillEffect.baseSkill] = new BL.ExecuteSkillEffectResult()
          {
            skill = skillEffect.baseSkill
          };
        List<BL.UnitPosition> skillEffectsTargets = this.getExecuteSkillEffectsTargets(up, new int[2]
        {
          skillEffect.effect.GetInt("min_range"),
          skillEffect.effect.GetInt("max_range")
        }, this.getForceID(up.unit));
        BL.ExecuteSkillEffectResult skillEffectResult = dictionary[skillEffect.baseSkill];
        foreach (BL.UnitPosition unitPosition in skillEffectsTargets)
        {
          if ((skillEffect.effect.GetInt("job_id") == 0 || skillEffect.effect.GetInt("job_id") == unitPosition.unit.job.ID) && (skillEffect.effect.GetInt("gear_kind_id") == 0 || skillEffect.effect.GetInt("gear_kind_id") == unitPosition.unit.unit.kind.ID) && (skillEffect.effect.GetInt("element") == 0 || (CommonElement) skillEffect.effect.GetInt("element") == unitPosition.unit.playerUnit.GetElement()))
          {
            int num = skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
            int index = skillEffectResult.targets.IndexOf(unitPosition);
            if (index == -1)
            {
              skillEffectResult.target_prev_hps.Add(unitPosition.unit.hp);
              unitPosition.unit.hp += num;
              skillEffectResult.targets.Add(unitPosition);
              skillEffectResult.target_hps.Add(unitPosition.unit.hp);
            }
            else
            {
              unitPosition.unit.hp += num;
              skillEffectResult.target_hps[index] = unitPosition.unit.hp;
            }
          }
        }
      }
      foreach (BattleskillSkill key in dictionary.Keys)
        skillEffectResultList.Add(dictionary[key]);
      return skillEffectResultList;
    }

    public List<BL.ExecuteSkillEffectResult> completedExecuteSkillEffects(BL.UnitPosition up)
    {
      List<BL.ExecuteSkillEffectResult> skillEffectResultList = new List<BL.ExecuteSkillEffectResult>();
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.fix_poison).ToArray<BL.SkillEffect>())
      {
        BL.ExecuteSkillEffectResult skillEffectResult = new BL.ExecuteSkillEffectResult()
        {
          skill = skillEffect.baseSkill
        };
        int num = skillEffect.effect.GetInt("value");
        skillEffectResult.target_prev_hps.Add(up.unit.hp);
        up.unit.hp -= num;
        skillEffectResult.targets.Add(up);
        skillEffectResult.target_hps.Add(up.unit.hp);
        skillEffectResultList.Add(skillEffectResult);
      }
      foreach (BL.SkillEffect skillEffect in up.unit.skillEffects.Where(BattleskillEffectLogicEnum.ratio_poison).ToArray<BL.SkillEffect>())
      {
        BL.ExecuteSkillEffectResult skillEffectResult = new BL.ExecuteSkillEffectResult()
        {
          skill = skillEffect.baseSkill
        };
        int num = Mathf.CeilToInt((float) up.unit.parameter.Hp * skillEffect.effect.GetFloat("percentage"));
        skillEffectResult.target_prev_hps.Add(up.unit.hp);
        up.unit.hp -= num;
        skillEffectResult.targets.Add(up);
        skillEffectResult.target_hps.Add(up.unit.hp);
        skillEffectResultList.Add(skillEffectResult);
      }
      if (up.unit.skillEffects.AilmentExecuted())
        up.unit.commit();
      return skillEffectResultList;
    }

    public List<BL.Unit> setSkillEffect(
      BattleskillSkill skill,
      int level,
      List<BL.Unit> targets,
      BL env)
    {
      HashSet<BL.Unit> source = new HashSet<BL.Unit>();
      foreach (BL.Unit target in targets)
      {
        BL.UnitPosition unitPosition = this.getUnitPosition(target);
        int moveCost = unitPosition.moveCost;
        bool flag1 = target.HasEnabledSkillEffect(BattleskillEffectLogicEnum.ignore_move_cost);
        bool flag2 = target.HasEnabledSkillEffect(BattleskillEffectLogicEnum.slip_thru);
        bool isDontMove = target.IsDontMove;
        foreach (BattleskillEffect effect1 in skill.Effects)
        {
          if (effect1.effect_logic.Enum != BattleskillEffectLogicEnum.reduct_release_skill_turn && effect1.effect_logic.Enum != BattleskillEffectLogicEnum.recovery_command_skill_use)
            source.Add(target);
          if (effect1.effect_logic.HasTag(BattleskillEffectTag.immediately))
          {
            switch (effect1.effect_logic.Enum)
            {
              case BattleskillEffectLogicEnum.fix_heal:
                target.hp += effect1.GetInt("value");
                continue;
              case BattleskillEffectLogicEnum.ratio_heal:
                target.hp += (int) ((double) target.parameter.Hp * (double) effect1.GetFloat("percentage"));
                continue;
              case BattleskillEffectLogicEnum.power_heal:
                continue;
              case BattleskillEffectLogicEnum.remove_skilleffect:
                target.skillEffects.RemoveEffect(effect1.GetInt("logic_id"));
                target.commit();
                continue;
              case BattleskillEffectLogicEnum.fix_lv_heal:
                target.hp += effect1.GetInt("value") + level * effect1.GetInt("skill_ratio");
                continue;
              case BattleskillEffectLogicEnum.ratio_lv_heal:
                target.hp += (int) ((double) target.parameter.Hp * ((double) effect1.GetFloat("percentage") + (double) level * (double) effect1.GetFloat("skill_ratio")));
                continue;
              case BattleskillEffectLogicEnum.invest_skilleffect_im:
                int num1 = effect1.GetInt("skill_id");
                if (num1 != 0 && MasterData.BattleskillSkill.ContainsKey(num1) && MasterData.BattleskillSkill[num1].skill_type == BattleskillSkillType.ailment)
                {
                  BL.Skill[] skillArray = BattleFuncs.ailmentInvest(num1, (BL.ISkillEffectListUnit) target);
                  if (skillArray != null)
                  {
                    foreach (BL.Skill skill1 in skillArray)
                    {
                      foreach (BattleskillEffect effect2 in skill1.skill.Effects)
                        target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect2, skill1.skill, 1));
                    }
                    target.commit();
                    continue;
                  }
                  continue;
                }
                continue;
              case BattleskillEffectLogicEnum.reduct_release_skill_turn:
                using (List<BL.UnitPosition>.Enumerator enumerator = this.getExecuteSkillEffectsTargets(unitPosition, new int[2]
                {
                  effect1.GetInt("min_range"),
                  effect1.GetInt("max_range")
                }, this.getForceID(unitPosition.unit)).GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    BL.Unit unit = enumerator.Current.unit;
                    if (effect1.GetInt("element") == 0 || (CommonElement) effect1.GetInt("element") == unit.playerUnit.GetElement())
                    {
                      if (unit.hasOugi)
                      {
                        unit.ougi.useTurn -= effect1.GetInt("value");
                        int num2 = this.phaseState.absoluteTurnCount + unit.ougi.skill.charge_turn - (unit.ougi.level - 1);
                        if (unit.ougi.useTurn > num2)
                          unit.ougi.useTurn = num2;
                      }
                      source.Add(unit);
                    }
                  }
                  continue;
                }
              case BattleskillEffectLogicEnum.recovery_command_skill_use:
                using (List<BL.UnitPosition>.Enumerator enumerator = this.getExecuteSkillEffectsTargets(unitPosition, new int[2]
                {
                  effect1.GetInt("min_range"),
                  effect1.GetInt("max_range")
                }, this.getForceID(unitPosition.unit)).GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    BL.Unit unit = enumerator.Current.unit;
                    if (effect1.GetInt("element") == 0 || (CommonElement) effect1.GetInt("element") == unit.playerUnit.GetElement())
                    {
                      int num3 = effect1.GetInt("value");
                      foreach (BL.Skill skill2 in unit.skills)
                      {
                        if (skill2.remain.HasValue)
                        {
                          BL.Skill skill3 = skill2;
                          int? remain1 = skill3.remain;
                          skill3.remain = !remain1.HasValue ? new int?() : new int?(remain1.Value + num3);
                          int num4 = skill2.skill.use_count + (skill2.level - 1);
                          int? remain2 = skill2.remain;
                          if ((!remain2.HasValue ? 0 : (remain2.Value > num4 ? 1 : 0)) != 0)
                          {
                            skill2.remain = new int?(num4);
                          }
                          else
                          {
                            int? remain3 = skill2.remain;
                            if ((!remain3.HasValue ? 0 : (remain3.Value < 0 ? 1 : 0)) != 0)
                              skill2.remain = new int?(0);
                          }
                        }
                      }
                      source.Add(unit);
                    }
                  }
                  continue;
                }
              case BattleskillEffectLogicEnum.fix_rebirth:
                target.hp += effect1.GetInt("value") + level * effect1.GetInt("skill_ratio");
                if (target.isDead)
                {
                  target.rebirth(env, false, effect1.GetInt("is_reset_completed") != 0);
                  continue;
                }
                continue;
              case BattleskillEffectLogicEnum.ratio_rebirth:
                target.hp += (int) ((double) target.parameter.Hp * ((double) effect1.GetFloat("percentage") + (double) level * (double) effect1.GetFloat("skill_ratio")));
                if (target.isDead)
                {
                  target.rebirth(env, false, effect1.GetInt("is_reset_completed") != 0);
                  continue;
                }
                continue;
              default:
                Debug.LogError((object) ("unexpected effect_logic: " + (object) effect1.effect_logic.ID));
                continue;
            }
          }
          else
          {
            target.commit();
            target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect1, skill, level));
          }
        }
        if (unitPosition.moveCost != moveCost || isDontMove != target.IsDontMove || flag1 != target.HasEnabledSkillEffect(BattleskillEffectLogicEnum.ignore_move_cost) || flag2 != target.HasEnabledSkillEffect(BattleskillEffectLogicEnum.slip_thru))
          this.getUnitPosition(target).clearMovePanelCache();
      }
      return source.ToList<BL.Unit>();
    }

    public void useSkillWith(
      BL.Unit unit,
      BL.Skill skill,
      List<BL.Unit> targets,
      Action<List<BL.Unit>, BL.Unit, int> f,
      BL env)
    {
      List<BL.Unit> unitList = this.setSkillEffect(skill.skill, skill.level, targets, env);
      skill.useTurn = this.phaseState.absoluteTurnCount + skill.skill.charge_turn - (skill.level - 1);
      if (((IEnumerable<BattleskillEffect>) skill.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_rebirth || x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_rebirth)))
      {
        int hp = unit.hp;
        unit.hp -= skill.getHpCost(unit);
        f(unitList, unit, hp);
      }
      else
        f(unitList, (BL.Unit) null, 0);
      if (skill.remain.HasValue)
      {
        int? remain = skill.remain;
        if (remain.HasValue)
          skill.remain = new int?(remain.Value - 1);
      }
      this.getUnitPosition(unit).actionActionUnit(this);
    }

    public List<BL.Skill> getFieldSkills(BL.Unit unit)
    {
      List<BL.Skill> fieldSkills = new List<BL.Skill>();
      if (unit == null)
        return fieldSkills;
      foreach (BL.Skill skill in unit.skills)
      {
        if (skill.isCommand)
          fieldSkills.Add(skill);
      }
      return fieldSkills;
    }

    public List<BL.Unit> getSkillTargetUnits(
      BL.Unit unit,
      int row,
      int column,
      BL.Skill skill,
      bool isAI = false)
    {
      List<BL.Unit> skillTargetUnits = new List<BL.Unit>();
      if (skill.targetType == BattleskillTargetType.myself)
      {
        skillTargetUnits.Add(unit);
      }
      else
      {
        List<BL.UnitPosition> targets;
        if (skill.isOwn)
        {
          bool flag = skill.targetType == BattleskillTargetType.dead_player_single;
          targets = BattleFuncs.getTargets(row, column, new int[2]
          {
            skill.skill.min_range,
            skill.skill.max_range
          }, BattleFuncs.getForceIDArray(this.getForceID(unit)), (isAI ? 1 : 0) != 0, isDead: (flag ? 1 : 0) != 0);
        }
        else
          targets = BattleFuncs.getTargets(row, column, new int[2]
          {
            skill.skill.min_range,
            skill.skill.max_range
          }, this.getTargetForce(unit), (isAI ? 1 : 0) != 0);
        foreach (BL.UnitPosition unitPosition in targets)
          skillTargetUnits.Add(unitPosition.unit);
      }
      return skillTargetUnits;
    }

    public List<BL.Unit> getSkillTargetUnits(BL.UnitPosition up, BL.Skill skill)
    {
      return this.getSkillTargetUnits(up.unit, up.row, up.column, skill);
    }

    public BL.ClassValue<List<BL.UnitPosition>> getActionUnitsList(BL.Phase state)
    {
      switch (state)
      {
        case BL.Phase.player:
          return this.playerActionUnits;
        case BL.Phase.neutral:
          return this.neutralActionUnits;
        case BL.Phase.enemy:
          return this.enemyActionUnits;
        default:
          return (BL.ClassValue<List<BL.UnitPosition>>) null;
      }
    }

    public BL.ClassValue<List<BL.UnitPosition>> currentActionUnitsList()
    {
      return this.getActionUnitsList(this.phaseState.state);
    }

    public void resetActionList(BL.ForceID forceId)
    {
      BL.ClassValue<List<BL.Unit>> classValue1;
      BL.ClassValue<List<BL.UnitPosition>> classValue2;
      switch (forceId)
      {
        case BL.ForceID.player:
          classValue1 = this.playerUnits;
          classValue2 = this.playerActionUnits;
          break;
        case BL.ForceID.neutral:
          classValue1 = this.neutralUnits;
          classValue2 = this.neutralActionUnits;
          break;
        case BL.ForceID.enemy:
          classValue1 = this.enemyUnits;
          classValue2 = this.enemyActionUnits;
          break;
        default:
          return;
      }
      List<BL.UnitPosition> unitPositionList = new List<BL.UnitPosition>();
      foreach (BL.Unit unit in classValue1.value)
      {
        if (unit.isEnable && !unit.isDead)
        {
          BL.UnitPosition unitPosition = this.getUnitPosition(unit);
          unitPosition.resetOriginalPosition();
          unitPositionList.Add(unitPosition);
        }
      }
      classValue2.value = unitPositionList;
      this.completedActionUnits.value = new List<BL.UnitPosition>();
    }

    public BL.ClassValue<List<BL.UnitPosition>> getActionUnits(BL.ForceID forceId)
    {
      switch (forceId)
      {
        case BL.ForceID.player:
          return this.playerActionUnits;
        case BL.ForceID.neutral:
          return this.neutralActionUnits;
        case BL.ForceID.enemy:
          return this.enemyActionUnits;
        default:
          return (BL.ClassValue<List<BL.UnitPosition>>) null;
      }
    }

    public bool isCompleted(BL.Unit unit) => unit.isDead || this.getUnitPosition(unit).isCompleted;

    public BL.ClassValue<List<BL.UnitPosition>> getActionUnits(BL.UnitPosition up)
    {
      if (this.playerActionUnits.value.Contains(up))
        return this.playerActionUnits;
      if (this.neutralActionUnits.value.Contains(up))
        return this.neutralActionUnits;
      return this.enemyActionUnits.value.Contains(up) ? this.enemyActionUnits : (BL.ClassValue<List<BL.UnitPosition>>) null;
    }

    public bool currentPhaseUnitp(BL.Unit unit)
    {
      BL.ClassValue<List<BL.Unit>> classValue = (BL.ClassValue<List<BL.Unit>>) null;
      switch (this.phaseState.state)
      {
        case BL.Phase.player:
          classValue = this.playerUnits;
          break;
        case BL.Phase.neutral:
          classValue = this.neutralUnits;
          break;
        case BL.Phase.enemy:
          classValue = this.enemyUnits;
          break;
        case BL.Phase.pvp_disposition:
          classValue = this.playerUnits;
          break;
      }
      return classValue != null && classValue.value.Contains(unit);
    }

    public bool currentPhaseUnitp(BL.UnitPosition up) => this.currentPhaseUnitp(up.unit);

    public int getActionUnitsIndexOf(BL.UnitPosition up, ref BL.ForceID forceId)
    {
      if (up.unit == null)
        return -1;
      if (forceId == BL.ForceID.none)
        forceId = this.getForceID(up.unit);
      BL.ClassValue<List<BL.UnitPosition>> classValue;
      switch (forceId)
      {
        case BL.ForceID.player:
          classValue = this.playerActionUnits;
          break;
        case BL.ForceID.neutral:
          classValue = this.neutralActionUnits;
          break;
        case BL.ForceID.enemy:
          classValue = this.enemyActionUnits;
          break;
        default:
          return -1;
      }
      return classValue.value.IndexOf(up);
    }

    public int getActionUnitsIndexOf(BL.Unit unit, ref BL.ForceID forceId)
    {
      return unit == null ? -1 : this.getActionUnitsIndexOf(this.getUnitPosition(unit), ref forceId);
    }

    public bool allDeadUnitsp(BL.ForceID forceId)
    {
      BL.ClassValue<List<BL.Unit>> classValue;
      switch (forceId)
      {
        case BL.ForceID.player:
          classValue = this.playerUnits;
          break;
        case BL.ForceID.neutral:
          classValue = this.neutralUnits;
          break;
        case BL.ForceID.enemy:
          classValue = this.enemyUnits;
          break;
        default:
          return false;
      }
      foreach (BL.Unit unit in classValue.value)
      {
        if (unit.isSpawned && !unit.isDead)
          return false;
      }
      return true;
    }

    public BL.ForceID[] getTargetForce(BL.Unit unit)
    {
      if (unit.targetForce != null)
        return unit.targetForce;
      switch (this.getForceID(unit))
      {
        case BL.ForceID.player:
          unit.targetForce = BattleFuncs.ForceIDArrayPlayerTarget;
          break;
        case BL.ForceID.neutral:
          unit.targetForce = BattleFuncs.ForceIDArrayNeutralTarget;
          break;
        case BL.ForceID.enemy:
          unit.targetForce = BattleFuncs.ForceIDArrayEnemyTarget;
          break;
        default:
          return (BL.ForceID[]) null;
      }
      return unit.targetForce;
    }

    public BL.Story getStory(BL.StoryType type)
    {
      foreach (BL.Story story in this.storyList.value)
      {
        if (story.type == type)
          return story;
      }
      return (BL.Story) null;
    }

    public BL.Story getStoryStart() => this.getStory(BL.StoryType.battle_start);

    public BL.Story getFirstTurnStart() => this.getStory(BL.StoryType.first_turn_start);

    public BL.Story getStoryWin() => this.getStory(BL.StoryType.battle_win);

    public BL.Story getStorySpawn(BL.Unit unit)
    {
      foreach (BL.Story storySpawn in this.storyList.value)
      {
        if (storySpawn.type == BL.StoryType.spawn_unit && storySpawn.datas.Length > 0 && storySpawn.datas[0] is int && (int) storySpawn.datas[0] == unit.unit.ID)
          return storySpawn;
      }
      return (BL.Story) null;
    }

    public BL.Story getStoryUnitForUnit(BL.Unit from, BL.Unit to)
    {
      foreach (BL.Story storyUnitForUnit in this.storyList.value)
      {
        if (storyUnitForUnit.type == BL.StoryType.unit_for_unit && storyUnitForUnit.datas.Length > 0 && storyUnitForUnit.datas[0] is int)
        {
          int data = (int) storyUnitForUnit.datas[0];
          if (data == from.unit.ID && data == to.unit.ID)
            return storyUnitForUnit;
        }
      }
      return (BL.Story) null;
    }

    public List<BL.Story> getStoryUnitForAll(BL.Unit from)
    {
      List<BL.Story> storyUnitForAll = new List<BL.Story>();
      foreach (BL.Story story in this.storyList.value)
      {
        if (story.type == BL.StoryType.unit_for_unit && story.datas.Length > 0 && story.datas[0] is int && (int) story.datas[0] == from.unit.ID)
          storyUnitForAll.Add(story);
      }
      return storyUnitForAll;
    }

    public List<BL.Story> getDuelStorys(BL.Unit attack, BL.Unit defense)
    {
      List<BL.Story> duelStorys = new List<BL.Story>();
      foreach (BL.Story story in this.storyList.value)
      {
        if ((story.type == BL.StoryType.duel_start || story.type == BL.StoryType.duel_unit_dead) && !story.isRead && story.datas.Length > 1 && story.datas[0] is int && story.datas[1] is int)
        {
          int data1 = (int) story.datas[0];
          int data2 = (int) story.datas[1];
          bool flag = false;
          switch (data1)
          {
            case 0:
              if (data2 == attack.playerUnit.id && attack.playerUnit.is_enemy || data2 == defense.playerUnit.id && defense.playerUnit.is_enemy)
              {
                flag = true;
                break;
              }
              break;
            case 1:
              if (data2 == attack.playerUnit.id && attack.playerUnit.is_enemy)
              {
                flag = true;
                break;
              }
              break;
            case 2:
              if (data2 == defense.playerUnit.id && defense.playerUnit.is_enemy)
              {
                flag = true;
                break;
              }
              break;
          }
          if (flag)
            duelStorys.Add(story);
        }
      }
      return duelStorys;
    }

    public List<BL.Story> getStoryOffense(int turn)
    {
      return this.findStoryTurnStart(BL.StoryPhase.offense, turn);
    }

    public List<BL.Story> getStoryDefense(int turn)
    {
      return this.findStoryTurnStart(BL.StoryPhase.defense, turn);
    }

    private List<BL.Story> findStoryTurnStart(BL.StoryPhase sphase, int turn)
    {
      List<BL.Story> storyTurnStart = new List<BL.Story>();
      foreach (BL.Story story in this.storyList.value)
      {
        if (!story.isRead && story.type == BL.StoryType.turn_start && (BL.StoryPhase) story.datas[0] == sphase && (int) story.datas[1] == turn)
          storyTurnStart.Add(story);
      }
      return storyTurnStart;
    }

    public List<BL.Story> getStoryOffenseInArea(int row, int column)
    {
      return this.findStoryInArea(BL.StoryPhase.offense, row, column);
    }

    public List<BL.Story> getStoryDefenseInArea(int row, int column)
    {
      return this.findStoryInArea(BL.StoryPhase.defense, row, column);
    }

    private List<BL.Story> findStoryInArea(BL.StoryPhase sphase, int row, int column)
    {
      List<BL.Story> storyInArea = new List<BL.Story>();
      foreach (BL.Story story in this.storyList.value)
      {
        if (!story.isRead && story.type == BL.StoryType.unit_in_area && (BL.StoryPhase) story.datas[0] == sphase)
        {
          int num1 = row - (int) story.datas[1];
          int num2 = column - (int) story.datas[2];
          if (0 <= num1 && num1 < (int) story.datas[3] && 0 <= num2 && num2 < (int) story.datas[4])
            storyInArea.Add(story);
        }
      }
      return storyInArea;
    }

    public List<BL.Story> getStoryDefeat(int unitId, bool swRead = true)
    {
      List<BL.Story> sl = new List<BL.Story>();
      this.storyList.value.ForEach((Action<BL.Story>) (s =>
      {
        if (s.isRead || s.type != BL.StoryType.defeat_player || (int) s.datas[0] != unitId)
          return;
        if (swRead)
          s.isRead = true;
        sl.Add(s);
      }));
      return sl;
    }

    public void setCurrentUnitWith(BL.Unit unit, Action<BL.UnitPosition> f)
    {
      this.unitCurrent.setCurrentWith(unit, this, f);
    }

    public BL.ForceID getForceID(BL.Unit unit)
    {
      if (unit == null)
        return BL.ForceID.none;
      if (this.playerUnits.value.Contains(unit))
        return BL.ForceID.player;
      if (this.enemyUnits.value.Contains(unit))
        return BL.ForceID.enemy;
      return this.neutralUnits.value.Contains(unit) ? BL.ForceID.neutral : BL.ForceID.none;
    }

    public BL.ClassValue<List<BL.Unit>> forceUnits(BL.ForceID forceId)
    {
      switch (forceId)
      {
        case BL.ForceID.player:
          return this.playerUnits;
        case BL.ForceID.neutral:
          return this.neutralUnits;
        case BL.ForceID.enemy:
          return this.enemyUnits;
        default:
          return (BL.ClassValue<List<BL.Unit>>) null;
      }
    }

    public void updateUnitBattleStatus(DuelResult duelResult, BL.Unit attack, BL.Unit defense)
    {
      if (duelResult.isPlayerAttack)
        this.updateIntimateByAttack(this.getUnitPosition(attack));
      if (attack.hp <= 0)
      {
        ++defense.killCount;
        defense.skillEffects.AddKillCount(1);
        attack.killedBy = defense;
        int oDamage = 0;
        ((IEnumerable<BL.DuelTurn>) duelResult.turns).ForEach<BL.DuelTurn>((Action<BL.DuelTurn>) (x =>
        {
          if (x.isAtackker)
            return;
          oDamage += x.dispDamage - x.damage;
        }));
        attack.overkillDamage = oDamage;
        if (attack.playerUnit.is_gesut)
          attack.overkillDamage = 0;
      }
      if (defense.hp <= 0)
      {
        ++attack.killCount;
        attack.skillEffects.AddKillCount(1);
        defense.killedBy = attack;
        int oDamage = 0;
        ((IEnumerable<BL.DuelTurn>) duelResult.turns).ForEach<BL.DuelTurn>((Action<BL.DuelTurn>) (x =>
        {
          if (!x.isAtackker)
            return;
          oDamage += x.dispDamage - x.damage;
        }));
        defense.overkillDamage = oDamage;
        if (defense.playerUnit.is_gesut)
          defense.overkillDamage = 0;
      }
      if (duelResult.attackFromDamage > 0)
      {
        ++defense.attackCount;
        defense.attackDamage += duelResult.attackFromDamage;
        attack.receivedDamage += duelResult.attackFromDamage;
      }
      if (duelResult.defenseFromDamage > 0)
      {
        ++attack.attackCount;
        attack.attackDamage += duelResult.defenseFromDamage;
        defense.receivedDamage += duelResult.defenseFromDamage;
      }
      this.updateIntimateByDefense(!duelResult.isPlayerAttack ? defense : attack);
    }

    public bool checkDeadCount(int id, int count, bool isAI)
    {
      return count == 0 ? this.enemyUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x =>
      {
        if (id == 0)
          return true;
        return id != 0 && x.playerUnit.group_id.HasValue && x.playerUnit.group_id.Value == id;
      })).All<BL.Unit>((Func<BL.Unit, bool>) (x =>
      {
        if (x.isDead || x.hp == 0)
          return true;
        return isAI && this.aiDeads.value.Any<BL.AIUnit>((Func<BL.AIUnit, bool>) (y => y.unit == x));
      })) : count <= this.enemyUnits.value.Count<BL.Unit>((Func<BL.Unit, bool>) (x =>
      {
        if (id != 0 && (id == 0 || !x.playerUnit.group_id.HasValue || x.playerUnit.group_id.Value != id))
          return false;
        if (x.isDead || x.hp == 0)
          return true;
        return isAI && this.aiDeads.value.Any<BL.AIUnit>((Func<BL.AIUnit, bool>) (y => y.unit == x));
      }));
    }

    public bool isReinforceUnitForSmash(PlayerUnit pu, bool isAI = false)
    {
      return pu.reinforcement != null && pu.reinforcement.reinforcement_logic.Enum == BattleReinforcementLogicEnum.smash && this.checkDeadCount(pu.reinforcement.arg1_value, pu.reinforcement.arg2_value, isAI);
    }

    public List<BL.Panel> dangerAria => this.mDangerAria;

    public void hideDangerAria()
    {
      if (this.mDangerAria == null)
        return;
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.mDangerAria, BL.PanelAttribute.danger, true);
    }

    public void viewDangerAria()
    {
      if (this.mDangerAria == null)
        this.createDangerAria();
      else
        BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.mDangerAria, BL.PanelAttribute.danger, false);
    }

    public void createDangerAria()
    {
      this.hideDangerAria();
      if (!this.isViewDengerArea.value)
        return;
      this.mDangerAria = BattleFuncs.createDangerPanels(this.playerTarget).ToList<BL.Panel>();
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.mDangerAria, BL.PanelAttribute.danger, false);
    }

    public static BL.BattleModified<T> Observe<T>(T v) where T : BL.ModelBase
    {
      return new BL.BattleModified<T>(v);
    }

    public enum AIType
    {
      normal,
    }

    public class AIUnitNetwork
    {
      public int? unitPosition;
      public int hp;
      public int row;
      public int column;
      public BL.AIType type;
      public List<ActionResultNetwork> actionResults;
    }

    [Serializable]
    public class AIUnit : BL.UnitPosition, BL.ISkillEffectListUnit
    {
      [SerializeField]
      private BL.UnitPosition mUnitPosition;
      [SerializeField]
      private int mHp;
      [SerializeField]
      private BL.AIType mType;
      [SerializeField]
      private List<ActionResult> mActionResults;
      [SerializeField]
      private BL.SkillEffectList mSkillEffectList;
      [NonSerialized]
      private BL.ForceID mForceId = BL.ForceID.none;
      public System.Action action;
      [NonSerialized]
      private int mSkillLevel;

      private AIUnit()
      {
      }

      public AIUnit(BL.UnitPosition up, BL.AIType type)
      {
        this.mHp = up.unit.hp;
        this.mUnitPosition = up;
        this.mType = type;
        this.mActionResults = (List<ActionResult>) null;
        this.action = (System.Action) null;
        this.mSkillEffectList = CopyUtil.DeepCopy<BL.SkillEffectList>(up.unit.skillEffects);
        this.mId = up.id;
        this.mUnit = up.unit;
        this.mOriginalRow = this.mRow = up.originalRow;
        this.mOriginalColumn = this.mColumn = up.originalColumn;
        this.mUsedMoveCost = up.usedMoveCost;
        this.mCompletedCount = up.completedCount;
        this.mActionCount = up.actionCount;
        this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mMovePanels = this.mCompletePanels = (HashSet<BL.Panel>) null;
        this.asterNodeCache = up.asterNodeCache;
        this.mActionMovePanels = new HashSet<BL.Panel>();
        this.mHealMovePanels = new HashSet<BL.Panel>();
      }

      public int hp
      {
        get => this.mHp;
        set
        {
          this.mHp = Mathf.Max(Mathf.Min(value, this.unitPosition.unit.parameter.Hp), 0);
          ++this.revision;
        }
      }

      public BL.UnitPosition unitPosition
      {
        get => this.mUnitPosition;
        set
        {
          if (this.mUnitPosition == value)
            return;
          this.mUnitPosition = value;
          ++this.revision;
        }
      }

      public BL.AIType type
      {
        get => this.mType;
        set
        {
          this.mType = value;
          ++this.revision;
        }
      }

      public bool isHealer => this.mUnit.healRange.Length != 0;

      public BL.ForceID getForceID(BL env)
      {
        if (this.mForceId == BL.ForceID.none)
          this.mForceId = env.getForceID(this.mUnit);
        return this.mForceId;
      }

      public List<ActionResult> actionResults
      {
        get => this.mActionResults;
        set
        {
          this.mActionResults = value;
          ++this.revision;
        }
      }

      public bool isAction => this.mActionCount != 0 && !this.IsDontAction;

      public BL.Panel GetTargetPanelOrNull(BL env) => this.mUnitPosition.unit.GetTargetPanel(env);

      public BL.Unit originalUnit => this.mUnit;

      public BL.SkillEffectList skillEffects => this.mSkillEffectList;

      public bool HasAilment => this.mSkillEffectList.HasAilment;

      public bool IsDontAction
      {
        get
        {
          return this.mSkillEffectList.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_act, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontMove
      {
        get
        {
          return this.mSkillEffectList.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_move, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontEvasion
      {
        get
        {
          return this.mSkillEffectList.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontUseSkill(int skill_id)
      {
        return this.mSkillEffectList.HasAilmentEffectLogic(BattleskillEffectLogicEnum.seal) && this.skillEffects.IsSealedSkill(skill_id);
      }

      public bool HasEnabledSkillEffect(BattleskillEffectLogicEnum logic)
      {
        return this.enabledSkillEffect(logic).Any<BL.SkillEffect>();
      }

      public IEnumerable<BL.SkillEffect> enabledSkillEffect(BattleskillEffectLogicEnum logic)
      {
        return this.mSkillEffectList.Where(logic).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.skill.skill_type != BattleskillSkillType.passive || !this.IsDontUseSkill(x.baseSkillId)));
      }

      public BL.AIUnitNetwork ToNetwork(BL env)
      {
        return new BL.AIUnitNetwork()
        {
          unitPosition = this.mUnitPosition != null ? this.mUnitPosition.ToNetwork(env) : new int?(),
          hp = this.hp,
          row = this.row,
          column = this.column,
          type = this.type,
          actionResults = this.actionResults != null ? this.actionResults.Select<ActionResult, ActionResultNetwork>((Func<ActionResult, ActionResultNetwork>) (x => x.ToNetwork(env))).ToList<ActionResultNetwork>() : (List<ActionResultNetwork>) null
        };
      }

      public static BL.AIUnit FromNetwork(BL.AIUnitNetwork nw, BL env)
      {
        BL.AIUnit aiUnit = nw != null ? new BL.AIUnit(BL.UnitPosition.FromNetwork(nw.unitPosition, env), nw.type) : (BL.AIUnit) null;
        aiUnit.hp = nw.hp;
        aiUnit.row = nw.row;
        aiUnit.column = nw.column;
        aiUnit.actionResults = nw.actionResults != null ? nw.actionResults.Select<ActionResultNetwork, ActionResult>((Func<ActionResultNetwork, ActionResult>) (x => ActionResult.FromNetworkCommon((DuelResult.FromNetwork(x, env) ?? BL.BattleSkillResult.FromNetwork(x, env)) ?? (ActionResult) new MoveCompleteResult(nw.row, nw.column), x))).ToList<ActionResult>() : (List<ActionResult>) null;
        return aiUnit;
      }

      private void _completeAIUnit(BL env)
      {
        this.mUsedMoveCost = this.mActionCount = this.mCompletedCount = 0;
        if (this.mActionResults == null)
        {
          this.mActionResults = new List<ActionResult>();
          this.mActionResults.Add((ActionResult) new MoveCompleteResult(this.mRow, this.mColumn));
        }
        else
        {
          ActionResult mActionResult = this.mActionResults[this.mActionResults.Count - 1];
          if (mActionResult.row != this.mRow || mActionResult.column != this.mColumn)
            this.mActionResults.Add((ActionResult) new MoveCompleteResult(this.mRow, this.mColumn));
          else
            mActionResult.terminate = true;
        }
        env.aiActionUnits.value.Remove(this);
        env.aiActionOrder.value.Enqueue(this);
        if (env.aiActionOrder.value.Count == env.aiActionMax)
          env.aiActionUnits.value.Clear();
        int[] ids = env.getFieldPanel((BL.UnitPosition) this).getReinforcementIDsToPanel(env.getForceID(this.unit));
        if (ids == null)
          return;
        this.spawnAIUnits(env.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => this.canSpawnp(x.unit, env) && x.unit.playerUnit.reinforcement != null && ((IEnumerable<int>) ids).Contains<int>(x.unit.playerUnit.reinforcement.ID))), env);
      }

      public bool actionAIUnit(BL env, bool useCost = true)
      {
        if (this.mActionCount == 0)
          return false;
        --this.mCompletedCount;
        --this.mActionCount;
        int mOriginalRow = this.mOriginalRow;
        int mOriginalColumn = this.mOriginalColumn;
        this.mOriginalRow = this.mRow;
        this.mOriginalColumn = this.mColumn;
        BL.Panel fieldPanel1 = env.getFieldPanel(mOriginalRow, mOriginalColumn);
        BL.Panel fieldPanel2 = env.getFieldPanel(this.mRow, this.mColumn);
        if (this.mOriginalRow != mOriginalRow || this.mOriginalColumn != mOriginalColumn)
        {
          foreach (BL.AIUnit aiUnit in env.aiUnitPositions.value)
          {
            if (aiUnit != this && aiUnit.hasPanelsCache && (aiUnit.movePanels.Contains(fieldPanel1) || aiUnit.movePanels.Contains(fieldPanel2) || aiUnit.allMoveActionRangePanels.Contains(fieldPanel1) || aiUnit.allMoveActionRangePanels.Contains(fieldPanel2)))
              aiUnit.clearMovePanelCache();
          }
          foreach (BL.ISkillEffectListUnit skillEffectListUnit in env.getCharismaTargetUnits((BL.ISkillEffectListUnit) this, mOriginalRow, mOriginalColumn).Intersect<BL.ISkillEffectListUnit>((IEnumerable<BL.ISkillEffectListUnit>) env.getCharismaTargetUnits((BL.ISkillEffectListUnit) this, this.mOriginalRow, this.mOriginalColumn)))
            skillEffectListUnit.skillEffects.commit();
        }
        if (this.mActionResults != null)
        {
          foreach (ActionResult mActionResult in this.mActionResults)
          {
            if (!mActionResult.isCompleted)
            {
              try
              {
                this.applyActionResult(mActionResult, env);
              }
              catch (Exception ex)
              {
                Debug.LogException(ex);
              }
            }
          }
        }
        if (this.mCompletedCount == 0)
        {
          this._completeAIUnit(env);
          return true;
        }
        if (useCost)
        {
          int routeCostNonCache = env.getRouteCostNonCache((BL.UnitPosition) this, fieldPanel1, fieldPanel2, this.movePanels, this.completePanels);
          if (this.mActionCount > 0 && this.mCompletedCount > 0)
            this.mUsedMoveCost = 0;
          else
            this.mUsedMoveCost += routeCostNonCache;
          this.movePanels = BattleFuncs.createMovePanels(this.mOriginalRow, this.mOriginalColumn, this.moveCost, this.mUnitPosition.unit, isAI: true);
          if (this.mMovePanels.Count == 1)
          {
            this._completeAIUnit(env);
            return true;
          }
        }
        else if (this.mOriginalRow != mOriginalRow || this.mOriginalColumn != mOriginalColumn)
          this.clearMovePanelCache();
        return false;
      }

      public void completeAIUnit(BL env)
      {
        if (env.aiActionUnits.value.Count == 0 || this.mCompletedCount == 0)
          return;
        this.actionAIUnit(env);
      }

      private void applyActionResult(ActionResult ar, BL env)
      {
        if (ar.isCompleted)
          return;
        DuelResult duelResult = ar as DuelResult;
        BL.BattleSkillResult battleSkillResult = ar as BL.BattleSkillResult;
        if (duelResult != null)
        {
          BL.AIUnit aiUnit1 = env.getAIUnit(duelResult.attack);
          BL.AIUnit aiUnit2 = env.getAIUnit(duelResult.defense);
          int hp = aiUnit2.hp;
          aiUnit1.hp -= duelResult.attackDamage;
          aiUnit2.hp -= duelResult.defenseDamage;
          bool flag = false;
          if (duelResult.isHeal)
            BattleFuncs.applyServantsJoy((BL.ISkillEffectListUnit) aiUnit1, aiUnit2.hp - hp);
          foreach (BL.ISkillEffectListUnit applyDuelSkillEffect in BattleFuncs.applyDuelSkillEffects(duelResult, (BL.ISkillEffectListUnit) aiUnit1, (BL.ISkillEffectListUnit) aiUnit2, env))
          {
            this.doDead(applyDuelSkillEffect as BL.AIUnit, env);
            flag = true;
          }
          if (aiUnit1.hp <= 0)
          {
            this.doDead(aiUnit1, env);
            flag = true;
            aiUnit2.skillEffects.AddKillCount(1);
          }
          if (aiUnit2.hp <= 0)
          {
            this.doDead(aiUnit2, env);
            flag = true;
            aiUnit1.skillEffects.AddKillCount(1);
          }
          this.spawnAIUnits(env.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => this.canSpawnp(x.unit, env) && x.unit.playerUnit.reinforcement != null && x.unit.playerUnit.reinforcement.isSpawnForBattle(duelResult.attack, duelResult.moveUnit != duelResult.attack ? duelResult.attack : duelResult.defense))), env);
          if (flag)
          {
            foreach (BL.AIUnit aiUnit3 in env.aiUnitPositions.value)
            {
              if (aiUnit3.hasPanelsCache)
                aiUnit3.clearMovePanelCache();
            }
            this.spawnAIUnits(env.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => this.canSpawnp(x.unit, env) && env.isReinforceUnitForSmash(x.unit.playerUnit, true))), env);
          }
        }
        else if (battleSkillResult == null)
          ;
        ar.isCompleted = true;
      }

      private void doDead(BL.AIUnit u, BL env)
      {
        env.aiDeads.value.Add(u);
        env.aiUnitPositions.value.Remove(u);
      }

      private bool canSpawnp(BL.Unit unit, BL env)
      {
        return !unit.isDead && !unit.isEnable && !env.aiDeads.value.Any<BL.AIUnit>((Func<BL.AIUnit, bool>) (u => u.unit == unit));
      }

      private void spawnAIUnits(IEnumerable<BL.UnitPosition> units, BL env)
      {
        bool flag = false;
        foreach (BL.UnitPosition unit in units)
        {
          BL.AIUnit aiUnit = new BL.AIUnit(unit, BL.AIType.normal);
          aiUnit.resetSpawnPosition(true);
          env.aiUnitPositions.value.Add(aiUnit);
          env.aiUnitPositions.commit();
          flag = true;
        }
        if (!flag)
          return;
        foreach (BL.AIUnit aiUnit in env.aiUnitPositions.value)
        {
          if (aiUnit.hasPanelsCache)
            aiUnit.clearMovePanelCache();
        }
      }

      public int skillLevel
      {
        get
        {
          if (this.mSkillLevel == 0)
          {
            foreach (BL.Skill duelSkill in this.mUnit.duelSkills)
            {
              if (this.mSkillLevel < duelSkill.level)
                this.mSkillLevel = duelSkill.level;
            }
          }
          return this.mSkillLevel;
        }
      }

      public int rarity => this.mUnit.unit.rarity.index + 1;
    }

    public enum ConditionType
    {
      alldown,
      bossdown,
      area,
    }

    public enum GameoverType
    {
      alldown,
      guestdown,
      playerdown,
    }

    [Serializable]
    public class Condition : BL.ModelBase
    {
      [SerializeField]
      private int mId;

      public int id
      {
        get => this.mId;
        set
        {
          this.mId = value;
          ++this.revision;
        }
      }

      public BattleVictoryCondition condition => MasterData.BattleVictoryCondition[this.id];

      public BL.ConditionType type
      {
        get
        {
          if (this.isExistWinAreaCondition)
            return BL.ConditionType.area;
          return this.condition.enemy == null ? BL.ConditionType.alldown : BL.ConditionType.bossdown;
        }
      }

      public bool isTurn => this.condition.turn.HasValue;

      public bool isElapsedTurn => this.condition.elapsed_turn.HasValue;

      public int turn => this.condition.turn.Value;

      public int elapsedTurn => this.condition.elapsed_turn.Value;

      public int bossId => this.condition.enemy.ID;

      public bool isExistWinAreaCondition => this.condition.win_area_confition_group_id.HasValue;

      public BattleVictoryAreaCondition[] winAreaConditoin
      {
        get
        {
          return this.condition.win_area_confition_group_id.HasValue ? ((IEnumerable<BattleVictoryAreaCondition>) MasterData.BattleVictoryAreaConditionList).Where<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x =>
          {
            int groupId = x.group_id;
            int? confitionGroupId = this.condition.win_area_confition_group_id;
            int valueOrDefault = confitionGroupId.GetValueOrDefault();
            return groupId == valueOrDefault && confitionGroupId.HasValue;
          })).ToArray<BattleVictoryAreaCondition>() : new BattleVictoryAreaCondition[0];
        }
      }

      public bool isExistLoseAreaCondition => this.condition.lose_area_confition_group_id.HasValue;

      public BattleVictoryAreaCondition[] loseAreaConditoin
      {
        get
        {
          return this.condition.lose_area_confition_group_id.HasValue ? ((IEnumerable<BattleVictoryAreaCondition>) MasterData.BattleVictoryAreaConditionList).Where<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x =>
          {
            int groupId = x.group_id;
            int? confitionGroupId = this.condition.lose_area_confition_group_id;
            int valueOrDefault = confitionGroupId.GetValueOrDefault();
            return groupId == valueOrDefault && confitionGroupId.HasValue;
          })).ToArray<BattleVictoryAreaCondition>() : new BattleVictoryAreaCondition[0];
        }
      }
    }

    [Serializable]
    public class DropData : BL.ModelBase
    {
      [SerializeField]
      private Reward mReward;
      [SerializeField]
      private bool mIsCompleted;
      [SerializeField]
      private int mExecuteUnitId;
      [NonSerialized]
      private int mRarity = -1;

      public Reward reward
      {
        get => this.mReward;
        set
        {
          this.mReward = value;
          ++this.revision;
        }
      }

      public bool isCompleted => this.mIsCompleted;

      public int executeUnitId => this.mExecuteUnitId;

      public bool isDropBox
      {
        get
        {
          return this.mReward.Type == MasterDataTable.CommonRewardType.gear || this.mReward.Type == MasterDataTable.CommonRewardType.supply || this.mReward.Type == MasterDataTable.CommonRewardType.unit || this.mReward.Type == MasterDataTable.CommonRewardType.money;
        }
      }

      [OnDeserialized]
      private void OnDeserialized(StreamingContext context) => this.mRarity = -1;

      public int rarity
      {
        get
        {
          if (this.mRarity != -1)
            return this.mRarity;
          switch (this.mReward.Type)
          {
            case MasterDataTable.CommonRewardType.unit:
              this.mRarity = MasterData.UnitUnit[this.mReward.Id].rarity.index;
              break;
            case MasterDataTable.CommonRewardType.supply:
              this.mRarity = MasterData.SupplySupply[this.mReward.Id].rarity.index;
              break;
            case MasterDataTable.CommonRewardType.gear:
              this.mRarity = MasterData.GearGear[this.mReward.Id].rarity.index;
              break;
            default:
              this.mRarity = 0;
              break;
          }
          return this.mRarity;
        }
      }

      public void execute(BL.Unit unit, BL env)
      {
        if (this.mIsCompleted)
          return;
        switch (this.reward.Type)
        {
          case MasterDataTable.CommonRewardType.unit:
            ++env.dropUnit.value;
            break;
          case MasterDataTable.CommonRewardType.supply:
            ++env.dropItem.value;
            break;
          case MasterDataTable.CommonRewardType.gear:
            ++env.dropItem.value;
            break;
          case MasterDataTable.CommonRewardType.money:
            env.dropMoney.value += this.reward.Quantity;
            break;
        }
        if (unit != null)
          this.mExecuteUnitId = unit.playerUnit.id;
        this.mIsCompleted = true;
        ++this.revision;
      }
    }

    [Serializable]
    public class Duel : BL.ModelBase
    {
      public DuelResult result;
      public BL.MagicBullet attackBullet;
      public BL.MagicBullet defenseBullet;
    }

    [Serializable]
    public class SuiseiResult
    {
      public int damage;
      public int dispDamage;
      public int drainDamage;
      public int dispDrainDamage;
      public int defenderDispDrainDamage;
      public int defenderDrainDamage;
      public bool isHit;
      public bool isCritical;
      public BL.Skill[] invokeDuelSkills;
      public BL.Skill[] invokeDefenderDuelSkills;
    }

    [Serializable]
    public class DuelTurn
    {
      public int damage;
      public int dispDamage;
      public int drainDamage;
      public int dispDrainDamage;
      public int counterDamage;
      public int defenderDispDrainDamage;
      public int defenderDrainDamage;
      public int attackerRestHp;
      public int defenderRestHp;
      public AttackStatus attackStatus;
      public AttackStatus attackerStatus;
      public AttackStatus defenderStatus;
      public bool isAtackker;
      public bool isHit;
      public bool isCritical;
      public int[] skillIds;
      public BL.Skill[] invokeDuelSkills;
      public BL.Skill[] invokeDefenderDuelSkills;
      public BL.Skill[] invokeAilmentSkills;
      public BL.Skill[] invokeGiveSkills;
      public List<BL.SkillEffect> attackerConsumeSkillEffects;
      public List<BL.SkillEffect> defenderConsumeSkillEffects;
      public List<BL.SuiseiResult> suiseiResults;
      public BattleskillAilmentEffect[] ailmentEffects;

      public BattleskillSkill[] skills
      {
        get
        {
          return ((IEnumerable<int>) this.skillIds).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (x => MasterData.BattleskillSkill[x])).ToArray<BattleskillSkill>();
        }
      }

      public bool isDieAttackerOrDefender() => this.isDieAttacker() || this.isDieDefender();

      public bool isDieAttacker() => this.attackerRestHp <= 0;

      public bool isDieDefender() => this.defenderRestHp <= 0;
    }

    public enum PanelAttribute
    {
      clear = 0,
      playermove = 1,
      neutralmove = 2,
      enemymove = 4,
      danger = 8,
      moving = 16, // 0x00000010
      target_attack = 32, // 0x00000020
      target_heal = 64, // 0x00000040
      attack_range = 128, // 0x00000080
      heal_range = 256, // 0x00000100
      test = 4096, // 0x00001000
    }

    public enum PanelVictoryConditionAtrribute
    {
      none,
      win_player_on_panel,
      lose_enemy_on_panel,
    }

    public enum PanelReinforcementConditionAtrribute
    {
      none,
      player_on_panel,
      enemy_on_panel,
    }

    [Serializable]
    public class Panel : BL.ModelBase
    {
      [SerializeField]
      private int mLandformId;
      [SerializeField]
      private int mRow;
      [SerializeField]
      private int mColumn;
      [NonSerialized]
      private BL.PanelAttribute mAttribute;
      [SerializeField]
      private BL.DropData mFieldEvent;
      [SerializeField]
      private int mFieldEventId;
      [SerializeField]
      private BL.PanelVictoryConditionAtrribute mConditionAttribute;
      [SerializeField]
      private int[] reinforcementIDs;
      [SerializeField]
      private BL.PanelReinforcementConditionAtrribute mReinforcementConditionAttribute;
      [NonSerialized]
      public int workMovement;

      public Panel(
        int row,
        int column,
        int landformId,
        int fieldEventId,
        BL.DropData fieldEvent,
        BattleVictoryAreaCondition[] winArea,
        BattleVictoryAreaCondition[] loseArea,
        BattleReinforcement[] battleReinforcements)
      {
        this.mRow = row;
        this.mColumn = column;
        this.mLandformId = landformId;
        this.mFieldEventId = fieldEventId;
        this.mFieldEvent = fieldEvent;
        this.mConditionAttribute = BL.PanelVictoryConditionAtrribute.none;
        if (winArea != null && ((IEnumerable<BattleVictoryAreaCondition>) winArea).Any<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x => x.area_y - 1 == this.mRow && x.area_x - 1 == this.mColumn)))
          this.mConditionAttribute |= BL.PanelVictoryConditionAtrribute.win_player_on_panel;
        if (loseArea != null && ((IEnumerable<BattleVictoryAreaCondition>) loseArea).Any<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x => x.area_y - 1 == this.mRow && x.area_x - 1 == this.mColumn)))
          this.mConditionAttribute |= BL.PanelVictoryConditionAtrribute.lose_enemy_on_panel;
        List<int> intList = new List<int>();
        if (battleReinforcements != null)
        {
          foreach (BattleReinforcement battleReinforcement in battleReinforcements)
          {
            if (battleReinforcement.area != null && ((IEnumerable<BattleVictoryAreaCondition>) battleReinforcement.area).Any<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x => x.area_y - 1 == this.mRow && x.area_x - 1 == this.mColumn)))
            {
              if (battleReinforcement.reinforcement_logic.Enum == BattleReinforcementLogicEnum.player_area_invasion)
              {
                this.mReinforcementConditionAttribute |= BL.PanelReinforcementConditionAtrribute.player_on_panel;
                intList.Add(battleReinforcement.ID);
              }
              else if (battleReinforcement.reinforcement_logic.Enum == BattleReinforcementLogicEnum.enemy_area_invasion)
              {
                this.mReinforcementConditionAttribute |= BL.PanelReinforcementConditionAtrribute.enemy_on_panel;
                intList.Add(battleReinforcement.ID);
              }
            }
          }
          this.reinforcementIDs = intList.ToArray();
        }
        ++this.revision;
      }

      public BattleLandform landform => MasterData.BattleLandform[this.mLandformId];

      public int landformID => this.mLandformId;

      public int row
      {
        get => this.mRow;
        set
        {
          this.mRow = value;
          ++this.revision;
        }
      }

      public int column
      {
        get => this.mColumn;
        set
        {
          this.mColumn = value;
          ++this.revision;
        }
      }

      public BL.PanelAttribute attribute
      {
        get => this.mAttribute;
        set
        {
          if (this.mAttribute == value)
            return;
          this.mAttribute = value;
          ++this.revision;
        }
      }

      public void setAttribute(BL.PanelAttribute attr)
      {
        if ((this.mAttribute & attr) != BL.PanelAttribute.clear)
          return;
        this.mAttribute |= attr;
        ++this.revision;
      }

      public void unsetAttribute(BL.PanelAttribute attr)
      {
        if ((this.mAttribute & attr) == BL.PanelAttribute.clear)
          return;
        this.mAttribute &= ~attr;
        ++this.revision;
      }

      public bool checkAttribute(BL.PanelAttribute attr) => (this.mAttribute & attr) == attr;

      public void clearAttribute()
      {
        if (this.mAttribute == BL.PanelAttribute.clear)
          return;
        this.mAttribute = BL.PanelAttribute.clear;
        ++this.revision;
      }

      public bool checkVictoryConditionAtrribute(BL.PanelVictoryConditionAtrribute attr)
      {
        return (this.mConditionAttribute & attr) == attr;
      }

      public BL.Phase getChangePhaseToPanel(BL.ForceID forceID)
      {
        switch (forceID)
        {
          case BL.ForceID.player:
            if ((this.mConditionAttribute & BL.PanelVictoryConditionAtrribute.win_player_on_panel) == BL.PanelVictoryConditionAtrribute.win_player_on_panel)
              return BL.Phase.stageclear;
            break;
          case BL.ForceID.enemy:
            if ((this.mConditionAttribute & BL.PanelVictoryConditionAtrribute.lose_enemy_on_panel) == BL.PanelVictoryConditionAtrribute.lose_enemy_on_panel)
              return BL.Phase.gameover;
            break;
        }
        return BL.Phase.none;
      }

      public bool checkReinforcementConditionAtrribute(BL.PanelReinforcementConditionAtrribute attr)
      {
        return (this.mReinforcementConditionAttribute & attr) == attr;
      }

      public int[] getReinforcementIDsToPanel(BL.ForceID forceID)
      {
        int[] reinforcementIdsToPanel = (int[]) null;
        switch (forceID)
        {
          case BL.ForceID.player:
            if ((this.mReinforcementConditionAttribute & BL.PanelReinforcementConditionAtrribute.player_on_panel) == BL.PanelReinforcementConditionAtrribute.player_on_panel)
            {
              reinforcementIdsToPanel = this.reinforcementIDs;
              break;
            }
            break;
          case BL.ForceID.enemy:
            if ((this.mReinforcementConditionAttribute & BL.PanelReinforcementConditionAtrribute.enemy_on_panel) == BL.PanelReinforcementConditionAtrribute.enemy_on_panel)
            {
              reinforcementIdsToPanel = this.reinforcementIDs;
              break;
            }
            break;
        }
        return reinforcementIdsToPanel;
      }

      public int fieldEventId
      {
        get => this.mFieldEventId;
        set
        {
          this.mFieldEventId = value;
          ++this.revision;
        }
      }

      public BL.DropData fieldEvent
      {
        get => this.mFieldEvent;
        set
        {
          this.mFieldEvent = value;
          ++this.revision;
        }
      }

      public bool hasEvent => this.mFieldEvent != null && !this.mFieldEvent.isCompleted;

      public void executeEvent(BL.Unit unit, BL env)
      {
        if (!this.hasEvent)
          return;
        this.mFieldEvent.execute(unit, env);
        ++this.revision;
      }

      public Tuple<int, int> getEffectsAddRange(int gear_kind_id, UnitMoveType moveType)
      {
        BattleLandformEffect[] array = ((IEnumerable<BattleLandformEffect>) this.landform.GetIncr(moveType).GetLandformEffects(BattleLandformEffectPhase.move)).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_range && x.GetInt(nameof (gear_kind_id)) == gear_kind_id)).ToArray<BattleLandformEffect>();
        if (array.Length <= 0)
          return new Tuple<int, int>(0, 0);
        BattleLandformEffect battleLandformEffect = array[0];
        return new Tuple<int, int>(battleLandformEffect.GetInt("min_add"), battleLandformEffect.GetInt("max_add"));
      }

      public string ShowPosition() => "(" + (object) this.row + ", " + (object) this.column + ")";

      public override string ToString() => "[" + this.ShowPosition() + "]";

      public int id => this.mRow * 100000 + this.mColumn;
    }

    [Serializable]
    public class UnitPosition : BL.ModelBase
    {
      [SerializeField]
      protected int mId;
      [SerializeField]
      protected BL.Unit mUnit;
      [SerializeField]
      protected int mRow;
      [SerializeField]
      protected int mColumn;
      [SerializeField]
      protected float mDirection;
      [SerializeField]
      protected int mOriginalRow;
      [SerializeField]
      protected int mOriginalColumn;
      [SerializeField]
      protected int mUsedMoveCost;
      [SerializeField]
      protected int mCompletedCount;
      [SerializeField]
      protected int mActionCount;
      [SerializeField]
      protected List<int> mScriptList;
      [NonSerialized]
      protected HashSet<BL.Panel> mMovePanels;
      [NonSerialized]
      protected HashSet<BL.Panel> mCompletePanels;
      [NonSerialized]
      protected HashSet<BL.Panel> mAllMoveActionRangePanels;
      [NonSerialized]
      protected HashSet<BL.Panel> mAllMoveHealRangePanels;
      [NonSerialized]
      protected HashSet<BL.Panel> mActionMovePanels;
      [NonSerialized]
      protected HashSet<BL.Panel> mHealMovePanels;
      [NonSerialized]
      public BattleFuncs.AsterNode[][] asterNodeCache = new BattleFuncs.AsterNode[2][];
      private static int moveLimiter = 1000;

      public int? ToNetwork(BL env) => new int?(this.mId);

      public static BL.UnitPosition FromNetwork(int? nw, BL env)
      {
        return !nw.HasValue ? (BL.UnitPosition) null : env.getUnitPositionById(nw.Value);
      }

      public int id
      {
        get => this.mId;
        set
        {
          this.mId = value;
          ++this.revision;
        }
      }

      public BL.Unit unit
      {
        get => this.mUnit;
        set
        {
          if (this.mUnit == value)
            return;
          this.mUnit = value;
          this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = this.mMovePanels = (HashSet<BL.Panel>) null;
          ++this.revision;
        }
      }

      public int row
      {
        get => this.mRow;
        set
        {
          if (this.mRow == value)
            return;
          this.mRow = value;
          ++this.revision;
        }
      }

      public int column
      {
        get => this.mColumn;
        set
        {
          if (this.mColumn == value)
            return;
          this.mColumn = value;
          ++this.revision;
        }
      }

      public float direction
      {
        get => this.mDirection;
        set
        {
          if ((double) this.mDirection == (double) value)
            return;
          this.mDirection = value;
          ++this.revision;
        }
      }

      public override string ToString()
      {
        return "[" + this.mUnit.unit.name + " (" + (object) this.mRow + ", " + (object) this.mColumn + ") direction:" + (object) this.mDirection + "]";
      }

      public int originalRow => this.mOriginalRow;

      public int originalColumn => this.mOriginalColumn;

      public int usedMoveCost => this.mUsedMoveCost;

      public int completedCount => this.mCompletedCount;

      public int actionCount => this.mActionCount;

      public bool cantChangeCurrent
      {
        get
        {
          int currentActionCount = this.unit.skillEffects.GetCantChageCurrentActionCount();
          return this.mActionCount <= currentActionCount && this.mCompletedCount > currentActionCount;
        }
      }

      public void setPositions(int or, int oc, int r, int c)
      {
        this.mOriginalRow = or;
        this.mOriginalColumn = oc;
        this.mRow = r;
        this.mColumn = c;
      }

      public void resetOriginalPosition()
      {
        if (this.mOriginalRow != this.mRow || this.mOriginalColumn != this.mColumn)
        {
          this.mOriginalRow = this.mRow;
          this.mOriginalColumn = this.mColumn;
        }
        this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = this.mMovePanels = (HashSet<BL.Panel>) null;
        this.mUsedMoveCost = 0;
        this.mCompletedCount = this.unit.skillEffects.GetCompleteCount();
        this.mActionCount = this.unit.skillEffects.GetActionCount();
        ++this.revision;
      }

      public bool isLocalMoved
      {
        get => this.mOriginalRow != this.mRow || this.mOriginalColumn != this.mColumn;
      }

      public HashSet<BL.Panel> movePanels
      {
        get
        {
          if (this.mMovePanels == null)
          {
            this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = (HashSet<BL.Panel>) null;
            if (this.mUnit == null)
            {
              this.mMovePanels = new HashSet<BL.Panel>();
            }
            else
            {
              if (this.mUnit.IsDontMove)
                return new HashSet<BL.Panel>()
                {
                  BattleFuncs.getPanel(this.mOriginalRow, this.mOriginalColumn)
                };
              this.mMovePanels = BattleFuncs.createMovePanels(this.mOriginalRow, this.mOriginalColumn, this.moveCost, this.mUnit, isAI: this is BL.AIUnit);
            }
          }
          return this.mMovePanels;
        }
        set
        {
          this.mMovePanels = value;
          this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = (HashSet<BL.Panel>) null;
          ++this.revision;
        }
      }

      public bool hasPanelsCache => this.mMovePanels != null;

      public HashSet<BL.Panel> completePanels
      {
        get
        {
          if (this.mCompletePanels == null || this.mMovePanels == null)
            this.mCompletePanels = BattleFuncs.moveCompletePanels_(this.movePanels, this.mUnit, this is BL.AIUnit);
          return this.mCompletePanels;
        }
      }

      public HashSet<BL.Panel> allMoveActionRangePanels
      {
        get
        {
          if (this.mUnit.IsDontAction)
            return new HashSet<BL.Panel>();
          if (this.mAllMoveActionRangePanels == null)
            this.mAllMoveActionRangePanels = BattleFuncs.allMoveActionRangePanels_(this, isAI: this is BL.AIUnit, positionPanels: this.mActionMovePanels);
          return this.mAllMoveActionRangePanels;
        }
      }

      public HashSet<BL.Panel> allMoveHealRangePanels
      {
        get
        {
          if (this.mUnit.IsDontAction)
            return new HashSet<BL.Panel>();
          if (this.mAllMoveHealRangePanels == null)
            this.mAllMoveHealRangePanels = BattleFuncs.allMoveActionRangePanels_(this, isAI: this is BL.AIUnit, isHeal: true, positionPanels: this.mHealMovePanels);
          return this.mAllMoveHealRangePanels;
        }
      }

      public HashSet<BL.Panel> actionMovePanels
      {
        get
        {
          if (this.mUnit.IsDontAction)
            return new HashSet<BL.Panel>();
          if (this.mAllMoveActionRangePanels == null)
            this.mAllMoveActionRangePanels = BattleFuncs.allMoveActionRangePanels_(this, isAI: this is BL.AIUnit, positionPanels: this.mActionMovePanels);
          return this.mActionMovePanels;
        }
      }

      public HashSet<BL.Panel> healMovePanels
      {
        get
        {
          if (this.mUnit.IsDontAction)
            return new HashSet<BL.Panel>();
          if (this.mAllMoveHealRangePanels == null)
            this.mAllMoveHealRangePanels = BattleFuncs.allMoveActionRangePanels_(this, isAI: this is BL.AIUnit, isHeal: true, positionPanels: this.mHealMovePanels);
          return this.mHealMovePanels;
        }
      }

      public void clearMovePanelCache()
      {
        this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = this.mMovePanels = (HashSet<BL.Panel>) null;
      }

      public bool isCompleted => this.mCompletedCount == 0;

      public bool isActionComleted => this.mActionCount == 0;

      public int moveCost => this.mUnit.parameter.Move - this.mUsedMoveCost;

      private void _completeActionUnit(BL env)
      {
        BL.ClassValue<List<BL.UnitPosition>> actionUnits = env.getActionUnits(this);
        if (actionUnits != null)
        {
          actionUnits.value.Remove(this);
          actionUnits.commit();
        }
        env.completedActionUnits.value.Add(this);
        env.completedActionUnits.commit();
        this.mUsedMoveCost = this.mActionCount = this.mCompletedCount = 0;
      }

      public void actionActionUnit(BL env, bool useCost = true)
      {
        if (this.mActionCount == 0 && this.mCompletedCount == 0)
          return;
        if (this.mActionCount > 0)
          --this.mActionCount;
        --this.mCompletedCount;
        int mOriginalRow = this.mOriginalRow;
        int mOriginalColumn = this.mOriginalColumn;
        this.mOriginalRow = this.mRow;
        this.mOriginalColumn = this.mColumn;
        BL.Panel fieldPanel1 = env.getFieldPanel(mOriginalRow, mOriginalColumn);
        BL.Panel fieldPanel2 = env.getFieldPanel(this.mRow, this.mColumn);
        if (this.mOriginalRow != mOriginalRow || this.mOriginalColumn != mOriginalColumn)
        {
          foreach (BL.UnitPosition unitPosition in env.unitPositions.value)
          {
            if (unitPosition != this && unitPosition.hasPanelsCache && (unitPosition.movePanels.Contains(fieldPanel1) || unitPosition.movePanels.Contains(fieldPanel2) || unitPosition.allMoveActionRangePanels.Contains(fieldPanel1) || unitPosition.allMoveActionRangePanels.Contains(fieldPanel2)))
              unitPosition.clearMovePanelCache();
          }
          foreach (BL.ISkillEffectListUnit skillEffectListUnit in env.getCharismaTargetUnits((BL.ISkillEffectListUnit) this.mUnit, mOriginalRow, mOriginalColumn).Intersect<BL.ISkillEffectListUnit>((IEnumerable<BL.ISkillEffectListUnit>) env.getCharismaTargetUnits((BL.ISkillEffectListUnit) this.mUnit, this.mOriginalRow, this.mOriginalColumn)))
            skillEffectListUnit.skillEffects.commit();
        }
        if (this.mCompletedCount == 0)
          this._completeActionUnit(env);
        else if (useCost)
        {
          int routeCostNonCache = env.getRouteCostNonCache(this, fieldPanel1, fieldPanel2, this.movePanels, this.completePanels);
          if (this.mActionCount > 0 && this.mCompletedCount > 0)
            this.mUsedMoveCost = 0;
          else
            this.mUsedMoveCost += routeCostNonCache;
          this.movePanels = BattleFuncs.createMovePanels(this.mOriginalRow, this.mOriginalColumn, this.moveCost, this.mUnit, isAI: this is BL.AIUnit);
          if (this.mMovePanels.Count == 1)
            this._completeActionUnit(env);
        }
        else if (this.mOriginalRow != mOriginalRow || this.mOriginalColumn != mOriginalColumn)
          this.clearMovePanelCache();
        env.firstCompleted.value = true;
        ++this.revision;
        env.createDangerAria();
      }

      public void completeActionUnit(BL env, bool isAllComplete = false)
      {
        if (this.mCompletedCount == 0)
          return;
        if (isAllComplete)
          this.mActionCount = this.mCompletedCount = 1;
        this.actionActionUnit(env);
      }

      public void resetSpawnPosition(bool isAI = false)
      {
        if (this.mUnit.isEnable && !this.mUnit.isDead)
          return;
        int moveCost = this.moveCost;
        List<BL.Panel> list;
        do
        {
          bool isAI1 = isAI;
          list = BattleFuncs.moveCompletePanels_(BattleFuncs.createMovePanels(this.mOriginalRow, this.mOriginalColumn, moveCost, this.mUnit, isAI: isAI1, isRebirth: true), this.mUnit, isAI, false).ToList<BL.Panel>();
          moveCost += 5;
        }
        while (moveCost < BL.UnitPosition.moveLimiter && list.Count == 0);
        if (list.Count == 0)
          return;
        list.Sort((Comparison<BL.Panel>) ((a, b) => BL.fieldDistance(a, this) - BL.fieldDistance(b, this)));
        this.mOriginalRow = this.mRow = list[0].row;
        this.mOriginalColumn = this.mColumn = list[0].column;
        this.mAllMoveHealRangePanels = this.mAllMoveActionRangePanels = this.mCompletePanels = this.mMovePanels = (HashSet<BL.Panel>) null;
        ++this.revision;
      }

      public void setScript(int id)
      {
        if (id == 0)
          return;
        if (this.mScriptList == null)
          this.mScriptList = new List<int>();
        this.mScriptList.Add(id);
      }

      public List<int> getScripts() => this.mScriptList;

      public void resetScript() => this.mScriptList = (List<int>) null;
    }

    [Serializable]
    public class Stage : BL.ModelBase
    {
      [SerializeField]
      private int mId;

      public Stage(int id) => this.mId = id;

      public int id => this.mId;

      public BattleStage stage => MasterData.BattleStage[this.mId];

      public int mapId => this.stage.map.ID;

      public int mapOffsetRow => this.stage.map_offset_y;

      public int mapOffsetColumn => this.stage.map_offset_x;
    }

    public enum FieldEffectType
    {
      battle_start,
      first_turn_start,
      turn_start,
      player_start,
      neutral_start,
      enemy_start,
      stageclear,
      pvp_change_player,
      pvp_change_enemy,
    }

    [Serializable]
    public class FieldEffect : BL.ModelBase
    {
      [SerializeField]
      private int mEffectId;
      [SerializeField]
      private BL.FieldEffectType mType;

      public FieldEffect(int id, BL.FieldEffectType type)
      {
        this.mEffectId = id;
        this.mType = type;
        ++this.revision;
      }

      public BL.FieldEffectType type => this.mType;

      public BattleFieldEffect fieldEffect => MasterData.BattleFieldEffect[this.mEffectId];
    }

    [Serializable]
    public class Intimate : BL.ModelBase
    {
      public Dictionary<Tuple<BL.ForceID, int, int>, int> intimateDic = new Dictionary<Tuple<BL.ForceID, int, int>, int>();

      public void add(BL.ForceID force, BL.Unit self, BL.Unit[] targetUnits, int value)
      {
        if (self.is_helper || self.playerUnit.is_gesut)
          return;
        BL.Unit[] array = ((IEnumerable<BL.Unit>) targetUnits).Where<BL.Unit>((Func<BL.Unit, bool>) (x => !x.is_helper && !x.playerUnit.is_gesut)).ToArray<BL.Unit>();
        Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
        foreach (BL.Unit unit in array)
        {
          int id1 = self.unit.character.ID;
          int id2 = unit.unit.character.ID;
          if (id1 != id2)
          {
            if (!dictionary1.ContainsKey(id2))
              dictionary1.Add(id2, 0);
            value -= dictionary1[id2];
            Dictionary<int, int> dictionary2;
            int key1;
            (dictionary2 = dictionary1)[key1 = id2] = dictionary2[key1] + 1;
            if (value < 0)
              value = 0;
            if (self.hp <= 0)
              value *= -1;
            Tuple<BL.ForceID, int, int> key2 = id1 >= id2 ? Tuple.Create<BL.ForceID, int, int>(force, id2, id1) : Tuple.Create<BL.ForceID, int, int>(force, id1, id2);
            if (!this.intimateDic.ContainsKey(key2))
              this.intimateDic.Add(key2, 0);
            Dictionary<Tuple<BL.ForceID, int, int>, int> intimateDic;
            Tuple<BL.ForceID, int, int> key3;
            (intimateDic = this.intimateDic)[key3 = key2] = intimateDic[key3] + value;
          }
        }
      }
    }

    [Serializable]
    public class Item : BL.ModelBase
    {
      [SerializeField]
      private int mPlayerItemId;
      [SerializeField]
      private int mItemId;
      [SerializeField]
      private int mAmount;
      [SerializeField]
      private int mInitialAmount;

      public int playerItemId
      {
        get => this.mPlayerItemId;
        set
        {
          this.mPlayerItemId = value;
          ++this.revision;
        }
      }

      public int itemId
      {
        get => this.mItemId;
        set
        {
          this.mItemId = value;
          ++this.revision;
        }
      }

      public SupplySupply item => MasterData.SupplySupply[this.mItemId];

      public int amount
      {
        get => this.mAmount;
        set
        {
          this.mAmount = value;
          ++this.revision;
        }
      }

      public int initialAmount
      {
        get => this.mInitialAmount;
        set
        {
          this.mInitialAmount = value;
          ++this.revision;
        }
      }
    }

    private class AttackStatusCacheContainer
    {
      private bool isAttack;
      private bool isHeal;
      private BL.Unit[] attackNeighbors;
      private BL.Unit[] defenseNeighbors;
      private int attackHp;
      private int orgAttackHp;
      private int orgDefenseHp;
      private BL.BattleModified<BL.SkillEffectList> attackSkillEffects;
      private BL.BattleModified<BL.SkillEffectList> defenseSkillEffects;
      private bool isFirst;
      private int mReadCount;
      public AttackStatus[] data;

      public AttackStatusCacheContainer(
        BL.ISkillEffectListUnit attack,
        BL.ISkillEffectListUnit defense,
        BL.Unit[] attackNeighbors,
        BL.Unit[] defenseNeighbors,
        int attackHp,
        bool isAttack,
        bool isHeal,
        AttackStatus[] data)
      {
        this.isAttack = isAttack;
        this.isHeal = isHeal;
        this.setData(attack, defense, attackNeighbors, defenseNeighbors, attackHp, data);
      }

      public int readCount => this.mReadCount;

      public void setData(
        BL.ISkillEffectListUnit attack,
        BL.ISkillEffectListUnit defense,
        BL.Unit[] attackNeighbors,
        BL.Unit[] defenseNeighbors,
        int attackHp,
        AttackStatus[] data)
      {
        this.mReadCount = 0;
        this.attackSkillEffects = new BL.BattleModified<BL.SkillEffectList>(attack.skillEffects);
        this.defenseSkillEffects = new BL.BattleModified<BL.SkillEffectList>(defense.skillEffects);
        this.attackSkillEffects.isChangedOnce();
        this.defenseSkillEffects.isChangedOnce();
        this.attackNeighbors = attackNeighbors;
        this.defenseNeighbors = defenseNeighbors;
        this.attackHp = attackHp;
        this.orgAttackHp = attack.hp;
        this.orgDefenseHp = defense.hp;
        this.data = data;
        this.isFirst = true;
      }

      public bool checkBaseValues(bool isAttack, bool isHeal)
      {
        return this.isAttack == isAttack && this.isHeal == isHeal;
      }

      private bool checkNeighbors(BL.Unit[] attackNeighbors, BL.Unit[] defenseNeighbors)
      {
        if (this.attackNeighbors.Length != attackNeighbors.Length || this.defenseNeighbors.Length != defenseNeighbors.Length)
          return false;
        for (int index = 0; index < this.attackNeighbors.Length; ++index)
        {
          if (this.attackNeighbors[index] != attackNeighbors[index])
            return false;
        }
        for (int index = 0; index < this.defenseNeighbors.Length; ++index)
        {
          if (this.defenseNeighbors[index] != defenseNeighbors[index])
            return false;
        }
        return true;
      }

      public bool checkValues(
        BL.ISkillEffectListUnit attack,
        BL.ISkillEffectListUnit defense,
        BL.Unit[] attackNeighbors,
        BL.Unit[] defenseNeighbors,
        int attackHp)
      {
        ++this.mReadCount;
        return this.attackHp == attackHp && this.orgAttackHp == attack.hp && this.orgDefenseHp == defense.hp && !this.attackSkillEffects.isChanged && !this.defenseSkillEffects.isChanged && this.checkNeighbors(attackNeighbors, defenseNeighbors);
      }

      public bool checkReadCount(int n)
      {
        if (!this.isFirst)
          return this.mReadCount > n;
        this.isFirst = false;
        return true;
      }

      public void resetReadCount() => this.mReadCount = 0;
    }

    [Serializable]
    public class MagicBullet : BL.ModelBase
    {
      [SerializeField]
      private int mSkillId;

      public int skillId
      {
        get => this.mSkillId;
        set
        {
          this.mSkillId = value;
          ++this.revision;
        }
      }

      public BattleskillSkill skill => MasterData.BattleskillSkill[this.skillId];

      public string name => this.skill.name;

      public CommonElement element => this.skill.element;

      public int power => this.skill.power;

      public int weight => this.skill.weight;

      public int cost => this.skill.consume_hp;

      public int spattack1 => 0;

      public int spattack2 => 0;

      public int maxRange => this.skill.max_range;

      public int minRange => this.skill.min_range;

      public string description => this.skill.description;

      public bool isAttack
      {
        get
        {
          return this.skill.target_type == BattleskillTargetType.enemy_single || this.skill.target_type == BattleskillTargetType.enemy_range;
        }
      }

      public bool isHeal => !this.isAttack;

      public bool isDrain
      {
        get
        {
          return this.skill.genre1.HasValue && this.skill.genre1.Value == BattleskillGenre.attack && this.skill.genre2.HasValue && this.skill.genre2.Value == BattleskillGenre.heal;
        }
      }

      public float drainRate
      {
        get
        {
          if (!this.isDrain)
            return 0.0f;
          BattleskillEffect battleskillEffect = ((IEnumerable<BattleskillEffect>) this.skill.Effects).FirstOrDefault<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.drain));
          return battleskillEffect == null ? 0.0f : battleskillEffect.GetFloat("drain");
        }
      }

      public BattleskillEffect percentageDamage
      {
        get
        {
          return ((IEnumerable<BattleskillEffect>) this.skill.Effects).FirstOrDefault<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.percentage_damage));
        }
      }

      public IEnumerable<BattleskillEffect> investSkillEffect
      {
        get
        {
          return ((IEnumerable<BattleskillEffect>) this.skill.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.invest_skilleffect));
        }
      }
    }

    [Serializable]
    public class Skill : BL.ModelBase
    {
      [SerializeField]
      private int mId = 100000001;
      [SerializeField]
      private int? mRemain;
      [SerializeField]
      private int mUseTurn;
      [SerializeField]
      private int mLevel;

      public int id
      {
        get => this.mId;
        set
        {
          this.mId = value;
          ++this.revision;
        }
      }

      public BattleskillSkill skill => MasterData.BattleskillSkill[this.mId];

      public string name => this.skill.name;

      public string description => this.skill.description;

      public BattleskillGenre? genre1 => this.skill.genre1;

      public BattleskillGenre? genre2 => this.skill.genre2;

      public int level
      {
        get => this.mLevel;
        set
        {
          this.mLevel = value;
          ++this.revision;
        }
      }

      public int? remain
      {
        get => this.mRemain;
        set
        {
          this.mRemain = value;
          ++this.revision;
        }
      }

      public int useTurn
      {
        get => this.mUseTurn;
        set
        {
          this.mUseTurn = value;
          ++this.revision;
        }
      }

      public BattleskillTargetType targetType => this.skill.target_type;

      public bool isOwn
      {
        get
        {
          return this.skill.target_type == BattleskillTargetType.myself || this.skill.target_type == BattleskillTargetType.player_single || this.skill.target_type == BattleskillTargetType.player_range || this.skill.target_type == BattleskillTargetType.dead_player_single;
        }
      }

      public bool isNonSelect
      {
        get
        {
          return this.skill.target_type == BattleskillTargetType.myself || this.skill.target_type == BattleskillTargetType.player_range || this.skill.target_type == BattleskillTargetType.enemy_range;
        }
      }

      public bool isOugi => this.skill.skill_type == BattleskillSkillType.release;

      public bool isCommand => this.skill.skill_type == BattleskillSkillType.command;

      public static bool HasEffect(
        BL.Skill[] skills,
        params BattleskillEffectLogicEnum[] effectLogic)
      {
        return ((IEnumerable<BL.Skill>) skills).Any<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => ((IEnumerable<BattleskillEffectLogicEnum>) effectLogic).Contains<BattleskillEffectLogicEnum>(effect.effect_logic.Enum)))));
      }

      public static bool HasDontActionEffect(BL.Skill[] skills)
      {
        return BL.Skill.HasEffect(skills, BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_act, BattleskillEffectLogicEnum.sleep);
      }

      public static bool HasDontMoveEffect(BL.Skill[] skills)
      {
        return BL.Skill.HasEffect(skills, BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_move, BattleskillEffectLogicEnum.sleep);
      }

      public static bool HasDontEvasionEffect(BL.Skill[] skills)
      {
        return BL.Skill.HasEffect(skills, BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.sleep);
      }

      public int getHpCost(BL.Unit unit)
      {
        int hpCost = 0;
        foreach (BattleskillEffect effect in this.skill.Effects)
        {
          switch (effect.effect_logic.Enum)
          {
            case BattleskillEffectLogicEnum.fix_rebirth:
              hpCost += effect.GetInt("cost_value") + this.level * effect.GetInt("cost_skill_ratio");
              break;
            case BattleskillEffectLogicEnum.ratio_rebirth:
              hpCost += Mathf.CeilToInt((float) unit.parameter.Hp * (effect.GetFloat("cost_percentage") + (float) this.level * effect.GetFloat("cost_skill_ratio")));
              break;
          }
        }
        return hpCost;
      }
    }

    [Serializable]
    public class SkillEffect : BL.ModelBase
    {
      [SerializeField]
      private int mEffectId;
      [SerializeField]
      private int mBaseSkillId;
      [SerializeField]
      private int mBaseSkillLevel;
      [SerializeField]
      private int? mTurnRemain;
      [SerializeField]
      private int? mUseRemain;
      [SerializeField]
      private int? mExecuteRemain;
      [SerializeField]
      private bool mTimeOfDeathDisable;
      [SerializeField]
      private BL.Unit mUnit;
      [SerializeField]
      private int mKillCount;

      public int effectId
      {
        get => this.mEffectId;
        set
        {
          this.mEffectId = value;
          ++this.revision;
        }
      }

      public int baseSkillId
      {
        get => this.mBaseSkillId;
        set
        {
          this.mBaseSkillId = value;
          ++this.revision;
        }
      }

      public int baseSkillLevel
      {
        get => this.mBaseSkillLevel;
        set
        {
          this.mBaseSkillLevel = value;
          ++this.revision;
        }
      }

      public int? turnRemain
      {
        get => this.mTurnRemain;
        set
        {
          this.mTurnRemain = value;
          ++this.revision;
        }
      }

      public int? useRemain
      {
        get => this.mUseRemain;
        set
        {
          this.mUseRemain = value;
          ++this.revision;
        }
      }

      public int? executeRemain
      {
        get => this.mExecuteRemain;
        set
        {
          this.mExecuteRemain = value;
          ++this.revision;
        }
      }

      public bool timeOfDeathDisable
      {
        get => this.mTimeOfDeathDisable;
        set
        {
          this.mTimeOfDeathDisable = value;
          ++this.revision;
        }
      }

      public BL.Unit unit
      {
        get => this.mUnit;
        set
        {
          this.mUnit = value;
          ++this.revision;
        }
      }

      public int killCount
      {
        get => this.mKillCount;
        set
        {
          this.mKillCount = value;
          ++this.revision;
        }
      }

      public BattleskillEffect effect => MasterData.BattleskillEffect[this.effectId];

      public BattleskillSkill baseSkill => MasterData.BattleskillSkill[this.baseSkillId];

      public bool effectEnded
      {
        get
        {
          if (this.useRemain.HasValue && this.useRemain.Value == 0 || this.turnRemain.HasValue && this.turnRemain.Value == 0 || this.executeRemain.HasValue && this.executeRemain.Value == 0)
            return true;
          return this.timeOfDeathDisable && this.unit != null && this.unit.isDead;
        }
      }

      public bool deathDisable => this.unit != null && this.timeOfDeathDisable && this.unit.isDead;

      public static BL.SkillEffect FromMasterData(
        BL.Unit unit,
        BattleskillEffect effect,
        BattleskillSkill skill,
        int level)
      {
        return new BL.SkillEffect()
        {
          effectId = effect.ID,
          baseSkillId = skill.ID,
          baseSkillLevel = level,
          turnRemain = effect.use_turn,
          useRemain = effect.use_count,
          unit = unit,
          timeOfDeathDisable = skill.time_of_death_skill_disable,
          executeRemain = new int?(),
          killCount = 0
        };
      }

      public static BL.SkillEffect FromMasterData(
        BattleskillEffect effect,
        BattleskillSkill skill,
        int level)
      {
        BL.SkillEffect skillEffect = new BL.SkillEffect();
        skillEffect.effectId = effect.ID;
        skillEffect.baseSkillId = skill.ID;
        skillEffect.baseSkillLevel = level;
        skillEffect.useRemain = effect.use_count;
        skillEffect.timeOfDeathDisable = skill.time_of_death_skill_disable;
        skillEffect.unit = (BL.Unit) null;
        skillEffect.killCount = 0;
        if (skill.skill_type == BattleskillSkillType.ailment)
        {
          skillEffect.turnRemain = new int?();
          skillEffect.executeRemain = effect.use_turn;
        }
        else
        {
          skillEffect.turnRemain = effect.use_turn;
          skillEffect.executeRemain = new int?();
        }
        return skillEffect;
      }

      public static BL.SkillEffect FromRecovery(RecoverySkillEffect rse)
      {
        return new BL.SkillEffect()
        {
          effectId = rse.effectId,
          baseSkillId = rse.skillId,
          baseSkillLevel = rse.level,
          turnRemain = rse.turnRemain,
          useRemain = rse.useRemain,
          killCount = rse.killCount,
          timeOfDeathDisable = MasterData.BattleskillSkill[rse.skillId].time_of_death_skill_disable,
          unit = (BL.Unit) null
        };
      }
    }

    [Serializable]
    public class SkillEffectList : BL.ModelBase
    {
      [SerializeField]
      private List<BL.SkillEffect> effects = new List<BL.SkillEffect>();
      [NonSerialized]
      private AssocList<int, List<BL.SkillEffect>> effectDic;

      public bool HasAilment
      {
        get
        {
          foreach (BL.SkillEffect effect in this.effects)
          {
            if (effect.baseSkill.skill_type == BattleskillSkillType.ailment)
              return true;
          }
          return false;
        }
      }

      private void InitEffects()
      {
        if (this.effectDic != null)
          return;
        this.effectDic = new AssocList<int, List<BL.SkillEffect>>();
        foreach (BL.SkillEffect effect in this.effects)
        {
          int id = effect.effect.effect_logic.ID;
          if (!this.effectDic.ContainsKey(id))
            this.effectDic.Add(id, new List<BL.SkillEffect>());
          this.effectDic[id].Add(effect);
        }
      }

      private List<BL.SkillEffect> GetEffects(BattleskillEffectLogicEnum e)
      {
        if (this.effectDic == null)
        {
          this.effectDic = new AssocList<int, List<BL.SkillEffect>>();
          foreach (BL.SkillEffect effect in this.effects)
          {
            int id = effect.effect.effect_logic.ID;
            if (!this.effectDic.ContainsKey(id))
              this.effectDic.Add(id, new List<BL.SkillEffect>());
            this.effectDic[id].Add(effect);
          }
        }
        List<BL.SkillEffect> skillEffectList;
        return !this.effectDic.TryGetValue((int) e, out skillEffectList) ? new List<BL.SkillEffect>() : skillEffectList;
      }

      private void AddEffect(BL.SkillEffect effect)
      {
        int id = effect.effect.effect_logic.ID;
        List<BL.SkillEffect> skillEffectList;
        if (!this.effectDic.TryGetValue(id, out skillEffectList))
        {
          skillEffectList = new List<BL.SkillEffect>();
          this.effectDic.Add(id, skillEffectList);
        }
        skillEffectList.Add(effect);
      }

      public bool HasEffect(BL.SkillEffect effect)
      {
        if (this.HasEffect(effect.baseSkill))
        {
          foreach (BL.SkillEffect effect1 in this.effects)
          {
            if (effect1.effect.ID == effect.effect.ID)
              return true;
          }
        }
        return false;
      }

      public bool HasEffect(BattleskillSkill skill)
      {
        if (skill.skill_type == BattleskillSkillType.command || skill.skill_type == BattleskillSkillType.release || skill.skill_type == BattleskillSkillType.ailment || skill.skill_type == BattleskillSkillType.item)
        {
          foreach (BL.SkillEffect effect in this.effects)
          {
            if (effect.baseSkill.ID == skill.ID)
              return true;
          }
        }
        return false;
      }

      public void Add(BL.SkillEffect effect)
      {
        if (effect.baseSkill.skill_type == BattleskillSkillType.ailment)
        {
          this.AddAilment(effect);
        }
        else
        {
          if (this.HasEffect(effect))
            return;
          this.InitEffects();
          this.effects.Add(effect);
          this.AddEffect(effect);
          ++this.revision;
        }
      }

      private BL.SkillEffect GetEffect(BL.SkillEffect effect)
      {
        if (this.HasEffect(effect.baseSkill))
        {
          foreach (BL.SkillEffect effect1 in this.effects)
          {
            if (effect1.effect.ID == effect.effect.ID)
              return effect1;
          }
        }
        return (BL.SkillEffect) null;
      }

      private void AddAilment(BL.SkillEffect effect)
      {
        BL.SkillEffect effect1 = this.GetEffect(effect);
        if (effect1 == null)
        {
          this.InitEffects();
          this.effects.Add(effect);
          this.AddEffect(effect);
          ++this.revision;
        }
        else
        {
          if (!effect.executeRemain.HasValue || !effect1.executeRemain.HasValue || effect.executeRemain.Value <= effect1.executeRemain.Value)
            return;
          effect1.executeRemain = new int?(effect.executeRemain.Value);
          ++this.revision;
        }
      }

      public bool HasAilmentEffectLogic(params BattleskillEffectLogicEnum[] effectLogic)
      {
        return this.effects.Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => ((IEnumerable<BattleskillEffectLogicEnum>) effectLogic).Any<BattleskillEffectLogicEnum>((Func<BattleskillEffectLogicEnum, bool>) (y => y == x.effect.effect_logic.Enum))));
      }

      public bool IsSealedSkill(int skill_id)
      {
        return this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.Enum == BattleskillEffectLogicEnum.seal)).Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillSkill battleskillSkill;
          if (MasterData.BattleskillSkill.TryGetValue(skill_id, out battleskillSkill))
          {
            int num1 = x.effect.GetInt(nameof (skill_id));
            if (num1 > 0 && num1 == skill_id)
              return true;
            int num2 = x.effect.GetInt("skill_type");
            if (num2 > 0 && (BattleskillSkillType) num2 == battleskillSkill.skill_type || num1 == 0 && num2 == 0)
              return true;
          }
          return false;
        }));
      }

      public void RemoveEffect(int logic) => this.Clean(logic);

      public void RemoveEffect(BL.Unit invocationUnit)
      {
        foreach (BL.SkillEffect skillEffect in this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.unit != null && x.unit == invocationUnit)).ToList<BL.SkillEffect>())
          this.effects.Remove(skillEffect);
      }

      public void RemoveAilmentEffect()
      {
        foreach (int logic in this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.baseSkill.skill_type == BattleskillSkillType.ailment)).Select<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (x => (int) x.effect.effect_logic.Enum)))
          this.RemoveEffect(logic);
      }

      public void TurnStart(int turn)
      {
        foreach (BL.SkillEffect effect in this.effects)
        {
          if (effect.turnRemain.HasValue)
            effect.turnRemain = new int?(effect.turnRemain.Value - 1);
        }
        this.Clean();
      }

      public void PhaseStart() => this.Clean();

      public bool AilmentExecuted()
      {
        bool flag = false;
        foreach (BL.SkillEffect skillEffect in this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.executeRemain.HasValue)))
        {
          skillEffect.executeRemain = new int?(skillEffect.executeRemain.Value - 1);
          flag = true;
        }
        this.Clean();
        return flag;
      }

      private void Clean()
      {
        this.effects = this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !effect.effectEnded && !effect.deathDisable)).ToList<BL.SkillEffect>();
        this.effectDic = (AssocList<int, List<BL.SkillEffect>>) null;
        this.InitEffects();
        ++this.revision;
      }

      private void Clean(int logic)
      {
        this.effects = this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => effect.effect.effect_logic.Enum != (BattleskillEffectLogicEnum) logic)).ToList<BL.SkillEffect>();
        this.effectDic = (AssocList<int, List<BL.SkillEffect>>) null;
        this.InitEffects();
        ++this.revision;
      }

      public IEnumerable<BL.SkillEffect> Where(BattleskillEffectTag tag1)
      {
        return this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.HasTag(tag1)));
      }

      public IEnumerable<BL.SkillEffect> Where(BattleskillEffectTag tag1, BattleskillEffectTag tag2)
      {
        return this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.HasTag(tag1) && x.effect.effect_logic.HasTag(tag2)));
      }

      public IEnumerable<BL.SkillEffect> Where(
        BattleskillEffectTag tag1,
        BattleskillEffectTag tag2,
        BattleskillEffectTag tag3)
      {
        return this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.HasTag(tag1) && x.effect.effect_logic.HasTag(tag2) && x.effect.effect_logic.HasTag(tag3)));
      }

      public IEnumerable<BL.SkillEffect> Where(BattleskillEffectLogicEnum e)
      {
        return (IEnumerable<BL.SkillEffect>) this.GetEffects(e);
      }

      [DebuggerHidden]
      public IEnumerable<BL.SkillEffect> Where(
        BattleskillEffectLogicEnum e,
        Func<BL.SkillEffect, bool> f)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        BL.SkillEffectList.\u003CWhere\u003Ec__Iterator21 whereCIterator21 = new BL.SkillEffectList.\u003CWhere\u003Ec__Iterator21()
        {
          e = e,
          f = f,
          \u003C\u0024\u003Ee = e,
          \u003C\u0024\u003Ef = f,
          \u003C\u003Ef__this = this
        };
        // ISSUE: reference to a compiler-generated field
        whereCIterator21.\u0024PC = -2;
        return (IEnumerable<BL.SkillEffect>) whereCIterator21;
      }

      [DebuggerHidden]
      public IEnumerable<BL.SkillEffect> WhereAndGroupBy(
        BattleskillEffectLogicEnum e,
        Func<List<BL.SkillEffect>, BL.SkillEffect> f,
        Func<List<BL.SkillEffect>, List<BL.SkillEffect>> enabled)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        BL.SkillEffectList.\u003CWhereAndGroupBy\u003Ec__Iterator22 groupByCIterator22 = new BL.SkillEffectList.\u003CWhereAndGroupBy\u003Ec__Iterator22()
        {
          e = e,
          enabled = enabled,
          f = f,
          \u003C\u0024\u003Ee = e,
          \u003C\u0024\u003Eenabled = enabled,
          \u003C\u0024\u003Ef = f,
          \u003C\u003Ef__this = this
        };
        // ISSUE: reference to a compiler-generated field
        groupByCIterator22.\u0024PC = -2;
        return (IEnumerable<BL.SkillEffect>) groupByCIterator22;
      }

      public IEnumerable<BattleskillSkill> Where(BattleskillSkillType skillType)
      {
        HashSet<BattleskillSkill> battleskillSkillSet = new HashSet<BattleskillSkill>();
        foreach (BL.SkillEffect effect in this.effects)
        {
          if (effect.baseSkill.skill_type == skillType)
            battleskillSkillSet.Add(effect.baseSkill);
        }
        return (IEnumerable<BattleskillSkill>) battleskillSkillSet;
      }

      public List<Tuple<BattleskillSkill, int?>> GetAilmentData()
      {
        Dictionary<BattleskillSkill, int?> source = new Dictionary<BattleskillSkill, int?>();
        foreach (BL.SkillEffect effect in this.effects)
        {
          if (effect.baseSkill.skill_type == BattleskillSkillType.ailment)
          {
            if (!source.ContainsKey(effect.baseSkill))
            {
              source.Add(effect.baseSkill, effect.executeRemain);
            }
            else
            {
              int? nullable = source[effect.baseSkill];
              int num;
              if (nullable.HasValue)
              {
                int? executeRemain = effect.executeRemain;
                if (executeRemain.HasValue)
                {
                  num = nullable.Value < executeRemain.Value ? 1 : 0;
                  goto label_9;
                }
              }
              num = 0;
label_9:
              if (num != 0)
                source[effect.baseSkill] = effect.executeRemain;
            }
          }
        }
        return source.Select<KeyValuePair<BattleskillSkill, int?>, Tuple<BattleskillSkill, int?>>((Func<KeyValuePair<BattleskillSkill, int?>, Tuple<BattleskillSkill, int?>>) (x => new Tuple<BattleskillSkill, int?>(x.Key, x.Value))).ToList<Tuple<BattleskillSkill, int?>>();
      }

      public override string ToString()
      {
        string empty = string.Empty;
        foreach (BL.SkillEffect effect in this.effects)
          empty += string.Format("- エフェクト{0}({1}) -- スキル{2}({3})より\n", (object) effect.effect.effect_logic.ID, (object) effect.effect.effect_logic.name, (object) effect.baseSkill.ID, (object) effect.baseSkill.name);
        return empty;
      }

      public List<BL.SkillEffect> All() => this.effects;

      public void AddKillCount(int addCount)
      {
        foreach (BL.SkillEffect effect in this.effects)
          effect.killCount += addCount;
      }

      public void SetKillCount(int setCount)
      {
        foreach (BL.SkillEffect effect in this.effects)
          effect.killCount = setCount;
      }

      public int GetCompleteCount()
      {
        IEnumerable<BL.SkillEffect> source = this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.Enum == BattleskillEffectLogicEnum.again));
        return source.Count<BL.SkillEffect>() > 0 ? Mathf.Max(source.Max<BL.SkillEffect>((Func<BL.SkillEffect, int>) (x => x.effect.GetInt("complete_count"))), 1) : 1;
      }

      public int GetActionCount()
      {
        IEnumerable<BL.SkillEffect> source = this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.Enum == BattleskillEffectLogicEnum.again));
        return source.Count<BL.SkillEffect>() > 0 ? Mathf.Max(source.Max<BL.SkillEffect>((Func<BL.SkillEffect, int>) (x => x.effect.GetInt("action_count"))), 1) : 1;
      }

      public int GetCantChageCurrentActionCount()
      {
        IEnumerable<BL.SkillEffect> source = this.effects.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.Enum == BattleskillEffectLogicEnum.again));
        return source.Count<BL.SkillEffect>() > 0 ? Mathf.Max(source.Max<BL.SkillEffect>((Func<BL.SkillEffect, int>) (x => x.effect.GetInt("cant_chage_action_count"))), 0) : 0;
      }
    }

    public class ExecuteSkillEffectResult
    {
      public BattleskillSkill skill;
      public List<BL.UnitPosition> targets = new List<BL.UnitPosition>();
      public List<int> target_hps = new List<int>();
      public List<int> target_prev_hps = new List<int>();
    }

    public class BattleSkillResultNetwork : ActionResultNetwork
    {
      public int? mSkillID;
      public int? mInvocation;
      public List<int> mTargets;
    }

    [Serializable]
    public class BattleSkillResult : ActionResult
    {
      [SerializeField]
      private BL.Skill mSkill;
      [SerializeField]
      private BL.Unit mInvocation;
      [SerializeField]
      private List<BL.Unit> mTargets;

      public BattleSkillResult()
      {
        this.mSkill = (BL.Skill) null;
        this.mInvocation = (BL.Unit) null;
        this.mTargets = (List<BL.Unit>) null;
      }

      public override ActionResultNetwork ToNetworkLocal(BL env)
      {
        List<int> intList = new List<int>();
        if (this.mTargets != null)
        {
          foreach (BL.Unit mTarget in this.mTargets)
          {
            int? network = mTarget.ToNetwork(env);
            if (network.HasValue)
              intList.Add(network.Value);
          }
        }
        return (ActionResultNetwork) new BL.BattleSkillResultNetwork()
        {
          mSkillID = new int?(this.mSkill.id),
          mInvocation = (this.mInvocation != null ? this.mInvocation.ToNetwork(env) : new int?()),
          mTargets = intList
        };
      }

      public static ActionResult FromNetwork(ActionResultNetwork nnw, BL env)
      {
        BL.BattleSkillResultNetwork nw = nnw as BL.BattleSkillResultNetwork;
        if (nw == null)
          return (ActionResult) null;
        BL.Unit unit = BL.Unit.FromNetwork(nw.mInvocation, env);
        BL.Skill skill;
        if (unit.hasOugi)
        {
          int id = unit.ougi.id;
          int? mSkillId = nw.mSkillID;
          int valueOrDefault = mSkillId.GetValueOrDefault();
          if ((id != valueOrDefault ? 0 : (mSkillId.HasValue ? 1 : 0)) != 0)
          {
            skill = unit.ougi;
            goto label_6;
          }
        }
        skill = ((IEnumerable<BL.Skill>) unit.skills).Where<BL.Skill>((Func<BL.Skill, bool>) (p =>
        {
          int id = p.id;
          int? mSkillId = nw.mSkillID;
          int valueOrDefault = mSkillId.GetValueOrDefault();
          return id == valueOrDefault && mSkillId.HasValue;
        })).FirstOrDefault<BL.Skill>();
label_6:
        if (skill == null)
          return (ActionResult) null;
        return (ActionResult) new BL.BattleSkillResult()
        {
          mSkill = skill,
          mInvocation = unit,
          mTargets = nw.mTargets.Select<int, BL.Unit>((Func<int, BL.Unit>) (t => BL.Unit.FromNetwork(new int?(t), env))).ToList<BL.Unit>()
        };
      }

      public static BL.BattleSkillResult createBattleSkillResult(
        int skill_id,
        BL.Unit invocation,
        List<BL.Unit> targets,
        int nowTurnCount)
      {
        BL.BattleSkillResult battleSkillResult = (BL.BattleSkillResult) null;
        BL.Skill skill = !invocation.hasOugi || invocation.ougi.id != skill_id ? ((IEnumerable<BL.Skill>) invocation.skills).SingleOrDefault<BL.Skill>((Func<BL.Skill, bool>) (x => x.id == skill_id)) : invocation.ougi;
        if (skill != null)
        {
          if (skill.isCommand)
          {
            if (skill.remain.HasValue)
            {
              if (skill.remain.HasValue)
              {
                int? remain = skill.remain;
                if ((!remain.HasValue ? 0 : (remain.Value > 0 ? 1 : 0)) != 0)
                  goto label_6;
              }
            }
            else
              goto label_6;
          }
          if (!skill.isOugi || skill.useTurn - nowTurnCount > 0)
            goto label_7;
label_6:
          battleSkillResult = new BL.BattleSkillResult();
          battleSkillResult.mSkill = skill;
          battleSkillResult.mInvocation = invocation;
          battleSkillResult.mTargets = targets;
        }
label_7:
        return battleSkillResult;
      }

      public BL.Skill skill => this.mSkill;

      public BL.Unit invocation => this.mInvocation;

      public List<BL.Unit> targets => this.mTargets;
    }

    public enum Phase
    {
      unset = -2, // 0xFFFFFFFE
      none = -1, // 0xFFFFFFFF
      player_start = 0,
      neutral_start = 1,
      enemy_start = 2,
      player = 3,
      neutral = 4,
      enemy = 5,
      player_end = 6,
      neutral_end = 7,
      enemy_end = 8,
      turn_initialize = 10, // 0x0000000A
      win_finalize = 11, // 0x0000000B
      finalize = 12, // 0x0000000C
      suspend = 13, // 0x0000000D
      player_start_post = 15, // 0x0000000F
      neutral_start_post = 16, // 0x00000010
      enemy_start_post = 17, // 0x00000011
      all_dead_player = 20, // 0x00000014
      all_dead_neutral = 21, // 0x00000015
      all_dead_enemy = 22, // 0x00000016
      stageclear = 30, // 0x0000001E
      gameover = 31, // 0x0000001F
      pvp_move_unit_waiting = 40, // 0x00000028
      pvp_player_start = 41, // 0x00000029
      pvp_enemy_start = 42, // 0x0000002A
      pvp_result = 43, // 0x0000002B
      pvp_disposition = 44, // 0x0000002C
      pvp_start_init = 45, // 0x0000002D
      pvp_exception = 50, // 0x00000032
      pvp_restart = 51, // 0x00000033
      wave_start = 60, // 0x0000003C
      battle_start = 100, // 0x00000064
      battle_start_init = 101, // 0x00000065
    }

    [Serializable]
    public class PhaseState : BL.ModelBase
    {
      [SerializeField]
      private BL.Phase mState;
      [SerializeField]
      private int mTurnCount;
      [SerializeField]
      private int mAbsoluteTurnCount;

      public PhaseState()
      {
        this.mState = BL.Phase.battle_start;
        this.mAbsoluteTurnCount = this.mTurnCount = 0;
      }

      public BL.Phase state => this.mState;

      public void setStateWith(BL.Phase state, BL env, System.Action f)
      {
        if (this.mState == state)
          return;
        this.mState = state;
        if (state == BL.Phase.turn_initialize)
        {
          ++this.mTurnCount;
          ++this.mAbsoluteTurnCount;
          env.firstCompleted.value = false;
          foreach (BL.UnitPosition unitPosition in env.unitPositions.value)
          {
            unitPosition.unit.skillEffects.TurnStart(this.mAbsoluteTurnCount);
            unitPosition.unit.commit();
            unitPosition.commit();
          }
          env.attackStatusCacheGC();
        }
        if (state == BL.Phase.player_start || state == BL.Phase.enemy_start)
        {
          foreach (BL.UnitPosition unitPosition in env.unitPositions.value)
          {
            unitPosition.unit.skillEffects.PhaseStart();
            unitPosition.unit.commit();
            unitPosition.commit();
          }
        }
        ++this.revision;
        f();
      }

      public int turnCount => this.mTurnCount;

      public int absoluteTurnCount => this.mAbsoluteTurnCount;

      public void turnReset() => this.mTurnCount = 0;
    }

    public enum StoryType
    {
      battle_start,
      first_turn_start,
      battle_win,
      spawn_unit,
      unit_for_unit,
      unit_in_panel,
      unit_dead,
      duel_start,
      duel_unit_dead,
      turn_start,
      unit_in_area,
      defeat_player,
    }

    public enum StoryPhase
    {
      neutral,
      offense,
      defense,
    }

    [Serializable]
    public class Story : BL.ModelBase
    {
      [SerializeField]
      private int mScriptId;
      [SerializeField]
      private BL.StoryType mType;
      [SerializeField]
      private object[] mDatas;
      [SerializeField]
      private bool mIsRead;

      public Story(int id, BL.StoryType type, object[] datas)
      {
        this.mScriptId = id;
        this.mType = type;
        this.mDatas = datas;
        this.isRead = false;
        ++this.revision;
      }

      public int scriptId => this.mScriptId;

      public BL.StoryType type => this.mType;

      public object[] datas => this.mDatas;

      public bool isRead
      {
        get => this.mIsRead;
        set
        {
          this.mIsRead = value;
          ++this.revision;
        }
      }
    }

    public class UnitParameterCache : IDisposable
    {
      private List<BL.UnitPosition> units;
      private BL env;

      public UnitParameterCache(BL env_)
      {
        this.env = env_;
        this.units = this.env.unitPositions.value;
        this.units.ForEach((Action<BL.UnitPosition>) (x => x.unit.enableCache()));
      }

      public void Dispose()
      {
        this.units.ForEach((Action<BL.UnitPosition>) (x => x.unit.Dispose()));
      }
    }

    [Serializable]
    public class DuelHistory
    {
      [SerializeField]
      public int inflictTotalDamage;
      [SerializeField]
      public int sufferTotalDamage;
      [SerializeField]
      public int criticalCount;
      [SerializeField]
      public int inflictMaxDamage;
      [SerializeField]
      public int weekElementAttackCount;
      [SerializeField]
      public int weekKindAttackCount;
      [SerializeField]
      public int targetUnitID;
    }

    [Serializable]
    public class Unit : BL.ModelBase, IDisposable, BL.ISkillEffectListUnit
    {
      [SerializeField]
      private BL.DuelHistory[] mDuelHistory;
      [SerializeField]
      private int mSpecificId;
      [SerializeField]
      private int mUnitId;
      [SerializeField]
      private PlayerUnit mPlayerUnit;
      [SerializeField]
      private int mIndex;
      [SerializeField]
      private bool mFriend;
      [SerializeField]
      private int mAIScorePatternID;
      [SerializeField]
      private int mAIMoveGroup;
      [SerializeField]
      private int mAIMoveGroupOrder;
      [SerializeField]
      private int mAIMoveTargetX;
      [SerializeField]
      private int mAIMoveTargetY;
      [SerializeField]
      private object mAIExtension;
      [SerializeField]
      private int mLv;
      [SerializeField]
      private int mHp;
      [SerializeField]
      private BL.Weapon mWeapon;
      [SerializeField]
      private bool mGearLeftHand;
      [SerializeField]
      private bool mGearDualWield;
      [SerializeField]
      private BL.Skill mOugi;
      [SerializeField]
      private BL.Skill[] mArySkill;
      [SerializeField]
      private BL.Skill[] mDuelSkill;
      [SerializeField]
      private BL.MagicBullet[] mAryMB;
      [SerializeField]
      private int mSpawnTurn;
      [SerializeField]
      private int[] save_equiped_gears;
      [SerializeField]
      private bool mIsDead;
      [SerializeField]
      private bool mIsSpawned;
      [SerializeField]
      private int mSkillfullWeapon;
      [SerializeField]
      private int mSkillfullShild;
      [SerializeField]
      private BL.SkillEffectList mSkillEffects = new BL.SkillEffectList();
      [SerializeField]
      private BL.DropData mDrop;
      [SerializeField]
      private int mDropMoney;
      [SerializeField]
      private int mPvpPoint;
      [SerializeField]
      private int mPvpRespawnCount;
      [SerializeField]
      private int mAttackCount;
      [SerializeField]
      private int mAttackDamage;
      [SerializeField]
      private int mKillCount;
      [SerializeField]
      private int mDeadCount;
      [SerializeField]
      private BL.Unit mKilledBy;
      [SerializeField]
      private int mOverkillDamage;
      [SerializeField]
      private int mReceivedDamage;
      [NonSerialized]
      private int mParameterCacheCount;
      [NonSerialized]
      private Judgement.BattleParameter mParameterCache;
      [SerializeField]
      private bool mIsPlayerControl;
      private int[] mAttackRange = new int[2];
      private int[] mHealRange = new int[2];
      private int[] mNonRange = new int[0];
      [NonSerialized]
      private BL.ForceID[] mTargetForce;

      public int? ToNetwork(BL env) => env.getUnitPosition(this).ToNetwork(env);

      public static BL.Unit FromNetwork(int? nw, BL env)
      {
        return !nw.HasValue ? (BL.Unit) null : BL.UnitPosition.FromNetwork(nw, env).unit;
      }

      public BL.DuelHistory[] duelHistory
      {
        get => this.mDuelHistory;
        set
        {
          this.mDuelHistory = value;
          ++this.revision;
        }
      }

      public int specificId
      {
        get => this.mSpecificId;
        set
        {
          this.mSpecificId = value;
          ++this.revision;
        }
      }

      public int unitId
      {
        get => this.mUnitId;
        set
        {
          this.mUnitId = value;
          ++this.revision;
        }
      }

      public PlayerUnit playerUnit
      {
        get => this.mPlayerUnit;
        set
        {
          this.mPlayerUnit = value;
          ++this.revision;
        }
      }

      public int index
      {
        get => this.mIndex;
        set
        {
          this.mIndex = value;
          ++this.revision;
        }
      }

      public bool is_leader => this.index == 0;

      public bool is_helper => this.index == 5;

      public bool friend
      {
        get => this.mFriend;
        set
        {
          this.mFriend = value;
          ++this.revision;
        }
      }

      public UnitUnit unit => MasterData.UnitUnit[this.mUnitId];

      public UnitJob job => this.unit.job;

      public object aiExtension
      {
        get => this.mAIExtension;
        set
        {
          this.mAIExtension = value;
          ++this.revision;
        }
      }

      public BL.Panel GetTargetPanel(BL env)
      {
        return env.getFieldPanel(this.mAIMoveTargetY, this.mAIMoveTargetX);
      }

      public int lv
      {
        get => this.mLv;
        set
        {
          this.mLv = value;
          ++this.revision;
        }
      }

      public int hp
      {
        get => this.mHp;
        set
        {
          this.mHp = Mathf.Max(Mathf.Min(value, this.parameter.Hp), 0);
          ++this.revision;
        }
      }

      public Judgement.BattleParameter parameter => this.mParameterCache ?? this.calcParameter();

      public Judgement.BattleParameter calcParameter()
      {
        return Judgement.BattleParameter.FromBeUnit(this);
      }

      public void setParameter(Judgement.BattleParameter parameter)
      {
        this.mParameterCache = parameter;
      }

      public BL.Unit enableCache()
      {
        ++this.mParameterCacheCount;
        this.mParameterCache = this.mParameterCache ?? this.calcParameter();
        return this;
      }

      public void Dispose()
      {
        --this.mParameterCacheCount;
        if (this.mParameterCacheCount == 0)
        {
          this.mParameterCache = (Judgement.BattleParameter) null;
        }
        else
        {
          if (this.mParameterCacheCount >= 0)
            return;
          Debug.LogWarning((object) ("Illegal decrement mParameterCacheCount=" + (object) this.mParameterCacheCount));
        }
      }

      public int AIMoveTargetX
      {
        get => this.mAIMoveTargetX;
        set
        {
          this.mAIMoveTargetX = value;
          ++this.revision;
        }
      }

      public int AIMoveTargetY
      {
        get => this.mAIMoveTargetY;
        set
        {
          this.mAIMoveTargetY = value;
          ++this.revision;
        }
      }

      public int AIMoveGroup
      {
        get => this.mAIMoveGroup;
        set
        {
          this.mAIMoveGroup = value;
          ++this.revision;
        }
      }

      public bool IsAIMoveGroup => this.mAIMoveGroup > 0;

      public int AIMoveGroupOrder
      {
        get => this.mAIMoveGroupOrder;
        set
        {
          this.mAIMoveGroupOrder = value;
          ++this.revision;
        }
      }

      public BL.Weapon weapon
      {
        get => this.mWeapon;
        set
        {
          this.mWeapon = value;
          ++this.revision;
        }
      }

      public BL.Skill ougi
      {
        get => this.mOugi;
        set
        {
          this.mOugi = value;
          ++this.revision;
        }
      }

      public bool gearLeftHand
      {
        get => this.mGearLeftHand;
        set
        {
          this.mGearLeftHand = value;
          ++this.revision;
        }
      }

      public bool gearDualWield
      {
        get => this.mGearDualWield;
        set
        {
          this.mGearDualWield = value;
          ++this.revision;
        }
      }

      public int spawnTurn
      {
        get => this.mSpawnTurn;
        set
        {
          this.mSpawnTurn = value;
          ++this.revision;
        }
      }

      public int skillfull_weapon
      {
        get => this.mSkillfullWeapon;
        set
        {
          this.mSkillfullWeapon = value;
          ++this.revision;
        }
      }

      public int skillfull_shield
      {
        get => this.mSkillfullShild;
        set
        {
          this.mSkillfullShild = value;
          ++this.revision;
        }
      }

      public BL.Skill[] skills
      {
        get => this.mArySkill;
        set
        {
          this.mArySkill = value;
          ++this.revision;
        }
      }

      public BL.Skill[] duelSkills
      {
        get => this.mDuelSkill;
        set
        {
          this.mDuelSkill = value;
          ++this.revision;
        }
      }

      public BL.MagicBullet[] magicBullets
      {
        get => this.mAryMB;
        set
        {
          this.mAryMB = value;
          ++this.revision;
        }
      }

      public bool isDead => this.mIsDead;

      public bool isSpawned
      {
        get => this.mIsSpawned;
        set => this.mIsSpawned = value;
      }

      public void setIsDead(bool v, BL env)
      {
        if (this.mIsDead == v)
          return;
        this.mIsDead = v;
        ++this.revision;
        if (this.mIsDead)
        {
          ++this.mDeadCount;
        }
        else
        {
          this.mSkillEffects.RemoveAilmentEffect();
          this.mSkillEffects.SetKillCount(0);
        }
        foreach (BL.UnitPosition unitPosition in env.unitPositions.value)
        {
          if (unitPosition.hasPanelsCache)
            unitPosition.clearMovePanelCache();
        }
      }

      public void rebirth(BL env, bool resetHp = true, bool resetCompleted = true)
      {
        BL.UnitPosition unitPosition = env.getUnitPosition(this);
        unitPosition.resetSpawnPosition();
        if (resetHp && this.hp != this.parameter.Hp)
          this.hp = this.parameter.Hp;
        this.setIsDead(false, env);
        if (!resetCompleted)
          return;
        unitPosition.resetOriginalPosition();
        BL.ClassValue<List<BL.UnitPosition>> classValue = env.currentActionUnitsList();
        if (classValue == null || classValue.value.Contains(unitPosition))
          return;
        classValue.value.Add(unitPosition);
        classValue.commit();
      }

      public bool isPlayerControl
      {
        get => this.mIsPlayerControl;
        set
        {
          this.mIsPlayerControl = value;
          ++this.revision;
        }
      }

      public bool hasMapSkill => this.mArySkill.Length > 0;

      public bool hasOugi => this.mOugi != null;

      public BL.DropData drop
      {
        get => this.mDrop;
        set
        {
          this.mDrop = value;
          ++this.revision;
        }
      }

      public bool hasDrop => this.mDrop != null;

      public int dropMoney
      {
        get => this.mDropMoney;
        set
        {
          this.mDropMoney = value;
          ++this.revision;
        }
      }

      public int attackCount
      {
        get => this.mAttackCount;
        set
        {
          this.mAttackCount = value;
          ++this.revision;
        }
      }

      public int attackDamage
      {
        get => this.mAttackDamage;
        set
        {
          this.mAttackDamage = value;
          ++this.revision;
        }
      }

      public int killCount
      {
        get => this.mKillCount;
        set
        {
          this.mKillCount = value;
          ++this.revision;
        }
      }

      public BL.Unit killedBy
      {
        get => this.mKilledBy;
        set
        {
          this.mKilledBy = value;
          ++this.revision;
        }
      }

      public int overkillDamage
      {
        get => this.mOverkillDamage;
        set
        {
          this.mOverkillDamage = value;
          ++this.revision;
        }
      }

      public int receivedDamage
      {
        get => this.mReceivedDamage;
        set
        {
          this.mReceivedDamage = value;
          ++this.revision;
        }
      }

      public int deadCount
      {
        get => this.mDeadCount;
        set
        {
          this.mDeadCount = value;
          ++this.revision;
        }
      }

      public int pvpPoint
      {
        get => this.mPvpPoint;
        set
        {
          this.mPvpPoint = value;
          ++this.revision;
        }
      }

      public int pvpRespawnCount
      {
        get => this.mPvpRespawnCount;
        set
        {
          this.mPvpRespawnCount = value;
          ++this.revision;
        }
      }

      public int[] attackRange
      {
        get
        {
          int num1 = 1000000;
          int num2 = 0;
          int[] mAttackRange = this.mAttackRange;
          mAttackRange[0] = num1;
          mAttackRange[1] = num2;
          foreach (BL.MagicBullet magicBullet in this.mAryMB)
          {
            if (magicBullet.isAttack && this.mHp > magicBullet.cost)
            {
              if (mAttackRange[0] > magicBullet.minRange)
                mAttackRange[0] = magicBullet.minRange;
              if (mAttackRange[1] < magicBullet.maxRange)
                mAttackRange[1] = magicBullet.maxRange;
            }
          }
          BL.Unit.GearRange gearRange = this.gearRange();
          if (mAttackRange[0] > gearRange.Min)
            mAttackRange[0] = gearRange.Min;
          if (mAttackRange[1] < gearRange.Max)
            mAttackRange[1] = gearRange.Max;
          return mAttackRange;
        }
      }

      public BL.Unit.GearRange gearRange()
      {
        IEnumerable<BL.SkillEffect> skillEffects = this.skillEffects.Where(BattleskillEffectLogicEnum.fix_range).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.GetInt("gear_kind_id") == this.mWeapon.gear.kind.ID));
        int minRange = this.mWeapon.gear.min_range;
        int maxRange = this.mWeapon.gear.max_range;
        foreach (BL.SkillEffect skillEffect in skillEffects)
        {
          minRange += skillEffect.effect.GetInt("min_add");
          maxRange += skillEffect.effect.GetInt("max_add");
        }
        return new BL.Unit.GearRange(minRange, maxRange);
      }

      public int[] healRange
      {
        get
        {
          int num1 = 1000000;
          int num2 = 0;
          int[] mHealRange = this.mHealRange;
          mHealRange[0] = num1;
          mHealRange[1] = num2;
          foreach (BL.MagicBullet magicBullet in this.mAryMB)
          {
            if (magicBullet.isHeal && this.mHp > magicBullet.cost)
            {
              if (mHealRange[0] > magicBullet.minRange)
                mHealRange[0] = magicBullet.minRange;
              if (mHealRange[1] < magicBullet.maxRange)
                mHealRange[1] = magicBullet.maxRange;
            }
          }
          return mHealRange[0] != num1 ? mHealRange : this.mNonRange;
        }
      }

      public BL.ForceID[] targetForce
      {
        get => this.mTargetForce;
        set
        {
          this.mTargetForce = value;
          ++this.revision;
        }
      }

      public BL.SkillEffectList skillEffects
      {
        get => this.mSkillEffects;
        set
        {
          this.mSkillEffects = value;
          ++this.revision;
        }
      }

      public void dumpSkillEffects()
      {
      }

      public void SaveEquipedGears()
      {
        if (this.playerUnit.equip_gear_ids == null)
          return;
        this.save_equiped_gears = new int[this.playerUnit.equip_gear_ids.Length];
        for (int index = 0; index < this.playerUnit.equip_gear_ids.Length; ++index)
        {
          int? equipGearId = this.playerUnit.equip_gear_ids[index];
          this.save_equiped_gears[0] = int.MinValue;
          if (equipGearId.HasValue)
            this.save_equiped_gears[0] = equipGearId.Value;
        }
      }

      public void LoadEquipedGears()
      {
        if (this.save_equiped_gears == null)
          return;
        for (int index = 0; index < this.save_equiped_gears.Length; ++index)
        {
          int saveEquipedGear = this.save_equiped_gears[index];
          this.playerUnit.equip_gear_ids[index] = saveEquipedGear == int.MinValue ? new int?() : new int?(saveEquipedGear);
        }
      }

      public BL.Unit originalUnit => this;

      public bool HasAilment => this.skillEffects.HasAilment;

      public bool IsDontAction
      {
        get
        {
          return this.skillEffects.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_act, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontMove
      {
        get
        {
          return this.skillEffects.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.do_not_move, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontEvasion
      {
        get
        {
          return this.skillEffects.HasAilmentEffectLogic(BattleskillEffectLogicEnum.paralysis, BattleskillEffectLogicEnum.sleep);
        }
      }

      public bool IsDontUseSkill(int skill_id)
      {
        return this.skillEffects.HasAilmentEffectLogic(BattleskillEffectLogicEnum.seal) && this.skillEffects.IsSealedSkill(skill_id);
      }

      public bool HasEnabledSkillEffect(BattleskillEffectLogicEnum logic)
      {
        return this.enabledSkillEffect(logic).Any<BL.SkillEffect>();
      }

      public IEnumerable<BL.SkillEffect> enabledSkillEffect(BattleskillEffectLogicEnum logic)
      {
        return this.skillEffects.Where(logic).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.skill.skill_type != BattleskillSkillType.passive || !this.IsDontUseSkill(x.baseSkillId)));
      }

      [DebuggerHidden]
      public IEnumerator InitAIExtention(LispAILogic ai, byte[] scriptByte = null)
      {
        // ISSUE: object of a compiler-generated type is created
        return (IEnumerator) new BL.Unit.\u003CInitAIExtention\u003Ec__Iterator23()
        {
          scriptByte = scriptByte,
          ai = ai,
          \u003C\u0024\u003EscriptByte = scriptByte,
          \u003C\u0024\u003Eai = ai,
          \u003C\u003Ef__this = this
        };
      }

      public CommonElement GetElement()
      {
        CommonElement element = CommonElement.none;
        IEnumerable<BL.Skill> source = ((IEnumerable<BL.Skill>) this.duelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element))));
        if (source.Count<BL.Skill>() > 0)
          element = source.First<BL.Skill>().skill.element;
        return element;
      }

      public class GearRange
      {
        public readonly int Min;
        public readonly int Max;

        public GearRange(int min, int max)
        {
          this.Min = min;
          this.Max = max;
        }
      }
    }

    public enum ForceID
    {
      none = -1, // 0xFFFFFFFF
      player = 0,
      neutral = 1,
      enemy = 2,
    }

    [Serializable]
    public class CurrentUnit : BL.ModelBase
    {
      [SerializeField]
      private BL.Unit mUnit;

      public BL.Unit unit => this.mUnit;

      public void setCurrentWith(BL.Unit unit, BL env, Action<BL.UnitPosition> f)
      {
        if (this.mUnit == unit)
          return;
        BL.UnitPosition unitPosition = env.getUnitPosition(this.mUnit);
        if (unitPosition != null && unitPosition.cantChangeCurrent)
          return;
        f(unitPosition);
        this.mUnit = unit;
        ++this.revision;
      }
    }

    [Serializable]
    public class Weapon : BL.ModelBase
    {
      [SerializeField]
      private int mGearId;

      public int gearId
      {
        get => this.mGearId;
        set
        {
          this.mGearId = value;
          ++this.revision;
        }
      }

      public GearGear gear => MasterData.GearGear[this.mGearId];
    }

    [Serializable]
    public class ModelBase : IComparable
    {
      public int revision;
      [SerializeField]
      private bool mIsEnable = true;

      public bool isEnable
      {
        get => this.mIsEnable;
        set
        {
          this.mIsEnable = value;
          ++this.revision;
        }
      }

      public int commit() => this.revision++;

      public int CompareTo(object o) => !(o is BL.ModelBase modelBase) || modelBase != this ? 1 : 0;
    }

    [Serializable]
    public class StructValue<T> : BL.ModelBase where T : struct
    {
      [SerializeField]
      private T mValue;

      public StructValue()
      {
      }

      public StructValue(T v) => this.mValue = v;

      public T value
      {
        get => this.mValue;
        set
        {
          this.mValue = value;
          ++this.revision;
        }
      }
    }

    [Serializable]
    public class ClassValue<T> : BL.ModelBase where T : class
    {
      [SerializeField]
      private T mValue;

      public ClassValue(T v) => this.mValue = v;

      public T value
      {
        get => this.mValue;
        set
        {
          if ((object) this.mValue == (object) value)
            return;
          this.mValue = value;
          ++this.revision;
        }
      }
    }

    public class BattleModified<T> where T : BL.ModelBase
    {
      public int revision;
      public T value;

      public BattleModified(T v)
      {
        if ((object) v != null)
          this.revision = v.revision - 1;
        this.value = v;
      }

      public bool isChanged => this.value.isEnable && this.value.revision != this.revision;

      public void commit() => this.revision = this.value.commit();

      public void notifyChanged() => this.revision = this.value.revision - 1;

      public bool isChangedOnce()
      {
        bool isChanged = this.isChanged;
        if (isChanged)
          this.revision = this.value.revision;
        return isChanged;
      }
    }

    public interface ISkillEffectListUnit
    {
      int hp { get; set; }

      BL.Unit originalUnit { get; }

      BL.SkillEffectList skillEffects { get; }

      bool HasAilment { get; }

      bool IsDontAction { get; }

      bool IsDontMove { get; }

      bool IsDontEvasion { get; }

      bool IsDontUseSkill(int skill_id);

      bool HasEnabledSkillEffect(BattleskillEffectLogicEnum logic);

      IEnumerable<BL.SkillEffect> enabledSkillEffect(BattleskillEffectLogicEnum logic);
    }
  }
}
