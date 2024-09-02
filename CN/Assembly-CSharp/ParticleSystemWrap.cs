// Decompiled with JetBrains decompiler
// Type: ParticleSystemWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ParticleSystemWrap
{
  private static System.Type classType = typeof (ParticleSystem);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[12]
    {
      new LuaMethod("SetParticles", new LuaCSFunction(ParticleSystemWrap.SetParticles)),
      new LuaMethod("GetParticles", new LuaCSFunction(ParticleSystemWrap.GetParticles)),
      new LuaMethod("Simulate", new LuaCSFunction(ParticleSystemWrap.Simulate)),
      new LuaMethod("Play", new LuaCSFunction(ParticleSystemWrap.Play)),
      new LuaMethod("Stop", new LuaCSFunction(ParticleSystemWrap.Stop)),
      new LuaMethod("Pause", new LuaCSFunction(ParticleSystemWrap.Pause)),
      new LuaMethod("Clear", new LuaCSFunction(ParticleSystemWrap.Clear)),
      new LuaMethod("IsAlive", new LuaCSFunction(ParticleSystemWrap.IsAlive)),
      new LuaMethod("Emit", new LuaCSFunction(ParticleSystemWrap.Emit)),
      new LuaMethod("New", new LuaCSFunction(ParticleSystemWrap._CreateParticleSystem)),
      new LuaMethod("GetClassType", new LuaCSFunction(ParticleSystemWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(ParticleSystemWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[37]
    {
      new LuaField("startDelay", new LuaCSFunction(ParticleSystemWrap.get_startDelay), new LuaCSFunction(ParticleSystemWrap.set_startDelay)),
      new LuaField("isPlaying", new LuaCSFunction(ParticleSystemWrap.get_isPlaying), (LuaCSFunction) null),
      new LuaField("isStopped", new LuaCSFunction(ParticleSystemWrap.get_isStopped), (LuaCSFunction) null),
      new LuaField("isPaused", new LuaCSFunction(ParticleSystemWrap.get_isPaused), (LuaCSFunction) null),
      new LuaField("loop", new LuaCSFunction(ParticleSystemWrap.get_loop), new LuaCSFunction(ParticleSystemWrap.set_loop)),
      new LuaField("playOnAwake", new LuaCSFunction(ParticleSystemWrap.get_playOnAwake), new LuaCSFunction(ParticleSystemWrap.set_playOnAwake)),
      new LuaField("time", new LuaCSFunction(ParticleSystemWrap.get_time), new LuaCSFunction(ParticleSystemWrap.set_time)),
      new LuaField("duration", new LuaCSFunction(ParticleSystemWrap.get_duration), (LuaCSFunction) null),
      new LuaField("playbackSpeed", new LuaCSFunction(ParticleSystemWrap.get_playbackSpeed), new LuaCSFunction(ParticleSystemWrap.set_playbackSpeed)),
      new LuaField("particleCount", new LuaCSFunction(ParticleSystemWrap.get_particleCount), (LuaCSFunction) null),
      new LuaField("startSpeed", new LuaCSFunction(ParticleSystemWrap.get_startSpeed), new LuaCSFunction(ParticleSystemWrap.set_startSpeed)),
      new LuaField("startSize", new LuaCSFunction(ParticleSystemWrap.get_startSize), new LuaCSFunction(ParticleSystemWrap.set_startSize)),
      new LuaField("startColor", new LuaCSFunction(ParticleSystemWrap.get_startColor), new LuaCSFunction(ParticleSystemWrap.set_startColor)),
      new LuaField("startRotation", new LuaCSFunction(ParticleSystemWrap.get_startRotation), new LuaCSFunction(ParticleSystemWrap.set_startRotation)),
      new LuaField("startRotation3D", new LuaCSFunction(ParticleSystemWrap.get_startRotation3D), new LuaCSFunction(ParticleSystemWrap.set_startRotation3D)),
      new LuaField("startLifetime", new LuaCSFunction(ParticleSystemWrap.get_startLifetime), new LuaCSFunction(ParticleSystemWrap.set_startLifetime)),
      new LuaField("gravityModifier", new LuaCSFunction(ParticleSystemWrap.get_gravityModifier), new LuaCSFunction(ParticleSystemWrap.set_gravityModifier)),
      new LuaField("maxParticles", new LuaCSFunction(ParticleSystemWrap.get_maxParticles), new LuaCSFunction(ParticleSystemWrap.set_maxParticles)),
      new LuaField("simulationSpace", new LuaCSFunction(ParticleSystemWrap.get_simulationSpace), new LuaCSFunction(ParticleSystemWrap.set_simulationSpace)),
      new LuaField("scalingMode", new LuaCSFunction(ParticleSystemWrap.get_scalingMode), new LuaCSFunction(ParticleSystemWrap.set_scalingMode)),
      new LuaField("randomSeed", new LuaCSFunction(ParticleSystemWrap.get_randomSeed), new LuaCSFunction(ParticleSystemWrap.set_randomSeed)),
      new LuaField("emission", new LuaCSFunction(ParticleSystemWrap.get_emission), (LuaCSFunction) null),
      new LuaField("shape", new LuaCSFunction(ParticleSystemWrap.get_shape), (LuaCSFunction) null),
      new LuaField("velocityOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_velocityOverLifetime), (LuaCSFunction) null),
      new LuaField("limitVelocityOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_limitVelocityOverLifetime), (LuaCSFunction) null),
      new LuaField("inheritVelocity", new LuaCSFunction(ParticleSystemWrap.get_inheritVelocity), (LuaCSFunction) null),
      new LuaField("forceOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_forceOverLifetime), (LuaCSFunction) null),
      new LuaField("colorOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_colorOverLifetime), (LuaCSFunction) null),
      new LuaField("colorBySpeed", new LuaCSFunction(ParticleSystemWrap.get_colorBySpeed), (LuaCSFunction) null),
      new LuaField("sizeOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_sizeOverLifetime), (LuaCSFunction) null),
      new LuaField("sizeBySpeed", new LuaCSFunction(ParticleSystemWrap.get_sizeBySpeed), (LuaCSFunction) null),
      new LuaField("rotationOverLifetime", new LuaCSFunction(ParticleSystemWrap.get_rotationOverLifetime), (LuaCSFunction) null),
      new LuaField("rotationBySpeed", new LuaCSFunction(ParticleSystemWrap.get_rotationBySpeed), (LuaCSFunction) null),
      new LuaField("externalForces", new LuaCSFunction(ParticleSystemWrap.get_externalForces), (LuaCSFunction) null),
      new LuaField("collision", new LuaCSFunction(ParticleSystemWrap.get_collision), (LuaCSFunction) null),
      new LuaField("subEmitters", new LuaCSFunction(ParticleSystemWrap.get_subEmitters), (LuaCSFunction) null),
      new LuaField("textureSheetAnimation", new LuaCSFunction(ParticleSystemWrap.get_textureSheetAnimation), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.ParticleSystem", typeof (ParticleSystem), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateParticleSystem(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      ParticleSystem particleSystem = new ParticleSystem();
      LuaScriptMgr.Push(L, (Object) particleSystem);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ParticleSystemWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startDelay(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startDelay");
      else
        LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startDelay);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPlaying(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPlaying");
      else
        LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isPlaying);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isStopped(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isStopped");
      else
        LuaDLL.luaL_error(L, "attempt to index isStopped on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isStopped);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPaused(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPaused");
      else
        LuaDLL.luaL_error(L, "attempt to index isPaused on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isPaused);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_loop(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name loop");
      else
        LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.loop);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_playOnAwake(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playOnAwake");
      else
        LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.playOnAwake);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_time(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int get_duration(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name duration");
      else
        LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.duration);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_playbackSpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.playbackSpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_particleCount(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_startSpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startSpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startSize(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startSize");
      else
        LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startColor(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startColor");
      else
        LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startRotation(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startRotation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startRotation3D(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startRotation3D");
      else
        LuaDLL.luaL_error(L, "attempt to index startRotation3D on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startRotation3D);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gravityModifier(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gravityModifier");
      else
        LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.gravityModifier);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxParticles(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxParticles");
      else
        LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxParticles);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_simulationSpace(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name simulationSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.simulationSpace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_scalingMode(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name scalingMode");
      else
        LuaDLL.luaL_error(L, "attempt to index scalingMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.scalingMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_randomSeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name randomSeed");
      else
        LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.randomSeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_emission(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name emission");
      else
        LuaDLL.luaL_error(L, "attempt to index emission on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.emission);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shape(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shape");
      else
        LuaDLL.luaL_error(L, "attempt to index shape on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.shape);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_velocityOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name velocityOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index velocityOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.velocityOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_limitVelocityOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name limitVelocityOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index limitVelocityOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.limitVelocityOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_inheritVelocity(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name inheritVelocity");
      else
        LuaDLL.luaL_error(L, "attempt to index inheritVelocity on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.inheritVelocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_forceOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name forceOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index forceOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.forceOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_colorOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name colorOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index colorOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.colorOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_colorBySpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name colorBySpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index colorBySpeed on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.colorBySpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sizeOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.sizeOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sizeBySpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sizeBySpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index sizeBySpeed on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.sizeBySpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rotationOverLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rotationOverLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index rotationOverLifetime on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.rotationOverLifetime);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rotationBySpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rotationBySpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index rotationBySpeed on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.rotationBySpeed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_externalForces(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name externalForces");
      else
        LuaDLL.luaL_error(L, "attempt to index externalForces on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.externalForces);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_collision(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name collision");
      else
        LuaDLL.luaL_error(L, "attempt to index collision on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.collision);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_subEmitters(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name subEmitters");
      else
        LuaDLL.luaL_error(L, "attempt to index subEmitters on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.subEmitters);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_textureSheetAnimation(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name textureSheetAnimation");
      else
        LuaDLL.luaL_error(L, "attempt to index textureSheetAnimation on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.textureSheetAnimation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startDelay(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startDelay");
      else
        LuaDLL.luaL_error(L, "attempt to index startDelay on a nil value");
    }
    luaObject.startDelay = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_loop(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name loop");
      else
        LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
    }
    luaObject.loop = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_playOnAwake(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playOnAwake");
      else
        LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
    }
    luaObject.playOnAwake = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_time(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int set_playbackSpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playbackSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index playbackSpeed on a nil value");
    }
    luaObject.playbackSpeed = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startSpeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startSpeed");
      else
        LuaDLL.luaL_error(L, "attempt to index startSpeed on a nil value");
    }
    luaObject.startSpeed = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startSize(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startSize");
      else
        LuaDLL.luaL_error(L, "attempt to index startSize on a nil value");
    }
    luaObject.startSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startColor(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startColor");
      else
        LuaDLL.luaL_error(L, "attempt to index startColor on a nil value");
    }
    luaObject.startColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startRotation(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startRotation");
      else
        LuaDLL.luaL_error(L, "attempt to index startRotation on a nil value");
    }
    luaObject.startRotation = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startRotation3D(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startRotation3D");
      else
        LuaDLL.luaL_error(L, "attempt to index startRotation3D on a nil value");
    }
    luaObject.startRotation3D = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startLifetime(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startLifetime");
      else
        LuaDLL.luaL_error(L, "attempt to index startLifetime on a nil value");
    }
    luaObject.startLifetime = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_gravityModifier(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gravityModifier");
      else
        LuaDLL.luaL_error(L, "attempt to index gravityModifier on a nil value");
    }
    luaObject.gravityModifier = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxParticles(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxParticles");
      else
        LuaDLL.luaL_error(L, "attempt to index maxParticles on a nil value");
    }
    luaObject.maxParticles = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_simulationSpace(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name simulationSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index simulationSpace on a nil value");
    }
    luaObject.simulationSpace = (ParticleSystemSimulationSpace) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ParticleSystemSimulationSpace));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_scalingMode(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name scalingMode");
      else
        LuaDLL.luaL_error(L, "attempt to index scalingMode on a nil value");
    }
    luaObject.scalingMode = (ParticleSystemScalingMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ParticleSystemScalingMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_randomSeed(IntPtr L)
  {
    ParticleSystem luaObject = (ParticleSystem) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name randomSeed");
      else
        LuaDLL.luaL_error(L, "attempt to index randomSeed on a nil value");
    }
    luaObject.randomSeed = (uint) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetParticles(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).SetParticles(LuaScriptMgr.GetArrayObject<ParticleSystem.Particle>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetParticles(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int particles = ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).GetParticles(LuaScriptMgr.GetArrayObject<ParticleSystem.Particle>(L, 2));
    LuaScriptMgr.Push(L, particles);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Simulate(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Simulate((float) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      case 3:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Simulate((float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      case 4:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Simulate((float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetBoolean(L, 3), LuaScriptMgr.GetBoolean(L, 4));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Simulate");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Play(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Play();
        return 0;
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Play(LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Play");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Stop(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Stop();
        return 0;
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Stop(LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Stop");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Pause(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Pause();
        return 0;
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Pause(LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Pause");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Clear(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Clear();
        return 0;
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Clear(LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Clear");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsAlive(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        bool b1 = ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).IsAlive();
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 2:
        bool b2 = ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).IsAlive(LuaScriptMgr.GetBoolean(L, 2));
        LuaScriptMgr.Push(L, b2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.IsAlive");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Emit(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Emit((int) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      case 3:
        ((ParticleSystem) LuaScriptMgr.GetUnityObjectSelf(L, 1, "ParticleSystem")).Emit((ParticleSystem.EmitParams) LuaScriptMgr.GetNetObject(L, 2, typeof (ParticleSystem.EmitParams)), (int) LuaScriptMgr.GetNumber(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: ParticleSystem.Emit");
        return 0;
    }
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
