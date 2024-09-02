// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillAilmentEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillAilmentEffect
  {
    public int ID;
    public string field_effect_name;
    public string duel_effect_name;

    public static BattleskillAilmentEffect Parse(MasterDataReader reader)
    {
      return new BattleskillAilmentEffect()
      {
        ID = reader.ReadInt(),
        field_effect_name = reader.ReadString(true),
        duel_effect_name = reader.ReadString(true)
      };
    }

    public Future<GameObject> LoadFieldAilmentEffectPrefab()
    {
      return ResourceManager.LoadOrNull<GameObject>(string.Format("BattleEffects/field/{0}", (object) this.field_effect_name));
    }
  }
}
