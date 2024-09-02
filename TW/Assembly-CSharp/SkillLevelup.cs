// Decompiled with JetBrains decompiler
// Type: SkillLevelup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SkillLevelup : MonoBehaviour
{
  private const int SKILL_KIND = 4;
  private Unit004813Menu menu;
  [SerializeField]
  private GameObject[] skillSlots;
  [SerializeField]
  private UI2DSprite[] skillSlotSprites;
  [SerializeField]
  private UILabel[] txtSkillName;
  [SerializeField]
  private UILabel[] txtLvbefore;
  [SerializeField]
  private UILabel[] txtLvafter;

  public void SetSkillSlots(
    Unit004813Menu m,
    PlayerUnit beforeUnit,
    PlayerUnit afterUnit,
    Dictionary<int, Sprite> dicSkillIcons,
    List<LevelupSkill> levelupSkills)
  {
    this.menu = m;
    Array.ForEach<GameObject>(this.skillSlots, (Action<GameObject>) (gameObject => gameObject.SetActive(false)));
    if (levelupSkills.Count <= 0)
      return;
    int count = 0;
    levelupSkills.ForEach((Action<LevelupSkill>) (lus =>
    {
      if (lus.afterLevel <= lus.beforeLevel || count >= 4)
        return;
      this.skillSlots[count].SetActive(true);
      this.txtSkillName[count].SetTextLocalize(lus.skill.name);
      this.txtLvbefore[count].SetTextLocalize(lus.beforeLevel);
      this.txtLvafter[count].SetTextLocalize(lus.afterLevel);
      this.skillSlotSprites[count].sprite2D = dicSkillIcons[lus.skill.ID];
      ++count;
    }));
  }

  public void StartTween()
  {
    foreach (TweenAlpha componentsInChild in ((Component) this).GetComponentsInChildren<TweenAlpha>())
    {
      if (componentsInChild.tweenGroup == 0)
      {
        componentsInChild.ResetToBeginning();
        componentsInChild.PlayForward();
      }
    }
  }

  public void EndTween()
  {
    foreach (TweenAlpha componentsInChild in ((Component) this).GetComponentsInChildren<TweenAlpha>())
    {
      if (componentsInChild.tweenGroup == 1)
      {
        componentsInChild.ResetToBeginning();
        componentsInChild.PlayForward();
      }
    }
  }

  public void TweenFinish() => this.menu.StartNextTween();
}
