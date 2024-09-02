// Decompiled with JetBrains decompiler
// Type: Shop00723UnitSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00723UnitSelect : MonoBehaviour
{
  [SerializeField]
  private UILabel txtName_;
  [SerializeField]
  private GameObject topIcon_;
  [SerializeField]
  private UIButton btnSkill_;
  [SerializeField]
  private UIButton btnSelect_;
  private Shop00723Menu menu_;
  private UnitTicketUnitSample sample_;

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop00723Menu menu, UnitTicketUnitSample unitSample)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723UnitSelect.\u003CcoInitialize\u003Ec__Iterator4C9()
    {
      menu = menu,
      unitSample = unitSample,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EunitSample = unitSample,
      \u003C\u003Ef__this = this
    };
  }

  public bool btnSelectEnabled
  {
    get => this.btnSelect_.isEnabled;
    set => this.btnSelect_.isEnabled = value;
  }

  public void onClickSkill() => this.menu_.onClickSkill(this.sample_);

  public void onClickSelect() => this.menu_.onClickSelect(this.sample_);
}
