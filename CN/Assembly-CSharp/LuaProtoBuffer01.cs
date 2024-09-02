// Decompiled with JetBrains decompiler
// Type: LuaProtoBuffer01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class LuaProtoBuffer01 : MonoBehaviour
{
  private string script = "      \r\n        function decoder()  \r\n            local msg = person_pb.Person()\r\n            msg:ParseFromString(TestProtol.data)\r\n            print('id:'..msg.id..' name:'..msg.name..' email:'..msg.email)\r\n        end\r\n\r\n        function encoder()                           \r\n            local msg = person_pb.Person()\r\n            msg.id = 100\r\n            msg.name = 'foo'\r\n            msg.email = 'bar'\r\n            local pb_data = msg:SerializeToString()\r\n            TestProtol.data = pb_data\r\n        end\r\n        ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    TestProtolWrap.Register(luaScriptMgr.GetL());
    luaScriptMgr.DoFile("person_pb.lua");
    luaScriptMgr.DoString(this.script);
    LuaFunction luaFunction1 = luaScriptMgr.GetLuaFunction("encoder");
    luaFunction1.Call();
    luaFunction1.Release();
    LuaFunction luaFunction2 = luaScriptMgr.GetLuaFunction("decoder");
    luaFunction2.Call();
    luaFunction2.Release();
  }
}
