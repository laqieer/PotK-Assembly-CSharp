// Decompiled with JetBrains decompiler
// Type: GuildDefGuestSelectPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildDefGuestSelectPopup : GuildGuestListBase
{
  private const int Width = 616;
  private const int Height = 154;
  private const int ColumnValue = 1;
  private const int RowValue = 11;
  private const int ScreenValue = 6;
  private GuildDefTeamPopup parent;
  private GuildDefTeamEditPopup teamEditPopup;
  private GvgCandidate[] friends;

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(GuildDefTeamPopup parent, GuildDefTeamEditPopup editPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefGuestSelectPopup.\u003CInitializeAsync\u003Ec__Iterator726()
    {
      parent = parent,
      editPopup = editPopup,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003EeditPopup = editPopup,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefGuestSelectPopup.\u003CCreateScroll\u003Ec__Iterator727()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitFriendListScroll(GvgCandidate[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefGuestSelectPopup.\u003CInitFriendListScroll\u003Ec__Iterator728()
    {
      friends = friends,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateFriendList(GvgCandidate[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefGuestSelectPopup.\u003CCreateFriendList\u003Ec__Iterator729()
    {
      friends = friends,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
  }

  public void InitScrollPosition() => this.scroll.scrollView.ResetPosition();

  public override void onBackButton()
  {
    if (this.IsPushAndSet() || !((Component) this).gameObject.activeSelf || this.parent.Mode != GuildDefTeamPopup.MODE.Guest)
      return;
    this.parent.ShowTeamEdit();
  }
}
