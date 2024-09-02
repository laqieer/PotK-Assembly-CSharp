// Decompiled with JetBrains decompiler
// Type: EmblemUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class EmblemUtility : MonoBehaviour
{
  public static Future<Sprite> LoadEmblemSprite(int emblemID)
  {
    string path = string.Format("Prefabs/colosseum/colosseum_title/{0}_title", (object) (emblemID != 0 ? emblemID : 99999));
    return Singleton<ResourceManager>.GetInstance().Load<Sprite>(path);
  }

  public static GuildEmblemUnit GuildEnblemData(int emblemID)
  {
    return ((IEnumerable<GuildEmblemUnit>) MasterData.GuildEmblemUnitList).FirstOrDefault<GuildEmblemUnit>((Func<GuildEmblemUnit, bool>) (x => x.ID == emblemID));
  }

  public static Future<Sprite> LoadGuildEmblemSprite(int emblemID)
  {
    string path = string.Format("Prefabs/guild/guild_title/{0}_title", (object) (emblemID != 0 ? emblemID : 99999));
    return Singleton<ResourceManager>.GetInstance().Load<Sprite>(path);
  }
}
