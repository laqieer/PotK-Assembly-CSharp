// Decompiled with JetBrains decompiler
// Type: SpreadColorSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/NGUI SpreadColorSprite")]
public class SpreadColorSprite : UISprite
{
  private UIWidget[] objs;

  protected override void OnInit()
  {
    this.objs = this.gameObject.GetComponentsInChildren<UIWidget>(true);
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
