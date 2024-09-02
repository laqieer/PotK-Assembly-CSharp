// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text;

#nullable disable
namespace LuaInterface
{
  public class LuaState : IDisposable
  {
    public IntPtr L;
    internal LuaCSFunction tracebackFunction;
    internal ObjectTranslator translator;
    internal LuaCSFunction panicCallback;
    internal LuaCSFunction printFunction;
    internal LuaCSFunction loadfileFunction;
    internal LuaCSFunction loaderFunction;
    internal LuaCSFunction dofileFunction;
    internal LuaCSFunction import_wrapFunction;

    public LuaState()
    {
      this.L = LuaDLL.luaL_newstate();
      LuaDLL.luaL_openlibs(this.L);
      LuaDLL.lua_pushstring(this.L, "LUAINTERFACE LOADED");
      LuaDLL.lua_pushboolean(this.L, true);
      LuaDLL.lua_settable(this.L, LuaIndexes.LUA_REGISTRYINDEX);
      LuaDLL.lua_newtable(this.L);
      LuaDLL.lua_setglobal(this.L, "luanet");
      LuaDLL.lua_pushvalue(this.L, LuaIndexes.LUA_GLOBALSINDEX);
      LuaDLL.lua_getglobal(this.L, "luanet");
      LuaDLL.lua_pushstring(this.L, "getmetatable");
      LuaDLL.lua_getglobal(this.L, "getmetatable");
      LuaDLL.lua_settable(this.L, -3);
      LuaDLL.lua_pushstring(this.L, "rawget");
      LuaDLL.lua_getglobal(this.L, "rawget");
      LuaDLL.lua_settable(this.L, -3);
      LuaDLL.lua_pushstring(this.L, "rawset");
      LuaDLL.lua_getglobal(this.L, "rawset");
      LuaDLL.lua_settable(this.L, -3);
      LuaDLL.lua_replace(this.L, LuaIndexes.LUA_GLOBALSINDEX);
      this.translator = new ObjectTranslator(this, this.L);
      LuaDLL.lua_replace(this.L, LuaIndexes.LUA_GLOBALSINDEX);
      this.translator.PushTranslator(this.L);
      this.panicCallback = new LuaCSFunction(LuaStatic.panic);
      LuaDLL.lua_atpanic(this.L, this.panicCallback);
      this.printFunction = new LuaCSFunction(LuaStatic.print);
      LuaDLL.lua_pushstdcallcfunction(this.L, this.printFunction);
      LuaDLL.lua_setfield(this.L, LuaIndexes.LUA_GLOBALSINDEX, "print");
      this.loadfileFunction = new LuaCSFunction(LuaStatic.loadfile);
      LuaDLL.lua_pushstdcallcfunction(this.L, this.loadfileFunction);
      LuaDLL.lua_setfield(this.L, LuaIndexes.LUA_GLOBALSINDEX, "loadfile");
      this.dofileFunction = new LuaCSFunction(LuaStatic.dofile);
      LuaDLL.lua_pushstdcallcfunction(this.L, this.dofileFunction);
      LuaDLL.lua_setfield(this.L, LuaIndexes.LUA_GLOBALSINDEX, "dofile");
      this.import_wrapFunction = new LuaCSFunction(LuaStatic.importWrap);
      LuaDLL.lua_pushstdcallcfunction(this.L, this.import_wrapFunction);
      LuaDLL.lua_setfield(this.L, LuaIndexes.LUA_GLOBALSINDEX, "import");
      this.loaderFunction = new LuaCSFunction(LuaStatic.loader);
      LuaDLL.lua_pushstdcallcfunction(this.L, this.loaderFunction);
      int index1 = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getfield(this.L, LuaIndexes.LUA_GLOBALSINDEX, "package");
      LuaDLL.lua_getfield(this.L, -1, "loaders");
      int num = LuaDLL.lua_gettop(this.L);
      for (int index2 = LuaDLL.luaL_getn(this.L, num) + 1; index2 > 1; --index2)
      {
        LuaDLL.lua_rawgeti(this.L, num, index2 - 1);
        LuaDLL.lua_rawseti(this.L, num, index2);
      }
      LuaDLL.lua_pushvalue(this.L, index1);
      LuaDLL.lua_rawseti(this.L, num, 1);
      LuaDLL.lua_settop(this.L, 0);
      this.DoString(LuaStatic.init_luanet);
      this.tracebackFunction = new LuaCSFunction(LuaStatic.traceback);
    }

