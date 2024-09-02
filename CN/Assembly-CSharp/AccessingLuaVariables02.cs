// Decompiled with JetBrains decompiler
// Type: AccessingLuaVariables02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System.Collections;
using UnityEngine;

#nullable disable
public class AccessingLuaVariables02 : MonoBehaviour
{
  private string var = "Objs2Spawn = 0";
  private string script = "            \r\n            particles = {}\r\n\r\n            for i = 1, Objs2Spawn, 1 do\r\n                local newGameObj = GameObject('NewObj' .. tostring(i))\r\n                local ps = newGameObj:AddComponent('ParticleSystem')\r\n                ps:Stop()\r\n\r\n                table.insert(particles, ps)\r\n            end\r\n\r\n            var2read = 42\r\n        ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    LuaState lua = luaScriptMgr.lua;
    lua.DoString(this.var);
    lua["Objs2Spawn"] = (object) 5;
    lua.DoString(this.script);
    MonoBehaviour.print((object) ("Read from lua: " + lua["var2read"].ToString()));
    foreach (ParticleSystem particleSystem in (IEnumerable) ((LuaTable) lua["particles"]).Values)
      particleSystem.Play();
  }

  private void Update()
  {
  }
}
