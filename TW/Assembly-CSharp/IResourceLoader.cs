// Decompiled with JetBrains decompiler
// Type: IResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
internal interface IResourceLoader
{
  Future<Object> Load(string path, ref ResourceInfo.Resource context);

  Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context);
}
