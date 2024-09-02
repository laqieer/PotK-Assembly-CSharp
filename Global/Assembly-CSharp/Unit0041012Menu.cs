// Decompiled with JetBrains decompiler
// Type: Unit0041012Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
      empty += Consts.Lookup("popup_004_10_12_zeny_text", (IDictionary) new Hashtable()
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
      empty += Consts.Lookup("popup_004_10_12_medal_text", (IDictionary) new Hashtable()
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
