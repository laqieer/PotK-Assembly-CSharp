// Decompiled with JetBrains decompiler
// Type: Story0098Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0098Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Story0098Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator533 asyncCIterator533 = new Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator533();
    return (IEnumerator) asyncCIterator533;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool connect)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0098Scene.\u003ConStartSceneAsync\u003Ec__Iterator534()
    {
      connect = connect,
      \u003C\u0024\u003Econnect = connect,
      \u003C\u003Ef__this = this
    };
  }
}
