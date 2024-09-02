// Decompiled with JetBrains decompiler
// Type: GameCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GameCamera : MonoBehaviour
{
  public static GameCamera Instance;
  private Quaternion m_EulerRotation;
  private Transform m_mainCamera;
  public Transform Target;
  public bool FixedCamera;
  public Vector3 FixedPostion = Vector3.zero;
  public bool IsFromCutscene;
  public float Distance = 13f;
  public float MinDistance = 8f;
  public float MaxDistance = 13f;
  public Vector2 OriginRotation = new Vector2(35f, 0.0f);
  [HideInInspector]
  public float MinAngle;
  [HideInInspector]
  public float MaxAngle = 90f;
  [HideInInspector]
  public bool AllowZoom = true;
  [HideInInspector]
  public bool AllowRotation = true;
  [HideInInspector]
  public float DistanceOffset;
  [HideInInspector]
  public Vector2 RotationOffset = Vector2.zero;
  [HideInInspector]
  public Vector3 PositionOffset = Vector3.zero;

  public void Awake()
  {
    GameCamera.Instance = this;
    this.m_mainCamera = ((Component) this).transform;
  }

  public void Start()
  {
    if (!this.FixedCamera)
      ;
  }

  public void Update()
  {
    if (this.FixedCamera)
      return;
    if (Object.op_Implicit((Object) this.Target) && this.AllowZoom)
    {
      float zoomFactor;
      if (SimpleInput.GetZoom(out zoomFactor))
      {
        this.Distance += zoomFactor;
        this.Distance = Mathf.Clamp(this.Distance, this.MinDistance, this.MaxDistance);
      }
      else if ((double) this.MaxDistance - (double) this.Distance > 2.0)
      {
        this.StopCoroutine("ZoomCamera");
        this.StartCoroutine("ZoomCamera", (object) this.MinDistance);
      }
      else
      {
        this.StopCoroutine("ZoomCamera");
        this.StartCoroutine("ZoomCamera", (object) this.MaxDistance);
      }
    }
    if (!this.AllowRotation || !SimpleInput.GetMouseRight(out float _, out float _))
      return;
    this.OriginRotation.y += Input.GetAxis("Mouse X") * 5f;
    this.ClampRotation();
    this.OriginRotation.x -= Input.GetAxis("Mouse Y") * 5f;
    this.OriginRotation.x = Mathf.Clamp(this.OriginRotation.x, this.MinAngle, this.MaxAngle);
    this.ClampRotation();
  }

  [DebuggerHidden]
  private IEnumerator ZoomCamera(float dest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GameCamera.\u003CZoomCamera\u003Ec__Iterator2()
    {
      dest = dest,
      \u003C\u0024\u003Edest = dest,
      \u003C\u003Ef__this = this
    };
  }

  public void FixedUpdate()
  {
    if (!Object.op_Implicit((Object) this.Target))
      return;
    this.m_EulerRotation = Quaternion.Euler(this.OriginRotation.x + this.RotationOffset.x, this.OriginRotation.y + this.RotationOffset.y, 0.0f);
    this.m_mainCamera.position = Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(Quaternion.op_Multiply(this.m_EulerRotation, new Vector3(0.0f, 0.0f, (float) -((double) this.Distance + (double) this.DistanceOffset))), this.Target.position), this.PositionOffset), new Vector3(0.0f, 1f, 0.0f));
    this.m_mainCamera.rotation = this.m_EulerRotation;
  }

  public void SetTargetPosition(Vector3 position)
  {
    this.FixedPostion = position;
    this.m_EulerRotation = Quaternion.Euler(this.OriginRotation.x, this.OriginRotation.y, 0.0f);
    this.m_mainCamera.position = Vector3.op_Addition(Vector3.op_Addition(Quaternion.op_Multiply(this.m_EulerRotation, new Vector3(0.0f, 0.0f, -this.Distance)), this.FixedPostion), new Vector3(0.0f, 1f, 0.0f));
    this.m_mainCamera.rotation = this.m_EulerRotation;
  }

  private void ClampRotation()
  {
    if ((double) this.OriginRotation.x < -180.0)
      this.OriginRotation.x += 360f;
    else if ((double) this.OriginRotation.x > 180.0)
      this.OriginRotation.x -= 360f;
    if ((double) this.OriginRotation.y < -180.0)
    {
      this.OriginRotation.y += 360f;
    }
    else
    {
      if ((double) this.OriginRotation.y <= 180.0)
        return;
      this.OriginRotation.y -= 360f;
    }
  }
}