    public void Close()
    {
      if (!(this.L != IntPtr.Zero))
        return;
      this.translator.Destroy();
      LuaDLL.lua_close(this.L);
    }

    public ObjectTranslator GetTranslator() => this.translator;

    internal void ThrowExceptionFromError(int oldTop)
    {
      string message = LuaDLL.lua_tostring(this.L, -1);
      LuaDLL.lua_settop(this.L, oldTop);
      message = message == null ? "Unknown Lua Error" : throw new LuaScriptException(message, string.Empty);
    }

    internal int SetPendingException(Exception e)
    {
      if (e == null)
        return 0;
      this.translator.throwError(this.L, e.ToString());
      LuaDLL.lua_pushnil(this.L);
      return 1;
    }

    public LuaFunction LoadString(string chunk, string name, LuaTable env)
    {
      int oldTop = LuaDLL.lua_gettop(this.L);
      byte[] bytes = Encoding.UTF8.GetBytes(chunk);
      if (LuaDLL.luaL_loadbuffer(this.L, bytes, bytes.Length, name) != 0)
        this.ThrowExceptionFromError(oldTop);
      if (env != null)
      {
        env.push(this.L);
        LuaDLL.lua_setfenv(this.L, -2);
      }
      LuaFunction function = this.translator.getFunction(this.L, -1);
      this.translator.popValues(this.L, oldTop);
      return function;
    }

    public LuaFunction LoadString(string chunk, string name)
    {
      return this.LoadString(chunk, name, (LuaTable) null);
    }

    public LuaFunction LoadFile(string fileName)
    {
      int oldTop = LuaDLL.lua_gettop(this.L);
      byte[] buff = (byte[]) null;
      using (FileStream input = new FileStream(Util.LuaPath(fileName), FileMode.Open))
      {
        buff = new BinaryReader((Stream) input).ReadBytes((int) input.Length);
        input.Close();
      }
      if (LuaDLL.luaL_loadbuffer(this.L, buff, buff.Length, fileName) != 0)
        this.ThrowExceptionFromError(oldTop);
      LuaFunction function = this.translator.getFunction(this.L, -1);
      this.translator.popValues(this.L, oldTop);
      return function;
    }

    public object[] DoString(string chunk) => this.DoString(chunk, nameof (chunk), (LuaTable) null);

    public object[] DoString(string chunk, string chunkName, LuaTable env)
    {
      int oldTop = LuaDLL.lua_gettop(this.L);
      byte[] bytes = Encoding.UTF8.GetBytes(chunk);
      if (LuaDLL.luaL_loadbuffer(this.L, bytes, bytes.Length, chunkName) == 0)
      {
        if (env != null)
        {
          env.push(this.L);
          LuaDLL.lua_setfenv(this.L, -2);
        }
        if (LuaDLL.lua_pcall(this.L, 0, -1, 0) == 0)
          return this.translator.popValues(this.L, oldTop);
        this.ThrowExceptionFromError(oldTop);
      }
      else
        this.ThrowExceptionFromError(oldTop);
      return (object[]) null;
    }

    public object[] DoFile(string fileName) => this.DoFile(fileName, (LuaTable) null);

    public object[] DoFile(string fileName, LuaTable env)
    {
      LuaDLL.lua_pushstdcallcfunction(this.L, this.tracebackFunction);
      int oldTop = LuaDLL.lua_gettop(this.L);
      byte[] buff = LuaStatic.Load(fileName);
      if (buff == null)
      {
        Debugger.LogError("Loader lua file failed: {0}", (object) fileName);
        LuaDLL.lua_pop(this.L, 1);
        return (object[]) null;
      }
      if (LuaDLL.luaL_loadbuffer(this.L, buff, buff.Length, fileName) == 0)
      {
        if (env != null)
        {
          env.push(this.L);
          LuaDLL.lua_setfenv(this.L, -2);
        }
        if (LuaDLL.lua_pcall(this.L, 0, -1, -2) == 0)
        {
          object[] objArray = this.translator.popValues(this.L, oldTop);
          LuaDLL.lua_pop(this.L, 1);
          return objArray;
        }
        this.ThrowExceptionFromError(oldTop);
        LuaDLL.lua_pop(this.L, 1);
      }
      else
      {
        this.ThrowExceptionFromError(oldTop);
        LuaDLL.lua_pop(this.L, 1);
      }
      return (object[]) null;
    }

