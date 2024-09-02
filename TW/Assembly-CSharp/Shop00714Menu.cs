﻿// Decompiled with JetBrains decompiler
// Type: Shop00714Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00714Menu : BackButtonMenuBase
{
  private const int gearType = 1;
  private int price;
  private bool success;
  private int prevMax;
  private int nextMax;
  private int totalPrice;
  private int company;
  private int addNum;
  private int gear1;
  private int gear2;
  [SerializeField]
  private UILabel txtDescription2;
  [SerializeField]
  private UILabel txtNumber;
  [SerializeField]
  private UILabel txtNumberAdd;
  [SerializeField]
  public GameObject btnYes;
  [SerializeField]
  public GameObject btnPlus5;
  [SerializeField]
  public GameObject btnPlus10;
  [SerializeField]
  public GameObject btnReduce5;
  [SerializeField]
  public GameObject btnReduce10;

  public void Init(int pri, int prev, int next)
  {
    this.price = pri;
    this.prevMax = prev;
    this.nextMax = next;
    this.addNum = this.nextMax - this.prevMax;
    this.company = this.nextMax - this.prevMax;
    this.totalPrice = this.price;
    foreach (Bag bag in MasterData.BagList)
    {
      if (bag.Type == 1)
      {
        this.gear1 = bag.Grade1;
        this.gear2 = bag.Grade2;
      }
    }
    this.UpdateUIData();
  }

  [DebuggerHidden]
  private IEnumerator UnitBoxPlus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00714Menu.\u003CUnitBoxPlus\u003Ec__Iterator480()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss(true);
    if (SMManager.Get<Player>().CheckKiseki(this.totalPrice))
      this.StartCoroutine(this.UnitBoxPlusAsync());
    else
      this.StartCoroutine(PopupUtility._999_3_1(Consts.GetInstance().SHOP_99931_TXT_DESCRIPTION, string.Empty));
  }

  [DebuggerHidden]
  private IEnumerator UnitBoxPlusAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00714Menu.\u003CUnitBoxPlusAsync\u003Ec__Iterator481()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup00715()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00714Menu.\u003Cpopup00715\u003Ec__Iterator482()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPlusGear1()
  {
    if (!this.btnPlus5.GetComponent<UIButton>().isEnabled)
      return;
    this.addNum += this.gear1;
    this.UpdateUIData();
  }

  public void IbtnPlusGear2()
  {
    if (!this.btnPlus10.GetComponent<UIButton>().isEnabled)
      return;
    this.addNum += this.gear2;
    this.UpdateUIData();
  }

  public void IbtnReduceGear1()
  {
    if (!this.btnReduce5.GetComponent<UIButton>().isEnabled)
      return;
    this.addNum -= this.gear1;
    this.UpdateUIData();
  }

  public void IbtnReduceGear2()
  {
    if (!this.btnReduce10.GetComponent<UIButton>().isEnabled)
      return;
    this.addNum -= this.gear2;
    this.UpdateUIData();
  }

  public void UpdateUIData()
  {
    Modified<Player> modified = SMManager.Observe<Player>();
    if (this.addNum <= 0)
    {
      this.addNum = 0;
      this.totalPrice = 0;
      this.btnYes.GetComponent<UIButton>().isEnabled = false;
      this.btnReduce5.GetComponent<UIButton>().isEnabled = false;
      this.btnReduce10.GetComponent<UIButton>().isEnabled = false;
      Vector3 size = this.btnReduce10.GetComponent<BoxCollider>().size;
      size.x = 50f;
      size.y = 58f;
      this.btnReduce10.GetComponent<BoxCollider>().size = size;
    }
    else
    {
      this.btnYes.GetComponent<UIButton>().isEnabled = true;
      this.btnReduce5.GetComponent<UIButton>().isEnabled = true;
      this.btnReduce10.GetComponent<UIButton>().isEnabled = true;
      if (modified.Value.CheckCapMaxUnit(this.addNum + this.prevMax))
      {
        this.addNum = modified.Value.max_units_cap - this.prevMax;
        this.btnPlus5.GetComponent<UIButton>().isEnabled = false;
        this.btnPlus10.GetComponent<UIButton>().isEnabled = false;
        Vector3 size = this.btnPlus10.GetComponent<BoxCollider>().size;
        size.x = 50f;
        size.y = 58f;
        this.btnPlus10.GetComponent<BoxCollider>().size = size;
      }
      else
      {
        this.btnPlus5.GetComponent<UIButton>().isEnabled = true;
        this.btnPlus10.GetComponent<UIButton>().isEnabled = true;
      }
      this.totalPrice = this.price * (this.addNum / this.company);
    }
    this.nextMax = this.addNum + this.prevMax;
    this.txtNumberAdd.SetTextLocalize(this.addNum);
    if (SMManager.Get<Player>().CheckKiseki(this.totalPrice))
      this.txtNumber.SetTextLocalize(SMManager.Observe<Player>().Value.coin);
    else
      this.txtNumber.SetTextLocalize("[ff0000]" + (object) SMManager.Observe<Player>().Value.coin + "[-]");
  }
}
