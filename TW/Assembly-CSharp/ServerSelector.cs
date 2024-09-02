// Decompiled with JetBrains decompiler
// Type: ServerSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public static class ServerSelector
{
  private static bool isSubmitEnv;

  public static string MOBAGE_TOKEN_URL => GameConfig.AccountServer;

  public static string PRODUCTION_API_URL => GameConfig.GameServer;

  public static string PRODUCTION_DLC_URL => GameConfig.DLCServer;

  public static string ApiUrl => ServerSelector.PRODUCTION_API_URL;

  public static string DlcUrl => ServerSelector.PRODUCTION_DLC_URL + GameConfig.DLCPath;

  public static void SetSubmitEnv(bool submitEnv) => ServerSelector.isSubmitEnv = submitEnv;
}
