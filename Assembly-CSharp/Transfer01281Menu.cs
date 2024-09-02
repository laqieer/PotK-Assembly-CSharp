// Decompiled with JetBrains decompiler
// Type: Transfer01281Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Transfer01281Menu : NGMenuBase
{
  [SerializeField]
  private GameObject MigrateSelect;
  [SerializeField]
  private GameObject FgGIDMigrate;

  public virtual void IbtnPopupNext()
  {
    this.MigrateSelect.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public virtual void IbtnPopupBack() => this.gameObject.SetActive(false);
}
