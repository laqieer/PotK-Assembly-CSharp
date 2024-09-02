// Decompiled with JetBrains decompiler
// Type: UISprite
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/NGUI Sprite")]
[ExecuteInEditMode]
public class UISprite : UIWidget
{
  [SerializeField]
  [HideInInspector]
  private UIAtlas mAtlas;
  [SerializeField]
  [HideInInspector]
  private string mSpriteName;
  [HideInInspector]
  [SerializeField]
  private UISprite.Type mType;
  [HideInInspector]
  [SerializeField]
  private UISprite.FillDirection mFillDirection = UISprite.FillDirection.Radial360;
  [HideInInspector]
  [SerializeField]
  [Range(0.0f, 1f)]
  private float mFillAmount = 1f;
  [SerializeField]
  [HideInInspector]
  private bool mInvert;
  [HideInInspector]
  [SerializeField]
  private UISprite.Flip mFlip;
  [HideInInspector]
  [SerializeField]
  private bool mFillCenter = true;
  protected UISpriteData mSprite;
  protected Rect mInnerUV = new Rect();
  protected Rect mOuterUV = new Rect();
  private bool mSpriteSet;
  public UISprite.AdvancedType centerType = UISprite.AdvancedType.Sliced;
  public UISprite.AdvancedType leftType = UISprite.AdvancedType.Sliced;
  public UISprite.AdvancedType rightType = UISprite.AdvancedType.Sliced;
  public UISprite.AdvancedType bottomType = UISprite.AdvancedType.Sliced;
  public UISprite.AdvancedType topType = UISprite.AdvancedType.Sliced;
  private static Vector2[] mTempPos = new Vector2[4];
  private static Vector2[] mTempUVs = new Vector2[4];

  public virtual UISprite.Type type
  {
    get => this.mType;
    set
    {
      if (this.mType == value)
        return;
      this.mType = value;
      this.MarkAsChanged();
    }
  }

  public override Material material
  {
    get
    {
      return Object.op_Inequality((Object) this.mAtlas, (Object) null) ? this.mAtlas.spriteMaterial : (Material) null;
    }
  }

