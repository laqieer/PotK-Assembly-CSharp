﻿// Decompiled with JetBrains decompiler
// Type: BattleUI04Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI04Scene.\u003ConStartSceneAsync\u003Ec__Iterator895()
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
