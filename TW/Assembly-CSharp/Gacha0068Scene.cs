// Decompiled with JetBrains decompiler
// Type: Gacha0068Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Gacha0068Scene : NGSceneBase
{
  private Gacha0068Menu menu;

  public PlayerUnit playerUnit { get; set; }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003ConStartSceneAsync\u003Ec__Iterator45A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit, bool newFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003ConStartSceneAsync\u003Ec__Iterator45B()
    {
      playerUnit = playerUnit,
      newFlag = newFlag,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EnewFlag = newFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit, bool newFlag, bool fixedBG)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003ConStartSceneAsync\u003Ec__Iterator45C()
    {
      fixedBG = fixedBG,
      playerUnit = playerUnit,
      newFlag = newFlag,
      \u003C\u0024\u003EfixedBG = fixedBG,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EnewFlag = newFlag,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  public void onStartScene(PlayerUnit playerUnit, bool newFlag)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  public void onStartScene(PlayerUnit playerUnit, bool newFlag, bool fixedBG)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  [DebuggerHidden]
  public IEnumerator ResultEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003CResultEffect\u003Ec__Iterator45D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetGachaResult()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0068Scene.\u003CSheetGachaResult\u003Ec__Iterator45E resultCIterator45E = new Gacha0068Scene.\u003CSheetGachaResult\u003Ec__Iterator45E();
    return (IEnumerator) resultCIterator45E;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStory()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0068Scene.\u003CCharacterStory\u003Ec__Iterator45F storyCIterator45F = new Gacha0068Scene.\u003CCharacterStory\u003Ec__Iterator45F();
    return (IEnumerator) storyCIterator45F;
  }

  [DebuggerHidden]
  private IEnumerator SetBackGround(bool fixedBG)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003CSetBackGround\u003Ec__Iterator460()
    {
      fixedBG = fixedBG,
      \u003C\u0024\u003EfixedBG = fixedBG,
      \u003C\u003Ef__this = this
    };
  }
}
