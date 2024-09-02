﻿// Decompiled with JetBrains decompiler
// Type: ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ItemIcon : IconPrefabBase
{
  public static readonly int Width = 123;
  public static readonly int Height = 147;
  public static readonly int ColumnValue = 5;
  public static readonly int RowValue = 8;
  public static readonly int RowScreenValue = 5;
  public static readonly int ScreenValue = ItemIcon.ColumnValue * ItemIcon.RowScreenValue;
  public static readonly int MaxValue = ItemIcon.ColumnValue * ItemIcon.RowValue;
  private static readonly int SelectedIndexFontSize = 22;
  private static readonly int ManaSeedsDurabilityFontSize = 28;
  private static Dictionary<int, Sprite> gearCache = new Dictionary<int, Sprite>();
  private static Dictionary<int, Sprite> supplyCache = new Dictionary<int, Sprite>();
  private PlayerItem playerItem;
  [SerializeField]
  private bool longTapFlag;
  public GameObject removeButton;
  public Sprite[] backSprite;
  public Sprite[] backSpriteSpecificationOfEquipmentUnits;
  public Sprite nonBackSprite;
  public Sprite[] raritySprite;
  public Sprite nonTypeSprite;
  public Sprite[] rankSprite;
  public Sprite[] selectNumSprite;
  public Sprite[] numberSprite;
  public Sprite[] gearUnlimitSprite;
  public Sprite[] limitRankSprite;
  public bool gray;
  public ItemIcon.Gear gear;
  public ItemIcon.Supply supply;
  public GameObject quantity;
  public GameObject[] leftNum;
  public GameObject[] rightNum;
  public GameObject selectQuantity;
  public GameObject[] selectedLeftNum;
  public GameObject[] selectedRightNum;
  public GameObject checkmark;
  private bool selected;
  private Action<ItemIcon> onClick_;
  private Action<ItemIcon> longPress_;
  [SerializeField]
  private ItemIcon.BottomMode bottomMode = ItemIcon.BottomMode.Visible;

  public bool Gray
  {
    get => this.gray;
    set
    {
      if (this.gray == value)
        return;
      this.gray = value;
      NGTween.playTweens(((Component) this).GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !value);
    }
  }

  public bool EnabledGear => this.gear.root.activeSelf;

  public bool EnabledSupply => this.supply.root.activeSelf;

  public void SetModeGear()
  {
    this.gear.root.SetActive(true);
    this.supply.root.SetActive(false);
  }

  public void SetModeSupply()
  {
    this.gear.root.SetActive(false);
    this.supply.root.SetActive(true);
  }

  public bool NewItem
  {
    get
    {
      return this.gear.root.activeSelf ? this.gear.newGear.activeSelf : this.supply.newSupply.activeSelf;
    }
    set
    {
      if (this.gear.root.activeSelf)
        this.gear.newGear.SetActive(value);
      else
        this.supply.newSupply.SetActive(value);
    }
  }

  public ItemIcon.BottomMode BottomModeValue
  {
    get => this.bottomMode;
    set
    {
      this.gear.bottom.SetActive(value == ItemIcon.BottomMode.Visible);
      this.supply.bottom.SetActive(value == ItemIcon.BottomMode.Visible);
      this.bottomMode = value;
    }
  }

  public bool ForBattle
  {
    get => this.EnabledGear ? this.gear.forbattle.activeSelf : this.supply.forbattle.activeSelf;
    set
    {
      if (this.EnabledGear)
        this.gear.forbattle.SetActive(value);
      else
        this.supply.forbattle.SetActive(value);
    }
  }

  public bool Favorite
  {
    get => this.EnabledGear ? this.gear.forbattle.activeSelf : this.supply.forbattle.activeSelf;
    set
    {
      if (this.EnabledGear)
        this.gear.favorite.SetActive(value);
      else
        this.supply.favorite.SetActive(value);
    }
  }

  public bool Broken
  {
    get => this.EnabledGear ? this.gear.forbattle.activeSelf : this.supply.forbattle.activeSelf;
    set
    {
      if (!this.EnabledGear)
        return;
      this.gear.broken.SetActive(value);
    }
  }

  public bool QuantitySupply
  {
    get => this.quantity.activeSelf;
    set => this.quantity.SetActive(value);
  }

  public bool DefaltGearText
  {
    get => this.gear.defaultGearTxt.activeSelf;
    set => this.gear.defaultGearTxt.SetActive(value);
  }

  public bool SelectQuantity
  {
    get => this.selectQuantity.activeSelf;
    set => this.selectQuantity.SetActive(value);
  }

  [DebuggerHidden]
  public IEnumerator InitByPlayerItem(PlayerItem playerItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CInitByPlayerItem\u003Ec__IteratorAA5()
    {
      playerItem = playerItem,
      \u003C\u0024\u003EplayerItem = playerItem,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitBySupplyItem(SupplyItem supplyItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CInitBySupplyItem\u003Ec__IteratorAA6()
    {
      supplyItem = supplyItem,
      \u003C\u0024\u003EsupplyItem = supplyItem,
      \u003C\u003Ef__this = this
    };
  }

  public void InitByRemoveButton()
  {
    this.gear.root.SetActive(false);
    this.supply.root.SetActive(false);
    this.gear.button.onLongPress.Clear();
    this.supply.button.onLongPress.Clear();
    this.removeButton.SetActive(true);
  }

  public void initManaseedsInfo(PlayerItem playerItem)
  {
    if (playerItem.gear.disappearance_num.HasValue)
    {
      this.gear.manaseedsBreakageRate.SetActive(false);
      this.gear.manaseedsDurabilityCount.SetActive(false);
      int accessoryRemainingAmount = playerItem.gear.disappearance_num.Value;
      GameObject gameObject = (GameObject) null;
      int num = 0;
      switch (playerItem.gear.disappearance_type_GearDisappearanceType)
      {
        case 1:
          this.gear.manaseedsDurabilityCount.SetActive(true);
          this.gear.manaseedsDurabilityCount_1.SetActive(false);
          this.gear.manaseedsDurabilityCount_10.SetActive(false);
          this.gear.manaseedsDurabilityCount_100.SetActive(false);
          accessoryRemainingAmount = playerItem.gear_accessory_remaining_amount;
          num = accessoryRemainingAmount.ToString().Length;
          switch (num)
          {
            case 1:
              gameObject = this.gear.manaseedsDurabilityCount_1;
              break;
            case 2:
              gameObject = this.gear.manaseedsDurabilityCount_10;
              break;
            case 3:
              gameObject = this.gear.manaseedsDurabilityCount_100;
              break;
          }
          break;
        case 2:
          this.gear.manaseedsBreakageRate.SetActive(true);
          num = accessoryRemainingAmount.ToString().Length;
          switch (num)
          {
            case 1:
              gameObject = this.gear.manaseedsBreakageRate_1;
              break;
            case 2:
              gameObject = this.gear.manaseedsBreakageRate_10;
              break;
          }
          break;
      }
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      gameObject.SetActive(true);
      string[] strArray = new string[3]
      {
        "slc_num_digit_ones",
        "slc_num_digit_tens",
        "slc_num_digit_hundreds"
      };
      for (int index = 0; index < num; ++index)
      {
        Transform child = gameObject.transform.FindChild(strArray[index]);
        int result;
        if (Object.op_Inequality((Object) child, (Object) null) && int.TryParse(accessoryRemainingAmount.ToString().Substring(num - 1 - index, 1), out result))
        {
          UI2DSprite component = ((Component) child).GetComponent<UI2DSprite>();
          UI2DSprite ui2Dsprite = component;
          Rect textureRect = this.numberSprite[result].textureRect;
          int width = (int) ((Rect) ref textureRect).width;
          int durabilityFontSize = ItemIcon.ManaSeedsDurabilityFontSize;
          ui2Dsprite.SetDimensions(width, durabilityFontSize);
          component.sprite2D = this.numberSprite[result];
        }
      }
    }
    else
    {
      this.gear.manaseedsBreakageRate.SetActive(false);
      this.gear.manaseedsDurabilityCount.SetActive(false);
    }
  }

  [DebuggerHidden]
  public IEnumerator InitByGear(GearGear gear, CommonElement element = CommonElement.none)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CInitByGear\u003Ec__IteratorAA7()
    {
      gear = gear,
      element = element,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Eelement = element,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitForEquipGear()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CInitForEquipGear\u003Ec__IteratorAA8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitBySupply(SupplySupply supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CInitBySupply\u003Ec__IteratorAA9()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  public void InitByPlayerItemCache(PlayerItem playerItem)
  {
    this.removeButton.SetActive(false);
    if (playerItem.gear != null)
    {
      this.InitByGearCache(playerItem);
      if (playerItem.gear.hasSpecificationOfEquipmentUnits)
        this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.backSpriteSpecificationOfEquipmentUnits[playerItem.gear.customize_flag];
      else
        this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.backSprite[playerItem.gear.customize_flag];
      this.gear.favorite.SetActive(playerItem.favorite);
      if (playerItem.gear.kind.isEquip && playerItem.gear.disappearance_type_GearDisappearanceType == 0)
      {
        this.gear.rank.SetActive(true);
        if (playerItem.gear_level == playerItem.gear_level_limit)
          this.gear.rank.GetComponent<UI2DSprite>().sprite2D = this.limitRankSprite[playerItem.gear_level - 1];
        else
          this.gear.rank.GetComponent<UI2DSprite>().sprite2D = this.rankSprite[playerItem.gear_level - 1];
        if (playerItem.gear_level_unlimit > 0)
        {
          this.gear.unlimit.SetActive(true);
          this.gear.unlimit.GetComponent<UI2DSprite>().sprite2D = this.gearUnlimitSprite[playerItem.gear_level_unlimit - 1];
        }
        else
          this.gear.unlimit.SetActive(false);
      }
      else
      {
        this.gear.rank.SetActive(false);
        this.gear.unlimit.SetActive(false);
      }
      this.gear.broken.SetActive(playerItem.broken);
      this.initManaseedsInfo(playerItem);
    }
    else
    {
      this.InitBySupplyCache(playerItem.supply);
      this.EnableQuantity(playerItem.quantity);
      this.supply.favorite.SetActive(playerItem.favorite);
    }
    this.onClick = (Action<ItemIcon>) null;
    this.playerItem = playerItem;
  }

  public void InitBySupplyItemCache(SupplyItem supplyItem)
  {
    this.removeButton.SetActive(false);
    this.InitBySupplyCache(supplyItem.Supply);
    this.EnableQuantity(supplyItem.ItemQuantity);
    this.PlayerItem.entity_id = supplyItem.Supply.ID;
    this.supply.name.GetComponent<UILabel>().SetText(supplyItem.Supply.name);
    this.onClick = (Action<ItemIcon>) null;
  }

  public void InitByGearCache(PlayerItem playerItem)
  {
    GearGear gear = playerItem.gear;
    if (gear != null)
    {
      this.gear.root.SetActive(true);
      this.supply.root.SetActive(false);
      this.gear.icon.sprite2D = ItemIcon.gearCache[gear.ID];
      UI2DSprite component = this.gear.star.GetComponent<UI2DSprite>();
      Rect textureRect1 = this.raritySprite[gear.rarity.index - 1].textureRect;
      int width = (int) ((Rect) ref textureRect1).width;
      Rect textureRect2 = this.raritySprite[gear.rarity.index - 1].textureRect;
      int height = (int) ((Rect) ref textureRect2).height;
      component.SetDimensions(width, height);
      this.gear.star.GetComponent<UI2DSprite>().sprite2D = this.raritySprite[gear.rarity.index - 1];
      this.SetGearType(gear.kind, playerItem.GetElement());
      this.gear.favorite.SetActive(false);
      this.gear.rank.SetActive(false);
      this.gear.unlimit.SetActive(false);
      this.gear.broken.SetActive(false);
      this.gear.unknown.SetActive(false);
    }
    else
    {
      this.gear.root.SetActive(true);
      this.supply.root.SetActive(false);
      this.gear.star.GetComponent<UI2DSprite>().sprite2D = this.raritySprite[0];
      this.gear.favorite.SetActive(false);
      this.gear.rank.SetActive(false);
      this.gear.unlimit.SetActive(false);
      this.gear.broken.SetActive(false);
      this.gear.unknown.SetActive(true);
    }
  }

  public void InitBySupplyCache(SupplySupply supply)
  {
    this.supply.root.SetActive(true);
    this.gear.root.SetActive(false);
    this.supply.icon.sprite2D = ItemIcon.supplyCache[supply.ID];
    ((IEnumerable<GameObject>) this.supply.rarities).ToggleOnce(supply.rarity.index - 1);
    this.supply.favorite.SetActive(false);
    this.selectQuantity.SetActive(false);
    this.supply.name.GetComponent<UILabel>().SetText(supply.name);
  }

  [DebuggerHidden]
  public static IEnumerator LoadSprite(PlayerItem playerItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CLoadSprite\u003Ec__IteratorAAA()
    {
      playerItem = playerItem,
      \u003C\u0024\u003EplayerItem = playerItem
    };
  }

  [DebuggerHidden]
  public static IEnumerator LoadSprite(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CLoadSprite\u003Ec__IteratorAAB()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear
    };
  }

  [DebuggerHidden]
  public static IEnumerator LoadSprite(SupplyItem supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemIcon.\u003CLoadSprite\u003Ec__IteratorAAC()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply
    };
  }

  public PlayerItem PlayerItem => this.playerItem;

  public void DisableLongPressEvent()
  {
    ((Component) this.gear.button).gameObject.SetActive(false);
    ((Component) this.supply.button).gameObject.SetActive(false);
  }

  public void EnableLongPressEvent()
  {
    if (this.playerItem != (PlayerItem) null)
    {
      if (this.playerItem.gear != null)
      {
        if (!this.playerItem.gear.kind.isEquip)
          EventDelegate.Set(this.gear.button.onLongPress, (EventDelegate.Callback) (() => Bugu00561Scene.changeScene(true, this.playerItem)));
        else
          EventDelegate.Set(this.gear.button.onLongPress, (EventDelegate.Callback) (() => Unit00443Scene.changeScene(true, this.playerItem)));
      }
      else
        EventDelegate.Set(this.supply.button.onLongPress, (EventDelegate.Callback) (() => Bugu00561Scene.changeScene(true, this.playerItem)));
    }
    else
      Debug.LogError((object) "playerItem NULL");
  }

  public void EnableLongPressEvent(bool isGear, Action<ItemIcon> action)
  {
    if (isGear)
      EventDelegate.Set(this.gear.button.onLongPress, (EventDelegate.Callback) (() => action(this)));
    else
      EventDelegate.Set(this.supply.button.onLongPress, (EventDelegate.Callback) (() => action(this)));
  }

  public void ReleaseClickEvent()
  {
    this.gear.button.onClick.Clear();
    this.supply.button.onClick.Clear();
  }

  public bool Selected
  {
    get
    {
      return this.EnabledGear ? this.gear.selectedBack.activeSelf : this.supply.selectedBack.activeSelf;
    }
  }

  public void Deselect()
  {
    if (this.EnabledGear)
    {
      this.gear.selectedBack.SetActive(false);
      this.gear.selectedNum.SetActive(false);
    }
    else
    {
      this.supply.selectedBack.SetActive(false);
      ((IEnumerable<GameObject>) this.supply.selectedSupply).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    }
  }

  public void DeselectByCheckIcon()
  {
    if (!this.EnabledGear)
      return;
    this.gear.selectedBack.SetActive(false);
    this.gear.selectedCheck.SetActive(false);
  }

  public void Select(int selectCount)
  {
    this.Deselect();
    if (this.EnabledGear)
    {
      this.gear.selectedBack.SetActive(true);
      this.gear.selectedNum.SetActive(true);
      UI2DSprite component = this.gear.selectedNum.GetComponent<UI2DSprite>();
      UI2DSprite ui2Dsprite = component;
      Rect textureRect = this.selectNumSprite[selectCount].textureRect;
      int width = (int) ((Rect) ref textureRect).width;
      int selectedIndexFontSize = ItemIcon.SelectedIndexFontSize;
      ui2Dsprite.SetDimensions(width, selectedIndexFontSize);
      component.sprite2D = this.selectNumSprite[selectCount];
    }
    else
    {
      this.supply.selectedBack.SetActive(true);
      this.supply.selectedSupply[selectCount].SetActive(true);
    }
  }

  public void SelectByCheckIcon()
  {
    this.DeselectByCheckIcon();
    if (!this.EnabledGear)
      return;
    this.gear.selectedBack.SetActive(true);
    this.gear.selectedCheck.SetActive(true);
  }

  public Sprite IconSprite
  {
    get => this.EnabledGear ? this.gear.icon.sprite2D : this.supply.icon.sprite2D;
  }

  public Action<ItemIcon> onClick
  {
    get => this.onClick_;
    set
    {
      this.onClick_ = value;
      if (this.onClick_ == null)
        return;
      EventDelegate.Set(this.gear.button.onClick, (EventDelegate.Callback) (() => this.onClick_(this)));
      EventDelegate.Set(this.supply.button.onClick, (EventDelegate.Callback) (() => this.onClick_(this)));
      EventDelegate.Set(this.removeButton.GetComponent<UIButton>().onClick, (EventDelegate.Callback) (() => this.onClick_(this)));
    }
  }

  private void SetGearType(GearKind kind, CommonElement element)
  {
    this.gear.type.SetActive(false);
    if (!this.gear.root.activeSelf)
      return;
    if (!kind.isEquip)
    {
      this.gear.star.transform.localPosition = new Vector3(-12f, 0.0f);
    }
    else
    {
      this.gear.star.transform.localPosition = Vector3.zero;
      Sprite sprite = Resources.Load<Sprite>(string.Format("Icons/Materials/GearKind_Element_Icon/slc_{0}_{1}_34_30", (object) kind.Enum.ToString(), (object) element.ToString()));
      this.gear.type.GetComponent<UI2DSprite>().sprite2D = sprite;
      this.gear.type.SetActive(true);
    }
  }

  public void EnableQuantity(int quantity)
  {
    for (int index = 0; index <= 9; ++index)
    {
      this.rightNum[index].SetActive(false);
      this.leftNum[index].SetActive(false);
    }
    this.supply.equals.SetActive(false);
    this.QuantitySupply = false;
    if (quantity <= 0)
      return;
    if (quantity > 99)
    {
      Debug.LogWarning((object) ("set quantity over 99, count=" + (object) quantity));
      quantity = 99;
    }
    int index1 = quantity % 10;
    int index2 = Mathf.FloorToInt((float) (quantity / 10));
    this.rightNum[index1].SetActive(true);
    if (index2 != 0)
    {
      this.leftNum[index2].SetActive(true);
      this.supply.equals.transform.localPosition = this.supply.equalsPos.localPosition;
    }
    else
    {
      this.leftNum[index2].SetActive(false);
      this.supply.equals.transform.localPosition = ((Component) this.leftNum[0].transform.parent).transform.localPosition;
    }
    this.supply.equals.SetActive(true);
    this.QuantitySupply = true;
  }

  public void SelectedQuantity(int quantity)
  {
    if (quantity == 0)
    {
      this.SelectQuantity = false;
    }
    else
    {
      this.SelectQuantity = true;
      if (quantity > 99)
      {
        Debug.LogWarning((object) ("set quantity over 99, count=" + (object) quantity));
        quantity = 99;
      }
      int index1 = quantity % 10;
      int index2 = Mathf.FloorToInt((float) (quantity / 10));
      for (int index3 = 0; index3 <= 9; ++index3)
      {
        this.selectedRightNum[index3].SetActive(false);
        this.selectedLeftNum[index3].SetActive(false);
      }
      this.selectedRightNum[index1].SetActive(true);
      if (index2 != 0)
        this.selectedLeftNum[index2].SetActive(true);
      else
        this.selectedLeftNum[index2].SetActive(true);
      this.checkmark.SetActive(true);
    }
  }

  public void SetEmpty(bool empty)
  {
    if (empty)
    {
      if (this.EnabledGear)
      {
        this.supply.root.SetActive(false);
        this.gear.item_back.SetActive(true);
        this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.nonBackSprite;
        this.gear.bottom.SetActive(true);
        this.gear.broken.SetActive(false);
        ((Component) ((Component) this.gear.button).transform).gameObject.SetActive(false);
        this.gear.favorite.SetActive(false);
        this.gear.forbattle.SetActive(false);
        ((Component) ((Component) this.gear.icon).transform).gameObject.SetActive(false);
        this.gear.star.SetActive(false);
        this.gear.rank.SetActive(false);
        this.gear.unlimit.SetActive(false);
        this.gear.type.GetComponent<UI2DSprite>().sprite2D = this.nonTypeSprite;
        this.gear.type.SetActive(true);
        this.gear.unknown.SetActive(false);
        this.gear.manaseedsBreakageRate.SetActive(false);
        this.gear.manaseedsDurabilityCount.SetActive(false);
      }
      else
      {
        this.gear.root.SetActive(false);
        this.supply.back.SetActive(true);
        this.supply.bottom.SetActive(true);
        ((Component) ((Component) this.supply.button).transform).gameObject.SetActive(false);
        this.supply.equals.SetActive(false);
        this.supply.favorite.SetActive(false);
        this.supply.forbattle.SetActive(false);
        ((Component) ((Component) this.supply.icon).transform).gameObject.SetActive(false);
        this.quantity.SetActive(false);
        ((IEnumerable<GameObject>) this.supply.rarities).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
        this.supply.name.SetActive(false);
      }
    }
    else if (this.EnabledGear)
    {
      this.gear.item_back.SetActive(true);
      this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.backSprite[0];
      this.gear.bottom.SetActive(true);
      this.gear.broken.SetActive(true);
      ((Component) ((Component) this.gear.button).transform).gameObject.SetActive(true);
      this.gear.favorite.SetActive(true);
      this.gear.forbattle.SetActive(false);
      ((Component) ((Component) this.gear.icon).transform).gameObject.SetActive(true);
      this.gear.star.SetActive(true);
      this.gear.rank.SetActive(false);
      this.gear.unlimit.SetActive(false);
      this.gear.type.GetComponent<UI2DSprite>().sprite2D = this.nonTypeSprite;
      this.gear.type.SetActive(false);
      this.gear.unknown.SetActive(true);
    }
    else
    {
      this.supply.back.SetActive(true);
      this.supply.bottom.SetActive(true);
      ((Component) ((Component) this.supply.button).transform).gameObject.SetActive(true);
      this.supply.equals.SetActive(true);
      this.supply.favorite.SetActive(true);
      this.supply.forbattle.SetActive(false);
      ((Component) ((Component) this.supply.icon).transform).gameObject.SetActive(true);
      this.quantity.SetActive(true);
      ((IEnumerable<GameObject>) this.supply.rarities).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(true)));
      this.supply.name.SetActive(true);
    }
  }

  public void setEquipPlus(bool bl) => this.gear.equipPlus.SetActive(bl);

  public static bool IsCache(PlayerItem playerItem)
  {
    return playerItem.gear != null ? ItemIcon.gearCache.ContainsKey(playerItem.gear.ID) : ItemIcon.supplyCache.ContainsKey(playerItem.supply.ID);
  }

  public static bool IsCache(SupplyItem supply)
  {
    return supply != null && ItemIcon.supplyCache.ContainsKey(supply.Supply.ID);
  }

  public static bool IsCache(GearGear gear) => ItemIcon.gearCache.ContainsKey(gear.ID);

  public static void ClearCache()
  {
    ItemIcon.gearCache.Clear();
    ItemIcon.supplyCache.Clear();
  }

  public bool isButtonActive
  {
    set
    {
      if (this.EnabledGear)
        ((Component) ((Component) this.gear.button).transform).gameObject.SetActive(value);
      else
        ((Component) ((Component) this.supply.button).transform).gameObject.SetActive(value);
    }
  }

  public bool isBackActive
  {
    set
    {
      if (this.EnabledGear)
      {
        this.gear.item_back.SetActive(value);
        if (value)
          this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.nonBackSprite;
        else
          this.gear.backGround.GetComponent<UI2DSprite>().sprite2D = this.backSprite[0];
      }
      else
        this.supply.back.SetActive(value);
    }
  }

  public enum Sort
  {
    RARITY,
    GETORDER,
    CATEGORY,
    FAVORITE,
    MAX,
  }

  [Serializable]
  public class Gear
  {
    public GameObject root;
    public UI2DSprite icon;
    public LongPressButton button;
    public GameObject favorite;
    public GameObject rank;
    public GameObject star;
    public GameObject type;
    public GameObject broken;
    public GameObject bottom;
    public GameObject unknown;
    public GameObject forbattle;
    public GameObject item_back;
    public GameObject selectedNum;
    public GameObject selectedBack;
    public GameObject selectedCheck;
    public GameObject newGear;
    public GameObject equipPlus;
    public GameObject defaultGearTxt;
    public GameObject backGround;
    public GameObject manaseedsDurabilityCount;
    public GameObject manaseedsBreakageRate;
    public GameObject manaseedsDurabilityCount_1;
    public GameObject manaseedsDurabilityCount_10;
    public GameObject manaseedsDurabilityCount_100;
    public GameObject manaseedsBreakageRate_1;
    public GameObject manaseedsBreakageRate_10;
    public GameObject unlimit;
  }

  [Serializable]
  public class Supply
  {
    public GameObject root;
    public UI2DSprite icon;
    public LongPressButton button;
    public GameObject bottom;
    public GameObject favorite;
    public GameObject[] rarities;
    public GameObject equals;
    public Transform equalsPos;
    public GameObject forbattle;
    public GameObject back;
    public GameObject[] selectedSupply;
    public GameObject selectedBack;
    public GameObject name;
    public GameObject newSupply;
  }

  public enum BottomMode
  {
    Nothing,
    Visible,
  }
}
