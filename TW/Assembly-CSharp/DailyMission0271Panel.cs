// Decompiled with JetBrains decompiler
// Type: DailyMission0271Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Panel : MonoBehaviour
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
  private BingoRewardGroup reward;

  [DebuggerHidden]
  public IEnumerator Init(
    DailyMission0271PanelRoot.DailyMissionView viewModel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Panel.\u003CInit\u003Ec__Iterator6C6()
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
    return (IEnumerator) new DailyMission0271Panel.\u003CgetIconImageAsync\u003Ec__Iterator6C7()
    {
      \u003C\u003Ef__this = this
    };
  }
}
