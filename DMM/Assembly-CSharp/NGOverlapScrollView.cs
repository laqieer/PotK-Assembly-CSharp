// Decompiled with JetBrains decompiler
// Type: NGOverlapScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UIPanel))]
[AddComponentMenu("NGUI/Interaction/Overlap Scroll View")]
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
        if ((Object) this.overlapScrollView != (Object) null && this.overlapScrollView.onDragFinished != null && this.moveMode.Value == this.overlapScrollView.movement)
          this.overlapScrollView.onDragFinished();
      }
      this.moveMode = new UIScrollView.Movement?();
    });
  }

  public void SetOverlapScrollView(UIScrollView scrollView) => this.overlapScrollView = scrollView;

  public override void SetDragAmount(float x, float y, bool updateScrollbars)
  {
    if ((Object) this.mPanel == (Object) null)
      this.mPanel = this.GetComponent<UIPanel>();
    this.DisableSpring();
    Bounds bounds = this.bounds;
    if ((double) bounds.min.x == (double) bounds.max.x || (double) bounds.min.y == (double) bounds.max.y)
      return;
    Vector4 finalClipRegion = this.mPanel.finalClipRegion;
    float num1 = finalClipRegion.z * 0.5f;
    float num2 = finalClipRegion.w * 0.5f;
    float a1 = bounds.min.x + num1;
    float b1 = bounds.max.x - num1;
    float b2 = bounds.min.y + num2;
    float a2 = bounds.max.y - num2;
    Vector3 localPosition = this.mTrans.localPosition;
    localPosition.z = 0.0f;
    this.mTrans.localRotation = Quaternion.Euler(Vector3.zero);
    if (this.canThisMoveHorizontally)
      localPosition.y = 0.0f;
    if (this.canThisMoveVertically)
      localPosition.x = 0.0f;
    if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
    {
      a1 -= this.mPanel.clipSoftness.x;
      b1 += this.mPanel.clipSoftness.x;
      b2 -= this.mPanel.clipSoftness.y;
      a2 += this.mPanel.clipSoftness.y;
    }
    float num3 = Mathf.Lerp(a1, b1, x);
    float num4 = Mathf.Lerp(a2, b2, y);
    if (!updateScrollbars)
    {
      if (this.canThisMoveHorizontally)
        localPosition.x += finalClipRegion.x - num3;
      if (this.canThisMoveVertically)
        localPosition.y += finalClipRegion.y - num4;
    }
    this.mTrans.localPosition = localPosition;
    if (this.canThisMoveHorizontally)
      finalClipRegion.x = num3;
    if (this.canThisMoveVertically)
      finalClipRegion.y = num4;
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
      int num1 = Mathf.CeilToInt(Mathf.Abs(relative.x) * 1000f);
      int num2 = Mathf.CeilToInt(Mathf.Abs(relative.y) * 1000f);
      this.moveMode = num1 != num2 ? (num1 <= num2 ? new UIScrollView.Movement?(UIScrollView.Movement.Vertical) : new UIScrollView.Movement?(UIScrollView.Movement.Horizontal)) : new UIScrollView.Movement?(this.thisMovement);
    }
    if (!this.moveMode.HasValue)
      return;
    relative.z = 0.0f;
    if (this.moveMode.Value == UIScrollView.Movement.Vertical)
      relative.x = 0.0f;
    if (this.moveMode.Value == UIScrollView.Movement.Horizontal)
      relative.y = 0.0f;
    Vector3 relative1 = new Vector3(relative.x, relative.y, 0.0f);
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
