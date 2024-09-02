// Decompiled with JetBrains decompiler
// Type: BattleFieldEffectExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class BattleFieldEffectExtension
{
  public static Future<GameObject> LoadEffectPrefab(this BattleFieldEffect self, int n)
  {
    string effectPrefabName = self.effect_prefab_names[n];
    if (effectPrefabName.Length == 0)
      return Future.Single<GameObject>((GameObject) null);
    return Singleton<ResourceManager>.GetInstance().Load<GameObject>("BattleEffects/field/{0}".F((object) effectPrefabName));
  }

  public static Future<GameObject[]> LoadAllEffectPrefab(this BattleFieldEffect self)
  {
    List<Future<GameObject>> futures = new List<Future<GameObject>>();
    foreach (string effectPrefabName in self.effect_prefab_names)
    {
      List<Future<GameObject>> futureList = futures;
      Future<GameObject> future;
      if (effectPrefabName.Length == 0)
        future = Future.Single<GameObject>((GameObject) null);
      else
        future = Singleton<ResourceManager>.GetInstance().Load<GameObject>("BattleEffects/field/{0}".F((object) effectPrefabName));
      futureList.Add(future);
    }
    return futures.Sequence<GameObject>().Then<GameObject[]>((Func<List<GameObject>, GameObject[]>) (x => x.ToArray()));
  }

  public static Future<GameObject> LoadPrefab(this BattleFieldEffect self)
  {
    if (string.IsNullOrEmpty(self.prefab_name))
      return Future.Single<GameObject>((GameObject) null);
    return Singleton<ResourceManager>.GetInstance().Load<GameObject>("Animations/{0}".F((object) self.prefab_name));
  }
}
