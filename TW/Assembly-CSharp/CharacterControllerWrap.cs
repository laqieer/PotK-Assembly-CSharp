// Decompiled with JetBrains decompiler
// Type: CharacterControllerWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class CharacterControllerWrap
{
  private static System.Type classType = typeof (CharacterController);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("SimpleMove", new LuaCSFunction(CharacterControllerWrap.SimpleMove)),
      new LuaMethod("Move", new LuaCSFunction(CharacterControllerWrap.Move)),
      new LuaMethod("New", new LuaCSFunction(CharacterControllerWrap._CreateCharacterController)),
      new LuaMethod("GetClassType", new LuaCSFunction(CharacterControllerWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(CharacterControllerWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[10]
    {
      new LuaField("isGrounded", new LuaCSFunction(CharacterControllerWrap.get_isGrounded), (LuaCSFunction) null),
      new LuaField("velocity", new LuaCSFunction(CharacterControllerWrap.get_velocity), (LuaCSFunction) null),
      new LuaField("collisionFlags", new LuaCSFunction(CharacterControllerWrap.get_collisionFlags), (LuaCSFunction) null),
      new LuaField("radius", new LuaCSFunction(CharacterControllerWrap.get_radius), new LuaCSFunction(CharacterControllerWrap.set_radius)),
      new LuaField("height", new LuaCSFunction(CharacterControllerWrap.get_height), new LuaCSFunction(CharacterControllerWrap.set_height)),
      new LuaField("center", new LuaCSFunction(CharacterControllerWrap.get_center), new LuaCSFunction(CharacterControllerWrap.set_center)),
      new LuaField("slopeLimit", new LuaCSFunction(CharacterControllerWrap.get_slopeLimit), new LuaCSFunction(CharacterControllerWrap.set_slopeLimit)),
      new LuaField("stepOffset", new LuaCSFunction(CharacterControllerWrap.get_stepOffset), new LuaCSFunction(CharacterControllerWrap.set_stepOffset)),
      new LuaField("skinWidth", new LuaCSFunction(CharacterControllerWrap.get_skinWidth), new LuaCSFunction(CharacterControllerWrap.set_skinWidth)),
      new LuaField("detectCollisions", new LuaCSFunction(CharacterControllerWrap.get_detectCollisions), new LuaCSFunction(CharacterControllerWrap.set_detectCollisions))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.CharacterController", typeof (CharacterController), regs, fields, typeof (Collider));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateCharacterController(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      CharacterController characterController = new CharacterController();
      LuaScriptMgr.Push(L, (Object) characterController);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: CharacterController.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, CharacterControllerWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isGrounded(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isGrounded");
      else
        LuaDLL.luaL_error(L, "attempt to index isGrounded on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isGrounded);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_velocity(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name velocity");
      else
        LuaDLL.luaL_error(L, "attempt to index velocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.velocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_collisionFlags(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name collisionFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index collisionFlags on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.collisionFlags);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_radius(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name radius");
      else
        LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.radius);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_height(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_center(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name center");
      else
        LuaDLL.luaL_error(L, "attempt to index center on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.center);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_slopeLimit(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name slopeLimit");
      else
        LuaDLL.luaL_error(L, "attempt to index slopeLimit on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.slopeLimit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stepOffset(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stepOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index stepOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.stepOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_skinWidth(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name skinWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index skinWidth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.skinWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_detectCollisions(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name detectCollisions");
      else
        LuaDLL.luaL_error(L, "attempt to index detectCollisions on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.detectCollisions);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_radius(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name radius");
      else
        LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
    }
    luaObject.radius = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_height(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name height");
      else
        LuaDLL.luaL_error(L, "attempt to index height on a nil value");
    }
    luaObject.height = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_center(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name center");
      else
        LuaDLL.luaL_error(L, "attempt to index center on a nil value");
    }
    luaObject.center = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_slopeLimit(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name slopeLimit");
      else
        LuaDLL.luaL_error(L, "attempt to index slopeLimit on a nil value");
    }
    luaObject.slopeLimit = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_stepOffset(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stepOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index stepOffset on a nil value");
    }
    luaObject.stepOffset = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_skinWidth(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name skinWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index skinWidth on a nil value");
    }
    luaObject.skinWidth = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_detectCollisions(IntPtr L)
  {
    CharacterController luaObject = (CharacterController) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name detectCollisions");
      else
        LuaDLL.luaL_error(L, "attempt to index detectCollisions on a nil value");
    }
    luaObject.detectCollisions = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SimpleMove(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((CharacterController) LuaScriptMgr.GetUnityObjectSelf(L, 1, "CharacterController")).SimpleMove(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Move(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    CollisionFlags e = ((CharacterController) LuaScriptMgr.GetUnityObjectSelf(L, 1, "CharacterController")).Move(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, (Enum) (object) e);
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
