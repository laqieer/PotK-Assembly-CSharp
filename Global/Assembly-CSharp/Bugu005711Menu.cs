// Decompiled with JetBrains decompiler
// Type: Bugu005711Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005711Menu : BackButtonMenuBase
{
  [SerializeField]
  private UISlider slider;
  [SerializeField]
  private GameObject itemObj;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtDescription04;
  [SerializeField]
  private UILabel TxtDescription05;
  [SerializeField]
  private UILabel TxtDescription06;
  [SerializeField]
  private UILabel TxtDescription07;
  [SerializeField]
  private UILabel TxtDescription08;
  [SerializeField]
  private UILabel TxtDescription09;
  [SerializeField]
  private UILabel TxtDescription10;
  [SerializeField]
  private UILabel TxtDescription11;
  [SerializeField]
  private UILabel TxtDescription12;
  [SerializeField]
  private UILabel TxtDescription13;
  [SerializeField]
  private UILabel TxtDescription14;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  private UI2DSprite LinkItem;
  public Bugu0052Menu menu;
  public int itemZenny = 12345;
  public int totalItem = 10;
  private int itemCount = 10;
  private int totalZenny;
  private PlayerItem supply;

  public void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    this.menu.SetSuppylCount(this.supply, this.itemCount);
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
  public IEnumerator InitSceneAsync(int supply_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Menu.\u003CInitSceneAsync\u003Ec__Iterator33F()
    {
      supply_id = supply_id,
      \u003C\u0024\u003Esupply_id = supply_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(PlayerItem supply, Bugu0052Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Menu.\u003CInitSceneAsync\u003Ec__Iterator340()
    {
      supply = supply,
      menu = menu,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  public void Set(PlayerItem pi)
  {
    this.totalItem = pi.quantity;
    this.itemZenny = pi.supply.sell_price;
    this.TxtDescription01.SetText(pi.supply.name);
    this.TxtDescription02.SetText(pi.supply.description);
    this.TxtDescription04.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription08.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription13.SetTextLocalize("0");
    this.TxtDescription14.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription06.SetTextLocalize(this.itemZenny.ToString());
    this.TxtDescription11.SetTextLocalize((this.totalItem * this.itemZenny).ToString());
    this.slider.value = 1f;
  }

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(SupplySupply supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005711Menu.\u003CInitSceneAsync\u003Ec__Iterator341()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  public void Set(SupplySupply pi)
  {
    this.itemZenny = pi.sell_price;
    this.TxtDescription01.SetText(pi.name);
    this.TxtDescription02.SetText(pi.description);
    this.TxtDescription04.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription08.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription14.SetTextLocalize(this.totalItem.ToString());
    this.TxtDescription06.SetTextLocalize(this.itemZenny.ToString());
    this.TxtDescription11.SetTextLocalize((this.totalItem * this.itemZenny).ToString());
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
    this.TxtDescription08.SetTextLocalize(this.itemCount.ToString());
    this.totalZenny = this.itemZenny * this.itemCount;
    this.TxtDescription11.SetTextLocalize(this.totalZenny.ToString());
    if (!Input.GetKeyUp((KeyCode) 27))
      return;
    this.IbtnNo();
  }
}