    public object this[string fullPath]
    {
      get
      {
        int newTop = LuaDLL.lua_gettop(this.L);
        string[] sourceArray = fullPath.Split('.');
        LuaDLL.lua_getglobal(this.L, sourceArray[0]);
        object obj = this.translator.getObject(this.L, -1);
        if (sourceArray.Length > 1)
        {
          string[] strArray = new string[sourceArray.Length - 1];
          Array.Copy((Array) sourceArray, 1, (Array) strArray, 0, sourceArray.Length - 1);
          obj = this.getObject(strArray);
        }
        LuaDLL.lua_settop(this.L, newTop);
        return obj;
      }
      set
      {
        int newTop = LuaDLL.lua_gettop(this.L);
        string[] sourceArray = fullPath.Split('.');
        if (sourceArray.Length == 1)
        {
          this.translator.push(this.L, value);
          LuaDLL.lua_setglobal(this.L, fullPath);
        }
        else
        {
          LuaDLL.lua_rawglobal(this.L, sourceArray[0]);
          if (LuaDLL.lua_type(this.L, -1) == LuaTypes.LUA_TNIL)
          {
            Debugger.LogError("Table {0} not exists", (object) sourceArray[0]);
            LuaDLL.lua_settop(this.L, newTop);
            return;
          }
          string[] strArray = new string[sourceArray.Length - 1];
          Array.Copy((Array) sourceArray, 1, (Array) strArray, 0, sourceArray.Length - 1);
          this.setObject(strArray, value);
        }
        LuaDLL.lua_settop(this.L, newTop);
      }
    }

    internal object getObject(string[] remainingPath)
    {
      object obj = (object) null;
      for (int index = 0; index < remainingPath.Length; ++index)
      {
        LuaDLL.lua_pushstring(this.L, remainingPath[index]);
        LuaDLL.lua_gettable(this.L, -2);
        obj = this.translator.getObject(this.L, -1);
        if (obj == null)
          break;
      }
      return obj;
    }

    public double GetNumber(string fullPath) => (double) this[fullPath];

    public string GetString(string fullPath) => (string) this[fullPath];

    public LuaTable GetTable(string fullPath) => (LuaTable) this[fullPath];

    public LuaFunction GetFunction(string fullPath)
    {
      object function = this[fullPath];
      return function is LuaCSFunction ? new LuaFunction((LuaCSFunction) function, this) : (LuaFunction) function;
    }

    public Delegate GetFunction(System.Type delegateType, string fullPath)
    {
      this.translator.throwError(this.L, "function delegates not implemnented");
      return (Delegate) null;
    }

    internal void setObject(string[] remainingPath, object val)
    {
      for (int index = 0; index < remainingPath.Length - 1; ++index)
      {
        LuaDLL.lua_pushstring(this.L, remainingPath[index]);
        LuaDLL.lua_gettable(this.L, -2);
      }
      LuaDLL.lua_pushstring(this.L, remainingPath[remainingPath.Length - 1]);
      this.translator.push(this.L, val);
      LuaDLL.lua_settable(this.L, -3);
    }

    public void NewTable(string fullPath)
    {
      string[] strArray = fullPath.Split('.');
      int newTop = LuaDLL.lua_gettop(this.L);
      if (strArray.Length == 1)
      {
        LuaDLL.lua_newtable(this.L);
        LuaDLL.lua_setglobal(this.L, fullPath);
      }
      else
      {
        LuaDLL.lua_getglobal(this.L, strArray[0]);
        for (int index = 1; index < strArray.Length - 1; ++index)
        {
          LuaDLL.lua_pushstring(this.L, strArray[index]);
          LuaDLL.lua_gettable(this.L, -2);
        }
        LuaDLL.lua_pushstring(this.L, strArray[strArray.Length - 1]);
        LuaDLL.lua_newtable(this.L);
        LuaDLL.lua_settable(this.L, -3);
      }
      LuaDLL.lua_settop(this.L, newTop);
    }

