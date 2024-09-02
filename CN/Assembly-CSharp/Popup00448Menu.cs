// Decompiled with JetBrains decompiler
// Type: Popup00448Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup00448Menu.\u003CInit\u003Ec__Iterator92B()
    {
      item = item,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
