// Decompiled with JetBrains decompiler
// Type: BoxTransform
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BoxTransform : MonoBehaviour
{
  public Mesh mesh;
  public Vector3[] vertices;

  private void Awake()
  {
    this.vertices = new Vector3[4];
    this.vertices[0] = new Vector3(-1f, 0.0f, 1f);
    this.vertices[1] = new Vector3(-1f, 0.0f, -1f);
    this.vertices[2] = new Vector3(1f, 0.0f, -1f);
    this.vertices[3] = new Vector3(1f, 0.0f, 1f);
  }

  public void SetVertices(int i, Vector3 v)
  {
    if (i < 0 || i >= 4)
      return;
    this.vertices[i] = v;
  }

  public void SetMesh()
  {
    this.mesh = new Mesh();
    Vector2[] vector2Array = new Vector2[4];
    int[] numArray = new int[6];
    vector2Array[0] = new Vector2(0.0f, 0.0f);
    vector2Array[1] = new Vector2(0.0f, 1f);
    vector2Array[2] = new Vector2(1f, 1f);
    vector2Array[3] = new Vector2(1f, 0.0f);
    numArray[0] = 2;
    numArray[1] = 1;
    numArray[2] = 0;
    numArray[3] = 0;
    numArray[4] = 3;
    numArray[5] = 2;
    this.mesh.vertices = this.vertices;
    this.mesh.uv = vector2Array;
    this.mesh.triangles = numArray;
    this.mesh.RecalculateNormals();
    this.mesh.RecalculateBounds();
    ((Component) this).GetComponent<MeshFilter>().sharedMesh = this.mesh;
    ((Object) ((Component) this).GetComponent<MeshFilter>().sharedMesh).name = "myMesh";
  }
}
