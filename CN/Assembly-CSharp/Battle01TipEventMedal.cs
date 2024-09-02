// Decompiled with JetBrains decompiler
// Type: Battle01TipEventMedal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Battle01TipEventMedal : Battle01TipEventBase
{
  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventMedal.\u003ConInitAsync\u003Ec__Iterator86D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.medal)
      return;
    this.setText(Consts.Format(Consts.GetInstance().TipEvent_text_medal, (IDictionary) new Dictionary<string, int>()
    {
      ["medal"] = e.reward.Quantity
    }));
  }
}
