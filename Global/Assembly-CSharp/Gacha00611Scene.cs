// Decompiled with JetBrains decompiler
// Type: Gacha00611Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Gacha00611Scene : NGSceneBase
{
  private Gacha00611Menu menu;
  private bool isPlay;

  public static void changeScene(bool stack, bool newflag, PlayerItem revTargetData)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", (stack ? 1 : 0) != 0, (object) newflag, (object) revTargetData);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConInitSceneAsync\u003Ec__Iterator35D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConStartSceneAsync\u003Ec__Iterator35E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool NewFlag, PlayerItem TargetData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConStartSceneAsync\u003Ec__Iterator35F()
    {
      NewFlag = NewFlag,
      TargetData = TargetData,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u0024\u003ETargetData = TargetData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool NewFlag, PlayerItem TargetData, PlayerItem baseData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Scene.\u003ConStartSceneAsync\u003Ec__Iterator360()
    {
      TargetData = TargetData,
      NewFlag = NewFlag,
      baseData = baseData,
      \u003C\u0024\u003ETargetData = TargetData,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u0024\u003EbaseData = baseData,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => Singleton<PopupManager>.GetInstance().closeAll();

  public void onStartScene(bool NewFlag, PlayerItem TargetData)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public void onStartScene(bool NewFlag, PlayerItem TargetData, PlayerItem baseData)
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
}
