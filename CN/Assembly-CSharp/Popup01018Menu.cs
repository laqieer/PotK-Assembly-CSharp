﻿// Decompiled with JetBrains decompiler
// Type: Popup01018Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup01018Menu : NGMenuBase
{
  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01018Menu.\u003CInit\u003Ec__Iterator93E initCIterator93E = new Popup01018Menu.\u003CInit\u003Ec__Iterator93E();
    return (IEnumerator) initCIterator93E;
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
