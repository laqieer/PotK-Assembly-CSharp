// Decompiled with JetBrains decompiler
// Type: Battle01GrandStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01GrandStatus : NGBattleMenuBase
{
  [SerializeField]
  private UILabel place;
  [SerializeField]
  private UILabel hit;
  [SerializeField]
  private UILabel pDefense;
  [SerializeField]
  private UILabel mDefense;
  [SerializeField]
  private UILabel stay;
  [SerializeField]
  private GameObject descriptionRoot;
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private NGTweenParts descriptionTween;
  private BL.BattleModified<BL.ClassValue<BL.Panel>> modified;

  private string numberString(int v) => v > 0 ? "+" + (object) v : string.Empty + (object) v;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01GrandStatus.\u003ConInitAsync\u003Ec__Iterator914()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void setText(UILabel label, int v) => this.setText(label, this.numberString(v));

  protected override void LateUpdate_Battle()
  {
    if (!this.modified.isChangedOnce() || this.env.core.fieldCurrent.value == null)
      return;
    BattleLandform landform = this.env.core.fieldCurrent.value.landform;
    BattleLandformIncr displayIncr = landform.GetDisplayIncr();
    this.setText(this.place, landform.name);
    this.setText(this.hit, displayIncr.hit_incr);
    this.setText(this.pDefense, displayIncr.physical_defense_incr);
    this.setText(this.mDefense, displayIncr.magic_defense_incr);
    this.setText(this.stay, displayIncr.evasion_incr);
    if (this.env.core.unitCurrent.unit == null || this.env.core.currentUnitPosition != null && !this.env.unitResource[this.env.core.currentUnitPosition.unit].unitParts.isMoving)
    {
      this.SetTextLandformDescription(landform.description);
    }
    else
    {
      if (this.env.core.currentUnitPosition == null || !this.env.unitResource[this.env.core.currentUnitPosition.unit].unitParts.isMoving)
        return;
      this.descriptionTween.isActive = false;
    }
  }

  private void SetTextLandformDescription(string descriptionText)
  {
    if (Object.op_Equality((Object) this.descriptionTween, (Object) null))
      return;
    if (string.IsNullOrEmpty(descriptionText))
    {
      this.descriptionTween.isActive = false;
    }
    else
    {
      this.setText(this.description, descriptionText);
      this.descriptionTween.isActive = true;
    }
  }
}
