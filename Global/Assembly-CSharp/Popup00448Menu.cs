// Decompiled with JetBrains decompiler
// Type: Popup00448Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup00448Menu : NGMenuBase
{
  public UILabel TxtDescription;

  [DebuggerHidden]
  public IEnumerator Init(PlayerItem item)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00448Menu.\u003CInit\u003Ec__Iterator7BA()
    {
      item = item,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
