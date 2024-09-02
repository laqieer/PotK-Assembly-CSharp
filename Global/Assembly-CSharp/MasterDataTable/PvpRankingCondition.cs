// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpRankingCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpRankingCondition
  {
    public int ID;
    private string _disp_text;
    public string image_name;
    public int priority;

    public string disp_text
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._disp_text;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("pvp_PvpRankingCondition_disp_text_" + (object) this.ID, out Translation) ? Translation : this._disp_text;
      }
      set => this._disp_text = value;
    }

    public static PvpRankingCondition Parse(MasterDataReader reader)
    {
      return new PvpRankingCondition()
      {
        ID = reader.ReadInt(),
        disp_text = reader.ReadString(true),
        image_name = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }
  }
}
