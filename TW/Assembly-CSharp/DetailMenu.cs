// Decompiled with JetBrains decompiler
// Type: DetailMenu
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
using UniLinq;
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
  private UnitDetailGroupButton[] groupBtns;
  [SerializeField]
  private SpriteSelectDirectButton[] groupSprites;
  [SerializeField]
  private UIGrid groupBtnGrid;
  [SerializeField]
  private NGHorizontalScrollParts informationScrollView;
  [SerializeField]
  private DetailMenuScrollViewBase[] informationPanels;
  [SerializeField]
  private GameObject dirSpecial;
  [SerializeField]
  private UISprite specialIcon;
  [SerializeField]
  private UILabel specialFactor;
  [SerializeField]
  private UILabel specialEventName;
  [SerializeField]
  private GameObject floatingGroupDialog;
  private GameObject floatingGroupDialogObject;
  private static readonly string specialIconSpriteBaseName = "slc_icon_specific_effectiveness_{0}.png__GUI__unit_detail__unit_detail_prefab";
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
      Unit0544Scene.ChangeScene(true, this._playerUnit, 1);
    else
      Unit0044Scene.ChangeScene(true, this._playerUnit, 1);
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
    return (IEnumerator) new DetailMenu.\u003CUpdateActive\u003Ec__IteratorAFD()
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
    return (IEnumerator) new DetailMenu.\u003CSetInformationPanelIndex\u003Ec__IteratorAFE()
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
    return (IEnumerator) new DetailMenu.\u003CInitInformationPanels\u003Ec__IteratorAFF()
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
    return (IEnumerator) new DetailMenu.\u003CItemGearFavoriteAscync\u003Ec__IteratorB00()
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
    return (IEnumerator) new DetailMenu.\u003ConEndSceneAsync\u003Ec__IteratorB01()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ShowGroupDescription(string title, string description, string spriteName)
  {
    Unit0042FloatingGroupDialog component = this.floatingGroupDialogObject.GetComponent<Unit0042FloatingGroupDialog>();
    component.Init(title, description, spriteName);
    component.Show();
  }

  private void DisplayGroupLogo(UnitUnit playerUnit)
  {
    int index = 0;
    ((IEnumerable<UnitDetailGroupButton>) this.groupBtns).ForEach<UnitDetailGroupButton>((Action<UnitDetailGroupButton>) (x => ((Component) x).gameObject.SetActive(false)));
    UnitGroup groupInfo = ((IEnumerable<UnitGroup>) MasterData.UnitGroupList).FirstOrDefault<UnitGroup>((Func<UnitGroup, bool>) (x => x.unit_id == playerUnit.ID));
    if (groupInfo == null)
      return;
    UnitGroupLargeCategory groupLargeCategory = ((IEnumerable<UnitGroupLargeCategory>) MasterData.UnitGroupLargeCategoryList).FirstOrDefault<UnitGroupLargeCategory>((Func<UnitGroupLargeCategory, bool>) (x => x.ID == groupInfo.group_large_category_id_UnitGroupLargeCategory));
    UnitGroupSmallCategory groupSmallCategory = ((IEnumerable<UnitGroupSmallCategory>) MasterData.UnitGroupSmallCategoryList).FirstOrDefault<UnitGroupSmallCategory>((Func<UnitGroupSmallCategory, bool>) (x => x.ID == groupInfo.group_small_category_id_UnitGroupSmallCategory));
    UnitGroupClothingCategory clothingCategory = ((IEnumerable<UnitGroupClothingCategory>) MasterData.UnitGroupClothingCategoryList).FirstOrDefault<UnitGroupClothingCategory>((Func<UnitGroupClothingCategory, bool>) (x => x.ID == groupInfo.group_clothing_category_id_UnitGroupClothingCategory));
    UnitGroupGenerationCategory generationCategory = ((IEnumerable<UnitGroupGenerationCategory>) MasterData.UnitGroupGenerationCategoryList).FirstOrDefault<UnitGroupGenerationCategory>((Func<UnitGroupGenerationCategory, bool>) (x => x.ID == groupInfo.group_generation_category_id_UnitGroupGenerationCategory));
    if (groupLargeCategory == null && groupSmallCategory == null && clothingCategory == null && generationCategory == null)
      return;
    if (groupLargeCategory != null && groupLargeCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(groupLargeCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), groupLargeCategory.name, groupLargeCategory.description, groupLargeCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (groupSmallCategory != null && groupSmallCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(groupSmallCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), groupSmallCategory.name, groupSmallCategory.description, groupSmallCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (clothingCategory != null && clothingCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(clothingCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), clothingCategory.name, clothingCategory.description, clothingCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (generationCategory != null && generationCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(generationCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), generationCategory.name, generationCategory.description, generationCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      int num = index + 1;
    }
    this.groupBtnGrid.repositionNow = true;
  }

  [DebuggerHidden]
  public override IEnumerator Init(
    Unit0042Menu menu,
    int index,
    PlayerUnit playerUnit,
    int infoIndex,
    bool isLimit,
    QuestScoreBonusTimetable[] tables,
    UnitBonus[] unitBonus,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CInit\u003Ec__IteratorB02()
    {
      menu = menu,
      index = index,
      playerUnit = playerUnit,
      infoIndex = infoIndex,
      tables = tables,
      unitBonus = unitBonus,
      isUpdate = isUpdate,
      isLimit = isLimit,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EinfoIndex = infoIndex,
      \u003C\u0024\u003Etables = tables,
      \u003C\u0024\u003EunitBonus = unitBonus,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u0024\u003EisLimit = isLimit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitPlayer(
    PlayerUnit playerUnit,
    int infoIndex,
    GameObject gearIconPrefab,
    QuestScoreBonusTimetable[] tables,
    UnitBonus[] unitBonus)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CInitPlayer\u003Ec__IteratorB03()
    {
      playerUnit = playerUnit,
      gearIconPrefab = gearIconPrefab,
      tables = tables,
      unitBonus = unitBonus,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EgearIconPrefab = gearIconPrefab,
      \u003C\u0024\u003Etables = tables,
      \u003C\u0024\u003EunitBonus = unitBonus,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadCharacterImage(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenu.\u003CLoadCharacterImage\u003Ec__IteratorB04()
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
    return (IEnumerator) new DetailMenu.\u003CsetDefaultWeapon\u003Ec__IteratorB05()
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
    return (IEnumerator) new DetailMenu.\u003CWaitScrollSe\u003Ec__IteratorB06()
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
