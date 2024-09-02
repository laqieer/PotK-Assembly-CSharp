// Decompiled with JetBrains decompiler
// Type: Bugu0052Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
public class Bugu0052Menu : BackButtonMenuBase
{
  public const int PAKUPAKU_MAXSELECT = 5;
  public const int DRILLING_MAXSELECT = 5;
  public const int SPECIAL_DRILLING_MAXSELECT = 1;
  protected const int REPAIR_NORMAL_MAXSELECT = 5;
  protected const int REPAIR_POWERED_MAXSELECT = 1;
  protected const int COMPOSITE_MINSELECT = 2;
  public const int PAKUPAKU_MINSELECT = 1;
  protected const int OTHER_MAXSELECT = 99;
  protected const int NOTSELECT = 0;
  protected const int BED_MAX_PERCENT = 90;
  protected const int BED_UP_PERCENT = 10;
  protected const int EXPENSE_MEDAL = 10;
  protected const float LINK_HEIGHT = 90f;
  protected const float LINK_DEFHEIGHT = 136f;
  protected const float scale = 0.6617647f;
  protected const float scale_repair = 0.8f;
  protected const float scale_repair_powered = 1f;
  public NGxScroll2 scroll;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  protected Bugu0052Menu.ResultParam resultParam = new Bugu0052Menu.ResultParam();
  private List<ItemIcon> allItemIcon = new List<ItemIcon>();
  private List<InventoryItem> FirstSelectItemList = new List<InventoryItem>();
  protected List<InventoryItem> ItemList = new List<InventoryItem>();
  private List<InventoryItem> InventoryItems = new List<InventoryItem>();
  private PlayerItem targetGear;
  private GameObject prefab;
  protected Player player;
  private int iconWidth = ItemIcon.Width;
  private int iconHeight = ItemIcon.Height;
  private int iconColumnValue = ItemIcon.ColumnValue;
  private int iconRowValue = ItemIcon.RowValue;
  private int iconScreenValue = ItemIcon.ScreenValue;
  private int iconMaxValue = ItemIcon.MaxValue;
  private bool isInitialize;
  protected Bugu0052Scene.MODE mode;
  private Bugu0052Menu.REPAIR_MODE repair_mode;
  private int bedCount;
  private int cost;
  private float scaleRaito;
  private float scrool_start_y;
  private bool isUpdateIcon;
  private bool isInit;
  protected Bugu0052Scene scene;
  [SerializeField]
  protected Transform[] iconParent;
  [SerializeField]
  protected Transform[] iconParentRepair;
  [SerializeField]
  protected Transform[] iconParentRepairPowered;
  [SerializeField]
  protected ItemIcon[] icons;
  [SerializeField]
  protected GameObject[] SortLabel;
  [SerializeField]
  protected GameObject CompositeYesButton;
  [SerializeField]
  protected GameObject ModeOverView;
  [SerializeField]
  protected GameObject ModeComposite;
  [SerializeField]
  protected GameObject ModeRepair;
  [SerializeField]
  protected GameObject ModePoweredRepair;
  [SerializeField]
  protected GameObject ModeSell;
  [SerializeField]
  protected UIButton RepairBedAddButton;
  [SerializeField]
  protected UIButton RepairBedReduceButton;
  [SerializeField]
  protected UIButton RepairMedalButton;
  [SerializeField]
  protected UIButton RepairMoneyButton;
  [SerializeField]
  protected UIButton RepairPowerdMoneyButton;
  [SerializeField]
  protected UIButton SellYesButton;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel NumProsession1;
  [SerializeField]
  protected UILabel NumProsession3;
  [SerializeField]
  protected UILabel NumSelectedCount2;
  [SerializeField]
  protected UILabel NumSelectedCount3;
  [SerializeField]
  protected UILabel NumSpendZenie2;
  [SerializeField]
  protected UILabel NumSpendZenie3;
  [SerializeField]
  protected UILabel TxtZenyPattern3;
  [SerializeField]
  protected UILabel TxtZenyRepair;
  [SerializeField]
  protected UILabel TxtZenyRepairPowered;
  [SerializeField]
  protected UILabel TxtRepairGearName;
  [SerializeField]
  protected UILabel TxtGearRepairProbability;
  [SerializeField]
  protected UILabel TxtProsession3;
  [SerializeField]
  protected UILabel[] TxtGearsRepairProbablity;
  [SerializeField]
  protected GameObject ScrollView;
  public ItemIcon.Sort sortLabel;
  protected int COMPOSITE_MAXSELECT = 5;
  private List<PlayerItem> oldSelectItem;

  public int Cost => this.cost;

  protected virtual void Foreground()
  {
  }

