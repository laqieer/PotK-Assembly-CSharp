// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonElementName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace MasterDataTable
{
  [Serializable]
  public class CommonElementName
  {
    private static readonly Dictionary<string, string> convTable_ = new Dictionary<string, string>()
    {
      {
        "火",
        "炎"
      }
    };
    public int ID;
    public string name;

    public static string GetName(int commonElementId)
    {
      CommonElementName commonElementName;
      string str;
      if (MasterData.CommonElementName.TryGetValue(commonElementId, out commonElementName))
      {
        if (!CommonElementName.convTable_.TryGetValue(commonElementName.name, out str))
          str = commonElementName.name;
      }
      else
        str = string.Empty;
      return str;
    }

    public static CommonElementName Parse(MasterDataReader reader) => new CommonElementName()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true)
    };
  }
}
