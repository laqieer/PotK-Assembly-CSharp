// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerTower
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerTower
  {
    public int ID;
    public int tower_id;
    public bool ranking_flag;

    public static TowerTower Parse(MasterDataReader reader) => new TowerTower()
    {
      ID = reader.ReadInt(),
      tower_id = reader.ReadInt(),
      ranking_flag = reader.ReadBool()
    };
  }
}
