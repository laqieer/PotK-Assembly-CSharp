// Decompiled with JetBrains decompiler
// Type: MapEditOrnament
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class MapEditOrnament : MonoBehaviour
{
  public MapEditFacilityShaderSetting shaderSetting_;
  private bool initialized_;
  private Camera camera_;
  private BoxCollider collider_;
  private Transform myTrans_;
  private Vector3 posTarget_ = Vector3.zero;
  private Vector3 velocityMove_ = Vector3.zero;
  private float smoothTimeMove_ = 0.1f;
  private bool isAutoSearchPanel_;
  private bool isSearchPanel_;
  private MapEdit031TopMenu topMenu_;
  private UnityEngine.Material matSelected_;
  private UnityEngine.Material matNotLocation_;
  private List<MapEditOrnament.MaterialControl> materialControls_ = new List<MapEditOrnament.MaterialControl>();
  private bool calcScreenPoint_;
  private Vector3 nowScreenPoint_ = Vector3.zero;
  private Vector3 targetScreenPoint_ = Vector3.zero;
  private Vector3 velocityMoveScreen_ = Vector3.zero;
  private float smoothTimeMoveScreen_ = 0.1f;
  private BE environment_;
  private const float DEFAULT_BOX_CENTER_Y = 1f;
  private const float DEFAULT_BOX_SIZE = 2f;
  private const float THRESHOLD_ZERO = 0.01f;
  private const float DISTANCE_LAYCAST = 10000f;
  private static int mask_terrain_layer_ = 0;
  private const float RAY_MARGIN = 100f;
  private static int mask_panel_layer_ = 0;
  private static int default_layer_ = -1;
  private static int selected_layer_ = -1;

  public static MapEditOrnament attach(
    GameObject go,
    PlayerGuildFacility facility,
    int id,
    Vector3 firstpos,
    UnityEngine.Material matSelected,
    UnityEngine.Material matNotLocation)
  {
    MapEditOrnament mapEditOrnament = go.AddComponent<MapEditOrnament>();
    mapEditOrnament.initialize(facility, id, firstpos, matSelected, matNotLocation);
    return mapEditOrnament;
  }

  public PlayerGuildFacility facility_ { get; private set; }

  public UnitUnit unit_ { get; private set; }

  public MapFacility master_ { get; private set; }

  public int ID_ { get; private set; }

  public bool hasLocation_ { get; private set; }

  public int row_ { get; private set; }

  public int column_ { get; private set; }

  public bool isInitialized_ => this.initialized_;

  public bool isMove_ => this.posTarget_ != this.myTrans_.position;

  public Vector3 nowPosition_ => this.myTrans_.position;

  public Vector3 targetPosition_ => this.posTarget_;

  public bool isMoveScreen_ => this.nowScreenPoint_ != this.targetScreenPoint_;

  private BE env_
  {
    get
    {
      if (this.environment_ == null)
        this.environment_ = Singleton<NGBattleManager>.GetInstance().environment;
      return this.environment_;
    }
  }

  public void initialize(
    PlayerGuildFacility facility,
    int id,
    Vector3 firstpos,
    UnityEngine.Material matSelected,
    UnityEngine.Material matNotLocation)
  {
    this.facility_ = facility;
    this.unit_ = facility?.unit;
    this.master_ = facility?.master;
    this.shaderSetting_ = this.unit_ == null || MasterData.MapEditFacilityShaderSettingList == null ? (MapEditFacilityShaderSetting) null : ((IEnumerable<MapEditFacilityShaderSetting>) MasterData.MapEditFacilityShaderSettingList).FirstOrDefault<MapEditFacilityShaderSetting>((Func<MapEditFacilityShaderSetting, bool>) (ss => ss.unit_UnitUnit == this.unit_.ID));
    this.ID_ = id;
    this.myTrans_ = this.transform;
    this.posTarget_ = firstpos;
    this.myTrans_.position = firstpos;
    this.matSelected_ = this.shaderSetting_ == null || !this.shaderSetting_.hasMovingMaterial ? matSelected : (UnityEngine.Material) null;
    this.matNotLocation_ = this.shaderSetting_ == null || !this.shaderSetting_.hasInstalledMaterial ? matNotLocation : (UnityEngine.Material) null;
    this.hasLocation_ = false;
  }

  private IEnumerator Start()
  {
    MapEditOrnament mapEditOrnament = this;
    Camera[] componentsInChildren = Singleton<NGBattleManager>.GetInstance().battleCamera.GetComponentsInChildren<Camera>(true);
    if (componentsInChildren != null && componentsInChildren.Length != 0)
    {
      mapEditOrnament.camera_ = ((IEnumerable<Camera>) componentsInChildren).First<Camera>();
      List<Renderer> lstRenderer = ((IEnumerable<MeshRenderer>) mapEditOrnament.GetComponentsInChildren<MeshRenderer>()).Select<MeshRenderer, Renderer>((Func<MeshRenderer, Renderer>) (r => (Renderer) r)).ToList<Renderer>();
      lstRenderer.AddRange((IEnumerable<Renderer>) ((IEnumerable<SkinnedMeshRenderer>) mapEditOrnament.GetComponentsInChildren<SkinnedMeshRenderer>()).Select<SkinnedMeshRenderer, Renderer>((Func<SkinnedMeshRenderer, Renderer>) (r => (Renderer) r)).ToList<Renderer>());
      mapEditOrnament.initBoxCollider();
      if (!lstRenderer.Any<Renderer>())
      {
        mapEditOrnament.initialized_ = true;
      }
      else
      {
        Future<UnityEngine.Material> ldmaterial;
        IEnumerator e;
        if (mapEditOrnament.shaderSetting_ != null && mapEditOrnament.shaderSetting_.hasMovingMaterial)
        {
          ldmaterial = mapEditOrnament.shaderSetting_.LoadMovingMaterial();
          e = ldmaterial.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          if ((UnityEngine.Object) ldmaterial.Result != (UnityEngine.Object) null)
            mapEditOrnament.matSelected_ = ldmaterial.Result;
          ldmaterial = (Future<UnityEngine.Material>) null;
        }
        if (mapEditOrnament.shaderSetting_ != null && mapEditOrnament.shaderSetting_.hasInstalledMaterial)
        {
          ldmaterial = mapEditOrnament.shaderSetting_.LoadInstalledMaterial();
          e = ldmaterial.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          if ((UnityEngine.Object) ldmaterial.Result != (UnityEngine.Object) null)
            mapEditOrnament.matNotLocation_ = ldmaterial.Result;
          ldmaterial = (Future<UnityEngine.Material>) null;
        }
        if ((UnityEngine.Object) mapEditOrnament.matSelected_ != (UnityEngine.Object) null || (UnityEngine.Object) mapEditOrnament.matNotLocation_ != (UnityEngine.Object) null)
        {
          // ISSUE: reference to a compiler-generated method
          mapEditOrnament.materialControls_ = lstRenderer.Where<Renderer>((Func<Renderer, bool>) (r => (UnityEngine.Object) r.material != (UnityEngine.Object) null)).Select<Renderer, MapEditOrnament.MaterialControl>(new Func<Renderer, MapEditOrnament.MaterialControl>(mapEditOrnament.\u003CStart\u003Eb__63_3)).ToList<MapEditOrnament.MaterialControl>();
        }
        Bounds bounds1 = new Bounds();
        int count = lstRenderer.Count;
        for (int index = 0; index < count; ++index)
        {
          Bounds bounds2 = lstRenderer[index].bounds;
          if (index == 0)
          {
            bounds1 = bounds2;
          }
          else
          {
            bounds1.min = Vector3.Min(bounds1.min, bounds2.min);
            bounds1.max = Vector3.Max(bounds1.max, bounds2.max);
          }
        }
        mapEditOrnament.collider_.center = mapEditOrnament.transform.InverseTransformPoint(bounds1.center);
        mapEditOrnament.collider_.size = bounds1.size;
        mapEditOrnament.initialized_ = true;
      }
    }
  }

  private void initBoxCollider()
  {
    this.collider_ = this.gameObject.GetOrAddComponent<BoxCollider>();
    this.collider_.center = new Vector3(0.0f, 1f, 0.0f);
    this.collider_.size = new Vector3(2f, 2f, 2f);
  }

  private void setTexture(UnityEngine.Material dst, UnityEngine.Material src)
  {
    dst.mainTexture = src.mainTexture;
    dst.mainTextureOffset = src.mainTextureOffset;
    dst.mainTextureScale = src.mainTextureScale;
  }

  private static int MASK_TERRAIN_LAYER
  {
    get
    {
      if (MapEditOrnament.mask_terrain_layer_ == 0)
        MapEditOrnament.mask_terrain_layer_ = 1 << LayerMask.NameToLayer("Terrain");
      return MapEditOrnament.mask_terrain_layer_;
    }
  }

  private void Update()
  {
    if (!this.initialized_)
      return;
    if (this.calcScreenPoint_ && this.isMoveScreen_)
    {
      this.nowScreenPoint_ = Vector3.SmoothDamp(this.nowScreenPoint_, this.targetScreenPoint_, ref this.velocityMoveScreen_, this.smoothTimeMoveScreen_);
      if ((double) (this.targetScreenPoint_ - this.nowScreenPoint_).sqrMagnitude < 9.99999974737875E-05)
      {
        this.nowScreenPoint_ = this.targetScreenPoint_;
        this.velocityMoveScreen_ = Vector3.zero;
      }
      RaycastHit hitInfo = new RaycastHit();
      if (!Physics.Raycast(this.camera_.ScreenPointToRay(this.nowScreenPoint_), out hitInfo, 10000f, MapEditOrnament.MASK_TERRAIN_LAYER))
        return;
      this.myTrans_.position = hitInfo.point;
    }
    else
    {
      if (this.isMove_)
      {
        this.myTrans_.position = Vector3.SmoothDamp(this.myTrans_.position, this.posTarget_, ref this.velocityMove_, this.smoothTimeMove_);
        if ((double) (this.posTarget_ - this.myTrans_.position).sqrMagnitude < 9.99999974737875E-05)
        {
          this.myTrans_.position = this.posTarget_;
          this.velocityMove_ = Vector3.zero;
        }
        if (this.isAutoSearchPanel_)
          this.isSearchPanel_ = true;
      }
      if (!this.isSearchPanel_)
        return;
      this.isSearchPanel_ = false;
      BL.Panel panel = this.hitPanel();
      if (panel != null)
      {
        this.topMenu_.setCurrentPanel(this.topMenu_.castPanel(panel), cameraCenter: false);
        Vector3 position = this.myTrans_.position;
        position.y = this.topMenu_.currentPanel_.center_.y;
        this.myTrans_.position = position;
        Vector3 posTarget = this.posTarget_;
        posTarget.y = this.topMenu_.currentPanel_.center_.y;
        this.posTarget_ = posTarget;
      }
      else
      {
        float terrainHeight = this.getTerrainHeight();
        Vector3 position = this.myTrans_.position;
        position.y = terrainHeight;
        this.myTrans_.position = position;
        Vector3 posTarget = this.posTarget_;
        posTarget.y = terrainHeight;
        this.posTarget_ = posTarget;
      }
    }
  }

  public bool checkHit(Vector2 pos)
  {
    if (!this.initialized_ || (UnityEngine.Object) this.collider_ == (UnityEngine.Object) null || !this.collider_.enabled)
      return false;
    RaycastHit hitInfo = new RaycastHit();
    Ray ray = this.camera_.ScreenPointToRay((Vector3) pos);
    float maxDistance = (this.nowPosition_ - ray.origin).magnitude + 100f;
    return this.collider_.Raycast(ray, out hitInfo, maxDistance);
  }

  private static int MASK_PANEL_LAYER
  {
    get
    {
      if (MapEditOrnament.mask_panel_layer_ == 0)
        MapEditOrnament.mask_panel_layer_ = 1 << LayerMask.NameToLayer("Panel");
      return MapEditOrnament.mask_panel_layer_;
    }
  }

  public BL.Panel hitPanel() => !this.initialized_ ? (BL.Panel) null : this.hitPanel(this.myTrans_.position);

  public BL.Panel hitPanel(Vector3 worldPos)
  {
    if (!this.initialized_)
      return (BL.Panel) null;
    BL.Panel panel = (BL.Panel) null;
    Vector3 origin = worldPos;
    origin.y = this.camera_.transform.position.y;
    float maxDistance = Mathf.Abs(origin.y - worldPos.y) + 100f;
    RaycastHit hitInfo = new RaycastHit();
    if (Physics.Raycast(origin, Vector3.down, out hitInfo, maxDistance, MapEditOrnament.MASK_PANEL_LAYER))
    {
      BattlePanelParts component = hitInfo.collider.GetComponent<BattlePanelParts>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        panel = component.getPanel();
    }
    return panel;
  }

  public float getTerrainHeight() => !this.isInitialized_ ? 0.0f : this.getTerrainHeight(this.myTrans_.position);

  public float getTerrainHeight(Vector3 worldPos)
  {
    float num = 0.0f;
    if (!this.initialized_)
      return num;
    Vector3 origin = worldPos;
    origin.y = this.camera_.transform.position.y;
    float maxDistance = Mathf.Abs(origin.y - worldPos.y) + 100f;
    RaycastHit hitInfo = new RaycastHit();
    if (Physics.Raycast(origin, Vector3.down, out hitInfo, maxDistance, MapEditOrnament.MASK_TERRAIN_LAYER))
      num = hitInfo.point.y;
    return num;
  }

  public bool setFocused(bool isFocused) => this.isInitialized_;

  private static int DEFAULT_LAYER
  {
    get
    {
      if (MapEditOrnament.default_layer_ == -1)
        MapEditOrnament.default_layer_ = LayerMask.NameToLayer("3DModels");
      return MapEditOrnament.default_layer_;
    }
  }

  private static int SELECTED_LAYER
  {
    get
    {
      if (MapEditOrnament.selected_layer_ == -1)
        MapEditOrnament.selected_layer_ = LayerMask.NameToLayer("Animation3D");
      return MapEditOrnament.selected_layer_;
    }
  }

  public bool setSelected(bool isSelected)
  {
    if (!this.isInitialized_)
      return false;
    if ((UnityEngine.Object) this.collider_ != (UnityEngine.Object) null)
      this.collider_.enabled = isSelected;
    NGUITools.SetLayer(this.gameObject, isSelected ? MapEditOrnament.SELECTED_LAYER : MapEditOrnament.DEFAULT_LAYER);
    foreach (MapEditOrnament.MaterialControl materialControl in this.materialControls_)
      materialControl.setSelected(isSelected);
    return true;
  }

  public void changeDrawNotLocation()
  {
    if (!this.isInitialized_)
      return;
    foreach (MapEditOrnament.MaterialControl materialControl in this.materialControls_)
      materialControl.changeNotLocation();
  }

  public void resetDraw()
  {
    if (!this.isInitialized_)
      return;
    foreach (MapEditOrnament.MaterialControl materialControl in this.materialControls_)
      materialControl.resetMaterial();
  }

  public void setPosition(Vector3 pos, bool isImmediate = false)
  {
    float y = pos.y;
    pos = this.env_.limitFieldPosition(pos);
    pos.y = y;
    this.calcScreenPoint_ = false;
    if (isImmediate)
    {
      if (this.isAutoSearchPanel_ && this.myTrans_.position != pos)
        this.isSearchPanel_ = true;
      this.myTrans_.position = pos;
      this.posTarget_ = pos;
    }
    else
      this.posTarget_ = pos;
  }

  public void startMoveScreen(Vector3 pos)
  {
    if (!this.isInitialized_)
      return;
    this.calcScreenPoint_ = true;
    this.nowScreenPoint_ = this.camera_.WorldToScreenPoint(this.myTrans_.position);
    this.targetScreenPoint_ = new Vector3(pos.x, pos.y, this.nowScreenPoint_.z);
  }

  public void setAutoSearchPanel(bool isAuto, MapEdit031TopMenu topMenu = null)
  {
    this.isAutoSearchPanel_ = isAuto && (UnityEngine.Object) topMenu != (UnityEngine.Object) null;
    this.topMenu_ = this.isAutoSearchPanel_ ? topMenu : (MapEdit031TopMenu) null;
    this.isSearchPanel_ = false;
  }

  public void setLocation(MapEditPanel panel, bool reposition = false)
  {
    panel.setOrnament(this);
    this.hasLocation_ = true;
    this.row_ = panel.panel_.row;
    this.column_ = panel.panel_.column;
    if (!reposition)
      return;
    this.setPosition(panel.center_, true);
  }

  public void destroySelf() => UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);

  private class MaterialControl
  {
    private Renderer renderer_;
    private UnityEngine.Material matOriginal_;
    private UnityEngine.Material matSelected_;
    private UnityEngine.Material matNotLocation_;

    public MaterialControl(Renderer renderer, UnityEngine.Material matSelected, UnityEngine.Material matNotLocation)
    {
      this.renderer_ = renderer;
      this.matOriginal_ = renderer.material;
      this.matSelected_ = !((UnityEngine.Object) this.matOriginal_ != (UnityEngine.Object) null) || !((UnityEngine.Object) matSelected != (UnityEngine.Object) null) ? (UnityEngine.Material) null : new UnityEngine.Material(matSelected);
      if ((UnityEngine.Object) this.matSelected_ != (UnityEngine.Object) null)
        this.setTexture(this.matSelected_, this.matOriginal_);
      this.matNotLocation_ = !((UnityEngine.Object) this.matOriginal_ != (UnityEngine.Object) null) || !((UnityEngine.Object) matNotLocation != (UnityEngine.Object) null) ? (UnityEngine.Material) null : new UnityEngine.Material(matNotLocation);
      if (!((UnityEngine.Object) this.matNotLocation_ != (UnityEngine.Object) null))
        return;
      this.setTexture(this.matNotLocation_, this.matOriginal_);
    }

    private void setTexture(UnityEngine.Material dst, UnityEngine.Material src)
    {
      dst.mainTexture = src.mainTexture;
      dst.mainTextureOffset = src.mainTextureOffset;
      dst.mainTextureScale = src.mainTextureScale;
    }

    public void setSelected(bool isSelected)
    {
      if (!((UnityEngine.Object) this.matSelected_ != (UnityEngine.Object) null) || !((UnityEngine.Object) this.matOriginal_ != (UnityEngine.Object) null))
        return;
      this.renderer_.material = isSelected ? this.matSelected_ : this.matOriginal_;
    }

    public void changeNotLocation()
    {
      if (!((UnityEngine.Object) this.matNotLocation_ != (UnityEngine.Object) null) || !((UnityEngine.Object) this.matOriginal_ != (UnityEngine.Object) null))
        return;
      this.renderer_.material = this.matNotLocation_;
    }

    public void resetMaterial()
    {
      if (!((UnityEngine.Object) this.matOriginal_ != (UnityEngine.Object) null))
        return;
      this.renderer_.material = this.matOriginal_;
    }
  }
}
