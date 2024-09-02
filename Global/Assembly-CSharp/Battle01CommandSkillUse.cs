// Decompiled with JetBrains decompiler
// Type: Battle01CommandSkillUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01CommandSkillUse : BattleMonoBehaviour
{
  private UIButton button;
  private BL.Unit unit;
  private BL.Skill skill;
  private List<BL.Unit> targets;

  private void Awake()
  {
    this.button = ((Component) this).GetComponent<UIButton>();
    EventDelegate.Set(this.button.onClick, new EventDelegate((MonoBehaviour) this, "onClick"));
  }

  public void setData(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    this.unit = unit;
    this.skill = skill;
    this.targets = targets;
  }

  public void setEnable(bool enable) => this.button.isEnabled = enable;

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    if (this.battleManager.useGameEngine)
      this.battleManager.gameEngine.moveUnitWithSkill(this.unit, this.skill, this.targets);
    else
      this.env.useSkill(this.unit, this.skill, this.targets, this.battleManager.getManager<BattleTimeManager>());
    this.battleManager.getController<BattleInputObserver>().cancelTargetSelect();
    NGUITools.FindInParents<Battle01SelectNode>(((Component) this).transform).backToTop();
  }
}
