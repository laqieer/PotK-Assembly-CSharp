// Decompiled with JetBrains decompiler
// Type: PersistentPath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class PersistentPath
{
  public static string Value
  {
    get
    {
      string empty = string.Empty;
      return Application.persistentDataPath;
    }
  }
}
