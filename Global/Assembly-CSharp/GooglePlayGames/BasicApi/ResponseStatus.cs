// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.ResponseStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public enum ResponseStatus
  {
    Timeout = -5, // 0xFFFFFFFB
    VersionUpdateRequired = -4, // 0xFFFFFFFC
    NotAuthorized = -3, // 0xFFFFFFFD
    InternalError = -2, // 0xFFFFFFFE
    LicenseCheckFailed = -1, // 0xFFFFFFFF
    Success = 1,
    SuccessWithStale = 2,
  }
}
