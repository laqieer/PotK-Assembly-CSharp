﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerPlaybackStory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerPlaybackStory
  {
    public int ID;
    public string name;
    public int stage_TowerStage;
    public int priority;
    public int banner_id;

    public static TowerPlaybackStory Parse(MasterDataReader reader) => new TowerPlaybackStory()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      stage_TowerStage = reader.ReadInt(),
      priority = reader.ReadInt(),
      banner_id = reader.ReadInt()
    };

    public TowerStage stage
    {
      get
      {
        TowerStage towerStage;
        if (!MasterData.TowerStage.TryGetValue(this.stage_TowerStage, out towerStage))
          Debug.LogError((object) ("Key not Found: MasterData.TowerStage[" + (object) this.stage_TowerStage + "]"));
        return towerStage;
      }
    }
  }
}
