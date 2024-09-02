// Decompiled with JetBrains decompiler
// Type: Story00983Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00983Scene : NGSceneBase
{
  [SerializeField]
  private Story00983Menu menu;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int ID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00983Scene.\u003ConStartSceneAsync\u003Ec__Iterator587()
    {
      ID = ID,
      \u003C\u0024\u003EID = ID,
      \u003C\u003Ef__this = this
    };
  }
}
