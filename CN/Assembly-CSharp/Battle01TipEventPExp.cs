// Decompiled with JetBrains decompiler
// Type: Battle01TipEventPExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;

#nullable disable
public class Battle01TipEventPExp : Battle01TipEventBase
{
  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.player_exp)
      return;
    this.setText(Consts.GetInstance().TipEvent_text_pexp);
  }
}
