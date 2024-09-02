// Decompiled with JetBrains decompiler
// Type: StreamingAssetsLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.IO;
using UnityEngine;

internal class StreamingAssetsLoader : IResourceLoader
{
  private const int GC_LOADED_BYTE_SIZE = 1048576;

  public Future<Object> Load(string path, ref ResourceInfo.Resource context) => Future.Single<Object>(this.LoadImmediatelyForSmallObject(path, ref context));

  public Future<Object> DownloadOrCache(string path, ref ResourceInfo.Resource context) => Future.Single<Object>(this.LoadImmediatelyForSmallObject(path, ref context));

  public Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context)
  {
    if (context._value._object_type != ResourceInfo.ObjectType.None && context._value._object_type != ResourceInfo.ObjectType.Texture2D)
    {
      Debug.LogError((object) ("Unknown type: " + context._value._object_type.ToString()));
      return (Object) null;
    }
    Texture2D tex = new Texture2D(4, 4, TextureFormat.ARGB32, false, true);
    tex.wrapMode = TextureWrapMode.Clamp;
    byte[] numArray = new byte[0];
    if (!tex.LoadImage(!Persist.fileMoved.Data.isAllMoved ? File.ReadAllBytes(DLC.ResourceDirectory + context._value._file_name) : File.ReadAllBytes(DLC.GetPath(context._value._file_name))))
      Debug.LogError((object) ("Failed LoadImage: " + path));
    tex.Apply(false, true);
    tex.name = path;
    return (Object) tex;
  }
}
