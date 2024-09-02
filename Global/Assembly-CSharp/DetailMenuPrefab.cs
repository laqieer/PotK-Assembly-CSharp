// Decompiled with JetBrains decompiler
// Type: DetailMenuPrefab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenuPrefab : MonoBehaviour
{
  public DetailMenu normal;
  public MaterialDetailMenu material;
  protected int index;
  private PlayerUnit _playerUnit;

  public int Index => this.index;

  public PlayerUnit PlayerUnit => this._playerUnit;

  [DebuggerHidden]
  public IEnumerator Init(
    Unit0042Menu menu,
    int index,
    PlayerUnit playerUnit,
    int infoIndex,
    bool isLimit,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenuPrefab.\u003CInit\u003Ec__Iterator8B4()
    {
      index = index,
      playerUnit = playerUnit,
      menu = menu,
      infoIndex = infoIndex,
      isLimit = isLimit,
      isUpdate = isUpdate,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EinfoIndex = infoIndex,
      \u003C\u0024\u003EisLimit = isLimit,
      \u003C\u0024\u003EisUpdate = isUpdate,
      \u003C\u003Ef__this = this
    };
  }

  public void SetInformationPanelIndex(int index)
  {
    if (!(this.PlayerUnit != (PlayerUnit) null))
      return;
    if (this.PlayerUnit.unit.IsNormalUnit)
      this.StartCoroutine(this.normal.SetInformationPanelIndex(index));
    else
      this.StartCoroutine(this.material.SetInformationPanelIndex(index));
  }

  public void SetInformationPaneEnable(bool enable)
  {
    if (!(this.PlayerUnit != (PlayerUnit) null) || !this.PlayerUnit.unit.IsNormalUnit)
      return;
    ((Behaviour) this.normal.InformationScrollView.uiScrollView).enabled = enable;
  }
}
