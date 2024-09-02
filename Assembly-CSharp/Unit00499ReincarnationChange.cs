// Decompiled with JetBrains decompiler
// Type: Unit00499ReincarnationChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Unit00499ReincarnationChange : NGMenuBase
{
  private const int PanelDepthFront = 10;
  private const int PanelDepthBack = 9;
  public Unit00499UnitStatus AfterUnit;
  public Unit00499UnitStatus RecordUnit;
  public UIPanel after;
  public UIPanel record;
  public Animator animator;
  private System.Action afterAction;
  private System.Action recordAction;
  [SerializeField]
  private UIButton afterChangeBtn;
  [SerializeField]
  private UIButton recordChangeBtn;
  private bool buttonEnable;

  public void SetActiveChangeButton(bool flag)
  {
    this.animator.gameObject.SetActive(false);
    this.animator.enabled = flag;
    this.afterChangeBtn.isEnabled = flag;
    this.recordChangeBtn.isEnabled = flag;
    this.buttonEnable = flag;
    this.animator.gameObject.SetActive(true);
  }

  public void SetAction(System.Action afterAction, System.Action recordAction)
  {
    this.afterAction = afterAction;
    this.recordAction = recordAction;
  }

  public void IbtnChangeRecord()
  {
    if (!this.buttonEnable)
      return;
    this.recordAction();
    this.animator.SetTrigger("is_ReinforceMemory_up");
  }

  public void IbtnChangeAfter()
  {
    if (!this.buttonEnable)
      return;
    this.afterAction();
    this.animator.SetTrigger("is_After_up");
  }

  public void AfterFront()
  {
    this.after.depth = 10;
    this.record.depth = 9;
  }

  public void RecordFront()
  {
    this.after.depth = 9;
    this.record.depth = 10;
  }
}
