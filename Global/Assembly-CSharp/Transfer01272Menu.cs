// Decompiled with JetBrains decompiler
// Type: Transfer01272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Transfer01272Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtPeriod02;
  [SerializeField]
  protected UILabel TxtTransfercord02;

  public void InitTransfer(string code, DateTime timeLimit)
  {
    this.TxtPeriod02.SetTextLocalize(Consts.Lookup("TRANSFER_01272_MENU_LIMIT", (IDictionary) new Hashtable()
    {
      {
        (object) "year",
        (object) timeLimit.Year
      },
      {
        (object) "month",
        (object) timeLimit.Month
      },
      {
        (object) "day",
        (object) timeLimit.Day
      },
      {
        (object) "hour",
        (object) timeLimit.Hour
      },
      {
        (object) "min",
        (object) timeLimit.Minute.ToString("00")
      }
    }));
    this.TxtTransfercord02.SetText(code);
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
