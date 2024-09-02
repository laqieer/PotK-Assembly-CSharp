// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
