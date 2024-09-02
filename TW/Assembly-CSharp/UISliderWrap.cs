// Decompiled with JetBrains decompiler
// Type: UISliderWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UISliderWrap
{
  private static System.Type classType = typeof (UISlider);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(UISliderWrap._CreateUISlider)),
      new LuaMethod("GetClassType", new LuaCSFunction(UISliderWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UISliderWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "UISlider", typeof (UISlider), regs, fields, typeof (UIProgressBar));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUISlider(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UISlider class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UISliderWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
