// Decompiled with JetBrains decompiler
// Type: AudioClipWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AudioClipWrap
{
  private static System.Type classType = typeof (AudioClip);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[8]
    {
      new LuaMethod("LoadAudioData", new LuaCSFunction(AudioClipWrap.LoadAudioData)),
      new LuaMethod("UnloadAudioData", new LuaCSFunction(AudioClipWrap.UnloadAudioData)),
      new LuaMethod("GetData", new LuaCSFunction(AudioClipWrap.GetData)),
      new LuaMethod("SetData", new LuaCSFunction(AudioClipWrap.SetData)),
      new LuaMethod("Create", new LuaCSFunction(AudioClipWrap.Create)),
      new LuaMethod("New", new LuaCSFunction(AudioClipWrap._CreateAudioClip)),
      new LuaMethod("GetClassType", new LuaCSFunction(AudioClipWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AudioClipWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[8]
    {
      new LuaField("length", new LuaCSFunction(AudioClipWrap.get_length), (LuaCSFunction) null),
      new LuaField("samples", new LuaCSFunction(AudioClipWrap.get_samples), (LuaCSFunction) null),
      new LuaField("channels", new LuaCSFunction(AudioClipWrap.get_channels), (LuaCSFunction) null),
      new LuaField("frequency", new LuaCSFunction(AudioClipWrap.get_frequency), (LuaCSFunction) null),
      new LuaField("loadType", new LuaCSFunction(AudioClipWrap.get_loadType), (LuaCSFunction) null),
      new LuaField("preloadAudioData", new LuaCSFunction(AudioClipWrap.get_preloadAudioData), (LuaCSFunction) null),
      new LuaField("loadState", new LuaCSFunction(AudioClipWrap.get_loadState), (LuaCSFunction) null),
      new LuaField("loadInBackground", new LuaCSFunction(AudioClipWrap.get_loadInBackground), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioClip", typeof (AudioClip), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAudioClip(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AudioClip audioClip = new AudioClip();
      LuaScriptMgr.Push(L, (Object) audioClip);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AudioClip.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AudioClipWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_length(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_samples(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name samples");
      else
        LuaDLL.luaL_error(L, "attempt to index samples on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.samples);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_channels(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name channels");
      else
        LuaDLL.luaL_error(L, "attempt to index channels on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.channels);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_frequency(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name frequency");
      else
        LuaDLL.luaL_error(L, "attempt to index frequency on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.frequency);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_loadType(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name loadType");
      else
        LuaDLL.luaL_error(L, "attempt to index loadType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.loadType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_preloadAudioData(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name preloadAudioData");
      else
        LuaDLL.luaL_error(L, "attempt to index preloadAudioData on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.preloadAudioData);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_loadState(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name loadState");
      else
        LuaDLL.luaL_error(L, "attempt to index loadState on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.loadState);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_loadInBackground(IntPtr L)
  {
    AudioClip luaObject = (AudioClip) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name loadInBackground");
      else
        LuaDLL.luaL_error(L, "attempt to index loadInBackground on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.loadInBackground);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAudioData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = ((AudioClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioClip")).LoadAudioData();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UnloadAudioData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = ((AudioClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioClip")).UnloadAudioData();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    bool data = ((AudioClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioClip")).GetData(LuaScriptMgr.GetArrayNumber<float>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    LuaScriptMgr.Push(L, data);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    bool b = ((AudioClip) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AudioClip")).SetData(LuaScriptMgr.GetArrayNumber<float>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Create(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 5:
        AudioClip audioClip1 = AudioClip.Create(LuaScriptMgr.GetLuaString(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), LuaScriptMgr.GetBoolean(L, 5));
        LuaScriptMgr.Push(L, (Object) audioClip1);
        return 1;
      case 6:
        string luaString1 = LuaScriptMgr.GetLuaString(L, 1);
        int number1 = (int) LuaScriptMgr.GetNumber(L, 2);
        int number2 = (int) LuaScriptMgr.GetNumber(L, 3);
        int number3 = (int) LuaScriptMgr.GetNumber(L, 4);
        bool boolean1 = LuaScriptMgr.GetBoolean(L, 5);
        AudioClip.PCMReaderCallback pcmReaderCallback1;
        if (LuaDLL.lua_type(L, 6) != LuaTypes.LUA_TFUNCTION)
        {
          pcmReaderCallback1 = (AudioClip.PCMReaderCallback) LuaScriptMgr.GetNetObject(L, 6, typeof (AudioClip.PCMReaderCallback));
        }
        else
        {
          LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 6);
          pcmReaderCallback1 = (AudioClip.PCMReaderCallback) (param0 =>
          {
            int oldTop = func.BeginPCall();
            LuaScriptMgr.PushArray(L, (Array) param0);
            func.PCall(oldTop, 1);
            func.EndPCall(oldTop);
          });
        }
        AudioClip audioClip2 = AudioClip.Create(luaString1, number1, number2, number3, boolean1, pcmReaderCallback1);
        LuaScriptMgr.Push(L, (Object) audioClip2);
        return 1;
      case 7:
        string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
        int number4 = (int) LuaScriptMgr.GetNumber(L, 2);
        int number5 = (int) LuaScriptMgr.GetNumber(L, 3);
        int number6 = (int) LuaScriptMgr.GetNumber(L, 4);
        bool boolean2 = LuaScriptMgr.GetBoolean(L, 5);
        AudioClip.PCMReaderCallback pcmReaderCallback2;
        if (LuaDLL.lua_type(L, 6) != LuaTypes.LUA_TFUNCTION)
        {
          pcmReaderCallback2 = (AudioClip.PCMReaderCallback) LuaScriptMgr.GetNetObject(L, 6, typeof (AudioClip.PCMReaderCallback));
        }
        else
        {
          LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 6);
          pcmReaderCallback2 = (AudioClip.PCMReaderCallback) (param0 =>
          {
            int oldTop = func.BeginPCall();
            LuaScriptMgr.PushArray(L, (Array) param0);
            func.PCall(oldTop, 1);
            func.EndPCall(oldTop);
          });
        }
        AudioClip.PCMSetPositionCallback positionCallback;
        if (LuaDLL.lua_type(L, 7) != LuaTypes.LUA_TFUNCTION)
        {
          positionCallback = (AudioClip.PCMSetPositionCallback) LuaScriptMgr.GetNetObject(L, 7, typeof (AudioClip.PCMSetPositionCallback));
        }
        else
        {
          LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 7);
          positionCallback = (AudioClip.PCMSetPositionCallback) (param0 =>
          {
            int oldTop = func.BeginPCall();
            LuaScriptMgr.Push(L, param0);
            func.PCall(oldTop, 1);
            func.EndPCall(oldTop);
          });
        }
        AudioClip audioClip3 = AudioClip.Create(luaString2, number4, number5, number6, boolean2, pcmReaderCallback2, positionCallback);
        LuaScriptMgr.Push(L, (Object) audioClip3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AudioClip.Create");
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
