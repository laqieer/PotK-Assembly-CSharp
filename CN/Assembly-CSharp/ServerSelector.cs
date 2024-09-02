// Decompiled with JetBrains decompiler
// Type: ServerSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ServerSelector : MonoBehaviour
{
  private static bool isSubmitEnv;

  public static string MOBAGE_TOKEN_URL => GameConfig.AccountServer;

  public static string PRODUCTION_API_URL => GameConfig.GameServer;

  public static string PRODUCTION_DLC_URL => GameConfig.DLCServer;

  public static string ApiUrl => ServerSelector.PRODUCTION_API_URL;

  public static string DlcUrl => ServerSelector.PRODUCTION_DLC_URL;

  public static string MobageTokenURL => ServerSelector.MOBAGE_TOKEN_URL;

  public static bool IsActive { get; private set; }

  public static void SetSubmitEnv(bool submitEnv) => ServerSelector.isSubmitEnv = submitEnv;
}
