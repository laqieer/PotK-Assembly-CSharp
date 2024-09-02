// Decompiled with JetBrains decompiler
// Type: UIDragDropItem
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Drag and Drop Item")]
public class UIDragDropItem : MonoBehaviour
{
  public UIDragDropItem.Restriction restriction;
  public bool cloneOnDrag;
  protected Transform mTrans;
  protected Transform mParent;
  protected Collider mCollider;
  protected UIRoot mRoot;
  protected UIGrid mGrid;
  protected UITable mTable;
  protected int mTouchID = int.MinValue;
  protected float mPressTime;
  protected UIDragScrollView mDragScrollView;

  protected virtual void Start()
  {
    this.mTrans = ((Component) this).transform;
    this.mCollider = ((Component) this).GetComponent<Collider>();
    this.mDragScrollView = ((Component) this).GetComponent<UIDragScrollView>();
  }

  private void OnPress(bool isPressed)
  {
    if (!isPressed)
      return;
    this.mPressTime = RealTime.time;
  }

  private void OnDragStart()
  {
    if (!((Behaviour) this).enabled || this.mTouchID != int.MinValue)
      return;
    if (this.restriction != UIDragDropItem.Restriction.None)
    {
      if (this.restriction == UIDragDropItem.Restriction.Horizontal)
      {
        Vector2 totalDelta = UICamera.currentTouch.totalDelta;
        if ((double) Mathf.Abs(totalDelta.x) < (double) Mathf.Abs(totalDelta.y))
          return;
      }
      else if (this.restriction == UIDragDropItem.Restriction.Vertical)
      {
        Vector2 totalDelta = UICamera.currentTouch.totalDelta;
        if ((double) Mathf.Abs(totalDelta.x) > (double) Mathf.Abs(totalDelta.y))
          return;
      }
      else if (this.restriction == UIDragDropItem.Restriction.PressAndHold && (double) this.mPressTime + 1.0 > (double) RealTime.time)
        return;
    }
    if (this.cloneOnDrag)
    {
      GameObject gameObject = NGUITools.AddChild(((Component) ((Component) this).transform.parent).gameObject, ((Component) this).gameObject);
      gameObject.transform.localPosition = ((Component) this).transform.localPosition;
      gameObject.transform.localRotation = ((Component) this).transform.localRotation;
      gameObject.transform.localScale = ((Component) this).transform.localScale;
      UIButtonColor component1 = gameObject.GetComponent<UIButtonColor>();
      if (Object.op_Inequality((Object) component1, (Object) null))
        component1.defaultColor = ((Component) this).GetComponent<UIButtonColor>().defaultColor;
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) false);
      UICamera.currentTouch.pressed = gameObject;
      UICamera.currentTouch.dragged = gameObject;
      UIDragDropItem component2 = gameObject.GetComponent<UIDragDropItem>();
      component2.Start();
      component2.OnDragDropStart();
    }
    else
      this.OnDragDropStart();
  }

  private void OnDrag(Vector2 delta)
  {
    if (!((Behaviour) this).enabled || this.mTouchID != UICamera.currentTouchID)
      return;
    this.OnDragDropMove(Vector3.op_Multiply(Vector2.op_Implicit(delta), this.mRoot.pixelSizeAdjustment));
  }

  private void OnDragEnd()
  {
    if (!((Behaviour) this).enabled || this.mTouchID != UICamera.currentTouchID)
      return;
    this.OnDragDropRelease(UICamera.hoveredObject);
  }

  protected virtual void OnDragDropStart()
  {
    if (Object.op_Inequality((Object) this.mDragScrollView, (Object) null))
      ((Behaviour) this.mDragScrollView).enabled = false;
    if (Object.op_Inequality((Object) this.mCollider, (Object) null))
      this.mCollider.enabled = false;
    this.mTouchID = UICamera.currentTouchID;
    this.mParent = this.mTrans.parent;
    this.mRoot = NGUITools.FindInParents<UIRoot>(this.mParent);
    this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
    this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
    if (Object.op_Inequality((Object) UIDragDropRoot.root, (Object) null))
      this.mTrans.parent = UIDragDropRoot.root;
    Vector3 localPosition = this.mTrans.localPosition;
    localPosition.z = 0.0f;
    this.mTrans.localPosition = localPosition;
    NGUITools.MarkParentAsChanged(((Component) this).gameObject);
    if (Object.op_Inequality((Object) this.mTable, (Object) null))
      this.mTable.repositionNow = true;
    if (!Object.op_Inequality((Object) this.mGrid, (Object) null))
      return;
    this.mGrid.repositionNow = true;
  }

  protected virtual void OnDragDropMove(Vector3 delta)
  {
    Transform mTrans = this.mTrans;
    mTrans.localPosition = Vector3.op_Addition(mTrans.localPosition, delta);
  }

  protected virtual void OnDragDropRelease(GameObject surface)
  {
    if (!this.cloneOnDrag)
    {
      this.mTouchID = int.MinValue;
      if (Object.op_Inequality((Object) this.mCollider, (Object) null))
        this.mCollider.enabled = true;
      UIDragDropContainer inParents = !Object.op_Implicit((Object) surface) ? (UIDragDropContainer) null : NGUITools.FindInParents<UIDragDropContainer>(surface);
      if (Object.op_Inequality((Object) inParents, (Object) null))
      {
        this.mTrans.parent = !Object.op_Inequality((Object) inParents.reparentTarget, (Object) null) ? ((Component) inParents).transform : inParents.reparentTarget;
        Vector3 localPosition = this.mTrans.localPosition;
        localPosition.z = 0.0f;
        this.mTrans.localPosition = localPosition;
      }
      else
        this.mTrans.parent = this.mParent;
      this.mParent = this.mTrans.parent;
      this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
      this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
      if (Object.op_Inequality((Object) this.mDragScrollView, (Object) null))
        ((Behaviour) this.mDragScrollView).enabled = true;
      NGUITools.MarkParentAsChanged(((Component) this).gameObject);
      if (Object.op_Inequality((Object) this.mTable, (Object) null))
        this.mTable.repositionNow = true;
      if (!Object.op_Inequality((Object) this.mGrid, (Object) null))
        return;
      this.mGrid.repositionNow = true;
    }
    else
      NGUITools.Destroy((Object) ((Component) this).gameObject);
  }

  public enum Restriction
  {
    None,
    Horizontal,
    Vertical,
    PressAndHold,
  }
}
