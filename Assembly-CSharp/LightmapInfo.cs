// Decompiled with JetBrains decompiler
// Type: LightmapInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

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
