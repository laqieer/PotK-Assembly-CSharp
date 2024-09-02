// Decompiled with JetBrains decompiler
// Type: BattleUnitParts
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

public class BattleUnitParts : BattleMonoBehaviour
{
  private BattleUnitController unitController;
  private MaterialController materialController;
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
  private BL.BattleModified<BL.ModelBase> landTagModified;
  private Renderer unitRenderer;
  private UnityEngine.Material[] normalMaterials;
  private UnityEngine.Material[] grayMaterials;
  private Renderer bikeRenderer;
  private UnityEngine.Material[] bikeNormalMaterials;
  private UnityEngine.Material[] bikeGrayMaterials;
  private Renderer equipARenderer;
  private Renderer equipBRenderer;
  private UnityEngine.Material[] equipANormalMaterials;
  private UnityEngine.Material[] equipBNormalMaterials;
  private UnityEngine.Material[] equipAGrayMaterials;
  private UnityEngine.Material[] equipBGrayMaterials;
  private HpGauge hpGauge;
  private HpNumber hpNumber;
  private GameObject damageEffect;
  private GameObject criticalDamageEffect;
  private GameObject missEffect;
  private GameObject criticalEffect;
  private BattleFiledSkillIconEffect skillIconEffect;
  private BattleTerrainSkillEffect terrainSkillEffect;
  private GameObject jumpLandingEffect;
  private GameObject callEntryEffect;
  private Dictionary<int, GameObject> ailmentEffectObjects;
  private bool enableEffectMode;
  private bool effectModeDontMove;
  private bool isGray;
  private SkillMetamorphosis metamorphosis;
  private bool effectCompleted = true;
  private const float jumpPeekPosY = 20f;
  private const float jumpUpSpeed = 1.2f;
  private const float jumpDownSpeed = 1.5f;
  private const float landBounceSpeed = 0.1f;
  private const float landBounceSizeBottom = 0.7f;
  private const float jumpReturnStartPosY = 0.5f;
  private const float jumpReturnStartPosZ = 2f;
  private const float jumpReturnStartWaitSec = 0.7f;
  private const float jumpReturnDulation = 6f;
  private bool oIsMoving;
  private BL.Panel thisPanel;
  private float moveSpeed;
  private System.Action endMoving;

  public UnitUpdate unitUpdate
  {
    get
    {
      if ((UnityEngine.Object) this._unitUpdate == (UnityEngine.Object) null)
        this._unitUpdate = this.gameObject.GetComponent<UnitUpdate>();
      return this._unitUpdate;
    }
  }

  public bool isActive
  {
    private set
    {
      this.nonTransform.SetActive(value);
      this.unitObject.SetActive(value);
      if (!((UnityEngine.Object) this.shadow != (UnityEngine.Object) null))
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
    bool isJumping = this.positionModified.value.unit.IsJumping;
    if (v & isJumping)
    {
      this.unitObject.SetActive(false);
      this.shadow?.SetActive(false);
    }
    if (v && !isJumping)
      this.unitObject.transform.localPosition = Vector3.zero;
    BL.UnitPosition unitPosition = this.positionModified.value;
    this.env.core.getFieldPanel(unitPosition.row, unitPosition.column).isJumping = v & isJumping;
  }

  protected override IEnumerator Start_Battle()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    BattleUnitParts battleUnitParts = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    battleUnitParts.unitController = battleUnitParts.battleManager.getController<BattleUnitController>();
    battleUnitParts.inputObserver = battleUnitParts.battleManager.getController<BattleInputObserver>();
    battleUnitParts.phaseModified = BL.Observe<BL.PhaseState>(battleUnitParts.env.core.phaseState);
    return false;
  }

  private void setMaterials(Renderer r, UnityEngine.Material[] mats) => r.materials = mats;

