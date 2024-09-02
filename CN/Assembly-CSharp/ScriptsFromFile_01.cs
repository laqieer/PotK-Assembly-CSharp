// Decompiled with JetBrains decompiler
// Type: ScriptsFromFile_01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class ScriptsFromFile_01 : MonoBehaviour
{
  public TextAsset scriptFile;

  private void Start() => new LuaState().DoString(this.scriptFile.text);

  private void Update()
  {
  }
}
