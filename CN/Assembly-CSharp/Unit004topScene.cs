// Decompiled with JetBrains decompiler
// Type: Unit004topScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Unit004topScene.\u003ConInitSceneAsync\u003Ec__Iterator36F()
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
