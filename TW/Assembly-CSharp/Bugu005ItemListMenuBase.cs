// Decompiled with JetBrains decompiler
// Type: Bugu005ItemListMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu005ItemListMenuBase : BackButtonMenuBase
{
  protected int iconWidth = ItemIcon.Width;
  protected int iconHeight = ItemIcon.Height;
  protected int iconColumnValue = ItemIcon.ColumnValue;
  protected int iconRowValue = ItemIcon.RowValue;
  protected int iconScreenValue = ItemIcon.ScreenValue;
  protected int iconMaxValue = ItemIcon.MaxValue;
  protected GameObject ItemIconPrefab;
  protected bool InitializeEnd;
  protected int itemCount = -1;
  protected int itemFavoriteCount = -1;
  protected float scroolStartY;
  protected bool isUpdateIcon;
  protected List<ItemIcon> AllItemIcon = new List<ItemIcon>();
  protected List<InventoryItem> InventoryItems = new List<InventoryItem>();
  protected List<InventoryItem> DisplayItems = new List<InventoryItem>();
  private bool[] filter = new bool[27];
  private ItemSortAndFilter.SORT_TYPES sortCategory = ItemSortAndFilter.SORT_TYPES.BranchOfWeapon;
  private SortAndFilter.SORT_TYPE_ORDER_BUY orderBuySort;
  protected GameObject SortPopupPrefab;
  [SerializeField]
  protected NGxScroll2 scroll;
  [SerializeField]
  protected ItemSortAndFilter.SORT_TYPES CurrentSortType;
  [SerializeField]
  protected UISprite SortSprite;
  [SerializeField]
  private Bugu005ItemListMenuBase.SortFilterPopupMode SortFilterMode = Bugu005ItemListMenuBase.SortFilterPopupMode.Full;

  public bool[] Filter
  {
    get => this.filter;
    set => this.filter = value;
  }

  public ItemSortAndFilter.SORT_TYPES SortCategory
  {
    get => this.sortCategory;
    set => this.sortCategory = value;
  }

  public SortAndFilter.SORT_TYPE_ORDER_BUY OrderBuySort
  {
    get => this.orderBuySort;
    set => this.orderBuySort = value;
  }

  protected Future<GameObject> GetSortAndFilterPopupGameObject()
  {
    switch (this.SortFilterMode)
    {
      case Bugu005ItemListMenuBase.SortFilterPopupMode.None:
        return (Future<GameObject>) null;
      case Bugu005ItemListMenuBase.SortFilterPopupMode.Material:
        return Res.Prefabs.popup.popup_Item_Material_Sort__anim_popup01.Load<GameObject>();
      case Bugu005ItemListMenuBase.SortFilterPopupMode.Bugu:
        return Res.Prefabs.popup.popup_Item_Bugu_Sort__anim_popup01.Load<GameObject>();
      case Bugu005ItemListMenuBase.SortFilterPopupMode.AlchemistMaterial:
        return Res.Prefabs.popup.popup_Item_Alchemist_Sort__anim_popup01.Load<GameObject>();
      case Bugu005ItemListMenuBase.SortFilterPopupMode.CompseMaterial:
        return Res.Prefabs.popup.popup_Item_Bugu_composite_Sort__anim_popup01.Load<GameObject>();
      default:
        return Res.Prefabs.popup.popup_Item_Sort__anim_popup01.Load<GameObject>();
    }
  }

  public virtual Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return (Persist<Persist.ItemSortAndFilterInfo>) null;
  }

  protected virtual List<PlayerItem> GetItemList() => (List<PlayerItem>) null;

  protected virtual List<PlayerMaterialGear> GetMaterialList() => (List<PlayerMaterialGear>) null;

  protected virtual void UpdateInvetoryItem(InventoryItem invItem, PlayerItem item)
  {
    invItem.Item.Set(item);
  }

  protected virtual void UpdateInvetoryItem(InventoryItem invItem, PlayerMaterialGear item)
  {
    invItem.Item.Set(item);
  }

  protected virtual void UpdateInventoryItemList()
  {
    List<InventoryItem> list1 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x =>
    {
      if (x.Item == null || x.removeButton)
        return false;
      return x.Item.isWeapon || x.Item.isSupply;
    })).ToList<InventoryItem>();
    if (list1 != null && list1.Count<InventoryItem>() > 0)
    {
      PlayerItem[] source = SMManager.Get<PlayerItem[]>();
      foreach (InventoryItem inventoryItem in list1)
      {
        InventoryItem invItem = inventoryItem;
        PlayerItem playerItem = ((IEnumerable<PlayerItem>) source).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == invItem.Item.itemID));
        if (playerItem != (PlayerItem) null)
          this.UpdateInvetoryItem(invItem, playerItem);
      }
    }
    List<InventoryItem> list2 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x =>
    {
      if (x.Item == null || x.removeButton)
        return false;
      return x.Item.isCompse || x.Item.isExchangable;
    })).ToList<InventoryItem>();
    if (list2 != null && list2.Count<InventoryItem>() > 0)
    {
      PlayerMaterialGear[] source = SMManager.Get<PlayerMaterialGear[]>();
      foreach (InventoryItem inventoryItem in list2)
      {
        InventoryItem invItem = inventoryItem;
        PlayerMaterialGear playerMaterialGear = ((IEnumerable<PlayerMaterialGear>) source).FirstOrDefault<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => x.id == invItem.Item.itemID));
        if (playerMaterialGear != (PlayerMaterialGear) null)
          this.UpdateInvetoryItem(invItem, playerMaterialGear);
      }
    }
    this.DisplayIconAndBottomInfoUpdate();
    this.isUpdateIcon = true;
  }

  protected virtual void CreateItemIconAdvencedSetting(int inventoryItemIdx, int allItemIdx)
  {
    ItemIcon itemIcon = this.AllItemIcon[allItemIdx];
    InventoryItem displayItem = this.DisplayItems[inventoryItemIdx];
    itemIcon.onClick = (Action<ItemIcon>) (playeritem => this.ChangeDetailScene(playeritem.ItemInfo));
    if (displayItem.Item.isSupply || displayItem.Item.isExchangable || displayItem.Item.isCompse)
    {
      itemIcon.QuantitySupply = true;
      itemIcon.EnableQuantity(displayItem.Item.quantity);
    }
    else
      itemIcon.QuantitySupply = false;
    itemIcon.ForBattle = displayItem.Item.ForBattle;
    itemIcon.Favorite = displayItem.Item.favorite;
    itemIcon.Gray = false;
    itemIcon.SelectedQuantity(0);
    itemIcon.Deselect();
    itemIcon.EnableLongPressEvent(new Action<GameCore.ItemInfo>(this.ChangeDetailScene));
  }

  [DebuggerHidden]
  protected virtual IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu005ItemListMenuBase.\u003CInitExtension\u003Ec__Iterator304 extensionCIterator304 = new Bugu005ItemListMenuBase.\u003CInitExtension\u003Ec__Iterator304();
    return (IEnumerator) extensionCIterator304;
  }

  protected virtual void BottomInfoUpdate()
  {
  }

  protected virtual void AllItemIconUpdate()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
    {
      Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    this.backScene();
  }

  [DebuggerHidden]
  public virtual IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005ItemListMenuBase.\u003CInit\u003Ec__Iterator305()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onEndScene() => Singleton<PopupManager>.GetInstance().closeAll();

  [DebuggerHidden]
  protected IEnumerator LoadItemIconPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005ItemListMenuBase.\u003CLoadItemIconPrefab\u003Ec__Iterator306()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator LoadSpriteCache()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005ItemListMenuBase.\u003CLoadSpriteCache\u003Ec__Iterator307()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected int GetItemListCnt(List<PlayerItem> itemList, List<PlayerMaterialGear> materialItemList)
  {
    int tmpItmCnt = 0;
    if (itemList != null && itemList.Count<PlayerItem>() > 0)
      itemList.ForEach((Action<PlayerItem>) (x =>
      {
        if (x.isWeapon())
          ++tmpItmCnt;
        else
          tmpItmCnt += x.quantity;
      }));
    if (materialItemList != null && materialItemList.Count<PlayerMaterialGear>() > 0)
      materialItemList.ForEach((Action<PlayerMaterialGear>) (x => tmpItmCnt += x.quantity));
    return tmpItmCnt;
  }

  protected int GetItemListFavoriteCnt(List<PlayerItem> itemList)
  {
    int num = 0;
    return itemList != null && itemList.Count<PlayerItem>() > 0 ? itemList.Count<PlayerItem>((Func<PlayerItem, bool>) (x => x.favorite)) : num;
  }

  protected void CreateInvetoryItem(
    List<PlayerItem> itemList,
    List<PlayerMaterialGear> materialItemList)
  {
    if (itemList != null && itemList.Count<PlayerItem>() > 0)
    {
      foreach (PlayerItem playerItem in itemList)
        this.InventoryItems.Add(new InventoryItem(playerItem));
    }
    if (materialItemList == null || materialItemList.Count<PlayerMaterialGear>() <= 0)
      return;
    foreach (PlayerMaterialGear materialItem in materialItemList)
    {
      PlayerMaterialGear item = materialItem;
      this.InventoryItems.Add(new InventoryItem(item, this.InventoryItems.Count<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemID == item.id))));
    }
  }

  protected void DisplayIconAndBottomInfoUpdate()
  {
    this.AllItemIconUpdate();
    this.BottomInfoUpdate();
  }

  protected void CreatePlayerItems()
  {
    this.scroll.Clear();
    this.AllItemIcon.Clear();
    for (int index = 0; index < Mathf.Min(ItemIcon.MaxValue, this.InventoryItems.Count); ++index)
      this.AllItemIcon.Add(Object.Instantiate<GameObject>(this.ItemIconPrefab).GetComponent<ItemIcon>());
    this.Sort(this.SortCategory, this.OrderBuySort);
    this.scroolStartY = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.StartCoroutine(this.LoadSpriteCache());
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public override void onBackButton() => this.IbtnBack();

  protected virtual void ChangeDetailScene(GameCore.ItemInfo item)
  {
    if (item == null)
      return;
    if (item.isWeapon)
      Unit00443Scene.changeScene(true, item);
    else
      Bugu00561Scene.changeScene(true, item);
  }

  public virtual void IbtnSort()
  {
    if (this.IsPush)
      return;
    this.ShowSortAndFilterPopup();
  }

  private void ShowSortAndFilterPopup()
  {
    if (!Singleton<PopupManager>.GetInstance().isOpen)
    {
      if (!Object.op_Inequality((Object) this.SortPopupPrefab, (Object) null))
        return;
      GameObject prefab = this.SortPopupPrefab.Clone();
      prefab.GetComponent<ItemSortAndFilter>().Initialize(this, true);
      Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
    }
    else
      this.IsPush = false;
  }

  public virtual void Sort(
    ItemSortAndFilter.SORT_TYPES type,
    SortAndFilter.SORT_TYPE_ORDER_BUY order)
  {
    this.CurrentSortType = type;
    if (Object.op_Inequality((Object) this.SortSprite, (Object) null))
      this.SortSprite = ItemSortAndFilter.SortSpriteLabel(type, this.SortSprite);
    this.DisplayItems = this.InventoryItems.FilterBy(this.filter).ToList<InventoryItem>();
    this.DisplayItems = this.DisplayItems.SortBy(type, order).ToList<InventoryItem>();
    this.scroll.Reset();
    this.AllItemIcon.ForEach((Action<ItemIcon>) (x =>
    {
      ((Component) x).transform.parent = ((Component) this).transform;
      ((Component) x).gameObject.SetActive(false);
    }));
    for (int index = 0; index < Mathf.Min(this.iconMaxValue, this.DisplayItems.Count); ++index)
    {
      this.scroll.Add(((Component) this.AllItemIcon[index]).gameObject, this.iconWidth, this.iconHeight);
      ((Component) this.AllItemIcon[index]).gameObject.SetActive(true);
    }
    this.InventoryItems.ForEach((Action<InventoryItem>) (v => v.icon = (ItemIcon) null));
    this.StartCoroutine(this.CreateItemIconRange(Mathf.Min(this.iconMaxValue, this.DisplayItems.Count)));
    this.scroll.CreateScrollPoint(this.iconHeight, this.DisplayItems.Count);
    this.scroll.ResolvePosition();
  }

  private void ScrollIconUpdate(int inventoryItemsIndex, int count)
  {
    if (this.DisplayItems[inventoryItemsIndex].removeButton || ItemIcon.IsCache(this.DisplayItems[inventoryItemsIndex].Item))
      this.CreateItemIconCache(inventoryItemsIndex, count);
    else
      this.StartCoroutine(this.CreateItemIcon(inventoryItemsIndex, count));
  }

  private void ScrollUpdate()
  {
    if ((!this.InitializeEnd || this.DisplayItems.Count <= this.iconScreenValue) && !this.isUpdateIcon)
      return;
    int num1 = this.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scroolStartY;
    float num3 = (float) (Mathf.Max(0, this.DisplayItems.Count - this.iconScreenValue - 1) / this.iconColumnValue * this.iconHeight);
    float num4 = (float) (this.iconHeight * this.iconRowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int count = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject item = gameObject;
        float num5 = item.transform.localPosition.y + num2;
        int? nullable = this.DisplayItems.FirstIndexOrNull<InventoryItem>((Func<InventoryItem, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
        if ((double) num5 > (double) num1)
        {
          item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
          if (nullable.HasValue && nullable.Value + this.iconMaxValue < (this.DisplayItems.Count + 4) / 5 * 5)
          {
            if (nullable.Value + this.iconMaxValue >= this.DisplayItems.Count)
              item.SetActive(false);
            else
              this.ScrollIconUpdate(nullable.Value + this.iconMaxValue, count);
            flag = true;
          }
        }
        else if ((double) num5 < -((double) num4 - (double) num1))
        {
          int num6 = this.iconMaxValue;
          if (!item.activeSelf)
          {
            item.SetActive(true);
            num6 = 0;
          }
          if (nullable.HasValue && nullable.Value - num6 >= 0)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + num4, 0.0f);
            this.ScrollIconUpdate(nullable.Value - num6, count);
            flag = true;
          }
        }
        else if (this.isUpdateIcon)
          this.ScrollIconUpdate(nullable.Value, count);
        ++count;
      }
    }
    while (flag);
    if (!this.isUpdateIcon)
      return;
    this.isUpdateIcon = false;
  }

  private void ResetItemIcon(int allItemIdx)
  {
    ((Component) this.AllItemIcon[allItemIdx]).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIconRange(int max)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005ItemListMenuBase.\u003CCreateItemIconRange\u003Ec__Iterator308()
    {
      max = max,
      \u003C\u0024\u003Emax = max,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIcon(int inventoryItemIdx, int allItemIdx)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005ItemListMenuBase.\u003CCreateItemIcon\u003Ec__Iterator309()
    {
      allItemIdx = allItemIdx,
      inventoryItemIdx = inventoryItemIdx,
      \u003C\u0024\u003EallItemIdx = allItemIdx,
      \u003C\u0024\u003EinventoryItemIdx = inventoryItemIdx,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateItemIconCache(int inventoryItemIdx, int allItemIdx)
  {
    ItemIcon itemIcon = this.AllItemIcon[allItemIdx];
    this.DisplayItems.Where<InventoryItem>((Func<InventoryItem, bool>) (a => Object.op_Equality((Object) a.icon, (Object) itemIcon))).ForEach<InventoryItem>((Action<InventoryItem>) (b => b.icon = (ItemIcon) null));
    this.DisplayItems[inventoryItemIdx].icon = itemIcon;
    if (this.DisplayItems[inventoryItemIdx].removeButton)
      itemIcon.InitByRemoveButton();
    else
      itemIcon.InitByItemInfoCache(this.DisplayItems[inventoryItemIdx].Item);
    this.CreateItemIconAdvencedSetting(inventoryItemIdx, allItemIdx);
    itemIcon.ShowBottomInfo(this.CurrentSortType);
  }

  private enum SortFilterPopupMode
  {
    None,
    Full,
    Material,
    Bugu,
    AlchemistMaterial,
    CompseMaterial,
  }
}
