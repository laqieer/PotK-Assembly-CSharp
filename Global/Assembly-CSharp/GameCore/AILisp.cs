// Decompiled with JetBrains decompiler
// Type: GameCore.AILisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UniLinq;

#nullable disable
namespace GameCore
{
  public class AILisp : IELisp
  {
    private BL battleEnv;
    private HashSet<BL.Panel> dangerPanels;
    private Dictionary<string, object> battleVariables = new Dictionary<string, object>();
    private BL.AIUnit mCurrentUnit;
    private BL.AIUnit mCurrentTarget;
    private BL.Panel mCurrentPanel;
    private AttackStatus mCurrentAttackStatus;

    public AILisp(BL e, SExpNumber n)
      : base(n)
    {
      this.init(e);
      this.timer = new Stopwatch();
      this.thresholdMS = 50L;
    }

    public void clearCache() => this.dangerPanels = (HashSet<BL.Panel>) null;

    private void init(BL e)
    {
      this.battleEnv = e;
      this.defun("unit-list", (Func<Cons, object>) (args => SExp.toLispList<BL.AIUnit>((IEnumerable<BL.AIUnit>) this.battleEnv.aiUnits.value)));
      this.defun("get-value", (Func<Cons, object>) (args =>
      {
        SExpString name = this.checkType<SExpString>("get-value", args, 1);
        return this.getValue(args.car, name);
      }));
      this.defun("get-action-unit-list", (Func<Cons, object>) (args => SExp.toLispList<BL.AIUnit>((IEnumerable<BL.AIUnit>) this.battleEnv.aiActionUnits.value)));
      this.defun("get-target-unit-list", (Func<Cons, object>) (args => SExp.toLispList<BL.AIUnit>((IEnumerable<BL.AIUnit>) this.battleEnv.getTargetAIUnits(this.checkType<BL.AIUnit>("healerp", args, 0)))));
      this.defun("cant-change-currentp", (Func<Cons, object>) (args => this.checkType<BL.AIUnit>("change-currentp", args, 0).cantChangeCurrent ? this.trueObject : (object) null));
      this.defun("unitp", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("unitp", args, 1))
          return (object) null;
        return args.car is BL.AIUnit ? this.trueObject : (object) null;
      }));
      this.defun("panelp", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("panelp", args, 1))
          return (object) null;
        return args.car is BL.Panel ? this.trueObject : (object) null;
      }));
      this.defun("healerp", (Func<Cons, object>) (args => this.checkType<BL.AIUnit>("healerp", args, 0).isHealer ? this.trueObject : (object) null));
      this.defun("actionp", (Func<Cons, object>) (args => this.checkType<BL.AIUnit>("actionp", args, 0).isAction ? this.trueObject : (object) null));
      this.defun("get-danger-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) this.getDangerPanels())));
      this.defun("get-target-route", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("get-target-route", args, 0);
        BL.Panel fieldPanel = this.battleEnv.getFieldPanel((BL.UnitPosition) aiUnit);
        return SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) this.createTargetRoute((BL.UnitPosition) aiUnit, fieldPanel, this.getTargetPanel(aiUnit, fieldPanel)).Item1);
      }));
      this.defun("ownp", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit1 = this.checkType<BL.AIUnit>("ownp", args, 0);
        BL.AIUnit aiUnit2 = this.checkType<BL.AIUnit>("ownp", args, 1);
        return this.battleEnv.getForceID(aiUnit1.unit) == this.battleEnv.getForceID(aiUnit2.unit) ? this.trueObject : (object) null;
      }));
      this.defun("action-completedp", (Func<Cons, object>) (args => this.checkType<BL.AIUnit>("action-completedp", args, 0).isActionComleted ? this.trueObject : (object) null));
      this.defun("completedp", (Func<Cons, object>) (args => this.checkType<BL.AIUnit>("completedp", args, 0).isCompleted ? this.trueObject : (object) null));
      this.defun("get-move-panels", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("get-move-panels", args, 0);
        return aiUnit == null ? (object) null : SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) aiUnit.movePanels);
      }));
      this.defun("get-complete-panels", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("get-complete-panels", args, 0);
        return aiUnit == null ? (object) null : SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) aiUnit.completePanels);
      }));
      this.defun("get-panel", (Func<Cons, object>) (args => (object) this.battleEnv.getFieldPanel((BL.UnitPosition) this.checkType<BL.AIUnit>("set-position", args, 0))));
      this.defun("set-position", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("set-position", args, 0);
        BL.Panel panel = this.checkType<BL.Panel>("set-position", args, 1);
        aiUnit.row = panel.row;
        aiUnit.column = panel.column;
        return (object) aiUnit;
      }));
      this.defun("reset-position", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("set-position", args, 0);
        aiUnit.row = aiUnit.originalRow;
        aiUnit.column = aiUnit.originalColumn;
        return (object) aiUnit;
      }));
      this.defun("action-move-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) this.checkType<BL.AIUnit>("action-move-panels", args, 0).actionMovePanels)));
      this.defun("heal-move-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) this.checkType<BL.AIUnit>("all-heal-panels", args, 0).healMovePanels)));
      this.defun("attack-target-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) BattleFuncs.getAttackTargetPanels((BL.UnitPosition) this.checkType<BL.AIUnit>("attack-target-panels", args, 0), isAI: true))));
      this.defun("heal-target-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) BattleFuncs.getHealTargetPanels((BL.UnitPosition) this.checkType<BL.AIUnit>("heal-target-panels", args, 0), isAI: true))));
      this.defun("attack-targets", (Func<Cons, object>) (args => SExp.toLispList<BL.UnitPosition>((IEnumerable<BL.UnitPosition>) BattleFuncs.getAttackTargets((BL.UnitPosition) this.checkType<BL.AIUnit>("attack-targets", args, 0), isAI: true))));
      this.defun("skill-targets", (Func<Cons, object>) (args => (object) SExp.cons((object) SExp.cons((object) this.checkType<BL.AIUnit>("attack-targets", args, 0), (object) null), (object) null)));
      this.defun("heal-targets", (Func<Cons, object>) (args => SExp.toLispList<BL.UnitPosition>((IEnumerable<BL.UnitPosition>) BattleFuncs.getHealTargets((BL.UnitPosition) this.checkType<BL.AIUnit>("heal-targets", args, 0), isAI: true))));
      this.defun("attack-panels", (Func<Cons, object>) (args => SExp.toLispList<BL.Panel>((IEnumerable<BL.Panel>) BattleFuncs.getAttackTargetPanels((BL.UnitPosition) this.checkType<BL.AIUnit>("attack-panels", args, 0), isAI: true))));
      this.defun("create-attack-status-list", (Func<Cons, object>) (args => SExp.toLispList<AttackStatus>((IEnumerable<AttackStatus>) BattleFuncs.getAttackStatusArray((BL.UnitPosition) this.checkType<BL.AIUnit>("create-attack-status-list", args, 0), (BL.UnitPosition) this.checkType<BL.AIUnit>("create-attack-status-list", args, 1), true, this.nth(2, args) != null, true))));
      this.defun("hit-attack-status-cache", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit3 = this.checkType<BL.AIUnit>("hit-attack-status-cache", args, 0);
        BL.AIUnit aiUnit4 = this.checkType<BL.AIUnit>("hit-attack-status-cache", args, 1);
        bool isHeal = this.nth(2, args) != null;
        BL.Unit[] attackNeighbors;
        BL.Unit[] defenseNeighbors;
        int move_distance;
        int move_range;
        BattleFuncs.makeAttackStatusArgs((BL.UnitPosition) aiUnit3, (BL.UnitPosition) aiUnit4, true, isHeal, out attackNeighbors, out defenseNeighbors, out move_distance, out move_range, true);
        return this.battleEnv.getAttackStatusCache((BL.ISkillEffectListUnit) aiUnit3, this.battleEnv.getFieldPanel((BL.UnitPosition) aiUnit3), attackNeighbors, (BL.ISkillEffectListUnit) aiUnit4, this.battleEnv.getFieldPanel((BL.UnitPosition) aiUnit4), defenseNeighbors, aiUnit3.hp, true, isHeal, move_distance, move_range, out AttackStatus[] _) ? this.trueObject : (object) null;
      }));
      this.defun("create-action-result", (Func<Cons, object>) (args =>
      {
        BL.AIUnit attack = this.checkType<BL.AIUnit>("create-action-result", args, 0);
        AttackStatus attackStatus = this.checkType<AttackStatus>("create-action-result", args, 1);
        BL.AIUnit defense = this.checkType<BL.AIUnit>("create-action-result", args, 2);
        BL.Panel fieldPanel1 = this.battleEnv.getFieldPanel(attack.originalRow, attack.originalColumn);
        BL.Panel fieldPanel2 = this.battleEnv.getFieldPanel(attack.row, attack.column);
        BL.Panel fieldPanel3 = this.battleEnv.getFieldPanel(defense.row, defense.column);
        int move_distance = BL.fieldDistance(fieldPanel1, fieldPanel3) - 1;
        int move_range = BL.fieldDistance(fieldPanel1, fieldPanel2);
        ActionResult actionResult = (ActionResult) BattleFuncs.calcDuel(attackStatus, (BL.ISkillEffectListUnit) attack, fieldPanel2, (BL.ISkillEffectListUnit) defense, fieldPanel3, move_distance, move_range, true);
        actionResult.isMove = true;
        actionResult.row = attack.row;
        actionResult.column = attack.column;
        return (object) actionResult;
      }));
      this.defun("create-skill-result", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("create-skill-result", args, 0);
        int skill_id = (int) this.checkType<Decimal?>("create-skill-result", args, 1).Value;
        Cons cons = this.checkType<Cons>("create-skill-result", args, 2);
        ActionResult battleSkillResult = (ActionResult) BL.BattleSkillResult.createBattleSkillResult(skill_id, aiUnit.unit, SExp.toCSList<BL.AIUnit>((object) cons).Select<BL.AIUnit, BL.Unit>((Func<BL.AIUnit, BL.Unit>) (x => x.unit)).ToList<BL.Unit>(), this.battleEnv.phaseState.turnCount);
        if (battleSkillResult != null)
        {
          battleSkillResult.isMove = true;
          battleSkillResult.row = aiUnit.row;
          battleSkillResult.column = aiUnit.column;
        }
        return (object) battleSkillResult;
      }));
      this.defun("action-unit", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("action-unit", args, 0);
        ActionResult actionResult = this.checkType<ActionResult>("action-unit", args, 1);
        BL.BattleModified<BL.ClassValue<List<BL.AIUnit>>> battleModified = BL.Observe<BL.ClassValue<List<BL.AIUnit>>>(this.battleEnv.aiUnitPositions);
        battleModified.isChangedOnce();
        if (aiUnit.actionResults == null)
          aiUnit.actionResults = new List<ActionResult>();
        aiUnit.actionResults.Add(actionResult);
        this.battleVariables.Remove("is_own_team_can_attacked");
        aiUnit.actionAIUnit(this.battleEnv);
        if (battleModified.isChanged)
          this.clearCache();
        return battleModified.isChanged ? this.trueObject : (object) null;
      }));
      this.defun("complete-unit", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("complete-unit", args, 0);
        this.battleVariables.Remove("is_own_team_can_attacked");
        aiUnit.completeAIUnit(this.battleEnv);
        return (object) aiUnit;
      }));
      this.defun("unit-extdata", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("get-unit-extdata", args, 0);
        object key = this.nth(1, args);
        return aiUnit.unit.aiExtension != null ? SExp.cdr(SExp.assoc(key, aiUnit.unit.aiExtension)) : (object) null;
      }));
      this.defun("clear-variables", (Func<Cons, object>) (args =>
      {
        this.battleVariables.Clear();
        return (object) null;
      }));
      this.defun("clear-danger-panels", (Func<Cons, object>) (args => (object) (this.dangerPanels = (HashSet<BL.Panel>) null)));
      this.defun("set-current", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit5 = this.checkType<BL.AIUnit>("set-current", args, 0);
        BL.AIUnit aiUnit6 = this.checkType<BL.AIUnit>("set-current", args, 1);
        BL.Panel panel = this.checkType<BL.Panel>("set-current", args, 2);
        AttackStatus attackStatus = this.checkType<AttackStatus>("set-current", args, 3);
        this.currentUnit = aiUnit5;
        this.currentTarget = aiUnit6;
        this.currentPanel = panel;
        this.currentAttackStatus = attackStatus;
        return (object) aiUnit5;
      }));
      this.defun("set-current-unit", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("set-current-unit", args, 0);
        this.currentUnit = aiUnit;
        return (object) aiUnit;
      }));
      this.defun("set-current-target", (Func<Cons, object>) (args =>
      {
        BL.AIUnit aiUnit = this.checkType<BL.AIUnit>("set-current-target", args, 0);
        this.currentTarget = aiUnit;
        return (object) aiUnit;
      }));
      this.defun("set-current-attack-status", (Func<Cons, object>) (args =>
      {
        AttackStatus attackStatus = this.checkType<AttackStatus>("set-current-attack-status", args, 0);
        this.currentAttackStatus = attackStatus;
        return (object) attackStatus;
      }));
      this.defun("set-current-panel", (Func<Cons, object>) (args =>
      {
        BL.Panel panel = this.checkType<BL.Panel>("set-current-panel", args, 0);
        this.currentPanel = panel;
        return (object) panel;
      }));
      this.defun("current-unit-has-mbp", (Func<Cons, object>) (args => this.hasMagicBullet(this.currentUnit, (int) this.checkType<Decimal?>("current-unit-has-mbp", args, 0).Value) ? this.trueObject : (object) null));
      this.defun("current-target-has-mbp", (Func<Cons, object>) (args => this.hasMagicBullet(this.currentTarget, (int) this.checkType<Decimal?>("current-target-has-mbp", args, 0).Value) ? this.trueObject : (object) null));
    }

    protected override object symbolValE(string sym, Stack<Dictionary<string, object>> es)
    {
      string[] split = sym.Split('@');
      return this.isBattleVariable(split) ? this.getBattleVariable(split) : base.symbolValE(sym, es);
    }

    private BL.AIUnit currentUnit
    {
      get => this.mCurrentUnit;
      set => this.mCurrentUnit = value;
    }

    private BL.AIUnit currentTarget
    {
      get => this.mCurrentTarget;
      set => this.mCurrentTarget = value;
    }

    private BL.Panel currentPanel
    {
      get => this.mCurrentPanel;
      set => this.mCurrentPanel = value;
    }

    private AttackStatus currentAttackStatus
    {
      get => this.mCurrentAttackStatus;
      set => this.mCurrentAttackStatus = value;
    }

    private bool isBattleVariable(string[] split)
    {
      if (split.Length != 2)
        return false;
      bool flag = false;
      switch (split[0])
      {
        case "own":
        case "target":
          flag = this.isUnitVariable(split[1]);
          break;
        case "panel":
          flag = this.isPanelVariable(split[1]);
          break;
        case "battle":
          string str1 = split[1];
          flag = str1 == "sum_own" || str1 == "sum_enemy" || str1 == "turn" || str1 == "is_own_team_can_attacked";
          break;
        case "current":
          string str2 = split[1];
          flag = str2 == "unit" || str2 == "target" || str2 == "panel";
          break;
      }
      return flag;
    }

    private bool isPanelVariable(string sym)
    {
      string key = sym;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AILisp.\u003C\u003Ef__switch\u0024map4 = new Dictionary<string, int>(9)
          {
            {
              "phisics",
              0
            },
            {
              "magic",
              0
            },
            {
              "eva",
              0
            },
            {
              "heal",
              0
            },
            {
              "own_skill",
              0
            },
            {
              "is_danger",
              0
            },
            {
              "enemy_distance",
              0
            },
            {
              "own_hp",
              0
            },
            {
              "move_distance",
              0
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map4.TryGetValue(key, out num) && num == 0)
          return true;
      }
      return false;
    }

    private bool isUnitVariable(string sym)
    {
      string key = sym;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AILisp.\u003C\u003Ef__switch\u0024map5 = new Dictionary<string, int>(10)
          {
            {
              "hp",
              0
            },
            {
              "attack",
              0
            },
            {
              "hit",
              0
            },
            {
              "critical",
              0
            },
            {
              "magic_cost",
              0
            },
            {
              "move_type",
              0
            },
            {
              "is_buster",
              0
            },
            {
              "has_leader_skill",
              0
            },
            {
              "skill_level",
              0
            },
            {
              "rarity",
              0
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map5.TryGetValue(key, out num) && num == 0)
          return true;
      }
      return false;
    }

    private object getBattleVariable(string[] split)
    {
      string str = split[1];
      string key1 = split[0];
      object battleVariable;
      if (key1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AILisp.\u003C\u003Ef__switch\u0024map8 = new Dictionary<string, int>(5)
          {
            {
              "own",
              0
            },
            {
              "target",
              1
            },
            {
              "panel",
              2
            },
            {
              "battle",
              3
            },
            {
              "current",
              4
            }
          };
        }
        int num1;
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map8.TryGetValue(key1, out num1))
        {
          switch (num1)
          {
            case 0:
              battleVariable = this.getUnitVariable(this.currentUnit, this.currentTarget, this.currentAttackStatus, str);
              goto label_36;
            case 1:
              battleVariable = this.getUnitVariable(this.currentTarget, this.currentUnit, (AttackStatus) null, str);
              goto label_36;
            case 2:
              battleVariable = this.getPanelVariable(this.currentPanel, this.currentUnit, this.currentTarget, str);
              goto label_36;
            case 3:
              if (this.battleVariables.ContainsKey(str))
              {
                battleVariable = this.battleVariables[str];
                goto label_36;
              }
              else
              {
                string key2 = str;
                if (key2 != null)
                {
                  // ISSUE: reference to a compiler-generated field
                  if (AILisp.\u003C\u003Ef__switch\u0024map6 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    AILisp.\u003C\u003Ef__switch\u0024map6 = new Dictionary<string, int>(4)
                    {
                      {
                        "sum_own",
                        0
                      },
                      {
                        "sum_enemy",
                        1
                      },
                      {
                        "turn",
                        2
                      },
                      {
                        "is_own_team_can_attacked",
                        3
                      }
                    };
                  }
                  int num2;
                  // ISSUE: reference to a compiler-generated field
                  if (AILisp.\u003C\u003Ef__switch\u0024map6.TryGetValue(key2, out num2))
                  {
                    switch (num2)
                    {
                      case 0:
                        battleVariable = (object) this.numberDic.numberObject(this.battleEnv.getTargetAIUnits(this.currentTarget).Count);
                        goto label_25;
                      case 1:
                        battleVariable = (object) this.numberDic.numberObject(this.battleEnv.getTargetAIUnits(this.currentUnit).Count);
                        goto label_25;
                      case 2:
                        battleVariable = (object) this.numberDic.numberObject(this.battleEnv.phaseState.turnCount);
                        goto label_25;
                      case 3:
                        battleVariable = (object) null;
                        using (List<BL.AIUnit>.Enumerator enumerator = this.battleEnv.aiUnits.value.GetEnumerator())
                        {
                          while (enumerator.MoveNext())
                          {
                            BL.AIUnit current = enumerator.Current;
                            if (this.getDangerPanels().Contains(this.battleEnv.getFieldPanel(current.originalRow, current.originalColumn)))
                            {
                              battleVariable = this.trueObject;
                              break;
                            }
                          }
                          goto label_25;
                        }
                    }
                  }
                }
                battleVariable = (object) null;
label_25:
                this.battleVariables[str] = battleVariable;
                goto label_36;
              }
            case 4:
              string key3 = str;
              if (key3 != null)
              {
                // ISSUE: reference to a compiler-generated field
                if (AILisp.\u003C\u003Ef__switch\u0024map7 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  AILisp.\u003C\u003Ef__switch\u0024map7 = new Dictionary<string, int>(3)
                  {
                    {
                      "unit",
                      0
                    },
                    {
                      "target",
                      1
                    },
                    {
                      "panel",
                      2
                    }
                  };
                }
                int num3;
                // ISSUE: reference to a compiler-generated field
                if (AILisp.\u003C\u003Ef__switch\u0024map7.TryGetValue(key3, out num3))
                {
                  switch (num3)
                  {
                    case 0:
                      battleVariable = (object) this.currentUnit;
                      goto label_36;
                    case 1:
                      battleVariable = (object) this.currentTarget;
                      goto label_36;
                    case 2:
                      battleVariable = (object) this.currentPanel;
                      goto label_36;
                  }
                }
              }
              battleVariable = (object) null;
              goto label_36;
          }
        }
      }
      battleVariable = (object) null;
