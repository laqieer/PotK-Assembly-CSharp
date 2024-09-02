// Decompiled with JetBrains decompiler
// Type: Unit00498Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00498Menu : BackButtonMenuBase
{
  public GameObject unitTexture;
  [SerializeField]
  private UILabel TxtCharaName;
  public UILabel jobNameLabel;
  public UILabel maxLevelLabel;
  public GameObject growthParameter;
  [SerializeField]
  private GameObject DirAnimEvolution;
  [SerializeField]
  private GameObject DirAnimRevival;
  [SerializeField]
  private GameObject DirMove;
  [SerializeField]
  private UILabel TxtMoveBefore;
  [SerializeField]
  private UILabel TxtMoveAfter;
  [SerializeField]
  private UILabel TxtNoChange;
  [SerializeField]
  private GameObject MoveBefore;
  [SerializeField]
  private GameObject MoveAfter;
  [SerializeField]
  private GameObject SlcArrow;
  [SerializeField]
  private GameObject NoChange;
  private NGSoundManager sm;

  private void OnDisable()
  {
    if (!Object.op_Inequality((Object) this.sm, (Object) null))
      return;
    this.sm.stopVoice();
  }

  public void onTouchPanel()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.onTouchPanel();

  private void SetMaxLv(int beforeLv, int afterLv)
  {
    this.maxLevelLabel.SetTextLocalize(afterLv);
    this.maxLevelLabel.color = beforeLv >= afterLv ? Color.white : Color.yellow;
  }

  private void SetMovement(int beforeMovement, int afterMovement)
  {
    if (beforeMovement != afterMovement)
    {
      this.MoveBefore.SetActive(true);
      this.MoveAfter.SetActive(true);
      this.SlcArrow.SetActive(true);
      this.NoChange.SetActive(false);
      this.TxtMoveBefore.SetTextLocalize(beforeMovement);
      this.TxtMoveAfter.SetTextLocalize(afterMovement);
    }
    else
    {
      this.MoveBefore.SetActive(false);
      this.MoveAfter.SetActive(false);
      this.SlcArrow.SetActive(false);
      this.NoChange.SetActive(true);
      this.TxtNoChange.SetTextLocalize(afterMovement);
    }
  }

  [DebuggerHidden]
  private IEnumerator SetUnitTexture(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00498Menu.\u003CSetUnitTexture\u003Ec__Iterator2EB()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator setCharacter(
    PlayerUnit beforeUnit,
    PlayerUnit afterUnit,
    Unit00499Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00498Menu.\u003CsetCharacter\u003Ec__Iterator2EC()
    {
      afterUnit = afterUnit,
      mode = mode,
      beforeUnit = beforeUnit,
      \u003C\u0024\u003EafterUnit = afterUnit,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EbeforeUnit = beforeUnit,
      \u003C\u003Ef__this = this
    };
  }
}
