// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DateScriptParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class DateScriptParts
  {
    public int ID;
    public int unitID;
    public string scriptID;
    public string script;

    public static DateScriptParts Parse(MasterDataReader reader) => new DateScriptParts()
    {
      ID = reader.ReadInt(),
      unitID = reader.ReadInt(),
      scriptID = reader.ReadString(true),
      script = reader.ReadString(true)
    };
  }
}
