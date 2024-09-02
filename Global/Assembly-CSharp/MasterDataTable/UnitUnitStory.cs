﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitStory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitStory
  {
    public int ID;
    public int face_x;
    public int face_y;
    public float story_texture_scale;
    public int story_texture_x;
    public int story_texture_y;

    public static UnitUnitStory Parse(MasterDataReader reader)
    {
      return new UnitUnitStory()
      {
        ID = reader.ReadInt(),
        face_x = reader.ReadInt(),
        face_y = reader.ReadInt(),
        story_texture_scale = reader.ReadFloat(),
        story_texture_x = reader.ReadInt(),
        story_texture_y = reader.ReadInt()
      };
    }
  }
}
