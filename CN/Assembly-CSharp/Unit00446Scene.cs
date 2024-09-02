// Decompiled with JetBrains decompiler
// Type: Unit00446Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00446Scene : NGSceneBase
{
  public Unit00446Menu menu;

  public static void changeScene(bool stack, PlayerItem targetGear)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_6", (stack ? 1 : 0) != 0, (object) targetGear);
  }

  public static void changeScene(bool stack, GearGear targetgear)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_6", (stack ? 1 : 0) != 0, (object) targetgear);
  }

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_6");
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00446Scene.\u003ConStartSceneAsync\u003Ec__Iterator2DE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem targetGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00446Scene.\u003ConStartSceneAsync\u003Ec__Iterator2DF()
    {
      targetGear = targetGear,
      \u003C\u0024\u003EtargetGear = targetGear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear targetgear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00446Scene.\u003ConStartSceneAsync\u003Ec__Iterator2E0()
    {
      targetgear = targetgear,
      \u003C\u0024\u003Etargetgear = targetgear,
      \u003C\u003Ef__this = this
    };
  }
}
