// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaStatic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.IO;
using UnityEngine;

#nullable disable
namespace LuaInterface
{
  public static class LuaStatic
  {
    public static ReadLuaFile Load;
    public static string init_luanet = "local metatable = {}\r\n            local rawget = rawget\r\n            local debug = debug\r\n            local import_type = luanet.import_type\r\n            local load_assembly = luanet.load_assembly\r\n            luanet.error, luanet.type = error, type\r\n            -- Lookup a .NET identifier component.\r\n            function metatable:__index(key) -- key is e.g. 'Form'\r\n            -- Get the fully-qualified name, e.g. 'System.Windows.Forms.Form'\r\n            local fqn = rawget(self,'.fqn')\r\n            fqn = ((fqn and fqn .. '.') or '') .. key\r\n\r\n            -- Try to find either a luanet function or a CLR type\r\n            local obj = rawget(luanet,key) or import_type(fqn)\r\n\r\n            -- If key is neither a luanet function or a CLR type, then it is simply\r\n            -- an identifier component.\r\n            if obj == nil then\r\n                -- It might be an assembly, so we load it too.\r\n                    pcall(load_assembly,fqn)\r\n                    obj = { ['.fqn'] = fqn }\r\n            setmetatable(obj, metatable)\r\n            end\r\n\r\n            -- Cache this lookup\r\n            rawset(self, key, obj)\r\n            return obj\r\n            end\r\n\r\n            -- A non-type has been called; e.g. foo = System.Foo()\r\n            function metatable:__call(...)\r\n            error('No such type: ' .. rawget(self,'.fqn'), 2)\r\n            end\r\n\r\n            -- This is the root of the .NET namespace\r\n            luanet['.fqn'] = false\r\n            setmetatable(luanet, metatable)\r\n\r\n            -- Preload the mscorlib assembly\r\n            luanet.load_assembly('mscorlib')\r\n\r\n            function traceback(msg)                \r\n                return debug.traceback(msg, 1)                \r\n            end";

    static LuaStatic() => LuaStatic.Load = new ReadLuaFile(LuaStatic.DefaultLoader);

    private static byte[] DefaultLoader(string path)
    {
      byte[] numArray = (byte[]) null;
      if (File.Exists(path))
        numArray = File.ReadAllBytes(path);
      return numArray;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int panic(IntPtr L)
    {
      string message = string.Format("unprotected error in call to Lua API ({0})", (object) LuaDLL.lua_tostring(L, -1));
      LuaDLL.lua_pop(L, 1);
      throw new LuaException(message);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int traceback(IntPtr L)
    {
      LuaDLL.lua_getglobal(L, "debug");
      LuaDLL.lua_getfield(L, -1, nameof (traceback));
      LuaDLL.lua_pushvalue(L, 1);
      LuaDLL.lua_pushnumber(L, 2.0);
      LuaDLL.lua_call(L, 2, 1);
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int print(IntPtr L)
    {
      int num = LuaDLL.lua_gettop(L);
      string empty = string.Empty;
      LuaDLL.lua_getglobal(L, "tostring");
      for (int index = 1; index <= num; ++index)
      {
        LuaDLL.lua_pushvalue(L, -1);
        LuaDLL.lua_pushvalue(L, index);
        LuaDLL.lua_call(L, 1, 1);
        empty += LuaDLL.lua_tostring(L, -1);
        if (index > 1)
          empty += "\t";
        LuaDLL.lua_pop(L, 1);
        Debug.Log((object) ("LUA: " + empty));
      }
      return 0;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int loader(IntPtr L)
    {
      string empty = string.Empty;
      string str = LuaDLL.lua_tostring(L, 1);
      if (str.ToLower().EndsWith(".lua"))
      {
        int length = str.LastIndexOf('.');
        str = str.Substring(0, length);
      }
      string name = str.Replace('.', '/') + ".lua";
      LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
      if (mgrFromLuaState == null)
        return 0;
      LuaDLL.lua_pushstdcallcfunction(L, mgrFromLuaState.lua.tracebackFunction);
      int oldTop = LuaDLL.lua_gettop(L);
      byte[] buff = LuaStatic.Load(name);
      if (buff == null)
      {
        Debugger.LogError("Loader lua file failed: {0}", (object) name);
        LuaDLL.lua_pop(L, 1);
        return 0;
      }
      if (LuaDLL.luaL_loadbuffer(L, buff, buff.Length, name) != 0)
      {
        mgrFromLuaState.lua.ThrowExceptionFromError(oldTop);
        LuaDLL.lua_pop(L, 1);
      }
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int dofile(IntPtr L)
    {
      string empty = string.Empty;
      string str = LuaDLL.lua_tostring(L, 1);
      if (str.ToLower().EndsWith(".lua"))
      {
        int length = str.LastIndexOf('.');
        str = str.Substring(0, length);
      }
      string name = str.Replace('.', '/') + ".lua";
      int num = LuaDLL.lua_gettop(L);
      byte[] buff = LuaStatic.Load(name);
      if (buff == null || LuaDLL.luaL_loadbuffer(L, buff, buff.Length, name) != 0)
        return LuaDLL.lua_gettop(L) - num;
      LuaDLL.lua_call(L, 0, LuaDLL.LUA_MULTRET);
      return LuaDLL.lua_gettop(L) - num;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int loadfile(IntPtr L) => LuaStatic.loader(L);

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int importWrap(IntPtr L)
    {
      string empty = string.Empty;
      string type = LuaDLL.lua_tostring(L, 1).Replace('.', '_');
      if (!string.IsNullOrEmpty(type))
        LuaBinder.Bind(L, type);
      return 0;
    }
  }
}
