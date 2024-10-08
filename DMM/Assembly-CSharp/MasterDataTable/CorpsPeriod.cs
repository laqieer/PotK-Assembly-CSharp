﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CorpsPeriod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CorpsPeriod
  {
    public int ID;
    public int setting_CorpsSetting;
    public DateTime start_at;
    public DateTime end_at;
    public DateTime end_at_disp;
    public int trade_coin_id;
    public int banner_id;
    public int priority;

    public static CorpsPeriod Parse(MasterDataReader reader) => new CorpsPeriod()
    {
      ID = reader.ReadInt(),
      setting_CorpsSetting = reader.ReadInt(),
      start_at = reader.ReadDateTime(),
      end_at = reader.ReadDateTime(),
      end_at_disp = reader.ReadDateTime(),
      trade_coin_id = reader.ReadInt(),
      banner_id = reader.ReadInt(),
      priority = reader.ReadInt()
    };

    public CorpsSetting setting
    {
      get
      {
        CorpsSetting corpsSetting;
        if (!MasterData.CorpsSetting.TryGetValue(this.setting_CorpsSetting, out corpsSetting))
          Debug.LogError((object) ("Key not Found: MasterData.CorpsSetting[" + (object) this.setting_CorpsSetting + "]"));
        return corpsSetting;
      }
    }
  }
}
