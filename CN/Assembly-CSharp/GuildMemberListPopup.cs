// Decompiled with JetBrains decompiler
// Type: GuildMemberListPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberListPopup : GuildMemberListBase
{
  private const int Width = 518;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 15;
  private const int ScreenValue = 8;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel guildMemberNum;
  private Guild0282Menu guild282Menu;
  private Guild0282GuildBaseMenu guildBaseMenu;
  private GuildRegistration guildInfo;
  private GuildMemberObject guildMemberObjs;
  private System.Action actionAfterRoleChange;

  [DebuggerHidden]
  public IEnumerator Initialize(
    Guild0282Menu menu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popup,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CInitialize\u003Ec__Iterator6B7()
    {
      menu = menu,
      baseMenu = baseMenu,
      popup = popup,
      action = action,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(GuildMemberObject popup, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CInitialize\u003Ec__Iterator6B8()
    {
      popup = popup,
      action = action,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CommonInit(
    Guild0282Menu menu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popup,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CCommonInit\u003Ec__Iterator6B9()
    {
      menu = menu,
      baseMenu = baseMenu,
      popup = popup,
      action = action,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitMemberScroll(GuildMembership[] members)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CInitMemberScroll\u003Ec__Iterator6BA()
    {
      members = members,
      \u003C\u0024\u003Emembers = members,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CCreateScroll\u003Ec__Iterator6BB()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }
}
