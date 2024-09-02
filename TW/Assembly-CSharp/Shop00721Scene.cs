// Decompiled with JetBrains decompiler
// Type: Shop00721Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00721Scene : NGSceneBase
{
  [SerializeField]
  private Shop00721Menu menu;
  private bool isInit = true;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00721Scene.\u003ConInitSceneAsync\u003Ec__Iterator4AB()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void changeScene(bool stack, bool isUpdate)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_21", (stack ? 1 : 0) != 0, (object) isUpdate);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isUpdate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00721Scene.\u003ConStartSceneAsync\u003Ec__Iterator4AC()
    {
      isUpdate = isUpdate,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }
}
