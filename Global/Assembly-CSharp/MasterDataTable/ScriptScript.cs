// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ScriptScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ScriptScript
  {
    public int ID;
    public string script;

    public static ScriptScript Parse(MasterDataReader reader)
    {
      return new ScriptScript()
      {
        ID = reader.ReadInt(),
        script = reader.ReadString(true)
      };
    }
  }
}
