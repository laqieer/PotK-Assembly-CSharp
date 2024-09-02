// Decompiled with JetBrains decompiler
// Type: AudioSourceWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Audio;

#nullable disable
public class AudioSourceWrap
{
  private static System.Type classType = typeof (AudioSource);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[19]
    {
      new LuaMethod("Play", new LuaCSFunction(AudioSourceWrap.Play)),
      new LuaMethod("PlayDelayed", new LuaCSFunction(AudioSourceWrap.PlayDelayed)),
      new LuaMethod("PlayScheduled", new LuaCSFunction(AudioSourceWrap.PlayScheduled)),
      new LuaMethod("SetScheduledStartTime", new LuaCSFunction(AudioSourceWrap.SetScheduledStartTime)),
      new LuaMethod("SetScheduledEndTime", new LuaCSFunction(AudioSourceWrap.SetScheduledEndTime)),
      new LuaMethod("Stop", new LuaCSFunction(AudioSourceWrap.Stop)),
      new LuaMethod("Pause", new LuaCSFunction(AudioSourceWrap.Pause)),
      new LuaMethod("UnPause", new LuaCSFunction(AudioSourceWrap.UnPause)),
      new LuaMethod("PlayOneShot", new LuaCSFunction(AudioSourceWrap.PlayOneShot)),
      new LuaMethod("PlayClipAtPoint", new LuaCSFunction(AudioSourceWrap.PlayClipAtPoint)),
      new LuaMethod("SetCustomCurve", new LuaCSFunction(AudioSourceWrap.SetCustomCurve)),
      new LuaMethod("GetCustomCurve", new LuaCSFunction(AudioSourceWrap.GetCustomCurve)),
      new LuaMethod("GetOutputData", new LuaCSFunction(AudioSourceWrap.GetOutputData)),
      new LuaMethod("GetSpectrumData", new LuaCSFunction(AudioSourceWrap.GetSpectrumData)),
      new LuaMethod("SetSpatializerFloat", new LuaCSFunction(AudioSourceWrap.SetSpatializerFloat)),
      new LuaMethod("GetSpatializerFloat", new LuaCSFunction(AudioSourceWrap.GetSpatializerFloat)),
      new LuaMethod("New", new LuaCSFunction(AudioSourceWrap._CreateAudioSource)),
      new LuaMethod("GetClassType", new LuaCSFunction(AudioSourceWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AudioSourceWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[26]
    {
      new LuaField("volume", new LuaCSFunction(AudioSourceWrap.get_volume), new LuaCSFunction(AudioSourceWrap.set_volume)),
      new LuaField("pitch", new LuaCSFunction(AudioSourceWrap.get_pitch), new LuaCSFunction(AudioSourceWrap.set_pitch)),
      new LuaField("time", new LuaCSFunction(AudioSourceWrap.get_time), new LuaCSFunction(AudioSourceWrap.set_time)),
      new LuaField("timeSamples", new LuaCSFunction(AudioSourceWrap.get_timeSamples), new LuaCSFunction(AudioSourceWrap.set_timeSamples)),
      new LuaField("clip", new LuaCSFunction(AudioSourceWrap.get_clip), new LuaCSFunction(AudioSourceWrap.set_clip)),
      new LuaField("outputAudioMixerGroup", new LuaCSFunction(AudioSourceWrap.get_outputAudioMixerGroup), new LuaCSFunction(AudioSourceWrap.set_outputAudioMixerGroup)),
      new LuaField("isPlaying", new LuaCSFunction(AudioSourceWrap.get_isPlaying), (LuaCSFunction) null),
      new LuaField("loop", new LuaCSFunction(AudioSourceWrap.get_loop), new LuaCSFunction(AudioSourceWrap.set_loop)),
      new LuaField("ignoreListenerVolume", new LuaCSFunction(AudioSourceWrap.get_ignoreListenerVolume), new LuaCSFunction(AudioSourceWrap.set_ignoreListenerVolume)),
      new LuaField("playOnAwake", new LuaCSFunction(AudioSourceWrap.get_playOnAwake), new LuaCSFunction(AudioSourceWrap.set_playOnAwake)),
      new LuaField("ignoreListenerPause", new LuaCSFunction(AudioSourceWrap.get_ignoreListenerPause), new LuaCSFunction(AudioSourceWrap.set_ignoreListenerPause)),
      new LuaField("velocityUpdateMode", new LuaCSFunction(AudioSourceWrap.get_velocityUpdateMode), new LuaCSFunction(AudioSourceWrap.set_velocityUpdateMode)),
      new LuaField("panStereo", new LuaCSFunction(AudioSourceWrap.get_panStereo), new LuaCSFunction(AudioSourceWrap.set_panStereo)),
      new LuaField("spatialBlend", new LuaCSFunction(AudioSourceWrap.get_spatialBlend), new LuaCSFunction(AudioSourceWrap.set_spatialBlend)),
      new LuaField("spatialize", new LuaCSFunction(AudioSourceWrap.get_spatialize), new LuaCSFunction(AudioSourceWrap.set_spatialize)),
      new LuaField("reverbZoneMix", new LuaCSFunction(AudioSourceWrap.get_reverbZoneMix), new LuaCSFunction(AudioSourceWrap.set_reverbZoneMix)),
      new LuaField("bypassEffects", new LuaCSFunction(AudioSourceWrap.get_bypassEffects), new LuaCSFunction(AudioSourceWrap.set_bypassEffects)),
      new LuaField("bypassListenerEffects", new LuaCSFunction(AudioSourceWrap.get_bypassListenerEffects), new LuaCSFunction(AudioSourceWrap.set_bypassListenerEffects)),
      new LuaField("bypassReverbZones", new LuaCSFunction(AudioSourceWrap.get_bypassReverbZones), new LuaCSFunction(AudioSourceWrap.set_bypassReverbZones)),
      new LuaField("dopplerLevel", new LuaCSFunction(AudioSourceWrap.get_dopplerLevel), new LuaCSFunction(AudioSourceWrap.set_dopplerLevel)),
      new LuaField("spread", new LuaCSFunction(AudioSourceWrap.get_spread), new LuaCSFunction(AudioSourceWrap.set_spread)),
      new LuaField("priority", new LuaCSFunction(AudioSourceWrap.get_priority), new LuaCSFunction(AudioSourceWrap.set_priority)),
      new LuaField("mute", new LuaCSFunction(AudioSourceWrap.get_mute), new LuaCSFunction(AudioSourceWrap.set_mute)),
      new LuaField("minDistance", new LuaCSFunction(AudioSourceWrap.get_minDistance), new LuaCSFunction(AudioSourceWrap.set_minDistance)),
      new LuaField("maxDistance", new LuaCSFunction(AudioSourceWrap.get_maxDistance), new LuaCSFunction(AudioSourceWrap.set_maxDistance)),
      new LuaField("rolloffMode", new LuaCSFunction(AudioSourceWrap.get_rolloffMode), new LuaCSFunction(AudioSourceWrap.set_rolloffMode))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioSource", typeof (AudioSource), regs, fields, typeof (Behaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAudioSource(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AudioSource audioSource = new AudioSource();
      LuaScriptMgr.Push(L, (Object) audioSource);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AudioSourceWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_volume(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name volume");
      else
        LuaDLL.luaL_error(L, "attempt to index volume on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.volume);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pitch(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pitch");
      else
        LuaDLL.luaL_error(L, "attempt to index pitch on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pitch);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_time(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_timeSamples(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name timeSamples");
      else
        LuaDLL.luaL_error(L, "attempt to index timeSamples on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.timeSamples);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clip(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int get_outputAudioMixerGroup(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name outputAudioMixerGroup");
      else
        LuaDLL.luaL_error(L, "attempt to index outputAudioMixerGroup on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.outputAudioMixerGroup);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPlaying(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_loop(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_ignoreListenerVolume(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ignoreListenerVolume");
      else
        LuaDLL.luaL_error(L, "attempt to index ignoreListenerVolume on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.ignoreListenerVolume);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_playOnAwake(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_ignoreListenerPause(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ignoreListenerPause");
      else
        LuaDLL.luaL_error(L, "attempt to index ignoreListenerPause on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.ignoreListenerPause);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_velocityUpdateMode(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name velocityUpdateMode");
      else
        LuaDLL.luaL_error(L, "attempt to index velocityUpdateMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.velocityUpdateMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_panStereo(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name panStereo");
      else
        LuaDLL.luaL_error(L, "attempt to index panStereo on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.panStereo);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spatialBlend(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spatialBlend");
      else
        LuaDLL.luaL_error(L, "attempt to index spatialBlend on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spatialBlend);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spatialize(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spatialize");
      else
        LuaDLL.luaL_error(L, "attempt to index spatialize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spatialize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_reverbZoneMix(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name reverbZoneMix");
      else
        LuaDLL.luaL_error(L, "attempt to index reverbZoneMix on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.reverbZoneMix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bypassEffects(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassEffects");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassEffects on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bypassEffects);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bypassListenerEffects(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassListenerEffects");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassListenerEffects on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bypassListenerEffects);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bypassReverbZones(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassReverbZones");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassReverbZones on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bypassReverbZones);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_dopplerLevel(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name dopplerLevel");
      else
        LuaDLL.luaL_error(L, "attempt to index dopplerLevel on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.dopplerLevel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spread(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spread");
      else
        LuaDLL.luaL_error(L, "attempt to index spread on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spread);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_priority(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int get_mute(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mute");
      else
        LuaDLL.luaL_error(L, "attempt to index mute on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.mute);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minDistance(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index minDistance on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minDistance);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxDistance(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index maxDistance on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxDistance);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rolloffMode(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rolloffMode");
      else
        LuaDLL.luaL_error(L, "attempt to index rolloffMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.rolloffMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_volume(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name volume");
      else
        LuaDLL.luaL_error(L, "attempt to index volume on a nil value");
    }
    luaObject.volume = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pitch(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pitch");
      else
        LuaDLL.luaL_error(L, "attempt to index pitch on a nil value");
    }
    luaObject.pitch = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_time(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_timeSamples(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name timeSamples");
      else
        LuaDLL.luaL_error(L, "attempt to index timeSamples on a nil value");
    }
    luaObject.timeSamples = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_clip(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clip");
      else
        LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
    }
    luaObject.clip = (AudioClip) LuaScriptMgr.GetUnityObject(L, 3, typeof (AudioClip));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_outputAudioMixerGroup(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name outputAudioMixerGroup");
      else
        LuaDLL.luaL_error(L, "attempt to index outputAudioMixerGroup on a nil value");
    }
    luaObject.outputAudioMixerGroup = (AudioMixerGroup) LuaScriptMgr.GetUnityObject(L, 3, typeof (AudioMixerGroup));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_loop(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_ignoreListenerVolume(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ignoreListenerVolume");
      else
        LuaDLL.luaL_error(L, "attempt to index ignoreListenerVolume on a nil value");
    }
    luaObject.ignoreListenerVolume = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_playOnAwake(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_ignoreListenerPause(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ignoreListenerPause");
      else
        LuaDLL.luaL_error(L, "attempt to index ignoreListenerPause on a nil value");
    }
    luaObject.ignoreListenerPause = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_velocityUpdateMode(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name velocityUpdateMode");
      else
        LuaDLL.luaL_error(L, "attempt to index velocityUpdateMode on a nil value");
    }
    luaObject.velocityUpdateMode = (AudioVelocityUpdateMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (AudioVelocityUpdateMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_panStereo(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name panStereo");
      else
        LuaDLL.luaL_error(L, "attempt to index panStereo on a nil value");
    }
    luaObject.panStereo = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spatialBlend(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spatialBlend");
      else
        LuaDLL.luaL_error(L, "attempt to index spatialBlend on a nil value");
    }
    luaObject.spatialBlend = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spatialize(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spatialize");
      else
        LuaDLL.luaL_error(L, "attempt to index spatialize on a nil value");
    }
    luaObject.spatialize = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_reverbZoneMix(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name reverbZoneMix");
      else
        LuaDLL.luaL_error(L, "attempt to index reverbZoneMix on a nil value");
    }
    luaObject.reverbZoneMix = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bypassEffects(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassEffects");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassEffects on a nil value");
    }
    luaObject.bypassEffects = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bypassListenerEffects(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassListenerEffects");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassListenerEffects on a nil value");
    }
    luaObject.bypassListenerEffects = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bypassReverbZones(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bypassReverbZones");
      else
        LuaDLL.luaL_error(L, "attempt to index bypassReverbZones on a nil value");
    }
    luaObject.bypassReverbZones = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_dopplerLevel(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name dopplerLevel");
      else
        LuaDLL.luaL_error(L, "attempt to index dopplerLevel on a nil value");
    }
    luaObject.dopplerLevel = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spread(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spread");
      else
        LuaDLL.luaL_error(L, "attempt to index spread on a nil value");
    }
    luaObject.spread = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_priority(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
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
  private static int set_mute(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mute");
      else
        LuaDLL.luaL_error(L, "attempt to index mute on a nil value");
    }
    luaObject.mute = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_minDistance(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index minDistance on a nil value");
    }
    luaObject.minDistance = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxDistance(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index maxDistance on a nil value");
    }
    luaObject.maxDistance = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rolloffMode(IntPtr L)
  {
    AudioSource luaObject = (AudioSource) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rolloffMode");
      else
        LuaDLL.luaL_error(L, "attempt to index rolloffMode on a nil value");
    }
    luaObject.rolloffMode = (AudioRolloffMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (AudioRolloffMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Play(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).Play();
        return 0;
      case 2:
        ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).Play((ulong) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.Play");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlayDelayed(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).PlayDelayed((float) LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlayScheduled(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).PlayScheduled(LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetScheduledStartTime(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).SetScheduledStartTime(LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetScheduledEndTime(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).SetScheduledEndTime(LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Stop(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).Stop();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Pause(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).Pause();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UnPause(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).UnPause();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlayOneShot(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).PlayOneShot((AudioClip) LuaScriptMgr.GetUnityObject(L, 2, typeof (AudioClip)));
        return 0;
      case 3:
        ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).PlayOneShot((AudioClip) LuaScriptMgr.GetUnityObject(L, 2, typeof (AudioClip)), (float) LuaScriptMgr.GetNumber(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.PlayOneShot");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlayClipAtPoint(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        AudioSource.PlayClipAtPoint((AudioClip) LuaScriptMgr.GetUnityObject(L, 1, typeof (AudioClip)), LuaScriptMgr.GetVector3(L, 2));
        return 0;
      case 3:
        AudioSource.PlayClipAtPoint((AudioClip) LuaScriptMgr.GetUnityObject(L, 1, typeof (AudioClip)), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.PlayClipAtPoint");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetCustomCurve(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).SetCustomCurve((AudioSourceCurveType) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (AudioSourceCurveType)), (AnimationCurve) LuaScriptMgr.GetNetObject(L, 3, typeof (AnimationCurve)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCustomCurve(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    AnimationCurve customCurve = ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).GetCustomCurve((AudioSourceCurveType) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (AudioSourceCurveType)));
    LuaScriptMgr.PushObject(L, (object) customCurve);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetOutputData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).GetOutputData(LuaScriptMgr.GetArrayNumber<float>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSpectrumData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).GetSpectrumData(LuaScriptMgr.GetArrayNumber<float>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (FFTWindow) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (FFTWindow)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetSpatializerFloat(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    bool b = ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).SetSpatializerFloat((int) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSpatializerFloat(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    float d;
    bool spatializerFloat = ((AudioSource) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioSource")).GetSpatializerFloat((int) LuaScriptMgr.GetNumber(L, 2), ref d);
    LuaScriptMgr.Push(L, spatializerFloat);
    LuaScriptMgr.Push(L, d);
    return 2;
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
