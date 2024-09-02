// Decompiled with JetBrains decompiler
// Type: Gacha00611Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Gacha00611Scene : NGSceneBase
{
  private Gacha00611Menu menu;
  private bool isPlay;

  public static void changeScene(bool stack, bool newflag, GameCore.ItemInfo revTargetData)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", (stack ? 1 : 0) != 0, (object) newflag, (object) revTargetData);
  }

  public static void ChangeScene(
    bool stack,
    bool newFlag,
    GameCore.ItemInfo TargetData,
    GameCore.ItemInfo baseData,
    System.Action backSceneCallback)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", (stack ? 1 : 0) != 0, (object) newFlag, (object) TargetData, (object) baseData, (object) backSceneCallback);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConInitSceneAsync\u003Ec__Iterator41A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool NewFlag, GameCore.ItemInfo TargetData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConStartSceneAsync\u003Ec__Iterator41B()
    {
      NewFlag = NewFlag,
      TargetData = TargetData,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u0024\u003ETargetData = TargetData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    bool NewFlag,
    GameCore.ItemInfo TargetData,
    GameCore.ItemInfo baseData,
    System.Action backSceneCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConStartSceneAsync\u003Ec__Iterator41C()
    {
      TargetData = TargetData,
      NewFlag = NewFlag,
      baseData = baseData,
      backSceneCallback = backSceneCallback,
      \u003C\u0024\u003ETargetData = TargetData,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u0024\u003EbaseData = baseData,
      \u003C\u0024\u003EbackSceneCallback = backSceneCallback,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => Singleton<PopupManager>.GetInstance().closeAll();

  public void onStartScene(bool NewFlag, GameCore.ItemInfo TargetData)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public void onStartScene(
    bool NewFlag,
    GameCore.ItemInfo TargetData,
    GameCore.ItemInfo baseData,
    System.Action backSceneCallback)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.isPlay = true;
  }

  public override void onSceneInitialized()
  {
    if (!this.isPlay)
      return;
    this.menu.StartAnime();
  }

  public override void onEndScene() => this.menu.StopAnime();
}
