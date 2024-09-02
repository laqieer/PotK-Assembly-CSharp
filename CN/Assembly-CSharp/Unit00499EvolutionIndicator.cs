// Decompiled with JetBrains decompiler
// Type: Unit00499EvolutionIndicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Unit00499EvolutionIndicator : MonoBehaviour
{
  public UILabel[] linkEvolutionUnitsPossessionLabel;
  public GameObject[] linkEvolutionUnits;
  public Unit00499EvolutionIndicator.ButtonIcon[] linkSelectableUnits;
  public UILabel TxtZeny;
  public UILabel TxtZenyNeed;

  [Serializable]
  public class ButtonIcon
  {
    public GameObject top_;
    public LongPressButton button_;
  }
}
