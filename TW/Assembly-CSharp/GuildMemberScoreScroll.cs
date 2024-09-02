// Decompiled with JetBrains decompiler
// Type: GuildMemberScoreScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberScoreScroll : MonoBehaviour
{
  [SerializeField]
  private GameObject link_Character;
  [SerializeField]
  private UI2DSprite playerTitle;
  [SerializeField]
  private UILabel lblPlayerName;
  [SerializeField]
  private UILabel lblContributionValue;
  [SerializeField]
  private UILabel lblAttack;
  [SerializeField]
  private UILabel lblAttack2;
  [SerializeField]
  private UILabel lblDefense;
  [SerializeField]
  private UILabel lblDefense2;
  [SerializeField]
  private UILabel lblStarNumAttack;
  [SerializeField]
  private UILabel lblStarNumDefense;
  [SerializeField]
  private GameObject slc_Listbase_guild_member;
  [SerializeField]
  private GameObject slc_Listbase_player;
  [SerializeField]
  private UILabel txt_stars_get;
  [SerializeField]
  private UILabel lbl_star_acquired;
  [SerializeField]
  private GameObject slc_master_icon;
  [SerializeField]
  private GameObject slc_sub_master_icon;
  [SerializeField]
  private List<GameObject> star_on_defense;
  private GvgPlayerHistory score;
  private GameObject unitIconPrefab;

  [DebuggerHidden]
  private IEnumerator SetMemberScoreData(GvgPlayerHistory score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberScoreScroll.\u003CSetMemberScoreData\u003Ec__Iterator78C()
    {
      score = score,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  private void SetLabel()
  {
    this.lblAttack.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_MEMBER_SCORE_ATTACK);
    this.lblAttack2.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_MEMBER_SCORE_MATCH_UNIT);
    this.lblDefense.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_MEMBER_SCORE_DEFENSE);
    this.lblDefense2.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_MEMBER_SCORE_MATCH_UNIT);
    this.txt_stars_get.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_MEMBER_SCORE_ACQUIRED_STAR);
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(GvgPlayerHistory score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberScoreScroll.\u003CInitializeAsync\u003Ec__Iterator78D()
    {
      score = score,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }
}
