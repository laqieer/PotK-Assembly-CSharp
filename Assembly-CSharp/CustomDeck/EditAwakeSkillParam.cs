// Decompiled with JetBrains decompiler
// Type: CustomDeck.EditAwakeSkillParam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;

namespace CustomDeck
{
  public class EditAwakeSkillParam : EditBaseParam
  {
    public PlayerAwakeSkill[] skills { get; private set; }

    public Action<int, int> onSetSkill { get; private set; }

    public EditAwakeSkillParam(
      PlayerCustomDeck d,
      PlayerUnit target,
      Dictionary<int, PlayerUnit> dic,
      int paramIndex,
      PlayerAwakeSkill[] awakeSkills,
      Action<int, int> eventSetSkill)
    {
      this.deck = d;
      this.baseUnit = target;
      this.dicReference = dic;
      this.index = paramIndex;
      this.skills = awakeSkills;
      this.onSetSkill = eventSetSkill;
    }
  }
}
