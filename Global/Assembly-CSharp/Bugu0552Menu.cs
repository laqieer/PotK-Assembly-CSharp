// Decompiled with JetBrains decompiler
// Type: Bugu0552Menu
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

#nullable disable
public class Bugu0552Menu : Bugu0052Menu
{
  public override void onBackButton() => this.backScene();

  public override void ChangeDetailScene(PlayerItem playerItem)
  {
    if (playerItem.gear != null)
    {
      if (!playerItem.gear.kind.isEquip)
        Bugu05561Scene.changeScene(true, playerItem);
      else
        Unit05443Scene.changeScene(true, playerItem);
    }
    else
      Bugu05561Scene.changeScene(true, playerItem);
  }

  protected override void SetPosessionText(int value, int max)
  {
    this.NumProsession1.SetTextLocalize(string.Format("{0}", (object) value));
  }

  public override void IbtnNo() => base.IbtnNo();

  protected override void SetTitle()
  {
    if (this.mode == Bugu0052Scene.MODE.SELL)
    {
      int num = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Count<PlayerItem>();
      this.TxtTitle.SetText(Consts.Lookup("GEAR_0052_SELL_TITLE"));
      this.TxtZenyPattern3.SetText(Consts.Lookup("GEAR_0052_SELL_LABEL"));
      this.scrollPanel.bottomAnchor.absolute = 99;
      this.scrollBarWidget.topAnchor.absolute = -13;
      this.scrollBarWidget.bottomAnchor.absolute = 140;
      this.NumProsession3.SetTextLocalize(Consts.Lookup("GEAR_0552_POSSESSION_SELL", (IDictionary) new Hashtable()
      {
        {
          (object) "now",
          (object) num.ToString()
        }
      }));
    }
    else
      base.SetTitle();
  }

  public override void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    if (this.ItemList.Select<InventoryItem, bool>((Func<InventoryItem, bool>) (x => x.Item.favorite)).Contains<bool>(true) && this.mode == Bugu0052Scene.MODE.SELL)
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
      if (this.mode != Bugu0052Scene.MODE.SELL || this.ItemList.Count <= 0)
        return;
      if (this.ItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear != null)).Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear.rarity.index >= 3)).ToList<InventoryItem>().Count > 0)
        this.StartCoroutine(this.SellWarningPopUp(new System.Action(this.SellAction)));
      else
        this.StartCoroutine(this.SellCheckPopUp(new System.Action(this.SellAction)));
    }
  }

  private void SellAction() => this.StartCoroutine(this.Sell());

  [DebuggerHidden]
  private IEnumerator Sell()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0552Menu.\u003CSell\u003Ec__Iterator63F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
