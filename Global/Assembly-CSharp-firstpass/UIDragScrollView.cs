// Decompiled with JetBrains decompiler
// Type: UIDragScrollView
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Drag Scroll View")]
public class UIDragScrollView : MonoBehaviour
{
  public UIScrollView scrollView;
  [SerializeField]
  [HideInInspector]
  private UIScrollView draggablePanel;
  private Transform mTrans;
  private UIScrollView mScroll;
  private bool mAutoFind;

  private void OnEnable()
  {
    this.mTrans = ((Component) this).transform;
    if (Object.op_Equality((Object) this.scrollView, (Object) null) && Object.op_Inequality((Object) this.draggablePanel, (Object) null))
    {
      this.scrollView = this.draggablePanel;
      this.draggablePanel = (UIScrollView) null;
    }
    if (!this.mAutoFind && !Object.op_Equality((Object) this.mScroll, (Object) null))
      return;
    this.FindScrollView();
  }

  private void FindScrollView()
  {
    UIScrollView inParents = NGUITools.FindInParents<UIScrollView>(this.mTrans);
    if (Object.op_Equality((Object) this.scrollView, (Object) null))
    {
      this.scrollView = inParents;
      this.mAutoFind = true;
    }
    else if (Object.op_Equality((Object) this.scrollView, (Object) inParents))
      this.mAutoFind = true;
    this.mScroll = this.scrollView;
  }

  private void Start() => this.FindScrollView();

  private void OnPress(bool pressed)
  {
    if (this.mAutoFind && Object.op_Inequality((Object) this.mScroll, (Object) this.scrollView))
    {
      this.mScroll = this.scrollView;
      this.mAutoFind = false;
    }
    if (!Object.op_Implicit((Object) this.scrollView) || !((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject))
      return;
    this.scrollView.Press(pressed);
    if (pressed || !this.mAutoFind)
      return;
    this.scrollView = NGUITools.FindInParents<UIScrollView>(this.mTrans);
    this.mScroll = this.scrollView;
  }

  private void OnDrag(Vector2 delta)
  {
    if (!Object.op_Implicit((Object) this.scrollView) || !NGUITools.GetActive((Behaviour) this))
      return;
    this.scrollView.Drag();
  }

  private void OnScroll(float delta)
  {
    if (!Object.op_Implicit((Object) this.scrollView) || !NGUITools.GetActive((Behaviour) this))
      return;
    this.scrollView.Scroll(delta);
  }
}
