// Decompiled with JetBrains decompiler
// Type: Unit0041010aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Unit0041010aMenu.\u003CUnitSellAsync\u003Ec__Iterator2A9()
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
    return (IEnumerator) new Unit0041010aMenu.\u003CSetSelectedUnitIcons\u003Ec__Iterator2AA()
    {
      menu = menu,
      icons = icons,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eicons = icons,
      \u003C\u003Ef__this = this
    };
  }
}
