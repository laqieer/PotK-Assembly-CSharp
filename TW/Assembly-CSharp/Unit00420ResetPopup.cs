// Decompiled with JetBrains decompiler
// Type: Unit00420ResetPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00420ResetPopup : BackButtonMenuBase
{
  private const int RESET_UNIT_ID = 701204;
  [SerializeField]
  private UI2DSprite linkCharacter;
  [SerializeField]
  private UILabel txtNumUnitPossession;
  [SerializeField]
  private UILabel txtDescriptionNoUnit;
  [SerializeField]
  private UILabel txtDescriptionNoReinforce;
  [SerializeField]
  private GameObject ibtnPopupClose;
  [SerializeField]
  private GameObject ibtnPopupNormal;
  private Unit00420Menu menu;
  private PlayerUnit baseUnit;
  private PlayerMaterialUnit resetUnit;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.reset());
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  [DebuggerHidden]
  public IEnumerator reset()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420ResetPopup.\u003Creset\u003Ec__Iterator2F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(Unit00420Menu bMenu, PlayerUnit bUnit, PlayerMaterialUnit rUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420ResetPopup.\u003CInit\u003Ec__Iterator2F8()
    {
      bMenu = bMenu,
      bUnit = bUnit,
      rUnit = rUnit,
      \u003C\u0024\u003EbMenu = bMenu,
      \u003C\u0024\u003EbUnit = bUnit,
      \u003C\u0024\u003ErUnit = rUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateMenu()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420ResetPopup.\u003CUpdateMenu\u003Ec__Iterator2F9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
