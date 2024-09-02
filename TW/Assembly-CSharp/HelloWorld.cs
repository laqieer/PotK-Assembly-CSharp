// Decompiled with JetBrains decompiler
// Type: HelloWorld
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using UnityEngine;

#nullable disable
public class HelloWorld : MonoBehaviour
{
  private void Start() => new LuaState().DoString("print('hello world 世界')");

  private void Update()
  {
  }
}
