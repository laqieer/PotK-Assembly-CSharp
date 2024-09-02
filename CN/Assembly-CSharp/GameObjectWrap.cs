// Decompiled with JetBrains decompiler
// Type: GameObjectWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GameObjectWrap
{
  private static System.Type classType = typeof (GameObject);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[20]
    {
      new LuaMethod("CreatePrimitive", new LuaCSFunction(GameObjectWrap.CreatePrimitive)),
      new LuaMethod("GetComponent", new LuaCSFunction(GameObjectWrap.GetComponent)),
      new LuaMethod("GetComponentInChildren", new LuaCSFunction(GameObjectWrap.GetComponentInChildren)),
      new LuaMethod("GetComponentInParent", new LuaCSFunction(GameObjectWrap.GetComponentInParent)),
      new LuaMethod("GetComponents", new LuaCSFunction(GameObjectWrap.GetComponents)),
      new LuaMethod("GetComponentsInChildren", new LuaCSFunction(GameObjectWrap.GetComponentsInChildren)),
      new LuaMethod("GetComponentsInParent", new LuaCSFunction(GameObjectWrap.GetComponentsInParent)),
      new LuaMethod("SetActive", new LuaCSFunction(GameObjectWrap.SetActive)),
      new LuaMethod("CompareTag", new LuaCSFunction(GameObjectWrap.CompareTag)),
      new LuaMethod("FindGameObjectWithTag", new LuaCSFunction(GameObjectWrap.FindGameObjectWithTag)),
      new LuaMethod("FindWithTag", new LuaCSFunction(GameObjectWrap.FindWithTag)),
      new LuaMethod("FindGameObjectsWithTag", new LuaCSFunction(GameObjectWrap.FindGameObjectsWithTag)),
      new LuaMethod("SendMessageUpwards", new LuaCSFunction(GameObjectWrap.SendMessageUpwards)),
      new LuaMethod("SendMessage", new LuaCSFunction(GameObjectWrap.SendMessage)),
      new LuaMethod("BroadcastMessage", new LuaCSFunction(GameObjectWrap.BroadcastMessage)),
      new LuaMethod("AddComponent", new LuaCSFunction(GameObjectWrap.AddComponent)),
      new LuaMethod("Find", new LuaCSFunction(GameObjectWrap.Find)),
      new LuaMethod("New", new LuaCSFunction(GameObjectWrap._CreateGameObject)),
      new LuaMethod("GetClassType", new LuaCSFunction(GameObjectWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(GameObjectWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[8]
    {
      new LuaField("transform", new LuaCSFunction(GameObjectWrap.get_transform), (LuaCSFunction) null),
      new LuaField("layer", new LuaCSFunction(GameObjectWrap.get_layer), new LuaCSFunction(GameObjectWrap.set_layer)),
      new LuaField("activeSelf", new LuaCSFunction(GameObjectWrap.get_activeSelf), (LuaCSFunction) null),
      new LuaField("activeInHierarchy", new LuaCSFunction(GameObjectWrap.get_activeInHierarchy), (LuaCSFunction) null),
      new LuaField("isStatic", new LuaCSFunction(GameObjectWrap.get_isStatic), new LuaCSFunction(GameObjectWrap.set_isStatic)),
      new LuaField("tag", new LuaCSFunction(GameObjectWrap.get_tag), new LuaCSFunction(GameObjectWrap.set_tag)),
      new LuaField("scene", new LuaCSFunction(GameObjectWrap.get_scene), (LuaCSFunction) null),
      new LuaField("gameObject", new LuaCSFunction(GameObjectWrap.get_gameObject), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.GameObject", typeof (GameObject), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateGameObject(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    switch (num)
    {
      case 0:
        GameObject gameObject1 = new GameObject();
        LuaScriptMgr.Push(L, (Object) gameObject1);
        return 1;
      case 1:
        GameObject gameObject2 = new GameObject(LuaScriptMgr.GetString(L, 1));
        LuaScriptMgr.Push(L, (Object) gameObject2);
        return 1;
      default:
        if (LuaScriptMgr.CheckTypes(L, 1, typeof (string)) && LuaScriptMgr.CheckParamsType(L, typeof (System.Type), 2, num - 1))
        {
          GameObject gameObject3 = new GameObject(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetParamsObject<System.Type>(L, 2, num - 1));
          LuaScriptMgr.Push(L, (Object) gameObject3);
          return 1;
        }
        LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.New");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, GameObjectWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_transform(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_layer(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layer");
      else
        LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.layer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeSelf(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeSelf");
      else
        LuaDLL.luaL_error(L, "attempt to index activeSelf on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.activeSelf);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeInHierarchy(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeInHierarchy");
      else
        LuaDLL.luaL_error(L, "attempt to index activeInHierarchy on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.activeInHierarchy);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isStatic(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isStatic");
      else
        LuaDLL.luaL_error(L, "attempt to index isStatic on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isStatic);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_tag(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_scene(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name scene");
      else
        LuaDLL.luaL_error(L, "attempt to index scene on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.scene);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gameObject(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_layer(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layer");
      else
        LuaDLL.luaL_error(L, "attempt to index layer on a nil value");
    }
    luaObject.layer = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_isStatic(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isStatic");
      else
        LuaDLL.luaL_error(L, "attempt to index isStatic on a nil value");
    }
    luaObject.isStatic = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_tag(IntPtr L)
  {
    GameObject luaObject = (GameObject) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int CreatePrimitive(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject primitive = GameObject.CreatePrimitive((PrimitiveType) (int) LuaScriptMgr.GetNetObject(L, 1, typeof (PrimitiveType)));
    LuaScriptMgr.Push(L, (Object) primitive);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponent(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string)))
    {
      Component component = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponent(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, (Object) component);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (System.Type)))
    {
      Component component = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponent(LuaScriptMgr.GetTypeObject(L, 2));
      LuaScriptMgr.Push(L, (Object) component);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponent");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentInChildren(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component componentInChildren1 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentInChildren(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.Push(L, (Object) componentInChildren1);
        return 1;
      case 3:
        Component componentInChildren2 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentInChildren(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.Push(L, (Object) componentInChildren2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponentInChildren");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentInParent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Component componentInParent = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentInParent(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.Push(L, (Object) componentInParent);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponents(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] components = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponents(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) components);
        return 1;
      case 3:
        ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponents(LuaScriptMgr.GetTypeObject(L, 2), (List<Component>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<Component>)));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponents");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentsInChildren(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] componentsInChildren1 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentsInChildren(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) componentsInChildren1);
        return 1;
      case 3:
        Component[] componentsInChildren2 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentsInChildren(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.PushArray(L, (Array) componentsInChildren2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponentsInChildren");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetComponentsInParent(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Component[] componentsInParent1 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentsInParent(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) componentsInParent1);
        return 1;
      case 3:
        Component[] componentsInParent2 = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).GetComponentsInParent(LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.PushArray(L, (Array) componentsInParent2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.GetComponentsInParent");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetActive(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SetActive(LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CompareTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).CompareTag(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindGameObjectWithTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, (Object) gameObjectWithTag);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindWithTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject withTag = GameObject.FindWithTag(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, (Object) withTag);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindGameObjectsWithTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.PushArray(L, (Array) gameObjectsWithTag);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SendMessageUpwards(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessageUpwards(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (SendMessageOptions)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessageUpwards(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (object)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessageUpwards(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessageUpwards(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.SendMessageUpwards");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SendMessage(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessage(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (SendMessageOptions)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessage(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (object)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessage(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).SendMessage(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.SendMessage");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BroadcastMessage(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).BroadcastMessage(LuaScriptMgr.GetLuaString(L, 2));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (SendMessageOptions)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).BroadcastMessage(LuaScriptMgr.GetString(L, 2), (SendMessageOptions) (int) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (string), typeof (object)))
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).BroadcastMessage(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      return 0;
    }
    if (num == 4)
    {
      ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).BroadcastMessage(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVarObject(L, 3), (SendMessageOptions) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (SendMessageOptions)));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: GameObject.BroadcastMessage");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddComponent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Component component = ((GameObject) LuaScriptMgr.GetUnityObjectSelf(L, 1, "GameObject")).AddComponent(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.Push(L, (Object) component);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Find(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject gameObject = GameObject.Find(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, (Object) gameObject);
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
