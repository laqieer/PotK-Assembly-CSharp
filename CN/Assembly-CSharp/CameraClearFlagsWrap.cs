// Decompiled with JetBrains decompiler
// Type: CameraClearFlagsWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class CameraClearFlagsWrap
{
  private static LuaMethod[] enums = new LuaMethod[6]
  {
    new LuaMethod("Skybox", new LuaCSFunction(CameraClearFlagsWrap.GetSkybox)),
    new LuaMethod("Color", new LuaCSFunction(CameraClearFlagsWrap.GetColor)),
    new LuaMethod("SolidColor", new LuaCSFunction(CameraClearFlagsWrap.GetSolidColor)),
    new LuaMethod("Depth", new LuaCSFunction(CameraClearFlagsWrap.GetDepth)),
    new LuaMethod("Nothing", new LuaCSFunction(CameraClearFlagsWrap.GetNothing)),
    new LuaMethod("IntToEnum", new LuaCSFunction(CameraClearFlagsWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.CameraClearFlags", typeof (CameraClearFlags), CameraClearFlagsWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSkybox(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (CameraClearFlags) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetColor(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (CameraClearFlags) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSolidColor(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (CameraClearFlags) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDepth(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (CameraClearFlags) 3);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNothing(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (CameraClearFlags) 4);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    CameraClearFlags e = (CameraClearFlags) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
