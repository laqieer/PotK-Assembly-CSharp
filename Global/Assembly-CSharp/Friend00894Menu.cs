// Decompiled with JetBrains decompiler
// Type: Friend00894Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Friend00894Menu : NGMenuBase
{
  [SerializeField]
  private UILabel txtDescription1;

  public void SetRejectNumMessage(int num)
  {
    this.txtDescription1.SetTextLocalize(Consts.Lookup("FRIEND_00894_MENU", (IDictionary) new Hashtable()
    {
      {
        (object) nameof (num),
        (object) num.ToString()
      }
    }));
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
