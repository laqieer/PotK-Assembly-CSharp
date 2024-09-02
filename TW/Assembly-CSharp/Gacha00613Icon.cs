﻿// Decompiled with JetBrains decompiler
// Type: Gacha00613Icon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

#nullable disable
public class Gacha00613Icon : MonoBehaviour
{
  public Gacha00613Scene Scene;
  public int Number;
  public bool is_new;

  public void IbtnIcon()
  {
    if (!this.Scene.Menu.IsBtnAction)
      return;
    GachaResultData instance = GachaResultData.GetInstance();
    this.is_new = instance.GetData().GetResultData()[this.Number].is_new;
    CommonRewardType commonRewardType = new CommonRewardType(instance.GetData().GetResultData()[this.Number].reward_type_id, instance.GetData().GetResultData()[this.Number].reward_result_id, instance.GetData().GetResultData()[this.Number].reward_result_quantity, instance.GetData().GetResultData()[this.Number].is_new);
    commonRewardType.ThenUnit((Action<PlayerUnit>) (unit => this.ChangeSceneUnit(unit)));
    commonRewardType.ThenMaterialUnit((Action<PlayerMaterialUnit>) (unit => this.ChangeSceneMaterialUnit(unit)));
    commonRewardType.ThenGear((Action<PlayerItem>) (gear => this.ChangeSceneGear(gear)));
    commonRewardType.ThenMaterialGear((Action<PlayerMaterialGear>) (materialGear => this.ChangeSceneGear(materialGear)));
  }

  public void ChangeSceneUnit(PlayerUnit PU)
  {
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    if (PU.unit.IsMaterialUnit)
      Unit00493Scene.changeScene(true, PU.unit, this.is_new, true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_8", true, (object) PU, (object) this.is_new);
  }

  public void ChangeSceneMaterialUnit(PlayerMaterialUnit PU)
  {
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    if (PU.unit.IsMaterialUnit)
      Unit00493Scene.changeScene(true, PU.unit, this.is_new, true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_8", true, (object) PU, (object) this.is_new);
  }

  public void ChangeSceneGear(PlayerItem PI)
  {
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    if (!PI.gear.kind.isEquip)
      Bugu00561Scene.changeScene(true, new GameCore.ItemInfo(PI), this.is_new, true, true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", true, (object) this.is_new, (object) new GameCore.ItemInfo(PI));
  }

  public void ChangeSceneGear(PlayerMaterialGear PI)
  {
    Singleton<PopupManager>.GetInstance().open((GameObject) null);
    if (!PI.gear.kind.isEquip)
      Bugu00561Scene.changeScene(true, new GameCore.ItemInfo(PI), this.is_new, true, true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", true, (object) this.is_new, (object) new GameCore.ItemInfo(PI));
  }
}
