// Decompiled with JetBrains decompiler
// Type: NGDuelDataManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGDuelDataManager : Singleton<NGDuelDataManager>
{
  private BattleMap mMapData;
  private GameObject mMapObject;
  private Color duelAmbientLight = Color.white;
  [SerializeField]
  private Transform mRoot3d;
  private GameObject duelMap;
  private int oldMapId;
  private bool isPreloadPrefabs;
  public Dictionary<string, RuntimeAnimatorController> dicAnimator = new Dictionary<string, RuntimeAnimatorController>();
  public Dictionary<string, RuntimeAnimatorController> cameraAnimator = new Dictionary<string, RuntimeAnimatorController>();

  public GameObject mDamagePrefab { get; private set; }

  public GameObject mCriticalEffect { get; private set; }

  public GameObject mMissEffect { get; private set; }

  public GameObject mShadow { get; private set; }

  public GameObject mDuelSupport { get; private set; }

  public GameObject mCriticalFlash { get; private set; }

  public GameObject mWeakEffect { get; private set; }

  public GameObject mResistEffect { get; private set; }

  public void Init() => this.Finalize();

  protected override void Initialize() => this.Init();

  private void Finalize()
  {
    Object.Destroy((Object) this.mMapObject);
    this.mMapObject = (GameObject) null;
    this.mDamagePrefab = (GameObject) null;
    this.mMissEffect = (GameObject) null;
    this.mShadow = (GameObject) null;
    this.mDuelSupport = (GameObject) null;
    this.mCriticalFlash = (GameObject) null;
    this.mWeakEffect = (GameObject) null;
    this.mResistEffect = (GameObject) null;
    this.dicAnimator.Clear();
    this.dicAnimator = new Dictionary<string, RuntimeAnimatorController>();
    this.cameraAnimator.Clear();
    this.cameraAnimator = new Dictionary<string, RuntimeAnimatorController>();
    this.oldMapId = -1;
    this.isPreloadPrefabs = false;
  }

  [DebuggerHidden]
  public IEnumerator createMapCache(BL.Stage stage, bool isColosseum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelDataManager.\u003CcreateMapCache\u003Ec__Iterator8AD()
    {
      isColosseum = isColosseum,
      stage = stage,
      \u003C\u0024\u003EisColosseum = isColosseum,
      \u003C\u0024\u003Estage = stage,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator createMap(
    BL.Stage stage,
    bool isColosseum,
    Transform root3d,
    Light directionalLight)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelDataManager.\u003CcreateMap\u003Ec__Iterator8AE()
    {
      stage = stage,
      isColosseum = isColosseum,
      directionalLight = directionalLight,
      \u003C\u0024\u003Estage = stage,
      \u003C\u0024\u003EisColosseum = isColosseum,
      \u003C\u0024\u003EdirectionalLight = directionalLight,
      \u003C\u003Ef__this = this
    };
  }

  public void ResetLight(Light directionalLight)
  {
    if (this.mMapData == null)
      return;
    RenderSettings.ambientLight = this.mMapData.getDuelAmbientColor();
    ((Component) directionalLight).transform.rotation = this.mMapData.getDuelDirectionalLightRotate();
    directionalLight.color = this.mMapData.getDuelDirectionalLightColor();
    directionalLight.intensity = this.mMapData.duel_directional_light_intensity;
  }

  public void SetActiveMap(bool active)
  {
    if (Object.op_Equality((Object) this.mMapObject, (Object) null))
      return;
    this.mMapObject.SetActive(active);
  }

  [DebuggerHidden]
  public IEnumerator preloadDuelUnitObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelDataManager.\u003CpreloadDuelUnitObject\u003Ec__Iterator8AF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator loadDefaultAnimatorController(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelDataManager.\u003CloadDefaultAnimatorController\u003Ec__Iterator8B0()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit
    };
  }

  public Future<RuntimeAnimatorController> loadDuelCamera(string name)
  {
    return this.cameraAnimator.ContainsKey(name) ? Future.Single<RuntimeAnimatorController>(this.cameraAnimator[name]) : Singleton<ResourceManager>.GetInstance().Load<RuntimeAnimatorController>(string.Format("Animators/Camera/{0}", (object) name)).Then<RuntimeAnimatorController>((Func<RuntimeAnimatorController, RuntimeAnimatorController>) (x =>
    {
      this.cameraAnimator.Add(name, x);
      return x;
    }));
  }
}
