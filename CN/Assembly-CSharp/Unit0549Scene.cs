// Decompiled with JetBrains decompiler
// Type: Unit0549Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Unit0549Scene.\u003ConInitSceneAsync\u003Ec__Iterator77C asyncCIterator77C = new Unit0549Scene.\u003ConInitSceneAsync\u003Ec__Iterator77C();
    return (IEnumerator) asyncCIterator77C;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0549Scene.\u003ConStartSceneAsync\u003Ec__Iterator77D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }
}
