// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGenderText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitGenderText
  {
    public int ID;
    public string name;

    public static UnitGenderText Parse(MasterDataReader reader)
    {
      return new UnitGenderText()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }

    public static string GetText(UnitGender gender)
    {
      UnitGenderText unitGenderText = (UnitGenderText) null;
      return MasterData.UnitGenderText.TryGetValue((int) gender, out unitGenderText) ? unitGenderText.name : string.Empty;
    }
  }
}
