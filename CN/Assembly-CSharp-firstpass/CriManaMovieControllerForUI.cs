﻿// Decompiled with JetBrains decompiler
// Type: CriManaMovieControllerForUI
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("CRIWARE/CriManaMovieControllerForUI")]
public class CriManaMovieControllerForUI : CriManaMovieMaterial
{
  public Graphic target;
  public bool useOriginalMaterial;
  private Material originalMaterial;

  protected override void Start()
  {
    base.Start();
    if (Object.op_Equality((Object) this.target, (Object) null))
      this.target = ((Component) this).gameObject.GetComponent<Graphic>();
    if (Object.op_Equality((Object) this.target, (Object) null))
    {
      Debug.LogError((object) "[CRIWARE] error");
      Object.Destroy((Object) this);
    }
    else
    {
      this.originalMaterial = this.target.material;
      if (this.useOriginalMaterial)
        return;
      ((Behaviour) this.target).enabled = false;
    }
  }

  protected override void OnDestroy()
  {
    this.target.material = this.originalMaterial;
    if (!this.useOriginalMaterial)
      ((Behaviour) this.target).enabled = false;
    this.originalMaterial = (Material) null;
    base.OnDestroy();
  }

  protected override void OnMaterialAvailableChanged()
  {
    if (this.isMaterialAvailable)
    {
      this.target.material = this.material;
      ((Behaviour) this.target).enabled = true;
    }
    else
    {
      this.target.material = this.originalMaterial;
      if (this.useOriginalMaterial)
        return;
      ((Behaviour) this.target).enabled = false;
    }
  }
}
