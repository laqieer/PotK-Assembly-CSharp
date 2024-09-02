// Decompiled with JetBrains decompiler
// Type: TimeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TimeWrap
{
  private static System.Type classType = typeof (Time);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[2]
    {
      new LuaMethod("New", new LuaCSFunction(TimeWrap._CreateTime)),
      new LuaMethod("GetClassType", new LuaCSFunction(TimeWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[14]
    {
      new LuaField("time", new LuaCSFunction(TimeWrap.get_time), (LuaCSFunction) null),
      new LuaField("timeSinceLevelLoad", new LuaCSFunction(TimeWrap.get_timeSinceLevelLoad), (LuaCSFunction) null),
      new LuaField("deltaTime", new LuaCSFunction(TimeWrap.get_deltaTime), (LuaCSFunction) null),
      new LuaField("fixedTime", new LuaCSFunction(TimeWrap.get_fixedTime), (LuaCSFunction) null),
      new LuaField("unscaledTime", new LuaCSFunction(TimeWrap.get_unscaledTime), (LuaCSFunction) null),
      new LuaField("unscaledDeltaTime", new LuaCSFunction(TimeWrap.get_unscaledDeltaTime), (LuaCSFunction) null),
      new LuaField("fixedDeltaTime", new LuaCSFunction(TimeWrap.get_fixedDeltaTime), new LuaCSFunction(TimeWrap.set_fixedDeltaTime)),
      new LuaField("maximumDeltaTime", new LuaCSFunction(TimeWrap.get_maximumDeltaTime), new LuaCSFunction(TimeWrap.set_maximumDeltaTime)),
      new LuaField("smoothDeltaTime", new LuaCSFunction(TimeWrap.get_smoothDeltaTime), (LuaCSFunction) null),
      new LuaField("timeScale", new LuaCSFunction(TimeWrap.get_timeScale), new LuaCSFunction(TimeWrap.set_timeScale)),
      new LuaField("frameCount", new LuaCSFunction(TimeWrap.get_frameCount), (LuaCSFunction) null),
      new LuaField("renderedFrameCount", new LuaCSFunction(TimeWrap.get_renderedFrameCount), (LuaCSFunction) null),
      new LuaField("realtimeSinceStartup", new LuaCSFunction(TimeWrap.get_realtimeSinceStartup), (LuaCSFunction) null),
      new LuaField("captureFramerate", new LuaCSFunction(TimeWrap.get_captureFramerate), new LuaCSFunction(TimeWrap.set_captureFramerate))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Time", typeof (Time), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTime(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Time o = new Time();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Time.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TimeWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_time(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.time);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_timeSinceLevelLoad(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.timeSinceLevelLoad);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_deltaTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.deltaTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fixedTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.fixedTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_unscaledTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.unscaledTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_unscaledDeltaTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.unscaledDeltaTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fixedDeltaTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.fixedDeltaTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maximumDeltaTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.maximumDeltaTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_smoothDeltaTime(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.smoothDeltaTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_timeScale(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.timeScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_frameCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.frameCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_renderedFrameCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.renderedFrameCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_realtimeSinceStartup(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.realtimeSinceStartup);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_captureFramerate(IntPtr L)
  {
    LuaScriptMgr.Push(L, Time.captureFramerate);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fixedDeltaTime(IntPtr L)
  {
    Time.fixedDeltaTime = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maximumDeltaTime(IntPtr L)
  {
    Time.maximumDeltaTime = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_timeScale(IntPtr L)
  {
    Time.timeScale = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_captureFramerate(IntPtr L)
  {
    Time.captureFramerate = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }
}
