// Decompiled with JetBrains decompiler
// Type: BattleCameraController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class BattleCameraController : BattleMonoBehaviour
{
  protected Vector3 lookAtTarget;
  protected Vector3 lookAtVelocity = Vector3.zero;
  protected float translateSmoothTime = 0.3f;
  public float sightDistance;
  protected Vector3 sightVelocity = Vector3.zero;
  protected float sightSmoothTime = 0.3f;
  protected Transform cameraTransform;
  protected Transform lookAt;
  protected Transform positionOffset;
  protected Transform angle;
  protected Camera cCamera;
  private Vector3 screenPoint;

  public bool isCameraMove
  {
    get
    {
      return !Object.op_Equality((Object) this.lookAt, (Object) null) && Vector3.op_Inequality(this.lookAtTarget, this.lookAt.position);
    }
  }

  protected void initVariables()
  {
    Camera[] componentsInChildren = this.battleManager.battleCamera.GetComponentsInChildren<Camera>(true);
    if (componentsInChildren == null || componentsInChildren.Length == 0)
      return;
    this.cCamera = componentsInChildren[0];
    this.cameraTransform = this.battleManager.battleCamera.transform;
    this.angle = this.cameraTransform.parent;
    this.positionOffset = this.angle.parent;
    this.lookAt = this.positionOffset.parent;
    this.positionOffset.localPosition = this.battleManager.cameraPositionOffsetValue;
    this.angle.localRotation = Quaternion.Euler(this.battleManager.cameraAngle, this.battleManager.cameraAngleYValue, 0.0f);
    this.lookAt.position = this.lookAtTarget;
    this.cameraTransform.localPosition = new Vector3(0.0f, 0.0f, -this.sightDistance);
  }

  protected override void Update_Battle()
  {
    if (Object.op_Equality((Object) this.cameraTransform, (Object) null))
    {
      if (Object.op_Equality((Object) this.battleManager.battleCamera, (Object) null))
        return;
      this.initVariables();
    }
    if (this.isCameraMove)
    {
      this.lookAt.position = Vector3.SmoothDamp(this.lookAt.position, this.lookAtTarget, ref this.lookAtVelocity, this.translateSmoothTime);
      Vector3 vector3 = Vector3.op_Subtraction(this.lookAtTarget, this.lookAt.position);
      if ((double) ((Vector3) ref vector3).magnitude < 0.0099999997764825821)
      {
        this.lookAtTarget = this.lookAt.position;
        this.lookAtVelocity = Vector3.zero;
      }
    }
    if ((double) this.sightDistance != (double) this.cameraTransform.localPosition.z)
      this.cameraTransform.localPosition = Vector3.SmoothDamp(this.cameraTransform.localPosition, new Vector3(0.0f, 0.0f, -this.sightDistance), ref this.sightVelocity, this.sightSmoothTime);
    else
      this.sightVelocity = Vector3.zero;
    this.cameraTransform.LookAt(this.positionOffset);
  }

  public void setLookAtTarget(BL.Panel panel, bool noSmooth = false)
  {
    this.lookAtTarget = this.env.panelResource[panel].gameObject.transform.position;
    if (!noSmooth)
      return;
    this.lookAt.position = this.lookAtTarget;
  }

  public void setLookAtTarget(Vector3 v, bool noSmooth = false)
  {
    this.lookAtTarget = this.env.limitFieldPosition(v);
    if (!noSmooth)
      return;
    this.lookAt.position = this.lookAtTarget;
  }

  public void onPress()
  {
    if (Object.op_Equality((Object) this.cCamera, (Object) null))
      return;
    this.screenPoint = this.cCamera.WorldToScreenPoint(this.lookAt.position);
  }

  public void onDrag(Vector2 delta)
  {
    if (Object.op_Equality((Object) this.cCamera, (Object) null))
      return;
    this.screenPoint.x -= delta.x;
    this.screenPoint.y -= delta.y;
    this.setLookAtTarget(this.cCamera.ScreenToWorldPoint(new Vector3(this.screenPoint.x, this.screenPoint.y, this.cCamera.WorldToScreenPoint(this.lookAt.position).z)));
  }

  public void onRelease()
  {
  }

  public void onCancel()
  {
  }
}
