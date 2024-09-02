// Decompiled with JetBrains decompiler
// Type: Unit0549Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0549Scene : NGSceneBase
{
  [SerializeField]
  private Unit0549Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_9", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit0549Scene.\u003ConInitSceneAsync\u003Ec__Iterator635 asyncCIterator635 = new Unit0549Scene.\u003ConInitSceneAsync\u003Ec__Iterator635();
    return (IEnumerator) asyncCIterator635;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0549Scene.\u003ConStartSceneAsync\u003Ec__Iterator636()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }
}
