// Decompiled with JetBrains decompiler
// Type: Popup0041013Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup0041013Menu : BackButtonMenuBase
{
  private List<PlayerUnit> sellUnitIcons = new List<PlayerUnit>();
  private Unit00410Menu menu;
  [SerializeField]
  private GameObject txtDescriptionLimit;

  [DebuggerHidden]
  public IEnumerator Init(List<PlayerUnit> icons, Unit00410Menu menu, bool isOverAlert)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0041013Menu.\u003CInit\u003Ec__Iterator9FC()
    {
      menu = menu,
      icons = icons,
      isOverAlert = isOverAlert,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eicons = icons,
      \u003C\u0024\u003EisOverAlert = isOverAlert,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UnitSellAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0041013Menu.\u003CUnitSellAsync\u003Ec__Iterator9FD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes() => this.StartCoroutine(this.UnitSellAsync());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
