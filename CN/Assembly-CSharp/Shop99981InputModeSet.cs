// Decompiled with JetBrains decompiler
// Type: Shop99981InputModeSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  private void Update()
  {
  }

  public void setKeyboardTypeNumber()
  {
    this.nen.keyboardType = UIInput.KeyboardType.NumberPad;
    this.getsu.keyboardType = UIInput.KeyboardType.NumberPad;
    this.hi.keyboardType = UIInput.KeyboardType.NumberPad;
  }
}
