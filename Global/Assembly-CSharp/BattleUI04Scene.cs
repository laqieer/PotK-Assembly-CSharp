﻿// Decompiled with JetBrains decompiler
// Type: BattleUI04Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI04Scene : BattleSceneBase
{
  [SerializeField]
  private BattleUI04Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(BL.UnitPosition attack, BL.UnitPosition defense)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI04Scene.\u003ConStartSceneAsync\u003Ec__Iterator74B()
    {
      attack = attack,
      defense = defense,
      \u003C\u0024\u003Eattack = attack,
      \u003C\u0024\u003Edefense = defense,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    this.menu.onEndScene();
    Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = true;
  }
}
