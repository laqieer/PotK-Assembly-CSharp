// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildStamp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildStamp
  {
    public int ID;
    public int groupID_GuildStampGroup;

    public static GuildStamp Parse(MasterDataReader reader)
    {
      return new GuildStamp()
      {
        ID = reader.ReadInt(),
        groupID_GuildStampGroup = reader.ReadInt()
      };
    }

    public GuildStampGroup groupID
    {
      get
      {
        GuildStampGroup groupId;
        if (!MasterData.GuildStampGroup.TryGetValue(this.groupID_GuildStampGroup, out groupId))
          Debug.LogError((object) ("Key not Found: MasterData.GuildStampGroup[" + (object) this.groupID_GuildStampGroup + "]"));
        return groupId;
      }
    }
  }
}
