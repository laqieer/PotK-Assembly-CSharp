// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.UIStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public enum UIStatus
  {
    LeftRoom = -18, // 0xFFFFFFEE
    UiBusy = -12, // 0xFFFFFFF4
    UserClosedUI = -6, // 0xFFFFFFFA
    Timeout = -5, // 0xFFFFFFFB
    VersionUpdateRequired = -4, // 0xFFFFFFFC
    NotAuthorized = -3, // 0xFFFFFFFD
    InternalError = -2, // 0xFFFFFFFE
    Valid = 1,
  }
}
