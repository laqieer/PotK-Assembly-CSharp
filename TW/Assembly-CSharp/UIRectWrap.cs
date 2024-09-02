// Decompiled with JetBrains decompiler
// Type: UIRectWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UIRectWrap
{
  private static System.Type classType = typeof (UIRect);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[11]
    {
      new LuaMethod("CalculateFinalAlpha", new LuaCSFunction(UIRectWrap.CalculateFinalAlpha)),
      new LuaMethod("Invalidate", new LuaCSFunction(UIRectWrap.Invalidate)),
      new LuaMethod("GetSides", new LuaCSFunction(UIRectWrap.GetSides)),
      new LuaMethod("Update", new LuaCSFunction(UIRectWrap.Update)),
      new LuaMethod("UpdateAnchors", new LuaCSFunction(UIRectWrap.UpdateAnchors)),
      new LuaMethod("SetAnchor", new LuaCSFunction(UIRectWrap.SetAnchor)),
      new LuaMethod("ResetAnchors", new LuaCSFunction(UIRectWrap.ResetAnchors)),
      new LuaMethod("ParentHasChanged", new LuaCSFunction(UIRectWrap.ParentHasChanged)),
      new LuaMethod("New", new LuaCSFunction(UIRectWrap._CreateUIRect)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIRectWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIRectWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[19]
    {
      new LuaField("leftAnchor", new LuaCSFunction(UIRectWrap.get_leftAnchor), new LuaCSFunction(UIRectWrap.set_leftAnchor)),
      new LuaField("rightAnchor", new LuaCSFunction(UIRectWrap.get_rightAnchor), new LuaCSFunction(UIRectWrap.set_rightAnchor)),
      new LuaField("bottomAnchor", new LuaCSFunction(UIRectWrap.get_bottomAnchor), new LuaCSFunction(UIRectWrap.set_bottomAnchor)),
      new LuaField("topAnchor", new LuaCSFunction(UIRectWrap.get_topAnchor), new LuaCSFunction(UIRectWrap.set_topAnchor)),
      new LuaField("updateAnchors", new LuaCSFunction(UIRectWrap.get_updateAnchors), new LuaCSFunction(UIRectWrap.set_updateAnchors)),
      new LuaField("finalAlpha", new LuaCSFunction(UIRectWrap.get_finalAlpha), new LuaCSFunction(UIRectWrap.set_finalAlpha)),
      new LuaField("cachedGameObject", new LuaCSFunction(UIRectWrap.get_cachedGameObject), (LuaCSFunction) null),
      new LuaField("cachedTransform", new LuaCSFunction(UIRectWrap.get_cachedTransform), (LuaCSFunction) null),
      new LuaField("anchorCamera", new LuaCSFunction(UIRectWrap.get_anchorCamera), (LuaCSFunction) null),
      new LuaField("isFullyAnchored", new LuaCSFunction(UIRectWrap.get_isFullyAnchored), (LuaCSFunction) null),
      new LuaField("isAnchoredHorizontally", new LuaCSFunction(UIRectWrap.get_isAnchoredHorizontally), (LuaCSFunction) null),
      new LuaField("isAnchoredVertically", new LuaCSFunction(UIRectWrap.get_isAnchoredVertically), (LuaCSFunction) null),
      new LuaField("canBeAnchored", new LuaCSFunction(UIRectWrap.get_canBeAnchored), (LuaCSFunction) null),
      new LuaField("parent", new LuaCSFunction(UIRectWrap.get_parent), (LuaCSFunction) null),
      new LuaField("root", new LuaCSFunction(UIRectWrap.get_root), (LuaCSFunction) null),
      new LuaField("isAnchored", new LuaCSFunction(UIRectWrap.get_isAnchored), (LuaCSFunction) null),
      new LuaField("alpha", new LuaCSFunction(UIRectWrap.get_alpha), new LuaCSFunction(UIRectWrap.set_alpha)),
      new LuaField("localCorners", new LuaCSFunction(UIRectWrap.get_localCorners), (LuaCSFunction) null),
      new LuaField("worldCorners", new LuaCSFunction(UIRectWrap.get_worldCorners), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UIRect", typeof (UIRect), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIRect(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIRect class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIRectWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_leftAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name leftAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index leftAnchor on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.leftAnchor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rightAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rightAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index rightAnchor on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.rightAnchor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bottomAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bottomAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index bottomAnchor on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.bottomAnchor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_topAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name topAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index topAnchor on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.topAnchor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_updateAnchors(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateAnchors");
      else
        LuaDLL.luaL_error(L, "attempt to index updateAnchors on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.updateAnchors);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_finalAlpha(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name finalAlpha");
      else
        LuaDLL.luaL_error(L, "attempt to index finalAlpha on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.finalAlpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedGameObject(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedGameObject");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedGameObject on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedGameObject);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedTransform(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedTransform");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedTransform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anchorCamera(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name anchorCamera");
      else
        LuaDLL.luaL_error(L, "attempt to index anchorCamera on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.anchorCamera);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isFullyAnchored(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isFullyAnchored");
      else
        LuaDLL.luaL_error(L, "attempt to index isFullyAnchored on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isFullyAnchored);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isAnchoredHorizontally(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isAnchoredHorizontally");
      else
        LuaDLL.luaL_error(L, "attempt to index isAnchoredHorizontally on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isAnchoredHorizontally);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isAnchoredVertically(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isAnchoredVertically");
      else
        LuaDLL.luaL_error(L, "attempt to index isAnchoredVertically on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isAnchoredVertically);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_canBeAnchored(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name canBeAnchored");
      else
        LuaDLL.luaL_error(L, "attempt to index canBeAnchored on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.canBeAnchored);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_parent(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name parent");
      else
        LuaDLL.luaL_error(L, "attempt to index parent on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.parent);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_root(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name root");
      else
        LuaDLL.luaL_error(L, "attempt to index root on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.root);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isAnchored(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isAnchored");
      else
        LuaDLL.luaL_error(L, "attempt to index isAnchored on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isAnchored);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_alpha(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_localCorners(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_worldCorners(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_leftAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name leftAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index leftAnchor on a nil value");
    }
    luaObject.leftAnchor = (UIRect.AnchorPoint) LuaScriptMgr.GetNetObject(L, 3, typeof (UIRect.AnchorPoint));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rightAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rightAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index rightAnchor on a nil value");
    }
    luaObject.rightAnchor = (UIRect.AnchorPoint) LuaScriptMgr.GetNetObject(L, 3, typeof (UIRect.AnchorPoint));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bottomAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bottomAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index bottomAnchor on a nil value");
    }
    luaObject.bottomAnchor = (UIRect.AnchorPoint) LuaScriptMgr.GetNetObject(L, 3, typeof (UIRect.AnchorPoint));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_topAnchor(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name topAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index topAnchor on a nil value");
    }
    luaObject.topAnchor = (UIRect.AnchorPoint) LuaScriptMgr.GetNetObject(L, 3, typeof (UIRect.AnchorPoint));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_updateAnchors(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateAnchors");
      else
        LuaDLL.luaL_error(L, "attempt to index updateAnchors on a nil value");
    }
    luaObject.updateAnchors = (UIRect.AnchorUpdate) LuaScriptMgr.GetNetObject(L, 3, typeof (UIRect.AnchorUpdate));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_finalAlpha(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name finalAlpha");
      else
        LuaDLL.luaL_error(L, "attempt to index finalAlpha on a nil value");
    }
    luaObject.finalAlpha = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_alpha(IntPtr L)
  {
    UIRect luaObject = (UIRect) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int CalculateFinalAlpha(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    float finalAlpha = ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).CalculateFinalAlpha((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, finalAlpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Invalidate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).Invalidate(LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSides(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3[] sides = ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).GetSides((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.PushArray(L, (Array) sides);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Update(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).Update();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateAnchors(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).UpdateAnchors();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetAnchor(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UIRect), typeof (GameObject)))
    {
      ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).SetAnchor((GameObject) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UIRect), typeof (Transform)))
    {
      ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).SetAnchor((Transform) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    if (num == 6)
    {
      ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).SetAnchor((GameObject) LuaScriptMgr.GetUnityObject(L, 2, typeof (GameObject)), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: UIRect.SetAnchor");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetAnchors(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).ResetAnchors();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ParentHasChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIRect) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect")).ParentHasChanged();
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
