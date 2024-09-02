// Decompiled with JetBrains decompiler
// Type: GridSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class GridSetting
{
  [Tooltip("単位幅")]
  public int width = 123;
  [Tooltip("単位高さ")]
  public int height = 147;
  [Tooltip("列数")]
  public int column = 5;
  [Tooltip("オブジェクト生成行数")]
  public int rowInstance = 8;
  [Tooltip("みなし表示行数")]
  public int rowScreen = 5;

  public int quantityScreen => this.column * this.rowScreen;

  public int quantityInstance => this.column * this.rowInstance;

  public Tuple<GameObject, GameObject> setScrollRange(
    Transform parent,
    string topName,
    string bottomName,
    int numObject)
  {
    Vector3 rhs1 = new Vector3(float.MaxValue, float.MaxValue, 0.0f);
    Vector3 rhs2 = new Vector3(float.MinValue, float.MinValue, 0.0f);
    Vector3 lhs1 = this.calcLocalPosition(0);
    Vector3 rhs3 = Vector3.Min(lhs1, rhs1);
    Vector3 rhs4 = Vector3.Max(lhs1, rhs2);
    Vector3 lhs2 = this.calcLocalPosition(this.column - 1);
    Vector3 rhs5 = Vector3.Min(lhs2, rhs3);
    Vector3 rhs6 = Vector3.Max(lhs2, rhs4);
    if (numObject > this.column)
    {
      Vector3 lhs3 = this.calcLocalPosition(numObject - 1);
      rhs5 = Vector3.Min(lhs3, rhs5);
      rhs6 = Vector3.Max(lhs3, rhs6);
    }
    float num1 = (float) this.width / 2f;
    float num2 = (float) this.height / 2f;
    rhs5.x -= num1;
    rhs5.y -= num2;
    rhs6.x += num1;
    rhs6.y += num2;
    return Tuple.Create<GameObject, GameObject>(this.createWidgetObject(parent, topName, new Vector3(rhs5.x, rhs6.y, 0.0f), UIWidget.Pivot.TopLeft), this.createWidgetObject(parent, bottomName, new Vector3(rhs6.x, rhs5.y, 0.0f), UIWidget.Pivot.BottomRight));
  }

  private GameObject createWidgetObject(
    Transform parent,
    string objName,
    Vector3 pos,
    UIWidget.Pivot pivot)
  {
    Transform orCreateChild = parent.FindOrCreateChild(objName);
    orCreateChild.gameObject.layer = parent.gameObject.layer;
    UIWidget orAddComponent = orCreateChild.gameObject.GetOrAddComponent<UIWidget>();
    orAddComponent.pivot = pivot;
    orAddComponent.SetDimensions(2, 2);
    orCreateChild.localPosition = pos;
    return orCreateChild.gameObject;
  }

  public Vector3 calcLocalPosition(int index) => new Vector3((float) (index % this.column * this.width - this.width * 2), (float) -(index / this.column * this.height), 0.0f);
}
