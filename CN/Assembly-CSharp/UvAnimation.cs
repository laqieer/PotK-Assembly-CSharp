// Decompiled with JetBrains decompiler
// Type: UvAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (MeshRenderer))]
public class UvAnimation : MonoBehaviour
{
  [SerializeField]
  private Vector2 mainOffset;
  [SerializeField]
  private Vector2 maskOffset;
  private Material mat;

  private void Start()
  {
    this.mat = ((Renderer) ((Component) this).GetComponent<MeshRenderer>()).materials[0];
  }

  private void Update()
  {
    this.mat.SetTextureOffset("_MainTex", this.mainOffset);
    this.mat.SetTextureOffset("_Mask", this.maskOffset);
  }
}
