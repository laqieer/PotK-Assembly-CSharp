// Decompiled with JetBrains decompiler
// Type: Guild02871Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02871Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel sceneTitle;
  [SerializeField]
  private NGxScrollMasonry Scroll;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02871Menu.\u003CInitializeAsync\u003Ec__Iterator721()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize() => Singleton<CommonRoot>.GetInstance().isLoading = false;

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
