// Decompiled with JetBrains decompiler
// Type: UIProgressBar
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/NGUI Progress Bar")]
[ExecuteInEditMode]
public class UIProgressBar : UIWidgetContainer
{
  public static UIProgressBar current;
  public UIProgressBar.OnDragFinished onDragFinished;
  public Transform thumb;
  [SerializeField]
  [HideInInspector]
  protected UIWidget mBG;
  [SerializeField]
  [HideInInspector]
  protected UIWidget mFG;
  [HideInInspector]
  [SerializeField]
  protected float mValue = 1f;
  [HideInInspector]
  [SerializeField]
  protected UIProgressBar.FillDirection mFill;
  protected Transform mTrans;
  protected bool mIsDirty;
  protected Camera mCam;
  protected float mOffset;
  public int numberOfSteps;
  public List<EventDelegate> onChange = new List<EventDelegate>();

  public Transform cachedTransform
  {
    get
    {
      if (Object.op_Equality((Object) this.mTrans, (Object) null))
        this.mTrans = ((Component) this).transform;
      return this.mTrans;
    }
  }

  public Camera cachedCamera
  {
    get
    {
      if (Object.op_Equality((Object) this.mCam, (Object) null))
        this.mCam = NGUITools.FindCameraForLayer(((Component) this).gameObject.layer);
      return this.mCam;
    }
  }

  public UIWidget foregroundWidget
  {
    get => this.mFG;
    set
    {
      if (!Object.op_Inequality((Object) this.mFG, (Object) value))
        return;
      this.mFG = value;
      this.mIsDirty = true;
    }
  }

  public UIWidget backgroundWidget
  {
    get => this.mBG;
    set
    {
      if (!Object.op_Inequality((Object) this.mBG, (Object) value))
        return;
      this.mBG = value;
      this.mIsDirty = true;
    }
  }

  public UIProgressBar.FillDirection fillDirection
  {
    get => this.mFill;
    set
    {
      if (this.mFill == value)
        return;
      this.mFill = value;
      this.ForceUpdate();
    }
  }

  public float value
  {
    get
    {
      return this.numberOfSteps > 1 ? Mathf.Round(this.mValue * (float) (this.numberOfSteps - 1)) / (float) (this.numberOfSteps - 1) : this.mValue;
    }
    set
    {
      float num1 = Mathf.Clamp01(value);
      if ((double) this.mValue == (double) num1)
        return;
      float num2 = this.value;
      this.mValue = num1;
      if ((double) num2 == (double) this.value)
        return;
      this.ForceUpdate();
      if (!NGUITools.GetActive((Behaviour) this) || !EventDelegate.IsValid(this.onChange))
        return;
      UIProgressBar.current = this;
      EventDelegate.Execute(this.onChange);
      UIProgressBar.current = (UIProgressBar) null;
    }
  }

  public float alpha
  {
    get
    {
      if (Object.op_Inequality((Object) this.mFG, (Object) null))
        return this.mFG.alpha;
      return Object.op_Inequality((Object) this.mBG, (Object) null) ? this.mBG.alpha : 1f;
    }
    set
    {
      if (Object.op_Inequality((Object) this.mFG, (Object) null))
      {
        this.mFG.alpha = value;
        if (Object.op_Inequality((Object) ((Component) this.mFG).GetComponent<Collider>(), (Object) null))
          ((Component) this.mFG).GetComponent<Collider>().enabled = (double) this.mFG.alpha > 1.0 / 1000.0;
      }
      if (Object.op_Inequality((Object) this.mBG, (Object) null))
      {
        this.mBG.alpha = value;
        if (Object.op_Inequality((Object) ((Component) this.mBG).GetComponent<Collider>(), (Object) null))
          ((Component) this.mBG).GetComponent<Collider>().enabled = (double) this.mBG.alpha > 1.0 / 1000.0;
      }
      if (!Object.op_Inequality((Object) this.thumb, (Object) null))
        return;
      UIWidget component = ((Component) this.thumb).GetComponent<UIWidget>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      component.alpha = value;
      if (!Object.op_Inequality((Object) ((Component) component).GetComponent<Collider>(), (Object) null))
        return;
      ((Component) component).GetComponent<Collider>().enabled = (double) component.alpha > 1.0 / 1000.0;
    }
  }

