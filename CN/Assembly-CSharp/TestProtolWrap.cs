// Decompiled with JetBrains decompiler
// Type: TestProtolWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class TestProtolWrap
{
  private static System.Type classType = typeof (TestProtol);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[2]
    {
      new LuaMethod("New", new LuaCSFunction(TestProtolWrap._CreateTestProtol)),
      new LuaMethod("GetClassType", new LuaCSFunction(TestProtolWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("data", new LuaCSFunction(TestProtolWrap.get_data), new LuaCSFunction(TestProtolWrap.set_data))
    };
    LuaScriptMgr.RegisterLib(L, "TestProtol", typeof (TestProtol), regs, fields, (System.Type) null);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTestProtol(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TestProtol class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TestProtolWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_data(IntPtr L)
  {
    LuaScriptMgr.Push(L, TestProtol.data);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_data(IntPtr L)
  {
    TestProtol.data = LuaScriptMgr.GetStringBuffer(L, 3);
    return 0;
  }
}
