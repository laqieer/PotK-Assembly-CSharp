// Decompiled with JetBrains decompiler
// Type: Transfer01281Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Transfer01281Menu : NGMenuBase
{
  [SerializeField]
  private GameObject MigrateSelect;
  [SerializeField]
  private GameObject FgGIDMigrate;

  public virtual void IbtnPopupNext()
  {
    this.MigrateSelect.SetActive(true);
    ((Component) this).gameObject.SetActive(false);
  }

  public virtual void IbtnPopupBack() => ((Component) this).gameObject.SetActive(false);
}
