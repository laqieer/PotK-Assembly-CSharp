// Decompiled with JetBrains decompiler
// Type: Popup00534Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
