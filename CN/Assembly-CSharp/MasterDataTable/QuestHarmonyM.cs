// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyM
  {
    public int ID;
    public string name;
    public int priority;
    public int background_QuestCommonBackground;

    public static QuestHarmonyM Parse(MasterDataReader reader)
    {
      return new QuestHarmonyM()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        background_QuestCommonBackground = reader.ReadInt()
      };
    }

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground background;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out background))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return background;
      }
    }
  }
}
