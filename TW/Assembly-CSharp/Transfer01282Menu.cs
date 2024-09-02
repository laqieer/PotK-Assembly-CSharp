// Decompiled with JetBrains decompiler
// Type: Transfer01282Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Transfer01282Menu : NGMenuBase
{
  [SerializeField]
  private GameObject Migrate;
  [SerializeField]
  private GameObject FgGIDMigrate;

  public void IbtnMigtate()
  {
    this.Migrate.SetActive(true);
    this.Migrate.GetComponent<Startup00017Menu>().InitDataCode();
    ((Component) this).gameObject.SetActive(false);
  }

  public void IbtnFgGIDMigtate()
  {
    this.FgGIDMigrate.SetActive(true);
    this.FgGIDMigrate.GetComponent<Startup00018Menu>().InitDataCode();
    ((Component) this).gameObject.SetActive(false);
  }

  public virtual void IbtnPopupBack() => ((Component) this).gameObject.SetActive(false);
}
