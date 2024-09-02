// Decompiled with JetBrains decompiler
// Type: clipEffectPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class clipEffectPlayer : MonoBehaviour
{
  private WeaponTrail _trail;
  private bool firstStep = true;
  private int countStep;
  private NGDuelUnit MyUnit;
  private BattleLandform mLandForm;
  protected UnitUnit _mUnit;
  private UnitUnit mDeteilUnit;
  private const int defaultFootstepSound = 5000;

  public WeaponTrail trail
  {
    get
    {
      if ((UnityEngine.Object) this._trail == (UnityEngine.Object) null)
        this._trail = this.gameObject.GetComponentInChildren<WeaponTrail>();
      return this._trail;
    }
  }

  private NGDuelUnit EnemyUnit => !((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null) ? (NGDuelUnit) null : this.MyUnit.Enemy;

  private NGDuelManager duelManager => !((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null) ? (NGDuelManager) null : this.MyUnit.manager;

  private bool isDuel => (UnityEngine.Object) this.duelManager != (UnityEngine.Object) null;

  private BattleLandform landformFlat => MasterData.BattleLandform[1];

  private UnitUnit mUnit
  {
    get
    {
      if (this._mUnit == null)
      {
        if ((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null)
        {
          if (this.MyUnit.mMyUnitData != (BL.Unit) null)
            this._mUnit = this.MyUnit.mMyUnitData.unit;
        }
        else
        {
          BattleUnitParts componentInParent = this.gameObject.GetComponentInParent<BattleUnitParts>();
          if ((UnityEngine.Object) componentInParent != (UnityEngine.Object) null)
            this._mUnit = componentInParent.getUnitPosition().unit.unit;
        }
      }
      return this._mUnit;
    }
  }

  private BL.Unit blUnit
  {
    get
    {
      if ((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null && this.MyUnit.mMyUnitData != (BL.Unit) null)
        return this.MyUnit.mMyUnitData;
      BattleUnitParts componentInParent = this.gameObject.GetComponentInParent<BattleUnitParts>();
      return !((UnityEngine.Object) componentInParent != (UnityEngine.Object) null) ? (BL.Unit) null : componentInParent.getUnitPosition().unit;
    }
  }

  public UnitUnit DeteilUnit
  {
    get => this.mDeteilUnit;
    set => this.mDeteilUnit = value;
  }

  private void Start()
  {
    this.MyUnit = this.gameObject.GetComponent<NGDuelUnit>();
    if ((UnityEngine.Object) this.MyUnit == (UnityEngine.Object) null && (UnityEngine.Object) this.transform.parent != (UnityEngine.Object) null)
      this.MyUnit = this.transform.parent.gameObject.GetComponent<NGDuelUnit>();
    this._trail = this.gameObject.GetComponentInChildren<WeaponTrail>();
  }

  public int lastPlaySound { get; private set; } = -1;

  protected virtual void playSound(string var)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    string str = var;
    if (var.Contains("FOOTSTEPS"))
    {
      int num = Mathf.RoundToInt(Time.timeScale);
      if (num < 1)
        num = 1;
      if (this.countStep++ % num != 0)
        return;
      if (this.mUnit == null)
      {
        this.lastPlaySound = instance.playSE("SE_5000");
      }
      else
      {
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
      if (!((UnityEngine.Object) null != (UnityEngine.Object) instance) || !(str != ""))
        return;
      this.lastPlaySound = instance.playSE(strArray[0]);
    }
  }

  public void setGroundStatus(BattleLandform lf) => this.mLandForm = lf;

  public void playEffect(string str)
  {
    if ((UnityEngine.Object) this.MyUnit == (UnityEngine.Object) null)
      return;
    if (str == "weapon_trail_on")
    {
      if (!((UnityEngine.Object) this.trail != (UnityEngine.Object) null))
        return;
      this.trail.On(this.transform, this.MyUnit);
    }
    else if (str == "weapon_trail_off")
    {
      if (!((UnityEngine.Object) this.trail != (UnityEngine.Object) null))
        return;
      this.trail.Off();
    }
    else
    {
      if (str.Contains("_locus_hit"))
      {
        BL.DuelTurn thisTurnDamage = this.MyUnit.thisTurnDamage;
        this.EnemyUnit.damaged(this.EnemyUnit.useDistance);
        if (thisTurnDamage == null || !thisTurnDamage.isHit)
          return;
        if (this.EnemyUnit.mMyUnitData.playerUnit.equippedGearOrInitial.kind.Enum == GearKindEnum.shield || this.EnemyUnit.mMyUnitData.playerUnit.equippedGear2 != (PlayerItem) null && this.EnemyUnit.mMyUnitData.playerUnit.equippedGear2.gear.kind.Enum == GearKindEnum.shield)
        {
          if (!thisTurnDamage.isCritical || !this.MyUnit.mIsLastAttack)
            return;
          this.StartCoroutine(this.EnemyUnit.playCriticalFlash());
          return;
        }
        if (thisTurnDamage.isCritical && this.MyUnit.mIsLastAttack)
          this.StartCoroutine(this.EnemyUnit.playCriticalFlash());
      }
      string[] strArray = str.Split(':');
      string target = "0";
      string parent_name = "";
      if (strArray == null || strArray.Length == 0)
        return;
      string effectName;
      if (strArray.Length == 1)
        effectName = strArray[0];
      else if (strArray.Length == 4)
      {
        effectName = strArray[0];
        target = strArray[1];
        parent_name = strArray[3];
      }
      else
      {
        effectName = strArray[0];
        target = strArray[1];
        if (target == "3")
          parent_name = strArray[2];
      }
      this.StartCoroutine(this.loadEffect(effectName, target, parent_name));
    }
  }

  private string changeEffect(string src)
  {
    string str = src;
    if (str.Equals("ef515_def_hit"))
    {
      if ((UnityEngine.Object) this.EnemyUnit != (UnityEngine.Object) null)
      {
        foreach (BL.Skill skill in ((IEnumerable<BL.Skill>) this.EnemyUnit.thisTurn.invokeDefenderDuelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x =>
        {
          BattleskillGenre? genre1 = x.genre1;
          BattleskillGenre battleskillGenre = BattleskillGenre.defense;
          return genre1.GetValueOrDefault() == battleskillGenre & genre1.HasValue && x.skill.duel_effect != null;
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
    else if (str.Contains("_locus_hit") && (UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null)
    {
      DuelElementHitEffect elementHitEffect = this.MyUnit.GetElementHitEffect(src);
      if (elementHitEffect != null && !string.IsNullOrEmpty(elementHitEffect.change_effect_name))
        str = elementHitEffect.change_effect_name;
    }
    return str;
  }

  private IEnumerator loadEffect(string effectName, string target, string parent_name)
  {
    clipEffectPlayer clipEffectPlayer = this;
    if (!effectName.Contains("weapon_trail_"))
    {
      GameObject place = clipEffectPlayer.duelManager.mRoot3d;
      if ((UnityEngine.Object) null == (UnityEngine.Object) place)
        place = clipEffectPlayer.gameObject;
      effectName = clipEffectPlayer.changeEffect(effectName);
      GameObject gameObject = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(effectName, place.transform);
      if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      {
        Future<GameObject> go = new ResourceObject(string.Format("BattleEffects/duel/{0}", (object) effectName)).Load<GameObject>();
        IEnumerator e = go.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        gameObject = go.Result.Clone(place.transform);
        if (clipEffectPlayer.isDuel)
          Singleton<NGDuelDataManager>.GetInstance().AddDestroyList(gameObject);
        go = (Future<GameObject>) null;
      }
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        clipEffectPlayer.goEffect(gameObject, effectName, target, parent_name);
      else
        Debug.LogError((object) ("clipEffectPlayer not load effectName:" + effectName));
    }
  }

  private void goEffect(GameObject goef, string kwd1, string kwd2, string kwd3)
  {
    goef.transform.localRotation = this.gameObject.transform.rotation;
    if (kwd2 == "0")
    {
      if (!string.IsNullOrEmpty(kwd3))
      {
        Transform transform = this.gameObject.transform.GetChildInFind(kwd3);
        if ((UnityEngine.Object) null == (UnityEngine.Object) transform)
          transform = this.gameObject.transform;
        goef.SetParent(transform.gameObject);
      }
      else
      {
        if (kwd1.Equals("ef515_def_hit") || kwd1.Equals("ef703_duel_holysheeld"))
        {
          Transform transform = !((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null) ? this.gameObject.transform.GetChildInFind("Bip") : this.MyUnit.mBipTransform;
          if ((UnityEngine.Object) null == (UnityEngine.Object) transform)
            transform = this.gameObject.transform;
          goef.transform.localPosition = transform.position;
        }
        else
          goef.transform.localPosition = this.gameObject.transform.position;
        goef.transform.parent = this.gameObject.transform;
      }
    }
    else if (kwd2 == "1")
    {
      if (!((UnityEngine.Object) this.EnemyUnit != (UnityEngine.Object) null))
        return;
      if (!string.IsNullOrEmpty(kwd3))
      {
        Transform transform = this.EnemyUnit.gameObject.transform.GetChildInFind(kwd3);
        if ((UnityEngine.Object) null == (UnityEngine.Object) transform)
          transform = this.EnemyUnit.gameObject.transform;
        goef.transform.parent = transform;
      }
      else
      {
        Transform childInFind = this.EnemyUnit.gameObject.transform.GetChildInFind("damagepoint_a");
        if ((UnityEngine.Object) null != (UnityEngine.Object) childInFind)
        {
          goef.transform.localPosition = childInFind.position;
        }
        else
        {
          Transform transform = this.EnemyUnit.mBipTransform;
          if ((UnityEngine.Object) null == (UnityEngine.Object) transform)
            transform = this.EnemyUnit.gameObject.transform;
          goef.transform.localPosition = transform.position;
        }
      }
    }
    else if (kwd2 == "2")
    {
      Transform transform1 = this.gameObject.transform.GetChildInFind("weaponr");
      if ((UnityEngine.Object) null == (UnityEngine.Object) transform1)
        transform1 = this.gameObject.transform;
      Transform transform2 = transform1.GetChild(0);
      if ((UnityEngine.Object) null == (UnityEngine.Object) transform2)
        transform2 = this.gameObject.transform;
      goef.transform.localPosition = transform2.position;
    }
    else if (kwd2 == "3")
      goef.SetParent(this.FindParentInRoot(kwd3));
    else if (kwd2 == "4")
    {
      GameObject baseGameObject = this.MyUnit.baseGameObject;
      if (!string.IsNullOrEmpty(kwd3))
      {
        Transform transform = baseGameObject.transform.GetChildInFind(kwd3);
        if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
          transform = baseGameObject.transform;
        goef.SetParent(transform.gameObject);
      }
      else
        goef.SetParent(baseGameObject);
    }
    else
    {
      if (!(kwd2 == "5") || !((UnityEngine.Object) this.EnemyUnit != (UnityEngine.Object) null))
        return;
      GameObject baseGameObject = this.EnemyUnit.baseGameObject;
      if (!string.IsNullOrEmpty(kwd3))
      {
        Transform transform = baseGameObject.transform.GetChildInFind(kwd3);
        if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
          transform = baseGameObject.transform;
        goef.SetParent(transform.gameObject);
      }
      else
        goef.SetParent(baseGameObject);
    }
  }

  private GameObject FindParentInRoot(string name)
  {
    GameObject gameObject = this.duelManager.mRoot3d;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      gameObject = this.gameObject;
    if (!string.IsNullOrEmpty(name))
    {
      Transform transform = gameObject.transform.Find(name);
      if ((UnityEngine.Object) transform != (UnityEngine.Object) null)
        gameObject = transform.gameObject;
    }
    return gameObject;
  }

  public void shoot()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.shootSomething();
  }

  public void shootready()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.shootSomethingReady();
  }

  public void backstepStart()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.playBackstepFromClip();
  }

  public void Attack1Start()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.AtAttack1();
  }

  public void Attack2Start()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.AtAttack2();
  }

  public void AttackSStart()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.AtAttackS();
  }

  public void DodgeStart()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.SetDodgeMode();
  }

  public void playVoiceCue(int Cue)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!((UnityEngine.Object) null != (UnityEngine.Object) instance))
      return;
    BL.Unit blUnit = this.blUnit;
    UnitVoicePattern voicePattern = blUnit != (BL.Unit) null ? blUnit.getVoicePattern() : (UnitVoicePattern) null;
    if (voicePattern == null && this.DeteilUnit != null)
      voicePattern = this.DeteilUnit.unitVoicePattern;
    if (voicePattern == null)
      return;
    instance.playVoiceByID(voicePattern, Cue);
  }

  public void HideWeapon()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveEquipeWeapon(false);
  }

  public void ShowWeapon()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveEquipeWeapon(true);
  }

  public void HideMap()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.manager.SetActiveMap(false);
  }

  public void ShowMap()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.manager.SetActiveMap(true);
  }

  public void HideShadow()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveShadow(false);
  }

  public void ShowShadow()
  {
    if (!((UnityEngine.Object) null != (UnityEngine.Object) this.MyUnit))
      return;
    this.MyUnit.SetActiveShadow(true);
  }

  public void start_attack()
  {
    if (!((UnityEngine.Object) this.MyUnit != (UnityEngine.Object) null))
      return;
    this.MyUnit.AddAttackMotionCount();
  }
}