  protected bool isHorizontal
  {
    get
    {
      return this.mFill == UIProgressBar.FillDirection.LeftToRight || this.mFill == UIProgressBar.FillDirection.RightToLeft;
    }
  }

  protected bool isInverted
  {
    get
    {
      return this.mFill == UIProgressBar.FillDirection.RightToLeft || this.mFill == UIProgressBar.FillDirection.TopToBottom;
    }
  }

  protected void Start()
  {
    this.Upgrade();
    if (Application.isPlaying)
    {
      if (Object.op_Equality((Object) this.mFG, (Object) null))
      {
        Debug.LogWarning((object) "Progress bar needs a foreground widget to work with", (Object) this);
        ((Behaviour) this).enabled = false;
        return;
      }
      if (Object.op_Inequality((Object) this.mBG, (Object) null))
        this.mBG.autoResizeBoxCollider = true;
      this.OnStart();
      if (this.onChange != null)
      {
        UIProgressBar.current = this;
        EventDelegate.Execute(this.onChange);
        UIProgressBar.current = (UIProgressBar) null;
      }
    }
    this.ForceUpdate();
  }

  protected virtual void Upgrade()
  {
  }

  protected virtual void OnStart()
  {
  }

  protected void Update()
  {
    if (!this.mIsDirty)
      return;
    this.ForceUpdate();
  }

  protected void OnValidate()
  {
    if (NGUITools.GetActive((Behaviour) this))
    {
      this.Upgrade();
      this.mIsDirty = true;
      float num = Mathf.Clamp01(this.mValue);
      if ((double) this.mValue != (double) num)
        this.mValue = num;
      if (this.numberOfSteps < 0)
        this.numberOfSteps = 0;
      else if (this.numberOfSteps > 20)
        this.numberOfSteps = 20;
      this.ForceUpdate();
    }
    else
    {
      float num = Mathf.Clamp01(this.mValue);
      if ((double) this.mValue != (double) num)
        this.mValue = num;
      if (this.numberOfSteps < 0)
      {
        this.numberOfSteps = 0;
      }
      else
      {
        if (this.numberOfSteps <= 20)
          return;
        this.numberOfSteps = 20;
      }
    }
  }

  protected float ScreenToValue(Vector2 screenPos)
  {
    Transform cachedTransform = this.cachedTransform;
    Plane plane;
    // ISSUE: explicit constructor call
    ((Plane) ref plane).\u002Ector(Quaternion.op_Multiply(cachedTransform.rotation, Vector3.back), cachedTransform.position);
    Ray ray = this.cachedCamera.ScreenPointToRay(Vector2.op_Implicit(screenPos));
    float num;
    return !((Plane) ref plane).Raycast(ray, ref num) ? this.value : this.LocalToValue(Vector2.op_Implicit(cachedTransform.InverseTransformPoint(((Ray) ref ray).GetPoint(num))));
  }

  protected virtual float LocalToValue(Vector2 localPos)
  {
    if (!Object.op_Inequality((Object) this.mFG, (Object) null))
      return this.value;
    Vector3[] localCorners = this.mFG.localCorners;
    Vector3 vector3 = Vector3.op_Subtraction(localCorners[2], localCorners[0]);
    if (this.isHorizontal)
    {
      float num = (localPos.x - localCorners[0].x) / vector3.x;
      return this.isInverted ? 1f - num : num;
    }
    float num1 = (localPos.y - localCorners[0].y) / vector3.y;
    return this.isInverted ? 1f - num1 : num1;
  }

