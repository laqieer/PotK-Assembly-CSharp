// Decompiled with JetBrains decompiler
// Type: Quest002171QuestOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002171QuestOpenPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private UILabel Title;
  [SerializeField]
  private UIButton ibtnYes;
  [SerializeField]
  private UIButton ibtnNo;
  [SerializeField]
  private List<GameObject> Banners;
  private PlayerQuestGate passGate;
  private Quest002171Scroll scrollcomp;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollview;
  [SerializeField]
  private NGxScroll ngxScroll;
  [SerializeField]
  private UI2DSprite keySprite;
  [SerializeField]
  private UILabel txtPossession;

  [DebuggerHidden]
  public IEnumerator Init(PlayerQuestGate[] gates, Quest002171Scroll scrollcomp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CInit\u003Ec__Iterator21E()
    {
      scrollcomp = scrollcomp,
      gates = gates,
      \u003C\u0024\u003Escrollcomp = scrollcomp,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitOfEachCount(PlayerQuestGate[] gates)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CInitOfEachCount\u003Ec__Iterator21F()
    {
      gates = gates,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  private string GetReleaseTime(int totalSec)
  {
    string empty = string.Empty;
    TimeSpan timeSpan = new TimeSpan(0, 0, 0, totalSec);
    if (timeSpan.Days > 0)
      empty += Consts.Format(Consts.GetInstance().QUEST_002171_RELEASEPOPUP_DESCRIPTION_DAY, (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) timeSpan.Days
        }
      });
    if (timeSpan.Hours > 0)
      empty += Consts.Format(Consts.GetInstance().QUEST_002171_RELEASEPOPUP_DESCRIPTION_HOUR, (IDictionary) new Hashtable()
      {
        {
          (object) "hour",
          (object) timeSpan.Hours
        }
      });
    if (timeSpan.Minutes > 0)
      empty += Consts.Format(Consts.GetInstance().QUEST_002171_RELEASEPOPUP_DESCRIPTION_MIN, (IDictionary) new Hashtable()
      {
        {
          (object) "min",
          (object) timeSpan.Minutes
        }
      });
    return empty;
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.ibtnYes.isEnabled = false;
    this.ibtnNo.isEnabled = false;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartAPI_QuestRelease(this.passGate, this.scrollcomp);
  }

  private void StartAPI_QuestRelease(PlayerQuestGate gate, Quest002171Scroll scroll)
  {
    this.StartCoroutine(this.QuestRelease(gate, scroll));
  }

  [DebuggerHidden]
  private IEnumerator QuestRelease(PlayerQuestGate gate, Quest002171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CQuestRelease\u003Ec__Iterator220()
    {
      scroll = scroll,
      gate = gate,
      \u003C\u0024\u003Escroll = scroll,
      \u003C\u0024\u003Egate = gate
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator CreateKeySprite(int keyID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateKeySprite\u003Ec__Iterator221()
    {
      keyID = keyID,
      \u003C\u0024\u003EkeyID = keyID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateBanner(int num)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateBanner\u003Ec__Iterator222()
    {
      num = num,
      \u003C\u0024\u003Enum = num,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateBannerSprite(PlayerQuestGate[] gates, bool isScroll, bool isAtlas)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateBannerSprite\u003Ec__Iterator223()
    {
      gates = gates,
      isScroll = isScroll,
      isAtlas = isAtlas,
      \u003C\u0024\u003Egates = gates,
      \u003C\u0024\u003EisScroll = isScroll,
      \u003C\u0024\u003EisAtlas = isAtlas,
      \u003C\u003Ef__this = this
    };
  }
}
