﻿// Decompiled with JetBrains decompiler
// Type: Setting0102Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting0102Scene : NGSceneBase
{
  [SerializeField]
  private Setting0102Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0102Scene.\u003ConInitSceneAsync\u003Ec__Iterator546()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.onEndScene();
}
