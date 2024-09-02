// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGenderText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitGenderText
  {
    public int ID;
    public string name;

    public static UnitGenderText Parse(MasterDataReader reader) => new UnitGenderText()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true)
    };

    public static string GetText(UnitGender gender)
    {
      UnitGenderText unitGenderText = (UnitGenderText) null;
      return MasterData.UnitGenderText.TryGetValue((int) gender, out unitGenderText) ? unitGenderText.name : string.Empty;
    }
  }
}
