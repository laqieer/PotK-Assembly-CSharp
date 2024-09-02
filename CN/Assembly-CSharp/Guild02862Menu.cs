// Decompiled with JetBrains decompiler
// Type: Guild02862Menu
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
public class Guild02862Menu : BackButtonMenuBase
{
  private const int ICON_WIDGET_SIZE_X = 112;
  private const int ICON_WIDGET_SIZE_Y = 121;
  private GameObject itemDetailPopup;
  [SerializeField]
  private NGxScroll2 scroll;
  private GameObject giftIcon;
  private List<Guild02862Menu.GiftIconInfo> allGiftItemInfo;
  private List<GameObject> showGiftList;
  private float scrool_start_y;
  private bool isInitialize;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CInitializeAsync\u003Ec__Iterator70D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CResourceLoad\u003Ec__Iterator70E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateItemIcon(int info_index, int item_index)
  {
    this.StartCoroutine(this.loadThumb(this.allGiftItemInfo[info_index], this.showGiftList[item_index]));
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIconForInitialize(int info_index, int item_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CCreateItemIconForInitialize\u003Ec__Iterator70F()
    {
      info_index = info_index,
      item_index = item_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003Eitem_index = item_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadThumb(Guild02862Menu.GiftIconInfo itemIcon, GameObject parent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CloadThumb\u003Ec__Iterator710()
    {
      itemIcon = itemIcon,
      parent = parent,
      \u003C\u0024\u003EitemIcon = itemIcon,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitGiftList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CInitGiftList\u003Ec__Iterator711()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetItem(Guild02862Menu.GiftIconInfo iconInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CSetItem\u003Ec__Iterator712()
    {
      iconInfo = iconInfo,
      \u003C\u0024\u003EiconInfo = iconInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowDetailPopup(Guild02862Menu.GiftIconInfo giftInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02862Menu.\u003CShowDetailPopup\u003Ec__Iterator713()
    {
      giftInfo = giftInfo,
      \u003C\u0024\u003EgiftInfo = giftInfo,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  private void onClickIcon(Guild02862Menu.GiftIconInfo giftInfo)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.SetItem(giftInfo));
  }

  private void onLongPressIcon(Guild02862Menu.GiftIconInfo giftInfo)
  {
    if (this.IsPushAndSet())
      return;
    if (giftInfo.gift.reward_type_id == 1 || giftInfo.gift.reward_type_id == 24 || giftInfo.gift.reward_type_id == 3 || giftInfo.gift.reward_type_id == 2 || giftInfo.gift.reward_type_id == 19 || giftInfo.gift.reward_type_id == 21)
      this.StartCoroutine(this.ShowDetailPopup(giftInfo));
    else
      this.IsPush = false;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  private void ScrollUpdate()
  {
    if (!this.isInitialize || this.showGiftList.Count <= ItemIcon.ScreenValue)
      return;
    int num1 = ItemIcon.Height * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.allGiftItemInfo.Count - ItemIcon.ScreenValue - 1) / ItemIcon.ColumnValue * ItemIcon.Height);
    float num4 = (float) (ItemIcon.Height * ItemIcon.RowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int num5 = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject item = gameObject;
        float num6 = item.transform.localPosition.y + num2;
        int? nullable = this.allGiftItemInfo.FirstIndexOrNull<Guild02862Menu.GiftIconInfo>((Func<Guild02862Menu.GiftIconInfo, bool>) (v => Object.op_Inequality((Object) v.iconObj, (Object) null) && Object.op_Equality((Object) ((Component) v.iconObj).gameObject, (Object) item)));
        if ((double) num6 > (double) num1)
        {
          int info_index = !nullable.HasValue ? this.allGiftItemInfo.Count : nullable.Value + ItemIcon.MaxValue;
          if (nullable.HasValue && info_index < this.allGiftItemInfo.Count)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
            this.ResetScroll(num5);
            this.CreateItemIcon(info_index, num5);
            flag = true;
          }
        }
        else if ((double) num6 < -((double) num4 - (double) num1))
        {
          int num7 = ItemIcon.MaxValue;
          if (!item.activeSelf)
          {
            item.SetActive(true);
            num7 = 0;
          }
          int info_index = !nullable.HasValue ? -1 : nullable.Value - num7;
          if (nullable.HasValue && info_index >= 0)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + num4, 0.0f);
            this.ResetScroll(num5);
            this.CreateItemIcon(info_index, num5);
            flag = true;
          }
        }
        ++num5;
      }
    }
    while (flag);
  }

  protected void ResetScroll(int index)
  {
    GameObject item = this.showGiftList[index];
    for (int index1 = 0; index1 < item.transform.childCount; ++index1)
      Object.Destroy((Object) ((Component) item.transform.GetChild(index1)).gameObject);
    item.SetActive(false);
    this.allGiftItemInfo.Where<Guild02862Menu.GiftIconInfo>((Func<Guild02862Menu.GiftIconInfo, bool>) (a => Object.op_Equality((Object) a.iconObj, (Object) item.GetComponent<CreateIconObject>()))).ForEach<Guild02862Menu.GiftIconInfo>((Action<Guild02862Menu.GiftIconInfo>) (b => b.iconObj = (CreateIconObject) null));
  }

  public class GiftIconInfo
  {
    public GuildGift gift;
    public CreateIconObject iconObj;
    public bool select;
    public int index;
  }
}
