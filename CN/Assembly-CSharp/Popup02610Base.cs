// Decompiled with JetBrains decompiler
// Type: Popup02610Base
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup02610Base.\u003CInitCoroutine\u003Ec__Iterator959()
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
    return (IEnumerator) new Popup02610Base.\u003CReturn2688Popup\u003Ec__Iterator95A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Return2687Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02610Base.\u003CReturn2687Popup\u003Ec__Iterator95B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnNo()
  {
  }

  public override void onBackButton() => this.IbtnNo();
}
