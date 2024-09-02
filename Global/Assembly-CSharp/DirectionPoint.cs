// Decompiled with JetBrains decompiler
// Type: DirectionPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class DirectionPoint
{
  public Vector3 Point;
  public Vector3 Direction;

  public DirectionPoint(Vector3 direction, Vector3 point)
  {
    this.Direction = direction;
    this.Point = point;
  }

  public static DirectionPoint Zero() => new DirectionPoint(Vector3.zero, Vector3.zero);
}
