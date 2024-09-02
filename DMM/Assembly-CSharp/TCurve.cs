// Decompiled with JetBrains decompiler
// Type: TCurve
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TCurve
{
  private readonly DirectionPoint[] directionPoints;
  private readonly float[] distances;
  private readonly float totalDistance;

  public TCurve(DirectionPoint[] directionPoints_)
  {
    this.directionPoints = directionPoints_;
    int length = this.directionPoints.Length - 1;
    this.distances = new float[length];
    for (int index = 0; index < length; ++index)
    {
      this.totalDistance += Mathf.Abs(Vector3.Distance(this.directionPoints[index].Point, this.directionPoints[index + 1].Point));
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
    int index1 = this.directionPoints.Length - 2;
    for (int index2 = 0; index2 < this.distances.Length; ++index2)
    {
      if ((double) num1 <= (double) this.distances[index2])
      {
        index1 = index2;
        break;
      }
    }
    Vector3 point1 = this.directionPoints[index1].Point;
    Vector3 point2 = this.directionPoints[index1 + 1].Point;
    float num2 = index1 > 0 ? this.distances[index1 - 1] : 0.0f;
    float t1 = (float) (((double) num1 - (double) num2) / ((double) this.distances[index1] - (double) num2));
    Vector3 direction = Vector3.Lerp(this.directionPoints[index1].Direction, this.directionPoints[index1 + 1].Direction, t1);
    Vector3 b = point2;
    double num3 = (double) t1;
    Vector3 point3 = Vector3.Lerp(point1, b, (float) num3) + direction * curve * Mathf.Pow((double) t1 >= 0.5 ? 1f - t1 : t1, 0.5f);
    return new DirectionPoint(direction, point3);
  }
}
