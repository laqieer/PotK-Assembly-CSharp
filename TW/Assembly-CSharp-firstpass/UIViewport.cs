﻿// Decompiled with JetBrains decompiler
// Type: UIViewport
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
  public Camera sourceCamera;
  public Transform topLeft;
  public Transform bottomRight;
  public float fullSize = 1f;
  private Camera mCam;

  private void Start()
  {
    this.mCam = ((Component) this).GetComponent<Camera>();
    if (!Object.op_Equality((Object) this.sourceCamera, (Object) null))
      return;
    this.sourceCamera = Camera.main;
  }

  private void LateUpdate()
  {
    if (!Object.op_Inequality((Object) this.topLeft, (Object) null) || !Object.op_Inequality((Object) this.bottomRight, (Object) null))
      return;
    Vector3 screenPoint1 = this.sourceCamera.WorldToScreenPoint(this.topLeft.position);
    Vector3 screenPoint2 = this.sourceCamera.WorldToScreenPoint(this.bottomRight.position);
    Rect rect;
    // ISSUE: explicit constructor call
    ((Rect) ref rect).\u002Ector(screenPoint1.x / (float) Screen.width, screenPoint2.y / (float) Screen.height, (screenPoint2.x - screenPoint1.x) / (float) Screen.width, (screenPoint1.y - screenPoint2.y) / (float) Screen.height);
    float num = this.fullSize * ((Rect) ref rect).height;
    if (Rect.op_Inequality(rect, this.mCam.rect))
      this.mCam.rect = rect;
    if ((double) this.mCam.orthographicSize == (double) num)
      return;
    this.mCam.orthographicSize = num;
  }
}
