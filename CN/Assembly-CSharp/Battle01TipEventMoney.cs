// Decompiled with JetBrains decompiler
// Type: Battle01TipEventMoney
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Battle01TipEventMoney : Battle01TipEventBase
{
  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventMoney.\u003CStart_Original\u003Ec__Iterator86E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.money)
      return;
    this.setText(Consts.Format(Consts.GetInstance().TipEvent_text_money, (IDictionary) new Dictionary<string, int>()
    {
      ["money"] = e.reward.Quantity
    }));
  }
}
