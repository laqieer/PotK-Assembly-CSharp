// Decompiled with JetBrains decompiler
// Type: RectTransformWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class RectTransformWrap
{
  private static System.Type classType = typeof (RectTransform);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[7]
    {
      new LuaMethod("GetLocalCorners", new LuaCSFunction(RectTransformWrap.GetLocalCorners)),
      new LuaMethod("GetWorldCorners", new LuaCSFunction(RectTransformWrap.GetWorldCorners)),
      new LuaMethod("SetInsetAndSizeFromParentEdge", new LuaCSFunction(RectTransformWrap.SetInsetAndSizeFromParentEdge)),
      new LuaMethod("SetSizeWithCurrentAnchors", new LuaCSFunction(RectTransformWrap.SetSizeWithCurrentAnchors)),
      new LuaMethod("New", new LuaCSFunction(RectTransformWrap._CreateRectTransform)),
      new LuaMethod("GetClassType", new LuaCSFunction(RectTransformWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(RectTransformWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[9]
    {
      new LuaField("rect", new LuaCSFunction(RectTransformWrap.get_rect), (LuaCSFunction) null),
      new LuaField("anchorMin", new LuaCSFunction(RectTransformWrap.get_anchorMin), new LuaCSFunction(RectTransformWrap.set_anchorMin)),
      new LuaField("anchorMax", new LuaCSFunction(RectTransformWrap.get_anchorMax), new LuaCSFunction(RectTransformWrap.set_anchorMax)),
      new LuaField("anchoredPosition3D", new LuaCSFunction(RectTransformWrap.get_anchoredPosition3D), new LuaCSFunction(RectTransformWrap.set_anchoredPosition3D)),
      new LuaField("anchoredPosition", new LuaCSFunction(RectTransformWrap.get_anchoredPosition), new LuaCSFunction(RectTransformWrap.set_anchoredPosition)),
      new LuaField("sizeDelta", new LuaCSFunction(RectTransformWrap.get_sizeDelta), new LuaCSFunction(RectTransformWrap.set_sizeDelta)),
      new LuaField("pivot", new LuaCSFunction(RectTransformWrap.get_pivot), new LuaCSFunction(RectTransformWrap.set_pivot)),
      new LuaField("offsetMin", new LuaCSFunction(RectTransformWrap.get_offsetMin), new LuaCSFunction(RectTransformWrap.set_offsetMin)),
      new LuaField("offsetMax", new LuaCSFunction(RectTransformWrap.get_offsetMax), new LuaCSFunction(RectTransformWrap.set_offsetMax))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.RectTransform", typeof (RectTransform), regs, fields, typeof (Transform));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateRectTransform(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      RectTransform rectTransform = new RectTransform();
      LuaScriptMgr.Push(L, (Object) rectTransform);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: RectTransform.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, RectTransformWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rect(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rect");
      else
        LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.rect);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anchorMin(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchorMin");
      else
        LuaDLL.luaL_error(L, "attempt to index anchorMin on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.anchorMin);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anchorMax(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchorMax");
      else
        LuaDLL.luaL_error(L, "attempt to index anchorMax on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.anchorMax);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anchoredPosition3D(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchoredPosition3D");
      else
        LuaDLL.luaL_error(L, "attempt to index anchoredPosition3D on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.anchoredPosition3D);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anchoredPosition(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchoredPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index anchoredPosition on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.anchoredPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sizeDelta(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeDelta");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeDelta on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sizeDelta);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pivot(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pivot");
      else
        LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pivot);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_offsetMin(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name offsetMin");
      else
        LuaDLL.luaL_error(L, "attempt to index offsetMin on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.offsetMin);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_offsetMax(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name offsetMax");
      else
        LuaDLL.luaL_error(L, "attempt to index offsetMax on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.offsetMax);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_anchorMin(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchorMin");
      else
        LuaDLL.luaL_error(L, "attempt to index anchorMin on a nil value");
    }
    luaObject.anchorMin = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_anchorMax(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchorMax");
      else
        LuaDLL.luaL_error(L, "attempt to index anchorMax on a nil value");
    }
    luaObject.anchorMax = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_anchoredPosition3D(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchoredPosition3D");
      else
        LuaDLL.luaL_error(L, "attempt to index anchoredPosition3D on a nil value");
    }
    luaObject.anchoredPosition3D = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_anchoredPosition(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchoredPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index anchoredPosition on a nil value");
    }
    luaObject.anchoredPosition = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sizeDelta(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeDelta");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeDelta on a nil value");
    }
    luaObject.sizeDelta = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pivot(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pivot");
      else
        LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
    }
    luaObject.pivot = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_offsetMin(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name offsetMin");
      else
        LuaDLL.luaL_error(L, "attempt to index offsetMin on a nil value");
    }
    luaObject.offsetMin = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_offsetMax(IntPtr L)
  {
    RectTransform luaObject = (RectTransform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name offsetMax");
      else
        LuaDLL.luaL_error(L, "attempt to index offsetMax on a nil value");
    }
    luaObject.offsetMax = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLocalCorners(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((RectTransform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectTransform")).GetLocalCorners(LuaScriptMgr.GetArrayObject<Vector3>(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWorldCorners(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((RectTransform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectTransform")).GetWorldCorners(LuaScriptMgr.GetArrayObject<Vector3>(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetInsetAndSizeFromParentEdge(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((RectTransform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectTransform")).SetInsetAndSizeFromParentEdge((RectTransform.Edge) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (RectTransform.Edge)), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetSizeWithCurrentAnchors(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((RectTransform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RectTransform")).SetSizeWithCurrentAnchors((RectTransform.Axis) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (RectTransform.Axis)), (float) LuaScriptMgr.GetNumber(L, 3));
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
