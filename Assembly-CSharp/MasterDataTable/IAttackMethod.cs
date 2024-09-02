// Decompiled with JetBrains decompiler
// Type: MasterDataTable.IAttackMethod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  public abstract class IAttackMethod
  {
    private GearAttackClassification? attackClass_;

    public abstract object original { get; }

    public abstract GearKind kind { get; protected set; }

    public abstract BattleskillSkill skill { get; protected set; }

    public abstract string motionKey { get; }

    public GearAttackClassification attackClass => !this.attackClass_.HasValue ? (this.attackClass_ = new GearAttackClassification?(this.getAttackClass())).Value : this.attackClass_.Value;

    private GearAttackClassification getAttackClass()
    {
      GearAttackClassification attackClassification = GearAttackClassification.none;
      if (this.skill != null)
      {
        if (this.skill.skill_type == BattleskillSkillType.magic)
        {
          attackClassification = GearAttackClassification.magic;
        }
        else
        {
          BattleskillEffect battleskillEffect = Array.Find<BattleskillEffect>(this.skill.Effects, (Predicate<BattleskillEffect>) (x => x.EffectLogic.Enum == BattleskillEffectLogicEnum.attack_classification));
          if (battleskillEffect != null)
            attackClassification = (GearAttackClassification) battleskillEffect.GetInt(BattleskillEffectLogicArgumentEnum.attack_classification_id);
        }
      }
      return attackClassification;
    }

    public CommonElement element
    {
      get
      {
        BattleskillSkill skill = this.skill;
        return skill == null ? CommonElement.none : skill.element;
      }
    }
  }
}
