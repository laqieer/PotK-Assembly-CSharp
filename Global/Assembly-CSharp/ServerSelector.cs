// Decompiled with JetBrains decompiler
// Type: ServerSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ServerSelector : MonoBehaviour
{
  private const string PRODUCTION_API_URL = "https://us01-punkww.gu3.jp/";
  private const string PRODUCTION_DLC_URL = "https://punkww-dlc.gu3.jp/dlc/production/v2/android/";

  public static string ApiUrl => "https://us01-punkww.gu3.jp/";

  public static string DlcUrl => "https://punkww-dlc.gu3.jp/dlc/production/v2/android/";

  public static bool IsActive { get; private set; }
}
