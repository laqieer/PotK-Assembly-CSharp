// Decompiled with JetBrains decompiler
// Type: Unit004topScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004topScene : NGSceneBase
{
  public Unit004topMenu menu;
  private bool isInit = true;

  public static void ChangeScene(bool isStack)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.changeScene("unit004_top", isStack);
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004topScene.\u003ConInitSceneAsync\u003Ec__Iterator3B0()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void IbtnCpmposite() => Debug.Log((object) "click default event IbtnCpmposite");

  private void IbtnEvolution() => Debug.Log((object) "click default event IbtnEvolution");

  private void IbtnFormation() => Debug.Log((object) "click default event IbtnFormation");

  private void IbtnOverview() => Debug.Log((object) "click default event IbtnOverview");

  private void IbtnSell() => Debug.Log((object) "click default event IbtnSell");

  private void IbtnEquip() => Debug.Log((object) "click default event IbtnEquip");
}
