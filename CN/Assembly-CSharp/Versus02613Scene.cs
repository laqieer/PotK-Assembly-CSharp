// Decompiled with JetBrains decompiler
// Type: Versus02613Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02613Scene : NGSceneBase
{
  [SerializeField]
  private Versus02613Menu menu;

  public static void ChangeScene(bool stack, PvPClassRecord info)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_13", (stack ? 1 : 0) != 0, (object) info);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02613Scene.\u003ConInitSceneAsync\u003Ec__Iterator63C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02613Scene.\u003ConStartSceneAsync\u003Ec__Iterator63D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PvPClassRecord info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02613Scene.\u003ConStartSceneAsync\u003Ec__Iterator63E()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }
}
