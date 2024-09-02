// Decompiled with JetBrains decompiler
// Type: MasterDataTable.AIScore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class AIScore
  {
    public int ID;
    public string name;
    public string exp;
    public float var1;
    public float var2;
    public float var3;

    public static AIScore Parse(MasterDataReader reader)
    {
      return new AIScore()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        exp = reader.ReadString(true),
        var1 = reader.ReadFloat(),
        var2 = reader.ReadFloat(),
        var3 = reader.ReadFloat()
      };
    }
  }
}
