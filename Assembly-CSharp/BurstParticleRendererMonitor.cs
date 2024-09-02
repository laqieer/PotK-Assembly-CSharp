// Decompiled with JetBrains decompiler
// Type: BurstParticleRendererMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BurstParticleRendererMonitor : MonoBehaviour
{
  private static Dictionary<string, UnityEngine.Material> originalMaterial;
  [SerializeField]
  private string materialPath;

  private void Start()
  {
    if (BurstParticleRendererMonitor.originalMaterial == null)
      BurstParticleRendererMonitor.originalMaterial = new Dictionary<string, UnityEngine.Material>();
    if (!BurstParticleRendererMonitor.originalMaterial.ContainsKey(this.materialPath))
      BurstParticleRendererMonitor.originalMaterial.Add(this.materialPath, new UnityEngine.Material(Resources.Load<UnityEngine.Material>(this.materialPath)));
    this.GetComponent<Renderer>().material = BurstParticleRendererMonitor.originalMaterial[this.materialPath];
  }
}
