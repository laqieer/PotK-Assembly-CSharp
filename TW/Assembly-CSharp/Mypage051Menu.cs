// Decompiled with JetBrains decompiler
// Type: Mypage051Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Mypage051Menu : MypageMenu
{
  private readonly List<int> baseVoiceIDList = new List<int>()
  {
    52,
    53,
    54
  };

  [DebuggerHidden]
  protected override IEnumerator CreateJogDial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CCreateJogDial\u003Ec__Iterator7F8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CInitSceneAsync\u003Ec__Iterator7F9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator InitOne()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CInitOne\u003Ec__Iterator7FA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CharcterAnimationSetting(bool isCloudAnim, int tweenID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CCharcterAnimationSetting\u003Ec__Iterator7FB()
    {
      isCloudAnim = isCloudAnim,
      tweenID = tweenID,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u0024\u003EtweenID = tweenID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator StartSceneAsync(bool isCloudAnim, bool isReservedEventScript)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Menu.\u003CStartSceneAsync\u003Ec__Iterator7FC()
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
    Mypage051Menu.\u003CShowBattleRestartPopup\u003Ec__Iterator7FD popupCIterator7Fd = new Mypage051Menu.\u003CShowBattleRestartPopup\u003Ec__Iterator7FD();
    return (IEnumerator) popupCIterator7Fd;
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
    return (IEnumerator) new Mypage051Menu.\u003CCloudAnimationStart\u003Ec__Iterator7FE()
    {
      \u003C\u003Ef__this = this
    };
  }
}
