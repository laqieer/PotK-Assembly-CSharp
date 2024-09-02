// Decompiled with JetBrains decompiler
// Type: SpreadColorSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
