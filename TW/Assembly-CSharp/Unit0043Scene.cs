﻿// Decompiled with JetBrains decompiler
// Type: Unit0043Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0043Scene : NGSceneBase
{
  [SerializeField]
  private Unit0043Menu menu;

  public static void changeScene(bool stack, UnitUnit unit, bool isSame = false)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_3", (stack ? 1 : 0) != 0, (object) unit, (object) isSame);
  }

  public static void changeScene(bool stack, PlayerUnit unit, bool isSame = false)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_3", (stack ? 1 : 0) != 0, (object) unit, (object) isSame);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0043Scene.\u003ConInitSceneAsync\u003Ec__Iterator301()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(UnitUnit unit, bool isSame)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0043Scene.\u003ConStartSceneAsync\u003Ec__Iterator302()
    {
      unit = unit,
      isSame = isSame,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisSame = isSame,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit unit, bool isSame)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0043Scene.\u003ConStartSceneAsync\u003Ec__Iterator303()
    {
      unit = unit,
      isSame = isSame,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisSame = isSame,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(UnitUnit unit, bool isSame)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!instance.ExistsCueID(unit.unitVoicePattern.file_name, 92))
      return;
    instance.playVoiceByID(unit.unitVoicePattern.file_name, 92);
  }

  public void onStartScene(PlayerUnit unit, bool isSame)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!instance.ExistsCueID(unit.unit.unitVoicePattern.file_name, 92))
      return;
    instance.playVoiceByID(unit.unit.unitVoicePattern.file_name, 92);
  }

  public override void onEndScene() => this.menu.onEndScene();
}