label_36:
      return battleVariable;
    }

    private object getPanelVariable(BL.Panel panel, BL.AIUnit unit, BL.AIUnit target, string sym)
    {
      BattleLandformIncr incr = panel.landform.GetIncr(unit.unit.unit);
      object panelVariable = (object) null;
      string key = sym;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AILisp.\u003C\u003Ef__switch\u0024map9 = new Dictionary<string, int>(9)
          {
            {
              "phisics",
              0
            },
            {
              "magic",
              1
            },
            {
              "eva",
              2
            },
            {
              "heal",
              3
            },
            {
              "own_skill",
              4
            },
            {
              "is_danger",
              5
            },
            {
              "enemy_distance",
              6
            },
            {
              "own_hp",
              7
            },
            {
              "move_distance",
              8
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024map9.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              panelVariable = (object) this.numberDic.numberObject(incr.physical_defense_incr);
              break;
            case 1:
              panelVariable = (object) this.numberDic.numberObject(incr.magic_defense_incr);
              break;
            case 2:
              panelVariable = (object) this.numberDic.numberObject(incr.evasion_incr);
              break;
            case 3:
              panelVariable = (object) this.numberDic.numberObject(incr.hp_healing_ratio);
              break;
            case 4:
              panelVariable = (object) this.numberDic.numberObject(0);
              break;
            case 5:
              panelVariable = !this.getDangerPanels().Contains(panel) ? (object) null : this.trueObject;
              break;
            case 6:
              panelVariable = (object) this.numberDic.numberObject(this.createTargetRoute((BL.UnitPosition) unit, panel, this.getTargetPanel(unit, panel)).Item1.Count);
              break;
            case 7:
              panelVariable = (object) this.numberDic.numberObject(0);
              break;
            case 8:
              panelVariable = (object) this.numberDic.numberObject(this.battleEnv.getTargetRouteWithCache((BL.UnitPosition) unit, this.battleEnv.getFieldPanel(unit.originalRow, unit.originalColumn), panel, false).Item1.Count);
              break;
          }
        }
      }
      return panelVariable;
    }

    private object getUnitVariable(
      BL.AIUnit unit,
      BL.AIUnit target,
      AttackStatus attackStatus,
      string sym)
    {
      string key = sym;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024mapA == null)
        {
          // ISSUE: reference to a compiler-generated field
          AILisp.\u003C\u003Ef__switch\u0024mapA = new Dictionary<string, int>(10)
          {
            {
              "hp",
              0
            },
            {
              "attack",
              1
            },
            {
              "hit",
              2
            },
            {
              "critical",
              3
            },
            {
              "magic_cost",
              4
            },
            {
              "move_type",
              5
            },
            {
              "is_buster",
              6
            },
            {
              "has_leader_skill",
              7
            },
            {
              "skill_level",
              8
            },
            {
              "rarity",
              9
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (AILisp.\u003C\u003Ef__switch\u0024mapA.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              return (object) this.numberDic.numberObject((float) unit.hp / (float) unit.unit.parameter.Hp);
            case 1:
              return this.calcAttack(unit, target, attackStatus);
            case 2:
              return this.calcHit(unit, target, attackStatus);
            case 3:
              return this.calcCritical(unit, target, attackStatus);
            case 4:
              return this.calcMagicCost(unit, target, attackStatus);
            case 5:
              return (object) this.numberDic.numberObject((int) unit.unit.unit.job.move_type);
            case 6:
              return this.calcIsBuster(unit, target, attackStatus);
            case 7:
              return (unit.unit.is_leader || unit.unit.is_helper) && unit.unit.playerUnit.leader_skills.Length != 0 ? this.trueObject : (object) null;
            case 8:
              return (object) this.numberDic.numberObject(unit.skillLevel);
            case 9:
              return (object) this.numberDic.numberObject(unit.rarity);
          }
        }
      }
      return (object) null;
    }

    private AttackStatus calcCounterAttack()
    {
      BL.Unit[] attackNeighbors = !BattleFuncs.useNeighbors(this.currentUnit.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getNeighbors((BL.UnitPosition) this.currentUnit, true).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      BL.Unit[] defenseNeighbors = !BattleFuncs.useNeighbors(this.currentTarget.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getNeighbors((BL.UnitPosition) this.currentTarget, true).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      return BattleFuncs.getCounterAttack((BL.ISkillEffectListUnit) this.currentUnit, this.currentPanel, attackNeighbors, (BL.ISkillEffectListUnit) this.currentTarget, this.battleEnv.getFieldPanel((BL.UnitPosition) this.currentTarget), defenseNeighbors, false, false, 0, -1, true);
    }

    private object calcIsBuster(BL.AIUnit unit, BL.AIUnit target, AttackStatus attackStatus)
    {
      if (attackStatus == null)
      {
        attackStatus = this.calcCounterAttack();
        if (attackStatus == null)
          return (object) null;
      }
      int num = attackStatus.attack * attackStatus.attackCount;
      return (double) (target.hp - num) <= 0.0 ? this.trueObject : (object) null;
    }

    private object calcAttack(BL.AIUnit unit, BL.AIUnit target, AttackStatus attackStatus)
    {
      if (attackStatus == null)
      {
        attackStatus = this.calcCounterAttack();
        if (attackStatus == null)
          return (object) this.numberDic.numberObject(0);
      }
      return (object) this.numberDic.numberObject(NC.Clampf(0.0f, 1f, (float) (attackStatus.attack * attackStatus.attackCount) / (float) target.hp));
    }

    private object calcHit(BL.AIUnit unit, BL.AIUnit target, AttackStatus attackStatus)
    {
      if (attackStatus == null)
      {
        attackStatus = this.calcCounterAttack();
        if (attackStatus == null)
          return (object) this.numberDic.numberObject(0);
      }
      return (object) this.numberDic.numberObject(attackStatus.hit);
    }

    private object calcCritical(BL.AIUnit unit, BL.AIUnit target, AttackStatus attackStatus)
    {
      if (attackStatus == null)
      {
        attackStatus = this.calcCounterAttack();
        if (attackStatus == null)
          return (object) this.numberDic.numberObject(0);
      }
      return (object) this.numberDic.numberObject(attackStatus.critical);
    }

    private object calcMagicCost(BL.AIUnit unit, BL.AIUnit target, AttackStatus attackStatus)
    {
      if (attackStatus == null)
      {
        attackStatus = this.calcCounterAttack();
        if (attackStatus == null)
          return (object) this.numberDic.numberObject(0);
      }
      return attackStatus.magicBullet != null ? (object) this.numberDic.numberObject((float) attackStatus.magicBullet.cost / (float) unit.unit.parameter.Hp) : (object) this.numberDic.numberObject(0);
    }

    private bool hasMagicBullet(BL.AIUnit unit, int id)
    {
      foreach (BL.MagicBullet magicBullet in unit.unit.magicBullets)
      {
        if (magicBullet.skillId == id)
          return true;
      }
      return false;
    }

    public Tuple<List<BL.Panel>, int> createTargetRoute(
      BL.UnitPosition u,
      BL.Panel panel,
      BL.Panel target)
    {
      bool im = (!(u is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) u.unit : u as BL.ISkillEffectListUnit).HasEnabledSkillEffect(BattleskillEffectLogicEnum.ignore_move_cost);
      return this.battleEnv.getTargetRouteWithCache(u, panel, target, im);
    }

    private BL.Panel getTargetPanel(BL.AIUnit unit, BL.Panel panel)
    {
      BL.Panel targetPanel = unit.GetTargetPanelOrNull(this.battleEnv);
      if (targetPanel == null)
      {
        targetPanel = this.getAIGroupTarget(unit);
        if (targetPanel == null)
        {
          List<BL.AIUnit> targetAiUnits = this.battleEnv.getTargetAIUnits(unit);
          if (targetAiUnits.Count == 0)
          {
            targetPanel = this.battleEnv.getFieldPanel((BL.UnitPosition) unit);
          }
          else
          {
            int num1 = 1000000000;
            foreach (BL.UnitPosition up in targetAiUnits)
            {
              BL.Panel fieldPanel = this.battleEnv.getFieldPanel(up);
              int num2 = this.createTargetRoute((BL.UnitPosition) unit, panel, fieldPanel).Item2;
              if (num2 < num1)
              {
                targetPanel = fieldPanel;
                num1 = num2;
              }
            }
          }
        }
      }
      return targetPanel;
    }

    private BL.Panel getAIGroupTarget(BL.AIUnit unit)
    {
      foreach (BL.AIUnit targetAiUnit in this.battleEnv.getTargetAIUnits(unit))
      {
        if (targetAiUnit.unit.IsAIMoveGroup && targetAiUnit.unit.AIMoveGroup == unit.unit.AIMoveGroup)
          return this.battleEnv.getFieldPanel((BL.UnitPosition) targetAiUnit);
      }
      return (BL.Panel) null;
    }

    private HashSet<BL.Panel> getDangerPanels()
    {
      if (this.dangerPanels == null)
        this.dangerPanels = BattleFuncs.createDangerPanels<BL.AIUnit>((IEnumerable<BL.AIUnit>) this.battleEnv.getTargetAIUnits(this.battleEnv.aiUnits.value[0]));
      return this.dangerPanels;
    }

    private object getValue(object o, SExpString name)
    {
      string strValue = name.strValue;
      Type type = o.GetType();
      if ((object) type != null)
      {
        FieldInfo field = type.GetField(strValue);
        if ((object) field != null)
          return field.GetValue(o);
      }
      return (object) null;
    }
  }
}
