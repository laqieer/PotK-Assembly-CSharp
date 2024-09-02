// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatusDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Battle02UIPlayerStatusDetail : Battle02MenuBase
{
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UILabel txt_CharaName_18;
  [SerializeField]
  protected UILabel txt_Lv_22;
  [SerializeField]
  protected UI2DSprite link_SPAttack1;
  [SerializeField]
  protected UI2DSprite link_SPAttack2;
  [SerializeField]
  protected UILabel txt_Movement_22;
  [SerializeField]
  protected UILabel txt_Rangement_22;
  public GameObject label_Done;
  public GameObject label_Standby;
  public GameObject label_Dead;
  public GameObject spa_icon_prefab;
  [SerializeField]
  protected Transform[] spaTypeIconParent;
  private GameObject[] spaTypeIcon = new GameObject[2];

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    UI2DSprite componentInChildren2 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions(componentInChildren2.width, componentInChildren2.height);
    componentInChildren1.depth = NGUITools.CalculateNextDepth(((Component) trans).gameObject);
    return icon;
  }

  private string getAttackRange(BL.Unit v)
  {
    return string.Format("{0} - {1}", (object) ((IEnumerable<int>) v.attackRange).Min(), (object) ((IEnumerable<int>) v.attackRange).Max());
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle02UIPlayerStatusDetail.\u003CStart_Battle\u003Ec__Iterator886 battleCIterator886 = new Battle02UIPlayerStatusDetail.\u003CStart_Battle\u003Ec__Iterator886();
    return (IEnumerator) battleCIterator886;
  }

  protected override void LateUpdate_Battle()
  {
  }

  public override void UpdateData()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit unit = this.modified.value;
    this.setText(this.txt_CharaName_18, unit.unit.name);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(unit);
    this.setColordText(this.txt_Movement_22, battleParameter.Move, battleParameter.MoveIncr);
    this.setText(this.txt_Rangement_22, this.getAttackRange(unit));
    this.CreateUnitSprite(this.link_Character);
    UnitFamily[] specialAttackTargets = unit.playerUnit.equippedWeaponGearOrInitial.SpecialAttackTargets;
    for (int index = 0; index < specialAttackTargets.Length && this.spaTypeIconParent.Length > index; ++index)
    {
      this.spaTypeIcon[index] = this.createIcon(this.spa_icon_prefab, this.spaTypeIconParent[index]);
      this.spaTypeIcon[index].GetComponent<SPAtkTypeIcon>().InitKindId(specialAttackTargets[index]);
    }
    ((Behaviour) ((Component) this.spaTypeIconParent[0]).gameObject.GetComponent<UI2DSprite>()).enabled = false;
    ((Behaviour) ((Component) this.spaTypeIconParent[1]).gameObject.GetComponent<UI2DSprite>()).enabled = false;
    if (Singleton<NGBattleManager>.GetInstance().environment.core.isCompleted(unit))
    {
      if (unit.isDead)
      {
        this.label_Done.SetActive(false);
        this.label_Standby.SetActive(false);
        this.label_Dead.SetActive(true);
      }
      else
      {
        this.label_Done.SetActive(true);
        this.label_Standby.SetActive(false);
        this.label_Dead.SetActive(false);
      }
    }
    else
    {
      this.label_Done.SetActive(false);
      this.label_Standby.SetActive(true);
      this.label_Dead.SetActive(false);
    }
  }

  public override void onBackButton()
  {
  }
}
