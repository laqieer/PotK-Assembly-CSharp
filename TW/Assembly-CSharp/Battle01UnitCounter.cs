﻿// Decompiled with JetBrains decompiler
// Type: Battle01UnitCounter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle01UnitCounter : NGBattleMenuBase
{
  [SerializeField]
  private SelectParts selectParts;
  [SerializeField]
  private UILabel count_txt;

  public void setCount(int c)
  {
    if (c <= 0)
    {
      this.selectParts.setValue(1);
    }
    else
    {
      this.selectParts.setValue(0);
      this.setText(this.count_txt, c);
    }
  }
}
