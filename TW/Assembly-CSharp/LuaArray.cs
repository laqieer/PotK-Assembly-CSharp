// Decompiled with JetBrains decompiler
// Type: LuaArray
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class LuaArray : MonoBehaviour
{
  private string source = "\r\n        function luaFunc(objs, len)\r\n            for i = 0, len - 1 do\r\n                print(objs[i])\r\n            end\r\n            local table1 = {'111', '222', '333'}\r\n            return unpack(table1)\r\n        end\r\n    ";
  private string[] objs = new string[3]
  {
    "aaa",
    "bbb",
    "ccc"
  };

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    LuaState lua = luaScriptMgr.lua;
    lua.DoString(this.source);
    LuaFunction function = lua.GetFunction("luaFunc");
    object[] objArray = function.Call((object) this.objs, (object) this.objs.Length);
    function.Release();
    foreach (object obj in objArray)
      Debug.Log((object) obj.ToString());
  }
}
