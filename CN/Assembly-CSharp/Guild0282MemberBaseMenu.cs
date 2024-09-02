// Decompiled with JetBrains decompiler
// Type: Guild0282MemberBaseMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0282MemberBaseMenu : GuildMapObject
{
  [SerializeField]
  private bool isEnemy;
  public GuildMembership memberData;
  private GuildMemberObject memberPopup;
  public GameObject unitIconPos;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  private Guild0282Menu guild0282Menu;

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CResourceLoad\u003Ec__Iterator6C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize(GuildMembership data, GuildMemberObject popup, Guild0282Menu menu)
  {
    this.memberData = data;
    this.memberPopup = popup;
    this.guild0282Menu = menu;
    if (Object.op_Equality((Object) this.unitIcon, (Object) null))
      this.unitIcon = this.unitIconPrefab.Clone(this.unitIconPos.transform).GetComponent<UnitIcon>();
    this.StartCoroutine(this.unitIcon.SetUnit(data.player.leader_unit_unit, data.player.leader_unit_unit.GetElement(), false));
    this.unitIcon.setLevelTextToString(data.player.leader_unit_level.ToString());
    this.unitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    this.unitIcon.button.onClick.Clear();
    this.unitIcon.button.onLongPress.Clear();
  }

  public override void onBackButton()
  {
  }

  public void onButtonMemberLog()
  {
    Singleton<CommonRoot>.GetInstance().guildChatManager.OpenMemberLogDialog(this.memberData.player.player_id);
  }

  public void onMemberAbout()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowMemberInfo());
  }

  [DebuggerHidden]
  private IEnumerator ShowMemberInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CShowMemberInfo\u003Ec__Iterator6C7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onButtonATKTeam() => Debug.Log((object) "MoveATKTeam");

  public void onButtonDEFTeam() => Debug.Log((object) "MoveDEFTeam");

  public void onButtonBattle() => Debug.Log((object) "MoveBattle");

  public void onButtonTown()
  {
  }

  public void FriendDetailScene(GuildMembership data)
  {
    GuildPlayerInfo player = PlayerAffiliation.Current.Player;
    if (player.player_id.Equals(Player.Current.id))
      Unit0042Scene.changeScene(true, PlayerUnit.create_by_unitunit(player.leader_unit_unit), SMManager.Get<PlayerUnit[]>());
    else
      Unit0042Scene.changeSceneFriendUnit(true, data.player.player_id);
  }
}
