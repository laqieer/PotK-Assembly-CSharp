﻿// Decompiled with JetBrains decompiler
// Type: Shop0078Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Shop0078Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  private GameObject linkParent;

  public void InitDataSet(string name, int item_quantity, int player_item_quantity)
  {
    this.TxtDescription.SetTextLocalize(name);
    this.TxtDescription01.SetTextLocalize(Consts.Lookup("SHOP_0078_TXT_DESCRIPTION01", (IDictionary) new Hashtable()
    {
      {
        (object) "quantity",
        (object) item_quantity.ToLocalizeNumberText()
      }
    }));
    this.TxtDescription02.SetTextLocalize(Consts.Lookup("SHOP_007X_TXT_DESCRIPTION_ADD_QUANTITY", (IDictionary) new Hashtable()
    {
      {
        (object) "quantity",
        (object) player_item_quantity.ToLocalizeNumberText()
      },
      {
        (object) "quantityNext",
        (object) (player_item_quantity + item_quantity).ToLocalizeNumberText()
      }
    }));
  }

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnPopupOk();

  public void InitObj(GameObject obj) => obj.Clone(this.linkParent.transform);
}
