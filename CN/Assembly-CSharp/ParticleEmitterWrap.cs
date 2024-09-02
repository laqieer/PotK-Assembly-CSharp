// Decompiled with JetBrains decompiler
// Type: ParticleEmitterWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ParticleEmitterWrap
{
  private static System.Type classType = typeof (ParticleEmitter);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("ClearParticles", new LuaCSFunction(ParticleEmitterWrap.ClearParticles)),
      new LuaMethod("Emit", new LuaCSFunction(ParticleEmitterWrap.Emit)),
      new LuaMethod("Simulate", new LuaCSFunction(ParticleEmitterWrap.Simulate)),
      new LuaMethod("New", new LuaCSFunction(ParticleEmitterWrap._CreateParticleEmitter)),
      new LuaMethod("GetClassType", new LuaCSFunction(ParticleEmitterWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(ParticleEmitterWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[18]
    {
      new LuaField("emit", new LuaCSFunction(ParticleEmitterWrap.get_emit), new LuaCSFunction(ParticleEmitterWrap.set_emit)),
      new LuaField("minSize", new LuaCSFunction(ParticleEmitterWrap.get_minSize), new LuaCSFunction(ParticleEmitterWrap.set_minSize)),
      new LuaField("maxSize", new LuaCSFunction(ParticleEmitterWrap.get_maxSize), new LuaCSFunction(ParticleEmitterWrap.set_maxSize)),
      new LuaField("minEnergy", new LuaCSFunction(ParticleEmitterWrap.get_minEnergy), new LuaCSFunction(ParticleEmitterWrap.set_minEnergy)),
      new LuaField("maxEnergy", new LuaCSFunction(ParticleEmitterWrap.get_maxEnergy), new LuaCSFunction(ParticleEmitterWrap.set_maxEnergy)),
      new LuaField("minEmission", new LuaCSFunction(ParticleEmitterWrap.get_minEmission), new LuaCSFunction(ParticleEmitterWrap.set_minEmission)),
      new LuaField("maxEmission", new LuaCSFunction(ParticleEmitterWrap.get_maxEmission), new LuaCSFunction(ParticleEmitterWrap.set_maxEmission)),
      new LuaField("emitterVelocityScale", new LuaCSFunction(ParticleEmitterWrap.get_emitterVelocityScale), new LuaCSFunction(ParticleEmitterWrap.set_emitterVelocityScale)),
      new LuaField("worldVelocity", new LuaCSFunction(ParticleEmitterWrap.get_worldVelocity), new LuaCSFunction(ParticleEmitterWrap.set_worldVelocity)),
      new LuaField("localVelocity", new LuaCSFunction(ParticleEmitterWrap.get_localVelocity), new LuaCSFunction(ParticleEmitterWrap.set_localVelocity)),
      new LuaField("rndVelocity", new LuaCSFunction(ParticleEmitterWrap.get_rndVelocity), new LuaCSFunction(ParticleEmitterWrap.set_rndVelocity)),
      new LuaField("useWorldSpace", new LuaCSFunction(ParticleEmitterWrap.get_useWorldSpace), new LuaCSFunction(ParticleEmitterWrap.set_useWorldSpace)),
      new LuaField("rndRotation", new LuaCSFunction(ParticleEmitterWrap.get_rndRotation), new LuaCSFunction(ParticleEmitterWrap.set_rndRotation)),
      new LuaField("angularVelocity", new LuaCSFunction(ParticleEmitterWrap.get_angularVelocity), new LuaCSFunction(ParticleEmitterWrap.set_angularVelocity)),
      new LuaField("rndAngularVelocity", new LuaCSFunction(ParticleEmitterWrap.get_rndAngularVelocity), new LuaCSFunction(ParticleEmitterWrap.set_rndAngularVelocity)),
      new LuaField("particles", new LuaCSFunction(ParticleEmitterWrap.get_particles), new LuaCSFunction(ParticleEmitterWrap.set_particles)),
      new LuaField("particleCount", new LuaCSFunction(ParticleEmitterWrap.get_particleCount), (LuaCSFunction) null),
      new LuaField("enabled", new LuaCSFunction(ParticleEmitterWrap.get_enabled), new LuaCSFunction(ParticleEmitterWrap.set_enabled))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleEmitter", typeof (ParticleEmitter), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateParticleEmitter(IntPtr L)
  {
    LuaDLL.luaL_error(L, "ParticleEmitter class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ParticleEmitterWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_emit(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name emit");
      else
        LuaDLL.luaL_error(L, "attempt to index emit on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.emit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minSize(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minSize");
      else
        LuaDLL.luaL_error(L, "attempt to index minSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxSize(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxSize");
      else
        LuaDLL.luaL_error(L, "attempt to index maxSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minEnergy(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minEnergy");
      else
        LuaDLL.luaL_error(L, "attempt to index minEnergy on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minEnergy);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxEnergy(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxEnergy");
      else
        LuaDLL.luaL_error(L, "attempt to index maxEnergy on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxEnergy);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minEmission(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minEmission");
      else
        LuaDLL.luaL_error(L, "attempt to index minEmission on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minEmission);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxEmission(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxEmission");
      else
        LuaDLL.luaL_error(L, "attempt to index maxEmission on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxEmission);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_emitterVelocityScale(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name emitterVelocityScale");
      else
        LuaDLL.luaL_error(L, "attempt to index emitterVelocityScale on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.emitterVelocityScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index worldVelocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.worldVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index localVelocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rndVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index rndVelocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.rndVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_useWorldSpace(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useWorldSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index useWorldSpace on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.useWorldSpace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rndRotation(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index rndRotation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.rndRotation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_angularVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name angularVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index angularVelocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.angularVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rndAngularVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndAngularVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index rndAngularVelocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.rndAngularVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_particles(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name particles");
      else
        LuaDLL.luaL_error(L, "attempt to index particles on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.particles);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_particleCount(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name particleCount");
      else
        LuaDLL.luaL_error(L, "attempt to index particleCount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.particleCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enabled(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int set_emit(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name emit");
      else
        LuaDLL.luaL_error(L, "attempt to index emit on a nil value");
    }
    luaObject.emit = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_minSize(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minSize");
      else
        LuaDLL.luaL_error(L, "attempt to index minSize on a nil value");
    }
    luaObject.minSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxSize(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxSize");
      else
        LuaDLL.luaL_error(L, "attempt to index maxSize on a nil value");
    }
    luaObject.maxSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_minEnergy(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minEnergy");
      else
        LuaDLL.luaL_error(L, "attempt to index minEnergy on a nil value");
    }
    luaObject.minEnergy = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxEnergy(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxEnergy");
      else
        LuaDLL.luaL_error(L, "attempt to index maxEnergy on a nil value");
    }
    luaObject.maxEnergy = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_minEmission(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minEmission");
      else
        LuaDLL.luaL_error(L, "attempt to index minEmission on a nil value");
    }
    luaObject.minEmission = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxEmission(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxEmission");
      else
        LuaDLL.luaL_error(L, "attempt to index maxEmission on a nil value");
    }
    luaObject.maxEmission = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_emitterVelocityScale(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name emitterVelocityScale");
      else
        LuaDLL.luaL_error(L, "attempt to index emitterVelocityScale on a nil value");
    }
    luaObject.emitterVelocityScale = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_worldVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index worldVelocity on a nil value");
    }
    luaObject.worldVelocity = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index localVelocity on a nil value");
    }
    luaObject.localVelocity = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rndVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index rndVelocity on a nil value");
    }
    luaObject.rndVelocity = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_useWorldSpace(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useWorldSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index useWorldSpace on a nil value");
    }
    luaObject.useWorldSpace = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rndRotation(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index rndRotation on a nil value");
    }
    luaObject.rndRotation = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_angularVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name angularVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index angularVelocity on a nil value");
    }
    luaObject.angularVelocity = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rndAngularVelocity(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rndAngularVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index rndAngularVelocity on a nil value");
    }
    luaObject.rndAngularVelocity = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_particles(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name particles");
      else
        LuaDLL.luaL_error(L, "attempt to index particles on a nil value");
    }
    luaObject.particles = LuaScriptMgr.GetArrayObject<Particle>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enabled(IntPtr L)
  {
    ParticleEmitter luaObject = (ParticleEmitter) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int ClearParticles(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).ClearParticles();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Emit(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).Emit();
        return 0;
      case 2:
        ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).Emit((int) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      case 6:
        ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).Emit(LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), LuaScriptMgr.GetColor(L, 6));
        return 0;
      case 8:
        ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).Emit(LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), LuaScriptMgr.GetColor(L, 6), (float) LuaScriptMgr.GetNumber(L, 7), (float) LuaScriptMgr.GetNumber(L, 8));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleEmitter.Emit");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Simulate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((ParticleEmitter) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleEmitter")).Simulate((float) LuaScriptMgr.GetNumber(L, 2));
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
