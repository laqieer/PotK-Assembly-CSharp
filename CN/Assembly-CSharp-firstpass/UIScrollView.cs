// Decompiled with JetBrains decompiler
// Type: UIScrollView
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[RequireComponent(typeof (UIPanel))]
[AddComponentMenu("NGUI/Interaction/Scroll View")]
public class UIScrollView : MonoBehaviour
{
  public UIScrollView.Movement movement;
  public UIScrollView.DragEffect dragEffect = UIScrollView.DragEffect.MomentumAndSpring;
  public bool restrictWithinPanel = true;
  public bool disableDragIfFits;
  public bool smoothDragStart = true;
  public bool iOSDragEmulation = true;
  public float scrollWheelFactor = 0.25f;
  public float momentumAmount = 35f;
  public UIProgressBar horizontalScrollBar;
  public UIProgressBar verticalScrollBar;
  public UIScrollView.ShowCondition showScrollBars = UIScrollView.ShowCondition.OnlyIfNeeded;
  public Vector2 customMovement = new Vector2(1f, 0.0f);
  public UIWidget.Pivot contentPivot;
  public UIScrollView.OnDragFinished onDragFinished;
  [HideInInspector]
  [SerializeField]
  private Vector3 scale = new Vector3(1f, 0.0f, 0.0f);
  [SerializeField]
  [HideInInspector]
  private Vector2 relativePositionOnReset = Vector2.zero;
  protected Transform mTrans;
  protected UIPanel mPanel;
  protected Plane mPlane;
  protected Vector3 mLastPos;
  protected bool mPressed;
  protected Vector3 mMomentum = Vector3.zero;
  protected float mScroll;
  protected Bounds mBounds;
  protected bool mCalculatedBounds;
  protected bool mShouldMove;
  protected bool mIgnoreCallbacks;
  protected int mDragID = -10;
  protected Vector2 mDragStartOffset = Vector2.zero;
  protected bool mDragStarted;

  public UIPanel panel => this.mPanel;

  public bool isDragging => this.mPressed && this.mDragStarted;

