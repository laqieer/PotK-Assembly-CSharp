// Decompiled with JetBrains decompiler
// Type: Startup00012Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator171()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int info_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator172()
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
    return (IEnumerator) new Startup00012Scene.\u003ConStartSceneAsync\u003Ec__Iterator173()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }
}
