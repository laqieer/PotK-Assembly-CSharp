// Decompiled with JetBrains decompiler
// Type: BattleEffects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class BattleEffects : BattleMonoBehaviour
{
  private BattleTimeManager btm;
  private Dictionary<BL.FieldEffect, Tuple<GameObject, GameObject[]>> effectResources;
  private GameObject damageEffect;
  private GameObject criticalEffect;
  private bool isPopupDismiss;

  public GameObject effectResourcePrefab(BL.FieldEffect fe) => this.effectResources[fe].Item1;

  public GameObject[] effectResourceAllPrefabs(BL.FieldEffect fe) => this.effectResources[fe].Item2;

  protected override IEnumerator Start_Battle()
  {
    BattleEffects battleEffects = this;
    battleEffects.btm = battleEffects.battleManager.getManager<BattleTimeManager>();
    battleEffects.effectResources = new Dictionary<BL.FieldEffect, Tuple<GameObject, GameObject[]>>();
    foreach (BL.FieldEffect fieldEffect in battleEffects.env.core.fieldEffectList.value)
    {
      BL.FieldEffect fe = fieldEffect;
      Future<GameObject> f = fe.fieldEffect.LoadPrefab();
      IEnumerator e = f.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Future<GameObject[]> f2 = fe.fieldEffect.LoadAllEffectPrefab();
      e = f2.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battleEffects.effectResources[fe] = Tuple.Create<GameObject, GameObject[]>(f.Result, f2.Result);
      f = (Future<GameObject>) null;
      f2 = (Future<GameObject[]>) null;
      fe = (BL.FieldEffect) null;
    }
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
    System.Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null,
    bool isUnmask = false,
    bool isViewBack = true)
  {
    this.startEffect(t, time, endAction, isBattleEnableControl, false, (System.Action<ScheduleEnumerator>) null, popupPrefab, alert, isCloned, cloneAction, cloneE, isUnmask, isViewBack, false);
  }

  public void startEffect(
    string name,
    float time,
    System.Action endAction = null,
    bool isBattleEnableControl = false,
    bool isSkippedVoiceStop = false,
    System.Action<ScheduleEnumerator> onClickMask = null,
    GameObject popupPrefab = null,
    bool alert = false,
    bool isCloned = false,
    System.Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null,
    bool isButtonNoneState = false)
  {
    this.startEffect(this.transform.GetChildInFind(name), time, endAction, isBattleEnableControl, isSkippedVoiceStop, onClickMask, popupPrefab, alert, isCloned, cloneAction, cloneE, isButtonNoneState: isButtonNoneState);
  }

  public void startEffect(
    string name,
    float time,
    GameObject popupPrefab,
    bool alert = false,
    bool isCloned = false,
    System.Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null)
  {
    this.startEffect(name, time, (System.Action) null, false, false, (System.Action<ScheduleEnumerator>) null, popupPrefab, alert, isCloned, cloneAction, cloneE, false);
  }

  public void startEffect(BL.FieldEffect effect)
  {
    GameObject p = this.effectResourcePrefab(effect).Clone(this.transform);
    if ((UnityEngine.Object) p == (UnityEngine.Object) null)
      return;
    ClipFieldEffect componentInChildren = p.GetComponentInChildren<ClipFieldEffect>();
    if ((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null)
      return;
    componentInChildren.setEffectData(effect);
    if (effect.fieldEffect.category == BattleFieldEffectCategory.boss)
      this.btm.setTargetUnit(this.env.core.getUnitPosition(this.env.core.getBossUnit()), 0.1f, isWaitCameraMove: true);
    this.startEffect(p.transform, 30000f, (System.Action) (() => UnityEngine.Object.Destroy((UnityEngine.Object) p.gameObject)), false, (GameObject) null, effect.fieldEffect.cancelable, false, (System.Action<GameObject>) null, (BattleEffects.CloneEnumlator) null, effect.fieldEffect.is_unmask, effect.fieldEffect.is_view_back);
  }

  private void startEffect(
    Transform t,
    float time,
    System.Action endAction = null,
    bool isBattleEnableControl = false,
    bool isSkippedVoiceStop = false,
    System.Action<ScheduleEnumerator> onClickMask = null,
    GameObject popupPrefab = null,
    bool alert = false,
    bool isCloned = false,
    System.Action<GameObject> cloneAction = null,
    BattleEffects.CloneEnumlator cloneE = null,
    bool isUnmask = false,
    bool isViewBack = true,
    bool isButtonNoneState = false)
  {
    this.btm.setSchedule((Schedule) new BattleEffects.StartEffect(t, time, endAction, isBattleEnableControl, isSkippedVoiceStop, this, onClickMask, popupPrefab, alert, isCloned, cloneAction, cloneE, isUnmask, isViewBack, isButtonNoneState));
  }

  public ConditionForVictory getConditionForVictory(string node)
  {
    Transform childInFind = this.transform.GetChildInFind(node);
    if (!((UnityEngine.Object) childInFind != (UnityEngine.Object) null))
      return (ConditionForVictory) null;
    ConditionForVictory[] componentsInChildren = childInFind.GetComponentsInChildren<ConditionForVictory>(true);
    return componentsInChildren != null && componentsInChildren.Length >= 1 ? componentsInChildren[0] : (ConditionForVictory) null;
  }

  public void setTurnNumber(string node, int n)
  {
    Transform childInFind = this.transform.GetChildInFind(node);
    if (!((UnityEngine.Object) childInFind != (UnityEngine.Object) null))
      return;
    EffectNumber[] componentsInChildren = childInFind.GetComponentsInChildren<EffectNumber>(true);
    if (componentsInChildren.Length == 0)
      return;
    foreach (EffectNumber effectNumber in componentsInChildren)
      effectNumber.setNumber(n);
  }

  public void setWaveNumber(string node, int wave, int maxWave)
  {
    Transform childInFind = this.transform.GetChildInFind(node);
    if (!((UnityEngine.Object) childInFind != (UnityEngine.Object) null))
      return;
    WaveNumber[] componentsInChildren = childInFind.GetComponentsInChildren<WaveNumber>(true);
    if (componentsInChildren.Length == 0)
      return;
    foreach (WaveNumber waveNumber in componentsInChildren)
      waveNumber.setNumber(wave + 1, maxWave);
  }

  private IEnumerator doFieldEffect(
    GameObject prefab,
    Transform t,
    float delay = 0.0f,
    Quaternion? rotate = null,
    Vector3? localPosition = null)
  {
    if ((double) delay != 0.0)
      yield return (object) new WaitForSeconds(delay);
    GameObject o = prefab.Clone(t);
    if (localPosition.HasValue)
      o.transform.localPosition = localPosition.Value;
    if (rotate.HasValue)
      o.transform.rotation *= rotate.Value;
    yield return (object) new WaitForSeconds(10f);
    UnityEngine.Object.Destroy((UnityEngine.Object) o);
  }

  private void execFieldEffect(
    GameObject prefab,
    Transform t,
    Quaternion? rotate = null,
    Vector3? localPosition = null)
  {
    this.StartCoroutine(this.doFieldEffect(prefab, t, rotate: rotate, localPosition: localPosition));
  }

  private void skillFieldEffectStartOld(
    BL.Unit unit,
    List<BL.Unit> targets,
    GameObject effectPrefab,
    GameObject targetEffectPrefab,
    System.Action action,
    System.Action targetAction)
  {
    if (unit != (BL.Unit) null)
    {
      UnitUpdate uu = this.env.unitResource[unit].gameObject.GetComponent<UnitUpdate>();
      this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), 0.5f, effectPrefab, endAction: ((System.Action) (() =>
      {
        uu.setAnimationBool("isRun", false);
        uu.setAnimationTrigger("isSkill");
        if (action == null)
          return;
        action();
      })), isWaitCameraMove: true);
    }
    if (targets == null || !((UnityEngine.Object) targetEffectPrefab != (UnityEngine.Object) null))
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
    GameObject invokedEffectPrefab,
    GameObject targetEffectPrefab,
    System.Action action,
    System.Action targetAction,
    List<BL.Unit> invokedTargetUnits,
    System.Action<BL.Unit> targetEndAction = null,
    int waitTiming = 0,
    List<Quaternion?> invokedEffectRotate = null,
    System.Action invokedAction = null,
    List<BL.Panel> targetPanels = null,
    System.Action<BL.Panel> targetPanelEndAction = null)
  {
    if (fe == null)
    {
      this.skillFieldEffectStartOld(unit, targets, effectPrefab, targetEffectPrefab, action, targetAction);
    }
    else
    {
      if (unit != (BL.Unit) null)
      {
        UnitUpdate uu = this.env.unitResource[unit].gameObject.GetComponent<UnitUpdate>();
        if (fe.user_move_camera)
        {
          if (waitTiming == 0)
          {
            this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), fe.user_wait_seconds, effectPrefab, endAction: ((System.Action) (() =>
            {
              uu.setAnimationBool("isRun", false);
              uu.setAnimationTrigger("isSkill");
              if (action == null)
                return;
              action();
            })), isWaitCameraMove: true);
          }
          else
          {
            this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), 0.0f, effectPrefab, endAction: ((System.Action) (() =>
            {
              uu.setAnimationBool("isRun", false);
              uu.setAnimationTrigger("isSkill");
              if (action == null)
                return;
              action();
            })), isWaitCameraMove: true);
            this.btm.setScheduleAction((System.Action) null, fe.user_wait_seconds);
          }
        }
        else
          this.btm.setScheduleAction((System.Action) (() =>
          {
            uu.setAnimationBool("isRun", false);
            uu.setAnimationTrigger("isSkill");
            if ((UnityEngine.Object) effectPrefab != (UnityEngine.Object) null)
              this.execFieldEffect(effectPrefab, uu.transform);
            if (action == null)
              return;
            action();
          }), fe.user_wait_seconds);
      }
      if ((UnityEngine.Object) invokedEffectPrefab != (UnityEngine.Object) null && invokedTargetUnits != null)
      {
        if (fe.invoked_move_camera)
          this.btm.setTargetUnit(this.env.core.getUnitPosition(invokedTargetUnits[0]), 0.0f, isWaitCameraMove: true);
        this.btm.setScheduleAction((System.Action) (() =>
        {
          int num = 0;
          foreach (BL.Unit invokedTargetUnit in invokedTargetUnits)
          {
            Quaternion? rotate = new Quaternion?();
            if (invokedEffectRotate != null)
              rotate = invokedEffectRotate[num++];
            this.execFieldEffect(invokedEffectPrefab, this.env.unitResource[invokedTargetUnit].gameObject.GetComponent<UnitUpdate>().transform, rotate);
          }
          if (invokedAction == null)
            return;
          invokedAction();
        }), fe.invoked_wait_seconds);
      }
      if (!((UnityEngine.Object) targetEffectPrefab != (UnityEngine.Object) null) || targets == null && (targetPanels == null || targetPanels.Count < 1))
        return;
      if (targetPanels != null && targetPanels.Count >= 1)
      {
        if (fe.targets_multiple_effect)
        {
          this.btm.setScheduleAction((System.Action) (() =>
          {
            this.fieldEffectsStartAtPanel(targetEffectPrefab, targetPanels);
            if (targetAction == null)
              return;
            targetAction();
          }), fe.target_wait_seconds, (System.Action) (() =>
          {
            if (targetPanelEndAction == null)
              return;
            foreach (BL.Panel targetPanel in targetPanels)
              targetPanelEndAction(targetPanel);
          }));
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
            foreach (BL.Panel targetPanel in targetPanels)
            {
              BL.Panel ct = targetPanel;
              System.Action endAction = (System.Action) null;
              if (targetPanelEndAction != null)
                endAction = (System.Action) (() => targetPanelEndAction(ct));
              if (waitTiming == 0)
              {
                this.btm.setTargetPanel(ct, fe.target_wait_seconds, endAction: ((System.Action) (() =>
                {
                  if ((UnityEngine.Object) targetEffectPrefab != (UnityEngine.Object) null)
                    this.fieldEffectsStartAtPanel(targetEffectPrefab, ct);
                  if (endAction == null)
                    return;
                  endAction();
                })));
              }
              else
              {
                this.btm.setTargetPanel(ct, 0.0f, endAction: ((System.Action) (() =>
                {
                  if (!((UnityEngine.Object) targetEffectPrefab != (UnityEngine.Object) null))
                    return;
                  this.fieldEffectsStartAtPanel(targetEffectPrefab, ct);
                })));
                this.btm.setScheduleAction((System.Action) null, fe.target_wait_seconds, endAction);
              }
            }
          }
          else
          {
            foreach (BL.Panel targetPanel in targetPanels)
            {
              BL.Panel ct = targetPanel;
              System.Action endAction = (System.Action) null;
              if (targetPanelEndAction != null)
                endAction = (System.Action) (() => targetPanelEndAction(ct));
              this.btm.setScheduleAction((System.Action) (() =>
              {
                BE.PanelResource panelResource = this.env.panelResource[ct];
                this.execFieldEffect(targetEffectPrefab, panelResource.gameObject.transform, localPosition: new Vector3?(panelResource.gameObject.GetComponent<BattlePanelParts>().getLocalPosition()));
              }), fe.target_wait_seconds, endAction);
            }
          }
        }
      }
      else if (fe.targets_multiple_effect)
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.fieldEffectsStart(targetEffectPrefab, targets);
          if (targetAction == null)
            return;
          targetAction();
        }), fe.target_wait_seconds, (System.Action) (() =>
        {
          if (targetEndAction == null)
            return;
          foreach (BL.Unit target in targets)
            targetEndAction(target);
        }));
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
          {
            BL.Unit ct = target;
            System.Action endAction = (System.Action) null;
            if (targetEndAction != null)
              endAction = (System.Action) (() => targetEndAction(ct));
            if (waitTiming == 0)
            {
              this.btm.setTargetUnit(this.env.core.getUnitPosition(ct), fe.target_wait_seconds, targetEffectPrefab, endAction: endAction);
            }
            else
            {
              this.btm.setTargetUnit(this.env.core.getUnitPosition(ct), 0.0f, targetEffectPrefab);
              this.btm.setScheduleAction((System.Action) null, fe.target_wait_seconds, endAction);
            }
          }
        }
        else
        {
          foreach (BL.Unit target in targets)
          {
            BL.Unit ct = target;
            System.Action endAction = (System.Action) null;
            if (targetEndAction != null)
              endAction = (System.Action) (() => targetEndAction(ct));
            this.btm.setScheduleAction((System.Action) (() => this.execFieldEffect(targetEffectPrefab, this.env.unitResource[ct].gameObject.transform)), fe.target_wait_seconds, endAction);
          }
        }
      }
    }
  }

  public void skillFieldEffectMultiStartCore(
    BattleskillFieldEffect[] aryFe,
    List<BL.Unit>[] aryTargets,
    GameObject[] aryInvokedEffectPrefab,
    GameObject[] aryTargetEffectPrefab,
    List<BL.Unit>[] aryInvokedTargetUnits,
    List<Quaternion?>[] aryInvokedEffectRotate = null,
    List<BL.Panel>[] aryTargetPanels = null)
  {
    if (aryFe == null)
      return;
    int length = aryFe.Length;
    this.btm.setSchedule(new Schedule()
    {
      isSetBattleEnable = true,
      isBattleEnable = false
    });
    for (int index = 0; index < length; ++index)
    {
      if (aryFe[index] != null && aryInvokedTargetUnits[index] != null && aryFe[index].invoked_move_camera)
      {
        this.btm.setTargetUnit(this.env.core.getUnitPosition(aryInvokedTargetUnits[index][0]), 0.0f, isWaitCameraMove: true);
        break;
      }
    }
    float num1 = 0.0f;
    for (int index1 = 0; index1 < length; ++index1)
    {
      if (aryFe[index1] != null && (UnityEngine.Object) aryInvokedEffectPrefab[index1] != (UnityEngine.Object) null && aryInvokedTargetUnits[index1] != null)
      {
        int idx = index1;
        this.btm.setScheduleAction((System.Action) (() =>
        {
          foreach (var data in aryInvokedTargetUnits[idx].Select((target, index) => new
          {
            target = target,
            index = index
          }))
          {
            Quaternion? rotate = new Quaternion?();
            if (aryInvokedEffectRotate != null && aryInvokedEffectRotate[idx] != null)
              rotate = aryInvokedEffectRotate[idx][data.index];
            this.execFieldEffect(aryInvokedEffectPrefab[idx], this.env.unitResource[data.target].gameObject.GetComponent<UnitUpdate>().transform, rotate);
          }
        }));
        num1 = Mathf.Max(num1, aryFe[index1].invoked_wait_seconds);
      }
    }
    if ((double) num1 > 0.0)
      this.btm.setScheduleAction((System.Action) null, num1);
    float num2 = 0.0f;
    for (int index = 0; index < length; ++index)
    {
      if (aryFe[index] != null && (UnityEngine.Object) aryTargetEffectPrefab[index] != (UnityEngine.Object) null && (aryTargets[index] != null || aryTargetPanels != null && aryTargetPanels[index] != null && aryTargetPanels[index].Count >= 1))
      {
        int idx = index;
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (aryTargetPanels != null && aryTargetPanels[idx] != null && aryTargetPanels[idx].Count >= 1)
            this.fieldEffectsStartAtPanel(aryTargetEffectPrefab[idx], aryTargetPanels[idx]);
          else
            this.fieldEffectsStart(aryTargetEffectPrefab[idx], aryTargets[idx]);
        }));
        num2 = Mathf.Max(num2, aryFe[index].target_wait_seconds);
      }
    }
    if ((double) num2 > 0.0)
      this.btm.setScheduleAction((System.Action) null, num2);
    this.btm.setSchedule(new Schedule()
    {
      isSetBattleEnable = true,
      isBattleEnable = this.battleManager.isBattleEnable
    });
  }

  public void skillFieldEffectStart(
    BL.Unit unit,
    BL.Skill skill,
    List<BL.Unit> targets,
    List<BL.Unit> invokeUnits,
    System.Action targetAction = null,
    List<Quaternion?> invokedEffectRotate = null,
    System.Action action = null,
    List<BL.Panel> targetPanels = null)
  {
    BE.SkillResource skillResource = this.env.skillResource[skill.skill.field_effect.ID];
    this.skillFieldEffectStartCore(skill.skill.field_effect, unit, targets, skillResource.effectPrefab, skillResource.invokedEffectPrefab, skillResource.targetEffectPrefab, action, targetAction, invokeUnits, invokedEffectRotate: invokedEffectRotate, targetPanels: targetPanels);
  }

  public void mbFieldEffectStart(BL.Unit unit, BL.MagicBullet mb, List<BL.Unit> targets)
  {
    Debug.LogWarning((object) (" === mbFieldEffectStart name:" + mb.name));
    BE.SkillResource skillResource = this.env.skillResource[mb.skill.field_effect.ID];
    this.skillFieldEffectStartCore(mb.skill.field_effect, unit, targets, skillResource.effectPrefab, skillResource.invokedEffectPrefab, skillResource.targetEffectPrefab, (System.Action) null, (System.Action) null, new List<BL.Unit>()
    {
      unit
    });
  }

  public void itemFieldEffectStart(List<BL.Unit> targets, BL.Item item, System.Action action)
  {
    BE.ItemResource itemResource = this.env.itemResource[item.itemId];
    this.skillFieldEffectStartCore(item.item.skill.field_effect, (BL.Unit) null, targets, (GameObject) null, (GameObject) null, itemResource.targetEffectPrefab, (System.Action) null, action, (List<BL.Unit>) null);
  }

  public void fieldEffectsStart(GameObject prefab, List<BL.Unit> targets, float delay = 0.0f)
  {
    foreach (BL.Unit target in targets)
    {
      BE.UnitResource unitResource = this.env.unitResource[target];
      this.StartCoroutine(this.doFieldEffect(prefab, unitResource.gameObject.transform, delay));
    }
  }

  public void fieldEffectsStartAtPanel(GameObject prefab, List<BL.Panel> targets, float delay = 0.0f)
  {
    foreach (BL.Panel target in targets)
    {
      BE.PanelResource panelResource = this.env.panelResource[target];
      this.StartCoroutine(this.doFieldEffect(prefab, panelResource.gameObject.transform, delay, localPosition: new Vector3?(panelResource.gameObject.GetComponent<BattlePanelParts>().getLocalPosition())));
    }
  }

  public void fieldEffectsStart(GameObject prefab, BL.Unit target, float delay = 0.0f)
  {
    BE.UnitResource unitResource = this.env.unitResource[target];
    this.StartCoroutine(this.doFieldEffect(prefab, unitResource.gameObject.transform, delay));
  }

  public void fieldEffectsStartAtPanel(GameObject prefab, BL.Panel target, float delay = 0.0f)
  {
    BE.PanelResource panelResource = this.env.panelResource[target];
    this.StartCoroutine(this.doFieldEffect(prefab, panelResource.gameObject.transform, delay, localPosition: new Vector3?(panelResource.gameObject.GetComponent<BattlePanelParts>().getLocalPosition())));
  }

  public abstract class CloneEnumlator
  {
    public abstract IEnumerator doBody(GameObject o);
  }

  public class StartEffect : ScheduleEnumerator
  {
    private Transform tf;
    private float wait;
    private bool isBattleEnableControl;
    private bool isSkippedVoiceStop;
    private BattleEffects parent;
    private System.Action<ScheduleEnumerator> onClickMask;
    private GameObject popupPrefab;
    private bool alert;
    private bool isCloned;
    private System.Action<GameObject> cloneAction;
    private BattleEffects.CloneEnumlator cloneE;
    private bool isUnmask;
    private bool isViewBack;
    private bool isEffectStopRequest;
    private bool isAlertButtonNoneState;

    public StartEffect(
      Transform t,
      float wait,
      System.Action endAction,
      bool isBattleEnableControl,
      bool isSkippedVoiceStop,
      BattleEffects parent,
      System.Action<ScheduleEnumerator> onClickMask,
      GameObject popupPrefab,
      bool alert,
      bool isCloned,
      System.Action<GameObject> cloneAction,
      BattleEffects.CloneEnumlator cloneE,
      bool isUnmask,
      bool isViewBack,
      bool isButtonNoneState)
    {
      this.tf = t;
      this.wait = wait;
      this.endAction = endAction;
      this.isBattleEnableControl = isBattleEnableControl;
      this.isSkippedVoiceStop = isSkippedVoiceStop;
      this.parent = parent;
      this.onClickMask = onClickMask;
      this.isCompleted = false;
      this.popupPrefab = popupPrefab;
      this.alert = alert;
      this.isCloned = isCloned;
      this.cloneAction = cloneAction;
      this.cloneE = cloneE;
      this.isUnmask = isUnmask;
      this.isViewBack = isViewBack;
      this.isInsertMode = true;
      this.isAlertButtonNoneState = isButtonNoneState;
    }

    public void StopEffect() => this.isEffectStopRequest = true;

    public override IEnumerator doBody()
    {
      BattleEffects.StartEffect startEffect = this;
      EventDelegate ed = (EventDelegate) null;
      startEffect.parent.battleManager.popupCloseAll();
      startEffect.parent.isPopupDismiss = false;
      if (startEffect.alert)
        ed = new EventDelegate((MonoBehaviour) startEffect.parent, "onPopupDismiss");
      GameObject po = startEffect.isCloned ? startEffect.popupPrefab : startEffect.popupPrefab.Clone();
      if (startEffect.cloneAction != null)
        startEffect.cloneAction(po);
      if (startEffect.cloneE != null)
      {
        IEnumerator e = startEffect.cloneE.doBody(po);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      startEffect.parent.battleManager.popupOpen(po, startEffect.alert, ed, true, startEffect.isBattleEnableControl, startEffect.isUnmask, startEffect.isViewBack, true, startEffect.isAlertButtonNoneState);
      if (startEffect.onClickMask != null && (UnityEngine.Object) Singleton<PopupManager>.GetInstance().currentMaskTween != (UnityEngine.Object) null)
      {
        UIButton orAddComponent = Singleton<PopupManager>.GetInstance().currentMaskTween.gameObject.GetOrAddComponent<UIButton>();
        orAddComponent.pressed = orAddComponent.defaultColor;
        // ISSUE: reference to a compiler-generated method
        orAddComponent.onClick.Add(new EventDelegate(new EventDelegate.Callback(startEffect.\u003CdoBody\u003Eb__17_0)));
      }
      if ((UnityEngine.Object) po != (UnityEngine.Object) null)
      {
        po.SetActive(false);
        po.SetActive(true);
      }
      if ((UnityEngine.Object) startEffect.tf != (UnityEngine.Object) null)
      {
        startEffect.tf.gameObject.SetActive(true);
        EffectSE component = startEffect.tf.gameObject.GetComponent<EffectSE>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          startEffect.parent.StartCoroutine(component.PlaySE());
      }
      while ((double) startEffect.time - (double) startEffect.startTime < (double) startEffect.wait && (!startEffect.parent.isPopupDismiss && !startEffect.isEffectStopRequest))
        yield return (object) null;
      NGSoundManager sm = Singleton<NGSoundManager>.GetInstance();
      while (!sm.IsVoiceStopAll())
      {
        if (startEffect.parent.isPopupDismiss)
        {
          sm.stopVoice();
          break;
        }
        if (!startEffect.isSkippedVoiceStop && !startEffect.isEffectStopRequest)
          yield return (object) null;
        else
          break;
      }
      if ((UnityEngine.Object) startEffect.tf != (UnityEngine.Object) null)
        startEffect.tf.gameObject.SetActive(false);
      startEffect.parent.battleManager.popupDismiss(startEffect.isBattleEnableControl);
      startEffect.isCompleted = true;
    }
  }
}
