// Decompiled with JetBrains decompiler
// Type: DebugText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DebugText : Singleton<DebugText>
{
  public bool isShow;

  protected override void Initialize()
  {
  }

  public static void Start(Application.LogCallback chain = null)
  {
    Application.RegisterLogCallback((Application.LogCallback) ((condition, stacktrace, type) =>
    {
      if (chain == null)
        return;
      chain(condition, stacktrace, type);
    }));
  }

  private static void Log(string condition, string stacktrace, LogType type)
  {
  }

  public static Application.LogCallback LogCallback => new Application.LogCallback(DebugText.Log);
}
