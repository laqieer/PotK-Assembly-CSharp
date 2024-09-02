// Decompiled with JetBrains decompiler
// Type: GuildMemberListPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private bool isEnemy;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel guildMemberNum;
  [SerializeField]
  private GameObject slc_title_base_one;
  [SerializeField]
  private GameObject slc_title_base_enemy;
  private Guild0282Menu guild282Menu;
  private Guild0282GuildBaseMenu guildBaseMenu;
  private GuildRegistration guildInfo;
  private GuildMemberObject guildMemberObjs;
  private System.Action actionAfterRoleChange;

  [DebuggerHidden]
  public IEnumerator Initialize(
    bool is_enemy,
    Guild0282Menu menu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popup,
    GuildRegistration guild,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CInitialize\u003Ec__Iterator74C()
    {
      is_enemy = is_enemy,
      menu = menu,
      baseMenu = baseMenu,
      popup = popup,
      guild = guild,
      action = action,
      \u003C\u0024\u003Eis_enemy = is_enemy,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Eguild = guild,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(GuildMemberObject popup, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CInitialize\u003Ec__Iterator74D()
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
    bool is_enemy,
    Guild0282Menu menu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popup,
    GuildRegistration guild,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CCommonInit\u003Ec__Iterator74E()
    {
      is_enemy = is_enemy,
      guild = guild,
      menu = menu,
      baseMenu = baseMenu,
      popup = popup,
      action = action,
      \u003C\u0024\u003Eis_enemy = is_enemy,
      \u003C\u0024\u003Eguild = guild,
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
    return (IEnumerator) new GuildMemberListPopup.\u003CInitMemberScroll\u003Ec__Iterator74F()
    {
      members = members,
      \u003C\u0024\u003Emembers = members,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsOpenSortPopup)
      return;
    if (Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_1"))
    {
      if (Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0281Menu>(), (Object) null))
        ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0281Menu>().isOpenGuildMemberOrInfoPopup = false;
    }
    else if (Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_2") && Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>(), (Object) null))
      ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>().isClosePopupByBackBtn = true;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberListPopup.\u003CCreateScroll\u003Ec__Iterator750()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }
}
