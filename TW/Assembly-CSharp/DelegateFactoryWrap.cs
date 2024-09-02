// Decompiled with JetBrains decompiler
// Type: DelegateFactoryWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class DelegateFactoryWrap
{
  private static System.Type classType = typeof (DelegateFactory);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[4]
    {
      new LuaMethod("Action_GameObject", new LuaCSFunction(DelegateFactoryWrap.Action_GameObject)),
      new LuaMethod("Clear", new LuaCSFunction(DelegateFactoryWrap.Clear)),
      new LuaMethod("New", new LuaCSFunction(DelegateFactoryWrap._CreateDelegateFactory)),
      new LuaMethod("GetClassType", new LuaCSFunction(DelegateFactoryWrap.GetClassType))
    };
    LuaScriptMgr.RegisterLib(L, "DelegateFactory", regs);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateDelegateFactory(IntPtr L)
  {
    LuaDLL.luaL_error(L, "DelegateFactory class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, DelegateFactoryWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Action_GameObject(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Delegate o = DelegateFactory.Action_GameObject(LuaScriptMgr.GetLuaFunction(L, 1));
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Clear(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    DelegateFactory.Clear();
    return 0;
  }
}
