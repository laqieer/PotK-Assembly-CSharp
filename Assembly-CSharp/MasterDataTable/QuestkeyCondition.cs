// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestkeyCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestkeyCondition
  {
    public int ID;
    public int gate_id;
    public string contents;

    public static QuestkeyCondition Parse(MasterDataReader reader) => new QuestkeyCondition()
    {
      ID = reader.ReadInt(),
      gate_id = reader.ReadInt(),
      contents = reader.ReadString(true)
    };
  }
}
