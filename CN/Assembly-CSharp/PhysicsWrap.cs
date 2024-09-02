// Decompiled with JetBrains decompiler
// Type: PhysicsWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class PhysicsWrap
{
  private static System.Type classType = typeof (Physics);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[25]
    {
      new LuaMethod("Raycast", new LuaCSFunction(PhysicsWrap.Raycast)),
      new LuaMethod("RaycastAll", new LuaCSFunction(PhysicsWrap.RaycastAll)),
      new LuaMethod("RaycastNonAlloc", new LuaCSFunction(PhysicsWrap.RaycastNonAlloc)),
      new LuaMethod("Linecast", new LuaCSFunction(PhysicsWrap.Linecast)),
      new LuaMethod("OverlapSphere", new LuaCSFunction(PhysicsWrap.OverlapSphere)),
      new LuaMethod("OverlapSphereNonAlloc", new LuaCSFunction(PhysicsWrap.OverlapSphereNonAlloc)),
      new LuaMethod("CapsuleCast", new LuaCSFunction(PhysicsWrap.CapsuleCast)),
      new LuaMethod("SphereCast", new LuaCSFunction(PhysicsWrap.SphereCast)),
      new LuaMethod("CapsuleCastAll", new LuaCSFunction(PhysicsWrap.CapsuleCastAll)),
      new LuaMethod("CapsuleCastNonAlloc", new LuaCSFunction(PhysicsWrap.CapsuleCastNonAlloc)),
      new LuaMethod("SphereCastAll", new LuaCSFunction(PhysicsWrap.SphereCastAll)),
      new LuaMethod("SphereCastNonAlloc", new LuaCSFunction(PhysicsWrap.SphereCastNonAlloc)),
      new LuaMethod("CheckSphere", new LuaCSFunction(PhysicsWrap.CheckSphere)),
      new LuaMethod("CheckCapsule", new LuaCSFunction(PhysicsWrap.CheckCapsule)),
      new LuaMethod("CheckBox", new LuaCSFunction(PhysicsWrap.CheckBox)),
      new LuaMethod("OverlapBox", new LuaCSFunction(PhysicsWrap.OverlapBox)),
      new LuaMethod("OverlapBoxNonAlloc", new LuaCSFunction(PhysicsWrap.OverlapBoxNonAlloc)),
      new LuaMethod("BoxCastAll", new LuaCSFunction(PhysicsWrap.BoxCastAll)),
      new LuaMethod("BoxCastNonAlloc", new LuaCSFunction(PhysicsWrap.BoxCastNonAlloc)),
      new LuaMethod("BoxCast", new LuaCSFunction(PhysicsWrap.BoxCast)),
      new LuaMethod("IgnoreCollision", new LuaCSFunction(PhysicsWrap.IgnoreCollision)),
      new LuaMethod("IgnoreLayerCollision", new LuaCSFunction(PhysicsWrap.IgnoreLayerCollision)),
      new LuaMethod("GetIgnoreLayerCollision", new LuaCSFunction(PhysicsWrap.GetIgnoreLayerCollision)),
      new LuaMethod("New", new LuaCSFunction(PhysicsWrap._CreatePhysics)),
      new LuaMethod("GetClassType", new LuaCSFunction(PhysicsWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[9]
    {
      new LuaField("IgnoreRaycastLayer", new LuaCSFunction(PhysicsWrap.get_IgnoreRaycastLayer), (LuaCSFunction) null),
      new LuaField("DefaultRaycastLayers", new LuaCSFunction(PhysicsWrap.get_DefaultRaycastLayers), (LuaCSFunction) null),
      new LuaField("AllLayers", new LuaCSFunction(PhysicsWrap.get_AllLayers), (LuaCSFunction) null),
      new LuaField("gravity", new LuaCSFunction(PhysicsWrap.get_gravity), new LuaCSFunction(PhysicsWrap.set_gravity)),
      new LuaField("defaultContactOffset", new LuaCSFunction(PhysicsWrap.get_defaultContactOffset), new LuaCSFunction(PhysicsWrap.set_defaultContactOffset)),
      new LuaField("bounceThreshold", new LuaCSFunction(PhysicsWrap.get_bounceThreshold), new LuaCSFunction(PhysicsWrap.set_bounceThreshold)),
      new LuaField("solverIterationCount", new LuaCSFunction(PhysicsWrap.get_solverIterationCount), new LuaCSFunction(PhysicsWrap.set_solverIterationCount)),
      new LuaField("sleepThreshold", new LuaCSFunction(PhysicsWrap.get_sleepThreshold), new LuaCSFunction(PhysicsWrap.set_sleepThreshold)),
      new LuaField("queriesHitTriggers", new LuaCSFunction(PhysicsWrap.get_queriesHitTriggers), new LuaCSFunction(PhysicsWrap.set_queriesHitTriggers))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Physics", typeof (Physics), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreatePhysics(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Physics o = new Physics();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, PhysicsWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IgnoreRaycastLayer(IntPtr L)
  {
    LuaScriptMgr.Push(L, 4);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_DefaultRaycastLayers(IntPtr L)
  {
    LuaScriptMgr.Push(L, -5);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_AllLayers(IntPtr L)
  {
    LuaScriptMgr.Push(L, -1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gravity(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.gravity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_defaultContactOffset(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.defaultContactOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bounceThreshold(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.bounceThreshold);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_solverIterationCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.solverIterationCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sleepThreshold(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.sleepThreshold);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_queriesHitTriggers(IntPtr L)
  {
    LuaScriptMgr.Push(L, Physics.queriesHitTriggers);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_gravity(IntPtr L)
  {
    Physics.gravity = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_defaultContactOffset(IntPtr L)
  {
    Physics.defaultContactOffset = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bounceThreshold(IntPtr L)
  {
    Physics.bounceThreshold = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_solverIterationCount(IntPtr L)
  {
    Physics.solverIterationCount = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sleepThreshold(IntPtr L)
  {
    Physics.sleepThreshold = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_queriesHitTriggers(IntPtr L)
  {
    Physics.queriesHitTriggers = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Raycast(IntPtr L)
  {
    int num1 = LuaDLL.lua_gettop(L);
    if (num1 == 1)
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetRay(L, 1));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.Raycast(LuaScriptMgr.GetRay(L, 1), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (int)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.Raycast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), (System.Type) null, typeof (float)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num2 = (float) LuaDLL.lua_tonumber(L, 3);
      RaycastHit hit;
      bool b = Physics.Raycast(ray, ref hit, num2);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (int)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (float)))
    {
      Vector3 vector3_1 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_2 = LuaScriptMgr.GetVector3(L, 2);
      float num3 = (float) LuaDLL.lua_tonumber(L, 4);
      RaycastHit hit;
      bool b = Physics.Raycast(vector3_1, vector3_2, ref hit, num3);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), (System.Type) null, typeof (float), typeof (int)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num4 = (float) LuaDLL.lua_tonumber(L, 3);
      int num5 = (int) LuaDLL.lua_tonumber(L, 4);
      RaycastHit hit;
      bool b = Physics.Raycast(ray, ref hit, num4, num5);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.Raycast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 5));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (float), typeof (int)))
    {
      Vector3 vector3_3 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_4 = LuaScriptMgr.GetVector3(L, 2);
      float num6 = (float) LuaDLL.lua_tonumber(L, 4);
      int num7 = (int) LuaDLL.lua_tonumber(L, 5);
      RaycastHit hit;
      bool b = Physics.Raycast(vector3_3, vector3_4, ref hit, num6, num7);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), (System.Type) null, typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num8 = (float) LuaDLL.lua_tonumber(L, 3);
      int num9 = (int) LuaDLL.lua_tonumber(L, 4);
      QueryTriggerInteraction luaObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 5);
      RaycastHit hit;
      bool b = Physics.Raycast(ray, ref hit, num8, num9, luaObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6)
    {
      Vector3 vector3_5 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_6 = LuaScriptMgr.GetVector3(L, 2);
      float number1 = (float) LuaScriptMgr.GetNumber(L, 4);
      int number2 = (int) LuaScriptMgr.GetNumber(L, 5);
      QueryTriggerInteraction netObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 6, typeof (QueryTriggerInteraction));
      RaycastHit hit;
      bool b = Physics.Raycast(vector3_5, vector3_6, ref hit, number1, number2, netObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Raycast");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RaycastAll(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetRay(L, 1));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (int)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (int)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 5)
    {
      RaycastHit[] o = Physics.RaycastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction)));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.RaycastAll");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RaycastNonAlloc(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetRay(L, 1), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (RaycastHit[])))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (RaycastHit[]), typeof (float)))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetRay(L, 1), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (RaycastHit[]), typeof (float)))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (RaycastHit[]), typeof (float), typeof (int)))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetRay(L, 1), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (RaycastHit[]), typeof (float), typeof (int)))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (RaycastHit[]), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetRay(L, 1), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 5));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 6)
    {
      int d = Physics.RaycastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 6, typeof (QueryTriggerInteraction)));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.RaycastNonAlloc");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Linecast(IntPtr L)
  {
    int num1 = LuaDLL.lua_gettop(L);
    if (num1 == 2)
    {
      bool b = Physics.Linecast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.Linecast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (int)))
    {
      bool b = Physics.Linecast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (int)))
    {
      Vector3 vector3_1 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_2 = LuaScriptMgr.GetVector3(L, 2);
      int num2 = (int) LuaDLL.lua_tonumber(L, 4);
      RaycastHit hit;
      bool b = Physics.Linecast(vector3_1, vector3_2, ref hit, num2);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.Linecast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5)
    {
      Vector3 vector3_3 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_4 = LuaScriptMgr.GetVector3(L, 2);
      int number = (int) LuaScriptMgr.GetNumber(L, 4);
      QueryTriggerInteraction netObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction));
      RaycastHit hit;
      bool b = Physics.Linecast(vector3_3, vector3_4, ref hit, number, netObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Linecast");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OverlapSphere(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Collider[] o1 = Physics.OverlapSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 3:
        Collider[] o2 = Physics.OverlapSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      case 4:
        Collider[] o3 = Physics.OverlapSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.PushArray(L, (Array) o3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapSphere");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OverlapSphereNonAlloc(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        int d1 = Physics.OverlapSphereNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 4:
        int d2 = Physics.OverlapSphereNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 5:
        int d3 = Physics.OverlapSphereNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, d3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapSphereNonAlloc");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CapsuleCast(IntPtr L)
  {
    int num1 = LuaDLL.lua_gettop(L);
    if (num1 == 4)
    {
      bool b = Physics.CapsuleCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.CapsuleCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), LuaScriptMgr.GetVector3(L, 4), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (float)))
    {
      bool b = Physics.CapsuleCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null, typeof (float)))
    {
      Vector3 vector3_1 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_2 = LuaScriptMgr.GetVector3(L, 2);
      float num2 = (float) LuaDLL.lua_tonumber(L, 3);
      Vector3 vector3_3 = LuaScriptMgr.GetVector3(L, 4);
      float num3 = (float) LuaDLL.lua_tonumber(L, 6);
      RaycastHit hit;
      bool b = Physics.CapsuleCast(vector3_1, vector3_2, num2, vector3_3, ref hit, num3);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (float), typeof (int)))
    {
      bool b = Physics.CapsuleCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaDLL.lua_tonumber(L, 5), (int) LuaDLL.lua_tonumber(L, 6));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.CapsuleCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaDLL.lua_tonumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaDLL.lua_tonumber(L, 5), (int) LuaDLL.lua_tonumber(L, 6), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 7));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null, typeof (float), typeof (int)))
    {
      Vector3 vector3_4 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_5 = LuaScriptMgr.GetVector3(L, 2);
      float num4 = (float) LuaDLL.lua_tonumber(L, 3);
      Vector3 vector3_6 = LuaScriptMgr.GetVector3(L, 4);
      float num5 = (float) LuaDLL.lua_tonumber(L, 6);
      int num6 = (int) LuaDLL.lua_tonumber(L, 7);
      RaycastHit hit;
      bool b = Physics.CapsuleCast(vector3_4, vector3_5, num4, vector3_6, ref hit, num5, num6);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 8)
    {
      Vector3 vector3_7 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_8 = LuaScriptMgr.GetVector3(L, 2);
      float number1 = (float) LuaScriptMgr.GetNumber(L, 3);
      Vector3 vector3_9 = LuaScriptMgr.GetVector3(L, 4);
      float number2 = (float) LuaScriptMgr.GetNumber(L, 6);
      int number3 = (int) LuaScriptMgr.GetNumber(L, 7);
      QueryTriggerInteraction netObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 8, typeof (QueryTriggerInteraction));
      RaycastHit hit;
      bool b = Physics.CapsuleCast(vector3_7, vector3_8, number1, vector3_9, ref hit, number2, number3, netObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCast");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SphereCast(IntPtr L)
  {
    int num1 = LuaDLL.lua_gettop(L);
    if (num1 == 2)
    {
      bool b = Physics.SphereCast(LuaScriptMgr.GetRay(L, 1), (float) LuaScriptMgr.GetNumber(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float)))
    {
      bool b = Physics.SphereCast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.SphereCast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.SphereCast(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float), typeof (int)))
    {
      bool b = Physics.SphereCast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), (System.Type) null, typeof (float)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num2 = (float) LuaDLL.lua_tonumber(L, 2);
      float num3 = (float) LuaDLL.lua_tonumber(L, 4);
      RaycastHit hit;
      bool b = Physics.SphereCast(ray, num2, ref hit, num3);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), (System.Type) null, typeof (float), typeof (int)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num4 = (float) LuaDLL.lua_tonumber(L, 2);
      float num5 = (float) LuaDLL.lua_tonumber(L, 4);
      int num6 = (int) LuaDLL.lua_tonumber(L, 5);
      RaycastHit hit;
      bool b = Physics.SphereCast(ray, num4, ref hit, num5, num6);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.SphereCast(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 5));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null, typeof (float)))
    {
      Vector3 vector3_1 = LuaScriptMgr.GetVector3(L, 1);
      float num7 = (float) LuaDLL.lua_tonumber(L, 2);
      Vector3 vector3_2 = LuaScriptMgr.GetVector3(L, 3);
      float num8 = (float) LuaDLL.lua_tonumber(L, 5);
      RaycastHit hit;
      bool b = Physics.SphereCast(vector3_1, num7, vector3_2, ref hit, num8);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), (System.Type) null, typeof (float), typeof (int)))
    {
      Vector3 vector3_3 = LuaScriptMgr.GetVector3(L, 1);
      float num9 = (float) LuaDLL.lua_tonumber(L, 2);
      Vector3 vector3_4 = LuaScriptMgr.GetVector3(L, 3);
      float num10 = (float) LuaDLL.lua_tonumber(L, 5);
      int num11 = (int) LuaDLL.lua_tonumber(L, 6);
      RaycastHit hit;
      bool b = Physics.SphereCast(vector3_3, num9, vector3_4, ref hit, num10, num11);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), (System.Type) null, typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      Ray ray = LuaScriptMgr.GetRay(L, 1);
      float num12 = (float) LuaDLL.lua_tonumber(L, 2);
      float num13 = (float) LuaDLL.lua_tonumber(L, 4);
      int num14 = (int) LuaDLL.lua_tonumber(L, 5);
      QueryTriggerInteraction luaObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 6);
      RaycastHit hit;
      bool b = Physics.SphereCast(ray, num12, ref hit, num13, num14, luaObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 7)
    {
      Vector3 vector3_5 = LuaScriptMgr.GetVector3(L, 1);
      float number1 = (float) LuaScriptMgr.GetNumber(L, 2);
      Vector3 vector3_6 = LuaScriptMgr.GetVector3(L, 3);
      float number2 = (float) LuaScriptMgr.GetNumber(L, 5);
      int number3 = (int) LuaScriptMgr.GetNumber(L, 6);
      QueryTriggerInteraction netObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 7, typeof (QueryTriggerInteraction));
      RaycastHit hit;
      bool b = Physics.SphereCast(vector3_5, number1, vector3_6, ref hit, number2, number3, netObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCast");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CapsuleCastAll(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 4:
        RaycastHit[] o1 = Physics.CapsuleCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4));
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 5:
        RaycastHit[] o2 = Physics.CapsuleCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaScriptMgr.GetNumber(L, 5));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      case 6:
        RaycastHit[] o3 = Physics.CapsuleCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6));
        LuaScriptMgr.PushArray(L, (Array) o3);
        return 1;
      case 7:
        RaycastHit[] o4 = Physics.CapsuleCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 7, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.PushArray(L, (Array) o4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCastAll");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CapsuleCastNonAlloc(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 5:
        int d1 = Physics.CapsuleCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 5));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 6:
        int d2 = Physics.CapsuleCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 5), (float) LuaScriptMgr.GetNumber(L, 6));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 7:
        int d3 = Physics.CapsuleCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 5), (float) LuaScriptMgr.GetNumber(L, 6), (int) LuaScriptMgr.GetNumber(L, 7));
        LuaScriptMgr.Push(L, d3);
        return 1;
      case 8:
        int d4 = Physics.CapsuleCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), LuaScriptMgr.GetVector3(L, 4), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 5), (float) LuaScriptMgr.GetNumber(L, 6), (int) LuaScriptMgr.GetNumber(L, 7), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 8, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, d4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCastNonAlloc");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SphereCastAll(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaScriptMgr.GetNumber(L, 2));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float), typeof (int)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (float)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (float), typeof (int)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 5));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 6)
    {
      RaycastHit[] o = Physics.SphereCastAll(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetVector3(L, 3), (float) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 6, typeof (QueryTriggerInteraction)));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCastAll");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SphereCastNonAlloc(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3)
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetRay(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (RaycastHit[]), typeof (float)))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (RaycastHit[])))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (RaycastHit[]), typeof (float), typeof (int)))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (RaycastHit[]), typeof (float)))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), (float) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (LuaTable), typeof (RaycastHit[]), typeof (float), typeof (int)))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), (float) LuaDLL.lua_tonumber(L, 5), (int) LuaDLL.lua_tonumber(L, 6));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (float), typeof (RaycastHit[]), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetRay(L, 1), (float) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 3), (float) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 6));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 7)
    {
      int d = Physics.SphereCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 7, typeof (QueryTriggerInteraction)));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCastNonAlloc");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckSphere(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        bool b1 = Physics.CheckSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 3:
        bool b2 = Physics.CheckSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, b2);
        return 1;
      case 4:
        bool b3 = Physics.CheckSphere(LuaScriptMgr.GetVector3(L, 1), (float) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, b3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckSphere");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckCapsule(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        bool b1 = Physics.CheckCapsule(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 4:
        bool b2 = Physics.CheckCapsule(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, b2);
        return 1;
      case 5:
        bool b3 = Physics.CheckCapsule(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, b3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckCapsule");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckBox(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        bool b1 = Physics.CheckBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 3:
        bool b2 = Physics.CheckBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3));
        LuaScriptMgr.Push(L, b2);
        return 1;
      case 4:
        bool b3 = Physics.CheckBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, b3);
        return 1;
      case 5:
        bool b4 = Physics.CheckBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, b4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckBox");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OverlapBox(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Collider[] o1 = Physics.OverlapBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2));
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 3:
        Collider[] o2 = Physics.OverlapBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      case 4:
        Collider[] o3 = Physics.OverlapBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.PushArray(L, (Array) o3);
        return 1;
      case 5:
        Collider[] o4 = Physics.OverlapBox(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.PushArray(L, (Array) o4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapBox");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OverlapBoxNonAlloc(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        int d1 = Physics.OverlapBoxNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 4:
        int d2 = Physics.OverlapBoxNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3), LuaScriptMgr.GetQuaternion(L, 4));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 5:
        int d3 = Physics.OverlapBoxNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (int) LuaScriptMgr.GetNumber(L, 5));
        LuaScriptMgr.Push(L, d3);
        return 1;
      case 6:
        int d4 = Physics.OverlapBoxNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetArrayObject<Collider>(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (int) LuaScriptMgr.GetNumber(L, 5), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 6, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, d4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapBoxNonAlloc");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BoxCastAll(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        RaycastHit[] o1 = Physics.BoxCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3));
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 4:
        RaycastHit[] o2 = Physics.BoxCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      case 5:
        RaycastHit[] o3 = Physics.BoxCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaScriptMgr.GetNumber(L, 5));
        LuaScriptMgr.PushArray(L, (Array) o3);
        return 1;
      case 6:
        RaycastHit[] o4 = Physics.BoxCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6));
        LuaScriptMgr.PushArray(L, (Array) o4);
        return 1;
      case 7:
        RaycastHit[] o5 = Physics.BoxCastAll(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaScriptMgr.GetNumber(L, 5), (int) LuaScriptMgr.GetNumber(L, 6), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 7, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.PushArray(L, (Array) o5);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.BoxCastAll");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BoxCastNonAlloc(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 4:
        int d1 = Physics.BoxCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 5:
        int d2 = Physics.BoxCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), LuaScriptMgr.GetQuaternion(L, 5));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 6:
        int d3 = Physics.BoxCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), LuaScriptMgr.GetQuaternion(L, 5), (float) LuaScriptMgr.GetNumber(L, 6));
        LuaScriptMgr.Push(L, d3);
        return 1;
      case 7:
        int d4 = Physics.BoxCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), LuaScriptMgr.GetQuaternion(L, 5), (float) LuaScriptMgr.GetNumber(L, 6), (int) LuaScriptMgr.GetNumber(L, 7));
        LuaScriptMgr.Push(L, d4);
        return 1;
      case 8:
        int d5 = Physics.BoxCastNonAlloc(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetArrayObject<RaycastHit>(L, 4), LuaScriptMgr.GetQuaternion(L, 5), (float) LuaScriptMgr.GetNumber(L, 6), (int) LuaScriptMgr.GetNumber(L, 7), (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 8, typeof (QueryTriggerInteraction)));
        LuaScriptMgr.Push(L, d5);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.BoxCastNonAlloc");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BoxCast(IntPtr L)
  {
    int num1 = LuaDLL.lua_gettop(L);
    if (num1 == 3)
    {
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), (System.Type) null))
    {
      RaycastHit hit;
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), ref hit);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (LuaTable)))
    {
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (float)))
    {
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaDLL.lua_tonumber(L, 5));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (LuaTable)))
    {
      Vector3 vector3_1 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_2 = LuaScriptMgr.GetVector3(L, 2);
      Vector3 vector3_3 = LuaScriptMgr.GetVector3(L, 3);
      Quaternion quaternion = LuaScriptMgr.GetQuaternion(L, 5);
      RaycastHit hit;
      bool b = Physics.BoxCast(vector3_1, vector3_2, vector3_3, ref hit, quaternion);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (LuaTable), typeof (float)))
    {
      Vector3 vector3_4 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_5 = LuaScriptMgr.GetVector3(L, 2);
      Vector3 vector3_6 = LuaScriptMgr.GetVector3(L, 3);
      Quaternion quaternion = LuaScriptMgr.GetQuaternion(L, 5);
      float num2 = (float) LuaDLL.lua_tonumber(L, 6);
      RaycastHit hit;
      bool b = Physics.BoxCast(vector3_4, vector3_5, vector3_6, ref hit, quaternion, num2);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (int)))
    {
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaDLL.lua_tonumber(L, 5), (int) LuaDLL.lua_tonumber(L, 6));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), typeof (float), typeof (int), typeof (QueryTriggerInteraction)))
    {
      bool b = Physics.BoxCast(LuaScriptMgr.GetVector3(L, 1), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetVector3(L, 3), LuaScriptMgr.GetQuaternion(L, 4), (float) LuaDLL.lua_tonumber(L, 5), (int) LuaDLL.lua_tonumber(L, 6), (QueryTriggerInteraction) (int) LuaScriptMgr.GetLuaObject(L, 7));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num1 == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (LuaTable), typeof (LuaTable), typeof (LuaTable), (System.Type) null, typeof (LuaTable), typeof (float), typeof (int)))
    {
      Vector3 vector3_7 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_8 = LuaScriptMgr.GetVector3(L, 2);
      Vector3 vector3_9 = LuaScriptMgr.GetVector3(L, 3);
      Quaternion quaternion = LuaScriptMgr.GetQuaternion(L, 5);
      float num3 = (float) LuaDLL.lua_tonumber(L, 6);
      int num4 = (int) LuaDLL.lua_tonumber(L, 7);
      RaycastHit hit;
      bool b = Physics.BoxCast(vector3_7, vector3_8, vector3_9, ref hit, quaternion, num3, num4);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    if (num1 == 8)
    {
      Vector3 vector3_10 = LuaScriptMgr.GetVector3(L, 1);
      Vector3 vector3_11 = LuaScriptMgr.GetVector3(L, 2);
      Vector3 vector3_12 = LuaScriptMgr.GetVector3(L, 3);
      Quaternion quaternion = LuaScriptMgr.GetQuaternion(L, 5);
      float number1 = (float) LuaScriptMgr.GetNumber(L, 6);
      int number2 = (int) LuaScriptMgr.GetNumber(L, 7);
      QueryTriggerInteraction netObject = (QueryTriggerInteraction) (int) LuaScriptMgr.GetNetObject(L, 8, typeof (QueryTriggerInteraction));
      RaycastHit hit;
      bool b = Physics.BoxCast(vector3_10, vector3_11, vector3_12, ref hit, quaternion, number1, number2, netObject);
      LuaScriptMgr.Push(L, b);
      LuaScriptMgr.Push(L, hit);
      return 2;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Physics.BoxCast");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IgnoreCollision(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Physics.IgnoreCollision((Collider) LuaScriptMgr.GetUnityObject(L, 1, typeof (Collider)), (Collider) LuaScriptMgr.GetUnityObject(L, 2, typeof (Collider)));
        return 0;
      case 3:
        Physics.IgnoreCollision((Collider) LuaScriptMgr.GetUnityObject(L, 1, typeof (Collider)), (Collider) LuaScriptMgr.GetUnityObject(L, 2, typeof (Collider)), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreCollision");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IgnoreLayerCollision(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Physics.IgnoreLayerCollision((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      case 3:
        Physics.IgnoreLayerCollision((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreLayerCollision");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetIgnoreLayerCollision(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool ignoreLayerCollision = Physics.GetIgnoreLayerCollision((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, ignoreLayerCollision);
    return 1;
  }
}