  public void setUnitPosition(
    BL.UnitPosition unitPosition,
    GameObject uo,
    GameObject shadowPrefab = null,
    GameObject damageEffectPrefab = null,
    GameObject criticalDamageEffectPrefab = null,
    GameObject missEffectPrefab = null,
    GameObject criticalEffectPrefab = null,
    GameObject skillIconEffectPrefab = null,
    GameObject terrainSkillEffectPrefab = null,
    GameObject jumpLandingEffectPrefab = null,
    GameObject callEntryEffectPrefab = null)
  {
    BL.Unit unit = unitPosition.unit;
    this.positionModified = BL.Observe<BL.UnitPosition>(unitPosition);
    this.unitModified = BL.Observe<BL.Unit>(unit);
    this.env.unitResource[unit].gameObject = this.gameObject;
    this.metamorphosis = unit.metamorphosis;
    this.landTagModified = BL.Observe<BL.ModelBase>(unit.skillEffects.LandTagModified);
    this.landTagModified.isChangedOnce();
    HpGauge[] componentsInChildren1 = this.GetComponentsInChildren<HpGauge>(true);
    if (componentsInChildren1.Length != 0)
    {
      this.hpGauge = componentsInChildren1[0];
      this.hpGauge.setUnit(unit);
      this.nonTransform = this.hpGauge.gameObject.transform.parent.gameObject;
      if (this.battleManager.isRaid && this.battleManager.isRaidBoss(unit))
        this.hpGauge.enableBossMode();
    }
    else
      this.nonTransform = this.gameObject.transform.GetChildInFind("nonTransform").gameObject;
    this.nonTransform.transform.localRotation = this.battleManager.unitNonTransformRotationValue;
    HpNumber[] componentsInChildren2 = this.GetComponentsInChildren<HpNumber>(true);
    if (componentsInChildren2.Length != 0)
    {
      this.hpNumber = componentsInChildren2[0];
      this.hpNumber.setUnit(unit);
    }
    this.materialController = this.battleManager.getController<MaterialController>();
    this.setUnitObject(unit, uo);
    if ((UnityEngine.Object) damageEffectPrefab != (UnityEngine.Object) null)
    {
      this.damageEffect = damageEffectPrefab.Clone(this.nonTransform.transform);
      this.damageEffect.SetActive(false);
    }
    if ((UnityEngine.Object) criticalDamageEffectPrefab != (UnityEngine.Object) null)
    {
      this.criticalDamageEffect = criticalDamageEffectPrefab.Clone(this.nonTransform.transform);
      this.criticalDamageEffect.SetActive(false);
    }
    if ((UnityEngine.Object) missEffectPrefab != (UnityEngine.Object) null)
    {
      this.missEffect = missEffectPrefab.Clone(this.nonTransform.transform);
      this.missEffect.SetActive(false);
    }
    if ((UnityEngine.Object) criticalEffectPrefab != (UnityEngine.Object) null)
    {
      this.criticalEffect = criticalEffectPrefab.Clone(this.nonTransform.transform);
      this.criticalEffect.SetActive(false);
    }
    if ((UnityEngine.Object) skillIconEffectPrefab != (UnityEngine.Object) null)
    {
      this.skillIconEffect = skillIconEffectPrefab.CloneAndGetComponent<BattleFiledSkillIconEffect>(this.nonTransform);
      this.skillIconEffect.gameObject.SetActive(false);
    }
    if ((UnityEngine.Object) terrainSkillEffectPrefab != (UnityEngine.Object) null)
    {
      this.terrainSkillEffect = terrainSkillEffectPrefab.CloneAndGetComponent<BattleTerrainSkillEffect>(this.nonTransform);
      this.terrainSkillEffect.SetCompatibleSkillByEffective(unit);
    }
    if ((UnityEngine.Object) jumpLandingEffectPrefab != (UnityEngine.Object) null)
    {
      this.jumpLandingEffect = jumpLandingEffectPrefab.Clone(this.nonTransform.transform);
      this.jumpLandingEffect.SetActive(false);
    }
    if ((UnityEngine.Object) callEntryEffectPrefab != (UnityEngine.Object) null)
    {
      this.callEntryEffect = callEntryEffectPrefab.Clone(this.nonTransform.transform);
      this.callEntryEffect.SetActive(false);
    }
    if ((UnityEngine.Object) shadowPrefab != (UnityEngine.Object) null)
    {
      this.shadow = shadowPrefab.Clone(this.transform);
      this.shadow.transform.localPosition = this.battleManager.unitShadowOffsetValue;
    }
    UnitAngle[] componentsInChildren3 = this.GetComponentsInChildren<UnitAngle>(true);
    this.angle = componentsInChildren3.Length == 0 ? (UnitAngle) null : componentsInChildren3[0];
    clipEffectPlayer[] componentsInChildren4 = this.GetComponentsInChildren<clipEffectPlayer>(true);
    if (componentsInChildren4 != null && componentsInChildren4.Length != 0)
      this.cst = componentsInChildren4[0];
    this.isActive = unit.isEnable && unit.spawnTurn <= this.env.core.phaseState.turnCount && !unit.isDead && !unit.IsJumping;
    if (unit.isFacility)
      this.unitUpdate.isUpdateAngleOnMove = false;
    this.ailmentEffectObjects = new Dictionary<int, GameObject>();
  }

