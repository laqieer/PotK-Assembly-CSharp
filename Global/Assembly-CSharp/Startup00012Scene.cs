// Decompiled with JetBrains decompiler
// Type: Startup00012Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00012Scene : NGSceneBase
{
  [SerializeField]
  private Startup00012Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator12E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int info_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator12F()
    {
      info_id = info_id,
      \u003C\u0024\u003Einfo_id = info_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(OfficialInformationArticle info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator130()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => DetailController.Release();
}
