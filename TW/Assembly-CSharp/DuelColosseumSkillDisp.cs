// Decompiled with JetBrains decompiler
// Type: DuelColosseumSkillDisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public class DuelColosseumSkillDisp : MonoBehaviour
{
  [SerializeField]
  private UILabel skill_name;
  [SerializeField]
  private UI2DSprite icon;

  public Future<Sprite> Init(BL.Skill skill)
  {
    this.skill_name.SetTextLocalize(skill.name);
    return skill.skill.LoadBattleSkillIcon().Then<Sprite>((Func<Sprite, Sprite>) (f =>
    {
      Sprite sprite = f;
      this.icon.sprite2D = sprite;
      return sprite;
    }));
  }
}
