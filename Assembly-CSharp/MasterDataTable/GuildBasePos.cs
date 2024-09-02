// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBasePos
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildBasePos
  {
    public int ID;
    public float baseXpos;
    public float baseYpos;

    public static GuildBasePos Parse(MasterDataReader reader) => new GuildBasePos()
    {
      ID = reader.ReadInt(),
      baseXpos = reader.ReadFloat(),
      baseYpos = reader.ReadFloat()
    };
  }
}
