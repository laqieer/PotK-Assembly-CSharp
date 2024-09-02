// Decompiled with JetBrains decompiler
// Type: clipEffectPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class clipEffectPlayer : MonoBehaviour
{
  private const int defaultFootstepSound = 5000;
  private WeaponTrail _trail;
  private bool firstStep = true;
  private NGDuelUnit MyUnit;
  private BattleLandform mLandForm;
  private UnitUnit _mUnit;
  private UnitUnit mDeteilUnit;

  public WeaponTrail trail
  {
    get
    {
      if (Object.op_Equality((Object) this._trail, (Object) null))
        this._trail = ((Component) this).gameObject.GetComponentInChildren<WeaponTrail>();
      return this._trail;
    }
  }

  private NGDuelUnit EnemyUnit
  {
    get
    {
      return Object.op_Inequality((Object) this.MyUnit, (Object) null) ? this.MyUnit.Enemy : (NGDuelUnit) null;
    }
  }

  private NGDuelManager duelManager
  {
    get
    {
      return Object.op_Inequality((Object) this.MyUnit, (Object) null) ? this.MyUnit.manager : (NGDuelManager) null;
    }
  }

  private BattleLandform landformFlat => MasterData.BattleLandform[1];

  private UnitUnit mUnit
  {
    get
    {
      if (this._mUnit == null)
      {
        if (Object.op_Inequality((Object) this.MyUnit, (Object) null))
        {
          if (this.MyUnit.mMyUnitData != null)
            this._mUnit = this.MyUnit.mMyUnitData.unit;
        }
        else
        {
          BattleUnitParts componentInParent = ((Component) this).gameObject.GetComponentInParent<BattleUnitParts>();
          if (Object.op_Inequality((Object) componentInParent, (Object) null))
            this._mUnit = componentInParent.getUnitPosition().unit.unit;
        }
      }
      return this._mUnit;
    }
  }

  public UnitUnit DeteilUnit
  {
    get => this.mDeteilUnit;
    set => this.mDeteilUnit = value;
  }

  private void Start()
  {
    this.MyUnit = ((Component) this).gameObject.GetComponent<NGDuelUnit>();
    if (Object.op_Equality((Object) this.MyUnit, (Object) null) && Object.op_Inequality((Object) ((Component) this).transform.parent, (Object) null))
      this.MyUnit = ((Component) ((Component) this).transform.parent).gameObject.GetComponent<NGDuelUnit>();
    this._trail = ((Component) this).gameObject.GetComponentInChildren<WeaponTrail>();
  }

  private void playSound(string var)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    string str = var;
    if (var.Contains("FOOTSTEPS"))
    {
      if (this.mUnit == null)
      {
        instance.playSE("SE_5000");
      }
      else
      {
        string empty = string.Empty;
        string clip;
        if (this.firstStep)
        {
          this.firstStep = false;
          clip = this.mLandForm == null ? this.landformFlat.GetFootstep(this.mUnit).footstep1 : this.mLandForm.GetFootstep(this.mUnit).footstep1;
        }
        else
        {
          this.firstStep = true;
          clip = this.mLandForm == null ? this.landformFlat.GetFootstep(this.mUnit).footstep2 : this.mLandForm.GetFootstep(this.mUnit).footstep2;
        }
        instance.playSE(clip);
      }
    }
    else
    {
      string[] strArray = str.Split('.');
      if (!Object.op_Inequality((Object) null, (Object) instance) || !(str != string.Empty))
        return;
      instance.playSE(strArray[0]);
    }
  }

  public void setGroundStatus(BattleLandform lf) => this.mLandForm = lf;

  public void playEffect(string str)
  {
    if (Object.op_Equality((Object) this.MyUnit, (Object) null))
      return;
    switch (str)
    {
      case "weapon_trail_on":
        if (!Object.op_Inequality((Object) this.trail, (Object) null))
          break;
        this.trail.On(((Component) this).transform, this.MyUnit);
        break;
      case "weapon_trail_off":
        if (!Object.op_Inequality((Object) this.trail, (Object) null))
          break;
        this.trail.Off();
        break;
      default:
        if (str.Contains("_locus_hit"))
        {
          this.EnemyUnit.damaged(this.EnemyUnit.useDistance);
          if (!this.MyUnit.isThisTurnHit())
            break;
          if (this.EnemyUnit.mMyUnitData.playerUnit.equippedGearOrInitial.kind.Enum == GearKindEnum.shield)
          {
            if (!this.MyUnit.isThisTurnCritical() || !this.MyUnit.mIsLastAttack)
              break;
            this.StartCoroutine(this.EnemyUnit.playCriticalFlash());
            break;
          }
          if (this.MyUnit.isThisTurnCritical() && this.MyUnit.mIsLastAttack)
            this.StartCoroutine(this.EnemyUnit.playCriticalFlash());
        }
        string[] strArray = str.Split(':');
        string empty1 = string.Empty;
        string target = "0";
        string empty2 = string.Empty;
        if (strArray == null || strArray.Length == 0)
          break;
        string effectName;
        if (strArray.Length == 1)
          effectName = strArray[0];
        else if (strArray.Length == 4)
        {
          effectName = strArray[0];
          target = strArray[1];
          empty2 = strArray[3];
        }
        else
        {
          effectName = strArray[0];
          target = strArray[1];
        }
        this.StartCoroutine(this.loadEffect(effectName, target, empty2));
        break;
    }
  }

  private string changeEffect(string src)
  {
    string str = src;
    if (str.Equals("ef515_def_hit"))
    {
      if (Object.op_Inequality((Object) this.EnemyUnit, (Object) null))
      {
        foreach (BL.Skill skill in ((IEnumerable<BL.Skill>) this.EnemyUnit.thisTurn.invokeDefenderDuelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x =>
        {
          BattleskillGenre? genre1 = x.genre1;
          return (genre1.GetValueOrDefault() != BattleskillGenre.defense ? 0 : (genre1.HasValue ? 1 : 0)) != 0 && x.skill.duel_effect != null;
        })))
        {
          if (!string.IsNullOrEmpty(skill.skill.duel_effect.duel_effect_name))
          {
            str = skill.skill.duel_effect.duel_effect_name;
            break;
          }
        }
      }
      if (string.IsNullOrEmpty(str))
        str = "ef515_def_hit";
    }
    else if (str.Contains("_locus_hit") && Object.op_Inequality((Object) this.MyUnit, (Object) null))
    {
      DuelElementHitEffect elementHitEffect = this.MyUnit.GetElementHitEffect(src);
      if (elementHitEffect != null && !string.IsNullOrEmpty(elementHitEffect.change_effect_name))
        str = elementHitEffect.change_effect_name;
    }
    return str;
  }

  [DebuggerHidden]
  private IEnumerator loadEffect(string effectName, string target, string parent_name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new clipEffectPlayer.\u003CloadEffect\u003Ec__Iterator93E()
    {
      effectName = effectName,
      target = target,
      parent_name = parent_name,
      \u003C\u0024\u003EeffectName = effectName,
      \u003C\u0024\u003Etarget = target,
      \u003C\u0024\u003Eparent_name = parent_name,
      \u003C\u003Ef__this = this
    };
  }

  private void goEffect(GameObject goef, string kwd1, string kwd2, string kwd3)
  {
    goef.transform.localRotation = ((Component) this).gameObject.transform.rotation;
    switch (kwd2)
    {
      case "0":
        if (!string.IsNullOrEmpty(kwd3))
        {
          Transform transform = ((Component) this).gameObject.transform.GetChildInFind(kwd3);
          if (Object.op_Equality((Object) null, (Object) transform))
            transform = ((Component) this).gameObject.transform;
          goef.SetParent(((Component) transform).gameObject);
          break;
        }
        if (kwd1.Equals("ef515_def_hit") || kwd1.Equals("ef703_duel_holysheeld"))
        {
          Transform transform = !Object.op_Inequality((Object) this.MyUnit, (Object) null) ? ((Component) this).gameObject.transform.GetChildInFind("Bip") : this.MyUnit.mBipTransform;
          if (Object.op_Equality((Object) null, (Object) transform))
            transform = ((Component) this).gameObject.transform;
          goef.transform.localPosition = transform.position;
        }
        else
          goef.transform.localPosition = ((Component) this).gameObject.transform.position;
        goef.transform.parent = ((Component) this).gameObject.transform;
        break;
      case "1":
        if (!Object.op_Inequality((Object) this.EnemyUnit, (Object) null))
          break;
        if (!string.IsNullOrEmpty(kwd3))
        {
          Transform transform = ((Component) this.EnemyUnit).gameObject.transform.GetChildInFind(kwd3);
          if (Object.op_Equality((Object) null, (Object) transform))
            transform = ((Component) this.EnemyUnit).gameObject.transform;
          goef.transform.parent = transform;
          break;
        }
        Transform childInFind = ((Component) this.EnemyUnit).gameObject.transform.GetChildInFind("damagepoint_a");
        if (Object.op_Inequality((Object) null, (Object) childInFind))
        {
          goef.transform.localPosition = childInFind.position;
          break;
        }
        Transform transform1 = this.EnemyUnit.mBipTransform;
        if (Object.op_Equality((Object) null, (Object) transform1))
          transform1 = ((Component) this.EnemyUnit).gameObject.transform;
        goef.transform.localPosition = transform1.position;
        break;
      case "2":
        Transform transform2 = ((Component) this).gameObject.transform.GetChildInFind("weaponr");
        if (Object.op_Equality((Object) null, (Object) transform2))
          transform2 = ((Component) this).gameObject.transform;
        Transform transform3 = transform2.GetChild(0);
        if (Object.op_Equality((Object) null, (Object) transform3))
          transform3 = ((Component) this).gameObject.transform;
        goef.transform.localPosition = transform3.position;
        break;
    }
  }

  public void shoot()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.shootSomething();
  }

  public void shootready()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.shootSomethingReady();
  }

  public void backstepStart()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.playBackstepFromClip();
  }

  public void Attack1Start()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.AtAttack1();
  }

  public void Attack2Start()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.AtAttack2();
  }

  public void AttackSStart()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.AtAttackS();
  }

  public void DodgeStart()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.SetDodgeMode();
  }

  public void playVoiceCue(int Cue)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) null, (Object) instance))
      return;
    if (this.mUnit == null)
      instance.playVoiceByID(this.DeteilUnit.unitVoicePattern.file_name, Cue);
    else
      instance.playVoiceByID(this.mUnit.unitVoicePattern.file_name, Cue);
  }

  public void HideWeapon()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveEquipeWeapon(false);
  }

  public void ShowWeapon()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveEquipeWeapon(true);
  }

  public void HideMap()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.manager.SetActiveMap(false);
  }

  public void ShowMap()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.MyUnit))
      return;
    this.MyUnit.manager.SetActiveMap(true);
  }
}
