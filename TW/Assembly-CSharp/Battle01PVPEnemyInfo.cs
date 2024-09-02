// Decompiled with JetBrains decompiler
// Type: Battle01PVPEnemyInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPEnemyInfo : NGBattleMenuBase
{
  [SerializeField]
  private UILabel playerName;
  [SerializeField]
  private UILabel className;
  [SerializeField]
  private UILabel ranking;
  [SerializeField]
  private UILabel point;
  [SerializeField]
  private UILabel power;
  [SerializeField]
  private UILabel contributionLabel;
  [SerializeField]
  private UILabel levelLabel;
  [SerializeField]
  private GameObject[] guildPositionNodes;
  [SerializeField]
  private GameObject memberBaseNode;
  [SerializeField]
  private Battle01PVPEnemyUnits enemyUnits;
  [SerializeField]
  private UI2DSprite emblem;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyInfo.\u003CStart_Battle\u003Ec__Iterator94A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setInfo(IGameEngine ge)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyInfo.\u003CsetInfo\u003Ec__Iterator94B()
    {
      ge = ge,
      \u003C\u0024\u003Ege = ge,
      \u003C\u003Ef__this = this
    };
  }
}
