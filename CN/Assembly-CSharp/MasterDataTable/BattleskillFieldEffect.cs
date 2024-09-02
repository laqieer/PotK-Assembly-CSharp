// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillFieldEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
      string path = string.Format("BattleEffects/field/{0}", (object) this.user_name);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }

    public Future<GameObject> LoadFieldTargetEffectPrefab()
    {
      string path = string.Format("BattleEffects/field/{0}", (object) this.target_name);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }
  }
}
