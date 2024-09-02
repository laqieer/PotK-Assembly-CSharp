// Decompiled with JetBrains decompiler
// Type: Friend0086Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public UIButton BtnFavoritOn;
  public UIButton BtnFavoritOff;
  public UIButton BtnCancellation;
  private PlayerFriend friend;
  private bool favorite;
  private UnitIcon charIcon;
  [SerializeField]
  private UI2DSprite Emblem;

  [DebuggerHidden]
  private IEnumerator openPopup0087()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CopenPopup0087\u003Ec__Iterator448()
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
    return (IEnumerator) new Friend0086Menu.\u003CCancellation\u003Ec__Iterator449()
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
    return (IEnumerator) new Friend0086Menu.\u003CFriendFavoriteAsync\u003Ec__Iterator44A()
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
    return (IEnumerator) new Friend0086Menu.\u003CopenPopup0089\u003Ec__Iterator44B()
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
    if (Object.op_Inequality((Object) this.charIcon, (Object) null))
      this.charIcon.Favorite = favorite;
    ((Component) this.BtnFavoritOn).gameObject.SetActive(this.favorite);
    ((Component) this.BtnFavoritOff).gameObject.SetActive(!this.favorite);
    this.BtnCancellation.isEnabled = !this.favorite;
  }

  [DebuggerHidden]
  public IEnumerator setData(PlayerFriend friend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Menu.\u003CsetData\u003Ec__Iterator44C()
    {
      friend = friend,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  public void setTxtTitle(string str) => this.TxtTitle.SetTextLocalize(str);
}
