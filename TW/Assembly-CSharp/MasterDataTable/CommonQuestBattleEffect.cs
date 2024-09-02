// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonQuestBattleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class CommonQuestBattleEffect
  {
    public int ID;
    public string file_name;

    public static CommonQuestBattleEffect Parse(MasterDataReader reader)
    {
      return new CommonQuestBattleEffect()
      {
        ID = reader.ReadInt(),
        file_name = reader.ReadString(true)
      };
    }
  }
}
