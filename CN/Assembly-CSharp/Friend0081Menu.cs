// Decompiled with JetBrains decompiler
// Type: Friend0081Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0081Menu : FriendBarBase
{
  private const int Width = 612;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 5;
  private List<PlayerFriend> friendList = new List<PlayerFriend>();
  public GameObject DirNoFriend;
  private int lastIndex;
  private GameObject prefabScroll;

  public int LastIndex
  {
    set => this.lastIndex = value;
    get => this.lastIndex;
  }

  [DebuggerHidden]
  private IEnumerator BackSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Menu.\u003CBackSceneAsync\u003Ec__Iterator4B7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnInformation()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_5", true);
  }

  public void IbtnSearch()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_10", true);
  }

  public void InviteFriend()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_20", true);
  }

  public void IbtnSendMessage()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_17", true);
  }

  public void IbtnSort()
  {
    if (this.IsPush)
      return;
    try
    {
      Persist.sortOrder.Data.Friend = ++Persist.sortOrder.Data.Friend % 3;
    }
    catch (Exception ex)
    {
      Persist.sortOrder.Delete();
      Persist.sortOrder.Data.Friend = ++Persist.sortOrder.Data.Friend % 3;
    }
    this.SortFriendsData();
  }

  [DebuggerHidden]
  public IEnumerator UpdateList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Menu.\u003CUpdateList\u003Ec__Iterator4B8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitFriendScroll(PlayerFriend[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Menu.\u003CInitFriendScroll\u003Ec__Iterator4B9()
    {
      friends = friends,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Menu.\u003CCreateScroll\u003Ec__Iterator4BA()
    {
      info_index = info_index,
      bar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u003Ef__this = this
    };
  }

  private void FriendScrollAction(int info_index, int bar_index)
  {
    ((Friend0081ScrollParts) this.allFriendBar[bar_index]).Set(this.allFriendInfo[info_index].index, this);
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public override void onBackButton() => this.IbtnBack();
}
