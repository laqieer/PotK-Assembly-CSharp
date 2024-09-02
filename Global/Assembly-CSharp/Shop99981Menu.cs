// Decompiled with JetBrains decompiler
// Type: Shop99981Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop99981Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UIInput nen;
  [SerializeField]
  protected UIInput getsu;
  [SerializeField]
  protected UIInput hi;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription04;
  [SerializeField]
  private UILabel TxtDescription06;
  [SerializeField]
  private UILabel TxtPopuptitle;
  private System.Action onCancel;

  public void SetOnCancel(System.Action callback) => this.onCancel = callback;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
    this.onCancel();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupDecide()
  {
    string str1 = this.nen.value;
    string str2 = this.getsu.value;
    string day = this.hi.value;
    if (DateCheck.YearCheck(str1) && DateCheck.MonthCheck(str2))
    {
      if (DateTime.TryParse(str1 + "/" + str2 + "/" + day, out DateTime _))
      {
        this.StartCoroutine(this.popup99982(str1, str2, day));
        return;
      }
    }
    PaymentListener.ShowPopupWithMessage(Consts.Lookup("SHOP_99981_MENU_01"), Consts.Lookup("SHOP_99981_MENU_02"));
  }

  public void Shop99981Visible(bool b)
  {
    ((Component) ((Component) this).transform.Find("MainPanel")).gameObject.SetActive(b);
  }

  [DebuggerHidden]
  private IEnumerator popup99982(string year, string month, string day)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop99981Menu.\u003Cpopup99982\u003Ec__Iterator417()
    {
      year = year,
      month = month,
      day = day,
      \u003C\u0024\u003Eyear = year,
      \u003C\u0024\u003Emonth = month,
      \u003C\u0024\u003Eday = day
    };
  }
}
