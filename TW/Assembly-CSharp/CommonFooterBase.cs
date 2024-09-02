// Decompiled with JetBrains decompiler
// Type: CommonFooterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CommonFooterBase : NGMenuBase
{
  public void setDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = new Color(0.4117647f, 0.4117647f, 0.4117647f);
  }

  public void resetDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = Color.white;
  }
}
