﻿// Decompiled with JetBrains decompiler
// Type: NGOverlapScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Overlap Scroll View")]
[RequireComponent(typeof (UIPanel))]
public class NGOverlapScrollView : UIScrollView
{
  private UIScrollView overlapScrollView;
  public UIScrollView.Movement thisMovement = UIScrollView.Movement.Vertical;
  public UIScrollView.Movement? moveMode;
  public UIScrollView.OnDragFinished onOverlapDragFinished;

  public bool canThisMoveHorizontally => this.thisMovement == UIScrollView.Movement.Horizontal;

  public bool canThisMoveVertically => this.thisMovement == UIScrollView.Movement.Vertical;

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

  public override void SetDragAmount(float x, float y, bool updateScrollbars)
  {
    if (Object.op_Equality((Object) this.mPanel, (Object) null))
      this.mPanel = ((Component) this).GetComponent<UIPanel>();
    this.DisableSpring();
    Bounds bounds = this.bounds;
    if ((double) ((Bounds) ref bounds).min.x == (double) ((Bounds) ref bounds).max.x || (double) ((Bounds) ref bounds).min.y == (double) ((Bounds) ref bounds).max.y)
      return;
    Vector4 finalClipRegion = this.mPanel.finalClipRegion;
    float num1 = finalClipRegion.z * 0.5f;
    float num2 = finalClipRegion.w * 0.5f;
    float num3 = ((Bounds) ref bounds).min.x + num1;
    float num4 = ((Bounds) ref bounds).max.x - num1;
    float num5 = ((Bounds) ref bounds).min.y + num2;
    float num6 = ((Bounds) ref bounds).max.y - num2;
    Vector3 localPosition = this.mTrans.localPosition;
    localPosition.z = 0.0f;
    this.mTrans.localRotation = Quaternion.Euler(Vector3.zero);
    if (this.canThisMoveHorizontally)
      localPosition.y = 0.0f;
    if (this.canThisMoveVertically)
      localPosition.x = 0.0f;
    if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
    {
      num3 -= this.mPanel.clipSoftness.x;
      num4 += this.mPanel.clipSoftness.x;
      num5 -= this.mPanel.clipSoftness.y;
      num6 += this.mPanel.clipSoftness.y;
    }
    float num7 = Mathf.Lerp(num3, num4, x);
    float num8 = Mathf.Lerp(num6, num5, y);
    if (!updateScrollbars)
    {
      if (this.canThisMoveHorizontally)
        localPosition.x += finalClipRegion.x - num7;
      if (this.canThisMoveVertically)
        localPosition.y += finalClipRegion.y - num8;
    }
    this.mTrans.localPosition = localPosition;
    if (this.canThisMoveHorizontally)
      finalClipRegion.x = num7;
    if (this.canThisMoveVertically)
      finalClipRegion.y = num8;
    Vector4 baseClipRegion = this.mPanel.baseClipRegion;
    this.mPanel.clipOffset = new Vector2(finalClipRegion.x - baseClipRegion.x, finalClipRegion.y - baseClipRegion.y);
    if (!updateScrollbars)
      return;
    this.UpdateScrollbars(this.mDragID == -10);
  }

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
    relative.z = 0.0f;
    if (this.moveMode.Value == UIScrollView.Movement.Vertical)
      relative.x = 0.0f;
    if (this.moveMode.Value == UIScrollView.Movement.Horizontal)
      relative.y = 0.0f;
    Vector3 relative1;
    // ISSUE: explicit constructor call
    ((Vector3) ref relative1).\u002Ector(relative.x, relative.y, 0.0f);
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
