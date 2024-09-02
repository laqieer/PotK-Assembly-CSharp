// Decompiled with JetBrains decompiler
// Type: Unit00446Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00446Scene : NGSceneBase
{
  public Unit00446Menu menu;

  public static void changeScene(bool stack, GearGear targetgear)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_6", (stack ? 1 : 0) != 0, (object) targetgear);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear targetgear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00446Scene.\u003ConStartSceneAsync\u003Ec__Iterator31E()
    {
      targetgear = targetgear,
      \u003C\u0024\u003Etargetgear = targetgear,
      \u003C\u003Ef__this = this
    };
  }
}
