// Decompiled with JetBrains decompiler
// Type: EarthUnitNumIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class EarthUnitNumIcon : MonoBehaviour
{
  [SerializeField]
  private GameObject[] dirDigitBase;
  [SerializeField]
  private GameObject[] numBase;
  [SerializeField]
  private UI2DSprite[] tenUnderDigitOne;
  [SerializeField]
  private UI2DSprite[] tenOverDigitOne;
  [SerializeField]
  private UI2DSprite[] tenOverDigitTwo;

  public void SetNumIcon(int num, bool isGorgeous = false)
  {
    ((IEnumerable<GameObject>) this.numBase).ToggleOnce(isGorgeous ? 1 : 0);
    EarthUnitNumIcon.DigitType index = num < 10 ? EarthUnitNumIcon.DigitType.One : EarthUnitNumIcon.DigitType.Tne;
    int num1 = num % 10;
    int num2 = num / 10;
    ((IEnumerable<GameObject>) this.dirDigitBase).ToggleOnce((int) index);
    if (index == EarthUnitNumIcon.DigitType.Tne)
    {
      this.ChangeNumSprite(this.tenOverDigitOne, num1);
      this.ChangeNumSprite(this.tenOverDigitTwo, num2);
    }
    else
      this.ChangeNumSprite(this.tenUnderDigitOne, num1);
  }

  private void ChangeNumSprite(UI2DSprite[] sprites, int num)
  {
    int length = sprites.Length;
    for (int index = 0; index < length; ++index)
    {
      ((Component) sprites[index]).gameObject.SetActive(false);
      if (index == num)
        ((Component) sprites[index]).gameObject.SetActive(true);
    }
  }

  private enum DigitType
  {
    One,
    Tne,
  }

  private enum Leader
  {
    None,
    Leader,
  }
}
