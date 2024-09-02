// Decompiled with JetBrains decompiler
// Type: Story00985Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00985Scene : NGSceneBase
{
  [SerializeField]
  private Story00985Menu menu;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int ID, bool listBack)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00985Scene.\u003ConStartSceneAsync\u003Ec__Iterator589()
    {
      ID = ID,
      listBack = listBack,
      \u003C\u0024\u003EID = ID,
      \u003C\u0024\u003ElistBack = listBack,
      \u003C\u003Ef__this = this
    };
  }
}
