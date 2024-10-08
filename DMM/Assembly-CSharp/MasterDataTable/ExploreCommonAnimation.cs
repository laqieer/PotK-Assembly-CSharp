﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ExploreCommonAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ExploreCommonAnimation
  {
    public int ID;
    public string target;
    public string changed;
    public bool no_run;

    public static ExploreCommonAnimation Parse(MasterDataReader reader) => new ExploreCommonAnimation()
    {
      ID = reader.ReadInt(),
      target = reader.ReadString(true),
      changed = reader.ReadString(true),
      no_run = reader.ReadBool()
    };
  }
}
