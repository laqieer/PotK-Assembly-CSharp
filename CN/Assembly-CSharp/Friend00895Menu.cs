// Decompiled with JetBrains decompiler
// Type: Friend00895Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator4DE asyncCIterator4De = new Friend00895Menu.\u003CBackSceneAsync\u003Ec__Iterator4DE();
    return (IEnumerator) asyncCIterator4De;
  }

  public virtual void IbtnOk()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    this.StartCoroutine(this.BackSceneAsync());
  }
}
