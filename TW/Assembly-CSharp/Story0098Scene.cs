﻿// Decompiled with JetBrains decompiler
// Type: Story0098Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0098Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Story0098Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator583 asyncCIterator583 = new Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator583();
    return (IEnumerator) asyncCIterator583;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool connect)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator584()
    {
      connect = connect,
      \u003C\u0024\u003Econnect = connect,
      \u003C\u003Ef__this = this
    };
  }
}
