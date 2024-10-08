﻿// Decompiled with JetBrains decompiler
// Type: FaceTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class FaceTexture : MonoBehaviour
{
  private UnitUnit unit;
  private Texture mNormalTexture;
  private Texture mKoyuTexture;
  private UnityEngine.Material mMaterialNormal;

  public void Initialize(UnitUnit buu, SkinnedMeshRenderer mesh)
  {
    this.unit = buu;
    this.checkFaceMaterial(mesh);
    this.mNormalTexture = this.mMaterialNormal.mainTexture;
  }

  private void checkFaceMaterial(SkinnedMeshRenderer mesh)
  {
    if (mesh.materials.Length <= 1)
    {
      this.mMaterialNormal = (UnityEngine.Material) null;
    }
    else
    {
      this.mMaterialNormal = mesh.materials[1];
      if (this.mMaterialNormal.name.Contains("_face"))
        return;
      this.mMaterialNormal = mesh.materials[0];
    }
  }

  private IEnumerator loadChgFaceTexture()
  {
    string path = string.Format("AssetBundle/Resources/Units/{0}/3D/duel/model/unit_model_face_chr", (object) this.unit.resource_reference_unit_id.ID);
    Future<UnityEngine.Sprite> go = Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(path);
    IEnumerator e = go.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.mKoyuTexture = (Texture) go.Result.texture;
    if ((Object) null != (Object) this.mKoyuTexture)
    {
      this.mMaterialNormal.mainTexture = this.mKoyuTexture;
      this.mMaterialNormal.mainTextureOffset = new Vector2(0.0f, 0.0f);
    }
  }

  public void ChangeFaceToNormal(SkinnedMeshRenderer mesh)
  {
    this.checkFaceMaterial(mesh);
    if ((Object) null == (Object) this.mMaterialNormal)
      Debug.LogWarning((object) "[FaceTexture ChangeFaceToNormal] Normal material null");
    else if ((Object) null == (Object) this.mNormalTexture)
    {
      Debug.LogWarning((object) "[FaceTexture ChangeFaceToNormal] Normal texture null");
    }
    else
    {
      if ((Object) this.mMaterialNormal.mainTexture != (Object) this.mNormalTexture)
        this.mMaterialNormal.mainTexture = this.mNormalTexture;
      if ((double) this.mMaterialNormal.mainTextureOffset.x == 0.0 && (double) this.mMaterialNormal.mainTextureOffset.y == 0.0)
        return;
      this.mMaterialNormal.mainTextureOffset = new Vector2(0.0f, 0.0f);
    }
  }

  public void ChangeFaceToAngry(SkinnedMeshRenderer mesh)
  {
    this.checkFaceMaterial(mesh);
    if ((Object) null == (Object) this.mMaterialNormal)
      Debug.LogWarning((object) "[FaceTexture ChangeFaceToAngry] Normal material null");
    else if ((Object) null == (Object) this.mNormalTexture)
      Debug.LogWarning((object) "[FaceTexture ChangeFaceToAngry] Normal texture null");
    else if ((Object) null == (Object) this.mKoyuTexture)
    {
      this.StartCoroutine(this.loadChgFaceTexture());
    }
    else
    {
      if ((Object) this.mMaterialNormal.mainTexture != (Object) this.mKoyuTexture)
        this.mMaterialNormal.mainTexture = this.mKoyuTexture;
      if ((double) this.mMaterialNormal.mainTextureOffset.x == 0.0 && (double) this.mMaterialNormal.mainTextureOffset.y == 0.0)
        return;
      this.mMaterialNormal.mainTextureOffset = new Vector2(0.0f, 0.0f);
    }
  }

  public void ChangeFaceToPain(SkinnedMeshRenderer mesh)
  {
    this.checkFaceMaterial(mesh);
    if ((Object) null == (Object) this.mMaterialNormal)
    {
      Debug.LogWarning((object) "[FaceTexture ChangeFaceToPain] Normal material null");
    }
    else
    {
      if ((Object) null == (Object) this.mNormalTexture)
        return;
      if ((Object) this.mMaterialNormal.mainTexture != (Object) this.mNormalTexture)
        this.mMaterialNormal.mainTexture = this.mNormalTexture;
      if ((double) this.mMaterialNormal.mainTextureOffset.x == 0.5 && (double) this.mMaterialNormal.mainTextureOffset.y == 0.0)
        return;
      this.mMaterialNormal.mainTextureOffset = new Vector2(0.5f, 0.0f);
    }
  }
}
