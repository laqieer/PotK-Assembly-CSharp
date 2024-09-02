// Decompiled with JetBrains decompiler
// Type: ComponentWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ComponentWrap
{
  private static System.Type classType = typeof (Component);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[13]
    {
      new LuaMethod("GetComponent", new LuaCSFunction(ComponentWrap.GetComponent)),
      new LuaMethod("GetComponentInChildren", new LuaCSFunction(ComponentWrap.GetComponentInChildren)),
      new LuaMethod("GetComponentsInChildren", new LuaCSFunction(ComponentWrap.GetComponentsInChildren)),
      new LuaMethod("GetComponentInParent", new LuaCSFunction(ComponentWrap.GetComponentInParent)),
      new LuaMethod("GetComponentsInParent", new LuaCSFunction(ComponentWrap.GetComponentsInParent)),
      new LuaMethod("GetComponents", new LuaCSFunction(ComponentWrap.GetComponents)),
      new LuaMethod("CompareTag", new LuaCSFunction(ComponentWrap.CompareTag)),
      new LuaMethod("SendMessageUpwards", new LuaCSFunction(ComponentWrap.SendMessageUpwards)),
      new LuaMethod("SendMessage", new LuaCSFunction(ComponentWrap.SendMessage)),
      new LuaMethod("BroadcastMessage", new LuaCSFunction(ComponentWrap.BroadcastMessage)),
      new LuaMethod("New", new LuaCSFunction(ComponentWrap._CreateComponent)),
      new LuaMethod("GetClassType", new LuaCSFunction(ComponentWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(ComponentWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[3]
    {
      new LuaField("transform", new LuaCSFunction(ComponentWrap.get_transform), (LuaCSFunction) null),
      new LuaField("gameObject", new LuaCSFunction(ComponentWrap.get_gameObject), (LuaCSFunction) null),
      new LuaField("tag", new LuaCSFunction(ComponentWrap.get_tag), new LuaCSFunction(ComponentWrap.set_tag))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Component", typeof (Component), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateComponent(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Component component = new Component();
      LuaScriptMgr.Push(L, (Object) component);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Component.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ComponentWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_transform(IntPtr L)
  {
    Component luaObject = (Component) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name transform");
      else
        LuaDLL.luaL_error(L, "attempt to index transform on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.transform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gameObject(IntPtr L)
  {
    Component luaObject = (Component) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gameObject");
      else
        LuaDLL.luaL_error(L, "attempt to index gameObject on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.gameObject);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_tag(IntPtr L)
  {
    Component luaObject = (Component) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name tag");
      else
        LuaDLL.luaL_error(L, "attempt to index tag on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.tag);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_tag(IntPtr L)
  {
    Component luaObject = (Component) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name tag");
      else
        LuaDLL.luaL_error(L, "attempt to index tag on a nil value");
    }
    luaObject.tag = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponent(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string)))
    {
      Component component = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponent(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, (Object) component);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (System.Type)))
    {
      Component component = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponent(LuaScriptMgr.GetTypeObject(L, 2));
      LuaScriptMgr.Push(L, (Object) component);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponent");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentInChildren(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component componentInChildren1 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentInChildren(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.Push(L, (Object) componentInChildren1);
        return 1;
      case 3:
        Component componentInChildren2 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentInChildren(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.Push(L, (Object) componentInChildren2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponentInChildren");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentsInChildren(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] componentsInChildren1 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentsInChildren(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) componentsInChildren1);
        return 1;
      case 3:
        Component[] componentsInChildren2 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentsInChildren(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.PushArray(L, (Array) componentsInChildren2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponentsInChildren");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentInParent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Component componentInParent = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentInParent(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.Push(L, (Object) componentInParent);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentsInParent(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] componentsInParent1 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentsInParent(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) componentsInParent1);
        return 1;
      case 3:
        Component[] componentsInParent2 = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponentsInParent(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.PushArray(L, (Array) componentsInParent2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponentsInParent");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponents(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] components = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponents(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) components);
        return 1;
      case 3:
        ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).GetComponents(LuaScriptMgr.GetTypeObject(L, 2), (List<Component>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<Component>)));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponents");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CompareTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).CompareTag(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SendMessageUpwards(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessageUpwards(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (SendMessageOptions)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessageUpwards(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (object)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessageUpwards(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessageUpwards(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Component.SendMessageUpwards");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SendMessage(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessage(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (SendMessageOptions)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessage(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (object)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessage(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).SendMessage(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Component.SendMessage");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BroadcastMessage(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).BroadcastMessage(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (SendMessageOptions)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).BroadcastMessage(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Component), typeof (string), typeof (object)))
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).BroadcastMessage(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((Component) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Component")).BroadcastMessage(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Component.BroadcastMessage");
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
