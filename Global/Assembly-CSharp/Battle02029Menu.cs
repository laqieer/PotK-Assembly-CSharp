// Decompiled with JetBrains decompiler
// Type: Battle02029Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle02029Menu : NGMenuBase
{
  [SerializeField]
  protected UI2DSprite srcSkill;
  [SerializeField]
  protected UI2DSprite srcSkillBefore;
  [SerializeField]
  protected UILabel txtSkillName;
  [SerializeField]
  protected UILabel txtSkillNameBefore;
  [SerializeField]
  protected UILabel txtSkillDescription;
  [SerializeField]
  protected UILabel txtSkillDescriptionBefore;
  [SerializeField]
  protected GameObject charaParent;
  [SerializeField]
  protected UILabel txtCharacterName;
  [SerializeField]
  private UISprite slcNewSkillTxt;
  [SerializeField]
  private GameObject skillIcon;
  [SerializeField]
  private GameObject skillIconBefore;
  [SerializeField]
  private GameObject skillIconBase;
  [SerializeField]
  private UIWidget elementIconParent;
  [SerializeField]
  private UIWidget elementIconParentBefore;
  private bool isSkip;
  private bool isRunning = true;
  private System.Action onCallback;
  private UITweener[] tweens;

  [DebuggerHidden]
  public IEnumerator InitForEvolution(int unit_id, int skill_id, int skill_id_before)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CInitForEvolution\u003Ec__Iterator6F2()
    {
      skill_id_before = skill_id_before,
      skill_id = skill_id,
      unit_id = unit_id,
      \u003C\u0024\u003Eskill_id_before = skill_id_before,
      \u003C\u0024\u003Eskill_id = skill_id,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(int unit_id, int skill_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CInit\u003Ec__Iterator6F3()
    {
      skill_id = skill_id,
      unit_id = unit_id,
      \u003C\u0024\u003Eskill_id = skill_id,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitLeaderSkill(int unit_id, int skill_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CInitLeaderSkill\u003Ec__Iterator6F4()
    {
      skill_id = skill_id,
      unit_id = unit_id,
      \u003C\u0024\u003Eskill_id = skill_id,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator setSkill(
    int skill_id,
    GameObject _skillIcon,
    UI2DSprite _srcSkill,
    UILabel _txtSkillName,
    UILabel _txtSkillDescription,
    UIWidget _elementIconParent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CsetSkill\u003Ec__Iterator6F5()
    {
      _skillIcon = _skillIcon,
      skill_id = skill_id,
      _srcSkill = _srcSkill,
      _elementIconParent = _elementIconParent,
      _txtSkillName = _txtSkillName,
      _txtSkillDescription = _txtSkillDescription,
      \u003C\u0024\u003E_skillIcon = _skillIcon,
      \u003C\u0024\u003Eskill_id = skill_id,
      \u003C\u0024\u003E_srcSkill = _srcSkill,
      \u003C\u0024\u003E_elementIconParent = _elementIconParent,
      \u003C\u0024\u003E_txtSkillName = _txtSkillName,
      \u003C\u0024\u003E_txtSkillDescription = _txtSkillDescription,
      \u003C\u003Ef__this = this
    };
  }

  public void SetLeaderSkill(int skill_id, UILabel _txtSkillName, UILabel _txtSkillDescription)
  {
    BattleskillSkill battleskillSkill = MasterData.BattleskillSkill[skill_id];
    if (battleskillSkill == null)
      return;
    _txtSkillName.SetTextLocalize(battleskillSkill.name);
    _txtSkillDescription.SetTextLocalize(battleskillSkill.description);
  }

  [DebuggerHidden]
  private IEnumerator Play()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CPlay\u003Ec__Iterator6F6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterViewUnit(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CSetCharacterViewUnit\u003Ec__Iterator6F7()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnScreen()
  {
    if (this.isRunning && !this.isSkip)
      this.isSkip = true;
    else
      this.StartCoroutine(this.toClose());
  }

  [DebuggerHidden]
  private IEnumerator toClose()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02029Menu.\u003CtoClose\u003Ec__Iterator6F8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;
}
