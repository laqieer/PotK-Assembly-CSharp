// Decompiled with JetBrains decompiler
// Type: Popup01015Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup01015Menu.\u003CInit\u003Ec__Iterator7C8()
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
    Popup01015Menu.\u003CPopup01017\u003Ec__Iterator7C9 popup01017CIterator7C9 = new Popup01015Menu.\u003CPopup01017\u003Ec__Iterator7C9();
    return (IEnumerator) popup01017CIterator7C9;
  }

  [DebuggerHidden]
  private IEnumerator Popup01018()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01015Menu.\u003CPopup01018\u003Ec__Iterator7CA popup01018CIterator7Ca = new Popup01015Menu.\u003CPopup01018\u003Ec__Iterator7CA();
    return (IEnumerator) popup01018CIterator7Ca;
  }

  [DebuggerHidden]
  private IEnumerator BtnYes()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup01015Menu.\u003CBtnYes\u003Ec__Iterator7CB()
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
