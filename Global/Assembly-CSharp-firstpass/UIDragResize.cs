// Decompiled with JetBrains decompiler
// Type: UIDragResize
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Drag-Resize Widget")]
public class UIDragResize : MonoBehaviour
{
  public UIWidget target;
  public UIWidget.Pivot pivot = UIWidget.Pivot.BottomRight;
  public int minWidth = 100;
  public int minHeight = 100;
  public int maxWidth = 100000;
  public int maxHeight = 100000;
  private Plane mPlane;
  private Vector3 mRayPos;
  private Vector3 mLocalPos;
  private int mWidth;
  private int mHeight;
  private bool mDragging;

  private void OnDragStart()
  {
    if (!Object.op_Inequality((Object) this.target, (Object) null))
      return;
    Vector3[] worldCorners = this.target.worldCorners;
    this.mPlane = new Plane(worldCorners[0], worldCorners[1], worldCorners[3]);
    Ray currentRay = UICamera.currentRay;
    float num;
    if (!((Plane) ref this.mPlane).Raycast(currentRay, ref num))
      return;
    this.mRayPos = ((Ray) ref currentRay).GetPoint(num);
    this.mLocalPos = this.target.cachedTransform.localPosition;
    this.mWidth = this.target.width;
    this.mHeight = this.target.height;
    this.mDragging = true;
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.mDragging || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    Ray currentRay = UICamera.currentRay;
    float num;
    if (!((Plane) ref this.mPlane).Raycast(currentRay, ref num))
      return;
    Transform cachedTransform = this.target.cachedTransform;
    cachedTransform.localPosition = this.mLocalPos;
    this.target.width = this.mWidth;
    this.target.height = this.mHeight;
    Vector3 vector3_1 = Vector3.op_Subtraction(((Ray) ref currentRay).GetPoint(num), this.mRayPos);
    cachedTransform.position = Vector3.op_Addition(cachedTransform.position, vector3_1);
    Vector3 vector3_2 = Quaternion.op_Multiply(Quaternion.Inverse(cachedTransform.localRotation), Vector3.op_Subtraction(cachedTransform.localPosition, this.mLocalPos));
    cachedTransform.localPosition = this.mLocalPos;
    NGUIMath.ResizeWidget(this.target, this.pivot, vector3_2.x, vector3_2.y, this.minWidth, this.minHeight, this.maxWidth, this.maxHeight);
  }

  private void OnDragEnd() => this.mDragging = false;
}
