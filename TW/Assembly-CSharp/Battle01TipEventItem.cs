// Decompiled with JetBrains decompiler
// Type: Battle01TipEventItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Battle01TipEventItem : Battle01TipEventBase
{
  private ItemIcon icon;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventItem.\u003ConInitAsync\u003Ec__Iterator936()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(SupplySupply supply)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventItem.\u003CdoSetIcon\u003Ec__Iterator937()
    {
      supply = supply,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventItem.\u003CdoSetIcon\u003Ec__Iterator938()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.gear && e.reward.Type != MasterDataTable.CommonRewardType.supply)
      return;
    Dictionary<string, string> args = new Dictionary<string, string>();
    args["item"] = string.Empty;
    switch (e.reward.Type)
    {
      case MasterDataTable.CommonRewardType.supply:
        if (MasterData.SupplySupply.ContainsKey(e.reward.Id))
        {
          SupplySupply supply = MasterData.SupplySupply[e.reward.Id];
          args["item"] = supply.name;
          Singleton<NGBattleManager>.GetInstance().StartCoroutine(this.doSetIcon(supply));
          break;
        }
        break;
      case MasterDataTable.CommonRewardType.gear:
        if (MasterData.GearGear.ContainsKey(e.reward.Id))
        {
          GearGear gear = MasterData.GearGear[e.reward.Id];
          args["item"] = gear.name;
          Singleton<NGBattleManager>.GetInstance().StartCoroutine(this.doSetIcon(gear));
          break;
        }
        break;
    }
    this.setText(Consts.Format(Consts.GetInstance().TipEvent_text_item, (IDictionary) args));
  }
}
