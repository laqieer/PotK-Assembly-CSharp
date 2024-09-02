// Decompiled with JetBrains decompiler
// Type: ParticleAnimatorWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ParticleAnimatorWrap
{
  private static System.Type classType = typeof (ParticleAnimator);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(ParticleAnimatorWrap._CreateParticleAnimator)),
      new LuaMethod("GetClassType", new LuaCSFunction(ParticleAnimatorWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(ParticleAnimatorWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[9]
    {
      new LuaField("doesAnimateColor", new LuaCSFunction(ParticleAnimatorWrap.get_doesAnimateColor), new LuaCSFunction(ParticleAnimatorWrap.set_doesAnimateColor)),
      new LuaField("worldRotationAxis", new LuaCSFunction(ParticleAnimatorWrap.get_worldRotationAxis), new LuaCSFunction(ParticleAnimatorWrap.set_worldRotationAxis)),
      new LuaField("localRotationAxis", new LuaCSFunction(ParticleAnimatorWrap.get_localRotationAxis), new LuaCSFunction(ParticleAnimatorWrap.set_localRotationAxis)),
      new LuaField("sizeGrow", new LuaCSFunction(ParticleAnimatorWrap.get_sizeGrow), new LuaCSFunction(ParticleAnimatorWrap.set_sizeGrow)),
      new LuaField("rndForce", new LuaCSFunction(ParticleAnimatorWrap.get_rndForce), new LuaCSFunction(ParticleAnimatorWrap.set_rndForce)),
      new LuaField("force", new LuaCSFunction(ParticleAnimatorWrap.get_force), new LuaCSFunction(ParticleAnimatorWrap.set_force)),
      new LuaField("damping", new LuaCSFunction(ParticleAnimatorWrap.get_damping), new LuaCSFunction(ParticleAnimatorWrap.set_damping)),
      new LuaField("autodestruct", new LuaCSFunction(ParticleAnimatorWrap.get_autodestruct), new LuaCSFunction(ParticleAnimatorWrap.set_autodestruct)),
      new LuaField("colorAnimation", new LuaCSFunction(ParticleAnimatorWrap.get_colorAnimation), new LuaCSFunction(ParticleAnimatorWrap.set_colorAnimation))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleAnimator", typeof (ParticleAnimator), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateParticleAnimator(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      ParticleAnimator particleAnimator = new ParticleAnimator();
      LuaScriptMgr.Push(L, (Object) particleAnimator);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: ParticleAnimator.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ParticleAnimatorWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_doesAnimateColor(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name doesAnimateColor");
      else
        LuaDLL.luaL_error(L, "attempt to index doesAnimateColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.doesAnimateColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldRotationAxis(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldRotationAxis");
      else
        LuaDLL.luaL_error(L, "attempt to index worldRotationAxis on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.worldRotationAxis);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localRotationAxis(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localRotationAxis");
      else
        LuaDLL.luaL_error(L, "attempt to index localRotationAxis on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localRotationAxis);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sizeGrow(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeGrow");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeGrow on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sizeGrow);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rndForce(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndForce");
      else
        LuaDLL.luaL_error(L, "attempt to index rndForce on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.rndForce);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_force(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name force");
      else
        LuaDLL.luaL_error(L, "attempt to index force on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.force);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_damping(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name damping");
      else
        LuaDLL.luaL_error(L, "attempt to index damping on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.damping);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autodestruct(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name autodestruct");
      else
        LuaDLL.luaL_error(L, "attempt to index autodestruct on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.autodestruct);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_colorAnimation(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name colorAnimation");
      else
        LuaDLL.luaL_error(L, "attempt to index colorAnimation on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.colorAnimation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_doesAnimateColor(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name doesAnimateColor");
      else
        LuaDLL.luaL_error(L, "attempt to index doesAnimateColor on a nil value");
    }
    luaObject.doesAnimateColor = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_worldRotationAxis(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldRotationAxis");
      else
        LuaDLL.luaL_error(L, "attempt to index worldRotationAxis on a nil value");
    }
    luaObject.worldRotationAxis = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localRotationAxis(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localRotationAxis");
      else
        LuaDLL.luaL_error(L, "attempt to index localRotationAxis on a nil value");
    }
    luaObject.localRotationAxis = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sizeGrow(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeGrow");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeGrow on a nil value");
    }
    luaObject.sizeGrow = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rndForce(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndForce");
      else
        LuaDLL.luaL_error(L, "attempt to index rndForce on a nil value");
    }
    luaObject.rndForce = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_force(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name force");
      else
        LuaDLL.luaL_error(L, "attempt to index force on a nil value");
    }
    luaObject.force = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_damping(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name damping");
      else
        LuaDLL.luaL_error(L, "attempt to index damping on a nil value");
    }
    luaObject.damping = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autodestruct(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name autodestruct");
      else
        LuaDLL.luaL_error(L, "attempt to index autodestruct on a nil value");
    }
    luaObject.autodestruct = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_colorAnimation(IntPtr L)
  {
    ParticleAnimator luaObject = (ParticleAnimator) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name colorAnimation");
      else
        LuaDLL.luaL_error(L, "attempt to index colorAnimation on a nil value");
    }
    luaObject.colorAnimation = LuaScriptMgr.GetArrayObject<Color>(L, 3);
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