  public BL.UnitPosition getUnitPosition() => this.positionModified.value;

  private IEnumerator doDead(bool dontReleaseMetamorphosis)
  {
    if ((UnityEngine.Object) this.angle != (UnityEngine.Object) null)
    {
      this.angle.enabled = false;
      this.angle.gameObject.transform.rotation = Quaternion.identity;
    }
    this.unitUpdate.setAnimationTrigger("isDead");
    this.nonTransform.SetActive(false);
    yield return (object) new WaitForSeconds(2f);
    if (this.metamorphosis != null && !dontReleaseMetamorphosis)
    {
      this.metamorphosis = (SkillMetamorphosis) null;
      yield return (object) this.doReloadUnitObject(true);
    }
    this.isActive = false;
  }

  public void SetAnimationTrigger(string trigger) => this.unitUpdate.setAnimationTrigger(trigger);

  public void SetRun(bool v) => this.unitUpdate.isForceRun = v;

  private IEnumerator doSpawn()
  {
    BattleUnitParts battleUnitParts = this;
    if ((UnityEngine.Object) battleUnitParts.angle != (UnityEngine.Object) null)
      battleUnitParts.angle.enabled = true;
    while (!battleUnitParts.bmStatus.StartCompleted)
      yield return (object) null;
    battleUnitParts.isActive = true;
  }

  private IEnumerator doRebirth(bool intoEffectMode = false)
  {
    if (intoEffectMode)
      this.setAilmentEffect(this.unitModified.value, new HashSet<int>(this.unitModified.value.skillEffects.Where(BattleskillSkillType.ailment).Select<BattleskillSkill, int>((Func<BattleskillSkill, int>) (x => x.ailment_effect.ID))));
    IEnumerator e = this.doSpawn();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void moveStayUpdate()
  {
    this.setUnitUpdate();
    this.unitUpdate.PosStayUpdate();
    this.unitUpdate.AngleStayUpdate();
    this.positionModified.isChangedOnce();
  }

  private void setUnitUpdate(bool dontMove = false)
  {
    BL.UnitPosition unitPosition = this.positionModified.value;
    BL.Panel fieldPanel = this.env.core.getFieldPanel(unitPosition.row, unitPosition.column);
    if (fieldPanel == null || this.env.panelResource[fieldPanel] == null || (UnityEngine.Object) this.env.panelResource[fieldPanel].gameObject == (UnityEngine.Object) null)
      return;
    if (!dontMove)
      this.unitUpdate.SetAimPos(this.env.panelResource[fieldPanel].gameObject.transform.localPosition);
    this.unitUpdate.SetStayRotateY(unitPosition.direction);
    if ((UnityEngine.Object) this.cst != (UnityEngine.Object) null)
      this.cst.setGroundStatus(fieldPanel.landform);
    if (this.unitModified.value.isDead)
    {
      this.unitUpdate.PosStayUpdate();
      this.unitUpdate.AngleStayUpdate();
    }
    if (!((UnityEngine.Object) this.terrainSkillEffect != (UnityEngine.Object) null))
      return;
    this.terrainSkillEffect.UpdateState(fieldPanel);
  }

  public void resetTerrainEffect()
  {
    if (!((UnityEngine.Object) this.terrainSkillEffect != (UnityEngine.Object) null))
      return;
    this.terrainSkillEffect.resetIllegalActiveStatus();
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
      if (!this.enableEffectMode && this.landTagModified.isChangedOnce() && (UnityEngine.Object) this.terrainSkillEffect != (UnityEngine.Object) null)
      {
        this.terrainSkillEffect.SetCompatibleSkillByEffective(this.unitModified.value);
        if (!flag1)
        {
          BL.Panel fieldPanel = this.env.core.getFieldPanel(unitPosition.row, unitPosition.column);
          if (fieldPanel != null && fieldPanel.landform != null)
            this.terrainSkillEffect.UpdateState(fieldPanel);
        }
      }
      if (flag1)
        this.setUnitUpdate(this.enableEffectMode && this.effectModeDontMove);
      if (!((UnityEngine.Object) this.unitRenderer != (UnityEngine.Object) null) || this.enableEffectMode)
        return;
      bool flag2 = !unitPosition.unit.isDead && unitPosition.isCompleted && (this.battleManager.isOvo || this.env.core.currentPhaseUnitp(unitPosition.unit));
      if (flag2 == this.isGray && !this.phaseModified.isChangedOnce())
        return;
      if (flag2)
      {
        if (this.grayMaterials.Length != 0)
        {
          this.setMaterials(this.unitRenderer, this.grayMaterials);
          if ((UnityEngine.Object) this.bikeRenderer != (UnityEngine.Object) null)
            this.setMaterials(this.bikeRenderer, this.bikeGrayMaterials);
          if ((UnityEngine.Object) this.equipARenderer != (UnityEngine.Object) null)
            this.setMaterials(this.equipARenderer, this.equipAGrayMaterials);
          if ((UnityEngine.Object) this.equipBRenderer != (UnityEngine.Object) null)
            this.setMaterials(this.equipBRenderer, this.equipBGrayMaterials);
        }
        this.isGray = true;
      }
      else
      {
        this.setMaterials(this.unitRenderer, this.normalMaterials);
        if ((UnityEngine.Object) this.bikeRenderer != (UnityEngine.Object) null)
          this.setMaterials(this.bikeRenderer, this.bikeNormalMaterials);
        if ((UnityEngine.Object) this.equipARenderer != (UnityEngine.Object) null)
          this.setMaterials(this.equipARenderer, this.equipANormalMaterials);
        if ((UnityEngine.Object) this.equipBRenderer != (UnityEngine.Object) null)
          this.setMaterials(this.equipBRenderer, this.equipBNormalMaterials);
        this.isGray = false;
      }
    }
  }

