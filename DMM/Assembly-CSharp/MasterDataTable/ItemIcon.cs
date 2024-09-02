// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

namespace MasterDataTable
{
  public class ItemIcon
  {
    public static Future<UnityEngine.Sprite> LoadSpriteThumbnail(
      string name,
      bool withPath = false)
    {
      return withPath ? Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(name) : Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("Icons/Item_Icon_{0}", (object) name));
    }
  }
}
