// Decompiled with JetBrains decompiler
// Type: TestOverride01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TestOverride01 : MonoBehaviour
{
  private string script = "                  \r\n        function Test(to)\r\n            assert(to:Test(1) == 4)\r\n            assert(to:Test('hello') == 6)\r\n            assert(to:Test(object.New()) == 8)\r\n            assert(to:Test(123, 456) == 5)            \r\n            assert(to:Test('123', '456') == 1)\r\n            assert(to:Test(object.New(), '456') == 1)\r\n            assert(to:Test('123', 456) == 9)\r\n            assert(to:Test('123', object.New()) == 9)\r\n            assert(to:Test(1,2,3) == 9)            \r\n            assert(to:Test(TestOverride.Space.World) == 10)        \r\n        end\r\n    ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    TestOverrideWrap.Register(luaScriptMgr.GetL());
    TestOverride_SpaceWrap.Register(luaScriptMgr.GetL());
    luaScriptMgr.DoString(this.script);
    TestOverride testOverride = new TestOverride();
    luaScriptMgr.GetLuaFunction("Test").Call((object) testOverride);
  }
}
