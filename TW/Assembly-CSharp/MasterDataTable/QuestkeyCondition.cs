// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestkeyCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestkeyCondition
  {
    public int ID;
    public int gate_id;
    public string contents;

    public static QuestkeyCondition Parse(MasterDataReader reader)
    {
      return new QuestkeyCondition()
      {
        ID = reader.ReadInt(),
        gate_id = reader.ReadInt(),
        contents = reader.ReadString(true)
      };
    }
  }
}
