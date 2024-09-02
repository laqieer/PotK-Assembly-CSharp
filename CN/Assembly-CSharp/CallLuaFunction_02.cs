// Decompiled with JetBrains decompiler
// Type: CallLuaFunction_02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class CallLuaFunction_02 : MonoBehaviour
{
  private string script = "\r\n            function luaFunc(num)                \r\n                return num\r\n            end\r\n        ";
  private LuaFunction func;

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.DoString(this.script);
    this.func = luaScriptMgr.GetLuaFunction("luaFunc");
    MonoBehaviour.print(this.func.Call(123456.0)[0]);
    MonoBehaviour.print((object) this.CallFunc());
  }

  private void OnDestroy()
  {
    if (this.func == null)
      return;
    this.func.Release();
  }

  private int CallFunc()
  {
    int oldTop = this.func.BeginPCall();
    IntPtr luaState = this.func.GetLuaState();
    LuaScriptMgr.Push(luaState, 123456);
    int number = (int) LuaScriptMgr.GetNumber(luaState, -1);
    this.func.EndPCall(oldTop);
    return number;
  }

  private void Update()
  {
  }
}
