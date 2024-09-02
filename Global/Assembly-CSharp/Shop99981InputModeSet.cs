// Decompiled with JetBrains decompiler
// Type: Shop99981InputModeSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Shop99981InputModeSet : MonoBehaviour
{
  [SerializeField]
  protected UIInput nen;
  [SerializeField]
  protected UIInput getsu;
  [SerializeField]
  protected UIInput hi;

  private void Start() => this.setKeyboardTypeNumber();

  public void setKeyboardTypeNumber()
  {
    this.nen.keyboardType = UIInput.KeyboardType.NumberPad;
    this.getsu.keyboardType = UIInput.KeyboardType.NumberPad;
    this.hi.keyboardType = UIInput.KeyboardType.NumberPad;
  }
}
