// Decompiled with JetBrains decompiler
// Type: Unit0042Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit0042Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txt_CharacterName;
  [SerializeField]
  protected UI2DSprite weaponTypeIcon;
  [SerializeField]
  protected UI2DSprite rarityStarsIcon;
  [SerializeField]
  private GameObject LeftArrow;
  [SerializeField]
  private GameObject RightArrow;
  [SerializeField]
  public GameObject iBtn_FbShare;
  [SerializeField]
  public GameObject iBtn_WxShare;
  private readonly int DISPLAY_OBJECT_MAX = 4;
  protected int objectCnt;
  protected GameObject[] detailMenuObject;
  private List<GameObject> objectList;
  private Dictionary<GameObject, DetailMenuPrefab> detailMenuPrefabDict;
  private GameObject gearKindIcon;
  public NGxScroll scrollView;
  [SerializeField]
  private UICenterOnChild centerOnChild;
  private bool IsFriend;
  private bool IsLimitMode;
  private PlayerItem equippedGear;
  private PlayerUnit[] unitList;
  private Dictionary<int, bool> firstSetting = new Dictionary<int, bool>();
  private Dictionary<int, bool> changeSetting = new Dictionary<int, bool>();
  public GameObject detailPrefab;
  public GameObject gearKindIconPrefab;
  public GameObject gearIconPrefab;
  public GameObject skillDetailDialogPrefab;
  public GameObject profIconPrefab;
  public GameObject skillTypeIconPrefab;
  public GameObject commonElementIconPrefab;
  public GameObject spAtkTypeIconPrefab;
  public GameObject modelPrefab;
  private int voiceID = -1;
  private int currentIndex;
  private int infoIndex;
  private bool lightON = true;
  private bool isArrowBtn = true;

  public int CurrentIndex
  {
    set => this.currentIndex = value;
    get => this.currentIndex;
  }

  public int InfoIndex
  {
    set => this.infoIndex = value;
    get => this.infoIndex;
  }

  public bool LightON
  {
    get => this.lightON;
    set => this.lightON = value;
  }

  private void Awake() => this.denaAwake();

  public void UpdateInfoIndicator(int idx)
  {
    this.InfoIndex = idx;
    ((Component) this.scrollView.grid).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => ((Component) t).gameObject)).ForEach<GameObject>((Action<GameObject>) (x =>
    {
      if (!x.activeSelf)
        x.SetActive(true);
      this.detailMenuPrefabDict[x].SetInformationPanelIndex(this.InfoIndex);
    }));
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnFbShare()
  {
    if (!Object.op_Equality((Object) this.iBtn_FbShare, (Object) null))
      return;
    Debug.LogError((object) "fbshare instance is null");
  }

  public void IbtnWxShare() => Singleton<SDKMgr>.GetInstance().ShareToWechatCircle();

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnIntimacy()
  {
  }

  public virtual void IbtnWpEquip()
  {
  }

  public virtual void IbtnZoom()
  {
  }

  private void CenterOnChild(int num)
  {
    foreach (GameObject key in this.detailMenuObject)
    {
      if (this.detailMenuPrefabDict[key].Index == num)
      {
        this.centerOnChild.onFinished = (SpringPanel.OnFinished) (() => this.isArrowBtn = true);
        this.centerOnChild.CenterOn(key.transform);
        break;
      }
    }
  }

  public void IbtnLeftArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    int num = this.currentIndex - 1;
    if (num < 0)
      return;
    this.CenterOnChild(num);
  }

  public void IbtnRightArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    int num = this.currentIndex + 1;
    if (num > this.unitList.Length - 1)
      return;
    this.CenterOnChild(num);
  }

  [DebuggerHidden]
  private IEnumerator UpdateActive(GameObject go)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CUpdateActive\u003Ec__Iterator2AB()
    {
      go = go,
      \u003C\u0024\u003Ego = go
    };
  }

  private void SetTitleBarInfo(bool isSe = true)
  {
    this.LeftArrow.SetActive(true);
    this.RightArrow.SetActive(true);
    if (this.currentIndex == 0)
      this.LeftArrow.SetActive(false);
    if (this.currentIndex >= this.unitList.Length - 1)
      this.RightArrow.SetActive(false);
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = this.unitList[this.currentIndex].id;
    this.txt_CharacterName.SetText(this.unitList[this.currentIndex].unit.name);
    this.gearKindIcon.SetActive(false);
    ((Component) this.rarityStarsIcon).gameObject.SetActive(false);
    if (this.unitList[this.currentIndex].unit.IsNormalUnit)
    {
      this.gearKindIcon.SetActive(true);
      ((Component) this.rarityStarsIcon).gameObject.SetActive(true);
      this.gearKindIcon.GetComponent<GearKindIcon>().Init(this.unitList[this.currentIndex].unit.kind, this.unitList[this.currentIndex].GetElement());
      RarityIcon.SetRarity(this.unitList[this.currentIndex].unit, this.rarityStarsIcon, true);
    }
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    if (isSe)
      instance.playSE("SE_1005");
    if (this.voiceID == this.unitList[this.currentIndex].unit.character.ID)
      return;
    this.voiceID = this.unitList[this.currentIndex].unit.character.ID;
    instance.stopVoice();
    if (this.unitList[this.currentIndex].unit.unitVoicePattern == null)
      return;
    instance.playVoiceByID(this.unitList[this.currentIndex].unit.unitVoicePattern.file_name, 42);
  }

  private void UpdateObjectList()
  {
    foreach (GameObject key in this.detailMenuObject)
    {
      int index = this.detailMenuPrefabDict[key].Index;
      if ((index < this.currentIndex - 1 || index > this.currentIndex + 1) && !this.objectList.Contains(key))
        this.objectList.Add(key);
    }
  }

  protected override void Update()
  {
    base.Update();
    int num1 = this.currentIndex;
    if ((double) ((Component) this.scrollView.scrollView).transform.localPosition.x < 0.0)
    {
      int num2 = (int) Mathf.Abs((((Component) this.scrollView.scrollView).transform.localPosition.x - this.scrollView.grid.cellWidth / 2f) / this.scrollView.grid.cellWidth);
      num1 = num2 > ((IEnumerable<PlayerUnit>) this.unitList).Count<PlayerUnit>() ? ((IEnumerable<PlayerUnit>) this.unitList).Count<PlayerUnit>() - 1 : num2;
    }
    ((Component) this.scrollView.grid).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => ((Component) t).gameObject)).ForEach<GameObject>((Action<GameObject>) (x => this.detailMenuPrefabDict[x].SetInformationPaneEnable(!this.scrollView.scrollView.isDragging)));
    if (this.currentIndex == num1)
      return;
    bool flag = this.currentIndex < num1;
    this.currentIndex = num1;
    bool isSe = true;
    if (this.currentIndex < 0)
    {
      isSe = false;
      this.currentIndex = 0;
    }
    if (this.currentIndex >= ((IEnumerable<PlayerUnit>) this.unitList).Count<PlayerUnit>())
    {
      isSe = false;
      this.currentIndex = ((IEnumerable<PlayerUnit>) this.unitList).Count<PlayerUnit>() - 1;
    }
    this.SetTitleBarInfo(isSe);
    this.UpdateObjectList();
    if (flag)
    {
      if (this.currentIndex >= ((IEnumerable<PlayerUnit>) this.unitList).Count<PlayerUnit>() - 1)
        return;
      this.StartCoroutine(this.CreatePage(this.currentIndex + 1));
    }
    else
    {
      if (this.currentIndex <= 0)
        return;
      this.StartCoroutine(this.CreatePage(this.currentIndex - 1));
    }
  }

  private void CreateFirstFavoriteSetting()
  {
    this.firstSetting.Clear();
    this.changeSetting.Clear();
    foreach (PlayerUnit unit in this.unitList)
    {
      this.firstSetting.Add(unit.id, unit.favorite);
      this.changeSetting.Add(unit.id, unit.favorite);
    }
  }

  public bool GetSetting(int id) => this.changeSetting[id];

  public void UpdateSetting(int id, bool flg) => this.changeSetting[id] = flg;

  [DebuggerHidden]
  protected virtual IEnumerator LoadPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CLoadPrefabs\u003Ec__Iterator2AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    bool isFriend,
    bool limitMode,
    bool isEarthMode,
    PlayerItem equippedGear = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CInit\u003Ec__Iterator2AD()
    {
      playerUnits = playerUnits,
      isFriend = isFriend,
      limitMode = limitMode,
      equippedGear = equippedGear,
      isEarthMode = isEarthMode,
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisFriend = isFriend,
      \u003C\u0024\u003ElimitMode = limitMode,
      \u003C\u0024\u003EequippedGear = equippedGear,
      \u003C\u0024\u003EisEarthMode = isEarthMode,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator CreatePage(int unitIdx, bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CCreatePage\u003Ec__Iterator2AE()
    {
      unitIdx = unitIdx,
      isUpdate = isUpdate,
      \u003C\u0024\u003EunitIdx = unitIdx,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateCurrentPage(PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CUpdateCurrentPage\u003Ec__Iterator2AF()
    {
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdatePage(int unitIdx)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CUpdatePage\u003Ec__Iterator2B0()
    {
      unitIdx = unitIdx,
      \u003C\u0024\u003EunitIdx = unitIdx,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UnitFavoriteAscync(int[] player_unit_ids, int[] unlock_player_unit_ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003CUnitFavoriteAscync\u003Ec__Iterator2B1()
    {
      player_unit_ids = player_unit_ids,
      unlock_player_unit_ids = unlock_player_unit_ids,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003Eunlock_player_unit_ids = unlock_player_unit_ids
    };
  }

  [DebuggerHidden]
  public IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Menu.\u003ConEndSceneAsync\u003Ec__Iterator2B2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void denaAwake()
  {
  }

  private void denaShareInit()
  {
    if (Object.op_Inequality((Object) this.iBtn_FbShare, (Object) null))
      this.iBtn_FbShare.SetActive(false);
    if (Object.op_Inequality((Object) this.iBtn_WxShare, (Object) null))
    {
      if (!GameConfig.IsChanelPackage)
        this.iBtn_WxShare.SetActive(true);
      else
        this.iBtn_WxShare.SetActive(false);
    }
    else
      Debug.LogError((object) "ibtn_wxhare is null");
  }
}
