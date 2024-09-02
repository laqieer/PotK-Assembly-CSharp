// Decompiled with JetBrains decompiler
// Type: Unit0549Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Unit0549Scene : NGSceneBase
{
  [SerializeField]
  private Unit0549Menu menu;

  public static void ChangeScene(bool stack) => Singleton<NGSceneManager>.GetInstance().changeScene("unit054_9", stack);

  public override IEnumerator onInitSceneAsync()
  {
    yield break;
  }

  public IEnumerator onStartSceneAsync()
  {
    IEnumerator e = this.menu.Init(((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => !x.unit.IsMaterialUnit)).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => (uint) x.unit.EvolutionPattern.Length > 0U)).ToArray<PlayerUnit>());
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onStartScene()
  {
  }
}
