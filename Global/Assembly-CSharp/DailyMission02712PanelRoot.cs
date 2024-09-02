// Decompiled with JetBrains decompiler
// Type: DailyMission02712PanelRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission02712PanelRoot : MonoBehaviour
{
  public GameObject panel;
  private DailyMission02712Menu.DailyMissionView viewModel;
  private PlayerBingo2Panel playerBingo2Panel;
  public static bool isBreakPanel;
  public static bool isAnimationEnd;
  private DailyMission02712Menu _menu;

  private DailyMission02712Menu menu
  {
    get
    {
      if (Object.op_Equality((Object) this._menu, (Object) null))
        this._menu = ((Component) ((Component) this).gameObject.transform.root).GetComponent<DailyMission02712Menu>();
      return this._menu;
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(DailyMission02712Menu.DailyMissionView viewModel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712PanelRoot.\u003CInit\u003Ec__Iterator5D9()
    {
      viewModel = viewModel,
      \u003C\u0024\u003EviewModel = viewModel,
      \u003C\u003Ef__this = this
    };
  }

  public void onPopup() => this.StartCoroutine(this.openDetailPopup());

  public void onClear() => this.StartCoroutine(this.clearMission());

  [DebuggerHidden]
  private IEnumerator openDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712PanelRoot.\u003CopenDetailPopup\u003Ec__Iterator5DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator clearMission()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712PanelRoot.\u003CclearMission\u003Ec__Iterator5DB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
