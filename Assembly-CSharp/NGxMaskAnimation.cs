// Decompiled with JetBrains decompiler
// Type: NGxMaskAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NGxMaskAnimation : MonoBehaviour
{
  public Texture2D maskTexture;
  public float xOffsetMin = -1f;
  public float xOffsetMax = 2f;
  public float speed = 1f;
  private float xOffsetClamp;
  private float xOffset;
  private UI2DSprite ui2dSprite;
  private SpriteRenderer spriteRender;
  private UnityEngine.Material material;

  private void Awake()
  {
    this.xOffset = 0.0f;
    this.ui2dSprite = this.GetComponent<UI2DSprite>();
    this.spriteRender = this.GetComponent<SpriteRenderer>();
    this.xOffsetClamp = Mathf.Abs(this.xOffsetMin) + Mathf.Abs(this.xOffsetMax);
    this.material = (bool) (Object) this.ui2dSprite ? this.ui2dSprite.material : this.spriteRender.material;
    this.material.mainTexture = (bool) (Object) this.ui2dSprite ? (Texture) this.ui2dSprite.sprite2D.texture : (Texture) this.spriteRender.sprite.texture;
    this.material.SetTexture("_MaskTex", (Texture) this.maskTexture);
    this.material.SetFloat("_xOffset", 0.0f);
  }

  private void Update()
  {
    this.xOffset = (this.xOffset + Time.deltaTime * this.speed) % this.xOffsetClamp;
    this.material.SetFloat("_xOffset", this.xOffset + this.xOffsetMin);
    if ((bool) (Object) this.ui2dSprite)
    {
      this.ui2dSprite.material = (UnityEngine.Material) null;
      this.ui2dSprite.material = this.material;
    }
    else
      this.spriteRender.sharedMaterial = this.material;
  }
}
