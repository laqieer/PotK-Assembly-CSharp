// Decompiled with JetBrains decompiler
// Type: QueueModeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class QueueModeWrap
{
  private static LuaMethod[] enums = new LuaMethod[3]
  {
    new LuaMethod("CompleteOthers", new LuaCSFunction(QueueModeWrap.GetCompleteOthers)),
    new LuaMethod("PlayNow", new LuaCSFunction(QueueModeWrap.GetPlayNow)),
    new LuaMethod("IntToEnum", new LuaCSFunction(QueueModeWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "UnityEngine.QueueMode", typeof (QueueMode), QueueModeWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCompleteOthers(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (QueueMode) 0);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPlayNow(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) (QueueMode) 2);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    QueueMode e = (QueueMode) (int) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) (object) e);
    return 1;
  }
}
