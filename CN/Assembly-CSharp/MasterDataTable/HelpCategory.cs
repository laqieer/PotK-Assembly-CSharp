// Decompiled with JetBrains decompiler
// Type: MasterDataTable.HelpCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class HelpCategory
  {
    public int ID;
    public string name;
    public int priority;

    public static HelpCategory Parse(MasterDataReader reader)
    {
      return new HelpCategory()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }
  }
}
