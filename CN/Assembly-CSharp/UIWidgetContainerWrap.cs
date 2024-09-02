// Decompiled with JetBrains decompiler
// Type: UIWidgetContainerWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UIWidgetContainerWrap
{
  private static System.Type classType = typeof (UIWidgetContainer);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(UIWidgetContainerWrap._CreateUIWidgetContainer)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIWidgetContainerWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIWidgetContainerWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "UIWidgetContainer", typeof (UIWidgetContainer), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIWidgetContainer(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIWidgetContainer class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIWidgetContainerWrap.classType);
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
