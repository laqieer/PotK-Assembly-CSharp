// Decompiled with JetBrains decompiler
// Type: Bugu0053DirRecipeList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053DirRecipeList : MonoBehaviour
{
  [SerializeField]
  private UIWidget SlcRecipeBase;
  [SerializeField]
  private UILabel TxtRecipeGearName;
  [SerializeField]
  private GameObject IconRecipeGear;
  [SerializeField]
  private GameObject[] IconMaterial;
  [SerializeField]
  private GameObject[] labMaterialNum;
  [SerializeField]
  private UILabel[] TxtMaterialNum;
  [SerializeField]
  private UIButton IbtnRecipeYes;
  [SerializeField]
  private UISprite[] IconRankShortage;
  [SerializeField]
  private UILabel TxtZenie;
  [SerializeField]
  private GameObject dirMain;
  [SerializeField]
  private GameObject dirMaterial;
  [SerializeField]
  private GameObject dirYes;
  private List<GearGear> materialGears = new List<GearGear>();
  private List<int> materialGearsRank = new List<int>();
  private List<InventoryItem> sendMaterialList = new List<InventoryItem>();
  private GameObject ItemIconPrefab;
  private GameObject materialInfoPopupPrefabF;
  private GearGear mainGear;
  private Action<List<InventoryItem>, string> IbtnEvent;
  private System.Action CloseEvent;
  public Bugu0053DirRecipePopup root;

  public int width => this.SlcRecipeBase.width;

  public int height => this.SlcRecipeBase.height;

  [DebuggerHidden]
  public IEnumerator Init(
    Bugu0053DirRecipePopup recipePopup,
    GearCombineRecipe gearRecipe,
    Action<List<InventoryItem>, string> ButtonEvent,
    Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDicData,
    Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDicDescendingData,
    GameObject itemIconPrefabObj,
    Bugu0053DirRecipeListPrefabs prefabs,
    System.Action backEvent,
    int playerMoney)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipeList.\u003CInit\u003Ec__Iterator3BB()
    {
      recipePopup = recipePopup,
      ButtonEvent = ButtonEvent,
      backEvent = backEvent,
      itemIconPrefabObj = itemIconPrefabObj,
      prefabs = prefabs,
      gearRecipe = gearRecipe,
      playerGearDicData = playerGearDicData,
      playerGearDicDescendingData = playerGearDicDescendingData,
      playerMoney = playerMoney,
      \u003C\u0024\u003ErecipePopup = recipePopup,
      \u003C\u0024\u003EButtonEvent = ButtonEvent,
      \u003C\u0024\u003EbackEvent = backEvent,
      \u003C\u0024\u003EitemIconPrefabObj = itemIconPrefabObj,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u0024\u003EgearRecipe = gearRecipe,
      \u003C\u0024\u003EplayerGearDicData = playerGearDicData,
      \u003C\u0024\u003EplayerGearDicDescendingData = playerGearDicDescendingData,
      \u003C\u0024\u003EplayerMoney = playerMoney,
      \u003C\u003Ef__this = this
    };
  }

  private int CheckCanMaterial(GameCore.ItemInfo gear)
  {
    int num = 0;
    if (gear.broken)
      ++num;
    if (gear.favorite)
      ++num;
    if (gear.ForBattle)
      ++num;
    return num;
  }

  [DebuggerHidden]
  private IEnumerator SetGearMainIcon(GearGear gear, Transform iconTransform)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipeList.\u003CSetGearMainIcon\u003Ec__Iterator3BC()
    {
      iconTransform = iconTransform,
      gear = gear,
      \u003C\u0024\u003EiconTransform = iconTransform,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetGearIcon(
    GameCore.ItemInfo playerGear,
    Transform iconTransform,
    int rank,
    bool isGray,
    int quantity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipeList.\u003CSetGearIcon\u003Ec__Iterator3BD()
    {
      iconTransform = iconTransform,
      playerGear = playerGear,
      quantity = quantity,
      rank = rank,
      isGray = isGray,
      \u003C\u0024\u003EiconTransform = iconTransform,
      \u003C\u0024\u003EplayerGear = playerGear,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003Erank = rank,
      \u003C\u0024\u003EisGray = isGray,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetGearIcon(
    GearGear gear,
    Transform iconTransform,
    int rank,
    bool isGray,
    int quantity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipeList.\u003CSetGearIcon\u003Ec__Iterator3BE()
    {
      iconTransform = iconTransform,
      gear = gear,
      quantity = quantity,
      rank = rank,
      isGray = isGray,
      \u003C\u0024\u003EiconTransform = iconTransform,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003Erank = rank,
      \u003C\u0024\u003EisGray = isGray,
      \u003C\u003Ef__this = this
    };
  }

  private int SetRequestGearRank(int? rank) => rank.HasValue ? rank.Value : 0;

  private void OnGearPopup()
  {
    string empty = string.Empty;
    string sceneName = this.mainGear.kind.Enum == GearKindEnum.smith ? (this.mainGear.compose_kind.kind.Enum == GearKindEnum.smith ? "guide011_4_2c" : "guide011_4_2b") : "guide011_4_2";
    Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true, (object) this.mainGear, (object) false);
  }

  private void OnMaterialPopup(GearGear gear, int quantity, int requestRank)
  {
    this.StartCoroutine(this.SetMaterialPopup(gear, quantity, requestRank));
  }

  public int SetZenie(List<GearGear> gears)
  {
    int total_item_level = 0;
    int total_item_rarity = 0;
    int cnt_use_gears = 0;
    gears.ForEach((Action<GearGear>) (item =>
    {
      if (item == null)
        return;
      total_item_level += item.compose_level;
      total_item_rarity += item.rarity.index;
      ++cnt_use_gears;
    }));
    if (cnt_use_gears < 1)
      cnt_use_gears = 1;
    int index = total_item_rarity / cnt_use_gears - 1;
    if (index < 0)
      index = 0;
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    return (int) ((boostInfo != null ? boostInfo.DiscountGearCombine : 1.0M) * (Decimal) total_item_level * 50M * (Decimal) GearRarity.ComposeRatio(index));
  }

  [DebuggerHidden]
  private IEnumerator SetMaterialPopup(GearGear gear, int quantity, int requestRank)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipeList.\u003CSetMaterialPopup\u003Ec__Iterator3BF()
    {
      gear = gear,
      quantity = quantity,
      requestRank = requestRank,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003ErequestRank = requestRank,
      \u003C\u003Ef__this = this
    };
  }

  private void IbtnYes()
  {
    if (this.IbtnEvent == null || this.CloseEvent == null)
      return;
    this.CloseEvent();
    this.IbtnEvent(this.sendMaterialList, this.mainGear.name);
  }
}
