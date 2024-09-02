// Decompiled with JetBrains decompiler
// Type: Friend008203Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator524 asyncCIterator524 = new Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator524();
    return (IEnumerator) asyncCIterator524;
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
