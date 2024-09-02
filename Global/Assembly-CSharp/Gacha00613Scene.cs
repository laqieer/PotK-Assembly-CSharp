// Decompiled with JetBrains decompiler
// Type: Gacha00613Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Gacha00613Scene.\u003ConEndSceneAsync\u003Ec__Iterator363()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003ConStartSceneAsync\u003Ec__Iterator364()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  [DebuggerHidden]
  public IEnumerator ResultEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003CResultEffect\u003Ec__Iterator365()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetGachaResult()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha00613Scene.\u003CSheetGachaResult\u003Ec__Iterator366 resultCIterator366 = new Gacha00613Scene.\u003CSheetGachaResult\u003Ec__Iterator366();
    return (IEnumerator) resultCIterator366;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStory()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha00613Scene.\u003CCharacterStory\u003Ec__Iterator367 storyCIterator367 = new Gacha00613Scene.\u003CCharacterStory\u003Ec__Iterator367();
    return (IEnumerator) storyCIterator367;
  }

  [DebuggerHidden]
  private IEnumerator SetBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Scene.\u003CSetBackGround\u003Ec__Iterator368()
    {
      \u003C\u003Ef__this = this
    };
  }
}
