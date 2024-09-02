// Decompiled with JetBrains decompiler
// Type: TestLuaArray
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class TestLuaArray : MonoBehaviour
{
  private string script = "                                   \r\n            function TestArray(objs)                \r\n                local len = objs.Length\r\n                \r\n                for i = 0, len - 1 do\r\n                    print(objs[i])\r\n                end\r\n                return 1, '123', true\r\n            end\r\n        ";
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
    luaScriptMgr.DoString(this.script);
    LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("TestArray");
    object[] objArray = luaFunction.Call((object) this.objs);
    luaFunction.Release();
    for (int index = 0; index < this.objs.Length; ++index)
      Debug.Log((object) objArray[index].ToString());
  }
}
