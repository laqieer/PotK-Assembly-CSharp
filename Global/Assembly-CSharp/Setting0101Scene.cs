// Decompiled with JetBrains decompiler
// Type: Setting0101Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting0101Scene : NGSceneBase
{
  [SerializeField]
  private Setting0101Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0101Scene.\u003ConInitSceneAsync\u003Ec__Iterator49E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0101Scene.\u003ConEndSceneAsync\u003Ec__Iterator49F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
