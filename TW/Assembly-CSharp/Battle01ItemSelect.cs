// Decompiled with JetBrains decompiler
// Type: Battle01ItemSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01ItemSelect : BattleHorizontalSelect<BL.Item>
{
  private Battle01SelectNode selectNode;

  protected override void initialize(BE e)
  {
    this.selectNode = NGUITools.FindInParents<Battle01SelectNode>(((Component) this).transform);
    this.modified = BL.Observe<BL.ClassValue<List<BL.Item>>>(e.core.itemListInBattle);
  }

  protected override Future<GameObject> resPrefab()
  {
    return Res.Prefabs.battle.Battle01_Item_Select.Load<GameObject>();
  }

  protected override void setParts(GameObject o, BL.Item parts)
  {
    o.GetComponent<Battle01Item>().setItem(parts);
  }

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    Battle01Item inParents = NGUITools.FindInParents<Battle01Item>(UICamera.selectedObject);
    if (!Object.op_Inequality((Object) inParents, (Object) null) || !Object.op_Inequality((Object) this.selectNode, (Object) null))
      return;
    this.selectNode.useItemSubject(inParents.getItem());
  }
}
