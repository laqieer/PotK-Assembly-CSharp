// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildStampGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildStampGroup
  {
    public int ID;
    public string name;
    public int iconID;

    public static GuildStampGroup Parse(MasterDataReader reader) => new GuildStampGroup()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      iconID = reader.ReadInt()
    };
  }
}
