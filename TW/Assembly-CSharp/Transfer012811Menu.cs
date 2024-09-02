// Decompiled with JetBrains decompiler
// Type: Transfer012811Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Transfer012811Menu : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtDescription;

  public void ChangeDescription(DateTime blockTime, bool isFgG)
  {
    string str1 = this.TimeIntToString(blockTime.Year);
    string str2 = this.TimeIntToString(blockTime.Month);
    string str3 = this.TimeIntToString(blockTime.Day);
    string str4 = this.TimeIntToString(blockTime.Hour);
    string str5 = this.TimeIntToString(blockTime.Minute);
    string empty = string.Empty;
    string text;
    if (isFgG)
      text = Consts.Format(Consts.GetInstance().POPUP_012_8_11_FGG_TEXT, (IDictionary) new Hashtable()
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
      });
    else
      text = Consts.Format(Consts.GetInstance().POPUP_012_8_11_TEXT, (IDictionary) new Hashtable()
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
      });
    this.TxtDescription.SetTextLocalize(text);
  }

  public string TimeIntToString(int time)
  {
    string empty = string.Empty;
    return time >= 0 && time < 10 ? "０" + time.ToLocalizeNumberText() : time.ToLocalizeNumberText();
  }
}
