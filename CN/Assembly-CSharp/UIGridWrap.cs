// Decompiled with JetBrains decompiler
// Type: UIGridWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UIGridWrap
{
  private static System.Type classType = typeof (UIGrid);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[7]
    {
      new LuaMethod("SortByName", new LuaCSFunction(UIGridWrap.SortByName)),
      new LuaMethod("SortHorizontal", new LuaCSFunction(UIGridWrap.SortHorizontal)),
      new LuaMethod("SortVertical", new LuaCSFunction(UIGridWrap.SortVertical)),
      new LuaMethod("Reposition", new LuaCSFunction(UIGridWrap.Reposition)),
      new LuaMethod("New", new LuaCSFunction(UIGridWrap._CreateUIGrid)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIGridWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIGridWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[11]
    {
      new LuaField("arrangement", new LuaCSFunction(UIGridWrap.get_arrangement), new LuaCSFunction(UIGridWrap.set_arrangement)),
      new LuaField("sorting", new LuaCSFunction(UIGridWrap.get_sorting), new LuaCSFunction(UIGridWrap.set_sorting)),
      new LuaField("pivot", new LuaCSFunction(UIGridWrap.get_pivot), new LuaCSFunction(UIGridWrap.set_pivot)),
      new LuaField("maxPerLine", new LuaCSFunction(UIGridWrap.get_maxPerLine), new LuaCSFunction(UIGridWrap.set_maxPerLine)),
      new LuaField("cellWidth", new LuaCSFunction(UIGridWrap.get_cellWidth), new LuaCSFunction(UIGridWrap.set_cellWidth)),
      new LuaField("cellHeight", new LuaCSFunction(UIGridWrap.get_cellHeight), new LuaCSFunction(UIGridWrap.set_cellHeight)),
      new LuaField("animateSmoothly", new LuaCSFunction(UIGridWrap.get_animateSmoothly), new LuaCSFunction(UIGridWrap.set_animateSmoothly)),
      new LuaField("hideInactive", new LuaCSFunction(UIGridWrap.get_hideInactive), new LuaCSFunction(UIGridWrap.set_hideInactive)),
      new LuaField("keepWithinPanel", new LuaCSFunction(UIGridWrap.get_keepWithinPanel), new LuaCSFunction(UIGridWrap.set_keepWithinPanel)),
      new LuaField("onReposition", new LuaCSFunction(UIGridWrap.get_onReposition), new LuaCSFunction(UIGridWrap.set_onReposition)),
      new LuaField("repositionNow", (LuaCSFunction) null, new LuaCSFunction(UIGridWrap.set_repositionNow))
    };
    LuaScriptMgr.RegisterLib(L, "UIGrid", typeof (UIGrid), regs, fields, typeof (UIWidgetContainer));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIGrid(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIGrid class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIGridWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_arrangement(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name arrangement");
      else
        LuaDLL.luaL_error(L, "attempt to index arrangement on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.arrangement);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sorting(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sorting");
      else
        LuaDLL.luaL_error(L, "attempt to index sorting on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.sorting);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pivot(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pivot");
      else
        LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.pivot);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxPerLine(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxPerLine");
      else
        LuaDLL.luaL_error(L, "attempt to index maxPerLine on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxPerLine);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cellWidth(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cellWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index cellWidth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.cellWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cellHeight(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cellHeight");
      else
        LuaDLL.luaL_error(L, "attempt to index cellHeight on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.cellHeight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_animateSmoothly(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name animateSmoothly");
      else
        LuaDLL.luaL_error(L, "attempt to index animateSmoothly on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.animateSmoothly);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hideInactive(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideInactive");
      else
        LuaDLL.luaL_error(L, "attempt to index hideInactive on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hideInactive);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_keepWithinPanel(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepWithinPanel");
      else
        LuaDLL.luaL_error(L, "attempt to index keepWithinPanel on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.keepWithinPanel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onReposition(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onReposition");
      else
        LuaDLL.luaL_error(L, "attempt to index onReposition on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.onReposition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_arrangement(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name arrangement");
      else
        LuaDLL.luaL_error(L, "attempt to index arrangement on a nil value");
    }
    luaObject.arrangement = (UIGrid.Arrangement) LuaScriptMgr.GetNetObject(L, 3, typeof (UIGrid.Arrangement));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sorting(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sorting");
      else
        LuaDLL.luaL_error(L, "attempt to index sorting on a nil value");
    }
    luaObject.sorting = (UIGrid.Sorting) LuaScriptMgr.GetNetObject(L, 3, typeof (UIGrid.Sorting));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pivot(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pivot");
      else
        LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
    }
    luaObject.pivot = (UIWidget.Pivot) LuaScriptMgr.GetNetObject(L, 3, typeof (UIWidget.Pivot));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxPerLine(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxPerLine");
      else
        LuaDLL.luaL_error(L, "attempt to index maxPerLine on a nil value");
    }
    luaObject.maxPerLine = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cellWidth(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cellWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index cellWidth on a nil value");
    }
    luaObject.cellWidth = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cellHeight(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cellHeight");
      else
        LuaDLL.luaL_error(L, "attempt to index cellHeight on a nil value");
    }
    luaObject.cellHeight = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_animateSmoothly(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name animateSmoothly");
      else
        LuaDLL.luaL_error(L, "attempt to index animateSmoothly on a nil value");
    }
    luaObject.animateSmoothly = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hideInactive(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideInactive");
      else
        LuaDLL.luaL_error(L, "attempt to index hideInactive on a nil value");
    }
    luaObject.hideInactive = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_keepWithinPanel(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepWithinPanel");
      else
        LuaDLL.luaL_error(L, "attempt to index keepWithinPanel on a nil value");
    }
    luaObject.keepWithinPanel = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onReposition(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onReposition");
      else
        LuaDLL.luaL_error(L, "attempt to index onReposition on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.onReposition = (UIGrid.OnReposition) LuaScriptMgr.GetNetObject(L, 3, typeof (UIGrid.OnReposition));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.onReposition = (UIGrid.OnReposition) (() => func.Call());
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_repositionNow(IntPtr L)
  {
    UIGrid luaObject = (UIGrid) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name repositionNow");
      else
        LuaDLL.luaL_error(L, "attempt to index repositionNow on a nil value");
    }
    luaObject.repositionNow = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SortByName(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = UIGrid.SortByName((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), (Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SortHorizontal(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = UIGrid.SortHorizontal((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), (Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SortVertical(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = UIGrid.SortVertical((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), (Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Reposition(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIGrid) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid")).Reposition();
    return 0;
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
