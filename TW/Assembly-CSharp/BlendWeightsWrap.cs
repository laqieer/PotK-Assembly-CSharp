// Decompiled with JetBrains decompiler
// Type: BlendWeightsWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class BlendWeightsWrap
{
  private static LuaMethod[] enums = new LuaMethod[4]
  {
    new LuaMethod("OneBone", new LuaCSFunction(BlendWeightsWrap.GetOneBone)),
    new LuaMethod("TwoBones", new LuaCSFunction(BlendWeightsWrap.GetTwoBones)),
    new LuaMethod("FourBones", new LuaCSFunction(BlendWeightsWrap.GetFourBones)),
    new LuaMethod("IntToEnum", new LuaCSFunction(BlendWeightsWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.BlendWeights", typeof (BlendWeights), BlendWeightsWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetOneBone(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (BlendWeights) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTwoBones(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (BlendWeights) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetFourBones(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (BlendWeights) 4);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    BlendWeights e = (BlendWeights) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
