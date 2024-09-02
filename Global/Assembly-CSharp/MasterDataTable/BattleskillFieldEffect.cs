// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillFieldEffect
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
  public class BattleskillFieldEffect
  {
    public int ID;
    public string user_name;
    public bool user_move_camera;
    public bool user_effect_mask;
    public float user_wait_seconds;
    public string target_name;
    public bool target_move_camera;
    public bool target_effect_mask;
    public float target_wait_seconds;
    public bool targets_multiple_effect;

    public static BattleskillFieldEffect Parse(MasterDataReader reader)
    {
      return new BattleskillFieldEffect()
      {
        ID = reader.ReadInt(),
        user_name = reader.ReadString(true),
        user_move_camera = reader.ReadBool(),
        user_effect_mask = reader.ReadBool(),
        user_wait_seconds = reader.ReadFloat(),
        target_name = reader.ReadString(true),
        target_move_camera = reader.ReadBool(),
        target_effect_mask = reader.ReadBool(),
        target_wait_seconds = reader.ReadFloat(),
        targets_multiple_effect = reader.ReadBool()
      };
    }

    public Future<GameObject> LoadFieldEffectPrefab()
    {
      return ResourceManager.LoadOrNull<GameObject>(string.Format("BattleEffects/field/{0}", (object) this.user_name));
    }

    public Future<GameObject> LoadFieldTargetEffectPrefab()
    {
      return ResourceManager.LoadOrNull<GameObject>(string.Format("BattleEffects/field/{0}", (object) this.target_name));
    }
  }
}
