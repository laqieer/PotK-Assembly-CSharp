// Decompiled with JetBrains decompiler
// Type: NGOverlapScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIPanel))]
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Overlap Scroll View")]
public class NGOverlapScrollView : UIScrollView
{
  private UIScrollView overlapScrollView;
  public UIScrollView.Movement thisMovement = UIScrollView.Movement.Vertical;
  public UIScrollView.Movement? moveMode;
  public UIScrollView.OnDragFinished onOverlapDragFinished;

  protected override void Start()
  {
    base.Start();
    this.movement = UIScrollView.Movement.Unrestricted;
    this.onDragFinished = (UIScrollView.OnDragFinished) (() =>
    {
      if (this.moveMode.HasValue)
      {
        if (this.onOverlapDragFinished != null && this.moveMode.Value == this.thisMovement)
          this.onOverlapDragFinished();
        if (Object.op_Inequality((Object) this.overlapScrollView, (Object) null) && this.overlapScrollView.onDragFinished != null && this.moveMode.Value == this.overlapScrollView.movement)
          this.overlapScrollView.onDragFinished();
      }
      this.moveMode = new UIScrollView.Movement?();
    });
  }

  public void SetOverlapScrollView(UIScrollView scrollView) => this.overlapScrollView = scrollView;

  public override void MoveRelative(Vector3 relative)
  {
    if (!this.moveMode.HasValue)
    {
      if ((double) Mathf.Abs(relative.x) > (double) Mathf.Abs(relative.y))
        this.moveMode = new UIScrollView.Movement?(UIScrollView.Movement.Horizontal);
      else if ((double) Mathf.Abs(relative.x) < (double) Mathf.Abs(relative.y))
        this.moveMode = new UIScrollView.Movement?(UIScrollView.Movement.Vertical);
    }
    if (!this.moveMode.HasValue)
      return;
    if (this.moveMode.Value == UIScrollView.Movement.Vertical)
      relative.x = 0.0f;
    if (this.moveMode.Value == UIScrollView.Movement.Horizontal)
      relative.y = 0.0f;
    Vector3 relative1;
    // ISSUE: explicit constructor call
    ((Vector3) ref relative1).\u002Ector(relative.x, relative.y, relative.z);
    if (this.overlapScrollView.movement == UIScrollView.Movement.Vertical)
      relative1.x = 0.0f;
    if (this.overlapScrollView.movement == UIScrollView.Movement.Horizontal)
      relative1.y = 0.0f;
    this.overlapScrollView.MoveRelative(relative1);
    if (this.thisMovement == UIScrollView.Movement.Vertical)
      relative.x = 0.0f;
    else if (this.thisMovement == UIScrollView.Movement.Horizontal)
      relative.y = 0.0f;
    if (!this.shouldMoveHorizontally)
      relative.x = 0.0f;
    if (!this.shouldMoveVertically)
      relative.y = 0.0f;
    base.MoveRelative(relative);
  }
}
