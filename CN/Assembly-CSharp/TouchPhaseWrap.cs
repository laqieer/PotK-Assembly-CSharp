// Decompiled with JetBrains decompiler
// Type: TouchPhaseWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TouchPhaseWrap
{
  private static LuaMethod[] enums = new LuaMethod[6]
  {
    new LuaMethod("Began", new LuaCSFunction(TouchPhaseWrap.GetBegan)),
    new LuaMethod("Moved", new LuaCSFunction(TouchPhaseWrap.GetMoved)),
    new LuaMethod("Stationary", new LuaCSFunction(TouchPhaseWrap.GetStationary)),
    new LuaMethod("Ended", new LuaCSFunction(TouchPhaseWrap.GetEnded)),
    new LuaMethod("Canceled", new LuaCSFunction(TouchPhaseWrap.GetCanceled)),
    new LuaMethod("IntToEnum", new LuaCSFunction(TouchPhaseWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.TouchPhase", typeof (TouchPhase), TouchPhaseWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBegan(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (TouchPhase) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMoved(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (TouchPhase) 1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStationary(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (TouchPhase) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEnded(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (TouchPhase) 3);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCanceled(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (TouchPhase) 4);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    TouchPhase e = (TouchPhase) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
