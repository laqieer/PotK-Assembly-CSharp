// Decompiled with JetBrains decompiler
// Type: Story0095Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0095Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Story0095Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Story0095Scene.\u003ConStartSceneAsync\u003Ec__Iterator486 asyncCIterator486 = new Story0095Scene.\u003ConStartSceneAsync\u003Ec__Iterator486();
    return (IEnumerator) asyncCIterator486;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool connect)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0095Scene.\u003ConStartSceneAsync\u003Ec__Iterator487()
    {
      connect = connect,
      \u003C\u0024\u003Econnect = connect,
      \u003C\u003Ef__this = this
    };
  }
}
