﻿// Decompiled with JetBrains decompiler
// Type: EffectShadowController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EffectShadowController : MonoBehaviour
{
  private Transform mRoot;

  public void SetTransfome(Transform root) => this.mRoot = root;

  private void Update()
  {
    if (!((Object) this.mRoot != (Object) null))
      return;
    this.transform.localPosition = new Vector3(this.mRoot.localPosition.x, 0.0f, this.mRoot.localPosition.z);
  }
}
