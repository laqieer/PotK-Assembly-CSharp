// Decompiled with JetBrains decompiler
// Type: UIWrapContent
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Wrap Content")]
public class UIWrapContent : MonoBehaviour
{
  public int itemSize = 100;
  public bool cullContent = true;
  private Transform mTrans;
  private UIPanel mPanel;
  private UIScrollView mScroll;
  private bool mHorizontal;
  private BetterList<Transform> mChildren = new BetterList<Transform>();

  protected virtual void Start()
  {
    this.SortBasedOnScrollMovement();
    this.WrapContent();
    if (!Object.op_Inequality((Object) this.mScroll, (Object) null))
      return;
    ((Component) this.mScroll).GetComponent<UIPanel>().onClipMove = new UIPanel.OnClippingMoved(this.OnMove);
    this.mScroll.restrictWithinPanel = false;
    if (this.mScroll.dragEffect != UIScrollView.DragEffect.MomentumAndSpring)
      return;
    this.mScroll.dragEffect = UIScrollView.DragEffect.Momentum;
  }

  protected virtual void OnMove(UIPanel panel) => this.WrapContent();

  [ContextMenu("Sort Based on Scroll Movement")]
  public void SortBasedOnScrollMovement()
  {
    if (!this.CacheScrollView())
      return;
    this.mChildren.Clear();
    for (int index = 0; index < this.mTrans.childCount; ++index)
      this.mChildren.Add(this.mTrans.GetChild(index));
    if (this.mHorizontal)
      this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortHorizontal));
    else
      this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortVertical));
    this.ResetChildPositions();
  }

  [ContextMenu("Sort Alphabetically")]
  public void SortAlphabetically()
  {
    if (!this.CacheScrollView())
      return;
    this.mChildren.Clear();
    for (int index = 0; index < this.mTrans.childCount; ++index)
      this.mChildren.Add(this.mTrans.GetChild(index));
    this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
    this.ResetChildPositions();
  }

  protected bool CacheScrollView()
  {
    this.mTrans = ((Component) this).transform;
    this.mPanel = NGUITools.FindInParents<UIPanel>(((Component) this).gameObject);
    this.mScroll = ((Component) this.mPanel).GetComponent<UIScrollView>();
    if (Object.op_Equality((Object) this.mScroll, (Object) null))
      return false;
    if (this.mScroll.movement == UIScrollView.Movement.Horizontal)
    {
      this.mHorizontal = true;
    }
    else
    {
      if (this.mScroll.movement != UIScrollView.Movement.Vertical)
        return false;
      this.mHorizontal = false;
    }
    return true;
  }

  private void ResetChildPositions()
  {
    for (int i = 0; i < this.mChildren.size; ++i)
      this.mChildren[i].localPosition = !this.mHorizontal ? new Vector3(0.0f, (float) (-i * this.itemSize), 0.0f) : new Vector3((float) (i * this.itemSize), 0.0f, 0.0f);
  }

  public void WrapContent()
  {
    float num1 = (float) (this.itemSize * this.mChildren.size) * 0.5f;
    Vector3[] worldCorners = this.mPanel.worldCorners;
    for (int index = 0; index < 4; ++index)
    {
      Vector3 vector3 = this.mTrans.InverseTransformPoint(worldCorners[index]);
      worldCorners[index] = vector3;
    }
    Vector3 vector3_1 = Vector3.Lerp(worldCorners[0], worldCorners[2], 0.5f);
    if (this.mHorizontal)
    {
      float num2 = worldCorners[0].x - (float) this.itemSize;
      float num3 = worldCorners[2].x + (float) this.itemSize;
      for (int index = 0; index < this.mChildren.size; ++index)
      {
        Transform mChild = this.mChildren[index];
        float num4 = mChild.localPosition.x - vector3_1.x;
        if ((double) num4 < -(double) num1)
        {
          Transform transform = mChild;
          transform.localPosition = Vector3.op_Addition(transform.localPosition, new Vector3(num1 * 2f, 0.0f, 0.0f));
          num4 = mChild.localPosition.x - vector3_1.x;
          this.UpdateItem(mChild, index);
        }
        else if ((double) num4 > (double) num1)
        {
          Transform transform = mChild;
          transform.localPosition = Vector3.op_Subtraction(transform.localPosition, new Vector3(num1 * 2f, 0.0f, 0.0f));
          num4 = mChild.localPosition.x - vector3_1.x;
          this.UpdateItem(mChild, index);
        }
        if (this.cullContent)
        {
          float num5 = num4 + (this.mPanel.clipOffset.x - this.mTrans.localPosition.x);
          if (!UICamera.IsPressed(((Component) mChild).gameObject))
            NGUITools.SetActive(((Component) mChild).gameObject, (double) num5 > (double) num2 && (double) num5 < (double) num3, false);
        }
      }
    }
    else
    {
      float num6 = worldCorners[0].y - (float) this.itemSize;
      float num7 = worldCorners[2].y + (float) this.itemSize;
      for (int index = 0; index < this.mChildren.size; ++index)
      {
        Transform mChild = this.mChildren[index];
        float num8 = mChild.localPosition.y - vector3_1.y;
        if ((double) num8 < -(double) num1)
        {
          Transform transform = mChild;
          transform.localPosition = Vector3.op_Addition(transform.localPosition, new Vector3(0.0f, num1 * 2f, 0.0f));
          num8 = mChild.localPosition.y - vector3_1.y;
          this.UpdateItem(mChild, index);
        }
        else if ((double) num8 > (double) num1)
        {
          Transform transform = mChild;
          transform.localPosition = Vector3.op_Subtraction(transform.localPosition, new Vector3(0.0f, num1 * 2f, 0.0f));
          num8 = mChild.localPosition.y - vector3_1.y;
          this.UpdateItem(mChild, index);
        }
        if (this.cullContent)
        {
          float num9 = num8 + (this.mPanel.clipOffset.y - this.mTrans.localPosition.y);
          if (!UICamera.IsPressed(((Component) mChild).gameObject))
            NGUITools.SetActive(((Component) mChild).gameObject, (double) num9 > (double) num6 && (double) num9 < (double) num7, false);
        }
      }
    }
  }

  protected virtual void UpdateItem(Transform item, int index)
  {
  }
}
