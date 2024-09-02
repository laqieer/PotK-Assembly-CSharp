// Decompiled with JetBrains decompiler
// Type: IResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
internal interface IResourceLoader
{
  Future<Object> Load(string path, ref ResourceInfo.Resource context);

  Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context);
}
