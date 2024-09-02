// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DuelEffectPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DuelEffectPreload
  {
    public int ID;
    public int duel_controller_id;
    public string effect_file_name;

    public static DuelEffectPreload Parse(MasterDataReader reader)
    {
      return new DuelEffectPreload()
      {
        ID = reader.ReadInt(),
        duel_controller_id = reader.ReadInt(),
        effect_file_name = reader.ReadString(true)
      };
    }
  }
}
