// Decompiled with JetBrains decompiler
// Type: BEUnitExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;

#nullable disable
public static class BEUnitExtension
{
  public static void spawn(this BL.Unit self, BE env)
  {
    env.core.getUnitPosition(self).resetSpawnPosition();
    self.isEnable = true;
    env.unitResource[self].unitParts.spawn();
  }

  public static void rebirthBE(this BL.Unit self, BE env)
  {
    env.unitResource[self].unitParts.rebirth();
  }
}
