// Decompiled with JetBrains decompiler
// Type: CommonFooterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
