// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ScriptText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ScriptText
  {
    public int ID;
    private string _Text;

    public string Text
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._Text;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("script_ScriptText_Text_" + (object) this.ID, out Translation) ? Translation : this._Text;
      }
      set => this._Text = value;
    }

    public static ScriptText Parse(MasterDataReader reader)
    {
      return new ScriptText()
      {
        ID = reader.ReadInt(),
        Text = reader.ReadString(true)
      };
    }
  }
}
