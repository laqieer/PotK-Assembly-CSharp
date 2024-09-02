// Decompiled with JetBrains decompiler
// Type: AsyncOperationWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AsyncOperationWrap
{
  private static System.Type classType = typeof (AsyncOperation);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[2]
    {
      new LuaMethod("New", new LuaCSFunction(AsyncOperationWrap._CreateAsyncOperation)),
      new LuaMethod("GetClassType", new LuaCSFunction(AsyncOperationWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[4]
    {
      new LuaField("isDone", new LuaCSFunction(AsyncOperationWrap.get_isDone), (LuaCSFunction) null),
      new LuaField("progress", new LuaCSFunction(AsyncOperationWrap.get_progress), (LuaCSFunction) null),
      new LuaField("priority", new LuaCSFunction(AsyncOperationWrap.get_priority), new LuaCSFunction(AsyncOperationWrap.set_priority)),
      new LuaField("allowSceneActivation", new LuaCSFunction(AsyncOperationWrap.get_allowSceneActivation), new LuaCSFunction(AsyncOperationWrap.set_allowSceneActivation))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AsyncOperation", typeof (AsyncOperation), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAsyncOperation(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AsyncOperation o = new AsyncOperation();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AsyncOperation.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AsyncOperationWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isDone(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isDone");
      else
        LuaDLL.luaL_error(L, "attempt to index isDone on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isDone);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_progress(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name progress");
      else
        LuaDLL.luaL_error(L, "attempt to index progress on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.progress);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_priority(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name priority");
      else
        LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.priority);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_allowSceneActivation(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
      else
        LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.allowSceneActivation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_priority(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name priority");
      else
        LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
    }
    luaObject.priority = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_allowSceneActivation(IntPtr L)
  {
    AsyncOperation luaObject = (AsyncOperation) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
      else
        LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
    }
    luaObject.allowSceneActivation = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }
}
