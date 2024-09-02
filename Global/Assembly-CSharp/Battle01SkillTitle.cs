// Decompiled with JetBrains decompiler
// Type: Battle01SkillTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Battle01SkillTitle : NGBattleMenuBase
{
  [SerializeField]
  private GameObject title_skill;
  [SerializeField]
  private GameObject title_secrets;

  public void setSkill(BL.Skill skill)
  {
    if (skill.isOugi)
    {
      this.title_skill.SetActive(false);
      this.title_secrets.SetActive(true);
    }
    else
    {
      this.title_skill.SetActive(true);
      this.title_secrets.SetActive(false);
    }
  }
}
