// Decompiled with JetBrains decompiler
// Type: BEUnitExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;

#nullable disable
public static class BEUnitExtension
{
  public static void spawn(this BL.Unit self, BE env)
  {
    env.core.getUnitPosition(self).resetSpawnPosition();
    self.isEnable = true;
    self.spawnTurn = env.core.phaseState.turnCount;
    env.unitResource[self].unitParts.spawn();
  }

  public static void rebirthBE(this BL.Unit self, BE env)
  {
    env.unitResource[self].unitParts.rebirth();
  }
}
