// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryClearMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryClearMessage
  {
    public int ID;
    public bool is_firsttime;
    public int quest_s_id;
    private string _title;
    private string _message;

    public string title
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._title;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_story_QuestStoryClearMessage_title_" + (object) this.ID, out Translation) ? Translation : this._title;
      }
      set => this._title = value;
    }

    public string message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_story_QuestStoryClearMessage_message_" + (object) this.ID, out Translation) ? Translation : this._message;
      }
      set => this._message = value;
    }

    public static QuestStoryClearMessage Parse(MasterDataReader reader)
    {
      return new QuestStoryClearMessage()
      {
        ID = reader.ReadInt(),
        is_firsttime = reader.ReadBool(),
        quest_s_id = reader.ReadInt(),
        title = reader.ReadString(true),
        message = reader.ReadString(true)
      };
    }
  }
}
