// Decompiled with JetBrains decompiler
// Type: AppConstWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class AppConstWrap
{
  private static System.Type classType = typeof (AppConst);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[2]
    {
      new LuaMethod("New", new LuaCSFunction(AppConstWrap._CreateAppConst)),
      new LuaMethod("GetClassType", new LuaCSFunction(AppConstWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[6]
    {
      new LuaField("UsePbc", new LuaCSFunction(AppConstWrap.get_UsePbc), (LuaCSFunction) null),
      new LuaField("UseLpeg", new LuaCSFunction(AppConstWrap.get_UseLpeg), (LuaCSFunction) null),
      new LuaField("UsePbLua", new LuaCSFunction(AppConstWrap.get_UsePbLua), (LuaCSFunction) null),
      new LuaField("UseCJson", new LuaCSFunction(AppConstWrap.get_UseCJson), (LuaCSFunction) null),
      new LuaField("UseSproto", new LuaCSFunction(AppConstWrap.get_UseSproto), (LuaCSFunction) null),
      new LuaField("uLuaPath", new LuaCSFunction(AppConstWrap.get_uLuaPath), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "AppConst", typeof (AppConst), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAppConst(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AppConst o = new AppConst();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AppConst.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AppConstWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UsePbc(IntPtr L)
  {
    LuaScriptMgr.Push(L, true);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UseLpeg(IntPtr L)
  {
    LuaScriptMgr.Push(L, true);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UsePbLua(IntPtr L)
  {
    LuaScriptMgr.Push(L, true);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UseCJson(IntPtr L)
  {
    LuaScriptMgr.Push(L, true);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UseSproto(IntPtr L)
  {
    LuaScriptMgr.Push(L, true);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_uLuaPath(IntPtr L)
  {
    LuaScriptMgr.Push(L, AppConst.uLuaPath);
    return 1;
  }
}
