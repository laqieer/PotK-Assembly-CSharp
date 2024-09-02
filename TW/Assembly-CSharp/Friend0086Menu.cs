// Decompiled with JetBrains decompiler
// Type: Friend0086Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0086Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtCharaname;
  [SerializeField]
  protected UILabel TxtFighting;
  [SerializeField]
  protected UILabel TxtHp;
  [SerializeField]
  protected UILabel TxtLastplay;
  [SerializeField]
  protected UILabel TxtLv;
  [SerializeField]
  protected UILabel TxtPlayername;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected GameObject LinkCharacter;
  [SerializeField]
  protected GameObject LinkBugu;
  [SerializeField]
  protected UILabel TxtComment;
  [SerializeField]
  protected UILabel TxtLeaderSkill;
  [SerializeField]
  protected UILabel TxtLeaderSkillDesc;
  [SerializeField]
  protected UILabel TxtPower;
  [SerializeField]
  protected GameObject GuildInfoRoot;
  [SerializeField]
  protected GameObject GuildThumb;
  [SerializeField]
  protected UILabel TxtGuildName;
  [SerializeField]
  protected UISprite GuildLevel;
  [SerializeField]
  protected UISprite GuildLevel10;
  [SerializeField]
  protected UILabel TxtGuildMember;
  [SerializeField]
  protected UILabel TxtGuildMemberCapacity;
  [SerializeField]
  protected GameObject LeaderUnit;
  [SerializeField]
  protected GameObject[] DeckUnits;
  public UIButton BtnFavoritOn;
  public UIButton BtnFavoritOff;
  public UIButton BtnCancellation;
  private PlayerFriend friend;
  private GuildDirectory guildData;
  private Guild0282GuildBase guildBase;
  private GuildInfoPopup guildInfoPopup;
  private bool favorite;
  [SerializeField]
  private UI2DSprite Emblem;
  private bool isInit;

  [DebuggerHidden]
  private IEnumerator openPopup0087()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CopenPopup0087\u003Ec__Iterator531()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnApproval()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.openPopup0087());
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator Cancellation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CCancellation\u003Ec__Iterator532()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnCancellation()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Cancellation());
  }

  [DebuggerHidden]
  private IEnumerator FriendFavoriteAsync(
    string[] target_player_ids,
    string[] unlock_target_player_ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CFriendFavoriteAsync\u003Ec__Iterator533()
    {
      target_player_ids = target_player_ids,
      unlock_target_player_ids = unlock_target_player_ids,
      \u003C\u0024\u003Etarget_player_ids = target_player_ids,
      \u003C\u0024\u003Eunlock_target_player_ids = unlock_target_player_ids,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnFavoriteiOff()
  {
    this.StartCoroutine(this.FriendFavoriteAsync(new string[1]
    {
      this.friend.target_player_id
    }, new string[0]));
  }

  public virtual void IbtnFavoriteiOn()
  {
    this.StartCoroutine(this.FriendFavoriteAsync(new string[0], new string[1]
    {
      this.friend.target_player_id
    }));
  }

  [DebuggerHidden]
  private IEnumerator openPopup0089()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CopenPopup0089\u003Ec__Iterator534()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnRefusal()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.openPopup0089());
  }

  public void changeFavorite(bool favorite)
  {
    this.favorite = favorite;
    ((Component) this.BtnFavoritOn).gameObject.SetActive(this.favorite);
    ((Component) this.BtnFavoritOff).gameObject.SetActive(!this.favorite);
    this.BtnCancellation.isEnabled = !this.favorite;
  }

  [DebuggerHidden]
  private IEnumerator SetGuildInfo(GuildDirectory guild)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CSetGuildInfo\u003Ec__Iterator535()
    {
      guild = guild,
      \u003C\u0024\u003Eguild = guild,
      \u003C\u003Ef__this = this
    };
  }

  public void FriendDetailScene(PlayerUnit playerUnit)
  {
    Unit0042Scene.changeSceneFriendUnit(true, this.friend.target_player_id, playerUnit);
  }

  private void SetIconEvent(UIButton button, PlayerUnit unit)
  {
    EventDelegate.Add(button.onClick, (EventDelegate.Callback) (() => this.FriendDetailScene(unit)));
  }

  [DebuggerHidden]
  public IEnumerator setData(PlayerFriend friend, SM.FriendDetail friendDetail)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CsetData\u003Ec__Iterator536()
    {
      friendDetail = friendDetail,
      friend = friend,
      \u003C\u0024\u003EfriendDetail = friendDetail,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  private void SetTextLeaderUnit(PlayerUnit leader)
  {
    PlayerUnitLeader_skills leaderSkill = leader.leader_skill;
    if (leaderSkill == null)
    {
      this.TxtLeaderSkill.alignment = NGUIText.Alignment.Center;
      this.TxtLeaderSkill.SetTextLocalize(Consts.GetInstance().FRIEND_LEADERSKILL_DEFAULT);
      this.TxtLeaderSkillDesc.SetTextLocalize(string.Empty);
    }
    else
    {
      this.TxtLeaderSkill.SetTextLocalize(leaderSkill.skill.name);
      this.TxtLeaderSkillDesc.SetTextLocalize(leaderSkill.skill.description);
    }
  }

  private void SetTextPlayerComment(string comment)
  {
    if (comment == string.Empty)
      this.TxtComment.SetTextLocalize(Consts.GetInstance().FRIEND_COMMENT_DEFAULT);
    else
      this.TxtComment.SetTextLocalize(comment);
  }

  public void onButtonGuildInfo() => this.StartCoroutine(this.ShowGuildInfo());

  [DebuggerHidden]
  private IEnumerator ShowGuildInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CShowGuildInfo\u003Ec__Iterator537()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetActionGuildMaintenance()
  {
  }

  public void SetActionAlreadyGuild()
  {
    this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().POPUP_028_1_1_5_TITLE, Consts.GetInstance().POPUP_028_1_1_6_NO_APPLICANT));
  }

  [DebuggerHidden]
  private IEnumerator LoadCharacterSprite(int id, GameObject locationObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CLoadCharacterSprite\u003Ec__Iterator538()
    {
      id = id,
      locationObject = locationObject,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003ElocationObject = locationObject
    };
  }

  public void setTxtTitle(string str) => this.TxtTitle.SetTextLocalize(str);
}
