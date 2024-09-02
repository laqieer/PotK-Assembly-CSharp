// Decompiled with JetBrains decompiler
// Type: SpreadColorButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpreadColorButton : UIButton
{
  private UISprite btnSprite;
  private UIWidget[] objs;

  protected override void OnInit()
  {
    base.OnInit();
    this.btnSprite = ((Component) this).GetComponentInChildren<UISprite>();
    this.objs = ((Component) this).gameObject.GetComponentsInChildren<UIWidget>(true);
  }

  private void Update()
  {
    if (!Object.op_Inequality((Object) this.btnSprite, (Object) null))
      return;
    foreach (UIWidget uiWidget in this.objs)
      uiWidget.color = this.btnSprite.color;
  }
}
