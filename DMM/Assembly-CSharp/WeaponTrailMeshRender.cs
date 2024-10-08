﻿// Decompiled with JetBrains decompiler
// Type: WeaponTrailMeshRender
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class WeaponTrailMeshRender : MonoBehaviour
{
  private const int snapSize = 64;
  public Color MeshCurrentColor;
  public int MeshSplitCount = 512;
  public float MeshHeight = 1.1f;
  public float CurveVolume = 0.5f;
  public Transform CaptureTarget;
  public UnityEngine.Material WeaponTrailMaterial;
  public List<DirectionPoint> snapDirectionPoints;
  private bool isOn;
  private MeshFilter meshFilter;
  private MeshRenderer meshRenderer;

  private void Update()
  {
    if (!this.isOn)
      return;
    this.snap();
    if (this.snapDirectionPoints.Count<DirectionPoint>() < 2)
      return;
    this.renderMesh(this.MeshSplitCount);
  }

  public void On()
  {
    this.isOn = true;
    this.snapDirectionPoints = new List<DirectionPoint>();
    this.meshFilter = this.gameObject.AddComponent<MeshFilter>();
    this.meshFilter.mesh = new Mesh();
    this.meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
    this.meshRenderer.material = this.WeaponTrailMaterial;
  }

  public void Off()
  {
    this.isOn = false;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  private void snap()
  {
    this.snapDirectionPoints.Insert(0, new DirectionPoint(this.CaptureTarget.TransformDirection(Vector3.up), this.CaptureTarget.position));
    if (this.snapDirectionPoints.Count <= 64)
      return;
    this.snapDirectionPoints.RemoveAt(this.snapDirectionPoints.Count - 1);
  }

  private void renderMesh(int splitCount)
  {
    DirectionPoint[] array = this.snapDirectionPoints.ToArray();
    TCurve tcurve1 = new TCurve(this.snapDirectionPoints.Select<DirectionPoint, DirectionPoint>((Func<DirectionPoint, DirectionPoint>) (x => new DirectionPoint(x.Direction, x.Point + x.Direction * this.MeshHeight))).ToArray<DirectionPoint>());
    TCurve tcurve2 = new TCurve(array);
    int n = splitCount;
    double curveVolume = (double) this.CurveVolume;
    DirectionPoint[] directionPointArray1 = tcurve1.Points(n, (float) curveVolume);
    DirectionPoint[] directionPointArray2 = tcurve2.Points(splitCount, 0.0f);
    int length = splitCount * 2;
    Vector3[] vector3Array = new Vector3[length];
    Vector2[] vector2Array = new Vector2[length];
    Color[] colorArray = new Color[length];
    Matrix4x4 worldToLocalMatrix = this.transform.worldToLocalMatrix;
    float num = (float) splitCount - 1f;
    for (int index1 = 0; index1 < splitCount; ++index1)
    {
      int index2 = index1 * 2;
      float x = (num - (float) index1) / num;
      vector3Array[index2] = worldToLocalMatrix.MultiplyPoint(directionPointArray1[index1].Point);
      vector3Array[index2 + 1] = worldToLocalMatrix.MultiplyPoint(directionPointArray2[index1].Point);
      vector2Array[index2] = new Vector2(x, 0.0f);
      vector2Array[index2 + 1] = new Vector2(x, 1f);
      colorArray[index2] = this.MeshCurrentColor;
      colorArray[index2 + 1] = this.MeshCurrentColor;
    }
    int[] numArray = new int[(length - 2) * 3];
    for (int index1 = 0; index1 < numArray.Length / 6; ++index1)
    {
      int index2 = index1 * 6;
      numArray[index2] = index1 * 2;
      numArray[index2 + 1] = index1 * 2 + 1;
      numArray[index2 + 2] = index1 * 2 + 2;
      numArray[index2 + 3] = index1 * 2 + 2;
      numArray[index2 + 4] = index1 * 2 + 1;
      numArray[index2 + 5] = index1 * 2 + 3;
    }
    Mesh mesh = this.meshFilter.mesh;
    mesh.Clear();
    mesh.vertices = vector3Array;
    mesh.colors = colorArray;
    mesh.uv = vector2Array;
    mesh.triangles = numArray;
  }
}
