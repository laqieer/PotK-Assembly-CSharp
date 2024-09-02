// Decompiled with JetBrains decompiler
// Type: Versus0261Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Versus0261Scene.\u003ConInitSceneAsync\u003Ec__Iterator659()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0261Scene.\u003ConStartSceneAsync\u003Ec__Iterator65A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
