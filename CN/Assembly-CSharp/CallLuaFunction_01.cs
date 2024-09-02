// Decompiled with JetBrains decompiler
// Type: CallLuaFunction_01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class CallLuaFunction_01 : MonoBehaviour
{
  private string script = "\r\n            function luaFunc(message)\r\n                print(message)\r\n                return 42\r\n            end\r\n        ";

  private void Start()
  {
    LuaState luaState = new LuaState();
    luaState.DoString(this.script);
    MonoBehaviour.print(luaState.GetFunction("luaFunc").Call((object) "I called a lua function!")[0]);
  }

  private void Update()
  {
  }
}
