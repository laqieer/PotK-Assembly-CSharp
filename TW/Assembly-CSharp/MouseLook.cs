// Decompiled with JetBrains decompiler
// Type: MouseLook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MouseLook : MonoBehaviour
{
  public MouseLook.RotationAxes axes;
  public float sensitivityX = 15f;
  public float sensitivityY = 15f;
  public float minimumX = -360f;
  public float maximumX = 360f;
  public float minimumY = -60f;
  public float maximumY = 60f;
  private float rotationY;

  public void Update()
  {
    if (DenaLib.Singleton<GameLogic>.Instance.GameState != EGameState.ERunGame || !Input.GetMouseButton(1))
      return;
    if (this.axes == MouseLook.RotationAxes.MouseXAndY)
    {
      float num = ((Component) this).transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensitivityX;
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
      ((Component) this).transform.localEulerAngles = new Vector3(-this.rotationY, num, 0.0f);
    }
    else if (this.axes == MouseLook.RotationAxes.MouseX)
    {
      ((Component) this).transform.Rotate(0.0f, Input.GetAxis("Mouse X") * this.sensitivityX, 0.0f);
    }
    else
    {
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
      ((Component) this).transform.localEulerAngles = new Vector3(-this.rotationY, ((Component) this).transform.localEulerAngles.y, 0.0f);
    }
  }

  public enum RotationAxes
  {
    MouseXAndY,
    MouseX,
    MouseY,
  }
}
