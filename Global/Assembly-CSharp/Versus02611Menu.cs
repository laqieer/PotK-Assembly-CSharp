// Decompiled with JetBrains decompiler
// Type: Versus02611Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02611Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private NGxScroll scroll;
  private bool is_initialized;

  [DebuggerHidden]
  public IEnumerator Init(WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02611Menu.\u003CInit\u003Ec__Iterator579()
    {
      pvpInfo = pvpInfo,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
