// Decompiled with JetBrains decompiler
// Type: Battle01TipEventPExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;

#nullable disable
public class Battle01TipEventPExp : Battle01TipEventBase
{
  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.player_exp)
      return;
    this.setText(Consts.Lookup("TipEvent_text_pexp"));
  }
}
