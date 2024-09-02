// Decompiled with JetBrains decompiler
// Type: Popup01015Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup01015Menu : BackButtonMenuBase
{
  public UILabel TextDescription;
  private Setting01013Menu menu01013;
  private string newName;

  [DebuggerHidden]
  public IEnumerator Init(Setting01013Menu menu, string name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup01015Menu.\u003CInit\u003Ec__IteratorA0C()
    {
      menu = menu,
      name = name,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Ename = name,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Popup01017()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01015Menu.\u003CPopup01017\u003Ec__IteratorA0D popup01017CIteratorA0D = new Popup01015Menu.\u003CPopup01017\u003Ec__IteratorA0D();
    return (IEnumerator) popup01017CIteratorA0D;
  }

  [DebuggerHidden]
  private IEnumerator Popup01018()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01015Menu.\u003CPopup01018\u003Ec__IteratorA0E popup01018CIteratorA0E = new Popup01015Menu.\u003CPopup01018\u003Ec__IteratorA0E();
    return (IEnumerator) popup01018CIteratorA0E;
  }

  [DebuggerHidden]
  private IEnumerator BtnYes()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup01015Menu.\u003CBtnYes\u003Ec__IteratorA0F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.BtnYes());
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
