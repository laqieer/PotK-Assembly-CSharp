// Decompiled with JetBrains decompiler
// Type: DebuggerWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class DebuggerWrap
{
  private static System.Type classType = typeof (Debugger);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("Log", new LuaCSFunction(DebuggerWrap.Log)),
      new LuaMethod("LogWarning", new LuaCSFunction(DebuggerWrap.LogWarning)),
      new LuaMethod("LogError", new LuaCSFunction(DebuggerWrap.LogError)),
      new LuaMethod("New", new LuaCSFunction(DebuggerWrap._CreateDebugger)),
      new LuaMethod("GetClassType", new LuaCSFunction(DebuggerWrap.GetClassType))
    };
    LuaScriptMgr.RegisterLib(L, "Debugger", regs);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateDebugger(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Debugger class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, DebuggerWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Log(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    Debugger.Log(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetParamsObject(L, 2, num - 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LogWarning(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    Debugger.LogWarning(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetParamsObject(L, 2, num - 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LogError(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    Debugger.LogError(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetParamsObject(L, 2, num - 1));
    return 0;
  }
}
