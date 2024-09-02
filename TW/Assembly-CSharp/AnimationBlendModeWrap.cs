// Decompiled with JetBrains decompiler
// Type: AnimationBlendModeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AnimationBlendModeWrap
{
  private static LuaMethod[] enums = new LuaMethod[3]
  {
    new LuaMethod("Blend", new LuaCSFunction(AnimationBlendModeWrap.GetBlend)),
    new LuaMethod("Additive", new LuaCSFunction(AnimationBlendModeWrap.GetAdditive)),
    new LuaMethod("IntToEnum", new LuaCSFunction(AnimationBlendModeWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationBlendMode", typeof (AnimationBlendMode), AnimationBlendModeWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBlend(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (AnimationBlendMode) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAdditive(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (AnimationBlendMode) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    AnimationBlendMode e = (AnimationBlendMode) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
