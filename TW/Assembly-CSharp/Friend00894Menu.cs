// Decompiled with JetBrains decompiler
// Type: Friend00894Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    this.txtDescription1.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_00894_MENU, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (num),
        (object) num.ToString()
      }
    }));
  }

  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
