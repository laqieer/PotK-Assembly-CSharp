// Decompiled with JetBrains decompiler
// Type: LuaEnum
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LuaEnum : MonoBehaviour
{
  private const string source = "\r\n        local type = LuaEnumType.IntToEnum(1);\r\n        print(type == LuaEnumType.AAA);\r\n    ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    luaScriptMgr.lua.DoString("\r\n        local type = LuaEnumType.IntToEnum(1);\r\n        print(type == LuaEnumType.AAA);\r\n    ");
  }
}
