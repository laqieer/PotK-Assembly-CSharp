﻿// Decompiled with JetBrains decompiler
// Type: Billboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Billboard : BattleMonoBehaviour
{
  private Vector3 savePos;
  private Vector3 saveCameraPos;
  private Quaternion saveCameraRot;
  private GameObject bc;
  private Camera c;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Billboard.\u003CStart_Battle\u003Ec__IteratorA62()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void calc(GameObject co)
  {
    if (Object.op_Equality((Object) co, (Object) null))
      return;
    if (Object.op_Inequality((Object) this.bc, (Object) co))
    {
      this.bc = co;
      Camera[] componentsInChildren = co.GetComponentsInChildren<Camera>(true);
      if (componentsInChildren.Length == 0)
        return;
      this.c = componentsInChildren[0];
    }
    Transform transform = co.transform;
    Vector3 forward = transform.forward;
    ((Vector3) ref forward).Normalize();
    Vector3 position = ((Component) this).transform.position;
    ((Component) this).transform.position = Vector3.op_Addition(transform.position, Vector3.op_Multiply(forward, this.c.nearClipPlane + 1f / 1000f));
    ((Component) this).transform.LookAt(Vector3.op_Addition(((Component) this).transform.position, Quaternion.op_Multiply(transform.rotation, Vector3.back)), Quaternion.op_Multiply(transform.rotation, Vector3.up));
    ((Component) this).transform.position = position;
    this.saveCameraRot = transform.rotation;
    this.saveCameraPos = transform.position;
    this.savePos = position;
  }

  protected override void Update_Battle()
  {
    if (Object.op_Equality((Object) this.battleManager, (Object) null) || Object.op_Equality((Object) this.battleManager.battleCamera, (Object) null))
      return;
    Transform transform = this.battleManager.battleCamera.transform;
    if (!Vector3.op_Inequality(this.savePos, ((Component) this).transform.position) && !Vector3.op_Inequality(this.saveCameraPos, transform.position) && !Quaternion.op_Inequality(this.saveCameraRot, transform.rotation))
      return;
    this.calc(this.battleManager.battleCamera);
  }
}
