// Decompiled with JetBrains decompiler
// Type: BE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
[Serializable]
public class BE
{
  [NonSerialized]
  private BE.DefaultDict<BL.DropData, BE.DropDataResource> dropDataResource_;
  public BL core;
  [NonSerialized]
  private BE.DefaultDict<BL.Panel, BE.PanelResource> panelResource_;
  [NonSerialized]
  private BE.DefaultDict<BL.Stage, BE.StageResource> stageResource_;
  [NonSerialized]
  private BE.DefaultDict<BL.Item, BE.ItemResource> itemResource_;
  [NonSerialized]
  private BE.DefaultDict<int, BE.SkillResource> skillResource_;
  [NonSerialized]
  private BE.DefaultDict<int, BE.AilmentSkillResource> ailmentSkillResource_;
  [NonSerialized]
  private BE.DefaultDict<BL.Unit, BE.UnitResource> unitResource_;
  public Stack<List<BL.Unit>> waveEnemiesStack = new Stack<List<BL.Unit>>();
  public Stack<List<Tuple<BL.DropData, int>>> waveDropStack = new Stack<List<Tuple<BL.DropData, int>>>();
  [NonSerialized]
  private BE.DefaultDict<BL.Weapon, BE.WeaponResource> weaponResource_;

  public BE.DefaultDict<BL.DropData, BE.DropDataResource> dropDataResource
  {
    get => this.getDefaultDict<BL.DropData, BE.DropDataResource>(ref this.dropDataResource_);
  }

  public BE.DefaultDict<TKey, TValue> getDefaultDict<TKey, TValue>(
    ref BE.DefaultDict<TKey, TValue> v)
    where TValue : new()
  {
    if (v == null)
      v = new BE.DefaultDict<TKey, TValue>();
    return v;
  }

  public BE.DefaultDict<BL.Panel, BE.PanelResource> panelResource
  {
    get => this.getDefaultDict<BL.Panel, BE.PanelResource>(ref this.panelResource_);
  }

  public BE.DefaultDict<BL.Stage, BE.StageResource> stageResource
  {
    get => this.getDefaultDict<BL.Stage, BE.StageResource>(ref this.stageResource_);
  }

  public Vector3 limitFieldPosition(Vector3 v)
  {
    BE.PanelResource panelResource1 = this.panelResource[this.core.getFieldPanel(0, 0)];
    BE.PanelResource panelResource2 = this.panelResource[this.core.getFieldPanel(this.core.getFieldHeight() - 1, 0)];
    BE.PanelResource panelResource3 = this.panelResource[this.core.getFieldPanel(0, this.core.getFieldWidth() - 1)];
    BE.PanelResource panelResource4 = (BE.PanelResource) null;
    BE.PanelResource panelResource5 = (BE.PanelResource) null;
    if ((double) v.x < (double) panelResource1.gameObject.transform.position.x)
      panelResource4 = panelResource1;
    else if ((double) v.x > (double) panelResource3.gameObject.transform.position.x)
      panelResource4 = panelResource3;
    if ((double) v.z < (double) panelResource1.gameObject.transform.position.z)
      panelResource5 = panelResource1;
    else if ((double) v.z > (double) panelResource2.gameObject.transform.position.z)
      panelResource5 = panelResource2;
    return new Vector3(panelResource4 != null ? panelResource4.gameObject.transform.position.x : v.x, panelResource1.gameObject.transform.position.y, panelResource5 != null ? panelResource5.gameObject.transform.position.z : v.z);
  }

  public BE.DefaultDict<BL.Item, BE.ItemResource> itemResource
  {
    get => this.getDefaultDict<BL.Item, BE.ItemResource>(ref this.itemResource_);
  }

  public void useItem(BL.Item item, BL.Unit unit, BattleTimeManager btm)
  {
    btm.setScheduleAction((System.Action) (() =>
    {
      int prev_hp = unit.hp;
      bool isRebirth = item.item.skill.target_type == BattleskillTargetType.dead_player_single && unit.isDead;
      this.core.useItemWith(item, unit, (Action<List<BL.Unit>>) (effectTargets =>
      {
        Debug.LogWarning((object) (" ==== useItem#effectTargets:" + (object) effectTargets + " isRebirth:" + (object) isRebirth));
        BE.UnitResource ur = this.unitResource[unit];
        Singleton<NGBattleManager>.GetInstance().battleEffects.itemFieldEffectStart(effectTargets, item, (System.Action) (() =>
        {
          if (isRebirth)
          {
            unit.rebirthBE(this);
          }
          else
          {
            if (prev_hp == unit.hp)
              return;
            ur.unitParts.dispHpNumber(prev_hp, unit.hp);
          }
        }));
      }), this.core);
    }));
  }

