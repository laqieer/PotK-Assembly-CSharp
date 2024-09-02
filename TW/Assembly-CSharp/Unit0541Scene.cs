// Decompiled with JetBrains decompiler
// Type: Unit0541Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0541Scene : NGSceneBase
{
  [SerializeField]
  private Unit0541Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_1");
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0541Scene.\u003ConInitSceneAsync\u003Ec__Iterator826()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0541Scene.\u003ConStartSceneAsync\u003Ec__Iterator827()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => Singleton<CommonRoot>.GetInstance().isLoading = false;

  public override void onEndScene()
  {
  }
}
