// Decompiled with JetBrains decompiler
// Type: ServerTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public static class ServerTime
{
  private static readonly TimeSpan nextSyncSpan = new TimeSpan(0, 5, 0);
  private static bool isInit = false;
  private static DateTime nextSyncLocalTime;
  private static DateTime lastSyncServerTime;

  public static void SetSyncServerTime(DateTime serverTime)
  {
    ServerTime.isInit = true;
    ServerTime.lastSyncServerTime = serverTime;
    ServerTime.nextSyncLocalTime = DateTime.UtcNow.Add(ServerTime.nextSyncSpan);
  }

  [DebuggerHidden]
  public static IEnumerator WaitSync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ServerTime.\u003CWaitSync\u003Ec__Iterator8C8 syncCIterator8C8 = new ServerTime.\u003CWaitSync\u003Ec__Iterator8C8();
    return (IEnumerator) syncCIterator8C8;
  }

  public static DateTime NowAppTime()
  {
    if (ServerTime.isInit)
      return ServerTime.lastSyncServerTime;
    Debug.LogWarning((object) "wait for API response. so return localtime");
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
