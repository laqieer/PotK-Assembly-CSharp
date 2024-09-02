// Decompiled with JetBrains decompiler
// Type: HelloWorld
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
