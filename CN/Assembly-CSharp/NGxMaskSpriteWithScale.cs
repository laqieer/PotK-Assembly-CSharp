// Decompiled with JetBrains decompiler
// Type: NGxMaskSpriteWithScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
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

  public void Start()
  {
    if (!Object.op_Inequality((Object) this.MainUI2DSprite, (Object) null) || !Object.op_Inequality((Object) this.MainUI2DSprite.material, (Object) null))
      return;
    this.FitMask();
  }

  private void setMask() => this.maskTexture = this._maskTexture;

  private void Update()
  {
    if (Object.op_Equality((Object) this.MainUI2DSprite, (Object) null))
      return;
    Material material = this.MainUI2DSprite.material;
    if (Object.op_Equality((Object) material, (Object) null))
      return;
    if ((double) this.beforeXOffsetPixelForAnimation != (double) this.xOffsetPixelForAnimation || (double) this.beforeYOffsetPixelForAnimation != (double) this.yOffsetPixelForAnimation)
      this.FitMask();
    Color color = this.MainUI2DSprite.color;
    color.a *= this.MainUI2DSprite.finalAlpha;
    if (!Color.op_Inequality(this.beforeColor, color))
      return;
    material.SetColor("_Color", color);
    this.beforeColor = color;
    this.MainUI2DSprite.material = (Material) null;
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
    if (Object.op_Equality((Object) this.MainUI2DSprite.mainTexture, (Object) null))
    {
      Debug.LogWarning((object) ("mainTexture is null " + ((Object) ((Component) this).gameObject).name));
    }
    else
    {
      if (Object.op_Equality((Object) this.maskTexture, (Object) null))
        return;
      if (this.enableMask)
      {
        this.MainUI2DSprite.width = ((Texture) this.maskTexture).width;
        this.MainUI2DSprite.height = ((Texture) this.maskTexture).height;
      }
      else
      {
        this.MainUI2DSprite.width = this.MainUI2DSprite.mainTexture.width;
        this.MainUI2DSprite.height = this.MainUI2DSprite.mainTexture.height;
      }
      NGxMaskSpriteWithScale maskSpriteWithScale = this;
      float width1 = (float) this.MainUI2DSprite.width;
      float height1 = (float) this.MainUI2DSprite.height;
      float width2 = (float) this.MainUI2DSprite.mainTexture.width;
      float height2 = (float) this.MainUI2DSprite.mainTexture.height;
      float num1 = height2 / height1;
      float num2 = width2 / width1;
      float num3 = Mathf.Max(num1, num2);
      float num4 = Mathf.Min(num1, num2);
      float num5 = num1 / num3 / num4 / maskSpriteWithScale.scale;
      float num6 = num2 / num3 / num4 / maskSpriteWithScale.scale;
      float num7 = ((float) maskSpriteWithScale.xOffsetPixel + this.xOffsetPixelForAnimation) / width2;
      float num8 = ((float) maskSpriteWithScale.yOffsetPixel + this.yOffsetPixelForAnimation) / height2;
      if (maskSpriteWithScale.isTopFit)
      {
        maskSpriteWithScale.topOffset = (float) (((double) height1 * (double) num4 - (double) height1) / (double) height2 / 2.0);
        num8 += maskSpriteWithScale.topOffset;
      }
      else
        maskSpriteWithScale.topOffset = 0.0f;
      float num9 = num7 - (float) (((double) num5 - 1.0) / 2.0);
      float num10 = num8 - (float) (((double) num6 - 1.0) / 2.0);
      string str = string.Format("dynamic {0}x{1} x({2}) y({3})", (object) num5, (object) num6, (object) num9, (object) num10);
      if (!Object.op_Equality((Object) this.MainUI2DSprite, (Object) null) && !Object.op_Equality((Object) this.MainUI2DSprite.material, (Object) null) && !(str != ((Object) this.MainUI2DSprite.material).name) && !Object.op_Inequality((Object) this.lastMaskTexture, (Object) this.maskTexture))
        return;
      Material material = !this.isMultiMaskColor ? new Material(Shader.Find("Unlit/AlphaMask")) : new Material(Shader.Find("Unlit/AlphaMaskMultiColor"));
      ((Object) material).name = str;
      material.SetTexture("_MaskTex", (Texture) maskSpriteWithScale.maskTexture);
      material.SetFloat("_xScale", num5);
      material.SetFloat("_yScale", num6);
      material.SetFloat("_xOffset", num9);
      material.SetFloat("_yOffset", num10);
      this.MainUI2DSprite.material = material;
      this.MainUI2DSprite.mainTexture.wrapMode = (TextureWrapMode) 1;
      this.lastMaskTexture = this.maskTexture;
      this.beforeXOffsetPixelForAnimation = this.xOffsetPixelForAnimation;
      this.beforeYOffsetPixelForAnimation = this.yOffsetPixelForAnimation;
    }
  }
}
