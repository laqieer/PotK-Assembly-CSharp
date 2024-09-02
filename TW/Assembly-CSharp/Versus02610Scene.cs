﻿// Decompiled with JetBrains decompiler
// Type: Versus02610Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02610Scene : NGSceneBase
{
  [SerializeField]
  private Versus02610Menu menu;
  private static bool is_loading_draw;
  private WebAPI.Response.PvpBoot pvpInfo;

  public static void ChangeScene(bool stack, bool loading_draw, bool isContinue = false)
  {
    Versus02610Scene.is_loading_draw = loading_draw;
    Versus02610Menu.IsContinue = isContinue;
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_10", stack);
  }

  public static void ChangeScene(bool stack, WebAPI.Response.PvpBoot pvpInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_10", (stack ? 1 : 0) != 0, (object) pvpInfo);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Scene.\u003ConInitSceneAsync\u003Ec__Iterator66F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Scene.\u003ConStartSceneAsync\u003Ec__Iterator670()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02610Scene.\u003ConStartSceneAsync\u003Ec__Iterator671()
    {
      pvpInfo = pvpInfo,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    if (!this.menu.IsUpdate)
      return;
    this.pvpInfo = this.menu.UpdatePvpInfo;
  }
}
