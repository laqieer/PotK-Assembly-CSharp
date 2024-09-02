// Decompiled with JetBrains decompiler
// Type: DisplayOrderSortPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DisplayOrderSortPopup : BackButtonMenuBase
{
  [SerializeField]
  private List<GameObject> categoryOffButtons;
  [SerializeField]
  private List<GameObject> categoryOnButtons;
  private int firstCategory;
  protected int nowCategory;
  private System.Action sortAction;

  public virtual void Init(int nowCategory, System.Action sortAction)
  {
    this.sortAction = sortAction;
    this.firstCategory = nowCategory;
    this.BtnSetting(nowCategory);
  }

  private void BtnSetting(int category)
  {
    this.nowCategory = category;
    this.BtnActive();
  }

  private void BtnActive()
  {
    this.categoryOffButtons.ForEach((Action<GameObject>) (x => x.SetActive(true)));
    this.categoryOnButtons.ForEach((Action<GameObject>) (x => x.SetActive(false)));
    this.categoryOffButtons[this.nowCategory].SetActive(false);
    this.categoryOnButtons[this.nowCategory].SetActive(true);
  }

  public virtual void IbtnID()
  {
    if (this.IsPush)
      return;
    this.BtnSetting(0);
  }

  public virtual void IbtnNew()
  {
    if (this.IsPush)
      return;
    this.BtnSetting(1);
  }

  public virtual void IbtnRarity()
  {
    if (this.IsPush)
      return;
    this.BtnSetting(2);
  }

  public virtual void IbtnOK()
  {
    if (this.IsPushAndSet())
      return;
    this.sortAction();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public virtual void IbtnClear()
  {
    if (this.IsPush)
      return;
    this.BtnSetting(this.firstCategory);
  }

  public virtual void SaveData() => Debug.Log((object) "Persist Save");

  public enum DISPLAY_ORDER_SORT_CATEGORY
  {
    ID,
    NEW,
    RARITY,
  }
}
