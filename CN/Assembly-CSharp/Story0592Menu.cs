// Decompiled with JetBrains decompiler
// Type: Story0592Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0592Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIGrid mGrid;
  [SerializeField]
  private UIScrollView mScrollView;
  private GameObject mScrollParts;

  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0592Menu.\u003CInitSceneAsync\u003Ec__Iterator798()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0592Menu.\u003CStartSceneAsync\u003Ec__Iterator799()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
