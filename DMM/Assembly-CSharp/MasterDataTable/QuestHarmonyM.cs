﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyM
  {
    public int ID;
    public string name;
    public int priority;
    public int background_QuestCommonBackground;

    public static QuestHarmonyM Parse(MasterDataReader reader) => new QuestHarmonyM()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      priority = reader.ReadInt(),
      background_QuestCommonBackground = reader.ReadInt()
    };

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground commonBackground;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out commonBackground))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return commonBackground;
      }
    }
  }
}
