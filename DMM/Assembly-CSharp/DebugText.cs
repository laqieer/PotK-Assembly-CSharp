﻿// Decompiled with JetBrains decompiler
// Type: DebugText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DebugText : Singleton<DebugText>
{
  protected override void Initialize()
  {
  }

  public bool isShow => false;

  public static void Log(string condition, string stacktrace, LogType type)
  {
  }
}
