﻿// Decompiled with JetBrains decompiler
// Type: Unit05499Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05499Scene : NGSceneBase
{
  [SerializeField]
  private Unit05499Menu menu;

  public static void ChangeScene(bool stack, PlayerUnit selectUnit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_9_9", (stack ? 1 : 0) != 0, (object) selectUnit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit selectUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05499Scene.\u003ConStartSceneAsync\u003Ec__Iterator63A()
    {
      selectUnit = selectUnit,
      \u003C\u0024\u003EselectUnit = selectUnit,
      \u003C\u003Ef__this = this
    };
  }
}
