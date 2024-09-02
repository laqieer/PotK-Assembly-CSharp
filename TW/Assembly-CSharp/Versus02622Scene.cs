// Decompiled with JetBrains decompiler
// Type: Versus02622Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02622Scene : NGSceneBase
{
  [SerializeField]
  private Versus02622Menu menu;

  public static void ChangeScene(bool stack, PvPRecord freeInfo, PvPRecord friendInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_2_2", (stack ? 1 : 0) != 0, (object) freeInfo, (object) friendInfo);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Scene.\u003ConInitSceneAsync\u003Ec__Iterator69A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Scene.\u003ConStartSceneAsync\u003Ec__Iterator69B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PvPRecord freeInfo, PvPRecord friendInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Scene.\u003ConStartSceneAsync\u003Ec__Iterator69C()
    {
      freeInfo = freeInfo,
      friendInfo = friendInfo,
      \u003C\u0024\u003EfreeInfo = freeInfo,
      \u003C\u0024\u003EfriendInfo = friendInfo,
      \u003C\u003Ef__this = this
    };
  }
}
