// Decompiled with JetBrains decompiler
// Type: UICenterOnChild
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Center Scroll View on Child")]
public class UICenterOnChild : MonoBehaviour
{
  public float springStrength = 8f;
  public float nextPageThreshold;
  public SpringPanel.OnFinished onFinished;
  private UIScrollView mScrollView;
  private GameObject mCenteredObject;

  public GameObject centeredObject => this.mCenteredObject;

  private void OnEnable() => this.Recenter();

  private void OnDragFinished()
  {
    if (!((Behaviour) this).enabled)
      return;
    this.Recenter();
  }

  private void OnValidate() => this.nextPageThreshold = Mathf.Abs(this.nextPageThreshold);

  public void Recenter()
  {
    if (Object.op_Equality((Object) this.mScrollView, (Object) null))
    {
      this.mScrollView = NGUITools.FindInParents<UIScrollView>(((Component) this).gameObject);
      if (Object.op_Equality((Object) this.mScrollView, (Object) null))
      {
        Debug.LogWarning((object) (((object) this).GetType().ToString() + " requires " + (object) typeof (UIScrollView) + " on a parent object in order to work"), (Object) this);
        ((Behaviour) this).enabled = false;
        return;
      }
      this.mScrollView.onDragFinished = new UIScrollView.OnDragFinished(this.OnDragFinished);
      if (Object.op_Inequality((Object) this.mScrollView.horizontalScrollBar, (Object) null))
        this.mScrollView.horizontalScrollBar.onDragFinished = new UIProgressBar.OnDragFinished(this.OnDragFinished);
      if (Object.op_Inequality((Object) this.mScrollView.verticalScrollBar, (Object) null))
        this.mScrollView.verticalScrollBar.onDragFinished = new UIProgressBar.OnDragFinished(this.OnDragFinished);
    }
    if (Object.op_Equality((Object) this.mScrollView.panel, (Object) null))
      return;
    Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
    Vector3 panelCenter = Vector3.op_Multiply(Vector3.op_Addition(worldCorners[2], worldCorners[0]), 0.5f);
    Vector3 vector3 = Vector3.op_Subtraction(panelCenter, Vector3.op_Multiply(this.mScrollView.currentMomentum, this.mScrollView.momentumAmount * 0.1f));
    this.mScrollView.currentMomentum = Vector3.zero;
    float num1 = float.MaxValue;
    Transform target = (Transform) null;
    Transform transform = ((Component) this).transform;
    int num2 = 0;
    int num3 = 0;
    for (int childCount = transform.childCount; num3 < childCount; ++num3)
    {
      Transform child = transform.GetChild(num3);
      float num4 = Vector3.SqrMagnitude(Vector3.op_Subtraction(child.position, vector3));
      if ((double) num4 < (double) num1)
      {
        num1 = num4;
        target = child;
        num2 = num3;
      }
    }
    if ((double) this.nextPageThreshold > 0.0 && UICamera.currentTouch != null && transform.childCount > 0 && Object.op_Inequality((Object) this.mCenteredObject, (Object) null) && Object.op_Equality((Object) this.mCenteredObject.transform, (Object) transform.GetChild(num2)))
    {
      Vector2 totalDelta = UICamera.currentTouch.totalDelta;
      float num5;
      switch (this.mScrollView.movement)
      {
        case UIScrollView.Movement.Horizontal:
          num5 = totalDelta.x;
          break;
        case UIScrollView.Movement.Vertical:
          num5 = totalDelta.y;
          break;
        default:
          num5 = ((Vector2) ref totalDelta).magnitude;
          break;
      }
      if ((double) num5 > (double) this.nextPageThreshold)
      {
        if (num2 > 0)
          target = transform.GetChild(num2 - 1);
      }
      else if ((double) num5 < -(double) this.nextPageThreshold && num2 < transform.childCount - 1)
        target = transform.GetChild(num2 + 1);
    }
    this.CenterOn(target, panelCenter);
  }

  private void CenterOn(Transform target, Vector3 panelCenter)
  {
    if (Object.op_Inequality((Object) target, (Object) null) && Object.op_Inequality((Object) this.mScrollView, (Object) null) && Object.op_Inequality((Object) this.mScrollView.panel, (Object) null))
    {
      Transform cachedTransform = this.mScrollView.panel.cachedTransform;
      this.mCenteredObject = ((Component) target).gameObject;
      Vector3 vector3 = Vector3.op_Subtraction(cachedTransform.InverseTransformPoint(target.position), cachedTransform.InverseTransformPoint(panelCenter));
      if (!this.mScrollView.canMoveHorizontally)
        vector3.x = 0.0f;
      if (!this.mScrollView.canMoveVertically)
        vector3.y = 0.0f;
      vector3.z = 0.0f;
      SpringPanel.Begin(this.mScrollView.panel.cachedGameObject, Vector3.op_Subtraction(cachedTransform.localPosition, vector3), this.springStrength).onFinished = this.onFinished;
    }
    else
      this.mCenteredObject = (GameObject) null;
  }

  public void CenterOn(Transform target)
  {
    if (!Object.op_Inequality((Object) this.mScrollView, (Object) null) || !Object.op_Inequality((Object) this.mScrollView.panel, (Object) null))
      return;
    Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
    Vector3 panelCenter = Vector3.op_Multiply(Vector3.op_Addition(worldCorners[2], worldCorners[0]), 0.5f);
    this.CenterOn(target, panelCenter);
  }
}
