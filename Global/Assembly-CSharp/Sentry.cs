// Decompiled with JetBrains decompiler
// Type: Sentry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public static class Sentry
{
  public static readonly int LIMIT_TIME_SECONDS = 30;
  public static readonly int MAX_SENDS_IN_TIME = 3;
  public static DateTime time;
  public static int send_count;
  private static int limited_send_count;

  public static void Start(MonoBehaviour mono, Application.LogCallback chain = null)
  {
    foreach (CrashReport report in CrashReport.reports)
    {
      mono.StartCoroutine(WebAPI.SendError("CrashReport at " + report.time.ToString(), report.text, (LogType) 4).Wait());
      report.Remove();
    }
    Application.logMessageReceived += (Application.LogCallback) ((condition, stacktrace, type) =>
    {
      if (chain != null)
        chain(condition, stacktrace, type);
      Sentry.Send(mono, condition, stacktrace, type);
    });
  }

  public static Application.LogCallback GetLogCallback(MonoBehaviour mono)
  {
    return (Application.LogCallback) ((condition, stacktrace, type) => Sentry.Send(mono, condition, stacktrace, type));
  }

  private static void Send(MonoBehaviour mono, string condition, string stacktrace, LogType type)
  {
    if (type == 3 || type == 2)
      return;
    DateTime now = DateTime.Now;
    TimeSpan timeSpan = now - Sentry.time;
    if (timeSpan.TotalSeconds < 0.0 || timeSpan.TotalSeconds >= (double) Sentry.LIMIT_TIME_SECONDS)
    {
      Sentry.time = now;
      if (Sentry.limited_send_count != 0)
        mono.StartCoroutine(WebAPI.SendError(condition + " with limited logs: " + (object) Sentry.limited_send_count, stacktrace, type).Wait());
      Sentry.send_count = 0;
      Sentry.limited_send_count = 0;
    }
    if (Sentry.send_count >= Sentry.MAX_SENDS_IN_TIME)
    {
      ++Sentry.limited_send_count;
    }
    else
    {
      mono.StartCoroutine(WebAPI.SendError(condition, stacktrace, type).Wait());
      ++Sentry.send_count;
    }
  }
}
