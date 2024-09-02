// Decompiled with JetBrains decompiler
// Type: Versus02622Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Versus02622Scene.\u003ConInitSceneAsync\u003Ec__Iterator59D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Scene.\u003ConStartSceneAsync\u003Ec__Iterator59E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PvPRecord freeInfo, PvPRecord friendInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Scene.\u003ConStartSceneAsync\u003Ec__Iterator59F()
    {
      freeInfo = freeInfo,
      friendInfo = friendInfo,
      \u003C\u0024\u003EfreeInfo = freeInfo,
      \u003C\u0024\u003EfriendInfo = friendInfo,
      \u003C\u003Ef__this = this
    };
  }
}
