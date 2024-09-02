// Decompiled with JetBrains decompiler
// Type: Friend008203Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator4D5 asyncCIterator4D5 = new Friend008203Menu.\u003CBackSceneAsync\u003Ec__Iterator4D5();
    return (IEnumerator) asyncCIterator4D5;
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
