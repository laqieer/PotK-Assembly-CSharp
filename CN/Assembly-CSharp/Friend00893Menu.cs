﻿// Decompiled with JetBrains decompiler
// Type: Friend00893Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00893Menu : BackButtonMenuBase
{
  [SerializeField]
  private string[] friend_ids;
  private Action<PlayerFriend[]> callback;

  public void setData(string[] friend_ids, Action<PlayerFriend[]> callback)
  {
    this.friend_ids = friend_ids;
    this.callback = callback;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00894()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00893Menu.\u003CopenPopup00894\u003Ec__Iterator4DD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.openPopup00894());
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
