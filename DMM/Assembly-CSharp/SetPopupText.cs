﻿// Decompiled with JetBrains decompiler
// Type: SetPopupText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SetPopupText : MonoBehaviour
{
  public string text;
  public UILabel description;
  public bool enLarge;

  private void Start() => this.Update();

  private void Update()
  {
    if (!(bool) (Object) this.description)
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
