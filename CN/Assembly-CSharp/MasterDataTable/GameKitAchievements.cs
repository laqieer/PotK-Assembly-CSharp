// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GameKitAchievements
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
