// Decompiled with JetBrains decompiler
// Type: UvAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (MeshRenderer))]
public class UvAnimation : MonoBehaviour
{
  [SerializeField]
  private Vector2 mainOffset;
  [SerializeField]
  private Vector2 maskOffset;
  private UnityEngine.Material mat;

  private void Start() => this.mat = this.GetComponent<MeshRenderer>().materials[0];

  private void Update()
  {
    this.mat.SetTextureOffset("_MainTex", this.mainOffset);
    this.mat.SetTextureOffset("_Mask", this.maskOffset);
  }
}
