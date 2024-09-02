// Decompiled with JetBrains decompiler
// Type: TestOverrideWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class TestOverrideWrap
{
  private static System.Type classType = typeof (TestOverride);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("Test", new LuaCSFunction(TestOverrideWrap.Test)),
      new LuaMethod("New", new LuaCSFunction(TestOverrideWrap._CreateTestOverride)),
      new LuaMethod("GetClassType", new LuaCSFunction(TestOverrideWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "TestOverride", typeof (TestOverride), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTestOverride(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      TestOverride o = new TestOverride();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: TestOverride.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TestOverrideWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Test(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (string)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      int d = TestOverride.Test(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (TestOverride.Space)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test((TestOverride.Space) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (double)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test(LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (object)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test(LuaScriptMgr.GetVarObject(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (int), typeof (int)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test((int) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (TestOverride), typeof (object), typeof (string)))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test(LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetString(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (object), 2, num - 1))
    {
      int d = ((TestOverride) LuaScriptMgr.GetNetObjectSelf(L, 1, "TestOverride")).Test(LuaScriptMgr.GetParamsObject(L, 2, num - 1));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: TestOverride.Test");
    return 0;
  }
}
