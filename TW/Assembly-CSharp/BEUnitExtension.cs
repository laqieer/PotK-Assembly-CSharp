// Decompiled with JetBrains decompiler
// Type: BEUnitExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;

#nullable disable
public static class BEUnitExtension
{
  public static void spawn(this BL.Unit self, BE env)
  {
    env.core.getUnitPosition(self).resetSpawnPosition();
    self.isEnable = true;
    env.unitResource[self].unitParts.spawn();
    foreach (BL.UnitPosition unitPosition in env.core.unitPositions.value)
    {
      if (unitPosition.hasPanelsCache)
        unitPosition.clearMovePanelCache();
    }
  }

  public static void rebirthBE(this BL.Unit self, BE env)
  {
    env.unitResource[self].unitParts.rebirth();
  }
}
