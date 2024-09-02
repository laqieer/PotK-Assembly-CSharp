// Decompiled with JetBrains decompiler
// Type: NGFullWidthGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
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
    if (Object.op_Inequality((Object) this.mPanel, (Object) null))
    {
      this.mPanel.UpdateAnchors();
      if ((double) this.cellWidth != (double) this.mPanel.width)
        this.cellWidth = this.mPanel.width;
    }
    base.Reposition();
  }
}
