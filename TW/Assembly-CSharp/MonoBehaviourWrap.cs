// Decompiled with JetBrains decompiler
// Type: MonoBehaviourWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class MonoBehaviourWrap
{
  private static System.Type classType = typeof (MonoBehaviour);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[12]
    {
      new LuaMethod("Invoke", new LuaCSFunction(MonoBehaviourWrap.Invoke)),
      new LuaMethod("InvokeRepeating", new LuaCSFunction(MonoBehaviourWrap.InvokeRepeating)),
      new LuaMethod("CancelInvoke", new LuaCSFunction(MonoBehaviourWrap.CancelInvoke)),
      new LuaMethod("IsInvoking", new LuaCSFunction(MonoBehaviourWrap.IsInvoking)),
      new LuaMethod("StartCoroutine", new LuaCSFunction(MonoBehaviourWrap.StartCoroutine)),
      new LuaMethod("StartCoroutine_Auto", new LuaCSFunction(MonoBehaviourWrap.StartCoroutine_Auto)),
      new LuaMethod("StopCoroutine", new LuaCSFunction(MonoBehaviourWrap.StopCoroutine)),
      new LuaMethod("StopAllCoroutines", new LuaCSFunction(MonoBehaviourWrap.StopAllCoroutines)),
      new LuaMethod("print", new LuaCSFunction(MonoBehaviourWrap.print)),
      new LuaMethod("New", new LuaCSFunction(MonoBehaviourWrap._CreateMonoBehaviour)),
      new LuaMethod("GetClassType", new LuaCSFunction(MonoBehaviourWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(MonoBehaviourWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("useGUILayout", new LuaCSFunction(MonoBehaviourWrap.get_useGUILayout), new LuaCSFunction(MonoBehaviourWrap.set_useGUILayout))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.MonoBehaviour", typeof (MonoBehaviour), regs, fields, typeof (Behaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateMonoBehaviour(IntPtr L)
  {
    LuaDLL.luaL_error(L, "MonoBehaviour class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, MonoBehaviourWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_useGUILayout(IntPtr L)
  {
    MonoBehaviour luaObject = (MonoBehaviour) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useGUILayout");
      else
        LuaDLL.luaL_error(L, "attempt to index useGUILayout on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.useGUILayout);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_useGUILayout(IntPtr L)
  {
    MonoBehaviour luaObject = (MonoBehaviour) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useGUILayout");
      else
        LuaDLL.luaL_error(L, "attempt to index useGUILayout on a nil value");
    }
    luaObject.useGUILayout = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Invoke(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).Invoke(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int InvokeRepeating(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).InvokeRepeating(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CancelInvoke(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).CancelInvoke();
        return 0;
      case 2:
        ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).CancelInvoke(LuaScriptMgr.GetLuaString(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.CancelInvoke");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsInvoking(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        bool b1 = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).IsInvoking();
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 2:
        bool b2 = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).IsInvoking(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, b2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.IsInvoking");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int StartCoroutine(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (MonoBehaviour), typeof (string)))
    {
      Coroutine o = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StartCoroutine(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (MonoBehaviour), typeof (IEnumerator)))
    {
      Coroutine o = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StartCoroutine((IEnumerator) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    if (num == 3)
    {
      Coroutine o = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StartCoroutine(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StartCoroutine");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int StartCoroutine_Auto(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Coroutine o = ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StartCoroutine_Auto((IEnumerator) LuaScriptMgr.GetNetObject(L, 2, typeof (IEnumerator)));
    LuaScriptMgr.PushObject(L, (object) o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int StopCoroutine(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (MonoBehaviour), typeof (Coroutine)))
    {
      ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StopCoroutine((Coroutine) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (MonoBehaviour), typeof (IEnumerator)))
    {
      ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StopCoroutine((IEnumerator) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (MonoBehaviour), typeof (string)))
    {
      ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StopCoroutine(LuaScriptMgr.GetString(L, 2));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StopCoroutine");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int StopAllCoroutines(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((MonoBehaviour) LuaScriptMgr.GetUnityObjectSelf(L, 1, "MonoBehaviour")).StopAllCoroutines();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int print(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    MonoBehaviour.print(LuaScriptMgr.GetVarObject(L, 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
