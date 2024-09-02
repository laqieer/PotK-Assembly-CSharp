// Decompiled with JetBrains decompiler
// Type: GuideUnitEvolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class GuideUnitEvolution : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite rarityStars;
  public GameObject selectObj;
  public GameObject hatenaObj;
  public UIButton button;
  public UnitUnit unitData;
  public Guide01122Menu menu;

  public void pressButton() => this.menu.IbtnEvolution(this);

  public void Set(UnitUnit unit, bool select, bool hatena)
  {
    this.unitData = unit;
    ((Behaviour) this.button).enabled = true;
    this.SetSelect(select);
    this.SetHatena(hatena);
  }

  public void SetSelect(bool flag)
  {
    if (flag)
    {
      this.selectObj.SetActive(true);
      ((Behaviour) this.button).enabled = false;
    }
    else
      this.selectObj.SetActive(false);
  }

  public void SetHatena(bool flag)
  {
    if (flag)
    {
      this.hatenaObj.SetActive(true);
      ((Behaviour) this.button).enabled = false;
      ((Component) this.button).GetComponent<Collider>().enabled = false;
    }
    else
    {
      this.hatenaObj.SetActive(false);
      RarityIcon.SetRarity(this.unitData, this.rarityStars, false, true);
    }
  }
}
