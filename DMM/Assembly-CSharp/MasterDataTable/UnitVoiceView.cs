﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitVoiceView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitVoiceView
  {
    public int ID;
    public int Cue_ID;
    public string Cue_Name;
    public string Cue_Info;
    public int Condition;
    public int ConditionValue;

    public static UnitVoiceView Parse(MasterDataReader reader) => new UnitVoiceView()
    {
      ID = reader.ReadInt(),
      Cue_ID = reader.ReadInt(),
      Cue_Name = reader.ReadString(true),
      Cue_Info = reader.ReadString(true),
      Condition = reader.ReadInt(),
      ConditionValue = reader.ReadInt()
    };
  }
}
