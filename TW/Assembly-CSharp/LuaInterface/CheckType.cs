// Decompiled with JetBrains decompiler
// Type: LuaInterface.CheckType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace LuaInterface
{
  internal class CheckType
  {
    private ObjectTranslator translator;
    private ExtractValue extractNetObject;
    private Dictionary<long, ExtractValue> extractValues = new Dictionary<long, ExtractValue>();

    public CheckType(ObjectTranslator translator)
    {
      this.translator = translator;
      this.extractValues.Add(typeof (object).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsObject));
      this.extractValues.Add(typeof (sbyte).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsSbyte));
      this.extractValues.Add(typeof (byte).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsByte));
      this.extractValues.Add(typeof (short).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsShort));
      this.extractValues.Add(typeof (ushort).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsUshort));
      this.extractValues.Add(typeof (int).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsInt));
      this.extractValues.Add(typeof (uint).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsUint));
      this.extractValues.Add(typeof (long).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsLong));
      this.extractValues.Add(typeof (ulong).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsUlong));
      this.extractValues.Add(typeof (double).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsDouble));
      this.extractValues.Add(typeof (char).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsChar));
      this.extractValues.Add(typeof (float).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsFloat));
      this.extractValues.Add(typeof (Decimal).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsDecimal));
      this.extractValues.Add(typeof (bool).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsBoolean));
      this.extractValues.Add(typeof (string).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsString));
      this.extractValues.Add(typeof (LuaFunction).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsFunction));
      this.extractValues.Add(typeof (LuaTable).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsTable));
      this.extractValues.Add(typeof (Vector3).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsVector3));
      this.extractValues.Add(typeof (Vector2).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsVector2));
      this.extractValues.Add(typeof (Quaternion).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsQuaternion));
      this.extractValues.Add(typeof (Color).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsColor));
      this.extractValues.Add(typeof (Vector4).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsVector4));
      this.extractValues.Add(typeof (Ray).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsRay));
      this.extractValues.Add(typeof (Bounds).TypeHandle.Value.ToInt64(), new ExtractValue(this.getAsBounds));
      this.extractNetObject = new ExtractValue(this.getAsNetObject);
    }

    internal ExtractValue getExtractor(IReflect paramType)
    {
      return this.getExtractor(paramType.UnderlyingSystemType);
    }

    internal ExtractValue getExtractor(System.Type paramType)
    {
      if (paramType.IsByRef)
        paramType = paramType.GetElementType();
      long int64 = paramType.TypeHandle.Value.ToInt64();
      return this.extractValues.ContainsKey(int64) ? this.extractValues[int64] : this.extractNetObject;
    }

    internal ExtractValue checkType(IntPtr luaState, int stackPos, System.Type paramType)
    {
      LuaTypes luaTypes = LuaDLL.lua_type(luaState, stackPos);
      if (paramType.IsByRef)
        paramType = paramType.GetElementType();
      System.Type underlyingType = Nullable.GetUnderlyingType(paramType);
      if ((object) underlyingType != null)
        paramType = underlyingType;
      long int64 = paramType.TypeHandle.Value.ToInt64();
      if (paramType.Equals(typeof (object)))
        return this.extractValues[int64];
      if (paramType.IsGenericParameter)
      {
        switch (luaTypes)
        {
          case LuaTypes.LUA_TBOOLEAN:
            return this.extractValues[typeof (bool).TypeHandle.Value.ToInt64()];
          case LuaTypes.LUA_TNUMBER:
            return this.extractValues[typeof (double).TypeHandle.Value.ToInt64()];
          case LuaTypes.LUA_TSTRING:
            return this.extractValues[typeof (string).TypeHandle.Value.ToInt64()];
          case LuaTypes.LUA_TTABLE:
            return this.extractValues[typeof (LuaTable).TypeHandle.Value.ToInt64()];
          case LuaTypes.LUA_TFUNCTION:
            return this.extractValues[typeof (LuaFunction).TypeHandle.Value.ToInt64()];
          case LuaTypes.LUA_TUSERDATA:
            return this.extractValues[typeof (object).TypeHandle.Value.ToInt64()];
        }
      }
      if (paramType.IsValueType && luaTypes == LuaTypes.LUA_TTABLE)
      {
        int newTop = LuaDLL.lua_gettop(luaState);
        ExtractValue extractValue = (ExtractValue) null;
        LuaDLL.lua_pushvalue(luaState, stackPos);
        LuaDLL.lua_pushstring(luaState, "class");
        LuaDLL.lua_gettable(luaState, -2);
        if (!LuaDLL.lua_isnil(luaState, -1))
        {
          string str = LuaDLL.lua_tostring(luaState, -1);
          extractValue = !(str == "Vector3") || (object) paramType != (object) typeof (Vector3) ? (!(str == "Vector2") || (object) paramType != (object) typeof (Vector2) ? (!(str == "Quaternion") || (object) paramType != (object) typeof (Quaternion) ? (!(str == "Color") || (object) paramType != (object) typeof (Color) ? (!(str == "Vector4") || (object) paramType != (object) typeof (Vector4) ? (!(str == "Ray") || (object) paramType != (object) typeof (Ray) ? (ExtractValue) null : this.extractValues[typeof (Ray).TypeHandle.Value.ToInt64()]) : this.extractValues[typeof (Vector4).TypeHandle.Value.ToInt64()]) : this.extractValues[typeof (Color).TypeHandle.Value.ToInt64()]) : this.extractValues[typeof (Quaternion).TypeHandle.Value.ToInt64()]) : this.extractValues[typeof (Vector2).TypeHandle.Value.ToInt64()]) : this.extractValues[typeof (Vector3).TypeHandle.Value.ToInt64()];
        }
        LuaDLL.lua_settop(luaState, newTop);
        if (extractValue != null)
          return extractValue;
      }
      if (LuaDLL.lua_isnumber(luaState, stackPos))
        return this.extractValues[int64];
      if ((object) paramType == (object) typeof (bool))
      {
        if (LuaDLL.lua_isboolean(luaState, stackPos))
          return this.extractValues[int64];
      }
      else if ((object) paramType == (object) typeof (string))
      {
        if (LuaDLL.lua_isstring(luaState, stackPos))
          return this.extractValues[int64];
        if (luaTypes == LuaTypes.LUA_TNIL)
          return this.extractNetObject;
      }
      else if ((object) paramType == (object) typeof (LuaTable))
      {
        if (luaTypes == LuaTypes.LUA_TTABLE)
          return this.extractValues[int64];
      }
      else if ((object) paramType == (object) typeof (LuaFunction))
      {
        if (luaTypes == LuaTypes.LUA_TFUNCTION)
          return this.extractValues[int64];
      }
      else if (typeof (Delegate).IsAssignableFrom(paramType) && luaTypes == LuaTypes.LUA_TFUNCTION)
        this.translator.throwError(luaState, "Delegates not implemnented");
      else if (paramType.IsInterface && luaTypes == LuaTypes.LUA_TTABLE)
      {
        this.translator.throwError(luaState, "Interfaces not implemnented");
      }
      else
      {
        if ((paramType.IsInterface || paramType.IsClass) && luaTypes == LuaTypes.LUA_TNIL)
          return this.extractNetObject;
        if (LuaDLL.lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE)
        {
          if (LuaDLL.luaL_getmetafield(luaState, stackPos, "__index") != LuaTypes.LUA_TNIL)
          {
            object netObject = this.translator.getNetObject(luaState, -1);
            LuaDLL.lua_settop(luaState, -2);
            if (netObject != null && paramType.IsAssignableFrom(netObject.GetType()))
              return this.extractNetObject;
          }
        }
        else
        {
          object rawNetObject = this.translator.getRawNetObject(luaState, stackPos);
          if (rawNetObject != null && paramType.IsAssignableFrom(rawNetObject.GetType()))
            return this.extractNetObject;
        }
      }
      return (ExtractValue) null;
    }

    private object getAsSbyte(IntPtr luaState, int stackPos)
    {
      sbyte num = (sbyte) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == (sbyte) 0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsByte(IntPtr luaState, int stackPos)
    {
      byte num = (byte) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == (byte) 0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsShort(IntPtr luaState, int stackPos)
    {
      short num = (short) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == (short) 0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsUshort(IntPtr luaState, int stackPos)
    {
      ushort num = (ushort) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == (ushort) 0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsInt(IntPtr luaState, int stackPos)
    {
      int num = (int) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsUint(IntPtr luaState, int stackPos)
    {
      uint num = (uint) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0U && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsLong(IntPtr luaState, int stackPos)
    {
      long num = (long) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0L && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsUlong(IntPtr luaState, int stackPos)
    {
      ulong num = (ulong) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0UL && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsDouble(IntPtr luaState, int stackPos)
    {
      double num = LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0.0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsChar(IntPtr luaState, int stackPos)
    {
      char ch = (char) LuaDLL.lua_tonumber(luaState, stackPos);
      return ch == char.MinValue && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) ch;
    }

    private object getAsFloat(IntPtr luaState, int stackPos)
    {
      float num = (float) LuaDLL.lua_tonumber(luaState, stackPos);
      return (double) num == 0.0 && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsDecimal(IntPtr luaState, int stackPos)
    {
      Decimal num = (Decimal) LuaDLL.lua_tonumber(luaState, stackPos);
      return num == 0M && !LuaDLL.lua_isnumber(luaState, stackPos) ? (object) null : (object) num;
    }

    private object getAsBoolean(IntPtr luaState, int stackPos)
    {
      return (object) LuaDLL.lua_toboolean(luaState, stackPos);
    }

    private object getAsString(IntPtr luaState, int stackPos)
    {
      string str = LuaDLL.lua_tostring(luaState, stackPos);
      return str == string.Empty && !LuaDLL.lua_isstring(luaState, stackPos) ? (object) null : (object) str;
    }

    private object getAsTable(IntPtr luaState, int stackPos)
    {
      return (object) this.translator.getTable(luaState, stackPos);
    }

    private object getAsFunction(IntPtr luaState, int stackPos)
    {
      return (object) this.translator.getFunction(luaState, stackPos);
    }

    public object getAsObject(IntPtr luaState, int stackPos)
    {
      if (LuaDLL.lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE && LuaDLL.luaL_getmetafield(luaState, stackPos, "__index") != LuaTypes.LUA_TNIL)
      {
        if (LuaDLL.luaL_checkmetatable(luaState, -1))
        {
          LuaDLL.lua_insert(luaState, stackPos);
          LuaDLL.lua_remove(luaState, stackPos + 1);
        }
        else
          LuaDLL.lua_settop(luaState, -2);
      }
      return this.translator.getObject(luaState, stackPos);
    }

    public object getAsNetObject(IntPtr luaState, int stackPos)
    {
      object asNetObject = this.translator.getRawNetObject(luaState, stackPos);
      if (asNetObject == null && LuaDLL.lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE && LuaDLL.luaL_getmetafield(luaState, stackPos, "__index") != LuaTypes.LUA_TNIL)
      {
        if (LuaDLL.luaL_checkmetatable(luaState, -1))
        {
          LuaDLL.lua_insert(luaState, stackPos);
          LuaDLL.lua_remove(luaState, stackPos + 1);
          asNetObject = this.translator.getNetObject(luaState, stackPos);
        }
        else
          LuaDLL.lua_settop(luaState, -2);
      }
      return asNetObject;
    }

    public object getAsVector3(IntPtr L, int stackPos)
    {
      return (object) LuaScriptMgr.GetVector3(L, stackPos);
    }

    public object getAsVector2(IntPtr L, int stackPos)
    {
      return (object) LuaScriptMgr.GetVector2(L, stackPos);
    }

    public object getAsQuaternion(IntPtr L, int stackPos)
    {
      return (object) LuaScriptMgr.GetQuaternion(L, stackPos);
    }

    public object getAsColor(IntPtr L, int stackPos) => (object) LuaScriptMgr.GetColor(L, stackPos);

    public object getAsVector4(IntPtr L, int stackPos)
    {
      return (object) LuaScriptMgr.GetVector4(L, stackPos);
    }

    public object getAsRay(IntPtr L, int stackPos) => (object) LuaScriptMgr.GetRay(L, stackPos);

    public object getAsBounds(IntPtr L, int stackPos)
    {
      return (object) LuaScriptMgr.GetBounds(L, stackPos);
    }
  }
}
