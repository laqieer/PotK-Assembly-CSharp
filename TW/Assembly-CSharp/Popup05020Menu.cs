// Decompiled with JetBrains decompiler
// Type: Popup05020Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class Popup05020Menu : BackButtonMenuBase
{
  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.StartCoroutine(this.ShowResetPopup());

  public void IbtnYes()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    if (Persist.earthBattleEnvironment.Data.core.battleInfo.quest_type == CommonQuestType.EarthExtra)
    {
      EarthExtraQuest quest = ((IEnumerable<EarthExtraQuest>) MasterData.EarthExtraQuestList).FirstOrDefault<EarthExtraQuest>((Func<EarthExtraQuest, bool>) (x => x.ID == Persist.earthBattleEnvironment.Data.core.battleInfo.quest_s_id));
      Singleton<EarthDataManager>.GetInstance().BattleInitExtra(quest);
    }
    else
      Singleton<EarthDataManager>.GetInstance().BattleInitStory();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  [DebuggerHidden]
  private IEnumerator ShowResetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup05020Menu.\u003CShowResetPopup\u003Ec__IteratorA4E popupCIteratorA4E = new Popup05020Menu.\u003CShowResetPopup\u003Ec__IteratorA4E();
    return (IEnumerator) popupCIteratorA4E;
  }
}
