﻿// Decompiled with JetBrains decompiler
// Type: Popup99914Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup99914Menu : NGMenuBase
{
  [SerializeField]
  private UI2DSprite Emblem;
  protected System.Action onCallback;

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  public IEnumerator Init(PlayerEmblem emblem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup99914Menu.\u003CInit\u003Ec__Iterator80F()
    {
      emblem = emblem,
      \u003C\u0024\u003Eemblem = emblem,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
