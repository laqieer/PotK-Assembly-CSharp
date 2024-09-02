// Decompiled with JetBrains decompiler
// Type: EmblemUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class EmblemUtility : MonoBehaviour
{
  public static Future<Sprite> LoadEmblemSprite(int emblemID)
  {
    return ResourceManager.Load<Sprite>(string.Format("Prefabs/colosseum/colosseum_title/{0}_title", (object) (emblemID != 0 ? emblemID : 99999)));
  }
}
