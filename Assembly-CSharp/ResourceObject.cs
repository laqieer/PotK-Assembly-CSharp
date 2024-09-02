// Decompiled with JetBrains decompiler
// Type: ResourceObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

public class ResourceObject
{
  private string path;

  public ResourceObject(string path) => this.path = path;

  public Future<T> Load<T>() where T : UnityEngine.Object => Singleton<ResourceManager>.GetInstance().Load<T>(this.path);

  public Future<T> Load<T>(System.Action<T> callback) where T : UnityEngine.Object => Singleton<ResourceManager>.GetInstance().Load<T>(this.path, callback);
}
