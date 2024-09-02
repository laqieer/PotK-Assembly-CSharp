// Decompiled with JetBrains decompiler
// Type: Unit0543Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0543Scene : NGSceneBase
{
  [SerializeField]
  private Unit0043Menu menu;

  public static void changeScene(bool stack, PlayerUnit unit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_3", (stack ? 1 : 0) != 0, (object) unit);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0543Scene.\u003ConInitSceneAsync\u003Ec__Iterator624()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0543Scene.\u003ConStartSceneAsync\u003Ec__Iterator625()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }
}
