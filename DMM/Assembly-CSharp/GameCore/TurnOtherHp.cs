﻿// Decompiled with JetBrains decompiler
// Type: GameCore.TurnOtherHp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

namespace GameCore
{
  public class TurnOtherHp
  {
    public int hp;
    public List<BL.SkillEffect> consumeSkillEffect;

    public TurnOtherHp(int hp)
    {
      this.hp = hp;
      this.consumeSkillEffect = new List<BL.SkillEffect>();
    }
  }
}
