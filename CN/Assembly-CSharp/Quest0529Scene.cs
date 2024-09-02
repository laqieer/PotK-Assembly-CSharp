// Decompiled with JetBrains decompiler
// Type: Quest0529Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Quest0529Scene.\u003ConInitSceneAsync\u003Ec__Iterator75B asyncCIterator75B = new Quest0529Scene.\u003ConInitSceneAsync\u003Ec__Iterator75B();
    return (IEnumerator) asyncCIterator75B;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int maxNum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Scene.\u003ConStartSceneAsync\u003Ec__Iterator75C()
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
