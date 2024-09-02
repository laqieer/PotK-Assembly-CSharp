// Decompiled with JetBrains decompiler
// Type: BattleEffects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleEffects : BattleMonoBehaviour
{
  private BattleTimeManager btm;
  private Dictionary<BL.FieldEffect, Tuple<GameObject, GameObject[]>> effectResources;
  private GameObject damageEffect;
  private GameObject criticalEffect;
  private bool isPopupDismiss;

  public GameObject effectResourcePrefab(BL.FieldEffect fe) => this.effectResources[fe].Item1;

  public GameObject[] effectResourceAllPrefabs(BL.FieldEffect fe) => this.effectResources[fe].Item2;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleEffects.\u003CStart_Battle\u003Ec__Iterator9A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onPopupDismiss() => this.isPopupDismiss = true;

  public void startEffect(
    Transform t,
    float time,
    System.Action endAction = null,
    bool isBattleEnableControl = false,
    GameObject popupPrefab = null,
    bool alert = false,
    bool isCloned = false,
    Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null,
    bool isUnmask = false,
    bool isViewBack = true)
  {
    this.btm.setSchedule((Schedule) new BattleEffects.StartEffect(t, time, endAction, isBattleEnableControl, this, popupPrefab, alert, isCloned, cloneAction, cloneE, isUnmask, isViewBack));
  }

  public void startEffect(
    string name,
    float time,
    System.Action endAction = null,
    bool isBattleEnableControl = false,
    GameObject popupPrefab = null,
    bool alert = false,
    bool isCloned = false,
    Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null)
  {
    this.startEffect(((Component) this).transform.GetChildInFind(name), time, endAction, isBattleEnableControl, popupPrefab, alert, isCloned, cloneAction, cloneE);
  }

  public void startEffect(
    string name,
    float time,
    GameObject popupPrefab,
    bool alert = false,
    bool isCloned = false,
    Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null)
  {
    this.startEffect(name, time, (System.Action) null, false, popupPrefab, alert, isCloned, cloneAction, cloneE);
  }

  public void startEffect(BL.FieldEffect effect)
  {
    GameObject p = this.effectResourcePrefab(effect).Clone(((Component) this).transform);
    if (Object.op_Equality((Object) p, (Object) null))
      return;
    ClipFieldEffect componentInChildren = p.GetComponentInChildren<ClipFieldEffect>();
    if (Object.op_Equality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.setEffectData(effect);
    if (effect.fieldEffect.category == BattleFieldEffectCategory.boss)
      this.btm.setTargetUnit(this.env.core.getUnitPosition(this.env.core.getBossUnit()), 0.1f, isWaitCameraMove: true);
    this.startEffect(p.transform, 30000f, (System.Action) (() => Object.Destroy((Object) p.gameObject)), alert: effect.fieldEffect.cancelable, isUnmask: effect.fieldEffect.is_unmask, isViewBack: effect.fieldEffect.is_view_back);
  }

  public ConditionForVictory getConditionForVictory(string node)
  {
    Transform childInFind = ((Component) this).transform.GetChildInFind(node);
    if (!Object.op_Inequality((Object) childInFind, (Object) null))
      return (ConditionForVictory) null;
    ConditionForVictory[] componentsInChildren = ((Component) childInFind).GetComponentsInChildren<ConditionForVictory>(true);
    return componentsInChildren != null && componentsInChildren.Length >= 1 ? componentsInChildren[0] : (ConditionForVictory) null;
  }

  public void setTurnNumber(string node, int n)
  {
    Transform childInFind = ((Component) this).transform.GetChildInFind(node);
    if (!Object.op_Inequality((Object) childInFind, (Object) null))
      return;
    EffectNumber[] componentsInChildren = ((Component) childInFind).GetComponentsInChildren<EffectNumber>(true);
    if (componentsInChildren.Length <= 0)
      return;
    foreach (EffectNumber effectNumber in componentsInChildren)
      effectNumber.setNumber(n);
  }

  public void setWaveNumber(string node, int wave, int maxWave)
  {
    Transform childInFind = ((Component) this).transform.GetChildInFind(node);
    if (!Object.op_Inequality((Object) childInFind, (Object) null))
      return;
    WaveNumber[] componentsInChildren = ((Component) childInFind).GetComponentsInChildren<WaveNumber>(true);
    if (componentsInChildren.Length <= 0)
      return;
    foreach (WaveNumber waveNumber in componentsInChildren)
      waveNumber.setNumber(wave + 1, maxWave);
  }

  [DebuggerHidden]
  private IEnumerator doFieldEffect(GameObject prefab, Transform t, float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleEffects.\u003CdoFieldEffect\u003Ec__Iterator9A8()
    {
      delay = delay,
      prefab = prefab,
      t = t,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Et = t
    };
  }

  private void execFieldEffect(GameObject prefab, Transform t)
  {
    this.StartCoroutine(this.doFieldEffect(prefab, t));
  }

  private void skillFieldEffectStartOld(
    BL.Unit unit,
    List<BL.Unit> targets,
    GameObject effectPrefab,
    GameObject targetEffectPrefab,
    System.Action action,
    System.Action targetAction)
  {
    if (unit != null)
    {
      UnitUpdate uu = this.env.unitResource[unit].gameObject.GetComponent<UnitUpdate>();
      this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), 0.5f, effectPrefab, endAction: (System.Action) (() =>
      {
        uu.setAnimationTrigger("isSkill");
        if (action == null)
          return;
        action();
      }), isWaitCameraMove: true);
    }
    if (targets == null || !Object.op_Inequality((Object) targetEffectPrefab, (Object) null))
      return;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      this.fieldEffectsStart(targetEffectPrefab, targets);
      if (targetAction == null)
        return;
      targetAction();
    }), 0.5f);
  }

  public void skillFieldEffectStartCore(
    BattleskillFieldEffect fe,
    BL.Unit unit,
    List<BL.Unit> targets,
    GameObject effectPrefab,
    GameObject targetEffectPrefab,
    System.Action action = null,
    System.Action targetAction = null)
  {
    if (fe == null)
    {
      this.skillFieldEffectStartOld(unit, targets, effectPrefab, targetEffectPrefab, action, targetAction);
    }
    else
    {
      if (unit != null)
      {
        UnitUpdate uu = this.env.unitResource[unit].gameObject.GetComponent<UnitUpdate>();
        if (fe.user_move_camera)
          this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), fe.user_wait_seconds, effectPrefab, endAction: (System.Action) (() =>
          {
            uu.setAnimationTrigger("isSkill");
            if (action == null)
              return;
            action();
          }), isWaitCameraMove: true);
        else
          this.btm.setScheduleAction((System.Action) (() =>
          {
            uu.setAnimationTrigger("isSkill");
            if (Object.op_Inequality((Object) effectPrefab, (Object) null))
              this.execFieldEffect(effectPrefab, ((Component) uu).transform);
            if (action == null)
              return;
            action();
          }), fe.user_wait_seconds);
      }
      if (!Object.op_Inequality((Object) targetEffectPrefab, (Object) null) || targets == null)
        return;
      if (fe.targets_multiple_effect)
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.fieldEffectsStart(targetEffectPrefab, targets);
          if (targetAction == null)
            return;
          targetAction();
        }), fe.target_wait_seconds);
      }
      else
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (targetAction == null)
            return;
          targetAction();
        }));
        if (fe.target_move_camera)
        {
          foreach (BL.Unit target in targets)
            this.btm.setTargetUnit(this.env.core.getUnitPosition(target), fe.target_wait_seconds, targetEffectPrefab);
        }
        else
        {
          foreach (BL.Unit target in targets)
          {
            BL.Unit ct = target;
            this.btm.setScheduleAction((System.Action) (() => this.execFieldEffect(targetEffectPrefab, this.env.unitResource[ct].gameObject.transform)), fe.target_wait_seconds);
          }
        }
      }
    }
  }

  public void skillFieldEffectStart(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    BE.SkillResource skillResource = this.env.skillResource[skill.skill.field_effect.ID];
    this.skillFieldEffectStartCore(skill.skill.field_effect, unit, targets, skillResource.effectPrefab, skillResource.targetEffectPrefab);
  }

  public void mbFieldEffectStart(BL.Unit unit, BL.MagicBullet mb, List<BL.Unit> targets)
  {
    Debug.LogWarning((object) (" === mbFieldEffectStart name:" + mb.name));
    BE.SkillResource skillResource = this.env.skillResource[mb.skill.field_effect.ID];
    this.skillFieldEffectStartCore(mb.skill.field_effect, unit, targets, skillResource.effectPrefab, skillResource.targetEffectPrefab);
  }

  public void itemFieldEffectStart(List<BL.Unit> targets, BL.Item item, System.Action action)
  {
    BE.ItemResource itemResource = this.env.itemResource[item];
    this.skillFieldEffectStartCore(item.item.skill.field_effect, (BL.Unit) null, targets, (GameObject) null, itemResource.targetEffectPrefab, targetAction: action);
  }

  public void fieldEffectsStart(GameObject prefab, List<BL.Unit> targets, float delay = 0.0f)
  {
    foreach (BL.Unit target in targets)
    {
      BE.UnitResource unitResource = this.env.unitResource[target];
      this.StartCoroutine(this.doFieldEffect(prefab, unitResource.gameObject.transform, delay));
    }
  }

  public void fieldEffectsStart(GameObject prefab, BL.Unit target, float delay = 0.0f)
  {
    BE.UnitResource unitResource = this.env.unitResource[target];
    this.StartCoroutine(this.doFieldEffect(prefab, unitResource.gameObject.transform, delay));
  }

  public abstract class CloneEnumlator
  {
    public abstract IEnumerator doBody(GameObject o);
  }

  private class StartEffect : ScheduleEnumerator
  {
    private Transform tf;
    private float wait;
    private bool isBattleEnableControl;
    private BattleEffects parent;
    private GameObject popupPrefab;
    private bool alert;
    private bool isCloned;
    private Action<GameObject> cloneAction;
    private BattleEffects.CloneEnumlator cloneE;
    private bool isUnmask;
    private bool isViewBack;

    public StartEffect(
      Transform t,
      float wait,
      System.Action endAction,
      bool isBattleEnableControl,
      BattleEffects parent,
      GameObject popupPrefab,
      bool alert,
      bool isCloned,
      Action<GameObject> cloneAction,
      BattleEffects.CloneEnumlator cloneE,
      bool isUnmask,
      bool isViewBack)
    {
      this.tf = t;
      this.wait = wait;
      this.endAction = endAction;
      this.isBattleEnableControl = isBattleEnableControl;
      this.parent = parent;
      this.isCompleted = false;
      this.popupPrefab = popupPrefab;
      this.alert = alert;
      this.isCloned = isCloned;
      this.cloneAction = cloneAction;
      this.cloneE = cloneE;
      this.isUnmask = isUnmask;
      this.isViewBack = isViewBack;
      this.isInsertMode = true;
    }

    [DebuggerHidden]
    public override IEnumerator doBody()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleEffects.StartEffect.\u003CdoBody\u003Ec__Iterator9A9()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
