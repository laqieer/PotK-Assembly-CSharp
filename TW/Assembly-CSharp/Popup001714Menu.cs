// Decompiled with JetBrains decompiler
// Type: Popup001714Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Popup001714Menu.\u003CInit\u003Ec__Iterator9EB initCIterator9Eb = new Popup001714Menu.\u003CInit\u003Ec__Iterator9EB();
    return (IEnumerator) initCIterator9Eb;
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
