// Decompiled with JetBrains decompiler
// Type: Battle01GrandStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private BL.BattleModified<BL.ClassValue<BL.Panel>> modified;

  private string numberString(int v) => v >= 0 ? "+" + (object) v : string.Empty + (object) v;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01GrandStatus.\u003ConInitAsync\u003Ec__Iterator702()
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
  }
}
