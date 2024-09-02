// Decompiled with JetBrains decompiler
// Type: TestOverride_SpaceWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class TestOverride_SpaceWrap
{
  private static LuaMethod[] enums = new LuaMethod[2]
  {
    new LuaMethod("World", new LuaCSFunction(TestOverride_SpaceWrap.GetWorld)),
    new LuaMethod("IntToEnum", new LuaCSFunction(TestOverride_SpaceWrap.IntToEnum))
  };

  public static void Register(IntPtr L)
  {
    LuaScriptMgr.RegisterLib(L, "TestOverride.Space", typeof (TestOverride.Space), TestOverride_SpaceWrap.enums);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWorld(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) TestOverride.Space.World);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IntToEnum(IntPtr L)
  {
    TestOverride.Space e = (TestOverride.Space) LuaDLL.lua_tonumber(L, 1);
    LuaScriptMgr.Push(L, (Enum) e);
    return 1;
  }
}
