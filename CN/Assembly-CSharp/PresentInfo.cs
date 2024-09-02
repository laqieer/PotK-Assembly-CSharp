// Decompiled with JetBrains decompiler
// Type: PresentInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
