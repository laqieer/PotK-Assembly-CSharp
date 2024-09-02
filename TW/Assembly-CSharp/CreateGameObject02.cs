// Decompiled with JetBrains decompiler
// Type: CreateGameObject02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreateGameObject02 : MonoBehaviour
{
  private string script = "\r\n            luanet.load_assembly('UnityEngine')\r\n            GameObject = UnityEngine.GameObject\r\n            ParticleSystem = UnityEngine.ParticleSystem\r\n            local newGameObj = GameObject('NewObj')\r\n            newGameObj:AddComponent(ParticleSystem.GetClassType())\r\n        ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    luaScriptMgr.DoString(this.script);
  }

  private void Update()
  {
  }
}
