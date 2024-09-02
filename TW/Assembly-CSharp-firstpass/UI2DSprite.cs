// Decompiled with JetBrains decompiler
// Type: UI2DSprite
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/NGUI Unity2D Sprite")]
public class UI2DSprite : UIWidget
{
  [HideInInspector]
  [SerializeField]
  private Sprite mSprite;
  [HideInInspector]
  [SerializeField]
  private Material mMat;
  [HideInInspector]
  [SerializeField]
  private Shader mShader;
  public Sprite nextSprite;
  private int mPMA = -1;

  public Sprite sprite2D
  {
    get => this.mSprite;
    set
    {
      if (!Object.op_Inequality((Object) this.mSprite, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mSprite = value;
      this.nextSprite = (Sprite) null;
      this.MarkAsChanged();
    }
  }

  public override Material material
  {
    get => this.mMat;
    set
    {
      if (!Object.op_Inequality((Object) this.mMat, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mMat = value;
      this.mPMA = -1;
      this.MarkAsChanged();
    }
  }

  public override Shader shader
  {
    get
    {
      if (Object.op_Inequality((Object) this.mMat, (Object) null))
        return this.mMat.shader;
      if (Object.op_Equality((Object) this.mShader, (Object) null))
        this.mShader = Shader.Find("Unlit/Transparent Colored");
      return this.mShader;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.mShader, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mShader = value;
      if (!Object.op_Equality((Object) this.mMat, (Object) null))
        return;
      this.mPMA = -1;
      this.MarkAsChanged();
    }
  }

  public override Texture mainTexture
  {
    get
    {
      if (Object.op_Inequality((Object) this.mSprite, (Object) null))
        return (Texture) this.mSprite.texture;
      return Object.op_Inequality((Object) this.mMat, (Object) null) ? this.mMat.mainTexture : (Texture) null;
    }
  }

  public bool premultipliedAlpha
  {
    get
    {
      if (this.mPMA == -1)
      {
        Shader shader = this.shader;
        this.mPMA = !Object.op_Inequality((Object) shader, (Object) null) || !((Object) shader).name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
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
      int mWidth;
      if (Object.op_Inequality((Object) this.mSprite, (Object) null))
      {
        Rect textureRect = this.mSprite.textureRect;
        mWidth = Mathf.RoundToInt(((Rect) ref textureRect).width);
      }
      else
        mWidth = this.mWidth;
      int num5 = mWidth;
      int mHeight;
      if (Object.op_Inequality((Object) this.mSprite, (Object) null))
      {
        Rect textureRect = this.mSprite.textureRect;
        mHeight = Mathf.RoundToInt(((Rect) ref textureRect).height);
      }
      else
        mHeight = this.mHeight;
      int num6 = mHeight;
      if ((num5 & 1) != 0)
        num3 -= 1f / (float) num5 * (float) this.mWidth;
      if ((num6 & 1) != 0)
        num4 -= 1f / (float) num6 * (float) this.mHeight;
      return new Vector4((double) this.mDrawRegion.x != 0.0 ? Mathf.Lerp(num1, num3, this.mDrawRegion.x) : num1, (double) this.mDrawRegion.y != 0.0 ? Mathf.Lerp(num2, num4, this.mDrawRegion.y) : num2, (double) this.mDrawRegion.z != 1.0 ? Mathf.Lerp(num1, num3, this.mDrawRegion.z) : num3, (double) this.mDrawRegion.w != 1.0 ? Mathf.Lerp(num2, num4, this.mDrawRegion.w) : num4);
    }
  }

  public Rect uvRect
  {
    get
    {
      Texture mainTexture = this.mainTexture;
      if (!Object.op_Inequality((Object) mainTexture, (Object) null))
        return new Rect(0.0f, 0.0f, 1f, 1f);
      Rect textureRect = this.mSprite.textureRect;
      ref Rect local1 = ref textureRect;
      ((Rect) ref local1).xMin = ((Rect) ref local1).xMin / (float) mainTexture.width;
      ref Rect local2 = ref textureRect;
      ((Rect) ref local2).xMax = ((Rect) ref local2).xMax / (float) mainTexture.width;
      ref Rect local3 = ref textureRect;
      ((Rect) ref local3).yMin = ((Rect) ref local3).yMin / (float) mainTexture.height;
      ref Rect local4 = ref textureRect;
      ((Rect) ref local4).yMax = ((Rect) ref local4).yMax / (float) mainTexture.height;
      return textureRect;
    }
  }

  protected override void OnUpdate()
  {
    if (Object.op_Inequality((Object) this.nextSprite, (Object) null))
    {
      if (Object.op_Inequality((Object) this.nextSprite, (Object) this.mSprite))
        this.sprite2D = this.nextSprite;
      this.nextSprite = (Sprite) null;
    }
    base.OnUpdate();
  }

  public override void MakePixelPerfect()
  {
    if (Object.op_Inequality((Object) this.mSprite, (Object) null))
    {
      Rect textureRect = this.mSprite.textureRect;
      int num1 = Mathf.RoundToInt(((Rect) ref textureRect).width);
      int num2 = Mathf.RoundToInt(((Rect) ref textureRect).height);
      if ((num1 & 1) == 1)
        ++num1;
      if ((num2 & 1) == 1)
        ++num2;
      this.width = num1;
      this.height = num2;
    }
    base.MakePixelPerfect();
  }

  public override void OnFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    Color color = this.color;
    color.a = this.finalAlpha;
    Color32 color32 = Color32.op_Implicit(!this.premultipliedAlpha ? color : NGUITools.ApplyPMA(color));
    Vector4 drawingDimensions = this.drawingDimensions;
    Rect uvRect = this.uvRect;
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
    uvs.Add(new Vector2(((Rect) ref uvRect).xMin, ((Rect) ref uvRect).yMin));
    uvs.Add(new Vector2(((Rect) ref uvRect).xMin, ((Rect) ref uvRect).yMax));
    uvs.Add(new Vector2(((Rect) ref uvRect).xMax, ((Rect) ref uvRect).yMax));
    uvs.Add(new Vector2(((Rect) ref uvRect).xMax, ((Rect) ref uvRect).yMin));
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
  }
}
