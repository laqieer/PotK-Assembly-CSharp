// Decompiled with JetBrains decompiler
// Type: BattleGvgFinalize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleGvgFinalize : BattleMonoBehaviour
{
  private GVGManager _gvgManager;

  private GVGManager gvgManager
  {
    get
    {
      if (Object.op_Equality((Object) this._gvgManager, (Object) null))
        this._gvgManager = Singleton<GVGManager>.GetInstance();
      return this._gvgManager;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleGvgFinalize.\u003CStart_Battle\u003Ec__IteratorA88()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ForceClose()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleGvgFinalize.\u003CForceClose\u003Ec__IteratorA89()
    {
      \u003C\u003Ef__this = this
    };
  }
}
