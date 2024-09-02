// Decompiled with JetBrains decompiler
// Type: UIUnityMaskRenderer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIUnityMaskRenderer : UIWidget
{
  public bool allowSharedMaterial;
  [HideInInspector]
  [SerializeField]
  private Renderer mRenderer;
  [HideInInspector]
  [SerializeField]
  private int renderQueue = -1;
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Material[] mMats;
  private UIDrawCall.Clipping nowClip;
  private MaterialPropertyBlock mbp;

  public Renderer cachedRenderer
  {
    get
    {
      if ((UnityEngine.Object) this.mRenderer == (UnityEngine.Object) null)
        this.mRenderer = this.GetComponent<Renderer>();
      return this.mRenderer;
    }
  }

  protected override void OnInit()
  {
    if (this.geometry == null)
      this.geometry = new UIGeometry();
    if (this.mCorners == null)
      this.mCorners = new Vector3[4];
    base.OnInit();
  }

  public override Vector3[] worldCorners
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float x1 = -pivotOffset.x * (float) this.mWidth;
      float y1 = -pivotOffset.y * (float) this.mHeight;
      float x2 = x1 + (float) this.mWidth;
      float y2 = y1 + (float) this.mHeight;
      Matrix4x4 matrix4x4 = this.cachedTransform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1f / 1000f, 1f / 1000f, 1f / 1000f));
      this.mCorners[0] = matrix4x4.MultiplyPoint(new Vector3(x1, y1, 0.0f));
      this.mCorners[1] = matrix4x4.MultiplyPoint(new Vector3(x1, y2, 0.0f));
      this.mCorners[2] = matrix4x4.MultiplyPoint(new Vector3(x2, y2, 0.0f));
      this.mCorners[3] = matrix4x4.MultiplyPoint(new Vector3(x2, y1, 0.0f));
      return this.mCorners;
    }
  }

  public override UnityEngine.Material material
  {
    get
    {
      if (!this.ExistSharedMaterial0())
      {
        Debug.LogError((object) "Renderer or Material is not found.");
        return (UnityEngine.Material) null;
      }
      if (this.allowSharedMaterial)
        return this.cachedRenderer.sharedMaterials[0];
      if (!this.CheckMaterial(this.mMats))
      {
        List<UnityEngine.Material> materialList = new List<UnityEngine.Material>();
        foreach (UnityEngine.Material sharedMaterial in this.cachedRenderer.sharedMaterials)
        {
          if (!((UnityEngine.Object) sharedMaterial == (UnityEngine.Object) null))
          {
            string name = sharedMaterial.shader.name.Replace(" UnityRender (AlphaClip)", "").Replace(" UnityRender (SoftClip)", "");
            UnityEngine.Shader shader = (UnityEngine.Shader) null;
            if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.clipping == UIDrawCall.Clipping.SoftClip)
            {
              shader = UnityEngine.Shader.Find(name + " UnityRender (SoftClip)");
              this.nowClip = UIDrawCall.Clipping.SoftClip;
            }
            else if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.clipping == UIDrawCall.Clipping.AlphaClip)
            {
              shader = UnityEngine.Shader.Find(name + " UnityRender (AlphaClip)");
              this.nowClip = UIDrawCall.Clipping.AlphaClip;
            }
            if ((UnityEngine.Object) shader == (UnityEngine.Object) null)
            {
              shader = UnityEngine.Shader.Find(name);
              this.nowClip = UIDrawCall.Clipping.None;
            }
            UnityEngine.Material material = new UnityEngine.Material(shader);
            material.CopyPropertiesFromMaterial(sharedMaterial);
            material.name += " (Copy)";
            materialList.Add(material);
          }
        }
        this.mMats = materialList.ToArray();
      }
      if (this.CheckMaterial(this.mMats) && Application.isPlaying && this.cachedRenderer.materials != this.mMats)
        this.cachedRenderer.materials = this.mMats;
      if (this.mbp != null && !this.mbp.isEmpty)
        this.cachedRenderer.SetPropertyBlock(this.mbp);
      return this.mMats[0];
    }
    set => throw new NotImplementedException(this.GetType().ToString() + " has no material setter");
  }

  public override UnityEngine.Shader shader
  {
    get
    {
      if (!this.allowSharedMaterial)
      {
        if (this.CheckMaterial(this.mMats))
          return this.mMats[0].shader;
      }
      else if (this.ExistSharedMaterial0())
        return this.cachedRenderer.sharedMaterials[0].shader;
      return (UnityEngine.Shader) null;
    }
    set => throw new NotImplementedException(this.GetType().ToString() + " has no shader setter");
  }

  private bool ExistSharedMaterial0() => (UnityEngine.Object) this.cachedRenderer != (UnityEngine.Object) null && this.CheckMaterial(this.cachedRenderer.sharedMaterials);

  private bool CheckMaterial(UnityEngine.Material[] mats)
  {
    if (mats == null || mats.Length == 0)
      return false;
    for (int index = 0; index < mats.Length; ++index)
    {
      if ((UnityEngine.Object) mats[index] != (UnityEngine.Object) null)
        return true;
    }
    return false;
  }

  private void OnDestroy()
  {
    if (this.mMats == null)
      return;
    for (int index = 0; index < this.mMats.Length; ++index)
    {
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.mMats[index]);
      this.mMats[index] = (UnityEngine.Material) null;
    }
    this.mMats = (UnityEngine.Material[]) null;
  }

  protected override void OnUpdate()
  {
    base.OnUpdate();
    if (!this.allowSharedMaterial)
    {
      if (this.CheckMaterial(this.mMats) && (UnityEngine.Object) this.drawCall != (UnityEngine.Object) null)
      {
        this.renderQueue = this.drawCall.finalRenderQueue;
        for (int index = 0; index < this.mMats.Length; ++index)
        {
          if (this.mMats[index].renderQueue != this.renderQueue)
            this.mMats[index].renderQueue = this.renderQueue;
        }
      }
    }
    else if (this.ExistSharedMaterial0() && (UnityEngine.Object) this.drawCall != (UnityEngine.Object) null)
    {
      this.renderQueue = this.drawCall.finalRenderQueue;
      for (int index = 0; index < this.cachedRenderer.sharedMaterials.Length; ++index)
        this.cachedRenderer.sharedMaterials[index].renderQueue = this.renderQueue;
    }
    if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null) || this.panel.clipping == this.nowClip)
      return;
    if (this.mMats != null)
    {
      for (int index = 0; index < this.mMats.Length; ++index)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.mMats[index]);
        this.mMats[index] = (UnityEngine.Material) null;
      }
      this.mMats = (UnityEngine.Material[]) null;
    }
    if (this.allowSharedMaterial)
      return;
    if (!this.CheckMaterial(this.mMats))
    {
      List<UnityEngine.Material> materialList = new List<UnityEngine.Material>();
      foreach (UnityEngine.Material sharedMaterial in this.cachedRenderer.sharedMaterials)
      {
        if (!((UnityEngine.Object) sharedMaterial == (UnityEngine.Object) null))
        {
          string name = sharedMaterial.shader.name.Replace(" UnityRender (AlphaClip)", "").Replace(" UnityRender (SoftClip)", "");
          UnityEngine.Shader shader = (UnityEngine.Shader) null;
          if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.clipping == UIDrawCall.Clipping.SoftClip)
          {
            shader = UnityEngine.Shader.Find(name + " UnityRender (SoftClip)");
            this.nowClip = UIDrawCall.Clipping.SoftClip;
          }
          else if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.clipping == UIDrawCall.Clipping.AlphaClip)
          {
            shader = UnityEngine.Shader.Find(name + " UnityRender (AlphaClip)");
            this.nowClip = UIDrawCall.Clipping.AlphaClip;
          }
          if ((UnityEngine.Object) shader == (UnityEngine.Object) null)
          {
            shader = UnityEngine.Shader.Find(name);
            this.nowClip = UIDrawCall.Clipping.None;
          }
          UnityEngine.Material material = new UnityEngine.Material(shader);
          material.CopyPropertiesFromMaterial(sharedMaterial);
          material.name += " (Copy)";
          materialList.Add(material);
        }
      }
      this.mMats = materialList.ToArray();
    }
    if (this.CheckMaterial(this.mMats) && Application.isPlaying && this.cachedRenderer.materials != this.mMats)
      this.cachedRenderer.materials = this.mMats;
    if (this.mbp == null || this.mbp.isEmpty)
      return;
    this.cachedRenderer.SetPropertyBlock(this.mbp);
  }

  private void OnWillRenderObject()
  {
    if ((UnityEngine.Object) this.drawCall == (UnityEngine.Object) null || this.mMats == null || (this.mMats.Length == 0 || !this.drawCall.isClipped) || this.drawCall.clipping == UIDrawCall.Clipping.ConstrainButDontClip)
      return;
    Vector2 vector2_1 = new Vector2(-this.drawCall.clipRange.x / this.drawCall.clipRange.z, -this.drawCall.clipRange.y / this.drawCall.clipRange.w);
    Vector2 vector2_2 = new Vector2(1f / this.drawCall.clipRange.z, 1f / this.drawCall.clipRange.w);
    Vector2 vector2_3 = new Vector2(1000f, 1000f);
    if ((double) this.drawCall.clipSoftness.x > 0.0)
      vector2_3.x = this.drawCall.clipRange.z / this.drawCall.clipSoftness.x;
    if ((double) this.drawCall.clipSoftness.y > 0.0)
      vector2_3.y = this.drawCall.clipRange.w / this.drawCall.clipSoftness.y;
    for (int index = 0; index < this.mMats.Length; ++index)
    {
      this.mMats[index].SetMatrix("_Trans", this.panel.cachedTransform.localToWorldMatrix.inverse);
      this.mMats[index].SetVector("_ViewScale", new Vector4(vector2_2.x, vector2_2.y, vector2_1.x, vector2_1.y));
      this.mMats[index].SetVector("_ClipSharpness", (Vector4) vector2_3);
    }
  }

  public void SetTexture(string name, Texture tex)
  {
    if ((UnityEngine.Object) tex == (UnityEngine.Object) null)
      return;
    if (this.mbp == null)
      this.mbp = new MaterialPropertyBlock();
    this.mbp.SetTexture(name, tex);
    if (this.mbp == null || this.mbp.isEmpty)
      return;
    this.cachedRenderer.SetPropertyBlock(this.mbp);
  }

  public override void OnFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    verts.Add(new Vector3(10000f, 10000f));
    verts.Add(new Vector3(10000f, 10000f));
    verts.Add(new Vector3(10000f, 10000f));
    verts.Add(new Vector3(10000f, 10000f));
    uvs.Add(new Vector2(0.0f, 0.0f));
    uvs.Add(new Vector2(0.0f, 1f));
    uvs.Add(new Vector2(1f, 1f));
    uvs.Add(new Vector2(1f, 0.0f));
    cols.Add((Color32) this.color);
    cols.Add((Color32) this.color);
    cols.Add((Color32) this.color);
    cols.Add((Color32) this.color);
  }
}
