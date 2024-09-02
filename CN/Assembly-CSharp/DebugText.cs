// Decompiled with JetBrains decompiler
// Type: DebugText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
