// Decompiled with JetBrains decompiler
// Type: CreateGameObject02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
