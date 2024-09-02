// Decompiled with JetBrains decompiler
// Type: ScriptsFromFile_02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
