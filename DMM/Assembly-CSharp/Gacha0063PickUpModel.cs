// Decompiled with JetBrains decompiler
// Type: Gacha0063PickUpModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Gacha0063PickUpModel : MonoBehaviour
{
  [SerializeField]
  private Camera model_camera_;

  public RenderTexture GetTargetTexture()
  {
    if ((Object) this.model_camera_.targetTexture == (Object) null)
    {
      this.model_camera_.targetTexture = new RenderTexture(256, 256, 16);
      this.model_camera_.targetTexture.antiAliasing = 2;
      this.model_camera_.targetTexture.wrapMode = TextureWrapMode.Clamp;
      this.model_camera_.targetTexture.filterMode = FilterMode.Bilinear;
      this.model_camera_.targetTexture.enableRandomWrite = false;
      this.model_camera_.enabled = true;
    }
    return this.model_camera_.targetTexture;
  }
}
