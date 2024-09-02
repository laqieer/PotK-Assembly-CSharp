// Decompiled with JetBrains decompiler
// Type: Shop99981InputModeSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