  public virtual void ForceUpdate()
  {
    this.mIsDirty = false;
    if (Object.op_Inequality((Object) this.mFG, (Object) null))
    {
      UISprite mFg = this.mFG as UISprite;
      if (this.isHorizontal)
      {
        if (Object.op_Inequality((Object) mFg, (Object) null) && mFg.type == UISprite.Type.Filled)
        {
          mFg.fillDirection = UISprite.FillDirection.Horizontal;
          mFg.invert = this.isInverted;
          mFg.fillAmount = this.value;
        }
        else
          this.mFG.drawRegion = !this.isInverted ? new Vector4(0.0f, 0.0f, this.value, 1f) : new Vector4(1f - this.value, 0.0f, 1f, 1f);
      }
      else if (Object.op_Inequality((Object) mFg, (Object) null) && mFg.type == UISprite.Type.Filled)
      {
        mFg.fillDirection = UISprite.FillDirection.Vertical;
        mFg.invert = this.isInverted;
        mFg.fillAmount = this.value;
      }
      else
        this.mFG.drawRegion = !this.isInverted ? new Vector4(0.0f, 0.0f, 1f, this.value) : new Vector4(0.0f, 1f - this.value, 1f, 1f);
    }
    if (!Object.op_Inequality((Object) this.thumb, (Object) null) || !Object.op_Inequality((Object) this.mFG, (Object) null) && !Object.op_Inequality((Object) this.mBG, (Object) null))
      return;
    Vector3[] vector3Array = !Object.op_Inequality((Object) this.mFG, (Object) null) ? this.mBG.localCorners : this.mFG.localCorners;
    Vector4 vector4 = !Object.op_Inequality((Object) this.mFG, (Object) null) ? this.mBG.border : this.mFG.border;
    vector3Array[0].x += vector4.x;
    vector3Array[1].x += vector4.x;
    vector3Array[2].x -= vector4.z;
    vector3Array[3].x -= vector4.z;
    vector3Array[0].y += vector4.y;
    vector3Array[1].y -= vector4.w;
    vector3Array[2].y -= vector4.w;
    vector3Array[3].y += vector4.y;
    Transform transform = !Object.op_Inequality((Object) this.mFG, (Object) null) ? this.mBG.cachedTransform : this.mFG.cachedTransform;
    for (int index = 0; index < 4; ++index)
      vector3Array[index] = transform.TransformPoint(vector3Array[index]);
    if (this.isHorizontal)
      this.SetThumbPosition(Vector3.Lerp(Vector3.Lerp(vector3Array[0], vector3Array[1], 0.5f), Vector3.Lerp(vector3Array[2], vector3Array[3], 0.5f), !this.isInverted ? this.value : 1f - this.value));
    else
      this.SetThumbPosition(Vector3.Lerp(Vector3.Lerp(vector3Array[0], vector3Array[3], 0.5f), Vector3.Lerp(vector3Array[1], vector3Array[2], 0.5f), !this.isInverted ? this.value : 1f - this.value));
  }

  protected void SetThumbPosition(Vector3 worldPos)
  {
    Transform parent = this.thumb.parent;
    if (Object.op_Inequality((Object) parent, (Object) null))
    {
      worldPos = parent.InverseTransformPoint(worldPos);
      worldPos.x = Mathf.Round(worldPos.x);
      worldPos.y = Mathf.Round(worldPos.y);
      worldPos.z = 0.0f;
      if ((double) Vector3.Distance(this.thumb.localPosition, worldPos) <= 1.0 / 1000.0)
        return;
      this.thumb.localPosition = worldPos;
    }
    else
    {
      if ((double) Vector3.Distance(this.thumb.position, worldPos) <= 9.9999997473787516E-06)
        return;
      this.thumb.position = worldPos;
    }
  }

  public enum FillDirection
  {
    LeftToRight,
    RightToLeft,
    BottomToTop,
    TopToBottom,
  }

  public delegate void OnDragFinished();
}
