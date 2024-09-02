// Decompiled with JetBrains decompiler
// Type: Transfer012811Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    string str1 = this.TimeIntToString(blockTime.Year);
    string str2 = this.TimeIntToString(blockTime.Month);
    string str3 = this.TimeIntToString(blockTime.Day);
    string str4 = this.TimeIntToString(blockTime.Hour);
    string str5 = this.TimeIntToString(blockTime.Minute);
    this.TxtDescription.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_012_8_11_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "year",
        (object) str1
      },
      {
        (object) "month",
        (object) str2
      },
      {
        (object) "day",
        (object) str3
      },
      {
        (object) "hour",
        (object) str4
      },
      {
        (object) "minute",
        (object) str5
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
    return time >= 0 && time < 10 ? "０" + time.ToLocalizeNumberText() : time.ToLocalizeNumberText();
  }
}
