﻿// Decompiled with JetBrains decompiler
// Type: UIOrthoCamera
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
public class UIOrthoCamera : MonoBehaviour
{
  private Camera mCam;
  private Transform mTrans;

  private void Start()
  {
    this.mCam = ((Component) this).GetComponent<Camera>();
    this.mTrans = ((Component) this).transform;
    this.mCam.orthographic = true;
  }

  private void Update()
  {
    Rect rect1 = this.mCam.rect;
    float num1 = ((Rect) ref rect1).yMin * (float) Screen.height;
    Rect rect2 = this.mCam.rect;
    float num2 = (float) (((double) (((Rect) ref rect2).yMax * (float) Screen.height) - (double) num1) * 0.5) * this.mTrans.lossyScale.y;
    if (Mathf.Approximately(this.mCam.orthographicSize, num2))
      return;
    this.mCam.orthographicSize = num2;
  }
}
