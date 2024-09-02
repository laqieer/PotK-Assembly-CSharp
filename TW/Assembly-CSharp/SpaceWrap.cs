// Decompiled with JetBrains decompiler
// Type: SpaceWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class SpaceWrap
{
  private static LuaMethod[] enums = new LuaMethod[3]
  {
    new LuaMethod("World", new LuaCSFunction(SpaceWrap.GetWorld)),
    new LuaMethod("Self", new LuaCSFunction(SpaceWrap.GetSelf)),
    new LuaMethod("IntToEnum", new LuaCSFunction(SpaceWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Space", typeof (Space), SpaceWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWorld(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (Space) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSelf(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (Space) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    Space e = (Space) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
