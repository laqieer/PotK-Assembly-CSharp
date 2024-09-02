// Decompiled with JetBrains decompiler
// Type: DetailMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenu : DetailMenuBase
{
  private Vector3 modelPos;
  [SerializeField]
  protected UI2DSprite DynCharacter;
  public bool isFavorited;
  [SerializeField]
  private GameObject dirFavorite;
  [SerializeField]
  private GameObject btnFavoritedOff;
  [SerializeField]
  private GameObject btnFavoritedOn;
  [SerializeField]
  private GameObject btnIntimacy;
  [SerializeField]
  private GameObject link_MainWeapon;
  private ItemIcon gearIcon;
  [SerializeField]
  private NGHorizontalScrollParts informationScrollView;
  [SerializeField]
  private DetailMenuScrollViewBase[] informationPanels;
  private PlayerItem equippedGear;
  private PlayerUnit _playerUnit;
  private bool ModelUpdate;
  private NGSoundManager sm;
  public bool isEarthMode;

  public Vector3 ModelPos
  {
    set => this.modelPos = value;
    get => this.modelPos;
  }

  public NGHorizontalScrollParts InformationScrollView => this.informationScrollView;

  public PlayerUnit PlayerUnit => this._playerUnit;

  public PlayerItem EquippedGear => this.equippedGear;

  public void IbtnIntimacy()
  {
    if (this.isEarthMode)
      Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2_2", true, (object) this._playerUnit);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2_2", true, (object) this._playerUnit);
  }

  public void IbtnZoom()
  {
    if (this.isEarthMode)
      Unit0543Scene.changeScene(true, this._playerUnit);
    else
      Unit0043Scene.changeScene(true, this._playerUnit);
  }

  public void IbtnWpEquip()
  {
    if (this.isEarthMode)
      Unit0544Scene.changeScene(true, this._playerUnit, 1);
    else
      Unit0044Scene.changeScene(true, this._playerUnit, 1);
  }

  public void IbtnFavoriteToggle() => this.SetFavorite(!this.isFavorited);

  public void SetFavorite(bool active)
  {
    this.isFavorited = active;
    this.btnFavoritedOff.SetActive(!active);
    this.btnFavoritedOn.SetActive(active);
    this.menu.UpdateSetting(this._playerUnit.id, this.isFavorited);
  }

  private void Update()
  {
    if (Object.op_Equality((Object) this.menu, (Object) null))
      return;
    this.informationScrollView.SeEnable = false;
    if (this.menu.CurrentIndex != this.index)
      return;
    this.informationScrollView.SeEnable = true;
    if (this.menu.InfoIndex == this.informationScrollView.selected)
      return;
    this.menu.InfoIndex = this.informationScrollView.selected;
    if (this.menu.InfoIndex < 0)
      this.menu.InfoIndex = 0;
    if (this.ModelUpdate)
      return;
    if (this.menu.InfoIndex != 0)
    {
      if (Object.op_Inequality((Object) ((Component) this.informationPanels[0]).GetComponent<DetailMenuScrollView01>().UI3DModel, (Object) null))
        ((Behaviour) ((Component) this.informationPanels[0]).GetComponent<DetailMenuScrollView01>().UI3DModelTexture).enabled = false;
    }
    else if (Object.op_Inequality((Object) ((Component) this.informationPanels[0]).GetComponent<DetailMenuScrollView01>().UI3DModel, (Object) null))
      ((Behaviour) ((Component) this.informationPanels[0]).GetComponent<DetailMenuScrollView01>().UI3DModelTexture).enabled = true;
    this.menu.UpdateInfoIndicator(this.menu.InfoIndex);
  }

  [DebuggerHidden]
  private IEnumerator UpdateActive(int infoIndex, bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CUpdateActive\u003Ec__Iterator8AA()
    {
      infoIndex = infoIndex,
      isUpdate = isUpdate,
      \u003C\u0024\u003EinfoIndex = infoIndex,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator SetInformationPanelIndex(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CSetInformationPanelIndex\u003Ec__Iterator8AB()
    {
      index = index,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitInformationPanels(PlayerUnit playerUnit, int infoIndex, bool isUpdate = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CInitInformationPanels\u003Ec__Iterator8AC()
    {
      playerUnit = playerUnit,
      infoIndex = infoIndex,
      isUpdate = isUpdate,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EinfoIndex = infoIndex,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ItemGearFavoriteAscync(
    int[] favorite_player_gear_ids,
    int[] un_favorite_player_gear_ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CItemGearFavoriteAscync\u003Ec__Iterator8AD()
    {
      favorite_player_gear_ids = favorite_player_gear_ids,
      un_favorite_player_gear_ids = un_favorite_player_gear_ids,
      \u003C\u0024\u003Efavorite_player_gear_ids = favorite_player_gear_ids,
      \u003C\u0024\u003Eun_favorite_player_gear_ids = un_favorite_player_gear_ids
    };
  }

  [DebuggerHidden]
  public IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003ConEndSceneAsync\u003Ec__Iterator8AE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(
    Unit0042Menu menu,
    int index,
    PlayerUnit playerUnit,
    int infoIndex,
    bool isLimit,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CInit\u003Ec__Iterator8AF()
    {
      menu = menu,
      index = index,
      playerUnit = playerUnit,
      infoIndex = infoIndex,
      isUpdate = isUpdate,
      isLimit = isLimit,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EinfoIndex = infoIndex,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u0024\u003EisLimit = isLimit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitPlayer(PlayerUnit playerUnit, int infoIndex, GameObject gearIconPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CInitPlayer\u003Ec__Iterator8B0()
    {
      playerUnit = playerUnit,
      gearIconPrefab = gearIconPrefab,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EgearIconPrefab = gearIconPrefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadCharacterImage(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CLoadCharacterImage\u003Ec__Iterator8B1()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  public void LimitMode()
  {
    this.link_MainWeapon.GetComponent<UIButton>().onClick = (List<EventDelegate>) null;
    this.gearIcon.setEquipPlus(false);
    this.gearIcon.Broken = false;
    this.gearIcon.onClick = (Action<ItemIcon>) (_ => { });
    if (!this.isEarthMode)
      this.dirFavorite.SetActive(false);
    this.btnIntimacy.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator setDefaultWeapon(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CsetDefaultWeapon\u003Ec__Iterator8B2()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CWaitScrollSe\u003Ec__Iterator8B3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void EnableScrollView()
  {
  }

  public void onEndScene()
  {
    foreach (DetailMenuScrollViewBase informationPanel in this.informationPanels)
      informationPanel.EndScene();
  }
}
