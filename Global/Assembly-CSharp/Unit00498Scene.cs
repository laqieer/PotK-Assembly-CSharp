// Decompiled with JetBrains decompiler
// Type: Unit00498Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00498Scene : NGSceneBase
{
  [SerializeField]
  private Unit00498Menu menu;

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    Unit00499Scene.Mode mode,
    bool fromEarth)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_9_8", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) resultPlayerUnit, (object) fromEarth);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00498Scene.\u003ConInitSceneAsync\u003Ec__Iterator2ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    Unit00499Scene.Mode mode,
    bool fromEarth)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.CharacterStory());
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit resultPlayerUnit,
    Unit00499Scene.Mode mode,
    bool fromEarth)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00498Scene.\u003ConStartSceneAsync\u003Ec__Iterator2EE()
    {
      basePlayerUnit = basePlayerUnit,
      resultPlayerUnit = resultPlayerUnit,
      mode = mode,
      fromEarth = fromEarth,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EresultPlayerUnit = resultPlayerUnit,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CharacterStory()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit00498Scene.\u003CCharacterStory\u003Ec__Iterator2EF storyCIterator2Ef = new Unit00498Scene.\u003CCharacterStory\u003Ec__Iterator2EF();
    return (IEnumerator) storyCIterator2Ef;
  }
}
