// Decompiled with JetBrains decompiler
// Type: Story00985Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Story00985Scene.\u003ConStartSceneAsync\u003Ec__Iterator539()
    {
      ID = ID,
      listBack = listBack,
      \u003C\u0024\u003EID = ID,
      \u003C\u0024\u003ElistBack = listBack,
      \u003C\u003Ef__this = this
    };
  }
}
