// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BeginnerNaviMovePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
