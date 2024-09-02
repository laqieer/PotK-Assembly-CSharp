// Decompiled with JetBrains decompiler
// Type: Battle01PVPBattleHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPBattleHeader : NGBattleMenuBase
{
  [SerializeField]
  private UILabel playerName;
  [SerializeField]
  private UILabel enemyName;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPBattleHeader.\u003CStart_Battle\u003Ec__Iterator87C()
    {
      \u003C\u003Ef__this = this
    };
  }
}
