// Decompiled with JetBrains decompiler
// Type: IResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
internal interface IResourceLoader
{
  Future<Object> Load(string path, ref ResourceInfo.Resource context);

  Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context);
}
