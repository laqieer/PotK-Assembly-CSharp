﻿// Decompiled with JetBrains decompiler
// Type: Friend00819Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00819Scene : NGSceneBase
{
  [SerializeField]
  private Friend00819Menu menu;
  private static bool mode;

  public static void ChangeSceneApproval(bool stack)
  {
    Friend00819Scene.mode = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_19", (stack ? 1 : 0) != 0, (object) Friend00819Scene.mode);
  }

  public static void ChangeSceneDenial(bool stack)
  {
    Friend00819Scene.mode = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_19", (stack ? 1 : 0) != 0, (object) Friend00819Scene.mode);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00819Scene.\u003ConStartSceneAsync\u003Ec__Iterator523()
    {
      mode = mode,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }
}
