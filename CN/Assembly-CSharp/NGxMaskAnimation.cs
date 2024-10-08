﻿// Decompiled with JetBrains decompiler
// Type: NGxMaskAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
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
  private Material material;

  private void Awake()
  {
    this.xOffset = 0.0f;
    this.ui2dSprite = ((Component) this).GetComponent<UI2DSprite>();
    this.spriteRender = ((Component) this).GetComponent<SpriteRenderer>();
    this.xOffsetClamp = Mathf.Abs(this.xOffsetMin) + Mathf.Abs(this.xOffsetMax);
    this.material = !Object.op_Implicit((Object) this.ui2dSprite) ? ((Renderer) this.spriteRender).material : this.ui2dSprite.material;
    this.material.mainTexture = !Object.op_Implicit((Object) this.ui2dSprite) ? (Texture) this.spriteRender.sprite.texture : (Texture) this.ui2dSprite.sprite2D.texture;
    this.material.SetTexture("_MaskTex", (Texture) this.maskTexture);
    this.material.SetFloat("_xOffset", 0.0f);
  }

  private void Update()
  {
    this.xOffset = (this.xOffset + Time.deltaTime * this.speed) % this.xOffsetClamp;
    this.material.SetFloat("_xOffset", this.xOffset + this.xOffsetMin);
    if (Object.op_Implicit((Object) this.ui2dSprite))
    {
      this.ui2dSprite.material = (Material) null;
      this.ui2dSprite.material = this.material;
    }
    else
      ((Renderer) this.spriteRender).sharedMaterial = this.material;
  }
}
