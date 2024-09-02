// Decompiled with JetBrains decompiler
// Type: CommonFooterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class CommonFooterBase : NGMenuBase
{
  public void setDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
  }

  public void resetDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
  }
}
