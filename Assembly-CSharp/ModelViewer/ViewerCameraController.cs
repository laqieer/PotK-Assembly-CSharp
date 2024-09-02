// Decompiled with JetBrains decompiler
// Type: ModelViewer.ViewerCameraController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace ModelViewer
{
  public class ViewerCameraController : MonoBehaviour
  {
    [SerializeField]
    private float defaultCameraDistanceValue = 3f;
    [SerializeField]
    private float defaultCameraRotateValue = 200f;
    [SerializeField]
    private float minRotationX = -25f;
    [SerializeField]
    private float maxRotationX = 80f;
    [SerializeField]
    private float minDistance = 2.3f;
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    private float targetOffsetY = 1.17f;
    [SerializeField]
    private float targetOffsetYAnimals = 1.76f;
    [SerializeField]
    private float dumpingRatio = 0.01f;
    [SerializeField]
    private Vector2 rangeMove = new Vector2(0.5f, 1f);
    private ViewerCameraInput viewerInput = new ViewerCameraInput();
    private Transform cameraTargetTransform;
    private Camera NGUICamera;
    private float cameraDistanceRatio;
    private float cameraRotateRatio;
    private Vector3 currentTargetOffset = Vector3.zero;
    private Vector3 currentTargetPosition = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 currentTargetRotation = new Vector3(40f, 0.0f, 0.0f);
    private float currentTargetDistance = 10f;

    public void Initialize(Transform target, bool unitWithAnimals, bool bReset)
    {
      this.cameraTargetTransform = target;
      if (!bReset)
        return;
      this.currentTargetPosition.Set(0.0f, unitWithAnimals ? this.targetOffsetYAnimals : this.targetOffsetY, 0.0f);
      this.currentTargetRotation.Set(0.0f, 0.0f, 0.0f);
      this.currentTargetDistance = Vector3.Distance(this.transform.position, target.position);
      this.NGUICamera = Singleton<CommonRoot>.GetInstance().getCamera();
      this.viewerInput.Initialize(this.dumpingRatio);
      this.AdjustInputValue();
    }

    private void OnApplicationPause(bool isPause)
    {
      if (!isPause || this.viewerInput == null)
        return;
      this.viewerInput.ClearInputParameter();
    }

    private void OnEnable()
    {
      if (this.viewerInput == null)
        return;
      this.viewerInput.ClearInputParameter();
    }

    private void LateUpdate()
    {
      if ((Object) this.cameraTargetTransform == (Object) null)
        return;
      this.viewerInput.UpdateParameter();
      if (this.IsTouchUI())
      {
        this.UpdateCameraTransform();
      }
      else
      {
        this.UpdateCameraRotate();
        this.UpdateCameraTargetDistance();
        this.UpdateCameraTransform();
      }
    }

    private void UpdateCameraTransform()
    {
      Vector3 vector3_1 = this.cameraTargetTransform.position + this.currentTargetPosition;
      this.transform.rotation = Quaternion.Euler(this.currentTargetRotation.x, this.currentTargetRotation.y, this.currentTargetRotation.z);
      Vector3 vector3_2 = Quaternion.Euler(this.currentTargetRotation.x, this.currentTargetRotation.y, this.currentTargetRotation.z) * Vector3.back;
      this.currentTargetOffset -= this.viewerInput.GetCameraMove();
      this.currentTargetOffset.x = Mathf.Clamp(this.currentTargetOffset.x, -this.rangeMove.x, this.rangeMove.x);
      this.currentTargetOffset.y = Mathf.Clamp(this.currentTargetOffset.y, -this.rangeMove.y, this.rangeMove.y);
      this.transform.position = vector3_1 + this.transform.up * this.currentTargetOffset.y + this.transform.right * this.currentTargetOffset.x + this.currentTargetDistance * vector3_2;
    }

    private void UpdateCameraRotate()
    {
      Vector3 cameraRotate = this.viewerInput.GetCameraRotate();
      this.currentTargetRotation.x -= cameraRotate.x * this.cameraRotateRatio;
      this.currentTargetRotation.y += cameraRotate.y * this.cameraRotateRatio;
      this.currentTargetRotation.x = Mathf.Clamp(this.currentTargetRotation.x, this.minRotationX, this.maxRotationX);
    }

    private void UpdateCameraTargetDistance()
    {
      this.currentTargetDistance -= this.viewerInput.TargetDistance() * this.cameraDistanceRatio;
      this.currentTargetDistance -= this.viewerInput.TargetWheelDistance();
      if ((double) this.currentTargetDistance < 0.100000001490116)
        this.currentTargetDistance = 0.1f;
      this.currentTargetDistance = Mathf.Clamp(this.currentTargetDistance, this.minDistance, this.maxDistance);
    }

    private void AdjustInputValue()
    {
      int num = Screen.width < Screen.height ? Screen.width : Screen.height;
      this.cameraDistanceRatio = this.defaultCameraDistanceValue / (float) num;
      this.cameraRotateRatio = this.defaultCameraRotateValue / (float) num;
    }

    private bool IsTouchUI() => !((Object) this.NGUICamera == (Object) null) && (this.CheckUICollision(Input.mousePosition) || this.viewerInput.IsTouchingDisplay() && this.CheckUICollision(this.viewerInput.GetTouchPosition()));

    private bool CheckUICollision(Vector3 touchPosition)
    {
      RaycastHit hitInfo;
      if (!Physics.Raycast(this.NGUICamera.ScreenPointToRay(touchPosition), out hitInfo) || hitInfo.transform.gameObject.layer != LayerMask.NameToLayer("2DUnity"))
        return false;
      this.viewerInput.ClearInputParameter();
      return true;
    }
  }
}
