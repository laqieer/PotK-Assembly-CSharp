// Decompiled with JetBrains decompiler
// Type: Shop00716Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00716Menu : BackButtonMenuBase
{
  private int price;
  private bool success;
  private int nextMax;
  [SerializeField]
  private UILabel txtDescription2;
  [SerializeField]
  private UILabel txtNumber;

  public void Init(int pri, int prev, int next)
  {
    this.price = pri;
    this.nextMax = next;
    this.txtDescription2.SetText(Consts.Lookup("SHOP_00716_MENU") + ":" + prev.ToLocalizeNumberText() + "→[fff000]" + next.ToLocalizeNumberText() + "[-]");
    this.txtNumber.SetTextLocalize(SMManager.Observe<Player>().Value.coin);
  }

  [DebuggerHidden]
  private IEnumerator ItemBoxPlus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00716Menu.\u003CItemBoxPlus\u003Ec__Iterator3B8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss(true);
    if (SMManager.Get<Player>().CheckKiseki(this.price))
      this.StartCoroutine(this.ItemBoxPlusAsync());
    else
      this.StartCoroutine(PopupUtility._999_3_1(Consts.Lookup("SHOP_99931_TXT_DESCRIPTION"), string.Empty));
  }

  [DebuggerHidden]
  private IEnumerator ItemBoxPlusAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00716Menu.\u003CItemBoxPlusAsync\u003Ec__Iterator3B9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup00717()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00716Menu.\u003Cpopup00717\u003Ec__Iterator3BA()
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
}
