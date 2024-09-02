// Decompiled with JetBrains decompiler
// Type: ClipEventEffectData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ClipEventEffectData : ScriptableObject
{
  public List<ClipEventEffectData.EffectData> dataList;

  public ClipEventEffectData() => this.dataList = new List<ClipEventEffectData.EffectData>();

  [Serializable]
  public class EffectData
  {
    public string effect_name = string.Empty;
    public string parent = string.Empty;
    public bool is_local_postion;
    public bool is_add_bip;
    public Vector3 position = Vector3.zero;
    public bool is_local_rotation;
    public Vector3 rotation = Vector3.zero;
  }
}
