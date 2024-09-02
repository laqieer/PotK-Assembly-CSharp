// Decompiled with JetBrains decompiler
// Type: Popup005512Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Popup005512Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel description;

  public void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnOk();

  public void SetTextWithMoney(long money)
  {
    this.description.SetText(Consts.Lookup("popup_005_5_12_text", (IDictionary) new Hashtable()
    {
      {
        (object) nameof (money),
        (object) money.ToLocalizeNumberText()
      }
    }));
  }
}
