// Decompiled with JetBrains decompiler
// Type: ScreenUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public static class ScreenUtil
{
  private const int STANDARD_SCREEN_HEIGHT = 1136;
  private static Vector2Int initResolution;

  private static void StoreInitResolution()
  {
    if (ScreenUtil.initResolution.x > 0 && ScreenUtil.initResolution.y > 0)
      return;
    ScreenUtil.initResolution = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
  }

  public static void RefreshPerformanceResolution()
  {
    if (PerformanceConfig.GetInstance().IsSpeedPriority)
      ScreenUtil.SetStandardResolution();
    else
      ScreenUtil.SetDefaultResolution();
  }

  public static void SetResolution(int width, int height)
  {
  }

  public static void SetDefaultResolution()
  {
    ScreenUtil.StoreInitResolution();
    ScreenUtil.SetResolution(ScreenUtil.initResolution.x, ScreenUtil.initResolution.y);
  }

  public static bool IsStandardResolutionOrLess() => Screen.currentResolution.height <= 1136;

  public static void SetStandardResolution()
  {
    ScreenUtil.StoreInitResolution();
    if (ScreenUtil.initResolution.y <= 1136)
      return;
    float num = 1136f / (float) ScreenUtil.initResolution.y;
    ScreenUtil.SetResolution((int) ((double) ScreenUtil.initResolution.x * (double) num), 1136);
  }

  public static void SetResolution_2_3()
  {
    ScreenUtil.StoreInitResolution();
    ScreenUtil.SetResolution(ScreenUtil.initResolution.x * 2 / 3, ScreenUtil.initResolution.y * 2 / 3);
  }

  public static void SetResolution_1_2()
  {
    ScreenUtil.StoreInitResolution();
    ScreenUtil.SetResolution(ScreenUtil.initResolution.x / 2, ScreenUtil.initResolution.y / 2);
  }

  public static void SetResolution_1_3()
  {
    ScreenUtil.StoreInitResolution();
    ScreenUtil.SetResolution(ScreenUtil.initResolution.x / 3, ScreenUtil.initResolution.y / 3);
  }

  public static void SetResolution_1_4()
  {
    ScreenUtil.StoreInitResolution();
    ScreenUtil.SetResolution(ScreenUtil.initResolution.x / 4, ScreenUtil.initResolution.y / 4);
  }
}
