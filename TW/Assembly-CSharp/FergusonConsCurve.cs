// Decompiled with JetBrains decompiler
// Type: FergusonConsCurve
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FergusonConsCurve
{
  private readonly DirectionPoint[] points;
  private readonly float[] distances;
  private readonly float totalDistance;

  public FergusonConsCurve(DirectionPoint[] points_)
  {
    int length = points_.Length;
    this.points = points_;
    this.distances = new float[length - 1];
    for (int index = 0; index < length - 1; ++index)
    {
      this.totalDistance += Mathf.Abs(Vector3.Distance(this.points[index].Point, this.points[index + 1].Point));
      this.distances[index] = this.totalDistance;
    }
  }

  public DirectionPoint[] Points(int n, float curve)
  {
    DirectionPoint[] directionPointArray = new DirectionPoint[n];
    float num = (float) (n - 1);
    for (int index = 0; index < n; ++index)
      directionPointArray[index] = this.Point((float) index / num, curve);
    return directionPointArray;
  }

  private DirectionPoint Point(float t, float curve)
  {
    if ((double) t < 0.0 | (double) t > 1.0)
    {
      Debug.LogError((object) ("out of range 0 <= t <= 1. but t = " + (object) t));
      return DirectionPoint.Zero();
    }
    float num1 = this.totalDistance * t;
    int index1 = this.points.Length - 2;
    for (int index2 = 0; index2 < this.distances.Length; ++index2)
    {
      if ((double) num1 <= (double) this.distances[index2])
      {
        index1 = index2;
        break;
      }
    }
    Vector3 point1 = this.points[index1].Point;
    Vector3 point2 = this.points[index1 + 1].Point;
    float num2 = index1 <= 0 ? 0.0f : this.distances[index1 - 1];
    float t1 = (float) (((double) num1 - (double) num2) / ((double) this.distances[index1] - (double) num2));
    Vector3 direction = Vector3.Lerp(this.points[index1].Direction, this.points[index1 + 1].Direction, t1);
    float v0 = curve;
    float v1 = curve;
    Vector3 point3;
    // ISSUE: explicit constructor call
    ((Vector3) ref point3).\u002Ector(this.calc(t1, point1.x, point2.x, v0, v1), this.calc(t1, point1.y, point2.y, v0, v1), this.calc(t1, point1.z, point2.z, v0, v1));
    return new DirectionPoint(direction, point3);
  }

  private float calc(float t, float x0, float x1, float v0, float v1)
  {
    float num1 = t * t;
    float num2 = num1 * t;
    return (float) ((2.0 * (double) x0 - 2.0 * (double) x1 + (double) v0 + (double) v1) * (double) num2 + (-3.0 * (double) x0 + 3.0 * (double) x1 - 2.0 * (double) v0 - (double) v1) * (double) num1 + (double) v0 * (double) t) + x0;
  }
}
