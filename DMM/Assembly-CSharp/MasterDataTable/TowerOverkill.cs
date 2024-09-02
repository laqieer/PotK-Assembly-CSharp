// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerOverkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerOverkill
  {
    public int ID;
    public int enemyID;

    public static TowerOverkill Parse(MasterDataReader reader) => new TowerOverkill()
    {
      ID = reader.ReadInt(),
      enemyID = reader.ReadInt()
    };
  }
}
