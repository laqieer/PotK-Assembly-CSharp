// Decompiled with JetBrains decompiler
// Type: Unit00493Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00493Scene : NGSceneBase
{
  public Unit00493Menu menu;

  public static void changeScene(
    bool stack,
    UnitUnit MaterialEvolution,
    bool NewFlag = false,
    bool isGacha = false)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("Unit004_9_3", (stack ? 1 : 0) != 0, (object) MaterialEvolution, (object) NewFlag, (object) isGacha);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit00493Scene.\u003ConInitSceneAsync\u003Ec__Iterator350 asyncCIterator350 = new Unit00493Scene.\u003ConInitSceneAsync\u003Ec__Iterator350();
    return (IEnumerator) asyncCIterator350;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(UnitUnit MaterialEvolution, bool NewFlag, bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00493Scene.\u003ConStartSceneAsync\u003Ec__Iterator351()
    {
      isGacha = isGacha,
      MaterialEvolution = MaterialEvolution,
      NewFlag = NewFlag,
      \u003C\u0024\u003EisGacha = isGacha,
      \u003C\u0024\u003EMaterialEvolution = MaterialEvolution,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u003Ef__this = this
    };
  }
}
