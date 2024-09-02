// Decompiled with JetBrains decompiler
// Type: EquipmentRules.Reisou
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

namespace EquipmentRules
{
  public static class Reisou
  {
    public static PlayerItem checkPossibleEquipped(PlayerItem gear, PlayerItem reisou)
    {
      int? nullable1 = (object) gear != null ? new int?(gear.gear.kind_GearKind) : new int?();
      int? nullable2 = (object) reisou != null ? new int?(reisou.gear.kind_GearKind) : new int?();
      return !(nullable1.GetValueOrDefault() == nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue) ? (PlayerItem) null : reisou;
    }
  }
}
