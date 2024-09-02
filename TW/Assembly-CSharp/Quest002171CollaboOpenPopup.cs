// Decompiled with JetBrains decompiler
// Type: Quest002171CollaboOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002171CollaboOpenPopup : Quest002171QuestOpenPopup
{
  [SerializeField]
  private UILabel m_TextCondition;

  [DebuggerHidden]
  public new IEnumerator Init(PlayerQuestGate[] gates, Quest002171Scroll scrollcomp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171CollaboOpenPopup.\u003CInit\u003Ec__Iterator224()
    {
      gates = gates,
      scrollcomp = scrollcomp,
      \u003C\u0024\u003Egates = gates,
      \u003C\u0024\u003Escrollcomp = scrollcomp,
      \u003C\u003Ef__this = this
    };
  }
}
