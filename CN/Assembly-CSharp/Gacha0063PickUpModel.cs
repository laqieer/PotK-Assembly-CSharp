// Decompiled with JetBrains decompiler
// Type: Gacha0063PickUpModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Gacha0063PickUpModel : MonoBehaviour
{
  [SerializeField]
  private Camera model_camera_;

  public RenderTexture GetTargetTexture()
  {
    if (Object.op_Equality((Object) this.model_camera_.targetTexture, (Object) null))
    {
      this.model_camera_.targetTexture = new RenderTexture(256, 256, 16);
      this.model_camera_.targetTexture.antiAliasing = 2;
      ((Texture) this.model_camera_.targetTexture).wrapMode = (TextureWrapMode) 1;
      ((Texture) this.model_camera_.targetTexture).filterMode = (FilterMode) 1;
      this.model_camera_.targetTexture.enableRandomWrite = false;
      ((Behaviour) this.model_camera_).enabled = true;
    }
    return this.model_camera_.targetTexture;
  }
}
