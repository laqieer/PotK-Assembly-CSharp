// Decompiled with JetBrains decompiler
// Type: PresentInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;

#nullable disable
public class PresentInfo
{
  public Mypage0017Scroll scroll;

  public PlayerPresent present { get; set; }

  public PresentInfo TempCopy()
  {
    PresentInfo presentInfo = (PresentInfo) this.MemberwiseClone();
    presentInfo.scroll = (Mypage0017Scroll) null;
    return presentInfo;
  }
}
