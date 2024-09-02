// Decompiled with JetBrains decompiler
// Type: UIPanel
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/NGUI Panel")]
public class UIPanel : UIRect
{
  public static BetterList<UIPanel> list = new BetterList<UIPanel>();
  public UIPanel.OnGeometryUpdated onGeometryUpdated;
  public bool showInPanelTool = true;
  public bool generateNormals;
  public bool widgetsAreStatic;
  public bool cullWhileDragging;
  public bool alwaysOnScreen;
  public bool anchorOffset;
  public UIPanel.RenderQueue renderQueue;
  public int startingRenderQueue = 3000;
  [NonSerialized]
  public BetterList<UIWidget> widgets = new BetterList<UIWidget>();
  [NonSerialized]
  public BetterList<UIDrawCall> drawCalls = new BetterList<UIDrawCall>();
  [NonSerialized]
  public Matrix4x4 worldToLocal = Matrix4x4.identity;
  public UIPanel.OnClippingMoved onClipMove;
  [SerializeField]
  [HideInInspector]
  private float mAlpha = 1f;
  [SerializeField]
  [HideInInspector]
  private UIDrawCall.Clipping mClipping;
  [SerializeField]
  [HideInInspector]
  private Vector4 mClipRange = new Vector4(0.0f, 0.0f, 300f, 200f);
  [HideInInspector]
  [SerializeField]
  private Vector2 mClipSoftness = new Vector2(4f, 4f);
  [HideInInspector]
  [SerializeField]
  private int mDepth;
  [SerializeField]
  [HideInInspector]
  private int mSortingOrder;
  private bool mRebuild;
  private bool mResized;
  private Camera mCam;
  [SerializeField]
  private Vector2 mClipOffset = Vector2.zero;
  private float mCullTime;
  private float mUpdateTime;
  private int mMatrixFrame = -1;
  private int mAlphaFrameID;
  private int mLayer = -1;
  private static float[] mTemp = new float[4];
  private Vector2 mMin = Vector2.zero;
  private Vector2 mMax = Vector2.zero;
  private bool mHalfPixelOffset;
  private bool mSortWidgets;
  private static Vector3[] mCorners = new Vector3[4];
  private static int mUpdateFrame = -1;
  private bool mForced;

  public static int nextUnusedDepth
  {
    get
    {
      int num = int.MinValue;
      for (int i = 0; i < UIPanel.list.size; ++i)
        num = Mathf.Max(num, UIPanel.list[i].depth);
      return num == int.MinValue ? 0 : num + 1;
    }
  }

  public override bool canBeAnchored => this.mClipping != UIDrawCall.Clipping.None;

  public override float alpha
  {
    get => this.mAlpha;
    set
    {
      float num = Mathf.Clamp01(value);
      if ((double) this.mAlpha == (double) num)
        return;
      this.mAlphaFrameID = -1;
      this.mResized = true;
      this.mAlpha = num;
      this.SetDirty();
    }
  }

  public int depth
  {
    get => this.mDepth;
    set
    {
      if (this.mDepth == value)
        return;
      this.mDepth = value;
      UIPanel.list.Sort(new BetterList<UIPanel>.CompareFunc(UIPanel.CompareFunc));
    }
  }

  public int sortingOrder
  {
    get => this.mSortingOrder;
    set
    {
      if (this.mSortingOrder == value)
        return;
      this.mSortingOrder = value;
      this.UpdateDrawCalls();
    }
  }

  public static int CompareFunc(UIPanel a, UIPanel b)
  {
    if (!Object.op_Inequality((Object) a, (Object) b) || !Object.op_Inequality((Object) a, (Object) null) || !Object.op_Inequality((Object) b, (Object) null))
      return 0;
    return a.mDepth < b.mDepth || a.mDepth <= b.mDepth && ((Object) a).GetInstanceID() < ((Object) b).GetInstanceID() ? -1 : 1;
  }

  public float width => this.GetViewSize().x;

  public float height => this.GetViewSize().y;

  public bool halfPixelOffset => this.mHalfPixelOffset;

  public bool usedForUI
  {
    get => Object.op_Inequality((Object) this.mCam, (Object) null) && this.mCam.orthographic;
  }

  public Vector3 drawCallOffset
  {
    get
    {
      if (!this.mHalfPixelOffset || !Object.op_Inequality((Object) this.mCam, (Object) null) || !this.mCam.orthographic)
        return Vector3.zero;
      float num = 1f / this.GetWindowSize().y / this.mCam.orthographicSize;
      return new Vector3(-num, num);
    }
  }

  public UIDrawCall.Clipping clipping
  {
    get => this.mClipping;
    set
    {
      if (this.mClipping == value)
        return;
      this.mResized = true;
      this.mClipping = value;
      this.mMatrixFrame = -1;
    }
  }

  public bool clipsChildren
  {
    get
    {
      return this.mClipping == UIDrawCall.Clipping.AlphaClip || this.mClipping == UIDrawCall.Clipping.SoftClip;
    }
  }

