// Decompiled with JetBrains decompiler
// Type: Menu0591Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Menu0591Menu.\u003CInitSceneAsync\u003Ec__Iterator792()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Menu0591Menu.\u003CStartSceneAsync\u003Ec__Iterator793 asyncCIterator793 = new Menu0591Menu.\u003CStartSceneAsync\u003Ec__Iterator793();
    return (IEnumerator) asyncCIterator793;
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
    Menu0591Menu.\u003CShowDetaResetPopup\u003Ec__Iterator794 popupCIterator794 = new Menu0591Menu.\u003CShowDetaResetPopup\u003Ec__Iterator794();
    return (IEnumerator) popupCIterator794;
  }
}
