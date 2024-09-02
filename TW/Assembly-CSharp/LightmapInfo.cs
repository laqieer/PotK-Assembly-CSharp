// Decompiled with JetBrains decompiler
// Type: LightmapInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class LightmapInfo : MonoBehaviour
{
  public LightmapInfo.Info[] infos;

  [Serializable]
  public class Info
  {
    public string name;
    public Vector4 lightmapScaleOffset;
  }
}
