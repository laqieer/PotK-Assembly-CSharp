// Decompiled with JetBrains decompiler
// Type: Popup001714Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup001714Menu : NGMenuBase
{
  public UILabel TxtDescription;

  [DebuggerHidden]
  public IEnumerator Init(string str)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup001714Menu.\u003CInit\u003Ec__Iterator918 initCIterator918 = new Popup001714Menu.\u003CInit\u003Ec__Iterator918();
    return (IEnumerator) initCIterator918;
  }

  public void SetText(string str)
  {
    this.TxtDescription.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_001714_DESCRIPT_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "Item",
        (object) str
      }
    }));
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
