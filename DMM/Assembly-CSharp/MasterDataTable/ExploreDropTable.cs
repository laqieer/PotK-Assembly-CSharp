// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ExploreDropTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ExploreDropTable
  {
    public int ID;
    public int deck_id;
    public int drop_ratio;
    public int drop_reward_id;

    public static ExploreDropTable Parse(MasterDataReader reader) => new ExploreDropTable()
    {
      ID = reader.ReadInt(),
      deck_id = reader.ReadInt(),
      drop_ratio = reader.ReadInt(),
      drop_reward_id = reader.ReadInt()
    };
  }
}
