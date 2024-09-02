// Decompiled with JetBrains decompiler
// Type: Battle01SkillSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01SkillSelect : BattleHorizontalSelect<BL.Skill>
{
  private Battle01SelectNode selectNode;

  protected override void initialize(BE e)
  {
    this.selectNode = NGUITools.FindInParents<Battle01SelectNode>(((Component) this).transform);
    this.modified = BL.Observe<BL.ClassValue<List<BL.Skill>>>(new BL.ClassValue<List<BL.Skill>>(e.core.getFieldSkills(e.core.unitCurrent.unit)));
  }

  protected override Future<GameObject> resPrefab()
  {
    return ResourceManager.Load<GameObject>("Prefabs/battle/Battle01 Skill Select");
  }

  protected override void setParts(GameObject o, BL.Skill parts)
  {
    o.GetComponent<Battle01Skill>().setSkill(parts, this.env.core.unitCurrent.unit);
  }

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    Battle01Skill inParents = NGUITools.FindInParents<Battle01Skill>(UICamera.selectedObject);
    if (!Object.op_Inequality((Object) inParents, (Object) null) || !Object.op_Inequality((Object) this.selectNode, (Object) null))
      return;
    this.selectNode.useSkillSubject(inParents.getUnit(), inParents.getSkill());
  }
}
