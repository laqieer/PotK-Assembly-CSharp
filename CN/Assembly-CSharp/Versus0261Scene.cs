// Decompiled with JetBrains decompiler
// Type: Versus0261Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus0261Scene : NGSceneBase
{
  [SerializeField]
  private Versus0261Menu menu;

  public static void ChangeScene0261(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_1", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Scene.\u003ConInitSceneAsync\u003Ec__Iterator60C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Scene.\u003ConStartSceneAsync\u003Ec__Iterator60D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
