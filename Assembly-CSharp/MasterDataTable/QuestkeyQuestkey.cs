// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestkeyQuestkey
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestkeyQuestkey
  {
    public int ID;
    public string name;
    public string description;
    public int priority;

    public static QuestkeyQuestkey Parse(MasterDataReader reader) => new QuestkeyQuestkey()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      description = reader.ReadString(true),
      priority = reader.ReadInt()
    };

    public Future<UnityEngine.Sprite> LoadSpriteThumbnail() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/Questkey/{0}/key_thum", (object) this.ID));

    public Future<UnityEngine.Sprite> LoadSpriteBasic() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/Questkey/{0}/key_basic", (object) this.ID));
  }
}
