// Decompiled with JetBrains decompiler
// Type: Battle01UnitCounter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
