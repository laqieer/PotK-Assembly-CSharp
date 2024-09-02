// Decompiled with JetBrains decompiler
// Type: PartsContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class PartsContainer : MonoBehaviour
{
  [SerializeField]
  private PartsContainer.PartSprite[] partsSprite_;
  [SerializeField]
  private PartsContainer.PartMaterial[] partsMaterial_;

  public Dictionary<string, UnityEngine.Sprite> partsSprite => this.partsSprite_ == null ? new Dictionary<string, UnityEngine.Sprite>() : ((IEnumerable<PartsContainer.PartSprite>) this.partsSprite_).ToDictionary<PartsContainer.PartSprite, string, UnityEngine.Sprite>((Func<PartsContainer.PartSprite, string>) (k => k.name), (Func<PartsContainer.PartSprite, UnityEngine.Sprite>) (v => v.sprite));

  public Dictionary<string, UnityEngine.Material> partsMaterial => this.partsMaterial_ == null ? new Dictionary<string, UnityEngine.Material>() : ((IEnumerable<PartsContainer.PartMaterial>) this.partsMaterial_).ToDictionary<PartsContainer.PartMaterial, string, UnityEngine.Material>((Func<PartsContainer.PartMaterial, string>) (k => k.name), (Func<PartsContainer.PartMaterial, UnityEngine.Material>) (v => v.material));

  [Serializable]
  public class PartSprite
  {
    public string name = string.Empty;
    public UnityEngine.Sprite sprite;
  }

  [Serializable]
  public class PartMaterial
  {
    public string name = string.Empty;
    public UnityEngine.Material material;
  }
}
