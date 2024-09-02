// Decompiled with JetBrains decompiler
// Type: DailyMission02712Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission02712Panel : MonoBehaviour
{
  [SerializeField]
  public UI2DSprite IconObject;
  [SerializeField]
  public UILabel txtLabel;
  [SerializeField]
  public UILabel txtMissionProgress;
  [SerializeField]
  public GameObject dirClear;
  [SerializeField]
  public GameObject dirPanel;
  [SerializeField]
  public UIButton popupButton;
  [SerializeField]
  public UIButton clearButton;
  private Bingo2RewardEntity reward;

  [DebuggerHidden]
  public IEnumerator Init(DailyMission02712Menu.DailyMissionView viewModel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Panel.\u003CInit\u003Ec__Iterator5D7()
    {
      viewModel = viewModel,
      \u003C\u0024\u003EviewModel = viewModel,
      \u003C\u003Ef__this = this
    };
  }

  public void changeClearState()
  {
    this.txtMissionProgress.text = string.Empty;
    this.dirClear.SetActive(true);
    this.dirPanel.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator getIconImageAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Panel.\u003CgetIconImageAsync\u003Ec__Iterator5D8()
    {
      \u003C\u003Ef__this = this
    };
  }
}
