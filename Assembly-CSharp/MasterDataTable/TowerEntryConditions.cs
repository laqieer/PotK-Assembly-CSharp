// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerEntryConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerEntryConditions
  {
    public int ID;
    public int tower_id_TowerTower;
    public int value;
    public string text;

    public static TowerEntryConditions Parse(MasterDataReader reader) => new TowerEntryConditions()
    {
      ID = reader.ReadInt(),
      tower_id_TowerTower = reader.ReadInt(),
      value = reader.ReadInt(),
      text = reader.ReadString(true)
    };

    public TowerTower tower_id
    {
      get
      {
        TowerTower towerTower;
        if (!MasterData.TowerTower.TryGetValue(this.tower_id_TowerTower, out towerTower))
          Debug.LogError((object) ("Key not Found: MasterData.TowerTower[" + (object) this.tower_id_TowerTower + "]"));
        return towerTower;
      }
    }
  }
}
