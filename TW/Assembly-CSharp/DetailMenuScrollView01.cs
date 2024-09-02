// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView01
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView01 : DetailMenuScrollViewBase
{
  [SerializeField]
  protected UISprite lvGauge;
  [SerializeField]
  protected UISprite hpGauge;
  [SerializeField]
  protected GameObject[] slc_LBicon_None;
  [SerializeField]
  protected GameObject[] slc_LBicon_Blue;
  [SerializeField]
  protected GameObject slc_Limitbreak;
  [SerializeField]
  protected UILabel txt_Attack;
  [SerializeField]
  protected UILabel txt_Cost;
  [SerializeField]
  protected UILabel txt_Critical;
  [SerializeField]
  protected UILabel txt_Defense;
  [SerializeField]
  protected UILabel txt_Dexterity;
  [SerializeField]
  protected UILabel txt_Evasion;
  [SerializeField]
  protected UILabel txt_Fighting;
  [SerializeField]
  protected UILabel txt_Matk;
  [SerializeField]
  protected UILabel txt_Mdef;
  [SerializeField]
  protected UILabel txt_Movement;
  [SerializeField]
  protected UILabel txt_Lv;
  [SerializeField]
  protected UILabel txt_Lvmax;
  [SerializeField]
  protected UILabel txt_Hp;
  [SerializeField]
  protected UILabel txt_Hpmax;
  [SerializeField]
  protected GameObject slc_maxStarHp;
  [SerializeField]
  protected UILabel TxtJobname;
  [SerializeField]
  protected UILabel TxtPrincesstype;
  [SerializeField]
  private GameObject dir_3DModel;
  [SerializeField]
  private GameObject ui3DModelLoadDummy;
  private UI3DModel ui_3DModel;
  private GameObject unitmodel;

  public GameObject Dir3DModel => this.dir_3DModel;

  public UI3DModel UI3DModel => this.ui_3DModel;

  public UITexture UI3DModelTexture => this.ui_3DModel.uiTexture;

  public override bool Init(PlayerUnit playerUnit)
  {
    ((Component) this).gameObject.SetActive(true);
    Func<int, int, float> func = (Func<int, int, float>) ((val, max) => val > 0 ? (float) val / (float) max : 0.0f);
    int num1 = playerUnit.exp_next + playerUnit.exp - 1;
    int num2 = playerUnit.exp;
    if (num2 > num1)
      num2 = num1;
    this.lvGauge.width = (int) ((double) this.lvGauge.width * (double) func(num2, num1));
    Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(playerUnit);
    this.setText(this.txt_Lv, playerUnit.level);
    this.txt_Lvmax.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_DETAIL_MAX, (IDictionary) new Hashtable()
    {
      {
        (object) "max",
        (object) playerUnit.max_level
      }
    }));
    this.setText(this.txt_Hp, nonBattleParameter.Hp);
    this.txt_Hpmax.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_DETAIL_MAX, (IDictionary) new Hashtable()
    {
      {
        (object) "max",
        (object) nonBattleParameter.Hp
      }
    }));
    this.slc_maxStarHp.SetActive(playerUnit.hp.is_max);
    this.setText(this.txt_Cost, playerUnit.unit.cost);
    this.setText(this.txt_Movement, nonBattleParameter.Move);
    this.setText(this.txt_Attack, nonBattleParameter.PhysicalAttack);
    this.setText(this.txt_Defense, nonBattleParameter.PhysicalDefense);
    this.setText(this.txt_Matk, nonBattleParameter.MagicAttack);
    this.setText(this.txt_Mdef, nonBattleParameter.MagicDefense);
    this.setText(this.txt_Dexterity, nonBattleParameter.Hit);
    this.setText(this.txt_Critical, nonBattleParameter.Critical);
    this.setText(this.txt_Evasion, nonBattleParameter.Evasion);
    this.setText(this.txt_Fighting, nonBattleParameter.Combat);
    this.TxtJobname.SetTextLocalize(playerUnit.unit.job.name);
    this.TxtPrincesstype.SetTextLocalize(playerUnit.unit_type.name);
    if (!this.isEarthMode)
      this.setBicon(playerUnit.breakthrough_count, playerUnit.unit.breakthrough_limit);
    return true;
  }

  [DebuggerHidden]
  public override IEnumerator setModel(
    PlayerUnit playerUnit,
    GameObject modelPrefab,
    Vector3 modelPos,
    bool light,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenuScrollView01.\u003CsetModel\u003Ec__IteratorB0A()
    {
      modelPrefab = modelPrefab,
      light = light,
      modelPos = modelPos,
      playerUnit = playerUnit,
      action = action,
      \u003C\u0024\u003EmodelPrefab = modelPrefab,
      \u003C\u0024\u003Elight = light,
      \u003C\u0024\u003EmodelPos = modelPos,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  public void cacheModel() => this.unitmodel = this.ui_3DModel.model_creater_.BaseModel;

  private void setBicon(int count, int max)
  {
    for (int index = 0; index < this.slc_LBicon_None.Length; ++index)
    {
      this.slc_LBicon_None[index].SetActive(false);
      this.slc_LBicon_Blue[index].SetActive(false);
      if (index < max)
        this.slc_LBicon_None[index].SetActive(true);
    }
    for (int index = 0; index < max; ++index)
    {
      this.slc_LBicon_None[index].SetActive(index >= count);
      this.slc_LBicon_Blue[index].SetActive(index < count);
    }
    if (max != 0)
      return;
    this.slc_Limitbreak.SetActive(false);
  }
}
