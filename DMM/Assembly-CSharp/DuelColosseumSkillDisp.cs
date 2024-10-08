﻿// Decompiled with JetBrains decompiler
// Type: DuelColosseumSkillDisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

public class DuelColosseumSkillDisp : MonoBehaviour
{
  [SerializeField]
  private UILabel skill_name;
  [SerializeField]
  private UI2DSprite icon;

  public Future<UnityEngine.Sprite> Init(BL.Skill skill)
  {
    this.skill_name.SetTextLocalize(skill.name);
    return skill.skill.LoadBattleSkillIcon().Then<UnityEngine.Sprite>((Func<UnityEngine.Sprite, UnityEngine.Sprite>) (f => this.icon.sprite2D = f));
  }
}
