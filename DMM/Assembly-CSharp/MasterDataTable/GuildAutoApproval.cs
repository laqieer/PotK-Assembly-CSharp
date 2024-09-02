// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildAutoApproval
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildAutoApproval
  {
    public int ID;
    public string name;
    public bool auto_approval;

    public static GuildAutoApproval Parse(MasterDataReader reader) => new GuildAutoApproval()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      auto_approval = reader.ReadBool()
    };
  }
}
