// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRaidSettings
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRaidSettings
  {
    public int ID;
    public string key;
    public int value;

    public static GuildRaidSettings Parse(MasterDataReader reader) => new GuildRaidSettings()
    {
      ID = reader.ReadInt(),
      key = reader.ReadString(true),
      value = reader.ReadInt()
    };
  }
}
