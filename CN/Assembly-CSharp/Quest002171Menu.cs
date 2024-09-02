// Decompiled with JetBrains decompiler
// Type: Quest002171Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest002171Menu.\u003CInit\u003Ec__Iterator1EE()
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
    return (IEnumerator) new Quest002171Menu.\u003CUpdateTime\u003Ec__Iterator1EF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(PlayerQuestGate[] gates, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CScrollInit\u003Ec__Iterator1F0()
    {
      prefab = prefab,
      gates = gates,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent() => Debug.Log((object) "click default event IbtnEvent");

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  private string GetTitle() => Consts.GetInstance().QUEST_00217_KEY_TITLE;

  public void StartAPI_QuestRelease(PlayerQuestGate gate, Quest002171Scroll scroll)
  {
    this.StartCoroutine(this.QuestRelease(gate, scroll));
  }

  [DebuggerHidden]
  private IEnumerator QuestRelease(PlayerQuestGate gate, Quest002171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Menu.\u003CQuestRelease\u003Ec__Iterator1F1()
    {
      scroll = scroll,
      gate = gate,
      \u003C\u0024\u003Escroll = scroll,
      \u003C\u0024\u003Egate = gate
    };
  }
}
