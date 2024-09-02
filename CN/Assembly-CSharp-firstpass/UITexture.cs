// Decompiled with JetBrains decompiler
// Type: UITexture
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/NGUI Texture")]
public class UITexture : UIWidget
{
  [HideInInspector]
  [SerializeField]
  private Rect mRect = new Rect(0.0f, 0.0f, 1f, 1f);
  [HideInInspector]
  [SerializeField]
  private Texture mTexture;
  [SerializeField]
  [HideInInspector]
  private Material mMat;
  [SerializeField]
  [HideInInspector]
  private Shader mShader;
  private int mPMA = -1;

  public override Texture mainTexture
  {
    get => this.mTexture;
    set
    {
      if (!Object.op_Inequality((Object) this.mTexture, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mTexture = value;
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
      this.mShader = value;
      if (!Object.op_Equality((Object) this.mMat, (Object) null))
        return;
      this.mPMA = -1;
      this.MarkAsChanged();
    }
  }

  public bool premultipliedAlpha
  {
    get
    {
      if (this.mPMA == -1)
      {
        Material material = this.material;
        this.mPMA = !Object.op_Inequality((Object) material, (Object) null) || !Object.op_Inequality((Object) material.shader, (Object) null) || !((Object) material.shader).name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public Rect uvRect
  {
    get => this.mRect;
    set
    {
      if (!Rect.op_Inequality(this.mRect, value))
        return;
      this.mRect = value;
      this.MarkAsChanged();
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
      Texture mainTexture = this.mainTexture;
      int num5 = !Object.op_Inequality((Object) mainTexture, (Object) null) ? this.mWidth : mainTexture.width;
      int num6 = !Object.op_Inequality((Object) mainTexture, (Object) null) ? this.mHeight : mainTexture.height;
      if ((num5 & 1) != 0)
        num3 -= 1f / (float) num5 * (float) this.mWidth;
      if ((num6 & 1) != 0)
        num4 -= 1f / (float) num6 * (float) this.mHeight;
      return new Vector4((double) this.mDrawRegion.x != 0.0 ? Mathf.Lerp(num1, num3, this.mDrawRegion.x) : num1, (double) this.mDrawRegion.y != 0.0 ? Mathf.Lerp(num2, num4, this.mDrawRegion.y) : num2, (double) this.mDrawRegion.z != 1.0 ? Mathf.Lerp(num1, num3, this.mDrawRegion.z) : num3, (double) this.mDrawRegion.w != 1.0 ? Mathf.Lerp(num2, num4, this.mDrawRegion.w) : num4);
    }
  }

  public override void MakePixelPerfect()
  {
    Texture mainTexture = this.mainTexture;
    if (Object.op_Inequality((Object) mainTexture, (Object) null))
    {
      int width = mainTexture.width;
      if ((width & 1) == 1)
        ++width;
      int height = mainTexture.height;
      if ((height & 1) == 1)
        ++height;
      this.width = width;
      this.height = height;
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
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
    verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
    verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
    uvs.Add(new Vector2(((Rect) ref this.mRect).xMin, ((Rect) ref this.mRect).yMin));
    uvs.Add(new Vector2(((Rect) ref this.mRect).xMin, ((Rect) ref this.mRect).yMax));
    uvs.Add(new Vector2(((Rect) ref this.mRect).xMax, ((Rect) ref this.mRect).yMax));
    uvs.Add(new Vector2(((Rect) ref this.mRect).xMax, ((Rect) ref this.mRect).yMin));
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
    cols.Add(color32);
  }
}
