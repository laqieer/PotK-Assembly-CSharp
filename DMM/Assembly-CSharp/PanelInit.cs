// Decompiled with JetBrains decompiler
// Type: PanelInit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PanelInit : MonoBehaviour
{
  private Vector3[] vertex;
  private BoxTransform bxT;
  public float mPanelHeight;
  public float panelFloat;

  public float panelHeight => this.mPanelHeight * this.transform.localScale.y;

  public float panelHeightNonScale => this.mPanelHeight;

  private void Awake()
  {
    this.bxT = this.GetComponent<BoxTransform>();
    this.mPanelHeight = 0.0f;
  }

  private void Update()
  {
  }

  private Vector3 initVertex(PanelInit.VertexKind kind)
  {
    Vector3 vector3 = new Vector3();
    vector3.y = 0.0f;
    switch (kind)
    {
      case PanelInit.VertexKind.RightUp:
        vector3.x = 0.5f;
        vector3.z = 0.5f;
        break;
      case PanelInit.VertexKind.LeftUp:
        vector3.x = -0.5f;
        vector3.z = 0.5f;
        break;
      case PanelInit.VertexKind.LeftDown:
        vector3.x = -0.5f;
        vector3.z = -0.5f;
        break;
      case PanelInit.VertexKind.RightDown:
        vector3.x = 0.5f;
        vector3.z = -0.5f;
        break;
    }
    return vector3;
  }

  public void Init()
  {
    float x = this.transform.localScale.x;
    float num1 = 0.0f;
    Matrix4x4 identity1 = Matrix4x4.identity;
    identity1.m00 = x;
    identity1.m11 = x;
    identity1.m22 = x;
    Matrix4x4 identity2 = Matrix4x4.identity;
    identity2.m00 = 1f / x;
    identity2.m11 = 1f / x;
    identity2.m22 = 1f / x;
    for (int index = 0; index < 4; ++index)
    {
      Vector3 point1 = this.initVertex((PanelInit.VertexKind) index);
      Vector3 origin = identity1.MultiplyPoint3x4(point1);
      origin += this.transform.position;
      origin.y += 50f;
      int layerMask = 1 << LayerMask.NameToLayer("Terrain");
      RaycastHit hitInfo;
      if (Physics.Raycast(origin, Vector3.down, out hitInfo, 100f, layerMask))
      {
        Vector3 point2 = hitInfo.point - this.transform.position;
        Vector3 pos = identity2.MultiplyPoint3x4(point2);
        num1 += pos.y;
        this.SetSquare((PanelInit.VertexKind) index, pos);
      }
      else
      {
        Vector3 point2 = origin - this.transform.position;
        Vector3 pos = identity2.MultiplyPoint3x4(point2);
        pos.y = 0.0f;
        this.SetSquare((PanelInit.VertexKind) index, pos);
      }
    }
    float num2 = num1 / 4f;
    this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
    this.mPanelHeight = num2;
    this.bxT.SetMesh();
    BoxCollider component = this.GetComponent<BoxCollider>();
    Vector3 vector3 = new Vector3(component.center.x, this.mPanelHeight, component.center.z);
    component.center = vector3;
  }

  private void SetSquare(PanelInit.VertexKind iType, Vector3 pos)
  {
    pos.y += this.panelFloat;
    this.bxT.SetVertices((int) iType, pos);
  }

  public enum VertexKind
  {
    RightUp,
    LeftUp,
    LeftDown,
    RightDown,
    Max,
  }
}
