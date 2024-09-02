// Decompiled with JetBrains decompiler
// Type: Friend00895Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator52C asyncCIterator52C = new Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator52C();
    return (IEnumerator) asyncCIterator52C;
  }

  public virtual void IbtnOk()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    this.StartCoroutine(this.BackSceneAsync());
  }
}
