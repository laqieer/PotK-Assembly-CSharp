// Decompiled with JetBrains decompiler
// Type: Quest00226List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00226List : Quest00219List
{
  [SerializeField]
  private UILabel TxtTotalPoint;

  [DebuggerHidden]
  public IEnumerator Init(PlayerExtraQuestS extra, bool isClear, bool isNew, int totalPoint)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226List.\u003CInit\u003Ec__Iterator278()
    {
      extra = extra,
      totalPoint = totalPoint,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EtotalPoint = totalPoint,
      \u003C\u003Ef__this = this
    };
  }
}
