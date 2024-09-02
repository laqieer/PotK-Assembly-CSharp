// Decompiled with JetBrains decompiler
// Type: Friend008202Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Friend008202Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtDescription1;

  public void SetAcceptNumMessage(int num)
  {
    this.txtDescription1.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_008202_MENU, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (num),
        (object) num.ToString()
      }
    }));
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
