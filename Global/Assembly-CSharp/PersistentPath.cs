// Decompiled with JetBrains decompiler
// Type: PersistentPath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class PersistentPath
{
  public static string Fallback
  {
    get => string.Format("/data/data/{0}/files/", (object) Application.bundleIdentifier);
  }

  public static string Value
  {
    get
    {
      string empty = string.Empty;
      return Application.persistentDataPath;
    }
  }
}
