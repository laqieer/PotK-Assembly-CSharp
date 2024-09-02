// Decompiled with JetBrains decompiler
// Type: Colosseum0236Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum0236Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum0236Menu menu;

  public static void ChangeScene(ColosseumUtility.Info info)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_6", false, (object) info);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0236Scene.\u003ConInitSceneAsync\u003Ec__Iterator630()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0236Scene.\u003ConStartSceneAsync\u003Ec__Iterator631()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ColosseumUtility.Info info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0236Scene.\u003ConStartSceneAsync\u003Ec__Iterator632()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }
}
