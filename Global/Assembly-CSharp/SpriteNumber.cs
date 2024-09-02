// Decompiled with JetBrains decompiler
// Type: SpriteNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpriteNumber : MonoBehaviour
{
  [SerializeField]
  private SpriteNumberSelectDirect[] numbers;
  [SerializeField]
  private int colorChangeLimit = 5;

  private void Awake() => this.initialize();

  private void initialize()
  {
    if (this.numbers != null)
      return;
    this.numbers = ((Component) this).gameObject.GetComponentsInChildren<SpriteNumberSelectDirect>();
  }

  public void setNumber(int n)
  {
    this.initialize();
    int num = 10;
    Color col = this.colorChangeLimit == -1 || n >= this.colorChangeLimit ? PunkColor.button_on : new Color(1f, 0.5f, 0.5f, 1f);
    for (int index = 0; index < this.numbers.Length; ++index)
    {
      this.numbers[index].setNumber(n % num, col);
      n /= num;
    }
  }
}
