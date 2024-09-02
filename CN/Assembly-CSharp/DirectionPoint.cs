// Decompiled with JetBrains decompiler
// Type: DirectionPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
