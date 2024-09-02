// Decompiled with JetBrains decompiler
// Type: Popup005512Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    string localizeNumberText = money.ToLocalizeNumberText();
    this.description.SetText(Consts.Format(Consts.GetInstance().popup_005_5_12_text, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (money),
        (object) localizeNumberText
      }
    }));
  }
}