  protected virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public virtual IEnumerator UpdateIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CUpdateIcon\u003Ec__Iterator301()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitPlayerItems(
    List<InventoryItem> InventoryItems,
    Player player,
    Bugu0052Scene.MODE mode,
    bool isResetParam,
    Bugu0052Scene scene = null,
    List<PlayerItem> select = null,
    PlayerItem target = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CInitPlayerItems\u003Ec__Iterator302()
    {
      select = select,
      scene = scene,
      target = target,
      isResetParam = isResetParam,
      InventoryItems = InventoryItems,
      player = player,
      mode = mode,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003Escene = scene,
      \u003C\u0024\u003Etarget = target,
      \u003C\u0024\u003EisResetParam = isResetParam,
      \u003C\u0024\u003EInventoryItems = InventoryItems,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateSelectItem()
  {
    IOrderedEnumerable<InventoryItem> orderedEnumerable1 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.select)).OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.index));
    int num = 1;
    foreach (InventoryItem inventoryItem in (IEnumerable<InventoryItem>) orderedEnumerable1)
    {
      inventoryItem.index = num;
      ++num;
    }
    IOrderedEnumerable<InventoryItem> orderedEnumerable2 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.select)).OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.index));
    this.ItemList.Clear();
    foreach (InventoryItem inventoryItem in (IEnumerable<InventoryItem>) orderedEnumerable2)
    {
      InventoryItem item = inventoryItem;
      this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item == item.Item)).ForEach<InventoryItem>((Action<InventoryItem>) (x => item.selectCount = x.selectCount));
      this.ItemList.Add(item);
    }
  }

  private void InventoryUpdate()
  {
    foreach (InventoryItem inventoryItem in this.InventoryItems)
    {
      if (this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
      {
        if (this.targetGear == (PlayerItem) null)
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
        else if (this.isActiveSpecialDrillingMaterial(inventoryItem.Item))
        {
          if (inventoryItem.Item.favorite || inventoryItem.Item.ForBattle || inventoryItem.Item.broken)
          {
            inventoryItem.Gray = true;
            inventoryItem.select = false;
            inventoryItem.index = 0;
          }
          else if (inventoryItem.select)
          {
            inventoryItem.Gray = true;
          }
          else
          {
            inventoryItem.Gray = false;
            inventoryItem.select = false;
            inventoryItem.index = 0;
          }
        }
        else
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
      }
      else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL)
      {
        if (this.targetGear == (PlayerItem) null)
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
        else if (this.isActiveDrillingMaterial(inventoryItem.Item))
        {
          if (inventoryItem.Item.favorite || inventoryItem.Item.ForBattle || inventoryItem.Item.broken)
          {
            inventoryItem.Gray = true;
            inventoryItem.select = false;
            inventoryItem.index = 0;
          }
          else if (inventoryItem.select)
          {
            inventoryItem.Gray = true;
          }
          else
          {
            inventoryItem.Gray = false;
            inventoryItem.select = false;
            inventoryItem.index = 0;
          }
        }
        else
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
      }
      if (this.mode == Bugu0052Scene.MODE.SELL || this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
      {
        if ((this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL) && inventoryItem.Item.broken)
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
        else if (inventoryItem.Item.favorite || inventoryItem.Item.ForBattle)
        {
          inventoryItem.Gray = true;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
        else if (inventoryItem.select)
        {
          inventoryItem.Gray = true;
        }
        else
        {
          inventoryItem.Gray = false;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
      }
      if ((this.mode == Bugu0052Scene.MODE.PAKUPAKU_BASE || this.mode == Bugu0052Scene.MODE.DRILLING_BASE) && inventoryItem.Item.broken)
      {
        inventoryItem.Gray = true;
        inventoryItem.select = false;
        inventoryItem.index = 0;
      }
      if (this.mode == Bugu0052Scene.MODE.REPAIR)
      {
        if (inventoryItem.select)
        {
          inventoryItem.Gray = true;
        }
        else
        {
          inventoryItem.Gray = false;
          inventoryItem.select = false;
          inventoryItem.index = 0;
        }
      }
    }
    int num = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.select)).Count<InventoryItem>();
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE && num == this.COMPOSITE_MAXSELECT || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL && num == 5)
      this.InventoryItems.GrayReverseComposite();
    else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL && num == 5)
      this.InventoryItems.GrayReverseDrilling(new Func<PlayerItem, bool>(this.isActiveDrillingMaterial));
    else if (this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL && num == 1)
      this.InventoryItems.GrayReverseDrilling(new Func<PlayerItem, bool>(this.isActiveSpecialDrillingMaterial));
    if (this.mode == Bugu0052Scene.MODE.SELL && num == 99)
      this.InventoryItems.GrayReverseSell();
    if (this.mode == Bugu0052Scene.MODE.REPAIR && (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL && num == 5 || this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED && num == 1))
    {
      this.InventoryItems.GrayReverseAll();
    }
    else
    {
      if (num != 0)
        return;
      this.InitRepair(false, false);
    }
  }

  private void CreateStatusItemIcon()
  {
    Transform[] transformArray;
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      this.scaleRaito = 0.6617647f;
      transformArray = this.iconParent;
      this.COMPOSITE_MAXSELECT = 5;
    }
    else if (this.mode == Bugu0052Scene.MODE.REPAIR && this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL)
    {
      this.scaleRaito = 0.8f;
      transformArray = this.iconParentRepair;
      this.COMPOSITE_MAXSELECT = 5;
    }
    else
    {
      if (this.mode != Bugu0052Scene.MODE.REPAIR || this.repair_mode != Bugu0052Menu.REPAIR_MODE.POWERED)
        return;
      this.scaleRaito = 1f;
      transformArray = this.iconParentRepairPowered;
      this.COMPOSITE_MAXSELECT = 1;
    }
    foreach (Component component in transformArray)
      ((IEnumerable<ItemIcon>) component.GetComponentsInChildren<ItemIcon>()).ForEach<ItemIcon>((Action<ItemIcon>) (x => Object.Destroy((Object) ((Component) x).gameObject)));
    for (int index = 0; index < this.COMPOSITE_MAXSELECT; ++index)
    {
      GameObject gameObject = this.prefab.Clone(transformArray[index]);
      gameObject.transform.localScale = new Vector3(this.scaleRaito, this.scaleRaito);
      ItemIcon component = gameObject.GetComponent<ItemIcon>();
      component.SetEmpty(true);
      this.icons[index] = component;
    }
    if (this.ItemList.Count > 0)
      this.CreateButtomIcon();
    for (int count = this.ItemList.Count; count < this.COMPOSITE_MAXSELECT; ++count)
    {
      this.icons[count].SetEmpty(true);
      this.icons[count].onClick = (Action<ItemIcon>) null;
    }
  }

  private void CreateButtomIcon()
  {
    for (int index = 0; index < this.ItemList.Count; ++index)
    {
      this.icons[index].SetEmpty(false);
      if (ItemIcon.IsCache(this.ItemList[index].Item))
        this.icons[index].InitByPlayerItemCache(this.ItemList[index].Item);
      else
        this.StartCoroutine(this.icons[index].InitByPlayerItem(this.ItemList[index].Item));
      this.icons[index].onClick = (Action<ItemIcon>) (playeritem => this.StartCoroutine(this.ButtomIconClickSet(playeritem)));
      this.icons[index].Gray = false;
      this.icons[index].Deselect();
      ((Component) this.icons[index]).transform.localScale = new Vector3(this.scaleRaito, this.scaleRaito);
    }
  }

  [DebuggerHidden]
  private IEnumerator ButtomIconClickSet(ItemIcon icon)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CButtomIconClickSet\u003Ec__Iterator303()
    {
      icon = icon,
      \u003C\u0024\u003Eicon = icon,
      \u003C\u003Ef__this = this
    };
  }

  private void InitRepair(bool addButton, bool reduceButton, bool isNoAnim = false)
  {
    if (this.mode != Bugu0052Scene.MODE.REPAIR)
      return;
    this.RepairButtonCondition(addButton, reduceButton, isNoAnim);
    if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED)
    {
      this.TxtZenyRepairPowered.SetTextLocalize(0);
      this.TxtRepairGearName.SetTextLocalize(string.Empty);
      this.TxtGearRepairProbability.SetTextLocalize("- %");
    }
    else
    {
      ((IEnumerable<UILabel>) this.TxtGearsRepairProbablity).ForEach<UILabel>((Action<UILabel>) (x => x.SetTextLocalize("- %")));
      this.TxtZenyRepair.SetTextLocalize(0);
    }
  }

  private void RepairButtonCondition(bool addButton, bool reduceButton, bool isNoAnim = false)
  {
    if (!Object.op_Inequality((Object) this.RepairBedAddButton, (Object) null) || !Object.op_Inequality((Object) this.RepairBedReduceButton, (Object) null) || !Object.op_Inequality((Object) this.RepairMedalButton, (Object) null) || !Object.op_Inequality((Object) this.RepairPowerdMoneyButton, (Object) null))
      return;
    float duration1 = this.RepairBedAddButton.duration;
    float duration2 = this.RepairBedReduceButton.duration;
    float duration3 = this.RepairMedalButton.duration;
    float duration4 = this.RepairPowerdMoneyButton.duration;
    if (isNoAnim)
    {
      this.RepairBedAddButton.duration = 0.0f;
      this.RepairBedReduceButton.duration = 0.0f;
      this.RepairMedalButton.duration = 0.0f;
      this.RepairPowerdMoneyButton.duration = 0.0f;
    }
    this.RepairBedAddButton.isEnabled = addButton;
    this.RepairBedReduceButton.isEnabled = reduceButton;
    this.RepairMedalButton.isEnabled = this.player.medal >= 10 && (addButton || reduceButton);
    this.RepairPowerdMoneyButton.isEnabled = this.player.money >= this.cost && (addButton || reduceButton);
    if (!isNoAnim)
      return;
    this.RepairBedAddButton.duration = duration1;
    this.RepairBedReduceButton.duration = duration2;
    this.RepairMedalButton.duration = duration3;
    this.RepairPowerdMoneyButton.duration = duration4;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public override void onBackButton() => this.IbtnBack();

  private void BackComposite()
  {
    Bugu0053Scene.changeScene(false, this.FavoriteBattleExcluion(this.FirstSelectItemList));
  }

  private void BackPAKUMATE()
  {
    Bugu0058Scene.changeScene(false, this.FavoriteBattleExcluion(this.oldSelectItem));
    Singleton<NGSceneManager>.GetInstance().destroyScene("bugu005_8_2");
  }

  private void BackDrillingMaterial()
  {
    Bugu0059Scene.changeScene(false, this.targetGear, this.FavoriteBattleExcluion(this.oldSelectItem).Select<InventoryItem, PlayerItem>((Func<InventoryItem, PlayerItem>) (x => x.Item)).ToList<PlayerItem>());
    Singleton<NGSceneManager>.GetInstance().destroyScene("bugu005_9_2");
  }

  private List<InventoryItem> FavoriteBattleExcluion(List<PlayerItem> list)
  {
    List<InventoryItem> newList = new List<InventoryItem>();
    list.ForEach((Action<PlayerItem>) (x => newList.Add(new InventoryItem(x))));
    return this.FavoriteBattleExcluion(newList);
  }

  private List<InventoryItem> FavoriteBattleExcluion(List<InventoryItem> list)
  {
    List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    foreach (InventoryItem inventoryItem in list)
    {
      InventoryItem item = inventoryItem;
      if (this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => !x.Item.favorite)).Where<InventoryItem>((Func<InventoryItem, bool>) (x => !x.Item.ForBattle)).FirstIndexOrNull<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.id == item.Item.id)).HasValue)
        inventoryItemList.Add(item);
    }
    return inventoryItemList;
  }

  protected virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.isInit = true;
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
    {
      Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE)
      this.BackComposite();
    else if (this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
      this.BackPAKUMATE();
    else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL || this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
      this.BackDrillingMaterial();
    else
      this.backScene();
  }

  public virtual void IbtnClearS()
  {
    if (this.IsPush)
      return;
    foreach (InventoryItem inventoryItem in this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.select)))
    {
      inventoryItem.select = false;
      inventoryItem.index = 0;
    }
    for (int index = 0; index < this.COMPOSITE_MAXSELECT; ++index)
      this.icons[index].SetEmpty(true);
    this.IconsUpdate();
  }

  public virtual void IbtnYesS()
  {
    if (this.IsPushAndSet())
      return;
    this.isInit = true;
    if (this.ItemList.Select<InventoryItem, bool>((Func<InventoryItem, bool>) (x => x.Item.favorite)).Contains<bool>(true))
    {
      if (this.mode == Bugu0052Scene.MODE.COMPOSITE)
      {
        this.StartCoroutine(PopupCommon.Show(Consts.Lookup("POPUP_005_GEAR_WARNING_TITLE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_COMPOSITE")
          }
        }), Consts.Lookup("POPUP_005_FAVORITE_WARNING_MESSAGE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_COMPOSITE")
          }
        })));
      }
      else
      {
        if (this.mode != Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
          return;
        this.StartCoroutine(PopupCommon.Show(Consts.Lookup("GEAR_0052_PAKUPAKU_TITLE"), Consts.Lookup("POPUP_005_FAVORITE_WARNING_MESSAGE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_PAKUPAKU_TITLE")
          }
        })));
      }
    }
    else if (this.mode == Bugu0052Scene.MODE.COMPOSITE)
    {
      if (this.ItemList.Count >= 2)
        Bugu0053Scene.changeScene(false, this.ItemList);
      else
        this.StartCoroutine(PopupCommon.Show(Consts.Lookup("POPUP_005_GEAR_WARNING_TITLE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_COMPOSITE")
          }
        }), Consts.Lookup("POPUP_005_COMPOSITE_WARNING_MESSAGE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_COMPOSITE")
          }
        })));
    }
    else
    {
      if (this.mode != Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
        return;
      Bugu0058Scene.changeScene(false, this.ItemList);
    }
  }

  public virtual void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    if (this.mode == Bugu0052Scene.MODE.SELL)
    {
      if (this.ItemList.Any<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.favorite)))
      {
        this.StartCoroutine(PopupCommon.Show(Consts.Lookup("POPUP_005_GEAR_WARNING_TITLE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_SELL")
          }
        }), Consts.Lookup("POPUP_005_FAVORITE_WARNING_MESSAGE", (IDictionary) new Hashtable()
        {
          {
            (object) "type",
            (object) Consts.Lookup("GEAR_0052_SELL")
          }
        })));
      }
      else
      {
        if (this.ItemList.Count <= 0)
          return;
        if (this.ItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear != null)).Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear.rarity.index >= 3)).ToList<InventoryItem>().Count > 0)
          this.StartCoroutine(this.SellWarningPopUp(new System.Action(this.CallSellAPI)));
        else
          this.StartCoroutine(this.SellCheckPopUp(new System.Action(this.CallSellAPI)));
      }
    }
    else if (this.mode == Bugu0052Scene.MODE.REPAIR)
    {
      this.RepairIbtnYes();
    }
    else
    {
      if (this.mode != Bugu0052Scene.MODE.DRILLING_MATERIAL && this.mode != Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
        return;
      Bugu0059Scene.changeScene(false, this.targetGear, this.ItemList.Select<InventoryItem, PlayerItem>((Func<InventoryItem, PlayerItem>) (x => x.Item)).ToList<PlayerItem>());
      Singleton<NGSceneManager>.GetInstance().destroyScene("bugu005_9_2");
    }
  }

  private void RepairIbtnYes(bool medal = false)
  {
    if (this.mode != Bugu0052Scene.MODE.REPAIR)
      return;
    if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL && this.ItemList.Count > 0)
    {
      if (this.cost > this.player.money)
        this.StartCoroutine(this.NotEnoughMoneyPopUp());
      else
        this.StartCoroutine(this.RepairAPI());
    }
    else
    {
      if (this.repair_mode != Bugu0052Menu.REPAIR_MODE.POWERED || this.ItemList.Count <= 0)
        return;
      if (this.cost > this.player.money && !medal)
        this.StartCoroutine(this.NotEnoughMoneyPopUp());
      else
        this.StartCoroutine(this.RepairPoweredAPI(medal));
    }
  }

  public void RepairMedalIbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.RepairPopup(new System.Action(this.PassMedalActionMethod), "medal", 10));
  }

  public void RepairZenyIbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.RepairPopup(new System.Action(this.PassMoneyActionMethod), "money", this.cost));
  }

  [DebuggerHidden]
  private IEnumerator RepairPopup(System.Action act, string kind, int latch)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CRepairPopup\u003Ec__Iterator304()
    {
      act = act,
      kind = kind,
      latch = latch,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Ekind = kind,
      \u003C\u0024\u003Elatch = latch
    };
  }

  private void PassMedalActionMethod() => this.RepairIbtnYes(true);

  private void PassMoneyActionMethod() => this.RepairIbtnYes();

  public virtual void IbtnNo()
  {
    if (this.IsPush)
      return;
    foreach (InventoryItem inventoryItem in this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.select)))
    {
      inventoryItem.select = false;
      inventoryItem.index = 0;
    }
    this.IconsUpdate();
  }

  public virtual void IbtnSort()
  {
    if (this.IsPush)
      return;
    int num;
    this.sortLabel = (ItemIcon.Sort) ((num = (int) (this.sortLabel + 1)) % 4);
    Persist.sortOrder.Data.Weapon = (int) this.sortLabel;
    this.Sort();
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    this.InventoryItems.ForEach((Action<InventoryItem>) (v => v.icon = (ItemIcon) null));
    this.StartCoroutine(this.CreateItemIconRange(Mathf.Min(this.iconMaxValue, this.InventoryItems.Count)));
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIconRange(int value)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CCreateItemIconRange\u003Ec__Iterator305()
    {
      value = value,
      \u003C\u0024\u003Evalue = value,
      \u003C\u003Ef__this = this
    };
  }

  private void IconsUpdate()
  {
    this.CreateSelectItem();
    this.SelectedUpdate();
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.REPAIR || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      if (this.ItemList.Count > 0)
        this.CreateButtomIcon();
      for (int count = this.ItemList.Count; count < this.COMPOSITE_MAXSELECT; ++count)
        this.icons[count].SetEmpty(true);
    }
    this.RepairProbabilityUpdate();
    this.GrayUpdate();
    this.CostCalculation();
    this.GrayYesButton();
  }

  private void GrayUpdate()
  {
    foreach (InventoryItem inventoryItem in this.InventoryItems)
    {
      if (inventoryItem.select)
        inventoryItem.Gray = true;
      else if (this.mode == Bugu0052Scene.MODE.REPAIR)
        inventoryItem.Gray = false;
      else if ((this.mode != Bugu0052Scene.MODE.DRILLING_MATERIAL || this.isActiveDrillingMaterial(inventoryItem.Item)) && (this.mode != Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL || this.isActiveSpecialDrillingMaterial(inventoryItem.Item)) && !inventoryItem.Item.ForBattle && !inventoryItem.Item.favorite && (this.mode != Bugu0052Scene.MODE.COMPOSITE && this.mode != Bugu0052Scene.MODE.PAKUPAKU_MATERIAL && this.mode != Bugu0052Scene.MODE.PAKUPAKU_BASE && this.mode != Bugu0052Scene.MODE.DRILLING_BASE || !inventoryItem.Item.broken))
        inventoryItem.Gray = false;
    }
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE && this.ItemList.Count == this.COMPOSITE_MAXSELECT || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL && this.ItemList.Count == 5)
      this.InventoryItems.GrayReverseComposite();
    else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL && this.ItemList.Count == 5)
      this.InventoryItems.GrayReverseDrilling(new Func<PlayerItem, bool>(this.isActiveDrillingMaterial));
    else if (this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL && this.ItemList.Count == 1)
      this.InventoryItems.GrayReverseDrilling(new Func<PlayerItem, bool>(this.isActiveSpecialDrillingMaterial));
    else if (this.ItemList.Count == 99 && this.mode == Bugu0052Scene.MODE.SELL)
      this.InventoryItems.GrayReverseSell();
    else if (this.mode == Bugu0052Scene.MODE.REPAIR && (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL && this.ItemList.Count == 5 || this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED && this.ItemList.Count == 1))
      this.InventoryItems.GrayReverseAll();
    foreach (ItemIcon itemIcon in this.allItemIcon)
    {
      ItemIcon icon = itemIcon;
      this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item == icon.PlayerItem)).ForEach<InventoryItem>((Action<InventoryItem>) (x => icon.Gray = x.Gray));
    }
  }

  private void SelectedUpdate()
  {
    foreach (ItemIcon itemIcon in this.allItemIcon)
    {
      foreach (InventoryItem inventoryItem in this.InventoryItems)
      {
        if (inventoryItem.Item == itemIcon.PlayerItem)
        {
          if (inventoryItem.select)
          {
            itemIcon.SelectedQuantity(inventoryItem.selectCount);
            if (this.mode == Bugu0052Scene.MODE.SELL)
              itemIcon.SelectByCheckIcon();
            else
              itemIcon.Select(inventoryItem.index - 1);
          }
          else
          {
            itemIcon.SelectQuantity = false;
            if (this.mode == Bugu0052Scene.MODE.SELL)
              itemIcon.DeselectByCheckIcon();
            else
              itemIcon.Deselect();
          }
        }
      }
    }
  }

  private void DestroyIcon()
  {
    for (int index = 0; index < this.COMPOSITE_MAXSELECT; ++index)
      this.icons[index].SetEmpty(true);
  }

  private void RepairProbabilityUpdate()
  {
    if (this.mode != Bugu0052Scene.MODE.REPAIR || this.repair_mode != Bugu0052Menu.REPAIR_MODE.NORMAL)
      return;
    for (int index = 0; index < this.ItemList.Count; ++index)
    {
      int num = (int) Math.Round((double) this.ItemList[index].Item.gear.repair_success_ratio * 100.0);
      this.TxtGearsRepairProbablity[index].SetTextLocalize(num.ToString() + "%");
    }
    for (int count = this.ItemList.Count; count < ((IEnumerable<UILabel>) this.TxtGearsRepairProbablity).Count<UILabel>(); ++count)
      this.TxtGearsRepairProbablity[count].SetTextLocalize("- %");
  }

  protected virtual void SetTitle()
  {
    int num = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Count<PlayerItem>();
    switch (this.mode)
    {
      case Bugu0052Scene.MODE.OVERVIEW:
        this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_VIEW_TITLE"));
        this.scrollPanel.bottomAnchor.absolute = -3;
        this.scrollBarWidget.topAnchor.absolute = -13;
        this.scrollBarWidget.bottomAnchor.absolute = 23;
        this.SetPosessionText(num, this.player.max_items);
        break;
      case Bugu0052Scene.MODE.COMPOSITE:
        this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_COMPOSITE_TITLE"));
        this.scrollPanel.bottomAnchor.absolute = 130;
        this.scrollBarWidget.topAnchor.absolute = -8;
        this.scrollBarWidget.bottomAnchor.absolute = 140;
        break;
      case Bugu0052Scene.MODE.PAKUPAKU_BASE:
        this.TxtTitle.text = Consts.Lookup("GEAR_0052_PAKUPAKU_BASE_SELECT_TITLE");
        this.scrollPanel.bottomAnchor.absolute = 0;
        this.scrollBarWidget.topAnchor.absolute = -8;
        this.scrollBarWidget.bottomAnchor.absolute = 0;
        break;
      case Bugu0052Scene.MODE.PAKUPAKU_MATERIAL:
        this.TxtTitle.text = Consts.Lookup("GEAR_0052_PAKUPAKU_MATERIAL_SELECT_TITLE");
        this.scrollPanel.bottomAnchor.absolute = 130;
        this.scrollBarWidget.topAnchor.absolute = -8;
        this.scrollBarWidget.bottomAnchor.absolute = 140;
        break;
      case Bugu0052Scene.MODE.REPAIR:
        this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_REPAIR_TITLE"));
        this.scrollPanel.bottomAnchor.absolute = 385;
        this.scrollBarWidget.topAnchor.absolute = -13;
        this.scrollBarWidget.bottomAnchor.absolute = 400;
        break;
      case Bugu0052Scene.MODE.SELL:
        this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_SELL_TITLE"));
        this.TxtZenyPattern3.SetText(Consts.Lookup("GEAR_0052_SELL_LABEL"));
        this.scrollPanel.bottomAnchor.absolute = 99;
        this.scrollBarWidget.topAnchor.absolute = -13;
        this.scrollBarWidget.bottomAnchor.absolute = 140;
        this.NumProsession3.SetTextLocalize(Consts.Lookup("GEAR_0052_POSSESSION", (IDictionary) new Hashtable()
        {
          {
            (object) "now",
            (object) num.ToString()
          },
          {
            (object) "max",
            (object) this.player.max_items.ToString()
          }
        }));
        break;
      case Bugu0052Scene.MODE.DRILLING_BASE:
        this.TxtTitle.SetTextLocalize(Consts.Lookup("GEAR_0052_DRILLING_BASE_TITLE"));
        this.scrollPanel.bottomAnchor.absolute = 0;
        this.scrollBarWidget.topAnchor.absolute = -8;
        this.scrollBarWidget.bottomAnchor.absolute = 0;
        this.SetPosessionText(num, this.player.max_items);
        break;
      case Bugu0052Scene.MODE.DRILLING_MATERIAL:
      case Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL:
        this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_DRILLING_MATERIAL_TITLE"));
        this.TxtZenyPattern3.SetTextLocalize(Consts.Lookup("GEAR_0052_DRILLING_MATERIAL_ZENY_LABEL"));
        this.TxtProsession3.SetTextLocalize(Consts.Lookup("GEAR_0052_DRILLING_MATERIAL_PROSESSION_LABEL"));
        this.scrollPanel.bottomAnchor.absolute = 99;
        this.scrollBarWidget.topAnchor.absolute = -13;
        this.scrollBarWidget.bottomAnchor.absolute = 140;
        this.NumProsession3.SetTextLocalize(0);
        this.NumSelectedCount3.SetTextLocalize(0);
        this.NumSpendZenie3.SetTextLocalize(0);
        break;
      default:
        Debug.LogError((object) ("Select mode error " + (object) this.mode));
        break;
    }
  }

  protected virtual void SetPosessionText(int value, int max)
  {
    this.NumProsession1.SetTextLocalize(Consts.Lookup("GEAR_0052_POSSESSION", (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) value
      },
      {
        (object) nameof (max),
        (object) max
      }
    }));
  }

  private void ModeChange()
  {
    this.ModeOverView.gameObject.SetActive(false);
    this.ModeComposite.gameObject.SetActive(false);
    this.ModeRepair.gameObject.SetActive(false);
    this.ModePoweredRepair.gameObject.SetActive(false);
    this.ModeSell.gameObject.SetActive(false);
    switch (this.mode)
    {
      case Bugu0052Scene.MODE.OVERVIEW:
        this.ModeOverView.gameObject.SetActive(true);
        break;
      case Bugu0052Scene.MODE.COMPOSITE:
        this.ModeComposite.gameObject.SetActive(true);
        break;
      case Bugu0052Scene.MODE.PAKUPAKU_BASE:
        break;
      case Bugu0052Scene.MODE.PAKUPAKU_MATERIAL:
        this.ModeComposite.gameObject.SetActive(true);
        break;
      case Bugu0052Scene.MODE.REPAIR:
        if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED)
        {
          this.ModePoweredRepair.gameObject.SetActive(true);
          break;
        }
        this.ModeRepair.gameObject.SetActive(true);
        break;
      case Bugu0052Scene.MODE.SELL:
        this.ModeSell.gameObject.SetActive(true);
        break;
      case Bugu0052Scene.MODE.DRILLING_BASE:
        break;
      case Bugu0052Scene.MODE.DRILLING_MATERIAL:
      case Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL:
        this.ModeSell.gameObject.SetActive(true);
        break;
      default:
        Debug.LogError((object) ("Select Mode Error " + (object) this.mode));
        break;
    }
  }

  public void RepairModeChange()
  {
    if (this.IsPush)
      return;
    float duration = this.RepairMoneyButton.duration;
    if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NONE)
      return;
    this.RepairMoneyButton.duration = 0.0f;
    this.IbtnNo();
    this.RepairMoneyButton.duration = duration;
    this.ModeRepair.SetActive(false);
    this.ModePoweredRepair.SetActive(false);
    if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL)
    {
      this.repair_mode = Bugu0052Menu.REPAIR_MODE.POWERED;
      this.ModePoweredRepair.SetActive(true);
      this.InitRepair(false, false);
    }
    else if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED)
    {
      this.repair_mode = Bugu0052Menu.REPAIR_MODE.NORMAL;
      this.ModeRepair.SetActive(true);
      this.InitRepair(false, false, true);
    }
    this.CreateStatusItemIcon();
  }

  private void Sort()
  {
    if (this.IsPush)
      return;
    ((IEnumerable<GameObject>) this.SortLabel).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
    this.SortLabel[(int) this.sortLabel].SetActive(true);
    this.InventoryItems = this.InventoryItems.SortBy(this.sortLabel).ToList<InventoryItem>();
    this.scroll.Reset();
    for (int index = 0; index < Mathf.Min(this.iconMaxValue, this.allItemIcon.Count); ++index)
    {
      this.scroll.Add(((Component) this.allItemIcon[index]).gameObject, this.iconWidth, this.iconHeight);
      ((Component) this.allItemIcon[index]).gameObject.SetActive(true);
    }
    this.scroll.CreateScrollPoint(this.iconHeight, this.InventoryItems.Count);
    this.scroll.ResolvePosition();
  }

  private bool isActiveDrillingMaterial(PlayerItem item)
  {
    return !(this.targetGear == (PlayerItem) null) && item.gear.kind.Enum == this.targetGear.gear.kind.Enum;
  }

  private bool isActiveSpecialDrillingMaterial(PlayerItem item)
  {
    return !(this.targetGear == (PlayerItem) null) && item.gear.group_id == this.targetGear.gear.group_id;
  }

  public void GetItem(PlayerItem item, InventoryItem selectItem = null)
  {
    if (item != (PlayerItem) null)
      selectItem = this.InventoryItems.FindByItem(item);
    if (selectItem.select)
    {
      if (item.supply != null)
      {
        this.StartCoroutine(this.CountSelectPopUp(item));
      }
      else
      {
        selectItem.select = false;
        selectItem.index = 0;
        if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.POWERED)
          this.InitRepair(false, false);
      }
      this.IconsUpdate();
    }
    else if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      if (this.ItemList.Count >= this.COMPOSITE_MAXSELECT)
        return;
      selectItem.select = true;
      selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
      this.IconsUpdate();
    }
    else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL)
    {
      if (this.ItemList.Count >= 5 || !this.isActiveDrillingMaterial(item) || item.favorite || item.ForBattle || item.broken)
        return;
      selectItem.select = true;
      selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
      this.IconsUpdate();
    }
    else if (this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
    {
      if (this.ItemList.Count >= 1 || !this.isActiveSpecialDrillingMaterial(item) || item.favorite || item.ForBattle || item.broken)
        return;
      selectItem.select = true;
      selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
      this.IconsUpdate();
    }
    else if (this.mode == Bugu0052Scene.MODE.REPAIR)
    {
      if (this.repair_mode == Bugu0052Menu.REPAIR_MODE.NORMAL && this.ItemList.Count < 5)
      {
        selectItem.select = true;
        selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
        this.IconsUpdate();
      }
      if (this.repair_mode != Bugu0052Menu.REPAIR_MODE.POWERED || this.ItemList.Count >= 1)
        return;
      selectItem.select = true;
      selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
      this.IconsUpdate();
      this.bedCount = 0;
      this.RepairButtonCondition(true, false);
      this.TxtGearRepairProbability.SetTextLocalize(((int) Math.Round((double) this.ItemList[0].Item.gear.repair_success_ratio * 100.0)).ToString() + "%");
      this.TxtRepairGearName.SetTextLocalize(this.ItemList[0].Item.name);
    }
    else
    {
      if (this.ItemList.Count >= 99)
        return;
      if (item.supply != null)
      {
        this.StartCoroutine(this.CountSelectPopUp(item));
      }
      else
      {
        selectItem.select = true;
        selectItem.index = this.ItemList.Count<InventoryItem>() + 1;
      }
      this.IconsUpdate();
    }
  }

  public void GrayYesButton()
  {
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      if (this.cost < this.player.money && (this.ItemList.Count >= 2 && this.mode == Bugu0052Scene.MODE.COMPOSITE || this.ItemList.Count >= 1 && this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL))
      {
        if (Object.op_Inequality((Object) this.CompositeYesButton, (Object) null))
        {
          this.CompositeYesButton.GetComponent<UISprite>().color = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
          ((Collider) this.CompositeYesButton.GetComponent<BoxCollider>()).enabled = true;
        }
      }
      else if (Object.op_Inequality((Object) this.CompositeYesButton, (Object) null))
      {
        this.CompositeYesButton.GetComponent<UISprite>().color = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
        ((Collider) this.CompositeYesButton.GetComponent<BoxCollider>()).enabled = false;
      }
    }
    if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL || this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
    {
      if (this.cost < this.player.money && this.ItemList.Count >= 1)
      {
        if (!Object.op_Inequality((Object) this.SellYesButton, (Object) null))
          return;
        this.SellYesButton.isEnabled = true;
      }
      else
      {
        if (!Object.op_Inequality((Object) this.SellYesButton, (Object) null))
          return;
        this.SellYesButton.isEnabled = false;
      }
    }
    else if (this.mode == Bugu0052Scene.MODE.REPAIR)
    {
      if (this.cost < this.player.money && this.ItemList.Count != 0)
      {
        if (!Object.op_Inequality((Object) this.RepairMoneyButton, (Object) null))
          return;
        this.RepairMoneyButton.isEnabled = true;
      }
      else
      {
        if (!Object.op_Inequality((Object) this.RepairMoneyButton, (Object) null))
          return;
        this.RepairMoneyButton.isEnabled = false;
      }
    }
    else if (this.ItemList.Count != 0)
    {
      if (!Object.op_Inequality((Object) this.SellYesButton, (Object) null))
        return;
      this.SellYesButton.isEnabled = true;
    }
    else
    {
      if (!Object.op_Inequality((Object) this.SellYesButton, (Object) null))
        return;
      this.SellYesButton.isEnabled = false;
    }
  }

  public void CostCalculation()
  {
    int result = 0;
    if (this.ItemList.Count == 0)
    {
      this.cost = 0;
      this.bedCount = 0;
    }
    else
    {
      this.cost = 0;
      switch (this.mode)
      {
        case Bugu0052Scene.MODE.COMPOSITE:
          int total_item_level = 0;
          int total_item_rarity = 0;
          int cnt_use_gears = 0;
          this.ItemList.ForEach((Action<InventoryItem>) (item =>
          {
            if (item.Item.gear == null)
              return;
            total_item_level += item.Item.gear.compose_level;
            total_item_rarity += item.Item.gear.rarity.index;
            ++cnt_use_gears;
          }));
          if (cnt_use_gears < 1)
            cnt_use_gears = 1;
          int index = total_item_rarity / cnt_use_gears - 1;
          if (index < 0)
            index = 0;
          this.cost = (int) ((double) (total_item_level * 50) * (double) GearRarity.ComposeRatio(index));
          break;
        case Bugu0052Scene.MODE.PAKUPAKU_MATERIAL:
          this.cost = Bugu0058Menu.CalcSpendZeny(this.ItemList.Select<InventoryItem, PlayerItem>((Func<InventoryItem, PlayerItem>) (x => x.Item)).ToList<PlayerItem>());
          break;
        case Bugu0052Scene.MODE.REPAIR:
          int repairCost = 0;
          this.ItemList.ForEach((Action<InventoryItem>) (item => repairCost += item.Item.gear.repair_price * (item.Item.gear_level + 1) * (this.bedCount + 1)));
          this.cost += repairCost;
          break;
        case Bugu0052Scene.MODE.SELL:
          float[] gear_rank_revision = new float[7]
          {
            1f,
            1f,
            2f,
            3f,
            4f,
            5f,
            6f
          };
          this.ItemList.ForEach((Action<InventoryItem>) (item =>
          {
            if (!item.select)
              return;
            if (item.Item.gear != null)
            {
              if (!item.Item.broken)
                this.cost += (int) ((double) item.Item.gear.sell_price * (double) gear_rank_revision[item.Item.gear_level]);
              else
                ++this.cost;
            }
            else
            {
              if (item.Item.supply == null)
                return;
              this.cost += item.Item.supply.sell_price * item.selectCount;
            }
          }));
          break;
        case Bugu0052Scene.MODE.DRILLING_MATERIAL:
          this.cost = (int) ((double) this.ItemList.Sum<InventoryItem>((Func<InventoryItem, int>) (x => x.Item.gear.compose_level)) * 50.0 * ((double) this.ItemList.Sum<InventoryItem>((Func<InventoryItem, float>) (x => x.Item.gear.rarity.compose_ratio)) / (double) this.ItemList.Count));
          result = this.ItemList.Sum<InventoryItem>((Func<InventoryItem, int>) (x => GearDrilling.GetGearDrilling(x.Item.gear_level, x.Item.gear.rarity.index)));
          break;
        case Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL:
          GearSpecialDrillingCost specialDrillingCost1 = (GearSpecialDrillingCost) null;
          foreach (GearSpecialDrillingCost specialDrillingCost2 in (IEnumerable<GearSpecialDrillingCost>) ((IEnumerable<GearSpecialDrillingCost>) MasterData.GearSpecialDrillingCostList).OrderBy<GearSpecialDrillingCost, int>((Func<GearSpecialDrillingCost, int>) (x => x.rarity != null ? 0 : 1)))
          {
            if (specialDrillingCost2.level == this.targetGear.gear_level && (specialDrillingCost2.rarity == null || specialDrillingCost2.rarity != null && specialDrillingCost2.rarity.index == this.targetGear.gear.rarity.index))
            {
              specialDrillingCost1 = specialDrillingCost2;
              break;
            }
          }
          this.cost = specialDrillingCost1 == null ? ((IEnumerable<GearSpecialDrillingCost>) MasterData.GearSpecialDrillingCostList).OrderByDescending<GearSpecialDrillingCost, int>((Func<GearSpecialDrillingCost, int>) (x => x.price)).First<GearSpecialDrillingCost>().price : specialDrillingCost1.price;
          break;
      }
    }
    this.SetTextLabel(this.ItemList.Count, this.cost, result);
  }

  public virtual void ChangeDetailScene(PlayerItem playerItem)
  {
    if (playerItem.gear != null)
    {
      if (!playerItem.gear.kind.isEquip)
        Bugu00561Scene.changeScene(true, playerItem);
      else
        Unit00443Scene.changeScene(true, playerItem);
    }
    else
      Bugu00561Scene.changeScene(true, playerItem);
  }

  public void ChangeBuguPakuPakuBase(PlayerItem playerItem)
  {
    Bugu0058Scene.changeScene(true, playerItem);
  }

  public void ChangeBuguDrillingBase(PlayerItem playerItem)
  {
    Bugu0059Scene.changeScene(true, playerItem);
  }

  public void RepairBedAdd() => this.RepairBedAction(1);

  public void RepairBedReduce() => this.RepairBedAction(-1);

  private void RepairBedAction(int val)
  {
    this.RepairButtonCondition(false, false);
    this.bedCount += val;
    int num1 = (int) Math.Round((double) this.ItemList[0].Item.gear.repair_success_ratio * 100.0);
    int num2 = this.bedCount * 10 + num1;
    bool addButton;
    bool reduceButton;
    if (100 <= num2)
    {
      this.bedCount -= val;
      num2 = 90;
      addButton = false;
      reduceButton = true;
    }
    else if (90 <= num2)
    {
      num2 = 90;
      addButton = false;
      reduceButton = true;
    }
    else if (num1 >= num2 || this.bedCount == 0)
    {
      this.bedCount = 0;
      num2 = num1;
      addButton = true;
      reduceButton = false;
    }
    else
    {
      addButton = true;
      reduceButton = true;
    }
    this.TxtGearRepairProbability.SetTextLocalize(num2.ToString() + "%");
    this.RepairPoweredCost();
    this.RepairButtonCondition(addButton, reduceButton);
  }

  private void RepairPoweredCost()
  {
    int repairCost = 0;
    this.ItemList.ForEach((Action<InventoryItem>) (item => repairCost += item.Item.gear.repair_price * (item.Item.gear_level + 1) * (this.bedCount + 1)));
    this.cost = repairCost;
    this.SetTextLabel(this.ItemList.Count, this.cost);
  }

  private void SetTextLabel(int selectNumber, int cost, int result = 0)
  {
    if (this.mode == Bugu0052Scene.MODE.OVERVIEW)
      return;
    UILabel label = (UILabel) null;
    string str = string.Empty;
    UILabel uiLabel1;
    UILabel uiLabel2;
    if (cost > this.player.money)
    {
      if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
      {
        uiLabel1 = this.NumSelectedCount2;
        uiLabel2 = this.NumSpendZenie2;
        this.ChangeTextColor(selectNumber, this.NumSelectedCount2, this.NumSpendZenie2, true);
      }
      else if (this.mode == Bugu0052Scene.MODE.REPAIR)
      {
        uiLabel1 = (UILabel) null;
        uiLabel2 = this.repair_mode != Bugu0052Menu.REPAIR_MODE.NORMAL ? this.TxtZenyRepairPowered : this.TxtZenyRepair;
        this.ChangeTextColor(selectNumber, uiLabel1, uiLabel2, true);
      }
      else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL || this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
      {
        uiLabel1 = this.NumSelectedCount3;
        uiLabel2 = this.NumSpendZenie3;
        label = this.NumProsession3;
        str = "{0}/{1}".F((object) selectNumber, (object) (this.mode != Bugu0052Scene.MODE.DRILLING_MATERIAL ? 1 : 5));
        this.ChangeTextColor(selectNumber, this.NumSelectedCount3, this.NumSpendZenie3, true);
      }
      else
      {
        uiLabel1 = this.NumSelectedCount3;
        uiLabel2 = this.NumSpendZenie3;
        this.ChangeTextColor(selectNumber, this.NumSelectedCount3, this.NumSpendZenie3, false);
      }
    }
    else if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      uiLabel1 = this.NumSelectedCount2;
      uiLabel2 = this.NumSpendZenie2;
      this.ChangeTextColor(selectNumber, this.NumSelectedCount2, this.NumSpendZenie2, false);
    }
    else if (this.mode == Bugu0052Scene.MODE.REPAIR)
    {
      uiLabel1 = (UILabel) null;
      uiLabel2 = this.repair_mode != Bugu0052Menu.REPAIR_MODE.NORMAL ? this.TxtZenyRepairPowered : this.TxtZenyRepair;
      this.ChangeTextColor(selectNumber, uiLabel1, uiLabel2, false);
    }
    else if (this.mode == Bugu0052Scene.MODE.DRILLING_MATERIAL || this.mode == Bugu0052Scene.MODE.SPECIAL_DRILLING_MATERIAL)
    {
      uiLabel1 = this.NumSelectedCount3;
      uiLabel2 = this.NumSpendZenie3;
      label = this.NumProsession3;
      str = "{0}/{1}".F((object) selectNumber, (object) (this.mode != Bugu0052Scene.MODE.DRILLING_MATERIAL ? 1 : 5));
      this.ChangeTextColor(selectNumber, this.NumSelectedCount3, this.NumSpendZenie3, false);
    }
    else
    {
      uiLabel1 = this.NumSelectedCount3;
      uiLabel2 = this.NumSpendZenie3;
      this.ChangeTextColor(selectNumber, this.NumSelectedCount3, this.NumSpendZenie3, false);
    }
    if (Object.op_Inequality((Object) uiLabel1, (Object) null))
      uiLabel1.SetTextLocalize(!string.IsNullOrEmpty(str) ? str : selectNumber.ToString());
    if (Object.op_Inequality((Object) label, (Object) null))
      label.SetTextLocalize(result);
    uiLabel2.SetTextLocalize(cost);
  }

  private void ChangeTextColor(
    int selectNumber,
    UILabel selectLabel,
    UILabel moneyLabel,
    bool costOverFlag)
  {
    if (Object.op_Inequality((Object) selectLabel, (Object) null))
    {
      if (selectNumber == 99 || this.mode == Bugu0052Scene.MODE.COMPOSITE && selectNumber == this.COMPOSITE_MAXSELECT)
        selectLabel.color = Color.red;
      else
        selectLabel.color = Color.white;
    }
    if (costOverFlag)
      moneyLabel.color = Color.red;
    else
      moneyLabel.color = Color.white;
  }

  [DebuggerHidden]
  private IEnumerator NotEnoughMoneyPopUp()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0052Menu.\u003CNotEnoughMoneyPopUp\u003Ec__Iterator306 popUpCIterator306 = new Bugu0052Menu.\u003CNotEnoughMoneyPopUp\u003Ec__Iterator306();
    return (IEnumerator) popUpCIterator306;
  }

  [DebuggerHidden]
  private IEnumerator CountSelectPopUp(PlayerItem supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CCountSelectPopUp\u003Ec__Iterator307()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellCheckPopUp(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CSellCheckPopUp\u003Ec__Iterator308()
    {
      action = action,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellWarningPopUp(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CSellWarningPopUp\u003Ec__Iterator309()
    {
      action = action,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellResultPopUp(long resultMoney)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CSellResultPopUp\u003Ec__Iterator30A()
    {
      resultMoney = resultMoney,
      \u003C\u0024\u003EresultMoney = resultMoney,
      \u003C\u003Ef__this = this
    };
  }

  public void SetSuppylCount(PlayerItem player, int count)
  {
    InventoryItem byItem = this.InventoryItems.FindByItem(player);
    if (count != 0)
    {
      byItem.select = true;
      byItem.index = this.ItemList.Count<InventoryItem>() + 1;
    }
    else
    {
      byItem.select = false;
      byItem.index = 0;
      this.allItemIcon.Where<ItemIcon>((Func<ItemIcon, bool>) (x => x.PlayerItem == player)).ForEach<ItemIcon>((Action<ItemIcon>) (x => x.SelectQuantity = false));
    }
    byItem.selectCount = count;
    this.IconsUpdate();
  }

  public void CallSellAPI() => this.StartCoroutine(this.SellAPI());

  [DebuggerHidden]
  private IEnumerator SellAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CSellAPI\u003Ec__Iterator30B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RepairAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CRepairAPI\u003Ec__Iterator30C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RepairPoweredAPI(bool Medal_Repair)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CRepairPoweredAPI\u003Ec__Iterator30D()
    {
      Medal_Repair = Medal_Repair,
      \u003C\u0024\u003EMedal_Repair = Medal_Repair,
      \u003C\u003Ef__this = this
    };
  }

  private void RepairUpdate(PlayerItem[] result)
  {
    List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    foreach (PlayerItem playerItem in ((IEnumerable<PlayerItem>) result).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.broken)))
    {
      InventoryItem inventoryItem = new InventoryItem(playerItem);
      inventoryItemList.Add(inventoryItem);
    }
    int num = 0;
    foreach (InventoryItem inventoryItem1 in inventoryItemList)
    {
      foreach (InventoryItem inventoryItem2 in this.ItemList)
      {
        if (inventoryItem2.Item == inventoryItem1.Item)
          ++num;
      }
    }
    foreach (InventoryItem inventoryItem3 in inventoryItemList)
    {
      foreach (InventoryItem inventoryItem4 in this.ItemList)
      {
        if (inventoryItem4.Item == inventoryItem3.Item)
        {
          inventoryItem3.select = inventoryItem4.select;
          inventoryItem3.index = inventoryItem4.index;
        }
      }
    }
    this.InventoryItems = inventoryItemList;
  }

  public void onEndScene(Bugu0052Scene scene)
  {
    if ((scene.sceneMode == Bugu0052Scene.MODE.COMPOSITE || scene.sceneMode == Bugu0052Scene.MODE.REPAIR) && this.isInit)
    {
      this.isInit = false;
      scene.clearInitFlg();
    }
    Singleton<PopupManager>.GetInstance().closeAll();
    this.resultParam.InventoryItemBack = this.InventoryItems;
  }

  private void ScrollIconUpdate(int inventoryItemsIndex, int count)
  {
    if (ItemIcon.IsCache(this.InventoryItems[inventoryItemsIndex].Item))
      this.CreateItemIconCache(inventoryItemsIndex, count);
    else
      this.StartCoroutine(this.CreateItemIcon(inventoryItemsIndex, count));
  }

  private void ScrollUpdate()
  {
    if ((!this.isInitialize || this.InventoryItems.Count <= this.iconScreenValue) && !this.isUpdateIcon)
      return;
    int num1 = this.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.InventoryItems.Count - this.iconScreenValue - 1) / this.iconColumnValue * this.iconHeight);
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
        int? nullable = this.InventoryItems.FirstIndexOrNull<InventoryItem>((Func<InventoryItem, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
        if ((double) num5 > (double) num1)
        {
          item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
          if (nullable.HasValue && nullable.Value + this.iconMaxValue < (this.InventoryItems.Count + 4) / 5 * 5)
          {
            if (nullable.Value + this.iconMaxValue >= this.InventoryItems.Count)
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

  private void ResetItemIcon(int index)
  {
    ((Component) this.allItemIcon[index]).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIcon(int info_index, int item_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CCreateItemIcon\u003Ec__Iterator30E()
    {
      item_index = item_index,
      info_index = info_index,
      \u003C\u0024\u003Eitem_index = item_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateItemIconCache(int info_index, int item_index)
  {
    ItemIcon itemIcon = this.allItemIcon[item_index];
    this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (a => Object.op_Equality((Object) a.icon, (Object) itemIcon))).ForEach<InventoryItem>((Action<InventoryItem>) (b => b.icon = (ItemIcon) null));
    this.InventoryItems[info_index].icon = itemIcon;
    itemIcon.InitByPlayerItemCache(this.InventoryItems[info_index].Item);
    this.CreateItemIconSharing(info_index, item_index);
  }

  private void CreateItemIconSharing(int info_index, int item_index)
  {
    ItemIcon itemIcon = this.allItemIcon[item_index];
    InventoryItem inventoryItem = this.InventoryItems[info_index];
    itemIcon.onClick = this.mode != Bugu0052Scene.MODE.PAKUPAKU_BASE ? (this.mode != Bugu0052Scene.MODE.DRILLING_BASE ? (this.mode == Bugu0052Scene.MODE.OVERVIEW ? (Action<ItemIcon>) (playeritem => this.ChangeDetailScene(playeritem.PlayerItem)) : (Action<ItemIcon>) (playeritem => this.GetItem(playeritem.PlayerItem))) : (Action<ItemIcon>) (playeritem => this.ChangeBuguDrillingBase(playeritem.PlayerItem))) : (Action<ItemIcon>) (playeritem => this.ChangeBuguPakuPakuBase(playeritem.PlayerItem));
    if (inventoryItem.Item.entity_type == MasterDataTable.CommonRewardType.supply)
    {
      itemIcon.QuantitySupply = true;
      itemIcon.EnableQuantity(inventoryItem.Item.quantity);
    }
    else
      itemIcon.QuantitySupply = false;
    itemIcon.ForBattle = inventoryItem.Item.ForBattle;
    if (this.mode == Bugu0052Scene.MODE.PAKUPAKU_BASE && inventoryItem.Item.broken)
    {
      itemIcon.onClick = (Action<ItemIcon>) (_ => { });
      inventoryItem.Gray = true;
    }
    if (this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.SELL || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL)
    {
      if ((this.mode == Bugu0052Scene.MODE.COMPOSITE || this.mode == Bugu0052Scene.MODE.PAKUPAKU_MATERIAL) && inventoryItem.Item.broken)
      {
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
        inventoryItem.Gray = true;
      }
      if (inventoryItem.Item.ForBattle)
      {
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
        inventoryItem.Gray = true;
      }
      else if (inventoryItem.Item.favorite)
      {
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
        inventoryItem.Gray = true;
      }
    }
    itemIcon.Gray = inventoryItem.Gray;
    if (inventoryItem.select)
    {
      if (inventoryItem.Item.supply != null)
        itemIcon.SelectedQuantity(inventoryItem.selectCount);
      if (this.mode == Bugu0052Scene.MODE.SELL)
        itemIcon.SelectByCheckIcon();
      else
        itemIcon.Select(inventoryItem.index - 1);
    }
    else if (this.mode == Bugu0052Scene.MODE.SELL)
      itemIcon.DeselectByCheckIcon();
    else
      itemIcon.Deselect();
    itemIcon.EnableLongPressEvent();
  }

  [DebuggerHidden]
  private IEnumerator LoadObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0052Menu.\u003CLoadObject\u003Ec__Iterator30F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class ResultParam
  {
    public List<InventoryItem> InventoryItemBack = new List<InventoryItem>();
  }

  protected enum REPAIR_MODE
  {
    NONE = 1,
    NORMAL = 2,
    POWERED = 3,
  }
}
