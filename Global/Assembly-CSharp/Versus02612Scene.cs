// Decompiled with JetBrains decompiler
// Type: Versus02612Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02612Scene : NGSceneBase
{
  [SerializeField]
  private Versus02612Menu menu;

  public static void ChangeScene(bool stack, int id, int best_class)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_12", (stack ? 1 : 0) != 0, (object) id, (object) best_class);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id, int best_class)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612Scene.\u003ConStartSceneAsync\u003Ec__Iterator57D()
    {
      id = id,
      best_class = best_class,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ebest_class = best_class,
      \u003C\u003Ef__this = this
    };
  }
}
