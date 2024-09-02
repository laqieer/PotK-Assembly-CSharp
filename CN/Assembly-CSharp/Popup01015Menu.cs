// Decompiled with JetBrains decompiler
// Type: Popup01015Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
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
    return (IEnumerator) new Popup01015Menu.\u003CInit\u003Ec__Iterator938()
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
    Popup01015Menu.\u003CPopup01017\u003Ec__Iterator939 popup01017CIterator939 = new Popup01015Menu.\u003CPopup01017\u003Ec__Iterator939();
    return (IEnumerator) popup01017CIterator939;
  }

  [DebuggerHidden]
  private IEnumerator Popup01018()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup01015Menu.\u003CPopup01018\u003Ec__Iterator93A popup01018CIterator93A = new Popup01015Menu.\u003CPopup01018\u003Ec__Iterator93A();
    return (IEnumerator) popup01018CIterator93A;
  }

  [DebuggerHidden]
  private IEnumerator BtnYes()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup01015Menu.\u003CBtnYes\u003Ec__Iterator93B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void sdkRenameEvent()
  {
    SDKExtraObj sdkExtraObj = new SDKExtraObj()
    {
      roleId = SDK.instance.GetPlayID(),
      roleName = this.newName
    };
    DDebug.Log("createRoleEvent");
    string balance = SMManager.Get<Player>().coin.ToString();
    SDK.instance.createRoleExtra(string.Empty, this.newName, "Android", string.Empty, balance);
  }

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.BtnYes());
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
