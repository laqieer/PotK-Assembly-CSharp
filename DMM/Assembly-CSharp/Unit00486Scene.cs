﻿// Decompiled with JetBrains decompiler
// Type: Unit00486Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;

public class Unit00486Scene : NGSceneBase
{
  public Unit00486Menu menu;
  protected bool isInit;
  public bool NotOnStartSceneAsync;

  public override IEnumerator onInitSceneAsync()
  {
    this.isInit = true;
    yield break;
  }

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialUnits,
    float currentMaxTrust,
    System.Action exceptionBackScene = null)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_6", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialUnits, (object) currentMaxTrust, (object) exceptionBackScene);
  }

  public IEnumerator onStartSceneAsync()
  {
    IEnumerator e = this.onStartSceneAsync(SMManager.Get<PlayerUnit[]>()[0], new PlayerUnit[5], 0.0f, (System.Action) null);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public virtual IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialUnits,
    float currentMaxTrust,
    System.Action exceptionBackScene)
  {
    if (this.NotOnStartSceneAsync)
    {
      this.NotOnStartSceneAsync = false;
    }
    else
    {
      PlayerUnit[] playerUnits = SMManager.Get<PlayerUnit[]>();
      PlayerMaterialUnit[] playerMaterialUnits = SMManager.Get<PlayerMaterialUnit[]>();
      this.menu.SetIconType(UnitMenuBase.IconType.Detail);
      this.menu.exceptionBackScene = exceptionBackScene;
      this.menu.isMaterial = true;
      if (this.isInit)
      {
        Player player = SMManager.Get<Player>();
        PlayerDeck[] playerDeck = SMManager.Get<PlayerDeck[]>();
        yield return (object) this.menu.Init(player, basePlayerUnit, playerUnits, playerMaterialUnits, materialUnits, playerDeck, false, 30, currentMaxTrust);
        this.isInit = false;
      }
      else
      {
        yield return (object) this.menu.UpdateInfoAndScrollExtend(((IEnumerable<PlayerUnit>) playerUnits).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != basePlayerUnit && this.menu.isComposeUnit(basePlayerUnit, x))).ToArray<PlayerUnit>(), ((IEnumerable<PlayerMaterialUnit>) playerMaterialUnits).Where<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (x => this.menu.isComposeUnit(basePlayerUnit, x))).ToArray<PlayerMaterialUnit>(), this.menu.SelectedUnitIcons.Select<UnitIconInfo, PlayerUnit>((Func<UnitIconInfo, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>());
        this.menu.UpdateInfomation();
      }
    }
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    UnitDetailIcon.ClearCache();
    this.GetComponentInChildren<NGxScroll2>().scrollView.Press(false);
  }
}
