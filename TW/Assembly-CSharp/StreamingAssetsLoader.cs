// Decompiled with JetBrains decompiler
// Type: StreamingAssetsLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using gu3.Utils;
using System;
using System.IO;
using UnityEngine;

#nullable disable
internal class StreamingAssetsLoader : IResourceLoader
{
  private const int GC_LOADED_BYTE_SIZE = 1048576;

  public Future<Object> Load(string path, ref ResourceInfo.Resource context)
  {
    return Future.Single<Object>(this.LoadImmediatelyForSmallObject(path, ref context));
  }

  public Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context)
  {
    if (context._value._type != (byte) 0 && context._value._type != (byte) 3)
    {
      Debug.LogError((object) ("Unknown type: " + context._value.GetTypeName()));
      return (Object) null;
    }
    bool compressed = context._value._compressed;
    byte[] bytes = File.ReadAllBytes(DLC.ResourceFullPath(context._value._file_name));
    if (compressed)
    {
      int skip = 67;
      ushort width = context._value._width;
      ushort height = context._value._height;
      byte[] numArray;
      try
      {
        numArray = ResourceLoadHelper.Decompress(bytes, ZlibFormat.Deflate, skip);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) string.Format("Load Compressed Texture: {0}, {1}, {2}x{3}", (object) ex.ToString(), (object) path, (object) width, (object) height));
        throw;
      }
      TextureFormat textureFormat = (TextureFormat) 34;
      Texture2D texture2D = new Texture2D((int) width, (int) height, textureFormat, false, true);
      ((Texture) texture2D).wrapMode = (TextureWrapMode) 1;
      texture2D.LoadRawTextureData(numArray);
      texture2D.Apply(false, true);
      ((Object) texture2D).name = path + " (compressed)";
      return (Object) texture2D;
    }
    Texture2D texture2D1 = new Texture2D(4, 4, (TextureFormat) 5, false, true);
    ((Texture) texture2D1).wrapMode = (TextureWrapMode) 1;
    if (!texture2D1.LoadImage(bytes))
      Debug.LogError((object) ("Failed LoadImage: " + path));
    texture2D1.Apply(false, true);
    ((Object) texture2D1).name = path;
    return (Object) texture2D1;
  }
}
