// Decompiled with JetBrains decompiler
// Type: Bugu0052MedalPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Bugu0052MedalPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtTitle;
  private Bugu0052MedalPopup.CurrencyKind kindType = Bugu0052MedalPopup.CurrencyKind.Money;
  private int price;
  private int boostCnt;
  private Action<bool, int, int> yesAction;

  public void Init(
    Bugu0052MedalPopup.CurrencyKind kind,
    int value,
    int bCnt,
    Action<bool, int, int> yesAct)
  {
    this.kindType = kind;
    this.price = value;
    this.boostCnt = bCnt;
    this.yesAction = yesAct;
    this.txtTitle.SetText(Consts.Format(Consts.GetInstance().BUGU_0052POPUP_TITLE));
    if (kind == Bugu0052MedalPopup.CurrencyKind.RareMedal)
    {
      this.txtDescription.SetTextLocalize(Consts.Format(Consts.GetInstance().BUGU_0052POPUP_DESCRIPTION_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "price",
          (object) this.price
        }
      }));
    }
    else
    {
      if (kind != Bugu0052MedalPopup.CurrencyKind.Money)
        return;
      this.txtDescription.SetTextLocalize(Consts.Format(Consts.GetInstance().BUGU_0052POPUP_DESCRIPTION_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "price",
          (object) this.price
        }
      }));
    }
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.yesAction(this.kindType == Bugu0052MedalPopup.CurrencyKind.RareMedal, this.price, this.boostCnt);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public enum CurrencyKind
  {
    RareMedal,
    Money,
  }
}
