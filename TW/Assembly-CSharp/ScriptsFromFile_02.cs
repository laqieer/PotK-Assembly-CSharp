// Decompiled with JetBrains decompiler
// Type: ScriptsFromFile_02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class ScriptsFromFile_02 : MonoBehaviour
{
  private void Start()
  {
    new LuaState().DoFile(Application.dataPath + "/uLua/Examples/04_ScriptsFromFile/ScriptsFromFile02.lua");
  }

  private void Update()
  {
  }
}
