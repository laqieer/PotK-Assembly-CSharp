// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearClassificationPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearClassificationPattern
  {
    public int ID;
    public int kind_GearKind;
    public string name;
    public int attack_classification_GearAttackClassification;

    public static GearClassificationPattern Parse(MasterDataReader reader) => new GearClassificationPattern()
    {
      ID = reader.ReadInt(),
      kind_GearKind = reader.ReadInt(),
      name = reader.ReadString(true),
      attack_classification_GearAttackClassification = reader.ReadInt()
    };

    public GearKind kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind + "]"));
        return gearKind;
      }
    }

    public GearAttackClassification attack_classification => (GearAttackClassification) this.attack_classification_GearAttackClassification;
  }
}
