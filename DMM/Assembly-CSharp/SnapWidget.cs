// Decompiled with JetBrains decompiler
// Type: SnapWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SnapWidget : MonoBehaviour
{
  [SerializeField]
  private bool isCalculateLocalPosition_ = true;
  private UIWidget widget_;
  private bool resetPosition_ = true;
  private Vector3 posOrigin_;

  private UIWidget myWidget
  {
    get
    {
      if ((Object) this.widget_ == (Object) null)
        this.widget_ = this.GetComponent<UIWidget>();
      return this.widget_;
    }
  }

  private Vector3 posOrigin
  {
    get
    {
      if (this.resetPosition_)
      {
        this.resetPosition_ = false;
        this.posOrigin_ = this.transform.localPosition;
      }
      return this.posOrigin_;
    }
  }

  private void Awake()
  {
    UIGrid component = this.GetComponent<UIGrid>();
    if (!((Object) component != (Object) null) || !((Object) this.myWidget != (Object) null))
      return;
    component.onReposition = new UIGrid.OnReposition(this.snapChildWidgets);
  }

  public void snapChildWidgets()
  {
    if ((Object) this.myWidget == (Object) null || this.transform.childCount == 0)
    {
      if (!((Object) this.myWidget != (Object) null))
        return;
      this.myWidget.enabled = false;
    }
    else
    {
      this.myWidget.enabled = false;
      if (this.isCalculateLocalPosition_)
        this.transform.localPosition = this.posOrigin;
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(this.transform);
      this.myWidget.enabled = true;
      this.myWidget.width = Mathf.FloorToInt(relativeWidgetBounds.size.x);
      this.myWidget.height = Mathf.FloorToInt(relativeWidgetBounds.size.y);
      Vector3 vector3 = Vector3.zero;
      switch (this.myWidget.pivot)
      {
        case UIWidget.Pivot.TopLeft:
          vector3 = new Vector3(relativeWidgetBounds.min.x, relativeWidgetBounds.max.y, 0.0f);
          break;
        case UIWidget.Pivot.Top:
          vector3 = new Vector3(relativeWidgetBounds.center.x, relativeWidgetBounds.max.y, 0.0f);
          break;
        case UIWidget.Pivot.TopRight:
          vector3 = new Vector3(relativeWidgetBounds.max.x, relativeWidgetBounds.max.y, 0.0f);
          break;
        case UIWidget.Pivot.Left:
          vector3 = new Vector3(relativeWidgetBounds.min.x, relativeWidgetBounds.center.y, 0.0f);
          break;
        case UIWidget.Pivot.Center:
          vector3 = new Vector3(relativeWidgetBounds.center.x, relativeWidgetBounds.center.y, 0.0f);
          break;
        case UIWidget.Pivot.Right:
          vector3 = new Vector3(relativeWidgetBounds.max.x, relativeWidgetBounds.center.y, 0.0f);
          break;
        case UIWidget.Pivot.BottomLeft:
          vector3 = new Vector3(relativeWidgetBounds.min.x, relativeWidgetBounds.min.y, 0.0f);
          break;
        case UIWidget.Pivot.Bottom:
          vector3 = new Vector3(relativeWidgetBounds.center.x, relativeWidgetBounds.min.y, 0.0f);
          break;
        case UIWidget.Pivot.BottomRight:
          vector3 = new Vector3(relativeWidgetBounds.max.x, relativeWidgetBounds.min.y, 0.0f);
          break;
      }
      if (this.isCalculateLocalPosition_)
        this.transform.localPosition = this.posOrigin + vector3;
      foreach (Transform child in this.transform.GetChildren())
        child.localPosition -= vector3;
    }
  }
}
