﻿// Decompiled with JetBrains decompiler
// Type: Battle01TipEventExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

public class Battle01TipEventExp : Battle01TipEventBase
{
  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.unit_exp)
      return;
    this.setText(Consts.GetInstance().TipEvent_text_exp);
  }
}
