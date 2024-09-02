// Decompiled with JetBrains decompiler
// Type: Story0099Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0099Scene : NGSceneBase
{
  [SerializeField]
  private Story0099Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Scene.\u003ConStartSceneAsync\u003Ec__Iterator540()
    {
      \u003C\u003Ef__this = this
    };
  }
}
