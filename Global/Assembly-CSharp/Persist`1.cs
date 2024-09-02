// Decompiled with JetBrains decompiler
// Type: Persist`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using GameCore.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using UniLinq;

#nullable disable
public class Persist<T> where T : new()
{
  public string fileName;
  public object value;
  private static HashSet<char> permitChars = new HashSet<char>((IEnumerable<char>) "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_-.");

  public Persist(string fileName) => this.fileName = fileName;

  private static string Sanitize(string str)
  {
    return str.Select<char, char>((Func<char, char>) (c => Persist<T>.permitChars.Contains(c) ? c : '_')).ToStringForChars();
  }

  public string FilePath => Path.Combine(PersistentPath.Value, Persist<T>.Sanitize(this.fileName));

  public string FileFallbackPath
  {
    get => Path.Combine(PersistentPath.Fallback, Persist<T>.Sanitize(this.fileName));
  }

  public bool Exists => File.Exists(this.FilePath);

  public void Delete()
  {
    if (!File.Exists(this.FilePath))
      return;
    File.Delete(this.FilePath);
  }

  public void Clear() => this.value = (object) null;

  public T Data
  {
    get
    {
      if (this.value == null)
        this.value = (EasySerializer.DeserializeObjectFromFile(this.FilePath) ?? EasySerializer.DeserializeObjectFromFile(this.FileFallbackPath)) ?? (object) new T();
      return (T) this.value;
    }
    set => this.value = (object) value;
  }

  public void Flush() => EasySerializer.SerializeObjectToFile((object) this.Data, this.FilePath);
}
