// Decompiled with JetBrains decompiler
// Type: Versus02611Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02611Scene : NGSceneBase
{
  [SerializeField]
  private Versus02611Menu menu;

  public static void ChangeScene(bool stack, WebAPI.Response.PvpBoot pvpInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_11", (stack ? 1 : 0) != 0, (object) pvpInfo);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02611Scene.\u003ConStartSceneAsync\u003Ec__Iterator62B()
    {
      pvpInfo = pvpInfo,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }
}