    public LuaTable NewTable()
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_newtable(this.L);
      LuaTable luaTable = (LuaTable) this.translator.getObject(this.L, -1);
      LuaDLL.lua_settop(this.L, newTop);
      return luaTable;
    }

    public ListDictionary GetTableDict(LuaTable table)
    {
      ListDictionary tableDict = new ListDictionary();
      int newTop = LuaDLL.lua_gettop(this.L);
      this.translator.push(this.L, (object) table);
      LuaDLL.lua_pushnil(this.L);
      while (LuaDLL.lua_next(this.L, -2) != 0)
      {
        tableDict[this.translator.getObject(this.L, -2)] = this.translator.getObject(this.L, -1);
        LuaDLL.lua_settop(this.L, -2);
      }
      LuaDLL.lua_settop(this.L, newTop);
      return tableDict;
    }

    internal void dispose(int reference)
    {
      if (!(this.L != IntPtr.Zero))
        return;
      LuaDLL.lua_unref(this.L, reference);
    }

    internal object rawGetObject(int reference, string field)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, reference);
      LuaDLL.lua_pushstring(this.L, field);
      LuaDLL.lua_rawget(this.L, -2);
      object obj = this.translator.getObject(this.L, -1);
      LuaDLL.lua_settop(this.L, newTop);
      return obj;
    }

    internal object getObject(int reference, string field)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, reference);
      object obj = this.getObject(field.Split('.'));
      LuaDLL.lua_settop(this.L, newTop);
      return obj;
    }

    internal object getObject(int reference, object field)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, reference);
      this.translator.push(this.L, field);
      LuaDLL.lua_gettable(this.L, -2);
      object obj = this.translator.getObject(this.L, -1);
      LuaDLL.lua_settop(this.L, newTop);
      return obj;
    }

    internal void setObject(int reference, string field, object val)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, reference);
      this.setObject(field.Split('.'), val);
      LuaDLL.lua_settop(this.L, newTop);
    }

    internal void setObject(int reference, object field, object val)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, reference);
      this.translator.push(this.L, field);
      this.translator.push(this.L, val);
      LuaDLL.lua_settable(this.L, -3);
      LuaDLL.lua_settop(this.L, newTop);
    }

    public LuaFunction RegisterFunction(string path, object target, MethodBase function)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      this.translator.push(this.L, (object) new LuaCSFunction(new LuaMethodWrapper(this.translator, target, (IReflect) function.DeclaringType, function).call));
      this[path] = this.translator.getObject(this.L, -1);
      LuaFunction function1 = this.GetFunction(path);
      LuaDLL.lua_settop(this.L, newTop);
      return function1;
    }

    public LuaFunction CreateFunction(object target, MethodBase function)
    {
      int newTop = LuaDLL.lua_gettop(this.L);
      this.translator.push(this.L, (object) new LuaCSFunction(new LuaMethodWrapper(this.translator, target, (IReflect) function.DeclaringType, function).call));
      object function1 = this.translator.getObject(this.L, -1);
      LuaFunction function2 = !(function1 is LuaCSFunction) ? (LuaFunction) function1 : new LuaFunction((LuaCSFunction) function1, this);
      LuaDLL.lua_settop(this.L, newTop);
      return function2;
    }

    internal bool compareRef(int ref1, int ref2)
    {
      if (ref1 == ref2)
        return true;
      int newTop = LuaDLL.lua_gettop(this.L);
      LuaDLL.lua_getref(this.L, ref1);
      LuaDLL.lua_getref(this.L, ref2);
      int num = LuaDLL.lua_equal(this.L, -1, -2);
      LuaDLL.lua_settop(this.L, newTop);
      return num != 0;
    }

    internal void pushCSFunction(LuaCSFunction function)
    {
      this.translator.pushFunction(this.L, function);
    }

    public void Dispose()
    {
      this.Dispose(true);
      this.L = IntPtr.Zero;
      GC.SuppressFinalize((object) this);
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public virtual void Dispose(bool dispose)
    {
      if (!dispose || this.translator == null)
        return;
      this.translator.pendingEvents.Dispose();
      this.translator = (ObjectTranslator) null;
    }
  }
}
