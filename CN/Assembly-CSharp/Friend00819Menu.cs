// Decompiled with JetBrains decompiler
// Type: Friend00819Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00819Menu : FriendBarBase
{
  private const int Width = 612;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 5;
  private bool mode;
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private UIButton btnDeselectAll;
  [SerializeField]
  private UIButton btnSelectAll;
  [SerializeField]
  private UIButton btnDecide;
  [SerializeField]
  private UILabel TxtTitle;
  private bool[] lst_is_checked;
  private DateTime now;

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_5");
    Singleton<NGSceneManager>.GetInstance().destroyScene("friend008_19");
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator openPopup00893()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Menu.\u003CopenPopup00893\u003Ec__Iterator4CD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup008202()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Menu.\u003CopenPopup008202\u003Ec__Iterator4CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator RefreshScroll(PlayerFriend[] friends)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Menu.\u003CRefreshScroll\u003Ec__Iterator4CF()
    {
      friends = friends,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
  }

  public void RefreshScrollEvent(PlayerFriend[] friends)
  {
    this.StartCoroutine(this.RefreshScroll(friends));
  }

  public void IbtnDecide()
  {
    if (this.IsPushAndSet())
      return;
    if (this.mode)
      this.StartCoroutine(this.openPopup00893());
    else
      this.StartCoroutine(this.openPopup008202());
  }

  public void IbtnDeselectAll()
  {
    if (this.IsPush)
      return;
    this.allFriendInfo.ForEach((Action<FriendBarInfo>) (x => x.select = false));
    foreach (Component component in this.allFriendBar)
      component.GetComponent<Friend00819Scroll>().CheckMarkUpdate();
    this.CheckSelect();
  }

  public void IbtnSelectAll()
  {
    if (this.IsPush)
      return;
    this.allFriendInfo.ForEach((Action<FriendBarInfo>) (x => x.select = true));
    foreach (Component component in this.allFriendBar)
      component.GetComponent<Friend00819Scroll>().CheckMarkUpdate();
    this.CheckSelect();
  }

  public void CheckSelect()
  {
    bool flag = false;
    foreach (FriendBarInfo friendBarInfo in this.allFriendInfo)
    {
      if (friendBarInfo.select)
      {
        flag = true;
        break;
      }
    }
    this.btnDecide.isEnabled = flag;
  }

  [DebuggerHidden]
  public IEnumerator InitFriendScroll(PlayerFriend[] friends, bool mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Menu.\u003CInitFriendScroll\u003Ec__Iterator4D0()
    {
      mode = mode,
      friends = friends,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Efriends = friends,
      \u003C\u003Ef__this = this
    };
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
    return (IEnumerator) new Friend00819Menu.\u003CCreateScroll\u003Ec__Iterator4D1()
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
    FriendScrollBar friendScrollBar = this.allFriendBar[bar_index];
    FriendBarInfo info = this.allFriendInfo[info_index];
    ((Friend00819Scroll) friendScrollBar).Set(info.select, this.now, info, this);
  }

  private void RefreshFriendRequests() => this.StartCoroutine(this.RefreshFrendRequestsImpl());

  [DebuggerHidden]
  private IEnumerator RefreshFrendRequestsImpl()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Menu.\u003CRefreshFrendRequestsImpl\u003Ec__Iterator4D2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ReloadFriendRequestsData()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00819Menu.\u003CReloadFriendRequestsData\u003Ec__Iterator4D3 dataCIterator4D3 = new Friend00819Menu.\u003CReloadFriendRequestsData\u003Ec__Iterator4D3();
    return (IEnumerator) dataCIterator4D3;
  }
}
