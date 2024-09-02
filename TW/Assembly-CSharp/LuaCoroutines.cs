// Decompiled with JetBrains decompiler
// Type: LuaCoroutines
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class LuaCoroutines : MonoBehaviour
{
  private string script = "                                   \r\n            function fib(n)\r\n                local a, b = 0, 1\r\n                while n > 0 do\r\n                    a, b = b, a + b\r\n                    n = n - 1\r\n                end\r\n\r\n                return a\r\n            end\r\n\r\n            function CoFunc()\r\n                print('Coroutine started')\r\n                local i = 0\r\n                for i = 0, 10, 1 do\r\n                    print(fib(i))                    \r\n                    coroutine.wait(1)\r\n                end\r\n                print('Coroutine ended')\r\n            end\r\n\r\n            function myFunc()\r\n                coroutine.start(CoFunc)\r\n            end\r\n        ";
  private LuaScriptMgr lua;

  private void Awake()
  {
    this.lua = new LuaScriptMgr();
    this.lua.Start();
    this.lua.DoString(this.script);
    LuaFunction luaFunction = this.lua.GetLuaFunction("myFunc");
    luaFunction.Call();
    luaFunction.Release();
  }

  private void Update() => this.lua.Update();

  private void LateUpdate() => this.lua.LateUpate();

  private void FixedUpdate() => this.lua.FixedUpdate();
}
