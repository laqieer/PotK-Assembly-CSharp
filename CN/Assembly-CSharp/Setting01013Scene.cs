// Decompiled with JetBrains decompiler
// Type: Setting01013Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting01013Scene : NGSceneBase
{
  [SerializeField]
  private Setting01013Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting01013Scene.\u003ConInitSceneAsync\u003Ec__Iterator544()
    {
      \u003C\u003Ef__this = this
    };
  }
}
