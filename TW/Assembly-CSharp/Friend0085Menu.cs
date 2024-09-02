// Decompiled with JetBrains decompiler
// Type: Friend0085Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0085Menu : FriendBarBase
{
  private const int Width = 612;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 5;
  [SerializeField]
  private GameObject DirBulk;
  private Modified<PlayerFriend[]> friendsM;

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<NGSceneManager>.GetInstance().backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnBulkApproval()
  {
    if (this.IsPushAndSet())
      return;
    Friend00819Scene.ChangeSceneApproval(false);
    Singleton<NGSceneManager>.GetInstance().destroyScene("friend008_5");
  }

  public void IbtnBulkDenial()
  {
    if (this.IsPushAndSet())
      return;
    Friend00819Scene.ChangeSceneDenial(false);
    Singleton<NGSceneManager>.GetInstance().destroyScene("friend008_5");
  }

  [DebuggerHidden]
  public IEnumerator InitFriendScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Menu.\u003CInitFriendScroll\u003Ec__Iterator526()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public IEnumerator ResetScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Menu.\u003CResetScroll\u003Ec__Iterator527()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResetScrollEvent() => this.StartCoroutine(this.ResetScroll());

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Menu.\u003CCreateScroll\u003Ec__Iterator528()
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
    ((FriendScrollParts) this.allFriendBar[bar_index]).Set(this);
  }
}
