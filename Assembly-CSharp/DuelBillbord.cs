// Decompiled with JetBrains decompiler
// Type: DuelBillbord
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DuelBillbord : MonoBehaviour
{
  private Vector3 savePos;
  private Vector3 saveCameraPos;
  private Quaternion saveCameraRot;
  private NGDuelManager mng;

  private void Start()
  {
    this.savePos = Vector3.zero;
    this.saveCameraPos = Vector3.zero;
    this.saveCameraRot = Quaternion.identity;
    GameObject gameObject = GameObject.Find("Duel3DRoot");
    if (!((Object) null != (Object) gameObject))
      return;
    this.mng = gameObject.GetComponent<NGDuelManager>();
    this.calc(this.mng.currentCamera);
  }

  private void Update()
  {
    if ((Object) null == (Object) this.mng || (Object) null == (Object) this.mng.currentCamera)
      return;
    Transform transform = this.mng.currentCamera.transform;
    if (!(this.savePos != this.transform.position) && !(this.saveCameraPos != transform.position) && !(this.saveCameraRot != transform.rotation))
      return;
    this.calc(this.mng.currentCamera);
  }

  private void calc(GameObject co)
  {
    if ((Object) co == (Object) null)
      return;
    Vector3 vector3 = Vector3.back;
    if (co.name.Contains("maya"))
      vector3 = Vector3.forward;
    Camera[] componentsInChildren = co.GetComponentsInChildren<Camera>(true);
    if (componentsInChildren.Length == 0)
      return;
    Camera camera = componentsInChildren[0];
    Transform transform = co.transform;
    Vector3 forward = transform.forward;
    forward.Normalize();
    Vector3 position = this.transform.position;
    this.transform.position = transform.position + forward * (camera.nearClipPlane + 1f / 1000f);
    this.transform.LookAt(this.transform.position + transform.rotation * vector3, transform.rotation * Vector3.up);
    this.transform.position = position;
    this.saveCameraRot = transform.rotation;
    this.saveCameraPos = transform.position;
    this.savePos = position;
  }
}
