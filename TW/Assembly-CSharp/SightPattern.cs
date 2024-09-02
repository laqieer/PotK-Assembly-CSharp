// Decompiled with JetBrains decompiler
// Type: SightPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
