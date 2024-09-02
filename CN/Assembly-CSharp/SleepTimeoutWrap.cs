// Decompiled with JetBrains decompiler
// Type: SleepTimeoutWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class SleepTimeoutWrap
{
  private static System.Type classType = typeof (SleepTimeout);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[2]
    {
      new LuaMethod("New", new LuaCSFunction(SleepTimeoutWrap._CreateSleepTimeout)),
      new LuaMethod("GetClassType", new LuaCSFunction(SleepTimeoutWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("NeverSleep", new LuaCSFunction(SleepTimeoutWrap.get_NeverSleep), (LuaCSFunction) null),
      new LuaField("SystemSetting", new LuaCSFunction(SleepTimeoutWrap.get_SystemSetting), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.SleepTimeout", typeof (SleepTimeout), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateSleepTimeout(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      SleepTimeout o = new SleepTimeout();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: SleepTimeout.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, SleepTimeoutWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_NeverSleep(IntPtr L)
  {
    LuaScriptMgr.Push(L, -1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_SystemSetting(IntPtr L)
  {
    LuaScriptMgr.Push(L, -2);
    return 1;
  }
}
