// Decompiled with JetBrains decompiler
// Type: Quest002171Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002171Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  public UIScrollView scrollview;
  public UIGrid grid;
  private DateTime serverTime;

  [DebuggerHidden]
  public IEnumerator Init(PlayerQuestGate[] gates)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CInit\u003Ec__Iterator1B0()
    {
      gates = gates,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CUpdateTime\u003Ec__Iterator1B1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(PlayerQuestGate[] gates, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CScrollInit\u003Ec__Iterator1B2()
    {
      prefab = prefab,
      gates = gates,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent()
  {
  }

  public virtual void VScrollBar()
  {
  }

  private string GetTitle() => Consts.Lookup("QUEST_00217_KEY_TITLE");

  public void StartAPI_QuestRelease(PlayerQuestGate gate)
  {
    this.StartCoroutine(this.QuestRelease(gate));
  }

  [DebuggerHidden]
  private IEnumerator QuestRelease(PlayerQuestGate gate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CQuestRelease\u003Ec__Iterator1B3()
    {
      gate = gate,
      \u003C\u0024\u003Egate = gate
    };
  }

  [DebuggerHidden]
  private IEnumerator CantQuestReleasePopup(QuestKeyGate gate)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest002171Menu.\u003CCantQuestReleasePopup\u003Ec__Iterator1B4 popupCIterator1B4 = new Quest002171Menu.\u003CCantQuestReleasePopup\u003Ec__Iterator1B4();
    return (IEnumerator) popupCIterator1B4;
  }
}
