// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GameKitAchievements
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GameKitAchievements
  {
    public int ID;
    public int steps;
    public string ios_id;
    public string android_id;

    public static GameKitAchievements Parse(MasterDataReader reader)
    {
      return new GameKitAchievements()
      {
        ID = reader.ReadInt(),
        steps = reader.ReadInt(),
        ios_id = reader.ReadString(true),
        android_id = reader.ReadString(true)
      };
    }
  }
}
