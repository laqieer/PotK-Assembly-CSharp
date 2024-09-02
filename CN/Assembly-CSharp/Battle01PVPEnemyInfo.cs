// Decompiled with JetBrains decompiler
// Type: Battle01PVPEnemyInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private Battle01PVPEnemyUnits enemyUnits;
  [SerializeField]
  private UI2DSprite emblem;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyInfo.\u003CStart_Battle\u003Ec__Iterator87E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void setInfo(IGameEngine ge)
  {
    this.setText(this.playerName, ge.enemyName);
    int v = 0;
    foreach (BL.Unit unit in this.env.core.enemyUnits.value)
    {
      Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(unit.playerUnit);
      v += nonBattleParameter.Combat;
    }
    this.setText(this.power, v);
    if (!(ge is PVPManager))
      return;
    PVPManager pvpManager = ge as PVPManager;
    if (pvpManager.enemyInfo == null)
      return;
    this.setText(this.className, pvpManager.enemyInfo.getClassNameString());
    this.setText(this.ranking, pvpManager.enemyInfo.getRankingString());
    this.setText(this.point, pvpManager.enemyInfo.getPointString());
  }
}
