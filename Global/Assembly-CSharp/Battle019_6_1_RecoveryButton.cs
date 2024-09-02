// Decompiled with JetBrains decompiler
// Type: Battle019_6_1_RecoveryButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class Battle019_6_1_RecoveryButton : NGBattleMenuBase
{
  private AttackStatus attackStatus;
  private BL.Unit src;
  private BL.Unit dst;
  private BattleHealCharacterInfoBase player;
  public bool isComplited;

  public void setUseTarget(BL.Unit src, BL.Unit dst)
  {
    this.src = src;
    this.dst = dst;
    this.isComplited = false;
  }

  public void setAttackStatus(AttackStatus attackStatus, BattleHealCharacterInfoBase player)
  {
    this.attackStatus = attackStatus;
    this.player = player;
  }

  public void onClick()
  {
    if (this.env == null || this.isComplited)
      return;
    if (!this.battleManager.isPvp)
    {
      this.env.useMagicBullet(this.attackStatus.magicBullet, this.attackStatus.heal_attack, this.src, ((IEnumerable<BL.Unit>) new BL.Unit[1]
      {
        this.dst
      }).ToList<BL.Unit>(), this.battleManager.getManager<BattleTimeManager>());
      this.backScene();
    }
    else
    {
      int currentAttackIndex = this.player.getCurrentAttackIndex();
      Singleton<PVPManager>.GetInstance().moveUnitWithAttack(this.src, this.dst, this.attackStatus.isHeal, currentAttackIndex);
    }
    this.isComplited = true;
  }
}
