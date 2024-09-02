// Decompiled with JetBrains decompiler
// Type: Quest0529Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0529Scene : NGSceneBase
{
  [SerializeField]
  private Quest0529Menu menu;
  private bool isInit = true;

  public static void ChangeScene(bool stack, int maxNum = -1)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest052_9", (stack ? 1 : 0) != 0, (object) maxNum);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0529Scene.\u003ConInitSceneAsync\u003Ec__Iterator822 asyncCIterator822 = new Quest0529Scene.\u003ConInitSceneAsync\u003Ec__Iterator822();
    return (IEnumerator) asyncCIterator822;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int maxNum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Scene.\u003ConStartSceneAsync\u003Ec__Iterator823()
    {
      maxNum = maxNum,
      \u003C\u0024\u003EmaxNum = maxNum,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(int maxNum)
  {
  }

  public override void onEndScene()
  {
  }
}
