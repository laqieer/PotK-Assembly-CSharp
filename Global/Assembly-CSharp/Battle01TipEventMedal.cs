// Decompiled with JetBrains decompiler
// Type: Battle01TipEventMedal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Battle01TipEventMedal.\u003ConInitAsync\u003Ec__Iterator723()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.medal)
      return;
    this.setText(Consts.Lookup("TipEvent_text_medal", (IDictionary) new Dictionary<string, int>()
    {
      ["medal"] = e.reward.Quantity
    }));
  }
}
