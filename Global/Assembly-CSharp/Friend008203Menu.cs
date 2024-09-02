// Decompiled with JetBrains decompiler
// Type: Friend008203Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Friend008203Menu : BackButtonMenuBase
{
  [DebuggerHidden]
  private IEnumerator BackSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator43A asyncCIterator43A = new Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator43A();
    return (IEnumerator) asyncCIterator43A;
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
