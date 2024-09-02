// Decompiled with JetBrains decompiler
// Type: Unit0041010aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0041010aMenu : BackButtonMenuBase
{
  [SerializeField]
  public UI2DSprite[] LinkCharacter;
  [SerializeField]
  public UILabel TxtDescription;
  [SerializeField]
  public UILabel TxtPopuptitle;
  private List<PlayerUnit> sellUnitIcons = new List<PlayerUnit>();
  private Unit00410Menu menu;

  [DebuggerHidden]
  private IEnumerator UnitSellAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0041010aMenu.\u003CUnitSellAsync\u003Ec__Iterator2E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.UnitSellAsync());
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  public IEnumerator SetSelectedUnitIcons(List<PlayerUnit> icons, Unit00410Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0041010aMenu.\u003CSetSelectedUnitIcons\u003Ec__Iterator2E5()
    {
      menu = menu,
      icons = icons,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eicons = icons,
      \u003C\u003Ef__this = this
    };
  }
}
