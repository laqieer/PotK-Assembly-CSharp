// Decompiled with JetBrains decompiler
// Type: UIWidgetWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UIWidgetWrap
{
  private static System.Type classType = typeof (UIWidget);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[24]
    {
      new LuaMethod("SetDimensions", new LuaCSFunction(UIWidgetWrap.SetDimensions)),
      new LuaMethod("GetSides", new LuaCSFunction(UIWidgetWrap.GetSides)),
      new LuaMethod("CalculateFinalAlpha", new LuaCSFunction(UIWidgetWrap.CalculateFinalAlpha)),
      new LuaMethod("Invalidate", new LuaCSFunction(UIWidgetWrap.Invalidate)),
      new LuaMethod("CalculateCumulativeAlpha", new LuaCSFunction(UIWidgetWrap.CalculateCumulativeAlpha)),
      new LuaMethod("SetRect", new LuaCSFunction(UIWidgetWrap.SetRect)),
      new LuaMethod("ResizeCollider", new LuaCSFunction(UIWidgetWrap.ResizeCollider)),
      new LuaMethod("FullCompareFunc", new LuaCSFunction(UIWidgetWrap.FullCompareFunc)),
      new LuaMethod("PanelCompareFunc", new LuaCSFunction(UIWidgetWrap.PanelCompareFunc)),
      new LuaMethod("CalculateBounds", new LuaCSFunction(UIWidgetWrap.CalculateBounds)),
      new LuaMethod("SetDirty", new LuaCSFunction(UIWidgetWrap.SetDirty)),
      new LuaMethod("MarkAsChanged", new LuaCSFunction(UIWidgetWrap.MarkAsChanged)),
      new LuaMethod("CreatePanel", new LuaCSFunction(UIWidgetWrap.CreatePanel)),
      new LuaMethod("CheckLayer", new LuaCSFunction(UIWidgetWrap.CheckLayer)),
      new LuaMethod("ParentHasChanged", new LuaCSFunction(UIWidgetWrap.ParentHasChanged)),
      new LuaMethod("UpdateVisibility", new LuaCSFunction(UIWidgetWrap.UpdateVisibility)),
      new LuaMethod("UpdateTransform", new LuaCSFunction(UIWidgetWrap.UpdateTransform)),
      new LuaMethod("UpdateGeometry", new LuaCSFunction(UIWidgetWrap.UpdateGeometry)),
      new LuaMethod("WriteToBuffers", new LuaCSFunction(UIWidgetWrap.WriteToBuffers)),
      new LuaMethod("MakePixelPerfect", new LuaCSFunction(UIWidgetWrap.MakePixelPerfect)),
      new LuaMethod("OnFill", new LuaCSFunction(UIWidgetWrap.OnFill)),
      new LuaMethod("New", new LuaCSFunction(UIWidgetWrap._CreateUIWidget)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIWidgetWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIWidgetWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[33]
    {
      new LuaField("onChange", new LuaCSFunction(UIWidgetWrap.get_onChange), new LuaCSFunction(UIWidgetWrap.set_onChange)),
      new LuaField("autoResizeBoxCollider", new LuaCSFunction(UIWidgetWrap.get_autoResizeBoxCollider), new LuaCSFunction(UIWidgetWrap.set_autoResizeBoxCollider)),
      new LuaField("hideIfOffScreen", new LuaCSFunction(UIWidgetWrap.get_hideIfOffScreen), new LuaCSFunction(UIWidgetWrap.set_hideIfOffScreen)),
      new LuaField("keepAspectRatio", new LuaCSFunction(UIWidgetWrap.get_keepAspectRatio), new LuaCSFunction(UIWidgetWrap.set_keepAspectRatio)),
      new LuaField("aspectRatio", new LuaCSFunction(UIWidgetWrap.get_aspectRatio), new LuaCSFunction(UIWidgetWrap.set_aspectRatio)),
      new LuaField("hitCheck", new LuaCSFunction(UIWidgetWrap.get_hitCheck), new LuaCSFunction(UIWidgetWrap.set_hitCheck)),
      new LuaField("panel", new LuaCSFunction(UIWidgetWrap.get_panel), new LuaCSFunction(UIWidgetWrap.set_panel)),
      new LuaField("geometry", new LuaCSFunction(UIWidgetWrap.get_geometry), new LuaCSFunction(UIWidgetWrap.set_geometry)),
      new LuaField("fillGeometry", new LuaCSFunction(UIWidgetWrap.get_fillGeometry), new LuaCSFunction(UIWidgetWrap.set_fillGeometry)),
      new LuaField("drawCall", new LuaCSFunction(UIWidgetWrap.get_drawCall), new LuaCSFunction(UIWidgetWrap.set_drawCall)),
      new LuaField("drawRegion", new LuaCSFunction(UIWidgetWrap.get_drawRegion), new LuaCSFunction(UIWidgetWrap.set_drawRegion)),
      new LuaField("pivotOffset", new LuaCSFunction(UIWidgetWrap.get_pivotOffset), (LuaCSFunction) null),
      new LuaField("width", new LuaCSFunction(UIWidgetWrap.get_width), new LuaCSFunction(UIWidgetWrap.set_width)),
      new LuaField("height", new LuaCSFunction(UIWidgetWrap.get_height), new LuaCSFunction(UIWidgetWrap.set_height)),
      new LuaField("color", new LuaCSFunction(UIWidgetWrap.get_color), new LuaCSFunction(UIWidgetWrap.set_color)),
      new LuaField("alpha", new LuaCSFunction(UIWidgetWrap.get_alpha), new LuaCSFunction(UIWidgetWrap.set_alpha)),
      new LuaField("isVisible", new LuaCSFunction(UIWidgetWrap.get_isVisible), (LuaCSFunction) null),
      new LuaField("hasVertices", new LuaCSFunction(UIWidgetWrap.get_hasVertices), (LuaCSFunction) null),
      new LuaField("rawPivot", new LuaCSFunction(UIWidgetWrap.get_rawPivot), new LuaCSFunction(UIWidgetWrap.set_rawPivot)),
      new LuaField("pivot", new LuaCSFunction(UIWidgetWrap.get_pivot), new LuaCSFunction(UIWidgetWrap.set_pivot)),
      new LuaField("depth", new LuaCSFunction(UIWidgetWrap.get_depth), new LuaCSFunction(UIWidgetWrap.set_depth)),
      new LuaField("raycastDepth", new LuaCSFunction(UIWidgetWrap.get_raycastDepth), (LuaCSFunction) null),
      new LuaField("localCorners", new LuaCSFunction(UIWidgetWrap.get_localCorners), (LuaCSFunction) null),
      new LuaField("localSize", new LuaCSFunction(UIWidgetWrap.get_localSize), (LuaCSFunction) null),
      new LuaField("worldCorners", new LuaCSFunction(UIWidgetWrap.get_worldCorners), (LuaCSFunction) null),
      new LuaField("drawingDimensions", new LuaCSFunction(UIWidgetWrap.get_drawingDimensions), (LuaCSFunction) null),
      new LuaField("material", new LuaCSFunction(UIWidgetWrap.get_material), new LuaCSFunction(UIWidgetWrap.set_material)),
      new LuaField("mainTexture", new LuaCSFunction(UIWidgetWrap.get_mainTexture), new LuaCSFunction(UIWidgetWrap.set_mainTexture)),
      new LuaField("shader", new LuaCSFunction(UIWidgetWrap.get_shader), new LuaCSFunction(UIWidgetWrap.set_shader)),
      new LuaField("hasBoxCollider", new LuaCSFunction(UIWidgetWrap.get_hasBoxCollider), (LuaCSFunction) null),
      new LuaField("minWidth", new LuaCSFunction(UIWidgetWrap.get_minWidth), (LuaCSFunction) null),
      new LuaField("minHeight", new LuaCSFunction(UIWidgetWrap.get_minHeight), (LuaCSFunction) null),
      new LuaField("border", new LuaCSFunction(UIWidgetWrap.get_border), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UIWidget", typeof (UIWidget), regs, fields, typeof (UIRect));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIWidget(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIWidget class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIWidgetWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onChange(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.onChange);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autoResizeBoxCollider(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name autoResizeBoxCollider");
      else
        LuaDLL.luaL_error(L, "attempt to index autoResizeBoxCollider on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.autoResizeBoxCollider);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hideIfOffScreen(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideIfOffScreen");
      else
        LuaDLL.luaL_error(L, "attempt to index hideIfOffScreen on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hideIfOffScreen);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_keepAspectRatio(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepAspectRatio");
      else
        LuaDLL.luaL_error(L, "attempt to index keepAspectRatio on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.keepAspectRatio);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_aspectRatio(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name aspectRatio");
      else
        LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.aspectRatio);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hitCheck(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hitCheck");
      else
        LuaDLL.luaL_error(L, "attempt to index hitCheck on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.hitCheck);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_panel(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name panel");
      else
        LuaDLL.luaL_error(L, "attempt to index panel on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.panel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_geometry(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name geometry");
      else
        LuaDLL.luaL_error(L, "attempt to index geometry on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.geometry);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fillGeometry(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillGeometry");
      else
        LuaDLL.luaL_error(L, "attempt to index fillGeometry on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.fillGeometry);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawCall(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawCall");
      else
        LuaDLL.luaL_error(L, "attempt to index drawCall on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.drawCall);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawRegion(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawRegion");
      else
        LuaDLL.luaL_error(L, "attempt to index drawRegion on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.drawRegion);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pivotOffset(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pivotOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index pivotOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pivotOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_width(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name width");
      else
        LuaDLL.luaL_error(L, "attempt to index width on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.width);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_height(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name height");
      else
        LuaDLL.luaL_error(L, "attempt to index height on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.height);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_color(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name color");
      else
        LuaDLL.luaL_error(L, "attempt to index color on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.color);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_alpha(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alpha");
      else
        LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.alpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isVisible(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isVisible");
      else
        LuaDLL.luaL_error(L, "attempt to index isVisible on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isVisible);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hasVertices(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hasVertices");
      else
        LuaDLL.luaL_error(L, "attempt to index hasVertices on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hasVertices);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rawPivot(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rawPivot");
      else
        LuaDLL.luaL_error(L, "attempt to index rawPivot on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.rawPivot);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pivot(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_depth(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depth");
      else
        LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.depth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_raycastDepth(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name raycastDepth");
      else
        LuaDLL.luaL_error(L, "attempt to index raycastDepth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.raycastDepth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localCorners(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localCorners");
      else
        LuaDLL.luaL_error(L, "attempt to index localCorners on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.localCorners);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localSize(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localSize");
      else
        LuaDLL.luaL_error(L, "attempt to index localSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldCorners(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldCorners");
      else
        LuaDLL.luaL_error(L, "attempt to index worldCorners on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.worldCorners);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawingDimensions(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
      else
        LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.drawingDimensions);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.material);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_mainTexture(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.mainTexture);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shader(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shader");
      else
        LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.shader);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hasBoxCollider(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hasBoxCollider");
      else
        LuaDLL.luaL_error(L, "attempt to index hasBoxCollider on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hasBoxCollider);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minWidth(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index minWidth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minHeight(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minHeight");
      else
        LuaDLL.luaL_error(L, "attempt to index minHeight on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minHeight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_border(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name border");
      else
        LuaDLL.luaL_error(L, "attempt to index border on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.border);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onChange(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.onChange = (UIWidget.OnDimensionsChanged) LuaScriptMgr.GetNetObject(L, 3, typeof (UIWidget.OnDimensionsChanged));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.onChange = (UIWidget.OnDimensionsChanged) (() => func.Call());
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autoResizeBoxCollider(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name autoResizeBoxCollider");
      else
        LuaDLL.luaL_error(L, "attempt to index autoResizeBoxCollider on a nil value");
    }
    luaObject.autoResizeBoxCollider = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hideIfOffScreen(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideIfOffScreen");
      else
        LuaDLL.luaL_error(L, "attempt to index hideIfOffScreen on a nil value");
    }
    luaObject.hideIfOffScreen = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_keepAspectRatio(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepAspectRatio");
      else
        LuaDLL.luaL_error(L, "attempt to index keepAspectRatio on a nil value");
    }
    luaObject.keepAspectRatio = (UIWidget.AspectRatioSource) LuaScriptMgr.GetNetObject(L, 3, typeof (UIWidget.AspectRatioSource));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_aspectRatio(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name aspectRatio");
      else
        LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
    }
    luaObject.aspectRatio = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hitCheck(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hitCheck");
      else
        LuaDLL.luaL_error(L, "attempt to index hitCheck on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.hitCheck = (UIWidget.HitCheck) LuaScriptMgr.GetNetObject(L, 3, typeof (UIWidget.HitCheck));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.hitCheck = (UIWidget.HitCheck) (param0 =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, param0);
        func.PCall(oldTop, 1);
        object[] objArray = func.PopValues(oldTop);
        func.EndPCall(oldTop);
        return (bool) objArray[0];
      });
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_panel(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name panel");
      else
        LuaDLL.luaL_error(L, "attempt to index panel on a nil value");
    }
    luaObject.panel = (UIPanel) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIPanel));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_geometry(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name geometry");
      else
        LuaDLL.luaL_error(L, "attempt to index geometry on a nil value");
    }
    luaObject.geometry = (UIGeometry) LuaScriptMgr.GetNetObject(L, 3, typeof (UIGeometry));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fillGeometry(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillGeometry");
      else
        LuaDLL.luaL_error(L, "attempt to index fillGeometry on a nil value");
    }
    luaObject.fillGeometry = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_drawCall(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawCall");
      else
        LuaDLL.luaL_error(L, "attempt to index drawCall on a nil value");
    }
    luaObject.drawCall = (UIDrawCall) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIDrawCall));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_drawRegion(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawRegion");
      else
        LuaDLL.luaL_error(L, "attempt to index drawRegion on a nil value");
    }
    luaObject.drawRegion = LuaScriptMgr.GetVector4(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_width(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name width");
      else
        LuaDLL.luaL_error(L, "attempt to index width on a nil value");
    }
    luaObject.width = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_height(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name height");
      else
        LuaDLL.luaL_error(L, "attempt to index height on a nil value");
    }
    luaObject.height = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_color(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name color");
      else
        LuaDLL.luaL_error(L, "attempt to index color on a nil value");
    }
    luaObject.color = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_alpha(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alpha");
      else
        LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
    }
    luaObject.alpha = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rawPivot(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rawPivot");
      else
        LuaDLL.luaL_error(L, "attempt to index rawPivot on a nil value");
    }
    luaObject.rawPivot = (UIWidget.Pivot) LuaScriptMgr.GetNetObject(L, 3, typeof (UIWidget.Pivot));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pivot(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_depth(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depth");
      else
        LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
    }
    luaObject.depth = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_material(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    luaObject.material = (Material) LuaScriptMgr.GetUnityObject(L, 3, typeof (Material));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_mainTexture(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
    }
    luaObject.mainTexture = (Texture) LuaScriptMgr.GetUnityObject(L, 3, typeof (Texture));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shader(IntPtr L)
  {
    UIWidget luaObject = (UIWidget) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shader");
      else
        LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
    }
    luaObject.shader = (Shader) LuaScriptMgr.GetUnityObject(L, 3, typeof (Shader));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetDimensions(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).SetDimensions((int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSides(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3[] sides = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).GetSides((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.PushArray(L, (Array) sides);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateFinalAlpha(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    float finalAlpha = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CalculateFinalAlpha((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, finalAlpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Invalidate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).Invalidate(LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateCumulativeAlpha(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    float cumulativeAlpha = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CalculateCumulativeAlpha((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, cumulativeAlpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetRect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 5);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).SetRect((float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (float) LuaScriptMgr.GetNumber(L, 5));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResizeCollider(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).ResizeCollider();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FullCompareFunc(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = UIWidget.FullCompareFunc((UIWidget) LuaScriptMgr.GetUnityObject(L, 1, typeof (UIWidget)), (UIWidget) LuaScriptMgr.GetUnityObject(L, 2, typeof (UIWidget)));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PanelCompareFunc(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = UIWidget.PanelCompareFunc((UIWidget) LuaScriptMgr.GetUnityObject(L, 1, typeof (UIWidget)), (UIWidget) LuaScriptMgr.GetUnityObject(L, 2, typeof (UIWidget)));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateBounds(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Bounds bounds1 = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CalculateBounds();
        LuaScriptMgr.Push(L, bounds1);
        return 1;
      case 2:
        Bounds bounds2 = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CalculateBounds((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
        LuaScriptMgr.Push(L, bounds2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: UIWidget.CalculateBounds");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetDirty(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).SetDirty();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MarkAsChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).MarkAsChanged();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CreatePanel(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    UIPanel panel = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CreatePanel();
    LuaScriptMgr.Push(L, (Object) panel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckLayer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).CheckLayer();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ParentHasChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).ParentHasChanged();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateVisibility(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    bool b = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).UpdateVisibility(LuaScriptMgr.GetBoolean(L, 2), LuaScriptMgr.GetBoolean(L, 3));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateTransform(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).UpdateTransform((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateGeometry(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).UpdateGeometry((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int WriteToBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 6);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).WriteToBuffers((BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 2, typeof (BetterList<Vector3>)), (BetterList<Vector2>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<Vector2>)), (BetterList<Color32>) LuaScriptMgr.GetNetObject(L, 4, typeof (BetterList<Color32>)), (BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 5, typeof (BetterList<Vector3>)), (BetterList<Vector4>) LuaScriptMgr.GetNetObject(L, 6, typeof (BetterList<Vector4>)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePixelPerfect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).MakePixelPerfect();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OnFill(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((UIWidget) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget")).OnFill((BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 2, typeof (BetterList<Vector3>)), (BetterList<Vector2>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<Vector2>)), (BetterList<Color32>) LuaScriptMgr.GetNetObject(L, 4, typeof (BetterList<Color32>)));
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
