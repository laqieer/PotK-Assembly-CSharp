// Decompiled with JetBrains decompiler
// Type: CreateGameObject01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
