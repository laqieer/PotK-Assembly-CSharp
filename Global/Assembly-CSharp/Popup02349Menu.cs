// Decompiled with JetBrains decompiler
// Type: Popup02349Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02349Menu : NGMenuBase
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
  private GameObject linkChar;
  private List<string> target_friend_ids = new List<string>();
  private System.Action callback;

  public void SetCallback(System.Action callback) => this.callback = callback;

  [DebuggerHidden]
  public IEnumerator Init(PlayerHelper helper, int incr_friend_point)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CInit\u003Ec__Iterator7DC()
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
    return (IEnumerator) new Popup02349Menu.\u003CInit\u003Ec__Iterator7DD()
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
    int point)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CInit\u003Ec__Iterator7DE()
    {
      unit = unit,
      level = level,
      playerID = playerID,
      playerName = playerName,
      point = point,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Elevel = level,
      \u003C\u0024\u003EplayerID = playerID,
      \u003C\u0024\u003EplayerName = playerName,
      \u003C\u0024\u003Epoint = point,
      \u003C\u003Ef__this = this
    };
  }

  public void SetText(string name, int point)
  {
    this.TxtFriendName.SetTextLocalize(name);
    if (point > 0)
      this.TxtGetPoint.SetTextLocalize(Consts.Lookup("FRIEND_REQUEST_POPUPBASE", (IDictionary) new Hashtable()
      {
        {
          (object) nameof (point),
          (object) point
        }
      }));
    else
      ((Component) this.TxtGetPoint).gameObject.SetActive(false);
  }

  public virtual void IbtnPopupYes()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Singleton<CommonRoot>.GetInstance().StartCoroutine(this.FriendApplyAsync());
  }

  public virtual void IbtnPopupNo()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.callback();
  }

  [DebuggerHidden]
  private IEnumerator FriendApplyAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CFriendApplyAsync\u003Ec__Iterator7DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00813()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CopenPopup00813\u003Ec__Iterator7E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00814()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CopenPopup00814\u003Ec__Iterator7E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup00815()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02349Menu.\u003CopenPopup00815\u003Ec__Iterator7E2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void AddTargetFriendsIds(string id) => this.target_friend_ids.Add(id);
}