  public void setAilmentEffect(BL.Unit unit, HashSet<int> currentAilmentIDs)
  {
    foreach (int key in this.ailmentEffectObjects.Keys.Where<int>((Func<int, bool>) (x => (UnityEngine.Object) this.ailmentEffectObjects[x] != (UnityEngine.Object) null && this.ailmentEffectObjects[x].activeSelf)).Except<int>((IEnumerable<int>) currentAilmentIDs))
      this.ailmentEffectObjects[key].SetActive(false);
    foreach (int currentAilmentId in currentAilmentIDs)
    {
      if (this.ailmentEffectObjects.ContainsKey(currentAilmentId))
        this.ailmentEffectObjects[currentAilmentId].SetActive(true);
      else if (this.env.ailmentSkillResource.ContainsKey(currentAilmentId) && (UnityEngine.Object) this.env.ailmentSkillResource[currentAilmentId].targetEffectPrefab != (UnityEngine.Object) null)
        this.ailmentEffectObjects.Add(currentAilmentId, this.env.ailmentSkillResource[currentAilmentId].targetEffectPrefab.Clone(this.nonTransform.transform));
    }
  }

  public void setDirection(float dir) => this.positionModified.value.direction = dir;

  public bool isMoveUnit() => this.unitController.isMoveUnit(this.gameObject);

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

  private IEnumerator doMoving(List<BL.Panel> panels)
  {
    BattleUnitParts battleUnitParts = this;
    if (panels != null && panels.Count > 0)
    {
      battleUnitParts.mIsMoving = true;
      battleUnitParts.thisPanel = panels[0];
      yield return (object) null;
      BL.UnitPosition up = battleUnitParts.positionModified.value;
      for (int idx = 0; idx < panels.Count; ++idx)
      {
        BL.Panel panel = panels[idx];
        up.row = panel.row;
        up.column = panel.column;
        battleUnitParts.thisPanel = panel;
        battleUnitParts.unitUpdate.MoveSpeed = battleUnitParts.moveSpeed;
        if (battleUnitParts.env.core.unitCurrent.unit == battleUnitParts.unitModified.value)
          battleUnitParts.env.core.setCurrentField(panel);
        if ((UnityEngine.Object) battleUnitParts.cst != (UnityEngine.Object) null)
          battleUnitParts.cst.setGroundStatus(panel.landform);
        do
        {
          yield return (object) null;
        }
        while (battleUnitParts.unitUpdate.IsMove());
      }
      up = (BL.UnitPosition) null;
    }
    battleUnitParts.thisPanel = (BL.Panel) null;
    battleUnitParts.mIsMoving = false;
    battleUnitParts.env.core.fieldCurrent.commit();
    if (battleUnitParts.endMoving != null)
      battleUnitParts.endMoving();
  }

