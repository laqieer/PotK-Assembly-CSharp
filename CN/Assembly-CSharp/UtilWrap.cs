// Decompiled with JetBrains decompiler
// Type: UtilWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class UtilWrap
{
  private static System.Type classType = typeof (Util);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[8]
    {
      new LuaMethod("LuaPath", new LuaCSFunction(UtilWrap.LuaPath)),
      new LuaMethod("Log", new LuaCSFunction(UtilWrap.Log)),
      new LuaMethod("LogWarning", new LuaCSFunction(UtilWrap.LogWarning)),
      new LuaMethod("LogError", new LuaCSFunction(UtilWrap.LogError)),
      new LuaMethod("ClearMemory", new LuaCSFunction(UtilWrap.ClearMemory)),
      new LuaMethod("CheckEnvironment", new LuaCSFunction(UtilWrap.CheckEnvironment)),
      new LuaMethod("New", new LuaCSFunction(UtilWrap._CreateUtil)),
      new LuaMethod("GetClassType", new LuaCSFunction(UtilWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "Util", typeof (Util), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUtil(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Util o = new Util();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Util.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UtilWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LuaPath(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = Util.LuaPath(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Log(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Util.Log(LuaScriptMgr.GetLuaString(L, 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LogWarning(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Util.LogWarning(LuaScriptMgr.GetLuaString(L, 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LogError(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Util.LogError(LuaScriptMgr.GetLuaString(L, 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ClearMemory(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    Util.ClearMemory();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckEnvironment(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    bool b = Util.CheckEnvironment();
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
