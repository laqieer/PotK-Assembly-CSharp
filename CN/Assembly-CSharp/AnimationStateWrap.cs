// Decompiled with JetBrains decompiler
// Type: AnimationStateWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AnimationStateWrap
{
  private static System.Type classType = typeof (AnimationState);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("AddMixingTransform", new LuaCSFunction(AnimationStateWrap.AddMixingTransform)),
      new LuaMethod("RemoveMixingTransform", new LuaCSFunction(AnimationStateWrap.RemoveMixingTransform)),
      new LuaMethod("New", new LuaCSFunction(AnimationStateWrap._CreateAnimationState)),
      new LuaMethod("GetClassType", new LuaCSFunction(AnimationStateWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AnimationStateWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[12]
    {
      new LuaField("enabled", new LuaCSFunction(AnimationStateWrap.get_enabled), new LuaCSFunction(AnimationStateWrap.set_enabled)),
      new LuaField("weight", new LuaCSFunction(AnimationStateWrap.get_weight), new LuaCSFunction(AnimationStateWrap.set_weight)),
      new LuaField("wrapMode", new LuaCSFunction(AnimationStateWrap.get_wrapMode), new LuaCSFunction(AnimationStateWrap.set_wrapMode)),
      new LuaField("time", new LuaCSFunction(AnimationStateWrap.get_time), new LuaCSFunction(AnimationStateWrap.set_time)),
      new LuaField("normalizedTime", new LuaCSFunction(AnimationStateWrap.get_normalizedTime), new LuaCSFunction(AnimationStateWrap.set_normalizedTime)),
      new LuaField("speed", new LuaCSFunction(AnimationStateWrap.get_speed), new LuaCSFunction(AnimationStateWrap.set_speed)),
      new LuaField("normalizedSpeed", new LuaCSFunction(AnimationStateWrap.get_normalizedSpeed), new LuaCSFunction(AnimationStateWrap.set_normalizedSpeed)),
      new LuaField("length", new LuaCSFunction(AnimationStateWrap.get_length), (LuaCSFunction) null),
      new LuaField("layer", new LuaCSFunction(AnimationStateWrap.get_layer), new LuaCSFunction(AnimationStateWrap.set_layer)),
      new LuaField("clip", new LuaCSFunction(AnimationStateWrap.get_clip), (LuaCSFunction) null),
      new LuaField("name", new LuaCSFunction(AnimationStateWrap.get_name), new LuaCSFunction(AnimationStateWrap.set_name)),
      new LuaField("blendMode", new LuaCSFunction(AnimationStateWrap.get_blendMode), new LuaCSFunction(AnimationStateWrap.set_blendMode))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationState", typeof (AnimationState), regs, fields, typeof (TrackedReference));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAnimationState(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AnimationState animationState = new AnimationState();
      LuaScriptMgr.Push(L, (TrackedReference) animationState);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AnimationState.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AnimationStateWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enabled(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.enabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_weight(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name weight");
      else
        LuaDLL.luaL_error(L, "attempt to index weight on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.weight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_wrapMode(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
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
  private static int get_time(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name time");
      else
        LuaDLL.luaL_error(L, "attempt to index time on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.time);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_normalizedTime(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name normalizedTime");
      else
        LuaDLL.luaL_error(L, "attempt to index normalizedTime on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.normalizedTime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_speed(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name speed");
      else
        LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.speed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_normalizedSpeed(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name normalizedSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index normalizedSpeed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.normalizedSpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_length(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
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
  private static int get_layer(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layer");
      else
        LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.layer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clip(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clip");
      else
        LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.clip);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_name(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name name");
      else
        LuaDLL.luaL_error(L, "attempt to index name on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.name);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_blendMode(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name blendMode");
      else
        LuaDLL.luaL_error(L, "attempt to index blendMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.blendMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enabled(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    luaObject.enabled = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_weight(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name weight");
      else
        LuaDLL.luaL_error(L, "attempt to index weight on a nil value");
    }
    luaObject.weight = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_wrapMode(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
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
  private static int set_time(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name time");
      else
        LuaDLL.luaL_error(L, "attempt to index time on a nil value");
    }
    luaObject.time = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_normalizedTime(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name normalizedTime");
      else
        LuaDLL.luaL_error(L, "attempt to index normalizedTime on a nil value");
    }
    luaObject.normalizedTime = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_speed(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name speed");
      else
        LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
    }
    luaObject.speed = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_normalizedSpeed(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name normalizedSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index normalizedSpeed on a nil value");
    }
    luaObject.normalizedSpeed = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_layer(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layer");
      else
        LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
    }
    luaObject.layer = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_name(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name name");
      else
        LuaDLL.luaL_error(L, "attempt to index name on a nil value");
    }
    luaObject.name = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_blendMode(IntPtr L)
  {
    AnimationState luaObject = (AnimationState) LuaScriptMgr.GetLuaObject(L, 1);
    if (TrackedReference.op_Equality((TrackedReference) luaObject, (TrackedReference) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name blendMode");
      else
        LuaDLL.luaL_error(L, "attempt to index blendMode on a nil value");
    }
    luaObject.blendMode = (AnimationBlendMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (AnimationBlendMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddMixingTransform(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((AnimationState) LuaScriptMgr.GetTrackedObjectSelf(L, 1, "AnimationState")).AddMixingTransform((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
        return 0;
      case 3:
        ((AnimationState) LuaScriptMgr.GetTrackedObjectSelf(L, 1, "AnimationState")).AddMixingTransform((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AnimationState.AddMixingTransform");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveMixingTransform(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AnimationState) LuaScriptMgr.GetTrackedObjectSelf(L, 1, "AnimationState")).RemoveMixingTransform((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = TrackedReference.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as TrackedReference, LuaScriptMgr.GetLuaObject(L, 2) as TrackedReference);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
