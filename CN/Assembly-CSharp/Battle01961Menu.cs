// Decompiled with JetBrains decompiler
// Type: Battle01961Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01961Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtCharaname;
  [SerializeField]
  protected UILabel TxtCharaname2;
  [SerializeField]
  protected UILabel TxtConsume;
  [SerializeField]
  protected UILabel TxtCritical;
  [SerializeField]
  protected UILabel TxtHp;
  [SerializeField]
  protected UILabel TxtHp2;
  [SerializeField]
  protected UILabel TxtHpmax;
  [SerializeField]
  protected UILabel TxtHpmax2;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  protected UILabel TxtRecovery;
  [SerializeField]
  protected UILabel TxtSkillname;
  [SerializeField]
  protected UILabel TxtWeaponName;
  [SerializeField]
  private BattleHealCharacterInfoHealer healer;
  [SerializeField]
  private BattleHealCharacterInfoInjured injured;
  private Battle019_6_1_RecoveryButton rButton;

  public override void onBackButton() => this.IbtnBack();

  public void IbtnBack()
  {
    if (Object.op_Equality((Object) this.rButton, (Object) null))
    {
      Battle019_6_1_RecoveryButton[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle019_6_1_RecoveryButton>(true);
      if (componentsInChildren.Length > 0)
        this.rButton = componentsInChildren[0];
    }
    if (this.rButton.isComplited)
      return;
    this.rButton.isComplited = true;
    this.backScene();
  }

  [DebuggerHidden]
  public IEnumerator Init(BL.UnitPosition attack, BL.UnitPosition defense)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01961Menu.\u003CInit\u003Ec__Iterator827()
    {
      attack = attack,
      defense = defense,
      \u003C\u0024\u003Eattack = attack,
      \u003C\u0024\u003Edefense = defense,
      \u003C\u003Ef__this = this
    };
  }
}
