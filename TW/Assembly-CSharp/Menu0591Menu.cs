﻿// Decompiled with JetBrains decompiler
// Type: Menu0591Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Menu0591Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scrollContainer;

  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Menu0591Menu.\u003CInitSceneAsync\u003Ec__Iterator85D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Menu0591Menu.\u003CStartSceneAsync\u003Ec__Iterator85E asyncCIterator85E = new Menu0591Menu.\u003CStartSceneAsync\u003Ec__Iterator85E();
    return (IEnumerator) asyncCIterator85E;
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Mypage051Scene.ChangeScene(false, false);
  }

  public void onHelpClick()
  {
    if (this.IsPushAndSet())
      return;
    Help0151Scene.ChangeScene(true);
  }

  public void onDetaResetClick()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowDetaResetPopup());
  }

  public void onStoryClick()
  {
    if (this.IsPushAndSet())
      return;
    Story0592Scene.ChangeScene(true);
  }

  [DebuggerHidden]
  private IEnumerator ShowDetaResetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Menu0591Menu.\u003CShowDetaResetPopup\u003Ec__Iterator85F popupCIterator85F = new Menu0591Menu.\u003CShowDetaResetPopup\u003Ec__Iterator85F();
    return (IEnumerator) popupCIterator85F;
  }
}
