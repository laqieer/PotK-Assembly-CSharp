// Decompiled with JetBrains decompiler
// Type: NGFullWidthGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NGFullWidthGrid : UIGrid
{
  protected override void Init()
  {
    base.Init();
    this.mPanel.UpdateAnchors();
    this.cellWidth = this.mPanel.width;
  }

  public override void Reposition()
  {
    if (!this.mInitDone)
      base.Init();
    if ((Object) this.mPanel != (Object) null)
    {
      this.mPanel.UpdateAnchors();
      if ((double) this.cellWidth != (double) this.mPanel.width)
        this.cellWidth = this.mPanel.width;
    }
    base.Reposition();
  }
}
