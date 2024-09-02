// Decompiled with JetBrains decompiler
// Type: StorageUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class StorageUtil
{
  private static readonly string m_persistentDataPath = Application.persistentDataPath;
  private static readonly string m_temporaryCachePath = Application.temporaryCachePath;

  public static string persistentDataPath => StorageUtil.m_persistentDataPath;

  public static string temporaryCachePath => StorageUtil.m_temporaryCachePath;
}
