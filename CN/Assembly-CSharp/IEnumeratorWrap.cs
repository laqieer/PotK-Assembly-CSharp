// Decompiled with JetBrains decompiler
// Type: IEnumeratorWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;

#nullable disable
public class IEnumeratorWrap
{
  private static System.Type classType = typeof (IEnumerator);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[4]
    {
      new LuaMethod("MoveNext", new LuaCSFunction(IEnumeratorWrap.MoveNext)),
      new LuaMethod("Reset", new LuaCSFunction(IEnumeratorWrap.Reset)),
      new LuaMethod("New", new LuaCSFunction(IEnumeratorWrap._CreateIEnumerator)),
      new LuaMethod("GetClassType", new LuaCSFunction(IEnumeratorWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("Current", new LuaCSFunction(IEnumeratorWrap.get_Current), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "System.Collections.IEnumerator", typeof (IEnumerator), regs, fields, (System.Type) null);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateIEnumerator(IntPtr L)
  {
    LuaDLL.luaL_error(L, "IEnumerator class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, IEnumeratorWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Current(IntPtr L)
  {
    IEnumerator luaObject = (IEnumerator) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Current");
      else
        LuaDLL.luaL_error(L, "attempt to index Current on a nil value");
    }
    LuaScriptMgr.PushVarObject(L, luaObject.Current);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MoveNext(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = ((IEnumerator) LuaScriptMgr.GetNetObjectSelf(L, 1, "IEnumerator")).MoveNext();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Reset(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((IEnumerator) LuaScriptMgr.GetNetObjectSelf(L, 1, "IEnumerator")).Reset();
    return 0;
  }
}
