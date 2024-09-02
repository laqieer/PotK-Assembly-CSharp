// Decompiled with JetBrains decompiler
// Type: Startup000144Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup000144Scene : NGSceneBase
{
  public Startup000144Menu menu;
  public Transform middleTransform;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000144Scene.\u003ConInitSceneAsync\u003Ec__Iterator183()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerLoginBonus loginBonus)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000144Scene.\u003ConStartSceneAsync\u003Ec__Iterator184()
    {
      loginBonus = loginBonus,
      \u003C\u0024\u003EloginBonus = loginBonus,
      \u003C\u003Ef__this = this
    };
  }
}
