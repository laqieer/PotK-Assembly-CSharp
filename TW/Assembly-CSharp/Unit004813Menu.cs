// Decompiled with JetBrains decompiler
// Type: Unit004813Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004813Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UIButton BackBtn;
  [SerializeField]
  protected UIButton NextSkillBtn;
  [SerializeField]
  private UILabel characterName;
  [SerializeField]
  private GameObject[] SlcLBiconNone;
  [SerializeField]
  private GameObject[] SlcLBiconBlue;
  [SerializeField]
  private GameObject[] SlcLBiconBlueEff;
  [SerializeField]
  private GameObject slc_Limitbreak;
  [SerializeField]
  private GameObject DirSkillLevelup;
  [SerializeField]
  private GameObject DirLvmax;
  [SerializeField]
  private UILabel beforeLvmax;
  [SerializeField]
  private UILabel afterLvmax;
  [SerializeField]
  private GameObject slcArrow;
  [SerializeField]
  private UILabel lvmaxUnchanged;
  [SerializeField]
  private GameObject unitTexture;
  [SerializeField]
  private GameObject growthParameter;
  private int displaySkillIndex;
  private GameObject SkillLevelupPrefab;
  private GameObject[] SkillLevelupObject = new GameObject[2];
  private GrowthParameter parameterPanel;
  private Dictionary<int, Sprite> dicSkillIcons = new Dictionary<int, Sprite>();
  private PlayerUnit BaseUnit;
  private int medal;
  private NGSoundManager sm;
  public Dictionary<string, object> showPopupData;
  private bool isDispNextSkill;
  private bool isPlayPopup;

  public Unit00468Scene.Mode mode { get; set; }

  private void OnDisable()
  {
    if (!Object.op_Inequality((Object) this.sm, (Object) null))
      return;
    this.sm.stopVoice();
  }

  private List<LevelupSkill> CreateLevelupSkillList(PlayerUnit beforeUnit, PlayerUnit afterUnit)
  {
    List<LevelupSkill> levelupSkills = new List<LevelupSkill>();
    ((IEnumerable<PlayerUnitSkills>) afterUnit.skills).ForEach<PlayerUnitSkills>((Action<PlayerUnitSkills>) (afterSkill =>
    {
      bool flg_exist = false;
      ((IEnumerable<PlayerUnitSkills>) beforeUnit.skills).ForEach<PlayerUnitSkills>((Action<PlayerUnitSkills>) (beforeSkill =>
      {
        if (flg_exist)
          return;
        if (afterSkill.skill_id == beforeSkill.skill_id && beforeSkill.level < afterSkill.level)
        {
          levelupSkills.Add(new LevelupSkill(beforeSkill.level, afterSkill.level, afterSkill.skill));
          flg_exist = true;
        }
        UnitSkillEvolution unitSkillEvolution = UnitSkillEvolution.getUnitSkillEvolution(beforeUnit.unit.ID, beforeSkill.skill_id, afterSkill.skill_id);
        if (unitSkillEvolution == null)
          return;
        levelupSkills.Add(new LevelupSkill(beforeSkill.level, unitSkillEvolution.level, beforeSkill.skill));
        flg_exist = true;
        this.StartCoroutine(this.AddEvolutionSkill(beforeSkill));
      }));
    }));
    return levelupSkills;
  }

  [DebuggerHidden]
  private IEnumerator AddEvolutionSkill(PlayerUnitSkills beforeSkill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CAddEvolutionSkill\u003Ec__Iterator36F()
    {
      beforeSkill = beforeSkill,
      \u003C\u0024\u003EbeforeSkill = beforeSkill,
      \u003C\u003Ef__this = this
    };
  }

  private void SetMaxLv(int beforeLv, int afterLv)
  {
    bool flag = beforeLv < afterLv;
    ((Component) this.beforeLvmax).gameObject.SetActive(flag);
    ((Component) this.afterLvmax).gameObject.SetActive(flag);
    this.slcArrow.SetActive(flag);
    ((Component) this.lvmaxUnchanged).gameObject.SetActive(!flag);
    if (flag)
    {
      this.beforeLvmax.SetTextLocalize(beforeLv);
      this.afterLvmax.SetTextLocalize(afterLv);
    }
    else
      this.lvmaxUnchanged.SetTextLocalize(afterLv);
  }

  private void SetLimitbreak(int beforeBreakCount, int afterBreakCount, int breakthrough_limit)
  {
    for (int index = 0; index < this.SlcLBiconNone.Length; ++index)
    {
      this.SlcLBiconNone[index].SetActive(index >= afterBreakCount && index < breakthrough_limit);
      this.SlcLBiconBlue[index].SetActive(index < afterBreakCount);
      this.SlcLBiconBlueEff[index].SetActive(index >= beforeBreakCount && index < afterBreakCount);
    }
    if (breakthrough_limit != 0)
      return;
    this.slc_Limitbreak.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator SetUnitTexture(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CSetUnitTexture\u003Ec__Iterator370()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator setCharacter(PlayerUnit beforeUnit, PlayerUnit afterUnit, List<int> otherData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CsetCharacter\u003Ec__Iterator371()
    {
      otherData = otherData,
      afterUnit = afterUnit,
      beforeUnit = beforeUnit,
      \u003C\u0024\u003EotherData = otherData,
      \u003C\u0024\u003EafterUnit = afterUnit,
      \u003C\u0024\u003EbeforeUnit = beforeUnit,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet() || this.isPlayPopup)
      return;
    this.isPlayPopup = true;
    this.StartCoroutine(this.PopupSequence());
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnNextSkill()
  {
    this.SkillLevelupObject[this.displaySkillIndex].GetComponent<SkillLevelup>().EndTween();
  }

  public void StartNextTween()
  {
    ++this.displaySkillIndex;
    if (this.displaySkillIndex < this.SkillLevelupObject.Length)
    {
      this.SkillLevelupObject[this.displaySkillIndex].SetActive(true);
      this.SkillLevelupObject[this.displaySkillIndex].GetComponent<SkillLevelup>().StartTween();
    }
    if (this.displaySkillIndex > this.SkillLevelupObject.Length - 1)
      return;
    this.isDispNextSkill = false;
  }

  private GameObject OpenPopup(GameObject original)
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(original);
    ((Component) gameObject.transform.parent.Find("Popup Mask")).gameObject.GetComponent<TweenAlpha>().to = 0.75f;
    return gameObject;
  }

  [DebuggerHidden]
  private IEnumerator PopupSequence()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CPopupSequence\u003Ec__Iterator372()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator NextSkillPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CNextSkillPopup\u003Ec__Iterator373()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MedalPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CMedalPopup\u003Ec__Iterator374()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CharacterQuestStoryPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CCharacterQuestStoryPopup\u003Ec__Iterator375()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SkillRankUpPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CSkillRankUpPopup\u003Ec__Iterator376()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator FinishSequence()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004813Menu.\u003CFinishSequence\u003Ec__Iterator377()
    {
      \u003C\u003Ef__this = this
    };
  }

  private delegate IEnumerator Runner();
}
