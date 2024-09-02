// Decompiled with JetBrains decompiler
// Type: Friend0083Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0083Menu : BackButtonMenuBase
{
  private List<string> target_friend_ids = new List<string>();

  public void AddTargetFriendId(string id) => this.target_friend_ids.Add(id);

  [DebuggerHidden]
  private IEnumerator FriendRemoveAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0083Menu.\u003CFriendRemoveAsync\u003Ec__Iterator530()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void RemoveError(string err)
  {
    Debug.LogWarning((object) ("FriendRemove API ERROR CODE : " + err));
    if (err == "FRD012")
      Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.FriendRemoveAsync());
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
