// Decompiled with JetBrains decompiler
// Type: Quest00210aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00210aMenu : BackButtonMenuBase
{
  public NGxScroll2 scroll;
  private int select;
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();
  private List<SupplyItem> SaveDeck = new List<SupplyItem>();
  private List<int> takeItem = new List<int>();
  private int iconWidth = ItemIcon.Width;
  private int iconHeight = ItemIcon.Height;
  private int iconColumnValue = ItemIcon.ColumnValue;
  private int iconRowValue = ItemIcon.RowValue;
  private int iconScreenValue = ItemIcon.ScreenValue;
  private int iconMaxValue = ItemIcon.MaxValue;
  private bool isInitialize;
  private List<ItemIcon> allSupplyIcon = new List<ItemIcon>();
  private List<SupplyItem> showSupplyItems = new List<SupplyItem>();
  private float scrool_start_y;
  private GameObject SelectCountPopup;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected Transform scrollParent;

  [DebuggerHidden]
  public IEnumerator InitSupplyList(
    List<SupplyItem> SupplyItems,
    List<SupplyItem> SaveDeck,
    int select,
    bool removeButton)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aMenu.\u003CInitSupplyList\u003Ec__Iterator178()
    {
      select = select,
      SupplyItems = SupplyItems,
      SaveDeck = SaveDeck,
      removeButton = removeButton,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003ESupplyItems = SupplyItems,
      \u003C\u0024\u003ESaveDeck = SaveDeck,
      \u003C\u0024\u003EremoveButton = removeButton,
      \u003C\u003Ef__this = this
    };
  }

  public void SelectRelease()
  {
    if (this.IsPushAndSet())
      return;
    this.scroll.Clear();
    Quest00210Scene.changeScene(false, this.SupplyItems);
  }

  public void CountSelectPopUp(PlayerItem tapSupply, SupplyItem shotItem, Sprite icon)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().open(this.SelectCountPopup).GetComponent<Quest002103Menu>().ChangePopUp(this.SupplyItems, shotItem, icon, this.select, this.SaveDeck);
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIconRange(int value)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aMenu.\u003CCreateItemIconRange\u003Ec__Iterator179()
    {
      value = value,
      \u003C\u0024\u003Evalue = value,
      \u003C\u003Ef__this = this
    };
  }

  private void ScrollUpdate()
  {
    if (!this.isInitialize || this.showSupplyItems.Count <= this.iconScreenValue)
      return;
    int num1 = this.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.showSupplyItems.Count - this.iconScreenValue - 1) / this.iconColumnValue * this.iconHeight);
    float num4 = (float) (this.iconHeight * this.iconRowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int item_index = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject item = gameObject;
        float num5 = item.transform.localPosition.y + num2;
        if ((double) num5 > (double) num1)
        {
          int? nullable = this.showSupplyItems.FirstIndexOrNull<SupplyItem>((Func<SupplyItem, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
          int num6 = nullable.Value + this.iconMaxValue;
          if (nullable.HasValue && num6 < (this.showSupplyItems.Count + 4) / 5 * 5)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
            if (num6 >= this.showSupplyItems.Count)
              item.SetActive(false);
            else if (this.showSupplyItems[num6].removeButton || ItemIcon.IsCache(this.showSupplyItems[num6]))
              this.CreateItemIconCache(num6, item_index);
            else
              this.StartCoroutine(this.CreateItemIcon(num6, item_index));
            flag = true;
          }
        }
        else if ((double) num5 < -((double) num4 - (double) num1))
        {
          int num7 = this.iconMaxValue;
          if (!item.activeSelf)
          {
            item.SetActive(true);
            num7 = 0;
          }
          int? nullable = this.showSupplyItems.FirstIndexOrNull<SupplyItem>((Func<SupplyItem, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
          int num8 = nullable.Value - num7;
          if (nullable.HasValue && num8 >= 0)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + num4, 0.0f);
            if (this.showSupplyItems[num8].removeButton || ItemIcon.IsCache(this.showSupplyItems[num8]))
              this.CreateItemIconCache(num8, item_index);
            else
              this.StartCoroutine(this.CreateItemIcon(num8, item_index));
            flag = true;
          }
        }
        ++item_index;
      }
    }
    while (flag);
  }

  private void ResetItemIcon(int index)
  {
    ((Component) this.allSupplyIcon[index]).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIcon(int info_index, int item_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aMenu.\u003CCreateItemIcon\u003Ec__Iterator17A()
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
    ItemIcon itemIcon = this.allSupplyIcon[item_index];
    SupplyItem showSupplyItem = this.showSupplyItems[info_index];
    this.showSupplyItems.Where<SupplyItem>((Func<SupplyItem, bool>) (a => Object.op_Equality((Object) a.icon, (Object) itemIcon))).ForEach<SupplyItem>((Action<SupplyItem>) (b => b.icon = (ItemIcon) null));
    showSupplyItem.icon = itemIcon;
    if (showSupplyItem.removeButton)
      itemIcon.InitByRemoveButton();
    else
      itemIcon.InitBySupplyItemCache(showSupplyItem);
    this.CreateItemIconSharing(info_index, item_index);
  }

  private void CreateItemIconSharing(int info_index, int item_index)
  {
    ItemIcon itemIcon = this.allSupplyIcon[item_index];
    SupplyItem s_item = this.showSupplyItems[info_index];
    if (s_item.removeButton)
    {
      itemIcon.onClick = (Action<ItemIcon>) (supplyicon => this.SelectRelease());
      itemIcon.ForBattle = false;
      itemIcon.Gray = false;
    }
    else if (this.takeItem.Contains(s_item.Supply.ID))
    {
      itemIcon.onClick = (Action<ItemIcon>) (supplyicon => { });
      itemIcon.ForBattle = true;
      itemIcon.Gray = true;
    }
    else
    {
      itemIcon.onClick = (Action<ItemIcon>) (supplyicon => this.CountSelectPopUp(supplyicon.PlayerItem, s_item, supplyicon.IconSprite));
      itemIcon.ForBattle = false;
      itemIcon.Gray = false;
    }
    if (s_item.removeButton)
      EventDelegate.Set(itemIcon.supply.button.onLongPress, (EventDelegate.Callback) (() => { }));
    else
      EventDelegate.Set(itemIcon.supply.button.onLongPress, (EventDelegate.Callback) (() => Bugu00561Scene.changeScene(true, ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.supply.ID == s_item.Supply.ID)).FirstOrDefault<PlayerItem>())));
  }

  [DebuggerHidden]
  private IEnumerator LoadObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210aMenu.\u003CLoadObject\u003Ec__Iterator17B()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public void onEndScene()
  {
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.SupplyItems = this.SaveDeck.Copy();
    Quest00210Scene.changeScene(false, this.SupplyItems);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }
}