  public virtual Bounds bounds
  {
    get
    {
      if (!this.mCalculatedBounds)
      {
        this.mCalculatedBounds = true;
        this.mTrans = ((Component) this).transform;
        this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mTrans, this.mTrans);
      }
      return this.mBounds;
    }
  }

  public bool canMoveHorizontally
  {
    get
    {
      if (this.movement == UIScrollView.Movement.Horizontal || this.movement == UIScrollView.Movement.Unrestricted)
        return true;
      return this.movement == UIScrollView.Movement.Custom && (double) this.customMovement.x != 0.0;
    }
  }

  public bool canMoveVertically
  {
    get
    {
      if (this.movement == UIScrollView.Movement.Vertical || this.movement == UIScrollView.Movement.Unrestricted)
        return true;
      return this.movement == UIScrollView.Movement.Custom && (double) this.customMovement.y != 0.0;
    }
  }

  public virtual bool shouldMoveHorizontally
  {
    get
    {
      Bounds bounds = this.bounds;
      float x = ((Bounds) ref bounds).size.x;
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        x += this.mPanel.clipSoftness.x * 2f;
      return (double) x > (double) this.mPanel.width;
    }
  }

  public virtual bool shouldMoveVertically
  {
    get
    {
      Bounds bounds = this.bounds;
      float y = ((Bounds) ref bounds).size.y;
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        y += this.mPanel.clipSoftness.y * 2f;
      return (double) y > (double) this.mPanel.height;
    }
  }

  protected virtual bool shouldMove
  {
    get
    {
      if (!this.disableDragIfFits)
        return true;
      if (Object.op_Equality((Object) this.mPanel, (Object) null))
        this.mPanel = ((Component) this).GetComponent<UIPanel>();
      Vector4 finalClipRegion = this.mPanel.finalClipRegion;
      Bounds bounds = this.bounds;
      float num1 = (double) finalClipRegion.z != 0.0 ? finalClipRegion.z * 0.5f : (float) Screen.width;
      float num2 = (double) finalClipRegion.w != 0.0 ? finalClipRegion.w * 0.5f : (float) Screen.height;
      return this.canMoveHorizontally && ((double) ((Bounds) ref bounds).min.x < (double) finalClipRegion.x - (double) num1 || (double) ((Bounds) ref bounds).max.x > (double) finalClipRegion.x + (double) num1) || this.canMoveVertically && ((double) ((Bounds) ref bounds).min.y < (double) finalClipRegion.y - (double) num2 || (double) ((Bounds) ref bounds).max.y > (double) finalClipRegion.y + (double) num2);
    }
  }

  public Vector3 currentMomentum
  {
    get => this.mMomentum;
    set
    {
      this.mMomentum = value;
      this.mShouldMove = true;
    }
  }

  private void Awake()
  {
    this.mTrans = ((Component) this).transform;
    this.mPanel = ((Component) this).GetComponent<UIPanel>();
    if (this.mPanel.clipping == UIDrawCall.Clipping.None)
      this.mPanel.clipping = UIDrawCall.Clipping.ConstrainButDontClip;
    if (this.movement != UIScrollView.Movement.Custom && (double) ((Vector3) ref this.scale).sqrMagnitude > 1.0 / 1000.0)
    {
      if ((double) this.scale.x == 1.0 && (double) this.scale.y == 0.0)
        this.movement = UIScrollView.Movement.Horizontal;
      else if ((double) this.scale.x == 0.0 && (double) this.scale.y == 1.0)
        this.movement = UIScrollView.Movement.Vertical;
      else if ((double) this.scale.x == 1.0 && (double) this.scale.y == 1.0)
      {
        this.movement = UIScrollView.Movement.Unrestricted;
      }
      else
      {
        this.movement = UIScrollView.Movement.Custom;
        this.customMovement.x = this.scale.x;
        this.customMovement.y = this.scale.y;
      }
      this.scale = Vector3.zero;
    }
    if (this.contentPivot != UIWidget.Pivot.TopLeft || !Vector2.op_Inequality(this.relativePositionOnReset, Vector2.zero))
      return;
    this.contentPivot = NGUIMath.GetPivot(new Vector2(this.relativePositionOnReset.x, 1f - this.relativePositionOnReset.y));
    this.relativePositionOnReset = Vector2.zero;
  }

  protected virtual void Start()
  {
    if (!Application.isPlaying)
      return;
    if (Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null))
    {
      EventDelegate.Add(this.horizontalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
      this.horizontalScrollBar.alpha = this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveHorizontally ? 1f : 0.0f;
    }
    if (!Object.op_Inequality((Object) this.verticalScrollBar, (Object) null))
      return;
    EventDelegate.Add(this.verticalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
    this.verticalScrollBar.alpha = this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveVertically ? 1f : 0.0f;
  }

  public bool RestrictWithinBounds(bool instant) => this.RestrictWithinBounds(instant, true, true);

  public bool RestrictWithinBounds(bool instant, bool horizontal, bool vertical)
  {
    Bounds bounds = this.bounds;
    Vector3 constrainOffset = this.mPanel.CalculateConstrainOffset(Vector2.op_Implicit(((Bounds) ref bounds).min), Vector2.op_Implicit(((Bounds) ref bounds).max));
    if (!horizontal)
      constrainOffset.x = 0.0f;
    if (!vertical)
      constrainOffset.y = 0.0f;
    if ((double) ((Vector3) ref constrainOffset).sqrMagnitude <= 1.0)
      return false;
    if (!instant && this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
    {
      Vector3 pos = Vector3.op_Addition(this.mTrans.localPosition, constrainOffset);
      pos.x = Mathf.Round(pos.x);
      pos.y = Mathf.Round(pos.y);
      SpringPanel.Begin(((Component) this.mPanel).gameObject, pos, 13f);
    }
    else
    {
      this.MoveRelative(constrainOffset);
      this.mMomentum = Vector3.zero;
      this.mScroll = 0.0f;
    }
    return true;
  }

  public void DisableSpring()
  {
    SpringPanel component = ((Component) this).GetComponent<SpringPanel>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    ((Behaviour) component).enabled = false;
  }

  public virtual void UpdateScrollbars(bool recalculateBounds)
  {
    if (Object.op_Equality((Object) this.mPanel, (Object) null))
      return;
    if (Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null) || Object.op_Inequality((Object) this.verticalScrollBar, (Object) null))
    {
      if (recalculateBounds)
      {
        this.mCalculatedBounds = false;
        this.mShouldMove = this.shouldMove;
      }
      Bounds bounds = this.bounds;
      Vector2 vector2_1 = Vector2.op_Implicit(((Bounds) ref bounds).min);
      Vector2 vector2_2 = Vector2.op_Implicit(((Bounds) ref bounds).max);
      if (Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null) && (double) vector2_2.x > (double) vector2_1.x)
      {
        Vector4 finalClipRegion = this.mPanel.finalClipRegion;
        int num1 = Mathf.RoundToInt(finalClipRegion.z);
        if ((num1 & 1) != 0)
          --num1;
        float num2 = Mathf.Round((float) num1 * 0.5f);
        if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
          num2 -= this.mPanel.clipSoftness.x;
        float contentSize = vector2_2.x - vector2_1.x;
        float viewSize = num2 * 2f;
        float x1 = vector2_1.x;
        float x2 = vector2_2.x;
        float num3 = finalClipRegion.x - num2;
        float num4 = finalClipRegion.x + num2;
        this.UpdateScrollbars(this.horizontalScrollBar, num3 - x1, x2 - num4, contentSize, viewSize, false);
      }
      if (!Object.op_Inequality((Object) this.verticalScrollBar, (Object) null) || (double) vector2_2.y <= (double) vector2_1.y)
        return;
      Vector4 finalClipRegion1 = this.mPanel.finalClipRegion;
      int num5 = Mathf.RoundToInt(finalClipRegion1.w);
      if ((num5 & 1) != 0)
        --num5;
      float num6 = Mathf.Round((float) num5 * 0.5f);
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        num6 -= this.mPanel.clipSoftness.y;
      float contentSize1 = vector2_2.y - vector2_1.y;
      float viewSize1 = num6 * 2f;
      float y1 = vector2_1.y;
      float y2 = vector2_2.y;
      float num7 = finalClipRegion1.y - num6;
      float num8 = finalClipRegion1.y + num6;
      this.UpdateScrollbars(this.verticalScrollBar, num7 - y1, y2 - num8, contentSize1, viewSize1, true);
    }
    else
    {
      if (!recalculateBounds)
        return;
      this.mCalculatedBounds = false;
    }
  }

  protected void UpdateScrollbars(
    UIProgressBar slider,
    float contentMin,
    float contentMax,
    float contentSize,
    float viewSize,
    bool inverted)
  {
    if (Object.op_Equality((Object) slider, (Object) null))
      return;
    if ((double) viewSize < (double) contentSize)
    {
      contentMin = Mathf.Clamp01(contentMin / contentSize);
      contentMax = Mathf.Clamp01(contentMax / contentSize);
    }
    else
    {
      contentMin = Mathf.Clamp01(-contentMin / contentSize);
      contentMax = Mathf.Clamp01(-contentMax / contentSize);
    }
    this.mIgnoreCallbacks = true;
    float num = contentMin + contentMax;
    slider.value = !inverted ? ((double) num <= 1.0 / 1000.0 ? 1f : contentMin / num) : ((double) num <= 1.0 / 1000.0 ? 0.0f : (float) (1.0 - (double) contentMin / (double) num));
    UIScrollBar uiScrollBar = slider as UIScrollBar;
    if (Object.op_Inequality((Object) uiScrollBar, (Object) null))
      uiScrollBar.barSize = 1f - num;
    this.mIgnoreCallbacks = false;
  }

  public virtual void SetDragAmount(float x, float y, bool updateScrollbars)
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
      Vector3 localPosition = this.mTrans.localPosition;
      if (this.canMoveHorizontally)
        localPosition.x += finalClipRegion.x - num7;
      if (this.canMoveVertically)
        localPosition.y += finalClipRegion.y - num8;
      this.mTrans.localPosition = localPosition;
    }
    if (this.canMoveHorizontally)
      finalClipRegion.x = num7;
    if (this.canMoveVertically)
      finalClipRegion.y = num8;
    Vector4 baseClipRegion = this.mPanel.baseClipRegion;
    this.mPanel.clipOffset = new Vector2(finalClipRegion.x - baseClipRegion.x, finalClipRegion.y - baseClipRegion.y);
    if (!updateScrollbars)
      return;
    this.UpdateScrollbars(this.mDragID == -10);
  }

  [ContextMenu("Reset Clipping Position")]
  public void ResetPosition()
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    this.mCalculatedBounds = false;
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
    this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, false);
    this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, true);
  }

  public void UpdatePosition()
  {
    if (this.mIgnoreCallbacks || !Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null) && !Object.op_Inequality((Object) this.verticalScrollBar, (Object) null))
      return;
    this.mIgnoreCallbacks = true;
    this.mCalculatedBounds = false;
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
    this.SetDragAmount(!Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null) ? pivotOffset.x : this.horizontalScrollBar.value, !Object.op_Inequality((Object) this.verticalScrollBar, (Object) null) ? 1f - pivotOffset.y : this.verticalScrollBar.value, false);
    this.UpdateScrollbars(true);
    this.mIgnoreCallbacks = false;
  }

  public void OnScrollBar()
  {
    if (this.mIgnoreCallbacks)
      return;
    this.mIgnoreCallbacks = true;
    this.SetDragAmount(!Object.op_Inequality((Object) this.horizontalScrollBar, (Object) null) ? 0.0f : this.horizontalScrollBar.value, !Object.op_Inequality((Object) this.verticalScrollBar, (Object) null) ? 0.0f : this.verticalScrollBar.value, false);
    this.mIgnoreCallbacks = false;
  }

  public virtual void MoveRelative(Vector3 relative)
  {
    Transform mTrans = this.mTrans;
    mTrans.localPosition = Vector3.op_Addition(mTrans.localPosition, relative);
    Vector2 clipOffset = this.mPanel.clipOffset;
    clipOffset.x -= relative.x;
    clipOffset.y -= relative.y;
    this.mPanel.clipOffset = clipOffset;
    this.UpdateScrollbars(false);
  }

  public void MoveAbsolute(Vector3 absolute)
  {
    this.MoveRelative(Vector3.op_Subtraction(this.mTrans.InverseTransformPoint(absolute), this.mTrans.InverseTransformPoint(Vector3.zero)));
  }

  public void Press(bool pressed)
  {
    if (this.smoothDragStart && pressed)
    {
      this.mDragStarted = false;
      this.mDragStartOffset = Vector2.zero;
    }
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject))
      return;
    if (!pressed && this.mDragID == UICamera.currentTouchID)
      this.mDragID = -10;
    this.mCalculatedBounds = false;
    this.mShouldMove = this.shouldMove;
    if (!this.mShouldMove)
      return;
    this.mPressed = pressed;
    if (pressed)
    {
      this.mMomentum = Vector3.zero;
      this.mScroll = 0.0f;
      this.DisableSpring();
      this.mLastPos = ((RaycastHit) ref UICamera.lastHit).point;
      this.mPlane = new Plane(Quaternion.op_Multiply(this.mTrans.rotation, Vector3.back), this.mLastPos);
      Vector2 clipOffset = this.mPanel.clipOffset;
      clipOffset.x = Mathf.Round(clipOffset.x);
      clipOffset.y = Mathf.Round(clipOffset.y);
      this.mPanel.clipOffset = clipOffset;
      Vector3 localPosition = this.mTrans.localPosition;
      localPosition.x = Mathf.Round(localPosition.x);
      localPosition.y = Mathf.Round(localPosition.y);
      this.mTrans.localPosition = localPosition;
    }
    else
    {
      if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None && this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
        this.RestrictWithinBounds(false, this.canMoveHorizontally, this.canMoveVertically);
      if (this.onDragFinished == null)
        return;
      this.onDragFinished();
    }
  }

  public void Drag()
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || !this.mShouldMove)
      return;
    if (this.mDragID == -10)
      this.mDragID = UICamera.currentTouchID;
    UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
    if (this.smoothDragStart && !this.mDragStarted)
    {
      this.mDragStarted = true;
      this.mDragStartOffset = UICamera.currentTouch.totalDelta;
    }
    Ray ray = !this.smoothDragStart ? UICamera.currentCamera.ScreenPointToRay(Vector2.op_Implicit(UICamera.currentTouch.pos)) : UICamera.currentCamera.ScreenPointToRay(Vector2.op_Implicit(Vector2.op_Subtraction(UICamera.currentTouch.pos, this.mDragStartOffset)));
    float num = 0.0f;
    if (!((Plane) ref this.mPlane).Raycast(ray, ref num))
      return;
    Vector3 point = ((Ray) ref ray).GetPoint(num);
    Vector3 absolute = Vector3.op_Subtraction(point, this.mLastPos);
    this.mLastPos = point;
    if ((double) absolute.x != 0.0 || (double) absolute.y != 0.0)
    {
      Vector3 vector3 = this.mTrans.InverseTransformDirection(absolute);
      if (this.movement == UIScrollView.Movement.Horizontal)
      {
        vector3.y = 0.0f;
        vector3.z = 0.0f;
      }
      else if (this.movement == UIScrollView.Movement.Vertical)
      {
        vector3.x = 0.0f;
        vector3.z = 0.0f;
      }
      else if (this.movement == UIScrollView.Movement.Unrestricted)
        vector3.z = 0.0f;
      else
        ((Vector3) ref vector3).Scale(Vector2.op_Implicit(this.customMovement));
      absolute = this.mTrans.TransformDirection(vector3);
    }
    this.mMomentum = Vector3.Lerp(this.mMomentum, Vector3.op_Addition(this.mMomentum, Vector3.op_Multiply(absolute, 0.01f * this.momentumAmount)), 0.67f);
    if (!this.iOSDragEmulation || this.dragEffect != UIScrollView.DragEffect.MomentumAndSpring)
    {
      this.MoveAbsolute(absolute);
    }
    else
    {
      UIPanel mPanel = this.mPanel;
      Bounds bounds1 = this.bounds;
      Vector2 min = Vector2.op_Implicit(((Bounds) ref bounds1).min);
      Bounds bounds2 = this.bounds;
      Vector2 max = Vector2.op_Implicit(((Bounds) ref bounds2).max);
      Vector3 constrainOffset = mPanel.CalculateConstrainOffset(min, max);
      if ((double) ((Vector3) ref constrainOffset).magnitude > 1.0)
      {
        this.MoveAbsolute(Vector3.op_Multiply(absolute, 0.5f));
        UIScrollView uiScrollView = this;
        uiScrollView.mMomentum = Vector3.op_Multiply(uiScrollView.mMomentum, 0.5f);
      }
      else
        this.MoveAbsolute(absolute);
    }
    if (!this.restrictWithinPanel || this.mPanel.clipping == UIDrawCall.Clipping.None || this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
      return;
    this.RestrictWithinBounds(true, this.canMoveHorizontally, this.canMoveVertically);
  }

  public void Scroll(float delta)
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || (double) this.scrollWheelFactor == 0.0)
      return;
    this.DisableSpring();
    this.mShouldMove = this.shouldMove;
    if ((double) Mathf.Sign(this.mScroll) != (double) Mathf.Sign(delta))
      this.mScroll = 0.0f;
    this.mScroll += delta * this.scrollWheelFactor;
  }

  private void LateUpdate()
  {
    if (!Application.isPlaying)
      return;
    float deltaTime = RealTime.deltaTime;
    if (this.showScrollBars != UIScrollView.ShowCondition.Always && (Object.op_Implicit((Object) this.verticalScrollBar) || Object.op_Implicit((Object) this.horizontalScrollBar)))
    {
      bool flag1 = false;
      bool flag2 = false;
      if (this.showScrollBars != UIScrollView.ShowCondition.WhenDragging || this.mDragID != -10 || (double) ((Vector3) ref this.mMomentum).magnitude > 0.0099999997764825821)
      {
        flag1 = this.shouldMoveVertically;
        flag2 = this.shouldMoveHorizontally;
      }
      if (Object.op_Implicit((Object) this.verticalScrollBar))
      {
        float num = Mathf.Clamp01(this.verticalScrollBar.alpha + (!flag1 ? (float) (-(double) deltaTime * 3.0) : deltaTime * 6f));
        if ((double) this.verticalScrollBar.alpha != (double) num)
          this.verticalScrollBar.alpha = num;
      }
      if (Object.op_Implicit((Object) this.horizontalScrollBar))
      {
        float num = Mathf.Clamp01(this.horizontalScrollBar.alpha + (!flag2 ? (float) (-(double) deltaTime * 3.0) : deltaTime * 6f));
        if ((double) this.horizontalScrollBar.alpha != (double) num)
          this.horizontalScrollBar.alpha = num;
      }
    }
    if (this.mShouldMove && !this.mPressed)
    {
      if (this.movement == UIScrollView.Movement.Horizontal)
      {
        UIScrollView uiScrollView = this;
        uiScrollView.mMomentum = Vector3.op_Subtraction(uiScrollView.mMomentum, this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, 0.0f, 0.0f)));
      }
      else if (this.movement == UIScrollView.Movement.Vertical)
      {
        UIScrollView uiScrollView = this;
        uiScrollView.mMomentum = Vector3.op_Subtraction(uiScrollView.mMomentum, this.mTrans.TransformDirection(new Vector3(0.0f, this.mScroll * 0.05f, 0.0f)));
      }
      else if (this.movement == UIScrollView.Movement.Unrestricted)
      {
        UIScrollView uiScrollView = this;
        uiScrollView.mMomentum = Vector3.op_Subtraction(uiScrollView.mMomentum, this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, this.mScroll * 0.05f, 0.0f)));
      }
      else
      {
        UIScrollView uiScrollView = this;
        uiScrollView.mMomentum = Vector3.op_Subtraction(uiScrollView.mMomentum, this.mTrans.TransformDirection(new Vector3((float) ((double) this.mScroll * (double) this.customMovement.x * 0.05000000074505806), (float) ((double) this.mScroll * (double) this.customMovement.y * 0.05000000074505806), 0.0f)));
      }
      if ((double) ((Vector3) ref this.mMomentum).magnitude > 9.9999997473787516E-05)
      {
        this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0.0f, 20f, deltaTime);
        this.MoveAbsolute(NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime));
        if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
          this.RestrictWithinBounds(false, this.canMoveHorizontally, this.canMoveVertically);
        if ((double) ((Vector3) ref this.mMomentum).magnitude >= 9.9999997473787516E-05 || this.onDragFinished == null)
          return;
        this.onDragFinished();
        return;
      }
      this.mScroll = 0.0f;
      this.mMomentum = Vector3.zero;
    }
    else
      this.mScroll = 0.0f;
    NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
  }

  public enum Movement
  {
    Horizontal,
    Vertical,
    Unrestricted,
    Custom,
  }

  public enum DragEffect
  {
    None,
    Momentum,
    MomentumAndSpring,
  }

  public enum ShowCondition
  {
    Always,
    OnlyIfNeeded,
    WhenDragging,
  }

  public delegate void OnDragFinished();
}
