// Decompiled with JetBrains decompiler
// Type: CreateGameObject01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class CreateGameObject01 : MonoBehaviour
{
  private string script = "\r\n            luanet.load_assembly('UnityEngine')\r\n            GameObject = luanet.import_type('UnityEngine.GameObject')        \r\n\t    ParticleSystem = luanet.import_type('UnityEngine.ParticleSystem')            \r\n            local newGameObj = GameObject('NewObj')\r\n            newGameObj:AddComponent(luanet.ctype(ParticleSystem))\r\n        ";

  private void Start() => new LuaState().DoString(this.script);

  private void Update()
  {
  }
}