  public UIAtlas atlas
  {
    get => this.mAtlas;
    set
    {
      if (!Object.op_Inequality((Object) this.mAtlas, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mAtlas = value;
      this.mSpriteSet = false;
      this.mSprite = (UISpriteData) null;
      if (string.IsNullOrEmpty(this.mSpriteName) && Object.op_Inequality((Object) this.mAtlas, (Object) null) && this.mAtlas.spriteList.Count > 0)
      {
        this.SetAtlasSprite(this.mAtlas.spriteList[0]);
        this.mSpriteName = this.mSprite.name;
      }
      if (string.IsNullOrEmpty(this.mSpriteName))
        return;
      string mSpriteName = this.mSpriteName;
      this.mSpriteName = string.Empty;
      this.spriteName = mSpriteName;
      this.MarkAsChanged();
    }
  }

  public string spriteName
  {
    get => this.mSpriteName;
    set
    {
      if (string.IsNullOrEmpty(value))
      {
        if (string.IsNullOrEmpty(this.mSpriteName))
          return;
        this.mSpriteName = string.Empty;
        this.mSprite = (UISpriteData) null;
        this.mChanged = true;
        this.mSpriteSet = false;
      }
      else
      {
        if (!(this.mSpriteName != value))
          return;
        this.mSpriteName = value;
        this.mSprite = (UISpriteData) null;
        this.mChanged = true;
        this.mSpriteSet = false;
      }
    }
  }

  public bool isValid => this.GetAtlasSprite() != null;

  [Obsolete("Use 'centerType' instead")]
  public bool fillCenter
  {
    get => this.centerType != UISprite.AdvancedType.Invisible;
    set
    {
      if (value == (this.centerType != UISprite.AdvancedType.Invisible))
        return;
      this.centerType = !value ? UISprite.AdvancedType.Invisible : UISprite.AdvancedType.Sliced;
      this.MarkAsChanged();
    }
  }

  public UISprite.FillDirection fillDirection
  {
    get => this.mFillDirection;
    set
    {
      if (this.mFillDirection == value)
        return;
      this.mFillDirection = value;
      this.mChanged = true;
    }
  }

  public float fillAmount
  {
    get => this.mFillAmount;
    set
    {
      float num = Mathf.Clamp01(value);
      if ((double) this.mFillAmount == (double) num)
        return;
      this.mFillAmount = num;
      this.mChanged = true;
    }
  }

  public bool invert
  {
    get => this.mInvert;
    set
    {
      if (this.mInvert == value)
        return;
      this.mInvert = value;
      this.mChanged = true;
    }
  }

  public override Vector4 border
  {
    get
    {
      if (this.type != UISprite.Type.Sliced && this.type != UISprite.Type.Advanced)
        return base.border;
      UISpriteData atlasSprite = this.GetAtlasSprite();
      return atlasSprite == null ? Vector4.op_Implicit(Vector2.zero) : new Vector4((float) atlasSprite.borderLeft, (float) atlasSprite.borderBottom, (float) atlasSprite.borderRight, (float) atlasSprite.borderTop);
    }
  }

  public override int minWidth
  {
    get
    {
      if (this.type != UISprite.Type.Sliced && this.type != UISprite.Type.Advanced)
        return base.minWidth;
      Vector4 vector4 = this.border;
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector4 = Vector4.op_Multiply(vector4, this.atlas.pixelSize);
      int num = Mathf.RoundToInt(vector4.x + vector4.z);
      UISpriteData atlasSprite = this.GetAtlasSprite();
      if (atlasSprite != null)
        num += atlasSprite.paddingLeft + atlasSprite.paddingRight;
      return Mathf.Max(base.minWidth, (num & 1) != 1 ? num : num + 1);
    }
  }

  public override int minHeight
  {
    get
    {
      if (this.type != UISprite.Type.Sliced && this.type != UISprite.Type.Advanced)
        return base.minHeight;
      Vector4 vector4 = this.border;
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector4 = Vector4.op_Multiply(vector4, this.atlas.pixelSize);
      int num = Mathf.RoundToInt(vector4.y + vector4.w);
      UISpriteData atlasSprite = this.GetAtlasSprite();
      if (atlasSprite != null)
        num += atlasSprite.paddingTop + atlasSprite.paddingBottom;
      return Mathf.Max(base.minHeight, (num & 1) != 1 ? num : num + 1);
    }
  }

  public UISpriteData GetAtlasSprite()
  {
    if (!this.mSpriteSet)
      this.mSprite = (UISpriteData) null;
    if (this.mSprite == null && Object.op_Inequality((Object) this.mAtlas, (Object) null))
    {
      if (!string.IsNullOrEmpty(this.mSpriteName))
      {
        UISpriteData sprite = this.mAtlas.GetSprite(this.mSpriteName);
        if (sprite == null)
          return (UISpriteData) null;
        this.SetAtlasSprite(sprite);
      }
      if (this.mSprite == null && this.mAtlas.spriteList.Count > 0)
      {
        UISpriteData sprite = this.mAtlas.spriteList[0];
        if (sprite == null)
          return (UISpriteData) null;
        this.SetAtlasSprite(sprite);
        if (this.mSprite == null)
        {
          Debug.LogError((object) (((Object) this.mAtlas).name + " seems to have a null sprite!"));
          return (UISpriteData) null;
        }
        this.mSpriteName = this.mSprite.name;
      }
    }
    return this.mSprite;
  }

  protected void SetAtlasSprite(UISpriteData sp)
  {
    this.mChanged = true;
    this.mSpriteSet = true;
    if (sp != null)
    {
      this.mSprite = sp;
      this.mSpriteName = this.mSprite.name;
    }
    else
    {
      this.mSpriteName = this.mSprite == null ? string.Empty : this.mSprite.name;
      this.mSprite = sp;
    }
  }

  public override void MakePixelPerfect()
  {
    if (!this.isValid)
      return;
    base.MakePixelPerfect();
    UISpriteData atlasSprite = this.GetAtlasSprite();
    if (atlasSprite == null)
      return;
    switch (this.type)
    {
      case UISprite.Type.Simple:
      case UISprite.Type.Filled:
        if (!Object.op_Inequality((Object) this.mainTexture, (Object) null) || atlasSprite == null)
          break;
        int num1 = Mathf.RoundToInt((!Object.op_Inequality((Object) this.atlas, (Object) null) ? 1f : this.atlas.pixelSize) * (float) (atlasSprite.width + atlasSprite.paddingLeft + atlasSprite.paddingRight));
        int num2 = Mathf.RoundToInt((!Object.op_Inequality((Object) this.atlas, (Object) null) ? 1f : this.atlas.pixelSize) * (float) (atlasSprite.height + atlasSprite.paddingTop + atlasSprite.paddingBottom));
        if ((num1 & 1) == 1)
          ++num1;
        if ((num2 & 1) == 1)
          ++num2;
        this.width = num1;
        this.height = num2;
        break;
      default:
        if (atlasSprite.hasBorder)
          break;
        goto case UISprite.Type.Simple;
    }
  }

  protected override void OnInit()
  {
    if (!this.mFillCenter)
    {
      this.mFillCenter = true;
      this.centerType = UISprite.AdvancedType.Invisible;
    }
    base.OnInit();
  }

  protected override void OnUpdate()
  {
    base.OnUpdate();
    if (!this.mChanged && this.mSpriteSet)
      return;
    this.mSpriteSet = true;
    this.mSprite = (UISpriteData) null;
    this.mChanged = true;
  }

  public override void OnFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    Texture mainTexture = this.mainTexture;
    if (Object.op_Inequality((Object) mainTexture, (Object) null))
    {
      if (this.mSprite == null && Object.op_Inequality((Object) this.atlas, (Object) null))
        this.mSprite = this.atlas.GetSprite(this.spriteName);
      if (this.mSprite == null)
        return;
      ((Rect) ref this.mOuterUV).Set((float) this.mSprite.x, (float) this.mSprite.y, (float) this.mSprite.width, (float) this.mSprite.height);
      ((Rect) ref this.mInnerUV).Set((float) (this.mSprite.x + this.mSprite.borderLeft), (float) (this.mSprite.y + this.mSprite.borderTop), (float) (this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float) (this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
      this.mOuterUV = NGUIMath.ConvertToTexCoords(this.mOuterUV, mainTexture.width, mainTexture.height);
      this.mInnerUV = NGUIMath.ConvertToTexCoords(this.mInnerUV, mainTexture.width, mainTexture.height);
    }
    switch (this.type)
    {
      case UISprite.Type.Simple:
        this.SimpleFill(verts, uvs, cols);
        break;
      case UISprite.Type.Sliced:
        this.SlicedFill(verts, uvs, cols);
        break;
      case UISprite.Type.Tiled:
        this.TiledFill(verts, uvs, cols);
        break;
      case UISprite.Type.Filled:
        this.FilledFill(verts, uvs, cols);
        break;
      case UISprite.Type.Advanced:
        this.AdvancedFill(verts, uvs, cols);
        break;
    }
  }

  public override Vector4 drawingDimensions
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float num1 = -pivotOffset.x * (float) this.mWidth;
      float num2 = -pivotOffset.y * (float) this.mHeight;
      float num3 = num1 + (float) this.mWidth;
      float num4 = num2 + (float) this.mHeight;
      if (this.GetAtlasSprite() != null && this.mType != UISprite.Type.Tiled)
      {
        int paddingLeft = this.mSprite.paddingLeft;
        int paddingBottom = this.mSprite.paddingBottom;
        int paddingRight = this.mSprite.paddingRight;
        int paddingTop = this.mSprite.paddingTop;
        int num5 = this.mSprite.width + paddingLeft + paddingRight;
        int num6 = this.mSprite.height + paddingBottom + paddingTop;
        float num7 = 1f;
        float num8 = 1f;
        if (num5 > 0 && num6 > 0 && (this.mType == UISprite.Type.Simple || this.mType == UISprite.Type.Filled))
        {
          if ((num5 & 1) != 0)
            ++paddingRight;
          if ((num6 & 1) != 0)
            ++paddingTop;
          num7 = 1f / (float) num5 * (float) this.mWidth;
          num8 = 1f / (float) num6 * (float) this.mHeight;
        }
        if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
        {
          num1 += (float) paddingRight * num7;
          num3 -= (float) paddingLeft * num7;
        }
        else
        {
          num1 += (float) paddingLeft * num7;
          num3 -= (float) paddingRight * num7;
        }
        if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
        {
          num2 += (float) paddingTop * num8;
          num4 -= (float) paddingBottom * num8;
        }
        else
        {
          num2 += (float) paddingBottom * num8;
          num4 -= (float) paddingTop * num8;
        }
      }
      Vector4 vector4 = this.border;
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector4 = Vector4.op_Multiply(vector4, this.atlas.pixelSize);
      float num9 = vector4.x + vector4.z;
      float num10 = vector4.y + vector4.w;
      return new Vector4(Mathf.Lerp(num1, num3 - num9, this.mDrawRegion.x), Mathf.Lerp(num2, num4 - num10, this.mDrawRegion.y), Mathf.Lerp(num1 + num9, num3, this.mDrawRegion.z), Mathf.Lerp(num2 + num10, num4, this.mDrawRegion.w));
    }
  }

  protected virtual Vector4 drawingUVs
  {
    get
    {
      switch (this.mFlip)
      {
        case UISprite.Flip.Horizontally:
          return new Vector4(((Rect) ref this.mOuterUV).xMax, ((Rect) ref this.mOuterUV).yMin, ((Rect) ref this.mOuterUV).xMin, ((Rect) ref this.mOuterUV).yMax);
        case UISprite.Flip.Vertically:
          return new Vector4(((Rect) ref this.mOuterUV).xMin, ((Rect) ref this.mOuterUV).yMax, ((Rect) ref this.mOuterUV).xMax, ((Rect) ref this.mOuterUV).yMin);
        case UISprite.Flip.Both:
          return new Vector4(((Rect) ref this.mOuterUV).xMax, ((Rect) ref this.mOuterUV).yMax, ((Rect) ref this.mOuterUV).xMin, ((Rect) ref this.mOuterUV).yMin);
        default:
          return new Vector4(((Rect) ref this.mOuterUV).xMin, ((Rect) ref this.mOuterUV).yMin, ((Rect) ref this.mOuterUV).xMax, ((Rect) ref this.mOuterUV).yMax);
      }
    }
  }

  protected void SimpleFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    Vector4 drawingDimensions = this.drawingDimensions;
    Vector4 drawingUvs = this.drawingUVs;
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
    uvs.Add(new Vector2(drawingUvs.x, drawingUvs.y));
    uvs.Add(new Vector2(drawingUvs.x, drawingUvs.w));
    uvs.Add(new Vector2(drawingUvs.z, drawingUvs.w));
    uvs.Add(new Vector2(drawingUvs.z, drawingUvs.y));
    Color color = this.color;
    color.a = this.finalAlpha;
    Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.atlas, (Object) null) || !this.atlas.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
  }

  protected void SlicedFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    if (!this.mSprite.hasBorder)
    {
      this.SimpleFill(verts, uvs, cols);
    }
    else
    {
      Vector4 drawingDimensions = this.drawingDimensions;
      Vector4 vector4 = this.border;
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector4 = Vector4.op_Multiply(vector4, this.atlas.pixelSize);
      UISprite.mTempPos[0].x = drawingDimensions.x;
      UISprite.mTempPos[0].y = drawingDimensions.y;
      UISprite.mTempPos[3].x = drawingDimensions.z;
      UISprite.mTempPos[3].y = drawingDimensions.w;
      if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
      {
        UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector4.z;
        UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector4.x;
        UISprite.mTempUVs[3].x = ((Rect) ref this.mOuterUV).xMin;
        UISprite.mTempUVs[2].x = ((Rect) ref this.mInnerUV).xMin;
        UISprite.mTempUVs[1].x = ((Rect) ref this.mInnerUV).xMax;
        UISprite.mTempUVs[0].x = ((Rect) ref this.mOuterUV).xMax;
      }
      else
      {
        UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector4.x;
        UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector4.z;
        UISprite.mTempUVs[0].x = ((Rect) ref this.mOuterUV).xMin;
        UISprite.mTempUVs[1].x = ((Rect) ref this.mInnerUV).xMin;
        UISprite.mTempUVs[2].x = ((Rect) ref this.mInnerUV).xMax;
        UISprite.mTempUVs[3].x = ((Rect) ref this.mOuterUV).xMax;
      }
      if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
      {
        UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector4.w;
        UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector4.y;
        UISprite.mTempUVs[3].y = ((Rect) ref this.mOuterUV).yMin;
        UISprite.mTempUVs[2].y = ((Rect) ref this.mInnerUV).yMin;
        UISprite.mTempUVs[1].y = ((Rect) ref this.mInnerUV).yMax;
        UISprite.mTempUVs[0].y = ((Rect) ref this.mOuterUV).yMax;
      }
      else
      {
        UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector4.y;
        UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector4.w;
        UISprite.mTempUVs[0].y = ((Rect) ref this.mOuterUV).yMin;
        UISprite.mTempUVs[1].y = ((Rect) ref this.mInnerUV).yMin;
        UISprite.mTempUVs[2].y = ((Rect) ref this.mInnerUV).yMax;
        UISprite.mTempUVs[3].y = ((Rect) ref this.mOuterUV).yMax;
      }
      Color color = this.color;
      color.a = this.finalAlpha;
      Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.atlas, (Object) null) || !this.atlas.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
      for (int index1 = 0; index1 < 3; ++index1)
      {
        int index2 = index1 + 1;
        for (int index3 = 0; index3 < 3; ++index3)
        {
          if (this.centerType != UISprite.AdvancedType.Invisible || index1 != 1 || index3 != 1)
          {
            int index4 = index3 + 1;
            verts.Add(new Vector3(UISprite.mTempPos[index1].x, UISprite.mTempPos[index3].y));
            verts.Add(new Vector3(UISprite.mTempPos[index1].x, UISprite.mTempPos[index4].y));
            verts.Add(new Vector3(UISprite.mTempPos[index2].x, UISprite.mTempPos[index4].y));
            verts.Add(new Vector3(UISprite.mTempPos[index2].x, UISprite.mTempPos[index3].y));
            uvs.Add(new Vector2(UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index3].y));
            uvs.Add(new Vector2(UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index4].y));
            uvs.Add(new Vector2(UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index4].y));
            uvs.Add(new Vector2(UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index3].y));
            cols.Add(color32);
            cols.Add(color32);
            cols.Add(color32);
            cols.Add(color32);
          }
        }
      }
    }
  }

  protected void TiledFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    Texture mainTexture = this.material.mainTexture;
    if (Object.op_Equality((Object) mainTexture, (Object) null))
      return;
    Vector4 drawingDimensions = this.drawingDimensions;
    Vector4 vector4;
    if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
    {
      vector4.x = ((Rect) ref this.mInnerUV).xMax;
      vector4.z = ((Rect) ref this.mInnerUV).xMin;
    }
    else
    {
      vector4.x = ((Rect) ref this.mInnerUV).xMin;
      vector4.z = ((Rect) ref this.mInnerUV).xMax;
    }
    if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
    {
      vector4.y = ((Rect) ref this.mInnerUV).yMax;
      vector4.w = ((Rect) ref this.mInnerUV).yMin;
    }
    else
    {
      vector4.y = ((Rect) ref this.mInnerUV).yMin;
      vector4.w = ((Rect) ref this.mInnerUV).yMax;
    }
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(((Rect) ref this.mInnerUV).width * (float) mainTexture.width, ((Rect) ref this.mInnerUV).height * (float) mainTexture.height);
    if (Object.op_Inequality((Object) this.atlas, (Object) null))
      vector2 = Vector2.op_Multiply(vector2, this.atlas.pixelSize);
    Color color = this.color;
    color.a = this.finalAlpha;
    Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.atlas, (Object) null) || !this.atlas.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
    float x1 = drawingDimensions.x;
    float y1 = drawingDimensions.y;
    float x2 = vector4.x;
    float y2 = vector4.y;
    for (; (double) y1 < (double) drawingDimensions.w; y1 += vector2.y)
    {
      float x3 = drawingDimensions.x;
      float num1 = y1 + vector2.y;
      float num2 = vector4.w;
      if ((double) num1 > (double) drawingDimensions.w)
      {
        num2 = Mathf.Lerp(vector4.y, vector4.w, (drawingDimensions.w - y1) / vector2.y);
        num1 = drawingDimensions.w;
      }
      for (; (double) x3 < (double) drawingDimensions.z; x3 += vector2.x)
      {
        float num3 = x3 + vector2.x;
        float num4 = vector4.z;
        if ((double) num3 > (double) drawingDimensions.z)
        {
          num4 = Mathf.Lerp(vector4.x, vector4.z, (drawingDimensions.z - x3) / vector2.x);
          num3 = drawingDimensions.z;
        }
        verts.Add(new Vector3(x3, y1));
        verts.Add(new Vector3(x3, num1));
        verts.Add(new Vector3(num3, num1));
        verts.Add(new Vector3(num3, y1));
        uvs.Add(new Vector2(x2, y2));
        uvs.Add(new Vector2(x2, num2));
        uvs.Add(new Vector2(num4, num2));
        uvs.Add(new Vector2(num4, y2));
        cols.Add(color32);
        cols.Add(color32);
        cols.Add(color32);
        cols.Add(color32);
      }
    }
  }

  protected void FilledFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    if ((double) this.mFillAmount < 1.0 / 1000.0)
      return;
    Color color = this.color;
    color.a = this.finalAlpha;
    Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.atlas, (Object) null) || !this.atlas.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
    Vector4 drawingDimensions = this.drawingDimensions;
    Vector4 drawingUvs = this.drawingUVs;
    if (this.mFillDirection == UISprite.FillDirection.Horizontal || this.mFillDirection == UISprite.FillDirection.Vertical)
    {
      if (this.mFillDirection == UISprite.FillDirection.Horizontal)
      {
        float num = (drawingUvs.z - drawingUvs.x) * this.mFillAmount;
        if (this.mInvert)
        {
          drawingDimensions.x = drawingDimensions.z - (drawingDimensions.z - drawingDimensions.x) * this.mFillAmount;
          drawingUvs.x = drawingUvs.z - num;
        }
        else
        {
          drawingDimensions.z = drawingDimensions.x + (drawingDimensions.z - drawingDimensions.x) * this.mFillAmount;
          drawingUvs.z = drawingUvs.x + num;
        }
      }
      else if (this.mFillDirection == UISprite.FillDirection.Vertical)
      {
        float num = (drawingUvs.w - drawingUvs.y) * this.mFillAmount;
        if (this.mInvert)
        {
          drawingDimensions.y = drawingDimensions.w - (drawingDimensions.w - drawingDimensions.y) * this.mFillAmount;
          drawingUvs.y = drawingUvs.w - num;
        }
        else
        {
          drawingDimensions.w = drawingDimensions.y + (drawingDimensions.w - drawingDimensions.y) * this.mFillAmount;
          drawingUvs.w = drawingUvs.y + num;
        }
      }
    }
    UISprite.mTempPos[0] = new Vector2(drawingDimensions.x, drawingDimensions.y);
    UISprite.mTempPos[1] = new Vector2(drawingDimensions.x, drawingDimensions.w);
    UISprite.mTempPos[2] = new Vector2(drawingDimensions.z, drawingDimensions.w);
    UISprite.mTempPos[3] = new Vector2(drawingDimensions.z, drawingDimensions.y);
    UISprite.mTempUVs[0] = new Vector2(drawingUvs.x, drawingUvs.y);
    UISprite.mTempUVs[1] = new Vector2(drawingUvs.x, drawingUvs.w);
    UISprite.mTempUVs[2] = new Vector2(drawingUvs.z, drawingUvs.w);
    UISprite.mTempUVs[3] = new Vector2(drawingUvs.z, drawingUvs.y);
    if ((double) this.mFillAmount < 1.0)
    {
      if (this.mFillDirection == UISprite.FillDirection.Radial90)
      {
        if (!UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, this.mFillAmount, this.mInvert, 0))
          return;
        for (int index = 0; index < 4; ++index)
        {
          verts.Add(Vector2.op_Implicit(UISprite.mTempPos[index]));
          uvs.Add(UISprite.mTempUVs[index]);
          cols.Add(color32);
        }
        return;
      }
      if (this.mFillDirection == UISprite.FillDirection.Radial180)
      {
        for (int index1 = 0; index1 < 2; ++index1)
        {
          float num1 = 0.0f;
          float num2 = 1f;
          float num3;
          float num4;
          if (index1 == 0)
          {
            num3 = 0.0f;
            num4 = 0.5f;
          }
          else
          {
            num3 = 0.5f;
            num4 = 1f;
          }
          UISprite.mTempPos[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, num3);
          UISprite.mTempPos[1].x = UISprite.mTempPos[0].x;
          UISprite.mTempPos[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, num4);
          UISprite.mTempPos[3].x = UISprite.mTempPos[2].x;
          UISprite.mTempPos[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, num1);
          UISprite.mTempPos[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, num2);
          UISprite.mTempPos[2].y = UISprite.mTempPos[1].y;
          UISprite.mTempPos[3].y = UISprite.mTempPos[0].y;
          UISprite.mTempUVs[0].x = Mathf.Lerp(drawingUvs.x, drawingUvs.z, num3);
          UISprite.mTempUVs[1].x = UISprite.mTempUVs[0].x;
          UISprite.mTempUVs[2].x = Mathf.Lerp(drawingUvs.x, drawingUvs.z, num4);
          UISprite.mTempUVs[3].x = UISprite.mTempUVs[2].x;
          UISprite.mTempUVs[0].y = Mathf.Lerp(drawingUvs.y, drawingUvs.w, num1);
          UISprite.mTempUVs[1].y = Mathf.Lerp(drawingUvs.y, drawingUvs.w, num2);
          UISprite.mTempUVs[2].y = UISprite.mTempUVs[1].y;
          UISprite.mTempUVs[3].y = UISprite.mTempUVs[0].y;
          float num5 = this.mInvert ? this.mFillAmount * 2f - (float) (1 - index1) : this.fillAmount * 2f - (float) index1;
          if (UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, Mathf.Clamp01(num5), !this.mInvert, NGUIMath.RepeatIndex(index1 + 3, 4)))
          {
            for (int index2 = 0; index2 < 4; ++index2)
            {
              verts.Add(Vector2.op_Implicit(UISprite.mTempPos[index2]));
              uvs.Add(UISprite.mTempUVs[index2]);
              cols.Add(color32);
            }
          }
        }
        return;
      }
      if (this.mFillDirection == UISprite.FillDirection.Radial360)
      {
        for (int index3 = 0; index3 < 4; ++index3)
        {
          float num6;
          float num7;
          if (index3 < 2)
          {
            num6 = 0.0f;
            num7 = 0.5f;
          }
          else
          {
            num6 = 0.5f;
            num7 = 1f;
          }
          float num8;
          float num9;
          if (index3 == 0 || index3 == 3)
          {
            num8 = 0.0f;
            num9 = 0.5f;
          }
          else
          {
            num8 = 0.5f;
            num9 = 1f;
          }
          UISprite.mTempPos[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, num6);
          UISprite.mTempPos[1].x = UISprite.mTempPos[0].x;
          UISprite.mTempPos[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, num7);
          UISprite.mTempPos[3].x = UISprite.mTempPos[2].x;
          UISprite.mTempPos[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, num8);
          UISprite.mTempPos[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, num9);
          UISprite.mTempPos[2].y = UISprite.mTempPos[1].y;
          UISprite.mTempPos[3].y = UISprite.mTempPos[0].y;
          UISprite.mTempUVs[0].x = Mathf.Lerp(drawingUvs.x, drawingUvs.z, num6);
          UISprite.mTempUVs[1].x = UISprite.mTempUVs[0].x;
          UISprite.mTempUVs[2].x = Mathf.Lerp(drawingUvs.x, drawingUvs.z, num7);
          UISprite.mTempUVs[3].x = UISprite.mTempUVs[2].x;
          UISprite.mTempUVs[0].y = Mathf.Lerp(drawingUvs.y, drawingUvs.w, num8);
          UISprite.mTempUVs[1].y = Mathf.Lerp(drawingUvs.y, drawingUvs.w, num9);
          UISprite.mTempUVs[2].y = UISprite.mTempUVs[1].y;
          UISprite.mTempUVs[3].y = UISprite.mTempUVs[0].y;
          float num10 = !this.mInvert ? this.mFillAmount * 4f - (float) (3 - NGUIMath.RepeatIndex(index3 + 2, 4)) : this.mFillAmount * 4f - (float) NGUIMath.RepeatIndex(index3 + 2, 4);
          if (UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, Mathf.Clamp01(num10), this.mInvert, NGUIMath.RepeatIndex(index3 + 2, 4)))
          {
            for (int index4 = 0; index4 < 4; ++index4)
            {
              verts.Add(Vector2.op_Implicit(UISprite.mTempPos[index4]));
              uvs.Add(UISprite.mTempUVs[index4]);
              cols.Add(color32);
            }
          }
        }
        return;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      verts.Add(Vector2.op_Implicit(UISprite.mTempPos[index]));
      uvs.Add(UISprite.mTempUVs[index]);
      cols.Add(color32);
    }
  }

  private static bool RadialCut(Vector2[] xy, Vector2[] uv, float fill, bool invert, int corner)
  {
    if ((double) fill < 1.0 / 1000.0)
      return false;
    if ((corner & 1) == 1)
      invert = !invert;
    if (!invert && (double) fill > 0.99900001287460327)
      return true;
    float num1 = Mathf.Clamp01(fill);
    if (invert)
      num1 = 1f - num1;
    float num2 = num1 * 1.57079637f;
    float cos = Mathf.Cos(num2);
    float sin = Mathf.Sin(num2);
    UISprite.RadialCut(xy, cos, sin, invert, corner);
    UISprite.RadialCut(uv, cos, sin, invert, corner);
    return true;
  }

  private static void RadialCut(Vector2[] xy, float cos, float sin, bool invert, int corner)
  {
    int index1 = corner;
    int index2 = NGUIMath.RepeatIndex(corner + 1, 4);
    int index3 = NGUIMath.RepeatIndex(corner + 2, 4);
    int index4 = NGUIMath.RepeatIndex(corner + 3, 4);
    if ((corner & 1) == 1)
    {
      if ((double) sin > (double) cos)
      {
        cos /= sin;
        sin = 1f;
        if (invert)
        {
          xy[index2].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
          xy[index3].x = xy[index2].x;
        }
      }
      else if ((double) cos > (double) sin)
      {
        sin /= cos;
        cos = 1f;
        if (!invert)
        {
          xy[index3].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
          xy[index4].y = xy[index3].y;
        }
      }
      else
      {
        cos = 1f;
        sin = 1f;
      }
      if (!invert)
        xy[index4].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
      else
        xy[index2].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
    }
    else
    {
      if ((double) cos > (double) sin)
      {
        sin /= cos;
        cos = 1f;
        if (!invert)
        {
          xy[index2].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
          xy[index3].y = xy[index2].y;
        }
      }
      else if ((double) sin > (double) cos)
      {
        cos /= sin;
        sin = 1f;
        if (invert)
        {
          xy[index3].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
          xy[index4].x = xy[index3].x;
        }
      }
      else
      {
        cos = 1f;
        sin = 1f;
      }
      if (invert)
        xy[index4].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
      else
        xy[index2].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
    }
  }

  protected void AdvancedFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    if (!this.mSprite.hasBorder)
    {
      this.SimpleFill(verts, uvs, cols);
    }
    else
    {
      Texture mainTexture = this.material.mainTexture;
      if (Object.op_Equality((Object) mainTexture, (Object) null))
        return;
      Vector4 drawingDimensions = this.drawingDimensions;
      Vector4 vector4 = this.border;
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector4 = Vector4.op_Multiply(vector4, this.atlas.pixelSize);
      Vector2 vector2;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2).\u002Ector(((Rect) ref this.mInnerUV).width * (float) mainTexture.width, ((Rect) ref this.mInnerUV).height * (float) mainTexture.height);
      if (Object.op_Inequality((Object) this.atlas, (Object) null))
        vector2 = Vector2.op_Multiply(vector2, this.atlas.pixelSize);
      if ((double) vector2.x < 1.0)
        vector2.x = 1f;
      if ((double) vector2.y < 1.0)
        vector2.y = 1f;
      UISprite.mTempPos[0].x = drawingDimensions.x;
      UISprite.mTempPos[0].y = drawingDimensions.y;
      UISprite.mTempPos[3].x = drawingDimensions.z;
      UISprite.mTempPos[3].y = drawingDimensions.w;
      if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
      {
        UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector4.z;
        UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector4.x;
        UISprite.mTempUVs[3].x = ((Rect) ref this.mOuterUV).xMin;
        UISprite.mTempUVs[2].x = ((Rect) ref this.mInnerUV).xMin;
        UISprite.mTempUVs[1].x = ((Rect) ref this.mInnerUV).xMax;
        UISprite.mTempUVs[0].x = ((Rect) ref this.mOuterUV).xMax;
      }
      else
      {
        UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector4.x;
        UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector4.z;
        UISprite.mTempUVs[0].x = ((Rect) ref this.mOuterUV).xMin;
        UISprite.mTempUVs[1].x = ((Rect) ref this.mInnerUV).xMin;
        UISprite.mTempUVs[2].x = ((Rect) ref this.mInnerUV).xMax;
        UISprite.mTempUVs[3].x = ((Rect) ref this.mOuterUV).xMax;
      }
      if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
      {
        UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector4.w;
        UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector4.y;
        UISprite.mTempUVs[3].y = ((Rect) ref this.mOuterUV).yMin;
        UISprite.mTempUVs[2].y = ((Rect) ref this.mInnerUV).yMin;
        UISprite.mTempUVs[1].y = ((Rect) ref this.mInnerUV).yMax;
        UISprite.mTempUVs[0].y = ((Rect) ref this.mOuterUV).yMax;
      }
      else
      {
        UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector4.y;
        UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector4.w;
        UISprite.mTempUVs[0].y = ((Rect) ref this.mOuterUV).yMin;
        UISprite.mTempUVs[1].y = ((Rect) ref this.mInnerUV).yMin;
        UISprite.mTempUVs[2].y = ((Rect) ref this.mInnerUV).yMax;
        UISprite.mTempUVs[3].y = ((Rect) ref this.mOuterUV).yMax;
      }
      Color color = this.color;
      color.a = this.finalAlpha;
      Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.atlas, (Object) null) || !this.atlas.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
      for (int index1 = 0; index1 < 3; ++index1)
      {
        int index2 = index1 + 1;
        for (int index3 = 0; index3 < 3; ++index3)
        {
          if (this.centerType != UISprite.AdvancedType.Invisible || index1 != 1 || index3 != 1)
          {
            int index4 = index3 + 1;
            if (index1 == 1 && index3 == 1)
            {
              if (this.centerType == UISprite.AdvancedType.Tiled)
              {
                float x1 = UISprite.mTempPos[index1].x;
                float x2 = UISprite.mTempPos[index2].x;
                float y1 = UISprite.mTempPos[index3].y;
                float y2 = UISprite.mTempPos[index4].y;
                float x3 = UISprite.mTempUVs[index1].x;
                float y3 = UISprite.mTempUVs[index3].y;
                for (float v0y = y1; (double) v0y < (double) y2; v0y += vector2.y)
                {
                  float v0x = x1;
                  float u1y = UISprite.mTempUVs[index4].y;
                  float v1y = v0y + vector2.y;
                  if ((double) v1y > (double) y2)
                  {
                    u1y = Mathf.Lerp(y3, u1y, (y2 - v0y) / vector2.y);
                    v1y = y2;
                  }
                  for (; (double) v0x < (double) x2; v0x += vector2.x)
                  {
                    float v1x = v0x + vector2.x;
                    float u1x = UISprite.mTempUVs[index2].x;
                    if ((double) v1x > (double) x2)
                    {
                      u1x = Mathf.Lerp(x3, u1x, (x2 - v0x) / vector2.x);
                      v1x = x2;
                    }
                    this.FillBuffers(v0x, v1x, v0y, v1y, x3, u1x, y3, u1y, Color32.op_Implicit(color32), verts, uvs, cols);
                  }
                }
              }
              else if (this.centerType == UISprite.AdvancedType.Sliced)
                this.FillBuffers(UISprite.mTempPos[index1].x, UISprite.mTempPos[index2].x, UISprite.mTempPos[index3].y, UISprite.mTempPos[index4].y, UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index3].y, UISprite.mTempUVs[index4].y, Color32.op_Implicit(color32), verts, uvs, cols);
            }
            else if (index1 == 1)
            {
              if (index3 == 0 && this.bottomType == UISprite.AdvancedType.Tiled || index3 == 2 && this.topType == UISprite.AdvancedType.Tiled)
              {
                float x4 = UISprite.mTempPos[index1].x;
                float x5 = UISprite.mTempPos[index2].x;
                float y4 = UISprite.mTempPos[index3].y;
                float y5 = UISprite.mTempPos[index4].y;
                float x6 = UISprite.mTempUVs[index1].x;
                float y6 = UISprite.mTempUVs[index3].y;
                float y7 = UISprite.mTempUVs[index4].y;
                for (float v0x = x4; (double) v0x < (double) x5; v0x += vector2.x)
                {
                  float v1x = v0x + vector2.x;
                  float u1x = UISprite.mTempUVs[index2].x;
                  if ((double) v1x > (double) x5)
                  {
                    u1x = Mathf.Lerp(x6, u1x, (x5 - v0x) / vector2.x);
                    v1x = x5;
                  }
                  this.FillBuffers(v0x, v1x, y4, y5, x6, u1x, y6, y7, Color32.op_Implicit(color32), verts, uvs, cols);
                }
              }
              else if (index3 == 0 && this.bottomType == UISprite.AdvancedType.Sliced || index3 == 2 && this.topType == UISprite.AdvancedType.Sliced)
                this.FillBuffers(UISprite.mTempPos[index1].x, UISprite.mTempPos[index2].x, UISprite.mTempPos[index3].y, UISprite.mTempPos[index4].y, UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index3].y, UISprite.mTempUVs[index4].y, Color32.op_Implicit(color32), verts, uvs, cols);
            }
            else if (index3 == 1)
            {
              if (index1 == 0 && this.leftType == UISprite.AdvancedType.Tiled || index1 == 2 && this.rightType == UISprite.AdvancedType.Tiled)
              {
                float x7 = UISprite.mTempPos[index1].x;
                float x8 = UISprite.mTempPos[index2].x;
                float y8 = UISprite.mTempPos[index3].y;
                float y9 = UISprite.mTempPos[index4].y;
                float x9 = UISprite.mTempUVs[index1].x;
                float x10 = UISprite.mTempUVs[index2].x;
                float y10 = UISprite.mTempUVs[index3].y;
                for (float v0y = y8; (double) v0y < (double) y9; v0y += vector2.y)
                {
                  float u1y = UISprite.mTempUVs[index4].y;
                  float v1y = v0y + vector2.y;
                  if ((double) v1y > (double) y9)
                  {
                    u1y = Mathf.Lerp(y10, u1y, (y9 - v0y) / vector2.y);
                    v1y = y9;
                  }
                  this.FillBuffers(x7, x8, v0y, v1y, x9, x10, y10, u1y, Color32.op_Implicit(color32), verts, uvs, cols);
                }
              }
              else if (index1 == 0 && this.leftType == UISprite.AdvancedType.Sliced || index1 == 2 && this.rightType == UISprite.AdvancedType.Sliced)
                this.FillBuffers(UISprite.mTempPos[index1].x, UISprite.mTempPos[index2].x, UISprite.mTempPos[index3].y, UISprite.mTempPos[index4].y, UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index3].y, UISprite.mTempUVs[index4].y, Color32.op_Implicit(color32), verts, uvs, cols);
            }
            else
              this.FillBuffers(UISprite.mTempPos[index1].x, UISprite.mTempPos[index2].x, UISprite.mTempPos[index3].y, UISprite.mTempPos[index4].y, UISprite.mTempUVs[index1].x, UISprite.mTempUVs[index2].x, UISprite.mTempUVs[index3].y, UISprite.mTempUVs[index4].y, Color32.op_Implicit(color32), verts, uvs, cols);
          }
        }
      }
    }
  }

  private void FillBuffers(
    float v0x,
    float v1x,
    float v0y,
    float v1y,
    float u0x,
    float u1x,
    float u0y,
    float u1y,
    Color col,
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    verts.Add(new Vector3(v0x, v0y));
    verts.Add(new Vector3(v0x, v1y));
    verts.Add(new Vector3(v1x, v1y));
    verts.Add(new Vector3(v1x, v0y));
    uvs.Add(new Vector2(u0x, u0y));
    uvs.Add(new Vector2(u0x, u1y));
    uvs.Add(new Vector2(u1x, u1y));
    uvs.Add(new Vector2(u1x, u0y));
    cols.Add(Color32.op_Implicit(col));
    cols.Add(Color32.op_Implicit(col));
    cols.Add(Color32.op_Implicit(col));
    cols.Add(Color32.op_Implicit(col));
  }

  public enum Type
  {
    Simple,
    Sliced,
    Tiled,
    Filled,
    Advanced,
  }

  public enum FillDirection
  {
    Horizontal,
    Vertical,
    Radial90,
    Radial180,
    Radial360,
  }

  public enum AdvancedType
  {
    Invisible,
    Sliced,
    Tiled,
  }

  public enum Flip
  {
    Nothing,
    Horizontally,
    Vertically,
    Both,
  }
}
