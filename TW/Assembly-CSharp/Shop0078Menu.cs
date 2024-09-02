// Decompiled with JetBrains decompiler
// Type: Shop0078Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    this.TxtDescription01.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0078_TXT_DESCRIPTION01, (IDictionary) new Hashtable()
    {
      {
        (object) "quantity",
        (object) item_quantity.ToLocalizeNumberText()
      }
    }));
    this.TxtDescription02.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION_ADD_QUANTITY, (IDictionary) new Hashtable()
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
