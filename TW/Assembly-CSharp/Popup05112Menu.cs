// Decompiled with JetBrains decompiler
// Type: Popup05112Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup05112Menu : BackButtonMenuBase
{
  public override void onBackButton() => this.IbtnOk();

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ChangeEarthPrologue());
  }

  [DebuggerHidden]
  private IEnumerator ChangeEarthPrologue()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup05112Menu.\u003CChangeEarthPrologue\u003Ec__IteratorA52 prologueCIteratorA52 = new Popup05112Menu.\u003CChangeEarthPrologue\u003Ec__IteratorA52();
    return (IEnumerator) prologueCIteratorA52;
  }
}
