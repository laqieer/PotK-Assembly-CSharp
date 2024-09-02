// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonQuestBattleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
