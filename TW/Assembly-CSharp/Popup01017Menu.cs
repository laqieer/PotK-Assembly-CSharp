﻿// Decompiled with JetBrains decompiler
// Type: Popup01017Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup01017Menu : NGMenuBase
{
  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01017Menu.\u003CInit\u003Ec__IteratorA11 initCIteratorA11 = new Popup01017Menu.\u003CInit\u003Ec__IteratorA11();
    return (IEnumerator) initCIteratorA11;
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
