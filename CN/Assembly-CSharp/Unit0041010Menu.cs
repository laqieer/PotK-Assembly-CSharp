// Decompiled with JetBrains decompiler
// Type: Unit0041010Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0041010Menu : BackButtonMenuBase
{
  [SerializeField]
  public GameObject DirCharaForm1;
  [SerializeField]
  public GameObject DirCharaForm2;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  public UI2DSprite[] LinkCharacter1;
  [SerializeField]
  public UI2DSprite[] LinkCharacter2;
  [SerializeField]
  public UI2DSprite[] LinkCharacter3;
  [SerializeField]
  public UI2DSprite[] LinkCharacter4;
  [SerializeField]
  public UI2DSprite[] LinkCharacter5;
  private List<PlayerUnit> sellUnitIcons = new List<PlayerUnit>();
  private Unit00410Menu menu;

  [DebuggerHidden]
  private IEnumerator UnitSellAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0041010Menu.\u003CUnitSellAsync\u003Ec__Iterator2A7()
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

  private void SetCharaForm01()
  {
    this.DirCharaForm1.SetActive(true);
    this.DirCharaForm2.SetActive(false);
  }

  private void SetCharaForm02()
  {
    this.DirCharaForm1.SetActive(false);
    this.DirCharaForm2.SetActive(true);
  }

  [DebuggerHidden]
  public IEnumerator SetSelectedUnitIcons(List<PlayerUnit> icons, Unit00410Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0041010Menu.\u003CSetSelectedUnitIcons\u003Ec__Iterator2A8()
    {
      menu = menu,
      icons = icons,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eicons = icons,
      \u003C\u003Ef__this = this
    };
  }
}