  public Vector2 clipOffset
  {
    get => this.mClipOffset;
    set
    {
      if ((double) Mathf.Abs(this.mClipOffset.x - value.x) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipOffset.y - value.y) <= 1.0 / 1000.0)
        return;
      this.mResized = true;
      this.mCullTime = (double) this.mCullTime != 0.0 ? RealTime.time + 0.15f : 1f / 1000f;
      this.mClipOffset = value;
      this.mMatrixFrame = -1;
      if (this.onClipMove == null)
        return;
      this.onClipMove(this);
    }
  }

  [Obsolete("Use 'finalClipRegion' or 'baseClipRegion' instead")]
  public Vector4 clipRange
  {
    get => this.baseClipRegion;
    set => this.baseClipRegion = value;
  }

  public Vector4 baseClipRegion
  {
    get => this.mClipRange;
    set
    {
      if ((double) Mathf.Abs(this.mClipRange.x - value.x) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.y - value.y) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.z - value.z) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.w - value.w) <= 1.0 / 1000.0)
        return;
      this.mResized = true;
      this.mCullTime = (double) this.mCullTime != 0.0 ? RealTime.time + 0.15f : 1f / 1000f;
      this.mClipRange = value;
      this.mMatrixFrame = -1;
      UIScrollView component = ((Component) this).GetComponent<UIScrollView>();
      if (Object.op_Inequality((Object) component, (Object) null))
        component.UpdatePosition();
      if (this.onClipMove == null)
        return;
      this.onClipMove(this);
    }
  }

  public Vector4 finalClipRegion
  {
    get
    {
      Vector2 viewSize = this.GetViewSize();
      return this.mClipping != UIDrawCall.Clipping.None ? new Vector4(this.mClipRange.x + this.mClipOffset.x, this.mClipRange.y + this.mClipOffset.y, viewSize.x, viewSize.y) : new Vector4(0.0f, 0.0f, viewSize.x, viewSize.y);
    }
  }

  public Vector2 clipSoftness
  {
    get => this.mClipSoftness;
    set
    {
      if (!Vector2.op_Inequality(this.mClipSoftness, value))
        return;
      this.mClipSoftness = value;
    }
  }

  public override Vector3[] localCorners
  {
    get
    {
      if (this.mClipping == UIDrawCall.Clipping.None)
      {
        Vector2 viewSize = this.GetViewSize();
        float num1 = -0.5f * viewSize.x;
        float num2 = -0.5f * viewSize.y;
        float num3 = num1 + viewSize.x;
        float num4 = num2 + viewSize.y;
        Transform transform = !Object.op_Inequality((Object) this.mCam, (Object) null) ? (Transform) null : ((Component) this.mCam).transform;
        if (Object.op_Inequality((Object) transform, (Object) null))
        {
          UIPanel.mCorners[0] = transform.TransformPoint(num1, num2, 0.0f);
          UIPanel.mCorners[1] = transform.TransformPoint(num1, num4, 0.0f);
          UIPanel.mCorners[2] = transform.TransformPoint(num3, num4, 0.0f);
          UIPanel.mCorners[3] = transform.TransformPoint(num3, num2, 0.0f);
          Transform cachedTransform = this.cachedTransform;
          for (int index = 0; index < 4; ++index)
            UIPanel.mCorners[index] = cachedTransform.InverseTransformPoint(UIPanel.mCorners[index]);
        }
        else
        {
          UIPanel.mCorners[0] = new Vector3(num1, num2);
          UIPanel.mCorners[1] = new Vector3(num1, num4);
          UIPanel.mCorners[2] = new Vector3(num3, num4);
          UIPanel.mCorners[3] = new Vector3(num3, num2);
        }
      }
      else
      {
        float num5 = (float) ((double) this.mClipOffset.x + (double) this.mClipRange.x - 0.5 * (double) this.mClipRange.z);
        float num6 = (float) ((double) this.mClipOffset.y + (double) this.mClipRange.y - 0.5 * (double) this.mClipRange.w);
        float num7 = num5 + this.mClipRange.z;
        float num8 = num6 + this.mClipRange.w;
        UIPanel.mCorners[0] = new Vector3(num5, num6);
        UIPanel.mCorners[1] = new Vector3(num5, num8);
        UIPanel.mCorners[2] = new Vector3(num7, num8);
        UIPanel.mCorners[3] = new Vector3(num7, num6);
      }
      return UIPanel.mCorners;
    }
  }

  public override Vector3[] worldCorners
  {
    get
    {
      if (this.mClipping == UIDrawCall.Clipping.None)
      {
        Vector2 viewSize = this.GetViewSize();
        float num1 = -0.5f * viewSize.x;
        float num2 = -0.5f * viewSize.y;
        float num3 = num1 + viewSize.x;
        float num4 = num2 + viewSize.y;
        Transform transform = !Object.op_Inequality((Object) this.mCam, (Object) null) ? (Transform) null : ((Component) this.mCam).transform;
        if (Object.op_Inequality((Object) transform, (Object) null))
        {
          UIPanel.mCorners[0] = transform.TransformPoint(num1, num2, 0.0f);
          UIPanel.mCorners[1] = transform.TransformPoint(num1, num4, 0.0f);
          UIPanel.mCorners[2] = transform.TransformPoint(num3, num4, 0.0f);
          UIPanel.mCorners[3] = transform.TransformPoint(num3, num2, 0.0f);
        }
      }
      else
      {
        float num5 = (float) ((double) this.mClipOffset.x + (double) this.mClipRange.x - 0.5 * (double) this.mClipRange.z);
        float num6 = (float) ((double) this.mClipOffset.y + (double) this.mClipRange.y - 0.5 * (double) this.mClipRange.w);
        float num7 = num5 + this.mClipRange.z;
        float num8 = num6 + this.mClipRange.w;
        Transform cachedTransform = this.cachedTransform;
        UIPanel.mCorners[0] = cachedTransform.TransformPoint(num5, num6, 0.0f);
        UIPanel.mCorners[1] = cachedTransform.TransformPoint(num5, num8, 0.0f);
        UIPanel.mCorners[2] = cachedTransform.TransformPoint(num7, num8, 0.0f);
        UIPanel.mCorners[3] = cachedTransform.TransformPoint(num7, num6, 0.0f);
      }
      return UIPanel.mCorners;
    }
  }

  public override Vector3[] GetSides(Transform relativeTo)
  {
    if (this.mClipping == UIDrawCall.Clipping.None && !this.anchorOffset)
      return base.GetSides(relativeTo);
    Vector2 viewSize = this.GetViewSize();
    Vector2 vector2 = this.mClipping == UIDrawCall.Clipping.None ? Vector2.zero : Vector2.op_Addition(Vector4.op_Implicit(this.mClipRange), this.mClipOffset);
    float num1 = vector2.x - 0.5f * viewSize.x;
    float num2 = vector2.y - 0.5f * viewSize.y;
    float num3 = num1 + viewSize.x;
    float num4 = num2 + viewSize.y;
    float num5 = (float) (((double) num1 + (double) num3) * 0.5);
    float num6 = (float) (((double) num2 + (double) num4) * 0.5);
    Matrix4x4 localToWorldMatrix = this.cachedTransform.localToWorldMatrix;
    UIPanel.mCorners[0] = ((Matrix4x4) ref localToWorldMatrix).MultiplyPoint3x4(new Vector3(num1, num6));
    UIPanel.mCorners[1] = ((Matrix4x4) ref localToWorldMatrix).MultiplyPoint3x4(new Vector3(num5, num4));
    UIPanel.mCorners[2] = ((Matrix4x4) ref localToWorldMatrix).MultiplyPoint3x4(new Vector3(num3, num6));
    UIPanel.mCorners[3] = ((Matrix4x4) ref localToWorldMatrix).MultiplyPoint3x4(new Vector3(num5, num2));
    if (Object.op_Inequality((Object) relativeTo, (Object) null))
    {
      for (int index = 0; index < 4; ++index)
        UIPanel.mCorners[index] = relativeTo.InverseTransformPoint(UIPanel.mCorners[index]);
    }
    return UIPanel.mCorners;
  }

  public override void Invalidate(bool includeChildren)
  {
    this.mAlphaFrameID = -1;
    base.Invalidate(includeChildren);
  }

  public override float CalculateFinalAlpha(int frameID)
  {
    if (this.mAlphaFrameID != frameID)
    {
      this.mAlphaFrameID = frameID;
      UIRect parent = this.parent;
      this.finalAlpha = !Object.op_Inequality((Object) this.parent, (Object) null) ? this.mAlpha : parent.CalculateFinalAlpha(frameID) * this.mAlpha;
    }
    return this.finalAlpha;
  }

  public bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
  {
    this.UpdateTransformMatrix();
    a = ((Matrix4x4) ref this.worldToLocal).MultiplyPoint3x4(a);
    b = ((Matrix4x4) ref this.worldToLocal).MultiplyPoint3x4(b);
    c = ((Matrix4x4) ref this.worldToLocal).MultiplyPoint3x4(c);
    d = ((Matrix4x4) ref this.worldToLocal).MultiplyPoint3x4(d);
    UIPanel.mTemp[0] = a.x;
    UIPanel.mTemp[1] = b.x;
    UIPanel.mTemp[2] = c.x;
    UIPanel.mTemp[3] = d.x;
    float num1 = Mathf.Min(UIPanel.mTemp);
    float num2 = Mathf.Max(UIPanel.mTemp);
    UIPanel.mTemp[0] = a.y;
    UIPanel.mTemp[1] = b.y;
    UIPanel.mTemp[2] = c.y;
    UIPanel.mTemp[3] = d.y;
    float num3 = Mathf.Min(UIPanel.mTemp);
    float num4 = Mathf.Max(UIPanel.mTemp);
    return (double) num2 >= (double) this.mMin.x && (double) num4 >= (double) this.mMin.y && (double) num1 <= (double) this.mMax.x && (double) num3 <= (double) this.mMax.y;
  }

  public bool IsVisible(Vector3 worldPos)
  {
    if ((double) this.mAlpha < 1.0 / 1000.0)
      return false;
    if (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
      return true;
    this.UpdateTransformMatrix();
    Vector3 vector3 = ((Matrix4x4) ref this.worldToLocal).MultiplyPoint3x4(worldPos);
    return (double) vector3.x >= (double) this.mMin.x && (double) vector3.y >= (double) this.mMin.y && (double) vector3.x <= (double) this.mMax.x && (double) vector3.y <= (double) this.mMax.y;
  }

  public bool IsVisible(UIWidget w)
  {
    if ((this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip) && !w.hideIfOffScreen)
      return true;
    Vector3[] worldCorners = w.worldCorners;
    return this.IsVisible(worldCorners[0], worldCorners[1], worldCorners[2], worldCorners[3]);
  }

  [ContextMenu("Force Refresh")]
  public void RebuildAllDrawCalls() => this.mRebuild = true;

  public void SetDirty()
  {
    for (int index = 0; index < this.drawCalls.size; ++index)
      this.drawCalls.buffer[index].isDirty = true;
    this.Invalidate(true);
  }

  private void Awake()
  {
    this.mGo = ((Component) this).gameObject;
    this.mTrans = ((Component) this).transform;
    this.mHalfPixelOffset = Application.platform == 2 || Application.platform == 10 || Application.platform == 5 || Application.platform == 7;
    if (!this.mHalfPixelOffset)
      return;
    this.mHalfPixelOffset = SystemInfo.graphicsShaderLevel < 40;
  }

  protected override void OnStart()
  {
    this.mLayer = this.mGo.layer;
    UICamera cameraForLayer = UICamera.FindCameraForLayer(this.mLayer);
    this.mCam = !Object.op_Inequality((Object) cameraForLayer, (Object) null) ? NGUITools.FindCameraForLayer(this.mLayer) : cameraForLayer.cachedCamera;
  }

  protected override void OnInit()
  {
    base.OnInit();
    if (Object.op_Equality((Object) ((Component) this).GetComponent<Rigidbody>(), (Object) null))
    {
      Rigidbody rigidbody = ((Component) this).gameObject.AddComponent<Rigidbody>();
      rigidbody.isKinematic = true;
      rigidbody.useGravity = false;
    }
    this.mRebuild = true;
    this.mAlphaFrameID = -1;
    this.mMatrixFrame = -1;
    UIPanel.list.Add(this);
    UIPanel.list.Sort(new BetterList<UIPanel>.CompareFunc(UIPanel.CompareFunc));
  }

  protected override void OnDisable()
  {
    for (int index = 0; index < this.drawCalls.size; ++index)
    {
      UIDrawCall dc = this.drawCalls.buffer[index];
      if (Object.op_Inequality((Object) dc, (Object) null))
        UIDrawCall.Destroy(dc);
    }
    this.drawCalls.Clear();
    UIPanel.list.Remove(this);
    this.mAlphaFrameID = -1;
    this.mMatrixFrame = -1;
    if (UIPanel.list.size == 0)
    {
      UIDrawCall.ReleaseAll();
      UIPanel.mUpdateFrame = -1;
    }
    base.OnDisable();
  }

  private void UpdateTransformMatrix()
  {
    int frameCount = Time.frameCount;
    if (this.mMatrixFrame == frameCount)
      return;
    this.mMatrixFrame = frameCount;
    this.worldToLocal = this.cachedTransform.worldToLocalMatrix;
    Vector2 vector2 = Vector2.op_Multiply(this.GetViewSize(), 0.5f);
    float num1 = this.mClipOffset.x + this.mClipRange.x;
    float num2 = this.mClipOffset.y + this.mClipRange.y;
    this.mMin.x = num1 - vector2.x;
    this.mMin.y = num2 - vector2.y;
    this.mMax.x = num1 + vector2.x;
    this.mMax.y = num2 + vector2.y;
  }

  protected override void OnAnchor()
  {
    if (this.mClipping == UIDrawCall.Clipping.None)
      return;
    Transform cachedTransform = this.cachedTransform;
    Transform parent = cachedTransform.parent;
    Vector2 viewSize = this.GetViewSize();
    Vector2 vector2_1 = Vector2.op_Implicit(cachedTransform.localPosition);
    float num1;
    float num2;
    float num3;
    float num4;
    if (Object.op_Equality((Object) this.leftAnchor.target, (Object) this.bottomAnchor.target) && Object.op_Equality((Object) this.leftAnchor.target, (Object) this.rightAnchor.target) && Object.op_Equality((Object) this.leftAnchor.target, (Object) this.topAnchor.target))
    {
      Vector3[] sides = this.leftAnchor.GetSides(parent);
      if (sides != null)
      {
        num1 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
        num2 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
        num3 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
        num4 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
      }
      else
      {
        Vector2 vector2_2 = Vector2.op_Implicit(this.GetLocalPos(this.leftAnchor, parent));
        num1 = vector2_2.x + (float) this.leftAnchor.absolute;
        num3 = vector2_2.y + (float) this.bottomAnchor.absolute;
        num2 = vector2_2.x + (float) this.rightAnchor.absolute;
        num4 = vector2_2.y + (float) this.topAnchor.absolute;
      }
    }
    else
    {
      if (Object.op_Implicit((Object) this.leftAnchor.target))
      {
        Vector3[] sides = this.leftAnchor.GetSides(parent);
        num1 = sides == null ? this.GetLocalPos(this.leftAnchor, parent).x + (float) this.leftAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
      }
      else
        num1 = this.mClipRange.x - 0.5f * viewSize.x;
      if (Object.op_Implicit((Object) this.rightAnchor.target))
      {
        Vector3[] sides = this.rightAnchor.GetSides(parent);
        num2 = sides == null ? this.GetLocalPos(this.rightAnchor, parent).x + (float) this.rightAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
      }
      else
        num2 = this.mClipRange.x + 0.5f * viewSize.x;
      if (Object.op_Implicit((Object) this.bottomAnchor.target))
      {
        Vector3[] sides = this.bottomAnchor.GetSides(parent);
        num3 = sides == null ? this.GetLocalPos(this.bottomAnchor, parent).y + (float) this.bottomAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
      }
      else
        num3 = this.mClipRange.y - 0.5f * viewSize.y;
      if (Object.op_Implicit((Object) this.topAnchor.target))
      {
        Vector3[] sides = this.topAnchor.GetSides(parent);
        num4 = sides == null ? this.GetLocalPos(this.topAnchor, parent).y + (float) this.topAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
      }
      else
        num4 = this.mClipRange.y + 0.5f * viewSize.y;
    }
    float num5 = num1 - (vector2_1.x + this.mClipOffset.x);
    float num6 = num2 - (vector2_1.x + this.mClipOffset.x);
    float num7 = num3 - (vector2_1.y + this.mClipOffset.y);
    float num8 = num4 - (vector2_1.y + this.mClipOffset.y);
    float num9 = Mathf.Lerp(num5, num6, 0.5f);
    float num10 = Mathf.Lerp(num7, num8, 0.5f);
    float num11 = num6 - num5;
    float num12 = num8 - num7;
    float num13 = Mathf.Max(20f, this.mClipSoftness.x);
    float num14 = Mathf.Max(20f, this.mClipSoftness.y);
    if ((double) num11 < (double) num13)
      num11 = num13;
    if ((double) num12 < (double) num14)
      num12 = num14;
    this.baseClipRegion = new Vector4(num9, num10, num11, num12);
  }

  private void LateUpdate()
  {
    if (UIPanel.mUpdateFrame == Time.frameCount)
      return;
    UIPanel.mUpdateFrame = Time.frameCount;
    for (int i = 0; i < UIPanel.list.size; ++i)
      UIPanel.list[i].UpdateSelf();
    int num = 3000;
    for (int index = 0; index < UIPanel.list.size; ++index)
    {
      UIPanel uiPanel = UIPanel.list.buffer[index];
      if (uiPanel.renderQueue == UIPanel.RenderQueue.Automatic)
      {
        uiPanel.startingRenderQueue = num;
        uiPanel.UpdateDrawCalls();
        num += uiPanel.drawCalls.size;
      }
      else if (uiPanel.renderQueue == UIPanel.RenderQueue.StartAt)
      {
        uiPanel.UpdateDrawCalls();
        if (uiPanel.drawCalls.size != 0)
          num = Mathf.Max(num, uiPanel.startingRenderQueue + uiPanel.drawCalls.size);
      }
      else
      {
        uiPanel.UpdateDrawCalls();
        if (uiPanel.drawCalls.size != 0)
          num = Mathf.Max(num, uiPanel.startingRenderQueue + 1);
      }
    }
  }

  private void UpdateSelf()
  {
    this.mUpdateTime = RealTime.time;
    this.UpdateTransformMatrix();
    this.UpdateLayers();
    this.UpdateWidgets();
    if (this.mRebuild)
    {
      this.mRebuild = false;
      this.FillAllDrawCalls();
    }
    else
    {
      int index = 0;
      while (index < this.drawCalls.size)
      {
        UIDrawCall dc = this.drawCalls.buffer[index];
        if (dc.isDirty && !this.FillDrawCall(dc))
        {
          UIDrawCall.Destroy(dc);
          this.drawCalls.RemoveAt(index);
        }
        else
          ++index;
      }
    }
  }

  public void SortWidgets()
  {
    this.mSortWidgets = false;
    this.widgets.Sort(new BetterList<UIWidget>.CompareFunc(UIWidget.PanelCompareFunc));
  }

  private void FillAllDrawCalls()
  {
    for (int index = 0; index < this.drawCalls.size; ++index)
      UIDrawCall.Destroy(this.drawCalls.buffer[index]);
    this.drawCalls.Clear();
    Material mat = (Material) null;
    Texture tex = (Texture) null;
    Shader shader1 = (Shader) null;
    UIDrawCall uiDrawCall = (UIDrawCall) null;
    if (this.mSortWidgets)
      this.SortWidgets();
    for (int index = 0; index < this.widgets.size; ++index)
    {
      UIWidget uiWidget = this.widgets.buffer[index];
      if (uiWidget.isVisible && uiWidget.hasVertices)
      {
        Material material = uiWidget.material;
        Texture mainTexture = uiWidget.mainTexture;
        Shader shader2 = uiWidget.shader;
        if (Object.op_Inequality((Object) mat, (Object) material) || Object.op_Inequality((Object) tex, (Object) mainTexture) || Object.op_Inequality((Object) shader1, (Object) shader2))
        {
          if (Object.op_Inequality((Object) uiDrawCall, (Object) null) && uiDrawCall.verts.size != 0)
          {
            this.drawCalls.Add(uiDrawCall);
            uiDrawCall.UpdateGeometry();
            uiDrawCall = (UIDrawCall) null;
          }
          mat = material;
          tex = mainTexture;
          shader1 = shader2;
        }
        if (Object.op_Inequality((Object) mat, (Object) null) || Object.op_Inequality((Object) shader1, (Object) null) || Object.op_Inequality((Object) tex, (Object) null))
        {
          if (Object.op_Equality((Object) uiDrawCall, (Object) null))
          {
            uiDrawCall = UIDrawCall.Create(this, mat, tex, shader1);
            uiDrawCall.depthStart = uiWidget.depth;
            uiDrawCall.depthEnd = uiDrawCall.depthStart;
            uiDrawCall.panel = this;
          }
          else
          {
            int depth = uiWidget.depth;
            if (depth < uiDrawCall.depthStart)
              uiDrawCall.depthStart = depth;
            if (depth > uiDrawCall.depthEnd)
              uiDrawCall.depthEnd = depth;
          }
          uiWidget.drawCall = uiDrawCall;
          if (this.generateNormals)
            uiWidget.WriteToBuffers(uiDrawCall.verts, uiDrawCall.uvs, uiDrawCall.cols, uiDrawCall.norms, uiDrawCall.tans);
          else
            uiWidget.WriteToBuffers(uiDrawCall.verts, uiDrawCall.uvs, uiDrawCall.cols, (BetterList<Vector3>) null, (BetterList<Vector4>) null);
        }
      }
      else
        uiWidget.drawCall = (UIDrawCall) null;
    }
    if (!Object.op_Inequality((Object) uiDrawCall, (Object) null) || uiDrawCall.verts.size == 0)
      return;
    this.drawCalls.Add(uiDrawCall);
    uiDrawCall.UpdateGeometry();
  }

  private bool FillDrawCall(UIDrawCall dc)
  {
    if (Object.op_Inequality((Object) dc, (Object) null))
    {
      dc.isDirty = false;
      int num = 0;
      while (num < this.widgets.size)
      {
        UIWidget widget = this.widgets[num];
        if (Object.op_Equality((Object) widget, (Object) null))
        {
          this.widgets.RemoveAt(num);
        }
        else
        {
          if (Object.op_Equality((Object) widget.drawCall, (Object) dc))
          {
            if (widget.isVisible && widget.hasVertices)
            {
              if (this.generateNormals)
                widget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans);
              else
                widget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, (BetterList<Vector3>) null, (BetterList<Vector4>) null);
            }
            else
              widget.drawCall = (UIDrawCall) null;
          }
          ++num;
        }
      }
      if (dc.verts.size != 0)
      {
        dc.UpdateGeometry();
        return true;
      }
    }
    return false;
  }

  private void UpdateDrawCalls()
  {
    Transform cachedTransform1 = this.cachedTransform;
    Vector4 zero = Vector4.zero;
    bool usedForUi = this.usedForUI;
    if (this.clipping != UIDrawCall.Clipping.None)
    {
      Vector4 finalClipRegion = this.finalClipRegion;
      // ISSUE: explicit constructor call
      ((Vector4) ref zero).\u002Ector(finalClipRegion.x, finalClipRegion.y, finalClipRegion.z * 0.5f, finalClipRegion.w * 0.5f);
    }
    if ((double) zero.z == 0.0)
      zero.z = (float) Screen.width * 0.5f;
    if ((double) zero.w == 0.0)
      zero.w = (float) Screen.height * 0.5f;
    if (this.halfPixelOffset)
    {
      zero.x -= 0.5f;
      zero.y += 0.5f;
    }
    Vector3 vector3;
    if (usedForUi)
    {
      Transform parent = this.cachedTransform.parent;
      vector3 = this.cachedTransform.localPosition;
      if (Object.op_Inequality((Object) parent, (Object) null))
      {
        float num1 = Mathf.Round(vector3.x);
        float num2 = Mathf.Round(vector3.y);
        zero.x += vector3.x - num1;
        zero.y += vector3.y - num2;
        vector3.x = num1;
        vector3.y = num2;
        vector3 = parent.TransformPoint(vector3);
      }
      vector3 = Vector3.op_Addition(vector3, this.drawCallOffset);
    }
    else
      vector3 = cachedTransform1.position;
    Quaternion rotation = cachedTransform1.rotation;
    Vector3 lossyScale = cachedTransform1.lossyScale;
    for (int index = 0; index < this.drawCalls.size; ++index)
    {
      UIDrawCall uiDrawCall = this.drawCalls.buffer[index];
      Transform cachedTransform2 = uiDrawCall.cachedTransform;
      cachedTransform2.position = vector3;
      cachedTransform2.rotation = rotation;
      cachedTransform2.localScale = lossyScale;
      uiDrawCall.renderQueue = this.renderQueue != UIPanel.RenderQueue.Explicit ? this.startingRenderQueue + index : this.startingRenderQueue;
      uiDrawCall.clipping = this.clipping;
      uiDrawCall.clipRange = zero;
      uiDrawCall.clipSoftness = this.mClipSoftness;
      uiDrawCall.alwaysOnScreen = this.alwaysOnScreen && (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip);
      uiDrawCall.sortingOrder = this.mSortingOrder;
    }
  }

  private void UpdateLayers()
  {
    if (this.mLayer == this.cachedGameObject.layer)
      return;
    this.mLayer = this.mGo.layer;
    UICamera cameraForLayer = UICamera.FindCameraForLayer(this.mLayer);
    this.mCam = !Object.op_Inequality((Object) cameraForLayer, (Object) null) ? NGUITools.FindCameraForLayer(this.mLayer) : cameraForLayer.cachedCamera;
    NGUITools.SetChildLayer(this.cachedTransform, this.mLayer);
    for (int index = 0; index < this.drawCalls.size; ++index)
      ((Component) this.drawCalls.buffer[index]).gameObject.layer = this.mLayer;
  }

  private void UpdateWidgets()
  {
    bool flag1 = !this.cullWhileDragging && (double) this.mCullTime > (double) this.mUpdateTime;
    bool flag2 = false;
    if (this.mForced != flag1)
    {
      this.mForced = flag1;
      this.mResized = true;
    }
    bool clipsChildren = this.clipsChildren;
    int index = 0;
    for (int size = this.widgets.size; index < size; ++index)
    {
      UIWidget w = this.widgets.buffer[index];
      if (Object.op_Equality((Object) w.panel, (Object) this) && ((Behaviour) w).enabled)
      {
        int frameCount = Time.frameCount;
        if (w.UpdateTransform(frameCount) || this.mResized || (double) w.CalculateCumulativeAlpha(frameCount) > 1.0 / 1000.0)
        {
          bool visibleByAlpha = flag1 || (double) w.CalculateCumulativeAlpha(frameCount) > 1.0 / 1000.0;
          w.UpdateVisibility(visibleByAlpha, flag1 || !clipsChildren && !w.hideIfOffScreen || this.IsVisible(w));
        }
        if (w.UpdateGeometry(frameCount))
        {
          flag2 = true;
          if (!this.mRebuild)
          {
            if (Object.op_Inequality((Object) w.drawCall, (Object) null))
              w.drawCall.isDirty = true;
            else
              this.FindDrawCall(w);
          }
        }
      }
    }
    if (flag2 && this.onGeometryUpdated != null)
      this.onGeometryUpdated();
    this.mResized = false;
  }

  public UIDrawCall FindDrawCall(UIWidget w)
  {
    Material material = w.material;
    Texture mainTexture = w.mainTexture;
    int depth = w.depth;
    for (int index = 0; index < this.drawCalls.size; ++index)
    {
      UIDrawCall drawCall = this.drawCalls.buffer[index];
      int num1 = index != 0 ? this.drawCalls.buffer[index - 1].depthEnd + 1 : int.MinValue;
      int num2 = index + 1 != this.drawCalls.size ? this.drawCalls.buffer[index + 1].depthStart - 1 : int.MaxValue;
      if (num1 <= depth && num2 >= depth)
      {
        if (Object.op_Equality((Object) drawCall.baseMaterial, (Object) material) && Object.op_Equality((Object) drawCall.mainTexture, (Object) mainTexture))
        {
          if (w.isVisible)
          {
            w.drawCall = drawCall;
            if (w.hasVertices)
              drawCall.isDirty = true;
            return drawCall;
          }
        }
        else
          this.mRebuild = true;
        return (UIDrawCall) null;
      }
    }
    this.mRebuild = true;
    return (UIDrawCall) null;
  }

  public void AddWidget(UIWidget w)
  {
    if (this.widgets.size == 0)
      this.widgets.Add(w);
    else if (this.mSortWidgets)
    {
      this.widgets.Add(w);
      this.SortWidgets();
    }
    else if (UIWidget.PanelCompareFunc(w, this.widgets[0]) == -1)
    {
      this.widgets.Insert(0, w);
    }
    else
    {
      int size = this.widgets.size;
      while (size > 0)
      {
        if (UIWidget.PanelCompareFunc(w, this.widgets[--size]) != -1)
        {
          this.widgets.Insert(size + 1, w);
          break;
        }
      }
    }
    this.FindDrawCall(w);
  }

  public void RemoveWidget(UIWidget w)
  {
    if (!this.widgets.Remove(w) || !Object.op_Inequality((Object) w.drawCall, (Object) null))
      return;
    int depth = w.depth;
    if (depth == w.drawCall.depthStart || depth == w.drawCall.depthEnd)
      this.mRebuild = true;
    w.drawCall.isDirty = true;
    w.drawCall = (UIDrawCall) null;
  }

  public void Refresh()
  {
    this.mRebuild = true;
    if (UIPanel.list.size <= 0)
      return;
    UIPanel.list[0].LateUpdate();
  }

  public virtual Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
  {
    Vector4 finalClipRegion = this.finalClipRegion;
    float num1 = finalClipRegion.z * 0.5f;
    float num2 = finalClipRegion.w * 0.5f;
    Vector2 minRect;
    // ISSUE: explicit constructor call
    ((Vector2) ref minRect).\u002Ector(min.x, min.y);
    Vector2 maxRect;
    // ISSUE: explicit constructor call
    ((Vector2) ref maxRect).\u002Ector(max.x, max.y);
    Vector2 minArea;
    // ISSUE: explicit constructor call
    ((Vector2) ref minArea).\u002Ector(finalClipRegion.x - num1, finalClipRegion.y - num2);
    Vector2 maxArea;
    // ISSUE: explicit constructor call
    ((Vector2) ref maxArea).\u002Ector(finalClipRegion.x + num1, finalClipRegion.y + num2);
    if (this.clipping == UIDrawCall.Clipping.SoftClip)
    {
      minArea.x += this.clipSoftness.x;
      minArea.y += this.clipSoftness.y;
      maxArea.x -= this.clipSoftness.x;
      maxArea.y -= this.clipSoftness.y;
    }
    return Vector2.op_Implicit(NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea));
  }

  public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
  {
    Vector3 constrainOffset = this.CalculateConstrainOffset(Vector2.op_Implicit(((Bounds) ref targetBounds).min), Vector2.op_Implicit(((Bounds) ref targetBounds).max));
    if ((double) ((Vector3) ref constrainOffset).sqrMagnitude <= 0.0)
      return false;
    if (immediate)
    {
      Transform transform = target;
      transform.localPosition = Vector3.op_Addition(transform.localPosition, constrainOffset);
      ref Bounds local = ref targetBounds;
      ((Bounds) ref local).center = Vector3.op_Addition(((Bounds) ref local).center, constrainOffset);
      SpringPosition component = ((Component) target).GetComponent<SpringPosition>();
      if (Object.op_Inequality((Object) component, (Object) null))
        ((Behaviour) component).enabled = false;
    }
    else
    {
      SpringPosition springPosition = SpringPosition.Begin(((Component) target).gameObject, Vector3.op_Addition(target.localPosition, constrainOffset), 13f);
      springPosition.ignoreTimeScale = true;
      springPosition.worldSpace = false;
    }
    return true;
  }

  public bool ConstrainTargetToBounds(Transform target, bool immediate)
  {
    Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(this.cachedTransform, target);
    return this.ConstrainTargetToBounds(target, ref relativeWidgetBounds, immediate);
  }

  public static UIPanel Find(Transform trans) => UIPanel.Find(trans, false, -1);

  public static UIPanel Find(Transform trans, bool createIfMissing)
  {
    return UIPanel.Find(trans, createIfMissing, -1);
  }

  public static UIPanel Find(Transform trans, bool createIfMissing, int layer)
  {
    for (UIPanel uiPanel = (UIPanel) null; Object.op_Equality((Object) uiPanel, (Object) null) && Object.op_Inequality((Object) trans, (Object) null); trans = trans.parent)
    {
      uiPanel = ((Component) trans).GetComponent<UIPanel>();
      if (Object.op_Inequality((Object) uiPanel, (Object) null))
        return uiPanel;
      if (Object.op_Equality((Object) trans.parent, (Object) null))
        break;
    }
    return createIfMissing ? NGUITools.CreateUI(trans, false, layer) : (UIPanel) null;
  }

  private Vector2 GetWindowSize()
  {
    UIRoot root = this.root;
    Vector2 windowSize;
    // ISSUE: explicit constructor call
    ((Vector2) ref windowSize).\u002Ector((float) Screen.width, (float) Screen.height);
    if (Object.op_Inequality((Object) root, (Object) null))
      windowSize = Vector2.op_Multiply(windowSize, root.GetPixelSizeAdjustment(Screen.height));
    return windowSize;
  }

  public Vector2 GetViewSize()
  {
    bool flag = this.mClipping != UIDrawCall.Clipping.None;
    Vector2 viewSize = !flag ? new Vector2((float) Screen.width, (float) Screen.height) : new Vector2(this.mClipRange.z, this.mClipRange.w);
    if (!flag)
    {
      UIRoot root = this.root;
      if (Object.op_Inequality((Object) root, (Object) null))
        viewSize = Vector2.op_Multiply(viewSize, root.GetPixelSizeAdjustment(Screen.height));
    }
    return viewSize;
  }

  public enum DebugInfo
  {
    None,
    Gizmos,
    Geometry,
  }

  public enum RenderQueue
  {
    Automatic,
    StartAt,
    Explicit,
  }

  public delegate void OnGeometryUpdated();

  public delegate void OnClippingMoved(UIPanel panel);
}
