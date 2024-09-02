// Decompiled with JetBrains decompiler
// Type: Unit00422Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00422Menu : BackButtonMenuBase
{
  private const int CHARACTER_ID_MAX = 7000;
  [SerializeField]
  protected UILabel TxtCharaname01;
  [SerializeField]
  protected UILabel TxtCharaname02;
  [SerializeField]
  protected UILabel TxtLv;
  [SerializeField]
  protected UILabel TxtOwn;
  [SerializeField]
  protected UILabel TxtOwnnumber;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtLvIcon;
  [SerializeField]
  public NGxScroll scroll;
  [SerializeField]
  protected NGxMaskSprite mask_Chara;
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UISprite lpivot_Friendly_Gauge;
  [SerializeField]
  private List<Unit00422Menu.CharacterIntimate> characterIntimates = new List<Unit00422Menu.CharacterIntimate>();
  [SerializeField]
  private List<UnitIcon> allUnitIcon = new List<UnitIcon>();

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00422Menu.\u003CInit\u003Ec__Iterator2BF()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitPlayer(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00422Menu.\u003CInitPlayer\u003Ec__Iterator2C0()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void SetBottomMode(UnitIcon icon)
  {
    icon.BottomModeValue = UnitIcon.BottomMode.Friendly;
  }

  protected virtual void SetPosessionText(int value, int max)
  {
    this.TxtOwnnumber.SetTextLocalize(string.Format("{0}/{1}", (object) value, (object) max));
  }

  private void GenerateCharacterIntimate(PlayerUnit playerUnit)
  {
    int characterUnitCharacter = playerUnit.unit.character_UnitCharacter;
    foreach (PlayerCharacterIntimate pci in SMManager.Get<PlayerCharacterIntimate[]>())
    {
      if (characterUnitCharacter == pci._character || characterUnitCharacter == pci._target_character)
        this.characterIntimates.Add(new Unit00422Menu.CharacterIntimate(characterUnitCharacter, pci));
    }
    this.characterIntimates = this.characterIntimates.OrderBy<Unit00422Menu.CharacterIntimate, int>((Func<Unit00422Menu.CharacterIntimate, int>) (x => x.unit.character.ID)).ToList<Unit00422Menu.CharacterIntimate>();
  }

  [DebuggerHidden]
  private IEnumerator SetMainCharacter(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00422Menu.\u003CSetMainCharacter\u003Ec__Iterator2C1()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateSelectCharacter(UnitIconBase unitIcon)
  {
    this.TxtCharaname02.SetTextLocalize(unitIcon.Unit.character.name);
    this.link_Character.sprite2D = unitIcon.icon.sprite2D;
    Unit00422Menu.CharacterIntimate characterIntimate = this.characterIntimates.Where<Unit00422Menu.CharacterIntimate>((Func<Unit00422Menu.CharacterIntimate, bool>) (x => x.unit.ID == unitIcon.Unit.ID)).First<Unit00422Menu.CharacterIntimate>();
    if (characterIntimate.level == characterIntimate.max_level)
      this.TxtLv.SetTextLocalize(Consts.GetInstance().UNIT_00422_MAX.ToConverter());
    else
      this.TxtLv.SetTextLocalize(characterIntimate.level.ToString().ToConverter());
    this.TxtLvIcon.SetText(characterIntimate.level.ToString().ToConverter());
    this.lpivot_Friendly_Gauge.width = characterIntimate.gauge;
    this.allUnitIcon.ForEach((Action<UnitIcon>) (icon => this.SetFriendlyEffect((UnitIconBase) icon, false)));
    this.SetFriendlyEffect(unitIcon, true);
  }

  protected virtual void SetFriendlyEffect(UnitIconBase icon, bool value)
  {
    icon.SetFriendlyEffect(value);
  }

  private class CharacterIntimate
  {
    private const int GAUGE_MAX = 194;
    public UnitUnit unit;
    public int exp;
    public int exp_next;
    public int level;
    public int max_level;
    public int total_exp;

    public CharacterIntimate(int characterId, PlayerCharacterIntimate pci)
    {
      UnitUnit unitUnit = (UnitUnit) null;
      if (pci.character.ID == characterId)
        unitUnit = pci.target_character.GetDefaultUnitUnit().resource_reference_unit_id;
      else if (pci.target_character.ID == characterId)
        unitUnit = pci.character.GetDefaultUnitUnit().resource_reference_unit_id;
      this.unit = unitUnit;
      this.exp = pci.exp;
      this.exp_next = pci.exp_next;
      this.level = pci.level;
      this.max_level = pci.max_level;
      this.total_exp = pci.total_exp;
    }

    public float percentageNextLevel
    {
      get
      {
        if (this.level >= this.max_level)
          return 100f;
        if (this.exp < 0)
          return 0.0f;
        return this.exp_next < 0 ? 100f : (float) this.exp * 100f / (float) (this.exp + this.exp_next);
      }
    }

    public int gauge
    {
      get
      {
        if ((double) this.percentageNextLevel >= 100.0)
          return 194;
        return (double) this.percentageNextLevel <= 0.0 ? 0 : (int) (194.0 * (double) this.percentageNextLevel / 100.0);
      }
    }
  }
}
