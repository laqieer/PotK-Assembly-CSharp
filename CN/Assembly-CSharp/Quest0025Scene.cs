﻿// Decompiled with JetBrains decompiler
// Type: Quest0025Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest0025Scene : NGSceneBase
{
  public Quest0025Menu menu;

  public static void changeScene0025(bool stack, int L, bool Hard)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_5", (stack ? 1 : 0) != 0, (object) L, (object) Hard);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int L, bool Hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0025Scene.\u003ConStartSceneAsync\u003Ec__Iterator276()
    {
      L = L,
      Hard = Hard,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EHard = Hard,
      \u003C\u003Ef__this = this
    };
  }
}
