﻿// Decompiled with JetBrains decompiler
// Type: Quest00215Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00215Scene : NGSceneBase
{
  [SerializeField]
  private Quest00215Menu menu;
  private bool doneDisplay;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215Scene.\u003ConStartSceneAsync\u003Ec__Iterator203()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215Scene.\u003ConStartSceneAsync\u003Ec__Iterator204()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
