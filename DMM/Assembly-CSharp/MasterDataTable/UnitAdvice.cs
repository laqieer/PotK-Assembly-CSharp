// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitAdvice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitAdvice
  {
    public int ID;
    public int role_UnitRole;
    public int activity_UnitActivityScenes;
    public string advice;

    public static UnitAdvice Parse(MasterDataReader reader) => new UnitAdvice()
    {
      ID = reader.ReadInt(),
      role_UnitRole = reader.ReadInt(),
      activity_UnitActivityScenes = reader.ReadInt(),
      advice = reader.ReadString(true)
    };

    public UnitRole role
    {
      get
      {
        UnitRole unitRole;
        if (!MasterData.UnitRole.TryGetValue(this.role_UnitRole, out unitRole))
          Debug.LogError((object) ("Key not Found: MasterData.UnitRole[" + (object) this.role_UnitRole + "]"));
        return unitRole;
      }
    }

    public UnitActivityScenes activity
    {
      get
      {
        UnitActivityScenes unitActivityScenes;
        if (!MasterData.UnitActivityScenes.TryGetValue(this.activity_UnitActivityScenes, out unitActivityScenes))
          Debug.LogError((object) ("Key not Found: MasterData.UnitActivityScenes[" + (object) this.activity_UnitActivityScenes + "]"));
        return unitActivityScenes;
      }
    }

    public int same_character_id => this.ID;
  }
}
