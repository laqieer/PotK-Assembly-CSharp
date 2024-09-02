// Decompiled with JetBrains decompiler
// Type: Mypage051Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Mypage051Menu : MypageMenu
{
  [DebuggerHidden]
  protected override IEnumerator CreateJogDial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CCreateJogDial\u003Ec__Iterator5F5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CInitSceneAsync\u003Ec__Iterator5F6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator InitOne()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CInitOne\u003Ec__Iterator5F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CharcterAnimationSetting(bool isCloudAnim, int tweenID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CCharcterAnimationSetting\u003Ec__Iterator5F8()
    {
      isCloudAnim = isCloudAnim,
      tweenID = tweenID,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u0024\u003EtweenID = tweenID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator StartSceneAsync(bool isCloudAnim)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CStartSceneAsync\u003Ec__Iterator5F9()
    {
      isCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u003Ef__this = this
    };
  }

  protected override void JogDialSetting()
  {
    this.CirculButton.Init(this.Story_Container);
    this.Story_Container.ChangeState(true);
    if (!Singleton<EarthDataManager>.GetInstance().questProgress.isCleared)
      return;
    this.Story_Container.ChangeState(false);
  }

  [DebuggerHidden]
  private IEnumerator ShowBattleRestartPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Mypage051Menu.\u003CShowBattleRestartPopup\u003Ec__Iterator5FA popupCIterator5Fa = new Mypage051Menu.\u003CShowBattleRestartPopup\u003Ec__Iterator5FA();
    return (IEnumerator) popupCIterator5Fa;
  }

  protected override void AllCircleTweenFinished()
  {
    base.AllCircleTweenFinished();
    if (!Persist.earthBattleEnvironment.Exists)
      return;
    this.StartCoroutine(this.ShowBattleRestartPopup());
  }

  [DebuggerHidden]
  public override IEnumerator CloudAnimationStart()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CCloudAnimationStart\u003Ec__Iterator5FB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
