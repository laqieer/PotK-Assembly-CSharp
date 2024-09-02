// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DuelElementHitEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DuelElementHitEffect
  {
    public int ID;
    public string original_effect_name;
    public int element_CommonElement;
    public string change_effect_name;

    public static DuelElementHitEffect Parse(MasterDataReader reader)
    {
      return new DuelElementHitEffect()
      {
        ID = reader.ReadInt(),
        original_effect_name = reader.ReadStringOrNull(true),
        element_CommonElement = reader.ReadInt(),
        change_effect_name = reader.ReadStringOrNull(true)
      };
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;
  }
}
