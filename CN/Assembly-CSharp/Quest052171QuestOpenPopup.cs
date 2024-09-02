// Decompiled with JetBrains decompiler
// Type: Quest052171QuestOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest052171QuestOpenPopup : BackButtonMenuBase
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
  [SerializeField]
  private UI2DSprite keySprite;
  [SerializeField]
  private UILabel txtPossession;
  private UIGrid grid;
  private NGxScroll ngxScroll;
  private Quest052171Menu menu;
  private Quest052171Scroll scrollcomp;
  private EarthExtraQuest quest;
  private EarthQuestKey questKey;

  [DebuggerHidden]
  public IEnumerator Init(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    Quest052171Menu menu,
    Quest052171Scroll scrollcomp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171QuestOpenPopup.\u003CInit\u003Ec__Iterator73F()
    {
      menu = menu,
      scrollcomp = scrollcomp,
      quest = quest,
      questKey = questKey,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Escrollcomp = scrollcomp,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003EquestKey = questKey,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.ibtnYes.isEnabled = false;
    this.ibtnNo.isEnabled = false;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.menu.StartAPI_QuestRelease(this.quest, this.questKey, this.scrollcomp.CanPlay);
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
    return (IEnumerator) new Quest052171QuestOpenPopup.\u003CCreateKeySprite\u003Ec__Iterator740()
    {
      keyID = keyID,
      \u003C\u0024\u003EkeyID = keyID,
      \u003C\u003Ef__this = this
    };
  }
}
