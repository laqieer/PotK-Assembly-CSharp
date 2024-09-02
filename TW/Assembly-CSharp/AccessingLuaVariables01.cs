// Decompiled with JetBrains decompiler
// Type: AccessingLuaVariables01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System.Collections;
using UnityEngine;

#nullable disable
public class AccessingLuaVariables01 : MonoBehaviour
{
  private string script = "\r\n            luanet.load_assembly('UnityEngine')\r\n            GameObject = luanet.import_type('UnityEngine.GameObject')\r\n\r\n            particles = {}\r\n\r\n            for i = 1, Objs2Spawn, 1 do\r\n                local newGameObj = GameObject('NewObj' .. tostring(i))\r\n                local ps = newGameObj:AddComponent('ParticleSystem')\r\n                ps:Stop()\r\n\r\n                table.insert(particles, ps)\r\n            end\r\n\r\n            var2read = 42\r\n        ";

  private void Start()
  {
    LuaState luaState = new LuaState();
    luaState["Objs2Spawn"] = (object) 5;
    luaState.DoString(this.script);
    MonoBehaviour.print((object) ("Read from lua: " + luaState["var2read"].ToString()));
    foreach (ParticleSystem particleSystem in (IEnumerable) ((LuaTable) luaState["particles"]).Values)
      particleSystem.Play();
  }

  private void Update()
  {
  }
}
