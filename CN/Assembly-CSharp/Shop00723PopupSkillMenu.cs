// Decompiled with JetBrains decompiler
// Type: Shop00723PopupSkillMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00723PopupSkillMenu : BackButtonMenuBase
{
  private const int SINGLE_SKILLCHANGE = 1;
  [SerializeField]
  private NGxScrollMasonry scroll_;
  private Shop00723Menu menu_;
  private UnitTicketUnitSample sample_;

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop00723Menu menu, UnitTicketUnitSample unitSample)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillMenu.\u003CcoInitialize\u003Ec__Iterator477()
    {
      menu = menu,
      unitSample = unitSample,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EunitSample = unitSample,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.onClickClose();

  public void onClickClose()
  {
    if (this.IsPushAndSet())
      return;
    this.menu_.onClosedSkill();
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
