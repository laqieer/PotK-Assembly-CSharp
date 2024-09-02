// Decompiled with JetBrains decompiler
// Type: Popup00534Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
