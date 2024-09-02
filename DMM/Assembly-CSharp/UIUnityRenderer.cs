// Decompiled with JetBrains decompiler
// Type: UIUnityRenderer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIUnityRenderer : UIWidget
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

  public Renderer cachedRenderer
  {
    get
    {
      if ((UnityEngine.Object) this.mRenderer == (UnityEngine.Object) null)
        this.mRenderer = this.GetComponent<Renderer>();
      return this.mRenderer;
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
            UnityEngine.Material material = new UnityEngine.Material(sharedMaterial);
            material.name += " (Copy)";
            materialList.Add(material);
          }
        }
        this.mMats = materialList.ToArray();
      }
      if (this.CheckMaterial(this.mMats) && Application.isPlaying && this.cachedRenderer.materials != this.mMats)
        this.cachedRenderer.materials = this.mMats;
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
      if (!this.CheckMaterial(this.mMats) || !((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null))
        return;
      this.renderQueue = this.drawCall.finalRenderQueue;
      for (int index = 0; index < this.mMats.Length; ++index)
      {
        if (this.mMats[index].renderQueue != this.renderQueue)
          this.mMats[index].renderQueue = this.renderQueue;
      }
    }
    else
    {
      if (!this.ExistSharedMaterial0() || !((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null))
        return;
      this.renderQueue = this.drawCall.finalRenderQueue;
      for (int index = 0; index < this.cachedRenderer.sharedMaterials.Length; ++index)
      {
        if ((UnityEngine.Object) this.cachedRenderer.sharedMaterials[index] != (UnityEngine.Object) null)
          this.cachedRenderer.sharedMaterials[index].renderQueue = this.renderQueue;
      }
    }
  }

  private void LateUpdate() => this.OnUpdate();

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
