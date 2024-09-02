// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  public class ItemIcon
  {
    public static Future<Sprite> LoadSpriteThumbnail(string name, bool withPath = false)
    {
      return withPath ? ResourceManager.Load<Sprite>(name) : ResourceManager.Load<Sprite>(string.Format("Icons/Item_Icon_{0}", (object) name));
    }
  }
}
