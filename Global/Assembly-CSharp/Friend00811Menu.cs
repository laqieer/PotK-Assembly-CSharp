// Decompiled with JetBrains decompiler
// Type: Friend00811Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00811Menu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject LinkUnit;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtLastplay;
  [SerializeField]
  private UILabel TxtLastplayTime;
  [SerializeField]
  private UILabel TxtPlayername;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  private UILabel TxtLv;
  [SerializeField]
  private UI2DSprite Emblem;
  private WebAPI.Response.PlayerSearch targetResult;
  private List<string> target_friend_ids = new List<string>();

  public void AddTargetFriendsIds(string id) => this.target_friend_ids.Add(id);

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator FriendApplyAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00811Menu.\u003CFriendApplyAsync\u003Ec__Iterator429()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupDemand()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.FriendApplyAsync());
  }

  [DebuggerHidden]
  private IEnumerator openPopup00813()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00811Menu.\u003CopenPopup00813\u003Ec__Iterator42A popup00813CIterator42A = new Friend00811Menu.\u003CopenPopup00813\u003Ec__Iterator42A();
    return (IEnumerator) popup00813CIterator42A;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00814()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00811Menu.\u003CopenPopup00814\u003Ec__Iterator42B popup00814CIterator42B = new Friend00811Menu.\u003CopenPopup00814\u003Ec__Iterator42B();
    return (IEnumerator) popup00814CIterator42B;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00815()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00811Menu.\u003CopenPopup00815\u003Ec__Iterator42C popup00815CIterator42C = new Friend00811Menu.\u003CopenPopup00815\u003Ec__Iterator42C();
    return (IEnumerator) popup00815CIterator42C;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00816()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00811Menu.\u003CopenPopup00816\u003Ec__Iterator42D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTargetUserData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00811Menu.\u003CSetTargetUserData\u003Ec__Iterator42E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTargetUserData(WebAPI.Response.PlayerSearch result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00811Menu.\u003CSetTargetUserData\u003Ec__Iterator42F()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }
}
