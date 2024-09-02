// Decompiled with JetBrains decompiler
// Type: SpreadColorSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/NGUI SpreadColorSprite")]
[ExecuteInEditMode]
public class SpreadColorSprite : UISprite
{
  private UIWidget[] objs;

  protected override void OnInit()
  {
    this.objs = ((Component) this).gameObject.GetComponentsInChildren<UIWidget>(true);
    base.OnInit();
  }

  public override void Invalidate(bool includeChildren)
  {
    if (this.objs != null)
    {
      foreach (UIWidget uiWidget in this.objs)
        uiWidget.color = this.color;
    }
    base.Invalidate(includeChildren);
  }
}
