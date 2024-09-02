// Decompiled with JetBrains decompiler
// Type: Friend00895Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Friend00895Menu : NGMenuBase
{
  private bool isPush;

  [DebuggerHidden]
  private IEnumerator BackSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator443 asyncCIterator443 = new Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator443();
    return (IEnumerator) asyncCIterator443;
  }

  public virtual void IbtnOk()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    this.StartCoroutine(this.BackSceneAsync());
  }
}
