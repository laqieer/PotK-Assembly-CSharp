// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BeginnerNaviDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BeginnerNaviDetail
  {
    public int ID;
    public int title_BeginnerNaviTitle;
    private string _questionText;
    private string _answerText;
    public string descriptionImage;
    public int movePage_BeginnerNaviMovePage;
    public int frameNumber;

    public string questionText
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._questionText;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("beginnernavi_BeginnerNaviDetail_questionText_" + (object) this.ID, out Translation) ? Translation : this._questionText;
      }
      set => this._questionText = value;
    }

    public string answerText
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._answerText;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("beginnernavi_BeginnerNaviDetail_answerText_" + (object) this.ID, out Translation) ? Translation : this._answerText;
      }
      set => this._answerText = value;
    }

    public static BeginnerNaviDetail Parse(MasterDataReader reader)
    {
      return new BeginnerNaviDetail()
      {
        ID = reader.ReadInt(),
        title_BeginnerNaviTitle = reader.ReadInt(),
        questionText = reader.ReadString(true),
        answerText = reader.ReadString(true),
        descriptionImage = reader.ReadString(true),
        movePage_BeginnerNaviMovePage = reader.ReadInt(),
        frameNumber = reader.ReadInt()
      };
    }

    public BeginnerNaviTitle title
    {
      get
      {
        BeginnerNaviTitle title;
        if (!MasterData.BeginnerNaviTitle.TryGetValue(this.title_BeginnerNaviTitle, out title))
          Debug.LogError((object) ("Key not Found: MasterData.BeginnerNaviTitle[" + (object) this.title_BeginnerNaviTitle + "]"));
        return title;
      }
    }

    public BeginnerNaviMovePage movePage
    {
      get
      {
        BeginnerNaviMovePage movePage;
        if (!MasterData.BeginnerNaviMovePage.TryGetValue(this.movePage_BeginnerNaviMovePage, out movePage))
          Debug.LogError((object) ("Key not Found: MasterData.BeginnerNaviMovePage[" + (object) this.movePage_BeginnerNaviMovePage + "]"));
        return movePage;
      }
    }
  }
}
