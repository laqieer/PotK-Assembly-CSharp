// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  public class ItemIcon
  {
    public static Future<Sprite> LoadSpriteThumbnail(string name, bool withPath = false)
    {
      return withPath ? Singleton<ResourceManager>.GetInstance().Load<Sprite>(name) : Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("Icons/Item_Icon_{0}", (object) name));
    }
  }
}
