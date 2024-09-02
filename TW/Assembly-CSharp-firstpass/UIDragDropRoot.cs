// Decompiled with JetBrains decompiler
// Type: UIDragDropRoot
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Drag and Drop Root")]
public class UIDragDropRoot : MonoBehaviour
{
  public static Transform root;

  private void OnEnable() => UIDragDropRoot.root = ((Component) this).transform;

  private void OnDisable()
  {
    if (!Object.op_Equality((Object) UIDragDropRoot.root, (Object) ((Component) this).transform))
      return;
    UIDragDropRoot.root = (Transform) null;
  }
}
