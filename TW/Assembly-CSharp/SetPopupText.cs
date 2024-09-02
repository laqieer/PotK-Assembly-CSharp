// Decompiled with JetBrains decompiler
// Type: SetPopupText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SetPopupText : MonoBehaviour
{
  public string text;
  public UILabel description;
  public bool enLarge;

  private void Start() => this.Update();

  private void Update()
  {
    if (!Object.op_Implicit((Object) this.description))
      return;
    if (this.enLarge)
      this.description.SetTextLocalize(this.text);
    else
      this.description.SetTextLocalize(this.text);
  }

  public void SetText(string txt, bool enL = true)
  {
    this.text = txt;
    this.enLarge = enL;
  }
}
