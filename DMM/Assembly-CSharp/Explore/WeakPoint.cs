// Decompiled with JetBrains decompiler
// Type: Explore.WeakPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;

namespace Explore
{
  public class WeakPoint
  {
    public const float COEFFICIENT_ELM = 0.3f;
    public const float COEFFICIENT_GEA = 0.3f;
    public const float COEFFICIENT_PRI = 0.3f;
    public CommonElement[] Element;
    public GearKindEnum[] Gearkind;
    public UnitTypeEnum[] PrincessType;

    public WeakPoint(
      CommonElement[] elements,
      GearKindEnum[] gearkinds,
      UnitTypeEnum[] princessTypes)
    {
      this.Element = elements;
      this.Gearkind = gearkinds;
      this.PrincessType = princessTypes;
    }

    public float GetEffectiveCoefficient(EpPlayerUnit epUnit)
    {
      float num = 1f;
      CommonElement element = epUnit.Element;
      foreach (CommonElement commonElement in this.Element)
      {
        if (commonElement == element)
        {
          num += 0.3f;
          break;
        }
      }
      UnitTypeEnum princessType = epUnit.PrincessType;
      foreach (UnitTypeEnum unitTypeEnum in this.PrincessType)
      {
        if (unitTypeEnum == princessType)
        {
          num += 0.3f;
          break;
        }
      }
      GearKindEnum gearKind = epUnit.GearKind;
      foreach (GearKindEnum gearKindEnum in this.Gearkind)
      {
        if (gearKindEnum == gearKind)
        {
          num += 0.3f;
          break;
        }
      }
      return num;
    }
  }
}
