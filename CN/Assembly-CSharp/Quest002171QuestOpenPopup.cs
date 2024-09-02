// Decompiled with JetBrains decompiler
// Type: Quest002171QuestOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private Quest002171Menu menu;
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
  public IEnumerator Init(
    PlayerQuestGate[] gates,
    Quest002171Menu menu,
    Quest002171Scroll scrollcomp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CInit\u003Ec__Iterator1F6()
    {
      menu = menu,
      scrollcomp = scrollcomp,
      gates = gates,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Escrollcomp = scrollcomp,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitOfEachCount(PlayerQuestGate[] gates)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CInitOfEachCount\u003Ec__Iterator1F7()
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
    this.menu.StartAPI_QuestRelease(this.passGate, this.scrollcomp);
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
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateKeySprite\u003Ec__Iterator1F8()
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
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateBanner\u003Ec__Iterator1F9()
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
    return (IEnumerator) new Quest002171QuestOpenPopup.\u003CCreateBannerSprite\u003Ec__Iterator1FA()
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
