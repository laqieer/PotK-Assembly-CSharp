// Decompiled with JetBrains decompiler
// Type: Popup00534Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Popup00534Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  public GameObject CompositeDescription;
  [SerializeField]
  public GameObject RepairDescription;

  public void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnOk();
}
