// Decompiled with JetBrains decompiler
// Type: Battle0181CharacterStatus
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
public class Battle0181CharacterStatus : NGBattleMenuBase
{
  [SerializeField]
  protected UI2DSprite link_skillIcon;
  [SerializeField]
  protected UILabel txt_skillName;
  [SerializeField]
  protected GameObject go_skillBase;
  [SerializeField]
  protected UI2DSprite link_skillIcon2;
  [SerializeField]
  protected UILabel txt_skillName2;
  [SerializeField]
  protected GameObject go_skillBase2;
  [SerializeField]
  protected UI2DSprite link_skillIcon3;
  [SerializeField]
  protected UILabel txt_skillName3;
  [SerializeField]
  protected GameObject go_skillBase3;
  [SerializeField]
  protected UI2DSprite link_skillIcon4;
  [SerializeField]
  protected UILabel txt_skillName4;
  [SerializeField]
  protected GameObject go_skillBase4;
  [SerializeField]
  private NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected UISprite link_spattackUp;
  [SerializeField]
  protected UISprite link_spattackDown;
  [SerializeField]
  protected UILabel txt_weaponName;
  [SerializeField]
  protected UI2DSprite link_weaponIcon;
  [SerializeField]
  protected UILabel txt_hpDamaged;
  [SerializeField]
  protected UILabel txt_hpMax;
  [SerializeField]
  protected UILabel txt_hp;
  [SerializeField]
  protected UILabel txt_characterName_ElementOn;
  [SerializeField]
  protected UILabel txt_consumeHp;
  [SerializeField]
  protected GameObject go_weaponTypeIcon;
  [SerializeField]
  protected UILabel txt_attack;
  [SerializeField]
  protected UILabel txt_dex;
  [SerializeField]
  protected UILabel txt_critical;
  [SerializeField]
  protected UI2DSprite link_characterIcon;
  [SerializeField]
  protected GameObject link_elementIcon;
  [SerializeField]
  protected GameObject go_commonElementIcon;
  [SerializeField]
  protected float flSkillDispTime;
  [SerializeField]
  protected UILabel TxtHpNumber;
  [SerializeField]
  protected GameObject attackCountOwner;
  [SerializeField]
  protected GameObject[] attackCount;
  private GameObject gearTypeIcon;
  private GameObject elementIcon;
  private BL.UnitPosition current;
  private UnitIcon unitIcon;
  private int currentHp;
  private int maxHp;
  public bool isHpDamaged;
  private List<ParticleSystem> particleList = new List<ParticleSystem>();
  private int tmpAttackCount;

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    UI2DSprite componentInChildren2 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions(componentInChildren2.width, componentInChildren2.height);
    componentInChildren1.depth = 100;
    return icon;
  }

  public virtual void Init(BL.UnitPosition up, AttackStatus attackStatus)
  {
    this.current = up;
    BL.Unit unit = up.unit;
    this.currentHp = unit.hp;
    if (unit.skills.Length > 0)
      this.txt_skillName.SetTextLocalize(unit.skills[0].name);
    try
    {
      this.hpGauge.setValue(unit.hp, unit.parameter.Hp);
    }
    catch (InvalidOperationException ex)
    {
      this.hpGauge.setValue(unit.hp, unit.hp);
    }
    this.txt_weaponName.SetTextLocalize(unit.playerUnit.equippedGearName);
    if (Object.op_Equality((Object) this.gearTypeIcon, (Object) null))
      this.gearTypeIcon = this.createIcon(this.go_weaponTypeIcon, ((Component) this.link_weaponIcon).transform);
    if (Object.op_Inequality((Object) null, (Object) this.gearTypeIcon))
    {
      GearKindIcon component = this.gearTypeIcon.GetComponent<GearKindIcon>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        CommonElement element = !(unit.playerUnit.equippedGear != (PlayerItem) null) ? unit.playerUnit.equippedGearOrInitial.GetElement() : unit.playerUnit.equippedGear.GetElement();
        component.Init(unit.playerUnit.equippedGearOrInitial.kind, element);
      }
    }
    this.SetUnitGearIcon(unit);
    if (Object.op_Implicit((Object) this.txt_hpDamaged))
      this.txt_hpDamaged.SetTextLocalize(string.Empty);
    this.maxHp = unit.parameter.Hp;
    this.setHPNumbers(unit.hp.ToString());
    this.attackCount[0].SetActive(false);
    this.attackCount[1].SetActive(false);
    this.attackCount[2].SetActive(false);
    if (attackStatus != null)
      this.setAttackCount(attackStatus.attackCount);
    if (attackStatus != null)
    {
      string text = Mathf.Max(Mathf.FloorToInt((float) attackStatus.attack * attackStatus.elementAttackRate), 1).ToString();
      if ((double) attackStatus.elementAttackRate > 1.0)
        text = "[00ff00]" + text;
      else if ((double) attackStatus.elementAttackRate < 1.0)
        text = "[ff0000]" + text;
      this.txt_attack.SetTextLocalize(text);
      this.txt_critical.SetTextLocalize(attackStatus.criticalDisplay().ToString() + "%");
      this.txt_dex.SetTextLocalize(attackStatus.dexerityDisplay().ToString() + "%");
    }
    else
    {
      this.txt_attack.SetText("-");
      this.txt_critical.SetText("-");
      this.txt_dex.SetText("-");
    }
    this.txt_consumeHp.SetText(string.Empty);
    this.go_skillBase.SetActive(false);
    this.go_skillBase2.SetActive(false);
    this.go_skillBase3.SetActive(false);
    this.go_skillBase4.SetActive(false);
    this.isHpDamaged = false;
    this.StartCoroutine("LoadCharaIcon");
  }

  public virtual void ChangeStatus(BL.UnitPosition up, AttackStatus attackStatus)
  {
    if (attackStatus.duelParameter == null)
      return;
    this.txt_weaponName.SetTextLocalize(up.unit.playerUnit.equippedGearName);
    this.attackCount[0].SetActive(false);
    this.attackCount[1].SetActive(false);
    this.attackCount[2].SetActive(false);
    if (attackStatus != null)
      this.setAttackCount(attackStatus.attackCount);
    if (attackStatus != null)
    {
      string text = Mathf.Max(Mathf.FloorToInt((float) attackStatus.attack * attackStatus.elementAttackRate), 1).ToString();
      if ((double) attackStatus.elementAttackRate > 1.0)
        text = "[00ff00]" + text;
      else if ((double) attackStatus.elementAttackRate < 1.0)
        text = "[ff0000]" + text;
      this.txt_attack.SetTextLocalize(text);
      this.txt_critical.SetTextLocalize(attackStatus.criticalDisplay().ToString() + "%");
      this.txt_dex.SetTextLocalize(attackStatus.dexerityDisplay().ToString() + "%");
    }
    else
    {
      this.txt_attack.SetText("-");
      this.txt_critical.SetText("-");
      this.txt_dex.SetText("-");
    }
    this.go_skillBase.SetActive(false);
    this.go_skillBase2.SetActive(false);
    this.go_skillBase3.SetActive(false);
  }

  private void SetUnitGearIcon(BL.Unit unit)
  {
    if (Object.op_Equality((Object) this.elementIcon, (Object) null))
      this.elementIcon = this.createIcon(this.go_weaponTypeIcon, this.link_elementIcon.transform);
    this.txt_characterName_ElementOn.SetTextLocalize(unit.unit.name);
    if (!Object.op_Inequality((Object) this.elementIcon, (Object) null))
      return;
    this.elementIcon.GetComponent<GearKindIcon>().Init(unit.unit.kind, unit.playerUnit.GetElement());
  }

  private void setAttackCount(int count)
  {
    int num = count - 2;
    int index;
    switch (count)
    {
      case 2:
        index = 0;
        break;
      case 3:
        index = 1;
        break;
      case 4:
        index = 2;
        break;
      default:
        index = -1;
        break;
    }
    if (index < 0)
      return;
    this.attackCount[index].SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator LoadCharaIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181CharacterStatus.\u003CLoadCharaIcon\u003Ec__Iterator89D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public BL.UnitPosition getCurrent() => this.current;

  public void Damaged(int damage, int? heal = null)
  {
    Debug.Log((object) ("Damaged: " + (object) damage));
    this.currentHp -= Math.Max(0, damage);
    if (0 > this.currentHp)
      this.currentHp = 0;
    this.txt_consumeHp.SetTextLocalize(damage);
    ((IEnumerable<UITweener>) ((Component) this.txt_consumeHp).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
    if (heal.HasValue)
    {
      this.currentHp += Math.Min(this.maxHp - this.currentHp, heal.Value);
      if (this.maxHp < this.currentHp)
        this.currentHp = this.maxHp;
    }
    this.setHPNumbers(this.currentHp.ToString());
    this.hpGauge.setValue(this.currentHp, this.current.unit.parameter.Hp);
  }

  public void Healed(int heal)
  {
    this.currentHp += Math.Min(this.maxHp - this.currentHp, heal);
    if (this.maxHp < this.currentHp)
      this.currentHp = this.maxHp;
    this.hpGauge.setValue(this.currentHp, this.current.unit.parameter.Hp);
    this.setHPNumbers(this.currentHp.ToString());
  }

  public void skillInvoke(BL.Skill[] skills) => this.severalSkillsInvoke(skills);

  private void severalSkillsInvoke(BL.Skill[] skills)
  {
    if (skills.Length >= 1)
      this.StartCoroutine(this.displaySkill(skills[0]));
    if (skills.Length >= 2)
      this.StartCoroutine(this.displaySkill2(skills[1]));
    if (skills.Length >= 3)
      this.StartCoroutine(this.displaySkill3(skills[2]));
    if (skills.Length < 4)
      return;
    this.StartCoroutine(this.displaySkill4(skills[3]));
  }

  public void skillInvoke(BL.Skill skill) => this.StartCoroutine(this.displaySkill(skill));

  [DebuggerHidden]
  private IEnumerator displaySkill(BL.Skill iskill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181CharacterStatus.\u003CdisplaySkill\u003Ec__Iterator89E()
    {
      iskill = iskill,
      \u003C\u0024\u003Eiskill = iskill,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator displaySkill2(BL.Skill iskill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181CharacterStatus.\u003CdisplaySkill2\u003Ec__Iterator89F()
    {
      iskill = iskill,
      \u003C\u0024\u003Eiskill = iskill,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator displaySkill3(BL.Skill iskill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181CharacterStatus.\u003CdisplaySkill3\u003Ec__Iterator8A0()
    {
      iskill = iskill,
      \u003C\u0024\u003Eiskill = iskill,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator displaySkill4(BL.Skill iskill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181CharacterStatus.\u003CdisplaySkill4\u003Ec__Iterator8A1()
    {
      iskill = iskill,
      \u003C\u0024\u003Eiskill = iskill,
      \u003C\u003Ef__this = this
    };
  }

  private void setHPNumbers(string hp) => this.TxtHpNumber.SetTextLocalize(hp);

  public void colosseumParameterChangeEffect(
    AttackStatus attackStatus,
    AttackStatus newAttackStatus,
    GameObject upEffect,
    GameObject downEffect)
  {
    if (newAttackStatus == null)
      return;
    if (attackStatus.attack != newAttackStatus.attack)
    {
      string text = Mathf.Max(Mathf.FloorToInt((float) newAttackStatus.attack * newAttackStatus.elementAttackRate), 1).ToString();
      if ((double) newAttackStatus.elementAttackRate > 1.0)
        text = "[00ff00]" + text;
      else if ((double) newAttackStatus.elementAttackRate < 1.0)
        text = "[ff0000]" + text;
      this.txt_attack.SetTextLocalize(text);
      if (attackStatus.attack < newAttackStatus.attack)
      {
        ParticleSystem component = upEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_attack).gameObject.transform);
        if (Object.op_Inequality((Object) component, (Object) null))
          this.particleList.Add(component);
      }
      else if (attackStatus.attack > newAttackStatus.attack)
      {
        ParticleSystem component = downEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_attack).gameObject.transform);
        if (Object.op_Inequality((Object) component, (Object) null))
          this.particleList.Add(component);
      }
    }
    if (attackStatus.dexerityDisplay() != newAttackStatus.dexerityDisplay())
    {
      this.txt_dex.SetTextLocalize(newAttackStatus.dexerityDisplay().ToString() + "%");
      if (attackStatus.dexerityDisplay() < newAttackStatus.dexerityDisplay())
      {
        ParticleSystem component = upEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_dex).gameObject.transform);
        if (Object.op_Inequality((Object) component, (Object) null))
          this.particleList.Add(component);
      }
      else if (attackStatus.dexerityDisplay() > newAttackStatus.dexerityDisplay())
      {
        ParticleSystem component = downEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_dex).gameObject.transform);
        if (Object.op_Inequality((Object) component, (Object) null))
          this.particleList.Add(component);
      }
    }
    if (attackStatus.criticalDisplay() == newAttackStatus.criticalDisplay())
      return;
    this.txt_critical.SetTextLocalize(newAttackStatus.criticalDisplay().ToString() + "%");
    if (attackStatus.criticalDisplay() < newAttackStatus.criticalDisplay())
    {
      ParticleSystem component = upEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_critical).gameObject.transform);
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      this.particleList.Add(component);
    }
    else
    {
      if (attackStatus.criticalDisplay() <= newAttackStatus.criticalDisplay())
        return;
      ParticleSystem component = downEffect.CloneAndGetComponent<ParticleSystem>(((Component) this.txt_critical).gameObject.transform);
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      this.particleList.Add(component);
    }
  }

  public void startColosseumParameterChangeEffect(
    AttackStatus attackStatus,
    AttackStatus newAttackStatus)
  {
    if (newAttackStatus == null)
      return;
    foreach (ParticleSystem particle in this.particleList)
      particle.Play();
    this.particleList.Clear();
    if (attackStatus.attackCount < newAttackStatus.attackCount)
    {
      UITweener[] tweenersAll = NGTween.findTweenersAll(this.attackCountOwner, false);
      this.tmpAttackCount = newAttackStatus.attackCount;
      if (attackStatus.attackCount > 1)
      {
        NGTween.setOnTweenFinished(tweenersAll, (MonoBehaviour) this, "AfterAttackCountUpAnime");
        NGTween.playTweens(tweenersAll, 100, true);
      }
      else
        this.AfterAttackCountUpAnime();
    }
    else
    {
      if (attackStatus.attackCount <= newAttackStatus.attackCount)
        return;
      UITweener[] tweenersAll = NGTween.findTweenersAll(this.attackCountOwner, false);
      this.tmpAttackCount = newAttackStatus.attackCount;
      if (attackStatus.attackCount > 2)
      {
        NGTween.setOnTweenFinished(tweenersAll, (MonoBehaviour) this, "AfterAttackCountDownAnime");
        NGTween.playTweens(tweenersAll, 101, true);
      }
      else
        this.AfterAttackCountDownAnime();
    }
  }

  private void AfterAttackCountUpAnime()
  {
    this.attackCount[0].SetActive(false);
    this.attackCount[1].SetActive(false);
    this.attackCount[2].SetActive(false);
    this.setAttackCount(this.tmpAttackCount);
    NGTween.playTweens(NGTween.findTweenersAll(this.attackCountOwner, false), 100);
  }

  private void AfterAttackCountDownAnime()
  {
    UITweener[] tweenersAll = NGTween.findTweenersAll(this.attackCountOwner, false);
    NGTween.playTweens(tweenersAll, 101);
    NGTween.setOnTweenFinished(tweenersAll, (MonoBehaviour) this, "SetAttackCount");
  }

  private void SetAttackCount()
  {
    this.attackCount[0].SetActive(false);
    this.attackCount[1].SetActive(false);
    this.attackCount[2].SetActive(false);
    this.setAttackCount(this.tmpAttackCount);
  }
}
