// Decompiled with JetBrains decompiler
// Type: Friend00880Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Friend00880Menu : BackButtonMenuBase
{
  private const int Width = 612;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 5;
  private Modified<PlayerFriend[]> friendsM;
  public NGxScroll2 scroll;
  private bool isInitialize;
  private float scrool_start_y;
  private int MaxValue;
  private List<Friend00880Scroll> allScroll = new List<Friend00880Scroll>();
  protected List<FriendBarInfoFB> allFriendInfo = new List<FriendBarInfoFB>();
  private List<Friend00880Menu.FB_FRIEND_INFO> lstFbFriend = new List<Friend00880Menu.FB_FRIEND_INFO>();

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void ScrollContainerResolvePosition() => this.scroll.ResolvePosition();

  [DebuggerHidden]
  public IEnumerator InitFriendScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00880Menu.\u003CInitFriendScroll\u003Ec__Iterator4ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CreateScrollBase(GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00880Menu.\u003CCreateScrollBase\u003Ec__Iterator4EE()
    {
      prefab = prefab,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  private void InitializeEnd()
  {
    this.scrool_start_y = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.isInitialize = true;
  }

  public void CreateFriendInfo(PlayerFriend[] friends)
  {
    foreach (PlayerFriend friend in friends)
    {
      this.allFriendInfo.Add(new FriendBarInfoFB()
      {
        friend = friend
      });
      FriendBarInfoFB friendBarInfoFb = new FriendBarInfoFB()
      {
        friend = friend
      };
      friendBarInfoFb.friend.target_player_name = "123131";
      this.allFriendInfo.Add(friendBarInfoFb);
    }
    int count = this.allFriendInfo.Count;
    for (int index = 0; index < count; ++index)
      this.allFriendInfo[index].index = index;
  }

  public void Initialize()
  {
    this.isInitialize = false;
    this.MaxValue = 8;
    this.scroll.Clear();
  }

  protected override void Update() => base.Update();

  private void ResetScroll(int index)
  {
    Friend00880Scroll scroll = this.allScroll[index];
    ((Component) scroll).gameObject.SetActive(false);
    this.allFriendInfo.Where<FriendBarInfoFB>((Func<FriendBarInfoFB, bool>) (a => Object.op_Equality((Object) a.scroll, (Object) scroll))).ForEach<FriendBarInfoFB>((Action<FriendBarInfoFB>) (b => b.scroll = (Friend00880Scroll) null));
  }

  [DebuggerHidden]
  public IEnumerator ResetScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00880Menu.\u003CResetScroll\u003Ec__Iterator4EF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResetScrollEvent() => this.StartCoroutine(this.ResetScroll());

  [DebuggerHidden]
  protected IEnumerator CreateScroll(int info_index, int unit_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00880Menu.\u003CCreateScroll\u003Ec__Iterator4F0()
    {
      unit_index = unit_index,
      info_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  private void FriendScrollAction(int info_index, int bar_index)
  {
    Friend00880Scroll friend00880Scroll = this.allScroll[bar_index];
  }

  public struct FB_FRIEND_INFO
  {
    public string strId;
    public string strName;
    public string strUrl;
    public Texture2D pic;
  }
}
