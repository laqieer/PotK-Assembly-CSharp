// Decompiled with JetBrains decompiler
// Type: Unit0041012Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Unit0041012Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txtDescription1;

  public void SetText(int zeny, int medal)
  {
    string empty = string.Empty;
    if (zeny > 0)
    {
      string localizeNumberText = zeny.ToLocalizeNumberText();
      empty += Consts.Format(Consts.GetInstance().popup_004_10_12_zeny_text, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) localizeNumberText
        }
      });
    }
    if (medal > 0)
    {
      string localizeNumberText = medal.ToLocalizeNumberText();
      empty += Consts.Format(Consts.GetInstance().popup_004_10_12_medal_text, (IDictionary) new Hashtable()
      {
        {
          (object) nameof (medal),
          (object) localizeNumberText
        }
      });
    }
    this.txtDescription1.SetText(empty);
  }

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public override void onBackButton() => this.IbtnPopupOk();
}
