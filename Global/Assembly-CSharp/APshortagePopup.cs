// Decompiled with JetBrains decompiler
// Type: APshortagePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class APshortagePopup : MonoBehaviour
{
  public void btnOK() => Singleton<PopupManager>.GetInstance().onDismiss();
}
