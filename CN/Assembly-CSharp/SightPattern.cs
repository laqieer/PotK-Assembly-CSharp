// Decompiled with JetBrains decompiler
// Type: SightPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class SightPattern
{
  [SerializeField]
  private GameObject sightImage;
  [SerializeField]
  private Vector3 mapScale;
  [SerializeField]
  private float scrollPower;

  public GameObject SightImage => this.sightImage;

  public Vector3 MapScale => this.mapScale;

  public float ScrollPower => this.scrollPower;
}
