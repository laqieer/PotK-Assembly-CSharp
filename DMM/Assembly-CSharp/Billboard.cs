// Decompiled with JetBrains decompiler
// Type: Billboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Billboard : BattleMonoBehaviour
{
  private Vector3 savePos;
  private Vector3 saveCameraPos;
  private Quaternion saveCameraRot;
  private GameObject bc;
  private Camera c;

  protected override IEnumerator Start_Battle()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Billboard billboard = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    billboard.savePos = Vector3.zero;
    billboard.saveCameraPos = Vector3.zero;
    billboard.saveCameraRot = Quaternion.identity;
    billboard.calc(billboard.battleManager.battleCamera);
    return false;
  }

  private void calc(GameObject co)
  {
    if ((Object) co == (Object) null)
      return;
    if ((Object) this.bc != (Object) co)
    {
      this.bc = co;
      Camera[] componentsInChildren = co.GetComponentsInChildren<Camera>(true);
      if (componentsInChildren.Length == 0)
        return;
      this.c = componentsInChildren[0];
    }
    Transform transform = co.transform;
    Vector3 forward = transform.forward;
    forward.Normalize();
    Vector3 position = this.transform.position;
    this.transform.position = transform.position + forward * (this.c.nearClipPlane + 1f / 1000f);
    this.transform.LookAt(this.transform.position + transform.rotation * Vector3.back, transform.rotation * Vector3.up);
    this.transform.position = position;
    this.saveCameraRot = transform.rotation;
    this.saveCameraPos = transform.position;
    this.savePos = position;
  }

  protected override void Update_Battle()
  {
    if ((Object) this.battleManager == (Object) null || (Object) this.battleManager.battleCamera == (Object) null)
      return;
    Transform transform = this.battleManager.battleCamera.transform;
    if (!(this.savePos != this.transform.position) && !(this.saveCameraPos != transform.position) && !(this.saveCameraRot != transform.rotation))
      return;
    this.calc(this.battleManager.battleCamera);
  }
}
