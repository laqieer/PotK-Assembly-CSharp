// Decompiled with JetBrains decompiler
// Type: Friend0089Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Friend0089Menu : BackButtonMenuBase
{
  private List<string> target_friend_ids = new List<string>();
  public bool is_back = true;
  private System.Action callback;

  public void SetBack(bool back) => this.is_back = back;

  public void InitPopup(string id, System.Action callback = null)
  {
    this.target_friend_ids.Add(id);
    this.callback = callback;
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.openPopup00892());
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator openPopup00892()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0089Menu.\u003CopenPopup00892\u003Ec__Iterator52D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
