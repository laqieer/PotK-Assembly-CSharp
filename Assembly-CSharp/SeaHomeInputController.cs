// Decompiled with JetBrains decompiler
// Type: SeaHomeInputController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SeaHomeInputController : MonoBehaviour
{
  [SerializeField]
  private SeaHomeCameraController cameraController;
  [SerializeField]
  private SeaHomeManager sceneObject;

  private void OnEnable() => UICamera.fallThrough = this.gameObject;

  private void OnDisable() => UICamera.fallThrough = (GameObject) null;

  private void OnClick()
  {
    if (UICamera.touchCount <= 0)
      return;
    this.sceneObject.SetTouchBipObject(this.hitObject("3DModels"));
  }

  private GameObject hitObject(string layer)
  {
    RaycastHit raycastHit = new RaycastHit();
    Ray ray = this.cameraController.mainCamera.ScreenPointToRay((Vector3) UICamera.lastTouchPosition);
    int num = 1 << LayerMask.NameToLayer(layer);
    ref RaycastHit local = ref raycastHit;
    int layerMask = num;
    return Physics.Raycast(ray, out local, 100f, layerMask) ? raycastHit.collider.gameObject : (GameObject) null;
  }
}
