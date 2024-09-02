// Decompiled with JetBrains decompiler
// Type: Gacha0068Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Gacha0068Scene.\u003ConStartSceneAsync\u003Ec__Iterator39B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit, bool newFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003ConStartSceneAsync\u003Ec__Iterator39C()
    {
      playerUnit = playerUnit,
      newFlag = newFlag,
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

  [DebuggerHidden]
  public IEnumerator ResultEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003CResultEffect\u003Ec__Iterator39D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetGachaResult()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0068Scene.\u003CSheetGachaResult\u003Ec__Iterator39E resultCIterator39E = new Gacha0068Scene.\u003CSheetGachaResult\u003Ec__Iterator39E();
    return (IEnumerator) resultCIterator39E;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStory()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0068Scene.\u003CCharacterStory\u003Ec__Iterator39F storyCIterator39F = new Gacha0068Scene.\u003CCharacterStory\u003Ec__Iterator39F();
    return (IEnumerator) storyCIterator39F;
  }

  [DebuggerHidden]
  private IEnumerator SetBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Scene.\u003CSetBackGround\u003Ec__Iterator3A0()
    {
      \u003C\u003Ef__this = this
    };
  }
}
