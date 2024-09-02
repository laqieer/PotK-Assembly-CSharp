// Decompiled with JetBrains decompiler
// Type: NGxMaskSpriteWithScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UI2DSprite))]
public class NGxMaskSpriteWithScale : MonoBehaviour
{
  [SerializeField]
  private Texture2D _maskTexture;
  public UI2DSprite MainUI2DSprite;
  public bool isMultiMaskColor;
  private Texture2D maskTextureTemp;
  private Texture2D lastMaskTexture;
  private bool enableMask = true;
  public int xOffsetPixel;
  public int yOffsetPixel;
  public float scale = 1f;
  public bool isTopFit;
  [HideInInspector]
  public float topOffset;
  private Color beforeColor = Color.white;
  [SerializeField]
  private float xOffsetPixelForAnimation;
  [SerializeField]
  private float yOffsetPixelForAnimation;
  private float beforeXOffsetPixelForAnimation;
  private float beforeYOffsetPixelForAnimation;

  public Texture2D maskTexture
  {
    get => this._maskTexture;
    set
    {
      this._maskTexture = value;
      this.maskTextureTemp = this._maskTexture;
      this.FitMask();
    }
  }

  public float spriteAlpha => (Object) this.MainUI2DSprite != (Object) null ? this.MainUI2DSprite.color.a * this.MainUI2DSprite.finalAlpha : 0.0f;

  public void Start()
  {
    if (!((Object) this.MainUI2DSprite != (Object) null) || !((Object) this.MainUI2DSprite.material != (Object) null))
      return;
    this.FitMask();
  }

  private void setMask() => this.maskTexture = this._maskTexture;

  private void Update()
  {
    if ((Object) this.MainUI2DSprite == (Object) null)
      return;
    UnityEngine.Material material = this.MainUI2DSprite.material;
    if ((Object) material == (Object) null)
      return;
    if ((double) this.beforeXOffsetPixelForAnimation != (double) this.xOffsetPixelForAnimation || (double) this.beforeYOffsetPixelForAnimation != (double) this.yOffsetPixelForAnimation)
      this.FitMask();
    Color color = this.MainUI2DSprite.color;
    color.a *= this.MainUI2DSprite.finalAlpha;
    if (!(this.beforeColor != color))
      return;
    material.SetColor("_Color", color);
    this.beforeColor = color;
    this.MainUI2DSprite.material = (UnityEngine.Material) null;
    this.MainUI2DSprite.material = material;
    this.MainUI2DSprite.SetDirty();
  }

  public void SetMaskEnable(bool enable)
  {
    this.enableMask = enable;
    this._maskTexture = !enable ? Resources.Load<Texture2D>("sprites/1x1_black") : this.maskTextureTemp;
    this.FitMask();
  }

  public void FitMask()
  {
    if ((Object) this.MainUI2DSprite.mainTexture == (Object) null || (Object) this.maskTexture == (Object) null)
      return;
    if (this.enableMask)
    {
      this.MainUI2DSprite.SetDimensions(this.maskTexture.width, this.maskTexture.height);
    }
    else
    {
      Texture mainTexture = this.MainUI2DSprite.mainTexture;
      this.MainUI2DSprite.SetDimensions(mainTexture.width, mainTexture.height);
    }
    float width1 = (float) this.MainUI2DSprite.width;
    float height1 = (float) this.MainUI2DSprite.height;
    float width2 = (float) this.MainUI2DSprite.mainTexture.width;
    float height2 = (float) this.MainUI2DSprite.mainTexture.height;
    double num1 = (double) height2 / (double) height1;
    float b = width2 / width1;
    float num2 = Mathf.Max((float) num1, b);
    float num3 = Mathf.Min((float) num1, b);
    float num4 = (float) num1 / num2 / num3 / this.scale;
    float num5 = b / num2 / num3 / this.scale;
    float num6 = ((float) this.xOffsetPixel + this.xOffsetPixelForAnimation) / width2;
    float num7 = ((float) this.yOffsetPixel + this.yOffsetPixelForAnimation) / height2;
    if (this.isTopFit)
    {
      this.topOffset = (float) (((double) height1 * (double) num3 - (double) height1) / 2.0);
      num7 += this.topOffset / height2;
    }
    else
      this.topOffset = 0.0f;
    float num8 = num6 - (float) (((double) num4 - 1.0) / 2.0);
    float num9 = num7 - (float) (((double) num5 - 1.0) / 2.0);
    string str1 = string.Empty;
    if ((Object) this.MainUI2DSprite.panel != (Object) null)
    {
      switch (this.MainUI2DSprite.panel.clipping)
      {
        case UIDrawCall.Clipping.AlphaClip:
          str1 = " (AlphaClip)";
          break;
        case UIDrawCall.Clipping.SoftClip:
          str1 = " (SoftClip)";
          break;
      }
    }
    string str2 = string.Format("dynamic {0}x{1} x({2}) y({3}){4}", (object) num4, (object) num5, (object) num8, (object) num9, (object) str1);
    if (!((Object) this.MainUI2DSprite.material == (Object) null) && !((Object) this.lastMaskTexture != (Object) this.maskTexture) && !(str2 != this.MainUI2DSprite.material.name))
      return;
    UnityEngine.Material material = new UnityEngine.Material(UnityEngine.Shader.Find(string.Format("Unlit/{0}{1}", this.isMultiMaskColor ? (object) "AlphaMaskMultiColor" : (object) "AlphaMask", (object) str1)));
    material.name = str2;
    material.SetTexture("_MaskTex", (Texture) this.maskTexture);
    material.SetFloat("_xScale", num4);
    material.SetFloat("_yScale", num5);
    material.SetFloat("_xOffset", num8);
    material.SetFloat("_yOffset", num9);
    this.MainUI2DSprite.material = material;
    this.MainUI2DSprite.mainTexture.wrapMode = TextureWrapMode.Clamp;
    this.lastMaskTexture = this.maskTexture;
    this.beforeXOffsetPixelForAnimation = this.xOffsetPixelForAnimation;
    this.beforeYOffsetPixelForAnimation = this.yOffsetPixelForAnimation;
    this.MainUI2DSprite.MarkAsChanged();
  }
}
