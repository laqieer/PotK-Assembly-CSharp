// Decompiled with JetBrains decompiler
// Type: DuelColosseumSkillDisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
