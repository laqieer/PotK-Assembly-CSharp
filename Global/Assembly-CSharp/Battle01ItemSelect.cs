// Decompiled with JetBrains decompiler
// Type: Battle01ItemSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return ResourceManager.Load<GameObject>("Prefabs/battle/Battle01 Item Select");
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