  public void useMagicBullet(
    BL.MagicBullet mb,
    int attack,
    BL.Unit unit,
    List<BL.Unit> targets,
    BattleTimeManager btm)
  {
    btm.setScheduleAction((System.Action) (() =>
    {
      Dictionary<BL.Unit, int> target_prev_hps = new Dictionary<BL.Unit, int>();
      foreach (BL.Unit target in targets)
        target_prev_hps.Add(target, target.hp);
      this.core.useMagicBulletWith(mb, attack, unit, targets, (Action<BL.Unit, int>) ((addUnit, unitPrevHp) =>
      {
        List<BL.Unit> list = targets.ToList<BL.Unit>();
        if (addUnit != null && !list.Contains(addUnit))
        {
          list.Add(addUnit);
          target_prev_hps.Add(addUnit, unitPrevHp);
        }
        foreach (BL.Unit key in list)
          this.unitResource[key].unitParts.dispHpNumber(target_prev_hps[key], key.hp);
        Singleton<NGBattleManager>.GetInstance().battleEffects.mbFieldEffectStart(unit, mb, targets);
      }), this.core);
    }));
  }

  public BE.DefaultDict<int, BE.SkillResource> skillResource
  {
    get => this.getDefaultDict<int, BE.SkillResource>(ref this.skillResource_);
  }

  public BE.DefaultDict<int, BE.AilmentSkillResource> ailmentSkillResource
  {
    get => this.getDefaultDict<int, BE.AilmentSkillResource>(ref this.ailmentSkillResource_);
  }

