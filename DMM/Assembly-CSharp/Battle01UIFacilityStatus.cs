// Decompiled with JetBrains decompiler
// Type: Battle01UIFacilityStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Battle01UIFacilityStatus : NGBattleMenuBase
{
  public NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected UI2DSprite attribution;
  [SerializeField]
  protected UIWidget thumb_container;
  [SerializeField]
  protected Transform passage;
  [SerializeField]
  protected Transform destruction;
  [SerializeField]
  protected Transform visibility;
  [SerializeField]
  protected int depthSkillTargetParent = 11;
  [SerializeField]
  protected Transform skillTargetParent1;
  [SerializeField]
  protected Transform skillTargetParent2;
  [SerializeField]
  protected GameObject node_without_hp_gauge;
  [SerializeField]
  protected GameObject node_hp_gauge;
  [SerializeField]
  protected GameObject node_dir_base_own;
  [SerializeField]
  protected GameObject node_dir_base_enemy;
  [SerializeField]
  protected UILabel txt_name;
  [SerializeField]
  protected UILabel txt_description;
  [SerializeField]
  protected UILabel txt_Hp_num_numerator;
  [SerializeField]
  protected UILabel txt_Hp_num_denominator;
  [SerializeField]
  protected UILabel txt_LV_num;
  [SerializeField]
  protected UILabel txt_DEF_num;
  [SerializeField]
  protected UILabel txt_INT_num;
  private BL.BattleModified<BL.Unit> modified;
  private FacilityIcon facilityIcon;
  private GameObject skillTgtIcon1;
  private GameObject skillTgtIcon2;
  private bool isSetHp;

  private void Awake()
  {
    this.attribution.enabled = false;
    foreach (UIWidget componentsInChild in this.gameObject.GetComponentsInChildren<UIWidget>(true))
    {
      if ((Object) componentsInChild.GetComponent<UIButton>() == (Object) null)
        componentsInChild.alpha = 0.0f;
    }
  }

  public override IEnumerator onInitAsync()
  {
    Future<GameObject> prefabF = new ResourceObject("Prefabs/FacilityIcon/dir_facility_thumb").Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.facilityIcon = prefabF.Result.Clone(this.thumb_container.gameObject.transform).GetComponent<FacilityIcon>();
    NGUITools.AdjustDepth(this.facilityIcon.gameObject, this.thumb_container.depth);
    this.facilityIcon.SetBasedOnHeight(this.thumb_container.height);
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    BoxCollider componentInChildren2 = trans.GetComponentInChildren<BoxCollider>();
    if (!((Object) componentInChildren1 != (Object) null) || !((Object) componentInChildren2 != (Object) null))
      return gameObject;
    componentInChildren1.SetDimensions((int) componentInChildren2.size.x, (int) componentInChildren2.size.y);
    componentInChildren1.depth += 150;
    return gameObject;
  }

  private IEnumerator doSetIcon(BL.Unit unit)
  {
    IEnumerator e = this.facilityIcon.SetUnit(unit.playerUnit, false, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.attribution.sprite2D = GuildUtil.LoadKindSprite((FacilityCategory) unit.unit.facility.category_id, unit.GetElement());
    this.attribution.enabled = true;
    if (unit.playerUnit.skills.Length != 0)
    {
      BattleskillSkill skill = unit.playerUnit.skills[0].skill;
      if ((Object) this.skillTgtIcon1 == (Object) null && (Object) this.skillTgtIcon2 == (Object) null)
      {
        Future<GameObject> skillTargetPrefabF = Res.Icons.SkillGenreIcon.Load<GameObject>();
        e = skillTargetPrefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        GameObject result = skillTargetPrefabF.Result;
        this.skillTgtIcon1 = this.createIcon(result, this.skillTargetParent1);
        this.skillTgtIcon2 = this.createIcon(result, this.skillTargetParent2);
        skillTargetPrefabF = (Future<GameObject>) null;
      }
      this.skillTargetParent1.gameObject.SetActive(true);
      this.skillTargetParent2.gameObject.SetActive(true);
      this.skillTgtIcon1.GetComponent<SkillGenreIcon>().Init(skill.genre1);
      this.skillTgtIcon2.GetComponent<SkillGenreIcon>().Init(skill.genre2);
      NGUITools.AdjustDepth(this.skillTgtIcon1, this.depthSkillTargetParent);
      NGUITools.AdjustDepth(this.skillTgtIcon2, this.depthSkillTargetParent);
      skill = (BattleskillSkill) null;
    }
    else
    {
      this.skillTargetParent1.gameObject.SetActive(false);
      this.skillTargetParent2.gameObject.SetActive(false);
    }
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null)
      return;
    bool flag = this.modified.isChangedOnce();
    if (flag)
    {
      BL.Unit unit = this.modified.value;
      Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit((BL.ISkillEffectListUnit) unit);
      this.StartCoroutine(this.doSetIcon(unit));
      this.setText(this.txt_name, unit.unit.name);
      this.setText(this.txt_description, unit.unit.description);
      this.setText(this.txt_LV_num, unit.lv);
      this.txt_Hp_num_denominator.SetTextLocalize("/" + battleParameter.Hp.ToString());
      this.setText(this.txt_DEF_num, battleParameter.PhysicalDefense);
      this.setText(this.txt_INT_num, battleParameter.MagicDefense);
      foreach (UIWidget componentsInChild in this.gameObject.GetComponentsInChildren<UIWidget>(true))
      {
        if ((double) componentsInChild.alpha == 0.0 && (Object) componentsInChild.GetComponent<UIButton>() == (Object) null)
          componentsInChild.alpha = 1f;
      }
    }
    if (this.battleManager.isBattleEnable)
    {
      if (!flag && !this.isSetHp)
        return;
      BL.Unit unit = this.modified.value;
      Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit((BL.ISkillEffectListUnit) unit);
      this.hpGauge.setValue(unit.hp, battleParameter.Hp);
      this.setText(this.txt_Hp_num_numerator, unit.hp);
      this.isSetHp = false;
    }
    else
    {
      if (!flag)
        return;
      this.isSetHp = true;
    }
  }

  public void setUnit(BL.Unit unit)
  {
    this.hpGauge.setValue(unit.hp, unit.parameter.Hp, false);
    this.modified = BL.Observe<BL.Unit>(unit);
    bool isEnemy = unit.playerUnit.is_enemy;
    this.node_dir_base_own.SetActive(!isEnemy);
    this.node_dir_base_enemy.SetActive(isEnemy);
    this.setIconOnOff(this.passage, unit.isPutOn);
    this.setIconOnOff(this.destruction, unit.isAttackTarget);
    this.setIconOnOff(this.visibility, unit.isView);
  }

  private void setIconOnOff(Transform parent, bool on)
  {
    GameObject gameObject1 = (GameObject) null;
    GameObject gameObject2 = (GameObject) null;
    foreach (Component component in parent)
    {
      GameObject gameObject3 = component.gameObject;
      if (gameObject3.name.LastIndexOf("_on") != -1)
        gameObject1 = gameObject3;
      else if (gameObject3.name.LastIndexOf("_off") != -1)
        gameObject2 = gameObject3;
      if ((Object) gameObject1 != (Object) null)
      {
        if ((Object) gameObject2 != (Object) null)
          break;
      }
    }
    if ((Object) gameObject1 != (Object) null)
      gameObject1.SetActive(on);
    if (!((Object) gameObject2 != (Object) null))
      return;
    gameObject2.SetActive(!on);
  }

  public BL.Unit getUnit() => this.modified.value;
}
