// Decompiled with JetBrains decompiler
// Type: Popup005512Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
