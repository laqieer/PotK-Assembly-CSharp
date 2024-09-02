// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;

#nullable disable
namespace LuaInterface
{
  public class LuaTable : LuaBase
  {
    public LuaTable(int reference, LuaState interpreter)
    {
      this._Reference = reference;
      this._Interpreter = interpreter;
      this.translator = interpreter.translator;
    }

    public LuaTable(int reference, IntPtr L)
    {
      this._Reference = reference;
      this.translator = ObjectTranslator.FromState(L);
      this._Interpreter = this.translator.interpreter;
    }

    public object this[string field]
    {
      get => this._Interpreter.getObject(this._Reference, field);
      set => this._Interpreter.setObject(this._Reference, field, value);
    }

    public object this[object field]
    {
      get => this._Interpreter.getObject(this._Reference, field);
      set => this._Interpreter.setObject(this._Reference, field, value);
    }

    public IDictionaryEnumerator GetEnumerator()
    {
      return this._Interpreter.GetTableDict(this).GetEnumerator();
    }

    public int Count => this._Interpreter.GetTableDict(this).Count;

    public ICollection Keys => this._Interpreter.GetTableDict(this).Keys;

    public ICollection Values => this._Interpreter.GetTableDict(this).Values;

    public void SetMetaTable(LuaTable metaTable)
    {
      this.push(this._Interpreter.L);
      metaTable.push(this._Interpreter.L);
      LuaDLL.lua_setmetatable(this._Interpreter.L, -2);
      LuaDLL.lua_pop(this._Interpreter.L, 1);
    }

    public T[] ToArray<T>()
    {
      IntPtr l = this._Interpreter.L;
      this.push(l);
      return LuaScriptMgr.GetArrayObject<T>(l, -1);
    }

    public void Set(string key, object o)
    {
      IntPtr l = this._Interpreter.L;
      this.push(l);
      LuaDLL.lua_pushstring(l, key);
      this.PushArgs(l, o);
      LuaDLL.lua_rawset(l, -3);
      LuaDLL.lua_settop(l, 0);
    }

    internal object rawget(string field) => this._Interpreter.rawGetObject(this._Reference, field);

    internal object rawgetFunction(string field)
    {
      object function = this._Interpreter.rawGetObject(this._Reference, field);
      return function is LuaCSFunction ? (object) new LuaFunction((LuaCSFunction) function, this._Interpreter) : function;
    }

    public LuaFunction RawGetFunc(string field)
    {
      IntPtr l = this._Interpreter.L;
      LuaFunction func = (LuaFunction) null;
      int newTop = LuaDLL.lua_gettop(l);
      LuaDLL.lua_getref(l, this._Reference);
      LuaDLL.lua_pushstring(l, field);
      LuaDLL.lua_gettable(l, -2);
      if (LuaDLL.lua_type(l, -1) == LuaTypes.LUA_TFUNCTION)
        func = new LuaFunction(LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX), l);
      LuaDLL.lua_settop(l, newTop);
      return func;
    }

    internal void push(IntPtr luaState) => LuaDLL.lua_getref(luaState, this._Reference);

    public override string ToString() => "table";
  }
}
