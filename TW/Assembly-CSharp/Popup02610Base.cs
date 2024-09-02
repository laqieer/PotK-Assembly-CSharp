// Decompiled with JetBrains decompiler
// Type: Popup02610Base
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup02610Base.\u003CInitCoroutine\u003Ec__IteratorA2E()
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
    return (IEnumerator) new Popup02610Base.\u003CReturn2688Popup\u003Ec__IteratorA2F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Return2687Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02610Base.\u003CReturn2687Popup\u003Ec__IteratorA30()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnNo()
  {
  }

  public override void onBackButton() => this.IbtnNo();
}
