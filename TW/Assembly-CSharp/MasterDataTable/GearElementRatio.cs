// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearElementRatio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearElementRatio
  {
    public int ID;
    public int element_CommonElement;
    public int family_UnitFamily;
    public float ratio;

    public static GearElementRatio Parse(MasterDataReader reader)
    {
      return new GearElementRatio()
      {
        ID = reader.ReadInt(),
        element_CommonElement = reader.ReadInt(),
        family_UnitFamily = reader.ReadInt(),
        ratio = reader.ReadFloat()
      };
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;

    public UnitFamily family => (UnitFamily) this.family_UnitFamily;
  }
}
