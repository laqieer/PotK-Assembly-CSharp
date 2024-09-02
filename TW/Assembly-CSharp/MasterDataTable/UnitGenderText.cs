// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGenderText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
