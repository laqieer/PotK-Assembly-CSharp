// Decompiled with JetBrains decompiler
// Type: SetPopupText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
