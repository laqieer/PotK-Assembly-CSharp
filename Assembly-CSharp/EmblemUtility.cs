// Decompiled with JetBrains decompiler
// Type: EmblemUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class EmblemUtility : MonoBehaviour
{
  public static Future<UnityEngine.Sprite> LoadEmblemSprite(int emblemID)
  {
    int num = 99999;
    string path = string.Format("Prefabs/colosseum/colosseum_title/{0}_title", (object) (emblemID == 0 ? num : emblemID));
    if (Singleton<NGGameDataManager>.GetInstance().IsSea && emblemID == 0)
      path += "_sea";
    return Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(path);
  }

  public static GuildEmblemUnit GuildEnblemData(int emblemID) => ((IEnumerable<GuildEmblemUnit>) MasterData.GuildEmblemUnitList).FirstOrDefault<GuildEmblemUnit>((Func<GuildEmblemUnit, bool>) (x => x.ID == emblemID));

  public static Future<UnityEngine.Sprite> LoadGuildEmblemSprite(int emblemID)
  {
    string path = string.Format("Prefabs/guild/guild_title/{0}_title", (object) (emblemID == 0 ? 99999 : emblemID));
    return Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(path);
  }
}
