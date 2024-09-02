// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.GameInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames
{
  public static class GameInfo
  {
    private const string UnescapedApplicationId = "APP_ID";
    private const string UnescapedIosClientId = "IOS_CLIENTID";
    private const string UnescapedWebClientId = "WEB_CLIENTID";
    private const string UnescapedNearbyServiceId = "NEARBY_SERVICE_ID";
    private const string UnescapedRequireGooglePlus = "REQUIRE_GOOGLE_PLUS";
    public const string ApplicationId = "392998474285";
    public const string IosClientId = "";
    public const string WebClientId = "";
    public const string NearbyConnectionServiceId = "";

    public static bool RequireGooglePlus() => false;

    public static bool ApplicationIdInitialized()
    {
      return !string.IsNullOrEmpty("392998474285") && !"392998474285".Equals(GameInfo.ToEscapedToken("APP_ID"));
    }

    public static bool IosClientIdInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("IOS_CLIENTID"));
    }

    public static bool WebClientIdInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("WEB_CLIENTID"));
    }

    public static bool NearbyConnectionsInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("NEARBY_SERVICE_ID"));
    }

    private static string ToEscapedToken(string token) => string.Format("__{0}__", (object) token);
  }
}
