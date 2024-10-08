﻿// Decompiled with JetBrains decompiler
// Type: AppSetup.AppSetupFPS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace AppSetup
{
  public class AppSetupFPS
  {
    public static void SetDefault() => AppSetupFPS.SetMaxFPS(Persist.appFPS.Data.MaxFPS);

    public static void SetMaxFPS(int fps)
    {
      QualitySettings.vSyncCount = 0;
      Application.targetFrameRate = fps;
    }

    public static int GetMaxFPS() => Application.targetFrameRate;
  }
}
