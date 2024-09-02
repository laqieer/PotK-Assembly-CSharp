// Decompiled with JetBrains decompiler
// Type: BattleUnitParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleUnitParts : BattleMonoBehaviour
{
  private BattleUnitController unitController;
  private GameObject nonTransform;
  private GameObject shadow;
  private GameObject unitObject;
  private UnitAngle angle;
  private clipEffectPlayer cst;
  private UnitUpdate _unitUpdate;
  private BattleInputObserver inputObserver;
  private BL.BattleModified<BL.UnitPosition> positionModified;
  private BL.BattleModified<BL.Unit> unitModified;
  private BL.BattleModified<BL.PhaseState> phaseModified;
  private Renderer unitRenderer;
  private Material[] normalMaterials;
  private Material[] grayMaterials;
  private Renderer bikeRenderer;
  private Material[] bikeNormalMaterials;
  private Material[] bikeGrayMaterials;
  private Renderer equipARenderer;
  private Renderer equipBRenderer;
  private Material[] equipANormalMaterials;
  private Material[] equipBNormalMaterials;
  private Material[] equipAGrayMaterials;
  private Material[] equipBGrayMaterials;
  private HpGauge hpGauge;
  private HpNumber hpNumber;
  private GameObject damageEffect;
  private GameObject criticalDamageEffect;
  private GameObject missEffect;
  private GameObject criticalEffect;
  private BattleFiledSkillIconEffect skillIconEffect;
  private Dictionary<int, GameObject> ailmentEffectObjects;
  private bool enableEffectMode;
  private bool isGray;
  private bool oIsMoving;
  private BL.Panel thisPanel;
  private float moveSpeed;

  private UnitUpdate unitUpdate
  {
    get
    {
      if (Object.op_Equality((Object) this._unitUpdate, (Object) null))
        this._unitUpdate = ((Component) this).gameObject.GetComponent<UnitUpdate>();
      return this._unitUpdate;
    }
  }

  private bool isActive
  {
    set
    {
      this.nonTransform.SetActive(value);
      this.unitObject.SetActive(value);
      if (!Object.op_Inequality((Object) this.shadow, (Object) null))
        return;
      this.shadow.SetActive(value);
    }
    get => this.unitObject.activeSelf;
  }

  public void setActive(bool v)
  {
    if (v && (this.positionModified == null || !this.positionModified.value.unit.isEnable || this.positionModified.value.unit.isDead))
      return;
    this.isActive = v;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitParts.\u003CStart_Battle\u003Ec__Iterator83D()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void setMaterials(Renderer r, Material[] mats) => r.materials = mats;

  public void setUnitPosition(
    BL.UnitPosition unitPosition,
    GameObject uo,
    GameObject shadowPrefab,
    GameObject damageEffectPrefab,
    GameObject criticalDamageEffectPrefab,
    GameObject missEffectPrefab,
    GameObject criticalEffectPrefab,
    GameObject skillIconEffectPrefab)
  {
    BL.Unit unit = unitPosition.unit;
    this.positionModified = BL.Observe<BL.UnitPosition>(unitPosition);
    this.unitModified = BL.Observe<BL.Unit>(unit);
    this.env.unitResource[unit].gameObject = ((Component) this).gameObject;
    this.hpGauge = ((Component) this).GetComponentsInChildren<HpGauge>(true)[0];
    this.hpGauge.setUnit(unit);
    this.nonTransform = ((Component) ((Component) this.hpGauge).gameObject.transform.parent).gameObject;
    this.nonTransform.transform.localRotation = this.battleManager.unitNonTransformRotationValue;
    this.hpNumber = ((Component) this).GetComponentsInChildren<HpNumber>(true)[0];
    this.hpNumber.setUnit(unit);
    this.setUnitObject(unit, uo);
    if (Object.op_Inequality((Object) damageEffectPrefab, (Object) null))
    {
      this.damageEffect = damageEffectPrefab.Clone(this.nonTransform.transform);
      this.damageEffect.SetActive(false);
    }
    if (Object.op_Inequality((Object) criticalDamageEffectPrefab, (Object) null))
    {
      this.criticalDamageEffect = criticalDamageEffectPrefab.Clone(this.nonTransform.transform);
      this.criticalDamageEffect.SetActive(false);
    }
    if (Object.op_Inequality((Object) missEffectPrefab, (Object) null))
    {
      this.missEffect = missEffectPrefab.Clone(this.nonTransform.transform);
      this.missEffect.SetActive(false);
    }
    if (Object.op_Inequality((Object) criticalEffectPrefab, (Object) null))
    {
      this.criticalEffect = criticalEffectPrefab.Clone(this.nonTransform.transform);
      this.criticalEffect.SetActive(false);
    }
    if (Object.op_Inequality((Object) skillIconEffectPrefab, (Object) null))
    {
      this.skillIconEffect = skillIconEffectPrefab.CloneAndGetComponent<BattleFiledSkillIconEffect>(this.nonTransform);
      ((Component) this.skillIconEffect).gameObject.SetActive(false);
    }
    if (Object.op_Inequality((Object) shadowPrefab, (Object) null))
    {
      this.shadow = shadowPrefab.Clone(((Component) this).transform);
      this.shadow.transform.localPosition = this.battleManager.unitShadowOffsetValue;
    }
    this.angle = ((Component) this).GetComponentsInChildren<UnitAngle>(true)[0];
    clipEffectPlayer[] componentsInChildren = ((Component) this).GetComponentsInChildren<clipEffectPlayer>(true);
    if (componentsInChildren != null && componentsInChildren.Length > 0)
      this.cst = componentsInChildren[0];
    this.isActive = unit.isEnable && unit.spawnTurn <= this.env.core.phaseState.turnCount && !unit.isDead;
    this.ailmentEffectObjects = new Dictionary<int, GameObject>();
  }

  public BL.UnitPosition getUnitPosition() => this.positionModified.value;

  [DebuggerHidden]
  private IEnumerator doDead()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitParts.\u003CdoDead\u003Ec__Iterator83E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetAnimationTrigger(string trigger) => this.unitUpdate.setAnimationTrigger(trigger);

  public void SetRun(bool v) => this.unitUpdate.isForceRun = v;

  [DebuggerHidden]
  private IEnumerator doSpawn()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitParts.\u003CdoSpawn\u003Ec__Iterator83F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doRebirth()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitParts.\u003CdoRebirth\u003Ec__Iterator840()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void moveStayUpdate()
  {
    this.setUnitUpdate();
    this.unitUpdate.PosStayUpdate();
    this.unitUpdate.AngleStayUpdate();
    this.positionModified.isChangedOnce();
  }

  private void setUnitUpdate()
  {
    BL.UnitPosition unitPosition = this.positionModified.value;
    BL.Panel fieldPanel = this.env.core.getFieldPanel(unitPosition.row, unitPosition.column);
    if (fieldPanel == null || this.env.panelResource[fieldPanel] == null || Object.op_Equality((Object) this.env.panelResource[fieldPanel].gameObject, (Object) null))
      return;
    this.unitUpdate.SetAimPos(this.env.panelResource[fieldPanel].gameObject.transform.localPosition);
    this.unitUpdate.SetStayRotateY(unitPosition.direction);
    if (Object.op_Inequality((Object) this.cst, (Object) null))
      this.cst.setGroundStatus(fieldPanel.landform);
    if (!this.unitModified.value.isDead)
      return;
    this.unitUpdate.PosStayUpdate();
    this.unitUpdate.AngleStayUpdate();
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.isActive)
    {
      if (!this.positionModified.isChanged || !this.unitModified.value.isDead)
        return;
      this.setUnitUpdate();
      this.positionModified.isChangedOnce();
    }
    else
    {
      if (!this.enableEffectMode && this.unitModified.isChangedOnce())
        this.setAilmentEffect(this.unitModified.value, new HashSet<int>(this.unitModified.value.skillEffects.Where(BattleskillSkillType.ailment).Select<BattleskillSkill, int>((Func<BattleskillSkill, int>) (x => x.ailment_effect.ID))));
      bool flag1 = this.positionModified.isChangedOnce();
      BL.UnitPosition unitPosition = this.positionModified.value;
      if (flag1)
        this.setUnitUpdate();
      if (this.enableEffectMode)
        return;
      bool flag2 = !unitPosition.unit.isDead && unitPosition.isCompleted && (this.battleManager.isOvo || this.env.core.currentPhaseUnitp(unitPosition.unit));
      if (flag2 == this.isGray && !this.phaseModified.isChangedOnce())
        return;
      if (flag2)
      {
        if (this.grayMaterials.Length != 0)
        {
          this.setMaterials(this.unitRenderer, this.grayMaterials);
          if (Object.op_Inequality((Object) this.bikeRenderer, (Object) null))
            this.setMaterials(this.bikeRenderer, this.bikeGrayMaterials);
          if (Object.op_Inequality((Object) this.equipARenderer, (Object) null))
            this.setMaterials(this.equipARenderer, this.equipAGrayMaterials);
          if (Object.op_Inequality((Object) this.equipBRenderer, (Object) null))
            this.setMaterials(this.equipBRenderer, this.equipBGrayMaterials);
        }
        this.isGray = true;
      }
      else
      {
        this.setMaterials(this.unitRenderer, this.normalMaterials);
        if (Object.op_Inequality((Object) this.bikeRenderer, (Object) null))
          this.setMaterials(this.bikeRenderer, this.bikeNormalMaterials);
        if (Object.op_Inequality((Object) this.equipARenderer, (Object) null))
          this.setMaterials(this.equipARenderer, this.equipANormalMaterials);
        if (Object.op_Inequality((Object) this.equipBRenderer, (Object) null))
          this.setMaterials(this.equipBRenderer, this.equipBNormalMaterials);
        this.isGray = false;
      }
    }
  }

  public void setAilmentEffect(BL.Unit unit, HashSet<int> currentAilmentIDs)
  {
    foreach (int key in this.ailmentEffectObjects.Keys.Where<int>((Func<int, bool>) (x => Object.op_Inequality((Object) this.ailmentEffectObjects[x], (Object) null) && this.ailmentEffectObjects[x].activeSelf)).Except<int>((IEnumerable<int>) currentAilmentIDs))
      this.ailmentEffectObjects[key].SetActive(false);
    foreach (int currentAilmentId in currentAilmentIDs)
    {
      if (this.ailmentEffectObjects.ContainsKey(currentAilmentId))
        this.ailmentEffectObjects[currentAilmentId].SetActive(true);
      else if (this.env.ailmentSkillResource.ContainsKey(currentAilmentId) && Object.op_Inequality((Object) this.env.ailmentSkillResource[currentAilmentId].targetEffectPrefab, (Object) null))
        this.ailmentEffectObjects.Add(currentAilmentId, this.env.ailmentSkillResource[currentAilmentId].targetEffectPrefab.Clone(this.nonTransform.transform));
    }
  }

  public void setDirection(float dir) => this.positionModified.value.direction = dir;

  public bool isMoveUnit() => this.unitController.isMoveUnit(((Component) this).gameObject);

  private bool mIsMoving
  {
    get => this.oIsMoving;
    set
    {
      this.battleManager.getController<BattleUIController>().uiButtonEnable = !value;
      this.oIsMoving = value;
    }
  }

  public bool isMoving => this.mIsMoving;

  [DebuggerHidden]
  private IEnumerator doMoving(List<BL.Panel> panels)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitParts.\u003CdoMoving\u003Ec__Iterator841()
    {
      panels = panels,
      \u003C\u0024\u003Epanels = panels,
      \u003C\u003Ef__this = this
    };
  }

  public void startMoveRoute(List<BL.Panel> route, float speed)
  {
    if (this.mIsMoving)
    {
      this.StopCoroutine("doMoving");
      if (this.thisPanel != null && route.Count != 0)
      {
        BL.UnitPosition up = this.positionModified.value;
        int count = route.IndexOf(this.thisPanel);
        switch (count)
        {
          case -1:
            BL.Panel thisPanel = this.thisPanel;
            BL.Panel goal = route[route.Count - 1];
            route = this.env.core.getRouteNonCache(up, thisPanel, goal, this.inputObserver.getMovePanels(up));
            break;
          case 0:
            break;
          default:
            route.RemoveRange(0, count);
            break;
        }
      }
    }
    if (route.Count == 0)
      return;
    if (route.Count >= 2)
    {
      if (route.Count == 2)
        speed *= 1.5f;
      else if (route.Count == 3)
        speed *= 2f;
      else if (route.Count == 4)
        speed *= 2.5f;
      else
        speed *= 3f;
    }
    this.moveSpeed = speed;
    this.mIsMoving = true;
    this.StartCoroutine("doMoving", (object) route);
  }

  public void cancelMove(float speed)
  {
    BL.UnitPosition up = this.positionModified.value;
    if (!this.mIsMoving && !up.isLocalMoved)
      return;
    BL.Panel fieldPanel1 = this.env.core.getFieldPanel(up.row, up.column);
    BL.Panel fieldPanel2 = this.env.core.getFieldPanel(up.originalRow, up.originalColumn);
    this.startMoveRoute(this.env.core.getRouteNonCache(up, fieldPanel1, fieldPanel2, this.inputObserver.getMovePanels(up)), speed);
  }

  public void spawn() => this.StartCoroutine("doSpawn");

  public void dead() => this.StartCoroutine("doDead");

  public void rebirth() => this.StartCoroutine("doRebirth");

  public void dispHpNumber(int prev_hp, int new_hp) => this.hpNumber.StartAnime(prev_hp, new_hp);

  public void DispDamageEffect(BL.DuelTurn turn)
  {
    if (turn.isHit)
    {
      if (turn.isCritical)
      {
        this.criticalEffect.SetActive(true);
        this.criticalDamageEffect.SetActive(true);
      }
      else
        this.damageEffect.SetActive(true);
      if (turn.ailmentEffects == null || turn.ailmentEffects.Length <= 0)
        return;
      this.setAilmentEffect(this.unitModified.value, new HashSet<int>(((IEnumerable<BattleskillAilmentEffect>) turn.ailmentEffects).Select<BattleskillAilmentEffect, int>((Func<BattleskillAilmentEffect, int>) (x => x.ID))));
    }
    else
      this.missEffect.SetActive(true);
  }

  public void DispSkillIconEffect(BattleskillSkill skill)
  {
    ((Component) this.skillIconEffect).gameObject.SetActive(true);
    this.skillIconEffect.SetSkillIcon(skill);
  }

  private void setUnitObject(BL.Unit unit, GameObject o)
  {
    BE.UnitResource unitResource = this.env.unitResource[unit];
    this.unitObject = o;
    float fieldModelScale = unit.unit.field_model_scale;
    o.transform.localScale = new Vector3(fieldModelScale, fieldModelScale, fieldModelScale);
    if (unitResource.completeEquipAMaterials != null)
    {
      Transform childInFind = o.transform.GetChildInFind("equippoint_a");
      if (Object.op_Inequality((Object) childInFind, (Object) null))
      {
        GameObject gameObject = (GameObject) null;
        foreach (Component component in childInFind)
          gameObject = component.gameObject;
        if (Object.op_Inequality((Object) gameObject, (Object) null))
        {
          this.equipARenderer = gameObject.GetComponentInChildren<Renderer>();
          this.equipANormalMaterials = this.equipARenderer.materials;
          this.equipAGrayMaterials = unitResource.completeEquipAMaterials;
        }
      }
    }
    if (unitResource.completeEquipBMaterials != null)
    {
      Transform childInFind = o.transform.GetChildInFind("equippoint_b");
      if (Object.op_Inequality((Object) childInFind, (Object) null))
      {
        GameObject gameObject = (GameObject) null;
        foreach (Component component in childInFind)
          gameObject = component.gameObject;
        if (Object.op_Inequality((Object) gameObject, (Object) null))
        {
          this.equipBRenderer = gameObject.GetComponentInChildren<Renderer>();
          this.equipBNormalMaterials = this.equipBRenderer.materials;
          this.equipBGrayMaterials = unitResource.completeEquipBMaterials;
        }
      }
    }
    GameObject gameObject1 = (GameObject) null;
    Transform childInFind1 = o.transform.GetChildInFind("ridePoint");
    if (Object.op_Inequality((Object) childInFind1, (Object) null))
    {
      foreach (Component component in childInFind1)
        gameObject1 = component.gameObject;
    }
    if (Object.op_Inequality((Object) gameObject1, (Object) null))
    {
      this.unitRenderer = (Renderer) gameObject1.GetComponentInChildren<SkinnedMeshRenderer>();
      foreach (SkinnedMeshRenderer componentsInChild in o.GetComponentsInChildren<SkinnedMeshRenderer>())
      {
        if (Object.op_Inequality((Object) componentsInChild, (Object) null) && Object.op_Inequality((Object) this.unitRenderer, (Object) componentsInChild) && (Object.op_Equality((Object) this.equipARenderer, (Object) null) || Object.op_Inequality((Object) this.equipARenderer, (Object) componentsInChild)) && (Object.op_Equality((Object) this.equipBRenderer, (Object) null) || Object.op_Inequality((Object) this.equipBRenderer, (Object) componentsInChild)))
        {
          this.bikeRenderer = (Renderer) componentsInChild;
          this.bikeNormalMaterials = this.bikeRenderer.materials;
          this.bikeGrayMaterials = unitResource.completeBikeMaterials;
          break;
        }
      }
    }
    else
    {
      foreach (SkinnedMeshRenderer componentsInChild in o.GetComponentsInChildren<SkinnedMeshRenderer>())
      {
        if (Object.op_Inequality((Object) componentsInChild, (Object) null) && (Object.op_Equality((Object) this.equipARenderer, (Object) null) || Object.op_Inequality((Object) this.equipARenderer, (Object) componentsInChild)) && (Object.op_Equality((Object) this.equipBRenderer, (Object) null) || Object.op_Inequality((Object) this.equipBRenderer, (Object) componentsInChild)))
        {
          this.unitRenderer = (Renderer) componentsInChild;
          break;
        }
      }
    }
    Material[] materials = this.unitRenderer.materials;
    if (Object.op_Inequality((Object) unitResource.faceMaterial, (Object) null))
    {
      for (int index = 0; index < materials.Length; ++index)
      {
        if (((Object) materials[index]).name.Contains("_face"))
          materials[index] = unitResource.faceMaterial;
      }
    }
    this.normalMaterials = materials;
    if (((Object) materials[0]).name.Contains("_face"))
      this.grayMaterials = ((IEnumerable<Material>) unitResource.completeMaterials).Reverse<Material>().ToArray<Material>();
    else
      this.grayMaterials = unitResource.completeMaterials;
  }

  public void setHpGauge(int prev, int now) => this.hpGauge.setGauge(prev, now);

  public void SetEffectMode(bool isEffectMode)
  {
    this.enableEffectMode = isEffectMode;
    this.hpGauge.isEffectMode = isEffectMode;
  }
}
