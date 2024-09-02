// Decompiled with JetBrains decompiler
// Type: Bugu0052MedalPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Bugu0052MedalPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtTitle;
  private System.Action repairAction;

  public void InitPopup(System.Action act, string kind, int latch)
  {
    this.repairAction = act;
    this.txtTitle.SetText(Consts.Lookup("BUGU_0052POPUP_TITLE"));
    switch (kind)
    {
      case "medal":
        this.txtDescription.SetText(Consts.Lookup("BUGU_0052POPUP_DESCRIPTION_MEDAL", (IDictionary) new Hashtable()
        {
          {
            (object) nameof (latch),
            (object) latch.ToString().ToConverter()
          }
        }));
        break;
      case "money":
        this.txtDescription.SetText(Consts.Lookup("BUGU_0052POPUP_DESCRIPTION_MONEY", (IDictionary) new Hashtable()
        {
          {
            (object) nameof (latch),
            (object) latch.ToString().ToConverter()
          }
        }));
        break;
    }
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.repairAction();
  }
}
