// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBaseAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildBaseAnimation
  {
    public int ID;
    public int anim_group_ID;
    public string animPrefixSprite;
    public int animframe;
    public float animXpos;
    public float animYpos;

    public static GuildBaseAnimation Parse(MasterDataReader reader)
    {
      return new GuildBaseAnimation()
      {
        ID = reader.ReadInt(),
        anim_group_ID = reader.ReadInt(),
        animPrefixSprite = reader.ReadString(true),
        animframe = reader.ReadInt(),
        animXpos = reader.ReadFloat(),
        animYpos = reader.ReadFloat()
      };
    }
  }
}
