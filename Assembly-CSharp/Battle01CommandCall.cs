﻿// Decompiled with JetBrains decompiler
// Type: Battle01CommandCall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Battle01CommandCall : BattleMonoBehaviour
{
  private Battle01SelectNode selectNode;

  private void Awake() => EventDelegate.Set(this.GetComponent<UIButton>().onClick, new EventDelegate((MonoBehaviour) this, "onClick"));

  protected override IEnumerator Start_Battle()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Battle01CommandCall battle01CommandCall = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    battle01CommandCall.selectNode = NGUITools.FindInParents<Battle01SelectNode>(battle01CommandCall.transform);
    return false;
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    this.selectNode.useCallSkill();
  }
}
