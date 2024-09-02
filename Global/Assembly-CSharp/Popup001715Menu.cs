// Decompiled with JetBrains decompiler
// Type: Popup001715Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup001715Menu : NGMenuBase
{
  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup001715Menu.\u003CInit\u003Ec__Iterator7AD initCIterator7Ad = new Popup001715Menu.\u003CInit\u003Ec__Iterator7AD();
    return (IEnumerator) initCIterator7Ad;
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
