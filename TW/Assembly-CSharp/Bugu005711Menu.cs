// Decompiled with JetBrains decompiler
// Type: Bugu005711Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005711Menu : BackButtonMenuBase
{
  [SerializeField]
  private UISlider slider;
  [SerializeField]
  private UILabel TxtItemName;
  [SerializeField]
  private UILabel TxtItemDescription;
  [SerializeField]
  private UILabel TxtPossessionNum;
  [SerializeField]
  private UILabel TxtSellValue;
  [SerializeField]
  private UILabel TxtSellNum;
  [SerializeField]
  private UILabel TxtTotalSellValue;
  [SerializeField]
  private UILabel TxtSelectMax;
  [SerializeField]
  private UI2DSprite LinkItem;
  private Bugu00525Menu menu;
  private int itemZenny;
  private int itemCount;
  private int totalItem;
  private int totalZenny;
  private InventoryItem item;

  public void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    this.menu.SetSellCount(this.item, this.itemCount);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(InventoryItem item, Bugu00525Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Menu.\u003CInitSceneAsync\u003Ec__Iterator3E2()
    {
      item = item,
      menu = menu,
      \u003C\u0024\u003Eitem = item,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  public void Set(InventoryItem item)
  {
    this.totalItem = item.Item.quantity >= this.menu.SelectMax ? this.menu.SelectMax : item.Item.quantity;
    this.itemZenny = item.GetSingleSellPrice();
    this.TxtItemName.SetText(item.GetName());
    this.TxtItemDescription.SetText(item.GetDescription());
    this.TxtPossessionNum.SetTextLocalize(item.Item.quantity);
    this.TxtSellNum.SetTextLocalize(this.totalItem);
    this.TxtSelectMax.SetTextLocalize(this.totalItem);
    this.TxtSellValue.SetTextLocalize(this.itemZenny);
    this.TxtTotalSellValue.SetTextLocalize(this.totalItem * this.itemZenny);
    this.slider.value = 1f;
  }

  protected override void Update()
  {
    this.itemCount = (int) ((double) this.slider.value * (double) this.totalItem);
    if (this.totalItem <= 1 && (double) this.slider.value < 1.0)
    {
      if ((double) this.slider.value >= 0.0099999997764825821)
        this.itemCount = 1;
    }
    else if (this.itemCount > this.totalItem)
    {
      this.itemCount = this.totalItem;
      this.slider.value = (float) this.itemCount / (float) this.totalItem;
    }
    this.TxtSellNum.SetTextLocalize(this.itemCount);
    this.totalZenny = this.itemZenny * this.itemCount;
    this.TxtTotalSellValue.SetTextLocalize(this.totalZenny);
    if (!Input.GetKeyUp((KeyCode) 27))
      return;
    this.IbtnNo();
  }
}
