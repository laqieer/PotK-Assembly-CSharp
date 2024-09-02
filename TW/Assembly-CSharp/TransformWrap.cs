// Decompiled with JetBrains decompiler
// Type: TransformWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class TransformWrap
{
  private static System.Type classType = typeof (Transform);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[24]
    {
      new LuaMethod("SetParent", new LuaCSFunction(TransformWrap.SetParent)),
      new LuaMethod("Translate", new LuaCSFunction(TransformWrap.Translate)),
      new LuaMethod("Rotate", new LuaCSFunction(TransformWrap.Rotate)),
      new LuaMethod("RotateAround", new LuaCSFunction(TransformWrap.RotateAround)),
      new LuaMethod("LookAt", new LuaCSFunction(TransformWrap.LookAt)),
      new LuaMethod("TransformDirection", new LuaCSFunction(TransformWrap.TransformDirection)),
      new LuaMethod("InverseTransformDirection", new LuaCSFunction(TransformWrap.InverseTransformDirection)),
      new LuaMethod("TransformVector", new LuaCSFunction(TransformWrap.TransformVector)),
      new LuaMethod("InverseTransformVector", new LuaCSFunction(TransformWrap.InverseTransformVector)),
      new LuaMethod("TransformPoint", new LuaCSFunction(TransformWrap.TransformPoint)),
      new LuaMethod("InverseTransformPoint", new LuaCSFunction(TransformWrap.InverseTransformPoint)),
      new LuaMethod("DetachChildren", new LuaCSFunction(TransformWrap.DetachChildren)),
      new LuaMethod("SetAsFirstSibling", new LuaCSFunction(TransformWrap.SetAsFirstSibling)),
      new LuaMethod("SetAsLastSibling", new LuaCSFunction(TransformWrap.SetAsLastSibling)),
      new LuaMethod("SetSiblingIndex", new LuaCSFunction(TransformWrap.SetSiblingIndex)),
      new LuaMethod("GetSiblingIndex", new LuaCSFunction(TransformWrap.GetSiblingIndex)),
      new LuaMethod("Find", new LuaCSFunction(TransformWrap.Find)),
      new LuaMethod("IsChildOf", new LuaCSFunction(TransformWrap.IsChildOf)),
      new LuaMethod("FindChild", new LuaCSFunction(TransformWrap.FindChild)),
      new LuaMethod("GetEnumerator", new LuaCSFunction(TransformWrap.GetEnumerator)),
      new LuaMethod("GetChild", new LuaCSFunction(TransformWrap.GetChild)),
      new LuaMethod("New", new LuaCSFunction(TransformWrap._CreateTransform)),
      new LuaMethod("GetClassType", new LuaCSFunction(TransformWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TransformWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[17]
    {
      new LuaField("position", new LuaCSFunction(TransformWrap.get_position), new LuaCSFunction(TransformWrap.set_position)),
      new LuaField("localPosition", new LuaCSFunction(TransformWrap.get_localPosition), new LuaCSFunction(TransformWrap.set_localPosition)),
      new LuaField("eulerAngles", new LuaCSFunction(TransformWrap.get_eulerAngles), new LuaCSFunction(TransformWrap.set_eulerAngles)),
      new LuaField("localEulerAngles", new LuaCSFunction(TransformWrap.get_localEulerAngles), new LuaCSFunction(TransformWrap.set_localEulerAngles)),
      new LuaField("right", new LuaCSFunction(TransformWrap.get_right), new LuaCSFunction(TransformWrap.set_right)),
      new LuaField("up", new LuaCSFunction(TransformWrap.get_up), new LuaCSFunction(TransformWrap.set_up)),
      new LuaField("forward", new LuaCSFunction(TransformWrap.get_forward), new LuaCSFunction(TransformWrap.set_forward)),
      new LuaField("rotation", new LuaCSFunction(TransformWrap.get_rotation), new LuaCSFunction(TransformWrap.set_rotation)),
      new LuaField("localRotation", new LuaCSFunction(TransformWrap.get_localRotation), new LuaCSFunction(TransformWrap.set_localRotation)),
      new LuaField("localScale", new LuaCSFunction(TransformWrap.get_localScale), new LuaCSFunction(TransformWrap.set_localScale)),
      new LuaField("parent", new LuaCSFunction(TransformWrap.get_parent), new LuaCSFunction(TransformWrap.set_parent)),
      new LuaField("worldToLocalMatrix", new LuaCSFunction(TransformWrap.get_worldToLocalMatrix), (LuaCSFunction) null),
      new LuaField("localToWorldMatrix", new LuaCSFunction(TransformWrap.get_localToWorldMatrix), (LuaCSFunction) null),
      new LuaField("root", new LuaCSFunction(TransformWrap.get_root), (LuaCSFunction) null),
      new LuaField("childCount", new LuaCSFunction(TransformWrap.get_childCount), (LuaCSFunction) null),
      new LuaField("lossyScale", new LuaCSFunction(TransformWrap.get_lossyScale), (LuaCSFunction) null),
      new LuaField("hasChanged", new LuaCSFunction(TransformWrap.get_hasChanged), new LuaCSFunction(TransformWrap.set_hasChanged))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Transform", typeof (Transform), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTransform(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Transform class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TransformWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_position(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name position");
      else
        LuaDLL.luaL_error(L, "attempt to index position on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.position);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localPosition(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index localPosition on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_eulerAngles(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name eulerAngles");
      else
        LuaDLL.luaL_error(L, "attempt to index eulerAngles on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.eulerAngles);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localEulerAngles(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localEulerAngles");
      else
        LuaDLL.luaL_error(L, "attempt to index localEulerAngles on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localEulerAngles);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_right(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name right");
      else
        LuaDLL.luaL_error(L, "attempt to index right on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.right);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_up(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name up");
      else
        LuaDLL.luaL_error(L, "attempt to index up on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.up);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_forward(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name forward");
      else
        LuaDLL.luaL_error(L, "attempt to index forward on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.forward);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rotation(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rotation");
      else
        LuaDLL.luaL_error(L, "attempt to index rotation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.rotation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localRotation(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index localRotation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localRotation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localScale(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localScale");
      else
        LuaDLL.luaL_error(L, "attempt to index localScale on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_parent(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name parent");
      else
        LuaDLL.luaL_error(L, "attempt to index parent on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.parent);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldToLocalMatrix(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldToLocalMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index worldToLocalMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.worldToLocalMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localToWorldMatrix(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localToWorldMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index localToWorldMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.localToWorldMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_root(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name root");
      else
        LuaDLL.luaL_error(L, "attempt to index root on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.root);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_childCount(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name childCount");
      else
        LuaDLL.luaL_error(L, "attempt to index childCount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.childCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_lossyScale(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name lossyScale");
      else
        LuaDLL.luaL_error(L, "attempt to index lossyScale on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.lossyScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hasChanged(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hasChanged");
      else
        LuaDLL.luaL_error(L, "attempt to index hasChanged on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hasChanged);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_position(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name position");
      else
        LuaDLL.luaL_error(L, "attempt to index position on a nil value");
    }
    luaObject.position = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localPosition(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index localPosition on a nil value");
    }
    luaObject.localPosition = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_eulerAngles(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name eulerAngles");
      else
        LuaDLL.luaL_error(L, "attempt to index eulerAngles on a nil value");
    }
    luaObject.eulerAngles = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localEulerAngles(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localEulerAngles");
      else
        LuaDLL.luaL_error(L, "attempt to index localEulerAngles on a nil value");
    }
    luaObject.localEulerAngles = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_right(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name right");
      else
        LuaDLL.luaL_error(L, "attempt to index right on a nil value");
    }
    luaObject.right = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_up(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name up");
      else
        LuaDLL.luaL_error(L, "attempt to index up on a nil value");
    }
    luaObject.up = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_forward(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name forward");
      else
        LuaDLL.luaL_error(L, "attempt to index forward on a nil value");
    }
    luaObject.forward = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rotation(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rotation");
      else
        LuaDLL.luaL_error(L, "attempt to index rotation on a nil value");
    }
    luaObject.rotation = LuaScriptMgr.GetQuaternion(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localRotation(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index localRotation on a nil value");
    }
    luaObject.localRotation = LuaScriptMgr.GetQuaternion(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localScale(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localScale");
      else
        LuaDLL.luaL_error(L, "attempt to index localScale on a nil value");
    }
    luaObject.localScale = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_parent(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name parent");
      else
        LuaDLL.luaL_error(L, "attempt to index parent on a nil value");
    }
    luaObject.parent = (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hasChanged(IntPtr L)
  {
    Transform luaObject = (Transform) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hasChanged");
      else
        LuaDLL.luaL_error(L, "attempt to index hasChanged on a nil value");
    }
    luaObject.hasChanged = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetParent(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).SetParent((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
        return 0;
      case 3:
        ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).SetParent((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.SetParent");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Translate(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate(LuaScriptMgr.GetVector3(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (Transform)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate(LuaScriptMgr.GetVector3(L, 2), (Transform) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (Space)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate(LuaScriptMgr.GetVector3(L, 2), (Space) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
      return 0;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (float), typeof (float), typeof (float), typeof (Transform)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate((float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (Transform) LuaScriptMgr.GetLuaObject(L, 5));
      return 0;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (float), typeof (float), typeof (float), typeof (Space)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Translate((float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (Space) (int) LuaScriptMgr.GetLuaObject(L, 5));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Transform.Translate");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Rotate(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate(LuaScriptMgr.GetVector3(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (float)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate(LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (Space)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate(LuaScriptMgr.GetVector3(L, 2), (Space) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (float), typeof (Space)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate(LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (Space) (int) LuaScriptMgr.GetLuaObject(L, 4));
      return 0;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (float), typeof (float), typeof (float)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate((float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (float) LuaDLL.lua_tonumber(L, 4));
      return 0;
    }
    if (num == 5)
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Rotate((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (Space) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (Space)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Transform.Rotate");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RotateAround(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).RotateAround(LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LookAt(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).LookAt(LuaScriptMgr.GetVector3(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (Transform)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).LookAt((Transform) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (LuaTable), typeof (LuaTable)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).LookAt(LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Transform), typeof (Transform), typeof (LuaTable)))
    {
      ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).LookAt((Transform) LuaScriptMgr.GetLuaObject(L, 2), LuaScriptMgr.GetVector3(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Transform.LookAt");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int TransformDirection(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformDirection(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformDirection((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.TransformDirection");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int InverseTransformDirection(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformDirection(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformDirection((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.InverseTransformDirection");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int TransformVector(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformVector(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformVector((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.TransformVector");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int InverseTransformVector(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformVector(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformVector((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.InverseTransformVector");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int TransformPoint(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformPoint(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).TransformPoint((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.TransformPoint");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int InverseTransformPoint(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Vector3 v3_1 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformPoint(LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, v3_1);
        return 1;
      case 4:
        Vector3 v3_2 = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).InverseTransformPoint((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, v3_2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Transform.InverseTransformPoint");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DetachChildren(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).DetachChildren();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetAsFirstSibling(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).SetAsFirstSibling();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetAsLastSibling(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).SetAsLastSibling();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetSiblingIndex(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).SetSiblingIndex((int) LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSiblingIndex(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int siblingIndex = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).GetSiblingIndex();
    LuaScriptMgr.Push(L, siblingIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Find(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Transform transform = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).Find(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, (Object) transform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsChildOf(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).IsChildOf((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindChild(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Transform child = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).FindChild(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, (Object) child);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEnumerator(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    IEnumerator enumerator = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).GetEnumerator();
    LuaScriptMgr.Push(L, enumerator);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetChild(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Transform child = ((Transform) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Transform")).GetChild((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, (Object) child);
    return 1;
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
