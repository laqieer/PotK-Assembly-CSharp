// Decompiled with JetBrains decompiler
// Type: Transfer012811Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Transfer012811Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription;

  public void ChangeDescription(DateTime blockTime)
  {
    this.TxtDescription.SetTextLocalize(Consts.Lookup("POPUP_012_8_11_TEXT", (IDictionary) new Hashtable()
    {
      {
        (object) "year",
        (object) this.TimeIntToString(blockTime.Year)
      },
      {
        (object) "month",
        (object) this.TimeIntToString(blockTime.Month)
      },
      {
        (object) "day",
        (object) this.TimeIntToString(blockTime.Day)
      },
      {
        (object) "hour",
        (object) this.TimeIntToString(blockTime.Hour)
      },
      {
        (object) "minute",
        (object) this.TimeIntToString(blockTime.Minute)
      }
    }));
  }

  public override void onBackButton() => this.IbtnPopupOk();

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public string TimeIntToString(int time)
  {
    string empty = string.Empty;
    return time >= 0 && time < 10 ? "0" + time.ToLocalizeNumberText() : time.ToLocalizeNumberText();
  }
}
