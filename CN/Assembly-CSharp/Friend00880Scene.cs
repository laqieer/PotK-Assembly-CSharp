﻿// Decompiled with JetBrains decompiler
// Type: Friend00880Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00880Scene : NGSceneBase
{
  [SerializeField]
  private Friend00880Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00880Scene.\u003ConStartSceneAsync\u003Ec__Iterator4F1()
    {
      \u003C\u003Ef__this = this
    };
  }
}
