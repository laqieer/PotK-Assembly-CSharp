// Decompiled with JetBrains decompiler
// Type: Battle01TipEventExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;

#nullable disable
public class Battle01TipEventExp : Battle01TipEventBase
{
  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.unit_exp)
      return;
    this.setText(Consts.GetInstance().TipEvent_text_exp);
  }
}
