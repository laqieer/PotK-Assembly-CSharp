// Decompiled with JetBrains decompiler
// Type: GuildAtkGuestSelectPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildAtkGuestSelectPopup : GuildGuestListBase
{
  private const int Width = 616;
  private const int Height = 154;
  private const int ColumnValue = 1;
  private const int RowValue = 11;
  private const int ScreenValue = 6;
  private GuildBattleSortiePopup sortiePopup;
  private GvgCandidate[] friends;
  private GuildBattlePreparationPopup parent;
  private Guild0282Menu guild0282Menu;

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkGuestSelectPopup.\u003CCreateScroll\u003Ec__Iterator70C()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(
    Guild0282Menu menu,
    GuildBattlePreparationPopup parent,
    GuildBattleSortiePopup sortiePopup,
    GvgCandidate[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkGuestSelectPopup.\u003CInitializeAsync\u003Ec__Iterator70D()
    {
      menu = menu,
      parent = parent,
      friends = friends,
      sortiePopup = sortiePopup,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u0024\u003EsortiePopup = sortiePopup,
      \u003C\u003Ef__this = this
    };
  }

  public void SetGvgPopup()
  {
    this.guild0282Menu.SetGvgPopup(GuildUtil.GvGPopupState.Sortie, (System.Action) (() =>
    {
      ((Component) this).gameObject.SetActive(true);
      this.IsPush = false;
    }));
  }

  [DebuggerHidden]
  public IEnumerator InitFriendListScroll(GvgCandidate[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkGuestSelectPopup.\u003CInitFriendListScroll\u003Ec__Iterator70E()
    {
      friends = friends,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
  }

  public void InitScrollPosition()
  {
    this.scroll.ResolvePosition();
    if (this.IsInitialize)
      return;
    this.InitializeEnd();
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet() || !((Component) this).gameObject.activeSelf || this.parent.Mode != GuildBattlePreparationPopup.MODE.Guest)
      return;
    GuildUtil.gvgFriendAttack = (GvgCandidate) null;
    this.guild0282Menu.closePopup(true);
  }
}
