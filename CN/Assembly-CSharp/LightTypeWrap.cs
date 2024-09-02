// Decompiled with JetBrains decompiler
// Type: LightTypeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class LightTypeWrap
{
  private static LuaMethod[] enums = new LuaMethod[5]
  {
    new LuaMethod("Spot", new LuaCSFunction(LightTypeWrap.GetSpot)),
    new LuaMethod("Directional", new LuaCSFunction(LightTypeWrap.GetDirectional)),
    new LuaMethod("Point", new LuaCSFunction(LightTypeWrap.GetPoint)),
    new LuaMethod("Area", new LuaCSFunction(LightTypeWrap.GetArea)),
    new LuaMethod("IntToEnum", new LuaCSFunction(LightTypeWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.LightType", typeof (LightType), LightTypeWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSpot(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (LightType) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDirectional(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (LightType) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPoint(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (LightType) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetArea(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (LightType) 3);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    LightType e = (LightType) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
