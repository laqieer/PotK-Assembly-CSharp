// Decompiled with JetBrains decompiler
// Type: UIDragCamera
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Drag Camera")]
[ExecuteInEditMode]
public class UIDragCamera : MonoBehaviour
{
  public UIDraggableCamera draggableCamera;

  private void Awake()
  {
    if (!Object.op_Equality((Object) this.draggableCamera, (Object) null))
      return;
    this.draggableCamera = NGUITools.FindInParents<UIDraggableCamera>(((Component) this).gameObject);
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || !Object.op_Inequality((Object) this.draggableCamera, (Object) null))
      return;
    this.draggableCamera.Press(isPressed);
  }

  private void OnDrag(Vector2 delta)
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || !Object.op_Inequality((Object) this.draggableCamera, (Object) null))
      return;
    this.draggableCamera.Drag(delta);
  }

  private void OnScroll(float delta)
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || !Object.op_Inequality((Object) this.draggableCamera, (Object) null))
      return;
    this.draggableCamera.Scroll(delta);
  }
}
