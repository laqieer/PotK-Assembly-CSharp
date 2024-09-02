// Decompiled with JetBrains decompiler
// Type: Gacha00613Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Gacha00613Scene : NGSceneBase
{
  public Gacha00613Menu Menu;

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003ConEndSceneAsync\u003Ec__Iterator420()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003ConStartSceneAsync\u003Ec__Iterator421()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  public void onStartScene(
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId_)
  {
    this.onStartScene();
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    string gachaModuleName,
    Consts.GachaType gachaType,
    int gachaModuleGachaId_)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003ConStartSceneAsync\u003Ec__Iterator422()
    {
      gachaModuleName = gachaModuleName,
      gachaType = gachaType,
      gachaModuleGachaId_ = gachaModuleGachaId_,
      \u003C\u0024\u003EgachaModuleName = gachaModuleName,
      \u003C\u0024\u003EgachaType = gachaType,
      \u003C\u0024\u003EgachaModuleGachaId_ = gachaModuleGachaId_,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ResultEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003CResultEffect\u003Ec__Iterator423()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetGachaResult()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha00613Scene.\u003CSheetGachaResult\u003Ec__Iterator424 resultCIterator424 = new Gacha00613Scene.\u003CSheetGachaResult\u003Ec__Iterator424();
    return (IEnumerator) resultCIterator424;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStory()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha00613Scene.\u003CCharacterStory\u003Ec__Iterator425 storyCIterator425 = new Gacha00613Scene.\u003CCharacterStory\u003Ec__Iterator425();
    return (IEnumerator) storyCIterator425;
  }

  [DebuggerHidden]
  private IEnumerator SetBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003CSetBackGround\u003Ec__Iterator426()
    {
      \u003C\u003Ef__this = this
    };
  }
}
