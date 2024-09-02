// Decompiled with JetBrains decompiler
// Type: ServerTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public static class ServerTime
{
  private static readonly TimeSpan nextSyncSpan = new TimeSpan(0, 5, 0);
  private static bool isInit = false;
  private static DateTime nextSyncLocalTime;
  private static DateTime lastSyncServerTime;
  private static DateTime lastSyncLocalTime;

  public static void SetSyncServerTime(DateTime serverTime)
  {
    ServerTime.isInit = true;
    ServerTime.lastSyncServerTime = serverTime;
    ServerTime.lastSyncLocalTime = DateTime.Now;
    ServerTime.nextSyncLocalTime = DateTime.UtcNow.Add(ServerTime.nextSyncSpan);
  }

  [DebuggerHidden]
  public static IEnumerator WaitSync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ServerTime.\u003CWaitSync\u003Ec__IteratorB38 syncCIteratorB38 = new ServerTime.\u003CWaitSync\u003Ec__IteratorB38();
    return (IEnumerator) syncCIteratorB38;
  }

  public static DateTime NowAppTime()
  {
    if (ServerTime.isInit)
      return ServerTime.lastSyncServerTime;
    Debug.LogError((object) "wait for API response. so return localtime");
    return DateTime.UtcNow.AddHours(Consts.GetInstance().APP_TIME_ZONE);
  }

  public static DateTime LastSyncLocalTime()
  {
    if (ServerTime.isInit)
      return ServerTime.lastSyncLocalTime;
    Debug.LogError((object) "wait for API response. so return localtime");
    return DateTime.UtcNow.AddHours(Consts.GetInstance().APP_TIME_ZONE);
  }

  private static bool needUpdate()
  {
    return !ServerTime.isInit || DateTime.UtcNow > ServerTime.nextSyncLocalTime;
  }

  public static DateTime NowAppTimeAddDelta()
  {
    TimeSpan timeSpan = ServerTime.nextSyncSpan - (ServerTime.nextSyncLocalTime - DateTime.UtcNow);
    return ServerTime.lastSyncServerTime.Add(timeSpan);
  }
}
