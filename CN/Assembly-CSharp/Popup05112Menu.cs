// Decompiled with JetBrains decompiler
// Type: Popup05112Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Popup05112Menu.\u003CChangeEarthPrologue\u003Ec__Iterator97D prologueCIterator97D = new Popup05112Menu.\u003CChangeEarthPrologue\u003Ec__Iterator97D();
    return (IEnumerator) prologueCIterator97D;
  }
}
