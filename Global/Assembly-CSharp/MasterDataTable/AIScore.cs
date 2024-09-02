// Decompiled with JetBrains decompiler
// Type: MasterDataTable.AIScore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
