﻿// Decompiled with JetBrains decompiler
// Type: Battle01TipEventTowerMedal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle01TipEventTowerMedal : Battle01TipEventBase
{
  public override IEnumerator onInitAsync()
  {
    Battle01TipEventTowerMedal tipEventTowerMedal = this;
    Future<GameObject> f = Res.Icons.UniqueIconPrefab.Load<GameObject>();
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UniqueIcons icon = tipEventTowerMedal.cloneIcon<UniqueIcons>(f.Result);
    e = icon.SetTowerMedal();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    icon.BackGroundActivated = false;
    icon.LabelActivated = false;
    tipEventTowerMedal.selectIcon(0);
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    if (e.reward.Type != MasterDataTable.CommonRewardType.tower_medal)
      return;
    Dictionary<string, int> dictionary = new Dictionary<string, int>()
    {
      {
        "medal",
        e.reward.Quantity
      }
    };
    this.setText(Consts.Format(Consts.GetInstance().TipEvent_text_tower_medal, (IDictionary) dictionary));
  }
}
