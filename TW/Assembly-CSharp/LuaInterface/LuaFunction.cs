// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaFunction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public class LuaFunction : LuaBase
  {
    internal LuaCSFunction function;
    private IntPtr L;
    private int beginPos = -1;

    public LuaFunction(int reference, LuaState interpreter)
    {
      this._Reference = reference;
      this.function = (LuaCSFunction) null;
      this._Interpreter = interpreter;
      this.L = this._Interpreter.L;
      this.translator = this._Interpreter.translator;
    }

    public LuaFunction(LuaCSFunction function, LuaState interpreter)
    {
      this._Reference = 0;
      this.function = function;
      this._Interpreter = interpreter;
      this.L = this._Interpreter.L;
      this.translator = this._Interpreter.translator;
    }

    public LuaFunction(int reference, IntPtr l)
    {
      this._Reference = reference;
      this.function = (LuaCSFunction) null;
      this.L = l;
      this.translator = ObjectTranslator.FromState(this.L);
      this._Interpreter = this.translator.interpreter;
    }

    internal object[] call(object[] args, System.Type[] returnTypes)
    {
      int nArgs = 0;
      LuaScriptMgr.PushTraceBack(this.L);
      int oldTop = LuaDLL.lua_gettop(this.L);
      if (!LuaDLL.lua_checkstack(this.L, args.Length + 6))
      {
        LuaDLL.lua_pop(this.L, 1);
        throw new LuaException("Lua stack overflow");
      }
      this.push(this.L);
      if (args != null)
      {
        nArgs = args.Length;
        for (int index = 0; index < args.Length; ++index)
          this.PushArgs(this.L, args[index]);
      }
      if (LuaDLL.lua_pcall(this.L, nArgs, -1, -nArgs - 2) != 0)
      {
        string message = LuaDLL.lua_tostring(this.L, -1);
        LuaDLL.lua_settop(this.L, oldTop - 1);
        message = message == null ? "Unknown Lua Error" : throw new LuaScriptException(message, string.Empty);
      }
      else
      {
        object[] objArray = returnTypes == null ? this.translator.popValues(this.L, oldTop) : this.translator.popValues(this.L, oldTop, returnTypes);
        LuaDLL.lua_settop(this.L, oldTop - 1);
        return objArray;
      }
    }

    public object[] Call(params object[] args) => this.call(args, (System.Type[]) null);

    public object[] Call()
    {
      int oldTop = this.BeginPCall();
      if (this.PCall(oldTop, 0))
      {
        object[] objArray = this.PopValues(oldTop);
        this.EndPCall(oldTop);
        return objArray;
      }
      LuaDLL.lua_settop(this.L, oldTop - 1);
      return (object[]) null;
    }

    public object[] Call(double arg1)
    {
      int oldTop = this.BeginPCall();
      LuaScriptMgr.Push(this.L, arg1);
      if (this.PCall(oldTop, 1))
      {
        object[] objArray = this.PopValues(oldTop);
        this.EndPCall(oldTop);
        return objArray;
      }
      LuaDLL.lua_settop(this.L, oldTop - 1);
      return (object[]) null;
    }

    public int BeginPCall()
    {
      LuaScriptMgr.PushTraceBack(this.L);
      this.beginPos = LuaDLL.lua_gettop(this.L);
      this.push(this.L);
      return this.beginPos;
    }

    public bool PCall(int oldTop, int args)
    {
      if (LuaDLL.lua_pcall(this.L, args, -1, -args - 2) != 0)
      {
        string message = LuaDLL.lua_tostring(this.L, -1);
        LuaDLL.lua_settop(this.L, oldTop - 1);
        message = message == null ? "Unknown Lua Error" : throw new LuaScriptException(message, string.Empty);
      }
      else
        return true;
    }

    public object[] PopValues(int oldTop) => this.translator.popValues(this.L, oldTop);

    public void EndPCall(int oldTop) => LuaDLL.lua_settop(this.L, oldTop - 1);

    public IntPtr GetLuaState() => this.L;

    internal void push(IntPtr luaState)
    {
      if (this._Reference != 0)
        LuaDLL.lua_getref(luaState, this._Reference);
      else
        this._Interpreter.pushCSFunction(this.function);
    }

    internal void push()
    {
      if (this._Reference != 0)
        LuaDLL.lua_getref(this.L, this._Reference);
      else
        this._Interpreter.pushCSFunction(this.function);
    }

    public override string ToString() => "function";

    public override bool Equals(object o)
    {
      if (!(o is LuaFunction))
        return false;
      LuaFunction luaFunction = (LuaFunction) o;
      return this._Reference != 0 && luaFunction._Reference != 0 ? this._Interpreter.compareRef(luaFunction._Reference, this._Reference) : (MulticastDelegate) this.function == (MulticastDelegate) luaFunction.function;
    }

    public override int GetHashCode()
    {
      return this._Reference != 0 ? this._Reference : this.function.GetHashCode();
    }

    public int GetReference() => this._Reference;
  }
}
