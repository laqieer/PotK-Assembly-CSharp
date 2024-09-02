// Decompiled with JetBrains decompiler
// Type: Popup02610Base
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup02610Base : BackButtonMenuBase
{
  protected WebAPI.Response.PvpBoot pvpInfo;
  protected Versus02610Menu menu;

  public virtual void Init(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    this.pvpInfo = pvpInfo;
    this.menu = menu;
  }

  [DebuggerHidden]
  public virtual IEnumerator InitCoroutine(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02610Base.\u003CInitCoroutine\u003Ec__Iterator7EA()
    {
      pvpInfo = pvpInfo,
      menu = menu,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Return2688Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02610Base.\u003CReturn2688Popup\u003Ec__Iterator7EB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Return2687Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02610Base.\u003CReturn2687Popup\u003Ec__Iterator7EC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnNo()
  {
  }

  public override void onBackButton() => this.IbtnNo();
}
