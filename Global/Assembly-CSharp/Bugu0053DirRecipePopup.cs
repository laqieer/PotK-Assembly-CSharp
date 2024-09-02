// Decompiled with JetBrains decompiler
// Type: Bugu0053DirRecipePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053DirRecipePopup : BackButtonMenuBase
{
  [SerializeField]
  protected NGxScroll2 ScrollContainer;
  private List<GearCombineRecipe> gearRecepes = new List<GearCombineRecipe>();
  public bool isBackKey = true;
  private Bugu0053Menu menu;

  [DebuggerHidden]
  public IEnumerator Init(Bugu0053Menu menuObject, Player player)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CInit\u003Ec__Iterator31B()
    {
      menuObject = menuObject,
      player = player,
      \u003C\u0024\u003EmenuObject = menuObject,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  private bool IsEnableRecipe(DateTime? start_at, DateTime? end_at, DateTime server_time)
  {
    return (!start_at.HasValue || (!start_at.HasValue ? 0 : (start_at.Value > server_time ? 1 : 0)) == 0) && (!end_at.HasValue || (!end_at.HasValue ? 0 : (end_at.Value < server_time ? 1 : 0)) == 0);
  }

  private int CheckCanMaterial(PlayerItem gear)
  {
    int num = 0;
    if (gear.broken)
      ++num;
    if (gear.favorite)
      ++num;
    if (gear.ForBattle)
      ++num;
    return num;
  }

  public void IbtnClose()
  {
    if (this.IsPushAndSet())
      return;
    this.menu.BackBtnEnable = true;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  [DebuggerHidden]
  public IEnumerator BackKeyEnable()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CBackKeyEnable\u003Ec__Iterator31C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnClose();
}