  public void useSkill(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets, BattleTimeManager btm)
  {
    btm.setScheduleAction((System.Action) (() =>
    {
      Dictionary<BL.Unit, int> target_prev_hps = new Dictionary<BL.Unit, int>();
      Dictionary<BL.Unit, bool> isRebirths = new Dictionary<BL.Unit, bool>();
      foreach (BL.Unit target in targets)
      {
        target_prev_hps.Add(target, target.hp);
        isRebirths.Add(target, skill.targetType == BattleskillTargetType.dead_player_single && target.isDead);
      }
      this.core.useSkillWith(unit, skill, targets, (Action<List<BL.Unit>, BL.Unit, int>) ((effectTargets, dispHpUnit, prevHp) =>
      {
        if (((IEnumerable<BattleskillEffect>) skill.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_heal || x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_heal || x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_lv_heal || x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_lv_heal || x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_rebirth || x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_rebirth)))
        {
          foreach (BL.Unit effectTarget in effectTargets)
          {
            if (isRebirths[effectTarget])
              effectTarget.rebirthBE(this);
            else
              this.unitResource[effectTarget].unitParts.dispHpNumber(target_prev_hps[effectTarget], effectTarget.hp);
          }
          if (dispHpUnit != null && !effectTargets.Contains(dispHpUnit))
            this.unitResource[dispHpUnit].unitParts.dispHpNumber(prevHp, dispHpUnit.hp);
        }
        Singleton<NGBattleManager>.GetInstance().battleEffects.skillFieldEffectStart(unit, skill, effectTargets);
      }), this.core);
    }));
  }

  public BE.DefaultDict<BL.Unit, BE.UnitResource> unitResource
  {
    get => this.getDefaultDict<BL.Unit, BE.UnitResource>(ref this.unitResource_);
  }

  public void rebirthUnits(List<BL.Unit> units, BattleTimeManager btm)
  {
    btm.setScheduleAction((System.Action) (() =>
    {
      foreach (BL.Unit unit in units)
      {
        unit.rebirth(this.core);
        unit.rebirthBE(this);
      }
    }));
  }

  public void setCurrentUnit_(BL.Unit unit)
  {
    this.core.setCurrentUnitWith(unit, (Action<BL.UnitPosition>) (up =>
    {
      if (up == null || this.core.phaseState.state == BL.Phase.pvp_disposition)
        return;
      up.cancelMove(this);
    }));
  }

  public void pushWaveStageDatas()
  {
    this.pushWaveEnemies();
    this.pushWaveDropData();
  }

  private void pushWaveEnemies() => this.waveEnemiesStack.Push(this.core.enemyUnits.value);

  private void pushWaveDropData()
  {
    List<Tuple<BL.DropData, int>> tupleList = new List<Tuple<BL.DropData, int>>();
    for (int row = 0; row < this.core.getFieldHeight(); ++row)
    {
      for (int column = 0; column < this.core.getFieldWidth(); ++column)
      {
        BL.Panel fieldPanel = this.core.getFieldPanel(row, column);
        if (fieldPanel.hasEvent && fieldPanel.fieldEvent.isCompleted)
          tupleList.Add(new Tuple<BL.DropData, int>(fieldPanel.fieldEvent, fieldPanel.fieldEventId));
      }
    }
    this.waveDropStack.Push(tupleList);
  }

  public BE.DefaultDict<BL.Weapon, BE.WeaponResource> weaponResource
  {
    get => this.getDefaultDict<BL.Weapon, BE.WeaponResource>(ref this.weaponResource_);
  }

  [Serializable]
  public class DropDataResource
  {
    [NonSerialized]
    private GameObject mPrefab;

    public GameObject prefab
    {
      get => this.mPrefab;
      set => this.mPrefab = value;
    }
  }

  public class DefaultDict<TKey, TValue> where TValue : new()
  {
    private Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

    public bool ContainsKey(TKey key) => this.dict.ContainsKey(key);

    public TValue this[TKey key]
    {
      get
      {
        TValue obj1;
        if (this.dict.TryGetValue(key, out obj1))
          return obj1;
        TValue obj2 = new TValue();
        this.dict.Add(key, obj2);
        return obj2;
      }
      set => this.dict[key] = value;
    }

    public void cleanup() => this.dict.Clear();
  }

  public class PanelResource
  {
    private GameObject mGameObject;

    public GameObject gameObject
    {
      get => this.mGameObject;
      set => this.mGameObject = value;
    }
  }

  public class StageResource
  {
    private GameObject mPrefab;

    public GameObject prefab
    {
      get => this.mPrefab;
      set => this.mPrefab = value;
    }
  }

  public class ItemResource
  {
    [NonSerialized]
    private GameObject mTargetEffectPrefab;

    public GameObject targetEffectPrefab
    {
      get => this.mTargetEffectPrefab;
      set => this.mTargetEffectPrefab = value;
    }
  }

  public class SkillResource
  {
    [NonSerialized]
    private GameObject mEffectPrefab;
    [NonSerialized]
    private GameObject mTargetEffectPrefab;

    public GameObject effectPrefab
    {
      get => this.mEffectPrefab;
      set => this.mEffectPrefab = value;
    }

    public GameObject targetEffectPrefab
    {
      get => this.mTargetEffectPrefab;
      set => this.mTargetEffectPrefab = value;
    }
  }

  public class AilmentSkillResource
  {
    [NonSerialized]
    private GameObject mTargetEffectPrefab;

    public GameObject targetEffectPrefab
    {
      get => this.mTargetEffectPrefab;
      set => this.mTargetEffectPrefab = value;
    }
  }

  public class UnitResource
  {
    [NonSerialized]
    private GameObject mGameObject;
    [NonSerialized]
    private GameObject mPrefab;
    [NonSerialized]
    private GameObject mEquipPrefab_a;
    [NonSerialized]
    private GameObject mEquipPrefab_b;
    [NonSerialized]
    private GameObject mBikePrefab;
    [NonSerialized]
    private Material mFaceMaterial;
    [NonSerialized]
    private Material[] mCompleteMaterials;
    [NonSerialized]
    private Material[] mCompleteEquipAMaterials;
    [NonSerialized]
    private Material[] mCompleteEquipBMaterials;
    [NonSerialized]
    private Material[] mCompleteBikeMaterials;
    [NonSerialized]
    private BattleUnitParts mUnitParts;

    public GameObject gameObject
    {
      get => this.mGameObject;
      set => this.mGameObject = value;
    }

    public GameObject prefab
    {
      get => this.mPrefab;
      set => this.mPrefab = value;
    }

    public GameObject equipPrefab_a
    {
      get => this.mEquipPrefab_a;
      set => this.mEquipPrefab_a = value;
    }

    public GameObject equipPrefab_b
    {
      get => this.mEquipPrefab_b;
      set => this.mEquipPrefab_b = value;
    }

    public GameObject bikePrefab
    {
      get => this.mBikePrefab;
      set => this.mBikePrefab = value;
    }

    public Material faceMaterial
    {
      get => this.mFaceMaterial;
      set => this.mFaceMaterial = value;
    }

    public Material[] completeMaterials
    {
      get => this.mCompleteMaterials;
      set => this.mCompleteMaterials = value;
    }

    public Material[] completeBikeMaterials
    {
      get => this.mCompleteBikeMaterials;
      set => this.mCompleteBikeMaterials = value;
    }

    public Material[] completeEquipAMaterials
    {
      get => this.mCompleteEquipAMaterials;
      set => this.mCompleteEquipAMaterials = value;
    }

    public Material[] completeEquipBMaterials
    {
      get => this.mCompleteEquipBMaterials;
      set => this.mCompleteEquipBMaterials = value;
    }

    public BattleUnitParts unitParts
    {
      get
      {
        if (Object.op_Equality((Object) this.mUnitParts, (Object) null))
          this.mUnitParts = this.gameObject.GetComponent<BattleUnitParts>();
        return this.mUnitParts;
      }
    }

    public void cleanup()
    {
      this.mGameObject = (GameObject) null;
      this.mPrefab = (GameObject) null;
      this.mEquipPrefab_a = (GameObject) null;
      this.mEquipPrefab_b = (GameObject) null;
      this.mBikePrefab = (GameObject) null;
      this.mFaceMaterial = (Material) null;
      this.mCompleteMaterials = (Material[]) null;
      this.mCompleteEquipAMaterials = (Material[]) null;
      this.mCompleteEquipBMaterials = (Material[]) null;
      this.mCompleteBikeMaterials = (Material[]) null;
      this.mUnitParts = (BattleUnitParts) null;
    }
  }

  public class WeaponResource
  {
    [NonSerialized]
    private GameObject mPrefab;

    public GameObject prefab
    {
      get => this.mPrefab;
      set => this.mPrefab = value;
    }
  }
}
