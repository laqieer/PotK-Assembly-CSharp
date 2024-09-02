// Decompiled with JetBrains decompiler
// Type: Battle01ItemSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class Battle01ItemSelect : BattleHorizontalSelect<BL.Item>
{
  private Battle01SelectNode selectNode;

  protected override void initialize(BE e)
  {
    this.selectNode = NGUITools.FindInParents<Battle01SelectNode>(this.transform);
    this.modified = BL.Observe<BL.ClassValue<List<BL.Item>>>(e.core.itemListInBattle);
  }

  protected override Future<GameObject> resPrefab() => this.battleManager.isSea ? Res.Prefabs.battle.Battle01_Item_Select_sea.Load<GameObject>() : Res.Prefabs.battle.Battle01_Item_Select.Load<GameObject>();

  protected override void setParts(GameObject o, BL.Item parts) => o.GetComponent<Battle01Item>().setItem(parts);

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    Battle01Item inParents = NGUITools.FindInParents<Battle01Item>(UICamera.selectedObject);
    if (!((Object) inParents != (Object) null) || !((Object) this.selectNode != (Object) null))
      return;
    this.selectNode.useItemSubject(inParents.getItem());
  }
}
