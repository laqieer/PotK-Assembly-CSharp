// Decompiled with JetBrains decompiler
// Type: Quest002103Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Quest002103Menu : BackButtonMenuBase
{
  private const int MIN_QUANTITY = 1;
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();
  [SerializeField]
  private int select;
  [SerializeField]
  private SupplyItem target;
  [SerializeField]
  protected UILabel SupplyName;
  [SerializeField]
  protected UILabel SupplyDescription;
  [SerializeField]
  protected UILabel Quantity;
  [SerializeField]
  protected UILabel SldTakeQuantity;
  [SerializeField]
  protected UILabel SldMaxQuantity;
  [SerializeField]
  protected UILabel MinQuantity;
  [SerializeField]
  protected UILabel MaxQuantity;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UI2DSprite IconSprite;
  [SerializeField]
  protected UISlider SldItemNumber;
  [SerializeField]
  protected GameObject BarButton;
  [SerializeField]
  protected BoxCollider BarCollider;
  private int slidervalue;
  private int totalTake;

  public void ChangePopUp(
    List<SupplyItem> SupplyItems,
    SupplyItem tapSupply,
    Sprite icon,
    int select,
    List<SupplyItem> SaveDeck)
  {
    this.SldItemNumber.value = 1f;
    this.SupplyItems = SupplyItems;
    this.select = select;
    foreach (SupplyItem supplyItem in SupplyItems)
    {
      if (supplyItem.Supply.ID == tapSupply.Supply.ID)
        this.target = supplyItem;
    }
    this.IconSprite.sprite2D = icon;
    this.SupplyName.SetText(tapSupply.Supply.name);
    this.SupplyDescription.SetText(tapSupply.Supply.description);
    this.MinQuantity.SetTextLocalize(1);
    this.totalTake = 0;
    this.totalTake = SupplyItems.TotalQuantity(tapSupply.Supply.ID);
    if (this.totalTake > tapSupply.Supply.battle_stack_limit)
      this.totalTake = tapSupply.Supply.battle_stack_limit;
    if (this.totalTake <= 1)
    {
      this.BarButton.SetActive(false);
      ((Collider) this.BarCollider).enabled = false;
    }
    else
    {
      this.BarButton.SetActive(true);
      ((Collider) this.BarCollider).enabled = true;
    }
    this.MaxQuantity.SetTextLocalize(this.totalTake);
    this.SldMaxQuantity.SetTextLocalize(this.totalTake);
    this.Quantity.SetTextLocalize(Consts.Lookup("QUEST_002103_MENU_QUANTITY", (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) SupplyItems.TotalQuantity(tapSupply.Supply.ID)
      }
    }));
    this.UpdateSldTakeQuantity();
  }

  protected override void Update()
  {
    base.Update();
    this.UpdateSldTakeQuantity();
  }

  private void UpdateSldTakeQuantity()
  {
    this.slidervalue = Mathf.CeilToInt(this.SldItemNumber.value * (float) this.totalTake);
    if (this.slidervalue < 1)
      this.slidervalue = 1;
    this.SldTakeQuantity.SetTextLocalize(this.slidervalue);
  }

  public void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    this.target.SelectCount = this.slidervalue;
    this.target.DeckIndex = this.select;
    Singleton<PopupManager>.GetInstance().dismiss();
    Quest00210Scene.changeScene(false, this.SupplyItems);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
