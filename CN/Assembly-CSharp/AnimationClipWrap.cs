// Decompiled with JetBrains decompiler
// Type: AnimationClipWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AnimationClipWrap
{
  private static System.Type classType = typeof (AnimationClip);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[8]
    {
      new LuaMethod("SampleAnimation", new LuaCSFunction(AnimationClipWrap.SampleAnimation)),
      new LuaMethod("SetCurve", new LuaCSFunction(AnimationClipWrap.SetCurve)),
      new LuaMethod("EnsureQuaternionContinuity", new LuaCSFunction(AnimationClipWrap.EnsureQuaternionContinuity)),
      new LuaMethod("ClearCurves", new LuaCSFunction(AnimationClipWrap.ClearCurves)),
      new LuaMethod("AddEvent", new LuaCSFunction(AnimationClipWrap.AddEvent)),
      new LuaMethod("New", new LuaCSFunction(AnimationClipWrap._CreateAnimationClip)),
      new LuaMethod("GetClassType", new LuaCSFunction(AnimationClipWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AnimationClipWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[7]
    {
      new LuaField("length", new LuaCSFunction(AnimationClipWrap.get_length), (LuaCSFunction) null),
      new LuaField("frameRate", new LuaCSFunction(AnimationClipWrap.get_frameRate), new LuaCSFunction(AnimationClipWrap.set_frameRate)),
      new LuaField("wrapMode", new LuaCSFunction(AnimationClipWrap.get_wrapMode), new LuaCSFunction(AnimationClipWrap.set_wrapMode)),
      new LuaField("localBounds", new LuaCSFunction(AnimationClipWrap.get_localBounds), new LuaCSFunction(AnimationClipWrap.set_localBounds)),
      new LuaField("legacy", new LuaCSFunction(AnimationClipWrap.get_legacy), new LuaCSFunction(AnimationClipWrap.set_legacy)),
      new LuaField("humanMotion", new LuaCSFunction(AnimationClipWrap.get_humanMotion), (LuaCSFunction) null),
      new LuaField("events", new LuaCSFunction(AnimationClipWrap.get_events), new LuaCSFunction(AnimationClipWrap.set_events))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationClip", typeof (AnimationClip), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAnimationClip(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AnimationClip animationClip = new AnimationClip();
      LuaScriptMgr.Push(L, (Object) animationClip);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AnimationClip.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AnimationClipWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_length(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name length");
      else
        LuaDLL.luaL_error(L, "attempt to index length on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.length);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_frameRate(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name frameRate");
      else
        LuaDLL.luaL_error(L, "attempt to index frameRate on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.frameRate);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_wrapMode(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name wrapMode");
      else
        LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.wrapMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localBounds(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localBounds");
      else
        LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localBounds);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_legacy(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name legacy");
      else
        LuaDLL.luaL_error(L, "attempt to index legacy on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.legacy);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_humanMotion(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name humanMotion");
      else
        LuaDLL.luaL_error(L, "attempt to index humanMotion on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.humanMotion);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_events(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name events");
      else
        LuaDLL.luaL_error(L, "attempt to index events on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.events);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_frameRate(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name frameRate");
      else
        LuaDLL.luaL_error(L, "attempt to index frameRate on a nil value");
    }
    luaObject.frameRate = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_wrapMode(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name wrapMode");
      else
        LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
    }
    luaObject.wrapMode = (WrapMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (WrapMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localBounds(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localBounds");
      else
        LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
    }
    luaObject.localBounds = LuaScriptMgr.GetBounds(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_legacy(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name legacy");
      else
        LuaDLL.luaL_error(L, "attempt to index legacy on a nil value");
    }
    luaObject.legacy = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_events(IntPtr L)
  {
    AnimationClip luaObject = (AnimationClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name events");
      else
        LuaDLL.luaL_error(L, "attempt to index events on a nil value");
    }
    luaObject.events = LuaScriptMgr.GetArrayObject<AnimationEvent>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SampleAnimation(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((AnimationClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AnimationClip")).SampleAnimation((GameObject) LuaScriptMgr.GetUnityObject(L, 2, typeof (GameObject)), (float) LuaScriptMgr.GetNumber(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetCurve(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 5);
    ((AnimationClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AnimationClip")).SetCurve(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3), LuaScriptMgr.GetLuaString(L, 4), (AnimationCurve) LuaScriptMgr.GetNetObject(L, 5, typeof (AnimationCurve)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int EnsureQuaternionContinuity(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((AnimationClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AnimationClip")).EnsureQuaternionContinuity();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ClearCurves(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((AnimationClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AnimationClip")).ClearCurves();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddEvent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AnimationClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AnimationClip")).AddEvent((AnimationEvent) LuaScriptMgr.GetNetObject(L, 2, typeof (AnimationEvent)));
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