  public void startMoveRoute(List<BL.Panel> route, float speed, System.Action endMoving = null)
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
    this.moveSpeed = BattleUnitParts.CalcMoveSpeed(route.Count, speed);
    this.mIsMoving = true;
    this.endMoving = endMoving;
    this.StartCoroutine("doMoving", (object) route);
  }

  public static float CalcMoveSpeed(int routeCount, float speed)
  {
    if (routeCount >= 2)
    {
      if (routeCount == 2)
        speed *= 1.5f;
      else if (routeCount == 3)
        speed *= 2f;
      else if (routeCount == 4)
        speed *= 2.5f;
      else
        speed *= 3f;
    }
    return speed;
  }

  public void cancelMove(float speed, System.Action endMoving)
  {
    BL.UnitPosition up = this.positionModified.value;
    if (!this.mIsMoving && !up.isLocalMoved)
      return;
    BL.Panel fieldPanel1 = this.env.core.getFieldPanel(up.row, up.column);
    BL.Panel fieldPanel2 = this.env.core.getFieldPanel(up.originalRow, up.originalColumn);
    this.startMoveRoute(this.env.core.getRouteNonCache(up, fieldPanel1, fieldPanel2, this.inputObserver.getMovePanels(up)), speed, endMoving);
  }

  public void spawn() => this.StartCoroutine("doSpawn");

  public void dead(bool dontReleaseMetamorphosis = false) => this.StartCoroutine("doDead", (object) dontReleaseMetamorphosis);

  public void rebirth(bool intoEffectMode = false) => this.StartCoroutine("doRebirth", (object) intoEffectMode);

  public void jumpUp() => this.StartCoroutine("doJumpUp");

  public void jumpReturn() => this.StartCoroutine("doJumpReturn");

  public void jumpMiss() => this.StartCoroutine("doJumpMiss");

  public void callEntry() => this.StartCoroutine("doCallEntry");

  public void createFacility(float wait) => this.StartCoroutine("doCreateFacility", (object) wait);

  public void destructFacility() => this.StartCoroutine("doDestructFacility");

  public void dispHpNumber(int prev_hp, int new_hp)
  {
    if (!((UnityEngine.Object) this.hpNumber != (UnityEngine.Object) null))
      return;
    this.hpNumber.StartAnime(prev_hp, new_hp);
  }

  public void DispDamageEffect(List<BL.DuelTurn> turns)
  {
    foreach (BL.DuelTurn turn in turns)
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
      }
      else
        this.missEffect.SetActive(true);
    }
  }

  public void DispAilmentEffect(BattleskillAilmentEffect[] ailmentEffects)
  {
    if (ailmentEffects == null || ailmentEffects.Length == 0)
      return;
    this.setAilmentEffect(this.unitModified.value, new HashSet<int>(((IEnumerable<BattleskillAilmentEffect>) ailmentEffects).Select<BattleskillAilmentEffect, int>((Func<BattleskillAilmentEffect, int>) (x => x.ID))));
  }

  public void DispSkillIconEffect(BattleskillSkill skill)
  {
    Camera component = GameObject.Find("3D Camera Objects").GetComponent<Camera>();
    Transform transform1 = this.skillIconEffect.transform.Find("skill_icon");
    Transform transform2 = this.skillIconEffect.transform.Find("effect");
    float x = component.WorldToScreenPoint(this.transform.GetParentInFind("UnitBase(Clone)").transform.position).x;
    Vector3 screenPoint = component.WorldToScreenPoint(transform1.position);
    Vector3 worldPoint = component.ScreenToWorldPoint(new Vector3(x, screenPoint.y, screenPoint.z));
    transform1.position = worldPoint;
    transform2.position = worldPoint;
    this.skillIconEffect.gameObject.SetActive(true);
    this.skillIconEffect.SetSkillIcon(skill);
  }

  private void setUnitObject(BL.Unit unit, GameObject o)
  {
    BE.UnitResource unitResource = this.env.unitResource[unit];
    this.unitObject = o;
    if ((UnityEngine.Object) this.unitObject == (UnityEngine.Object) null)
      return;
    float fieldModelScale = unit.unit.field_model_scale;
    o.transform.localScale = new Vector3(fieldModelScale, fieldModelScale, fieldModelScale);
    Transform childInFind1 = o.transform.GetChildInFind("equippoint_a");
    if ((UnityEngine.Object) childInFind1 != (UnityEngine.Object) null)
    {
      GameObject gameObject = (GameObject) null;
      foreach (Component component in childInFind1)
        gameObject = component.gameObject;
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
      {
        this.equipARenderer = gameObject.GetComponentInChildren<Renderer>();
        this.equipANormalMaterials = this.equipARenderer.materials;
        this.equipAGrayMaterials = this.materialController.CreateGrayScaleMaterial(this.equipARenderer);
      }
    }
    Transform childInFind2 = o.transform.GetChildInFind("equippoint_b");
    if ((UnityEngine.Object) childInFind2 != (UnityEngine.Object) null)
    {
      GameObject gameObject = (GameObject) null;
      foreach (Component component in childInFind2)
        gameObject = component.gameObject;
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
      {
        this.equipBRenderer = gameObject.GetComponentInChildren<Renderer>();
        this.equipBNormalMaterials = this.equipBRenderer.materials;
        this.equipBGrayMaterials = this.materialController.CreateGrayScaleMaterial(this.equipBRenderer);
      }
    }
    GameObject gameObject1 = (GameObject) null;
    Transform childInFind3 = o.transform.GetChildInFind("ridePoint");
    if ((UnityEngine.Object) childInFind3 != (UnityEngine.Object) null)
    {
      foreach (Component component in childInFind3)
        gameObject1 = component.gameObject;
    }
    if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
    {
      this.unitRenderer = (Renderer) gameObject1.GetComponentInChildren<SkinnedMeshRenderer>();
      foreach (SkinnedMeshRenderer componentsInChild in o.GetComponentsInChildren<SkinnedMeshRenderer>())
      {
        if ((UnityEngine.Object) componentsInChild != (UnityEngine.Object) null && (UnityEngine.Object) this.unitRenderer != (UnityEngine.Object) componentsInChild && ((UnityEngine.Object) this.equipARenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipARenderer != (UnityEngine.Object) componentsInChild) && ((UnityEngine.Object) this.equipBRenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipBRenderer != (UnityEngine.Object) componentsInChild))
        {
          this.bikeRenderer = (Renderer) componentsInChild;
          this.bikeNormalMaterials = this.bikeRenderer.materials;
          this.bikeGrayMaterials = this.materialController.CreateGrayScaleMaterial(this.bikeRenderer);
          break;
        }
      }
    }
    else
    {
      foreach (SkinnedMeshRenderer componentsInChild in o.GetComponentsInChildren<SkinnedMeshRenderer>())
      {
        if ((UnityEngine.Object) componentsInChild != (UnityEngine.Object) null && ((UnityEngine.Object) this.equipARenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipARenderer != (UnityEngine.Object) componentsInChild) && ((UnityEngine.Object) this.equipBRenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipBRenderer != (UnityEngine.Object) componentsInChild))
        {
          this.unitRenderer = (Renderer) componentsInChild;
          break;
        }
      }
      if ((UnityEngine.Object) this.unitRenderer == (UnityEngine.Object) null)
      {
        foreach (MeshRenderer componentsInChild in o.GetComponentsInChildren<MeshRenderer>())
        {
          if ((UnityEngine.Object) componentsInChild != (UnityEngine.Object) null && ((UnityEngine.Object) this.equipARenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipARenderer != (UnityEngine.Object) componentsInChild) && ((UnityEngine.Object) this.equipBRenderer == (UnityEngine.Object) null || (UnityEngine.Object) this.equipBRenderer != (UnityEngine.Object) componentsInChild))
          {
            this.unitRenderer = (Renderer) componentsInChild;
            break;
          }
        }
      }
    }
    if (!((UnityEngine.Object) this.unitRenderer != (UnityEngine.Object) null))
      return;
    UnityEngine.Material[] materials = this.unitRenderer.materials;
    if ((UnityEngine.Object) unitResource.faceMaterial != (UnityEngine.Object) null)
    {
      for (int index = 0; index < materials.Length; ++index)
      {
        if (materials[index].name.Contains("_face"))
          materials[index] = unitResource.faceMaterial;
      }
    }
    this.normalMaterials = materials;
    this.grayMaterials = this.materialController.CreateGrayScaleMaterial(materials);
  }

  public void setHpGauge(int prev, int now)
  {
    if (!((UnityEngine.Object) this.hpGauge != (UnityEngine.Object) null))
      return;
    this.hpGauge.setGauge(prev, now);
  }

  public void setHpGauge(int now)
  {
    if (!((UnityEngine.Object) this.hpGauge != (UnityEngine.Object) null))
      return;
    this.hpGauge.setGauge(now);
  }

  public void SetEffectMode(bool isEffectMode, bool dontMove = false)
  {
    this.enableEffectMode = isEffectMode;
    this.effectModeDontMove = dontMove;
    if ((UnityEngine.Object) this.hpGauge != (UnityEngine.Object) null)
      this.hpGauge.isEffectMode = isEffectMode;
    if (!this.enableEffectMode)
      return;
    SkillMetamorphosis metamorphosis = this.unitModified.value.metamorphosis;
    if (this.metamorphosis == metamorphosis)
      return;
    this.metamorphosis = metamorphosis;
    this.StartCoroutine(this.doMetamorphose());
  }

  public bool IsEffectMode() => this.enableEffectMode;

  public void resetPosition(int row, int column)
  {
    Vector3 vector3 = NGBattle3DObjectManager.create3DPosition(row, column);
    Vector3 origin = vector3 + this.gameObject.transform.parent.position;
    origin.y += 50f;
    int layerMask = 1 << LayerMask.NameToLayer("Terrain");
    RaycastHit hitInfo;
    this.gameObject.transform.localPosition = !Physics.Raycast(origin, Vector3.down, out hitInfo, 100f, layerMask) ? vector3 : hitInfo.point - this.gameObject.transform.parent.position;
    this.positionModified.value.column = column;
    this.positionModified.value.row = row;
  }

  public void resetDirection(float direction)
  {
    this.gameObject.transform.GetChildInFind("rot").gameObject.transform.localRotation = Quaternion.Euler(0.0f, direction, 0.0f);
    Transform transform = this.angle.gameObject.transform;
    Vector3 vector3 = new Vector3(1f, 0.0f, 0.0f);
    transform.localRotation = Quaternion.AngleAxis(this.battleManager.unitAngleValue, Quaternion.Inverse(transform.parent.rotation) * vector3);
    this.angle.enabled = true;
    this.positionModified.value.direction = direction;
  }

  public void resetStatus(int row, int column, float direction)
  {
    this.resetPosition(row, column);
    this.resetDirection(direction);
    this.moveStayUpdate();
  }

  public IEnumerator doMetamorphose()
  {
    yield return (object) this.doReloadUnitObject(false);
  }

  private IEnumerator doReloadUnitObject(bool nonMetamor)
  {
    BattleUnitParts battleUnitParts = this;
    BL.Unit unit = battleUnitParts.unitModified.value;
    if (!(unit == (BL.Unit) null) && unit.isView)
    {
      Transform ang = battleUnitParts.gameObject.transform.Find("rot").Find("angle");
      Transform child = ang.GetChildren().FirstOrDefault<Transform>();
      if (!((UnityEngine.Object) child == (UnityEngine.Object) null))
      {
        bool actObj = battleUnitParts.isActive;
        battleUnitParts.effectCompleted = false;
        BE.UnitResource unitR = battleUnitParts.env.unitResource[unit];
        NGBattle3DObjectManager objManager = Singleton<NGBattleManager>.GetInstance().getManager<NGBattle3DObjectManager>();
        unitR.cleanup();
        unitR.gameObject = battleUnitParts.gameObject;
        yield return (object) objManager.reloadInBattleUnitResource(unit, battleUnitParts.env, nonMetamor);
        child.gameObject.SetActive(false);
        UnityEngine.Object.Destroy((UnityEngine.Object) child.gameObject);
        GameObject unitObject = objManager.createUnitObject(ang, unitR.prefab, unitR.bikePrefab, unitR.equipPrefab_a, unitR.equipPrefab_b, battleUnitParts.env.weaponResource[unit.weapon].prefab, unitR.unitEffect, unit.gearLeftHand, unit.gearDualWield);
        battleUnitParts.setUnitObject(unit, unitObject);
        UnitUpdate component = battleUnitParts.transform.GetComponent<UnitUpdate>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          component.ResetAnimation();
        if (!actObj)
          battleUnitParts.isActive = false;
        battleUnitParts.effectCompleted = true;
      }
    }
  }

  public bool checkEffectCompleted() => this.effectCompleted;

  public IEnumerator doJumpUp()
  {
    this.unitUpdate.setAnimationBool("isRun", false);
    this.unitUpdate.setAnimationTrigger("isSkill");
    this.effectCompleted = false;
    this.shadow?.SetActive(false);
    this.unitObject.transform.localPosition = Vector3.zero;
    while ((double) this.unitObject.transform.localPosition.y < 20.0)
    {
      Vector3 localPosition = this.unitObject.transform.localPosition;
      localPosition.y += 1.2f * Time.timeScale;
      this.unitObject.transform.localPosition = localPosition;
      yield return (object) null;
    }
    this.effectCompleted = true;
    this.unitObject.SetActive(false);
  }

  public IEnumerator doJumpReturn()
  {
    this.effectCompleted = false;
    yield return (object) new WaitForSeconds(0.7f);
    this.unitObject.SetActive(true);
    float t = 0.0f;
    while (true)
    {
      t += 0.1666667f * Time.timeScale;
      if ((double) t > 1.0)
        t = 1f;
      this.unitObject.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(0.5f, 0.0f, t), Mathf.Lerp(2f, 0.0f, t));
      if ((double) t < 1.0)
        yield return (object) null;
      else
        break;
    }
    this.jumpLandingEffect?.SetActive(true);
    this.shadow?.SetActive(true);
    this.nonTransform?.SetActive(true);
    yield return (object) null;
    float baseScaleY = this.unitModified.value.unit.field_model_scale;
    if ((double) baseScaleY == 0.0)
      baseScaleY = 1f;
    while ((double) this.unitObject.transform.localScale.y > 0.699999988079071 * (double) baseScaleY)
    {
      Vector3 localScale = this.unitObject.transform.localScale;
      localScale.y -= 0.1f * baseScaleY * Time.timeScale;
      if ((double) localScale.y < 0.699999988079071 * (double) baseScaleY)
        localScale.y = 0.7f * baseScaleY;
      this.unitObject.transform.localScale = localScale;
      yield return (object) null;
    }
    while ((double) this.unitObject.transform.localScale.y < (double) baseScaleY)
    {
      Vector3 localScale = this.unitObject.transform.localScale;
      localScale.y += 0.1f * baseScaleY * Time.timeScale;
      if ((double) localScale.y > (double) baseScaleY)
        localScale.y = baseScaleY;
      this.unitObject.transform.localScale = localScale;
      yield return (object) null;
    }
    if ((UnityEngine.Object) this.jumpLandingEffect != (UnityEngine.Object) null)
    {
      while (this.jumpLandingEffect.activeSelf)
        yield return (object) null;
    }
    this.effectCompleted = true;
  }

  public IEnumerator doJumpMiss()
  {
    this.unitObject.SetActive(true);
    this.effectCompleted = false;
    this.unitObject.transform.localPosition = new Vector3(0.0f, 20f, 0.0f);
    while (true)
    {
      Vector3 localPosition = this.unitObject.transform.localPosition;
      localPosition.y -= 1.5f * Time.timeScale;
      if ((double) localPosition.y < 0.0)
        localPosition.y = 0.0f;
      this.unitObject.transform.localPosition = localPosition;
      if ((double) localPosition.y > 0.0)
        yield return (object) null;
      else
        break;
    }
    this.jumpLandingEffect?.SetActive(true);
    this.shadow?.SetActive(true);
    this.nonTransform?.SetActive(true);
    yield return (object) null;
    while ((double) this.unitObject.transform.localScale.y > 0.699999988079071)
    {
      Vector3 localScale = this.unitObject.transform.localScale;
      localScale.y -= 0.1f * Time.timeScale;
      if ((double) localScale.y < 0.699999988079071)
        localScale.y = 0.7f;
      this.unitObject.transform.localScale = localScale;
      yield return (object) null;
    }
    while ((double) this.unitObject.transform.localScale.y < 1.0)
    {
      Vector3 localScale = this.unitObject.transform.localScale;
      localScale.y += 0.1f * Time.timeScale;
      if ((double) localScale.y > 1.0)
        localScale.y = 1f;
      this.unitObject.transform.localScale = localScale;
      yield return (object) null;
    }
    if ((UnityEngine.Object) this.jumpLandingEffect != (UnityEngine.Object) null)
    {
      while (this.jumpLandingEffect.activeSelf)
        yield return (object) null;
    }
    this.effectCompleted = true;
  }

  public IEnumerator doCallEntry()
  {
    if ((UnityEngine.Object) this.callEntryEffect != (UnityEngine.Object) null)
    {
      this.effectCompleted = false;
      this.callEntryEffect.SetActive(true);
      while (this.callEntryEffect.activeSelf)
        yield return (object) null;
    }
    this.effectCompleted = true;
  }

  public IEnumerator doCreateFacility(float wait)
  {
    this.effectCompleted = false;
    yield return (object) new WaitForSeconds(wait);
    BL.UnitPosition unitPosition = this.positionModified.value;
    this.resetPosition(unitPosition.row, unitPosition.column);
    this.moveStayUpdate();
    this.setActive(true);
    this.effectCompleted = true;
  }

  public IEnumerator doDestructFacility()
  {
    this.effectCompleted = false;
    BL.UnitPosition unitPosition = this.positionModified.value;
    if ((UnityEngine.Object) this.angle != (UnityEngine.Object) null)
    {
      this.angle.enabled = false;
      this.angle.gameObject.transform.rotation = Quaternion.identity;
    }
    this.unitUpdate.setAnimationTrigger("isDead");
    this.nonTransform.SetActive(false);
    yield return (object) new WaitForSeconds(2f);
    this.isActive = false;
    this.effectCompleted = true;
  }
}
