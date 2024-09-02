// Decompiled with JetBrains decompiler
// Type: FriendRequestPopupBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FriendRequestPopupBase : BackButtonMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  [SerializeField]
  protected UILabel TxtFriendName;
  [SerializeField]
  protected UILabel TxtFriendRequest;
  [SerializeField]
  protected UILabel TxtGetPoint;
  [SerializeField]
  protected UILabel TxtPopuptitle26;
  [SerializeField]
  protected UILabel TxtRecommend;
  [SerializeField]
  protected UI2DSprite Emblem;
  [SerializeField]
  private GameObject linkChar;
  private List<string> target_friend_ids = new List<string>();
  private System.Action callback;
  [SerializeField]
  protected GameObject slc_Guest;
  [SerializeField]
  protected GameObject slc_Guild;

  public void SetCallback(System.Action callback) => this.callback = callback;

  [DebuggerHidden]
  public IEnumerator Init(PlayerHelper helper, int incr_friend_point)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CInit\u003Ec__IteratorBE3()
    {
      helper = helper,
      incr_friend_point = incr_friend_point,
      \u003C\u0024\u003Ehelper = helper,
      \u003C\u0024\u003Eincr_friend_point = incr_friend_point,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CInit\u003Ec__IteratorBE4()
    {
      gladiator = gladiator,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Init(
    UnitUnit unit,
    int level,
    string playerID,
    string playerName,
    int point,
    int emblemId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CInit\u003Ec__IteratorBE5()
    {
      unit = unit,
      level = level,
      playerID = playerID,
      playerName = playerName,
      point = point,
      emblemId = emblemId,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Elevel = level,
      \u003C\u0024\u003EplayerID = playerID,
      \u003C\u0024\u003EplayerName = playerName,
      \u003C\u0024\u003Epoint = point,
      \u003C\u0024\u003EemblemId = emblemId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetEmblem(int emblemId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CSetEmblem\u003Ec__IteratorBE6()
    {
      emblemId = emblemId,
      \u003C\u0024\u003EemblemId = emblemId,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void SetText(string name, int point)
  {
    this.TxtFriendName.SetTextLocalize(name);
    if (point <= 0)
      return;
    this.TxtGetPoint.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_REQUEST_POPUPBASE, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (point),
        (object) point
      }
    }));
  }

  public virtual void IbtnPopupYes()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Singleton<CommonRoot>.GetInstance().StartCoroutine(this.FriendApplyAsync());
  }

  public void IbtnNo()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.callback == null)
      return;
    this.callback();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator FriendApplyAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CFriendApplyAsync\u003Ec__IteratorBE7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00813()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CopenPopup00813\u003Ec__IteratorBE8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00814()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CopenPopup00814\u003Ec__IteratorBE9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00815()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendRequestPopupBase.\u003CopenPopup00815\u003Ec__IteratorBEA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void AddTargetFriendsIds(string id) => this.target_friend_ids.Add(id);
}
