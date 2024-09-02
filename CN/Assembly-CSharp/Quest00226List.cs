// Decompiled with JetBrains decompiler
// Type: Quest00226List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00226List.\u003CInit\u003Ec__Iterator243()
    {
      extra = extra,
      totalPoint = totalPoint,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EtotalPoint = totalPoint,
      \u003C\u003Ef__this = this
    };
  }
}
