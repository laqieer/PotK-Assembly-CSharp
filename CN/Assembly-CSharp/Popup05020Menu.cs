// Decompiled with JetBrains decompiler
// Type: Popup05020Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Popup05020Menu.\u003CShowResetPopup\u003Ec__Iterator979 popupCIterator979 = new Popup05020Menu.\u003CShowResetPopup\u003Ec__Iterator979();
    return (IEnumerator) popupCIterator979;
  }
}
