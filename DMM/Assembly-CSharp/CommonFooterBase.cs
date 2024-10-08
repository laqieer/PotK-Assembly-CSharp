﻿// Decompiled with JetBrains decompiler
// Type: CommonFooterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CommonFooterBase : NGMenuBase
{
  [SerializeField]
  protected UISprite[] mainButtons;

  public void setDisableColor()
  {
    Color color = new Color(0.4117647f, 0.4117647f, 0.4117647f);
    for (int index = 0; index < this.mainButtons.Length; ++index)
      this.mainButtons[index].color = new Color(color.r, color.g, color.b, this.mainButtons[index].color.a);
  }

  public void resetDisableColor()
  {
    Color color = new Color(0.5f, 0.5f, 0.5f);
    for (int index = 0; index < this.mainButtons.Length; ++index)
      this.mainButtons[index].color = new Color(color.r, color.g, color.b, this.mainButtons[index].color.a);
  }
}
