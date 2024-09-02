// Decompiled with JetBrains decompiler
// Type: Popup01016Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup01016Menu : BackButtonMenuBase
{
  public UILabel TextDescription;
  private Setting01013Menu menu01013;

  [DebuggerHidden]
  public IEnumerator Init(Setting01013Menu menu, string name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup01016Menu.\u003CInit\u003Ec__Iterator93C()
    {
      menu = menu,
      name = name,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Ename = name,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk()
  {
    this.menu01013.Initialize();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo() => this.IbtnOk();

  public override void onBackButton() => this.IbtnNo();
}
