﻿// Decompiled with JetBrains decompiler
// Type: Battle01CommandItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01CommandItem : BattleMonoBehaviour
{
  private Battle01SelectNode selectNode;

  private void Awake()
  {
    EventDelegate.Set(((Component) this).GetComponent<UIButton>().onClick, new EventDelegate((MonoBehaviour) this, "onClick"));
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandItem.\u003CStart_Battle\u003Ec__Iterator90E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    this.selectNode.useItem();
  }
}
