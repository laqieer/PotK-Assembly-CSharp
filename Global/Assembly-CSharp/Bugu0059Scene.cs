// Decompiled with JetBrains decompiler
// Type: Bugu0059Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Bugu0059Scene : NGSceneBase
{
  private Bugu0059Menu menu;
  private bool resetFlag;

  public static void changeScene(bool stack, PlayerItem baseGear)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9", (stack ? 1 : 0) != 0, (object) baseGear, null);
  }

  public static void changeScene(bool stack, PlayerItem baseGear, List<PlayerItem> materials)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9", (stack ? 1 : 0) != 0, (object) baseGear, (object) materials);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Scene.\u003ConInitSceneAsync\u003Ec__Iterator358()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem baseGear, List<PlayerItem> materials)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Scene.\u003ConStartSceneAsync\u003Ec__Iterator359()
    {
      baseGear = baseGear,
      materials = materials,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u0024\u003Ematerials = materials,
      \u003C\u003Ef__this = this
    };
  }

  public void SetResetFlag() => this.resetFlag = true;
}
