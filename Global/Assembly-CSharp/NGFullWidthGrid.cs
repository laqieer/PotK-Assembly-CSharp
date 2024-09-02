// Decompiled with JetBrains decompiler
// Type: NGFullWidthGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class NGFullWidthGrid : UIGrid
{
  protected override void Init()
  {
    base.Init();
    this.cellWidth = this.mPanel.width;
  }
}
