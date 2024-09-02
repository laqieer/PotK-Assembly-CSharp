// Decompiled with JetBrains decompiler
// Type: LightmapInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
