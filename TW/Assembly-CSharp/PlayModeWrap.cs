// Decompiled with JetBrains decompiler
// Type: PlayModeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class PlayModeWrap
{
  private static LuaMethod[] enums = new LuaMethod[3]
  {
    new LuaMethod("StopSameLayer", new LuaCSFunction(PlayModeWrap.GetStopSameLayer)),
    new LuaMethod("StopAll", new LuaCSFunction(PlayModeWrap.GetStopAll)),
    new LuaMethod("IntToEnum", new LuaCSFunction(PlayModeWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.PlayMode", typeof (PlayMode), PlayModeWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStopSameLayer(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (PlayMode) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStopAll(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (PlayMode) 4);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    PlayMode e = (PlayMode) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
