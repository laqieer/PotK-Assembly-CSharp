﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBaseAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static GuildBaseAnimation Parse(MasterDataReader reader) => new GuildBaseAnimation()
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
