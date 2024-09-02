// Decompiled with JetBrains decompiler
// Type: PresentInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
