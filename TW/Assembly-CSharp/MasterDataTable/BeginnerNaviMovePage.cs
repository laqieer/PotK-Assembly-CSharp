// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BeginnerNaviMovePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BeginnerNaviMovePage
  {
    public int ID;
    public string name;
    public string moveScene;
    public string buttonImage;

    public static BeginnerNaviMovePage Parse(MasterDataReader reader)
    {
      return new BeginnerNaviMovePage()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        moveScene = reader.ReadString(true),
        buttonImage = reader.ReadString(true)
      };
    }
  }
}
