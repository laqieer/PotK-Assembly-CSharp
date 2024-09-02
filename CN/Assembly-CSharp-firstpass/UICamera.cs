// Decompiled with JetBrains decompiler
// Type: UICamera
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/NGUI Event System (UICamera)")]
[RequireComponent(typeof (Camera))]
[ExecuteInEditMode]
public class UICamera : MonoBehaviour
{
  public static BetterList<UICamera> list = new BetterList<UICamera>();
  public static UICamera.OnScreenResize onScreenResize;
  public UICamera.EventType eventType = UICamera.EventType.UI;
  public LayerMask eventReceiverMask = LayerMask.op_Implicit(-1);
  public bool debug;
  public bool useMouse = true;
  public bool useTouch = true;
  public bool allowMultiTouch = true;
  public bool useKeyboard = true;
  public bool useController = true;
  public bool stickyTooltip = true;
  public float tooltipDelay = 1f;
  public float mouseDragThreshold = 4f;
  public float mouseClickThreshold = 10f;
  public float touchDragThreshold = 40f;
  public float touchClickThreshold = 40f;
  public float rangeDistance = -1f;
  public string scrollAxisName = "Mouse ScrollWheel";
  public string verticalAxisName = "Vertical";
  public string horizontalAxisName = "Horizontal";
  public KeyCode submitKey0 = (KeyCode) 13;
  public KeyCode submitKey1 = (KeyCode) 330;
  public KeyCode cancelKey0 = (KeyCode) 27;
  public KeyCode cancelKey1 = (KeyCode) 331;
  public static UICamera.OnCustomInput onCustomInput;
  public static bool showTooltips = true;
  public static Vector2 lastTouchPosition = Vector2.zero;
  public static RaycastHit lastHit;
  public static UICamera current = (UICamera) null;
  public static Camera currentCamera = (Camera) null;
  public static UICamera.ControlScheme currentScheme = UICamera.ControlScheme.Mouse;
  public static int currentTouchID = -1;
  public static KeyCode currentKey = (KeyCode) 0;
  public static UICamera.MouseOrTouch currentTouch = (UICamera.MouseOrTouch) null;
  public static bool inputHasFocus = false;
  public static GameObject genericEventHandler;
  public static GameObject fallThrough;
  private static GameObject mCurrentSelection = (GameObject) null;
  private static GameObject mNextSelection = (GameObject) null;
  private static UICamera.ControlScheme mNextScheme = UICamera.ControlScheme.Controller;
  private static UICamera.MouseOrTouch[] mMouse = new UICamera.MouseOrTouch[3]
  {
    new UICamera.MouseOrTouch(),
    new UICamera.MouseOrTouch(),
    new UICamera.MouseOrTouch()
  };
  private static GameObject mHover;
  public static UICamera.MouseOrTouch controller = new UICamera.MouseOrTouch();
  private static float mNextEvent = 0.0f;
  private static Dictionary<int, UICamera.MouseOrTouch> mTouches = new Dictionary<int, UICamera.MouseOrTouch>();
  private static int mWidth = 0;
  private static int mHeight = 0;
  private GameObject mTooltip;
  private Camera mCam;
  private float mTooltipTime;
  private float mNextRaycast;
  public static bool isDragging = false;
  public static GameObject hoveredObject;
  private static UICamera.DepthEntry mHit = new UICamera.DepthEntry();
  private static BetterList<UICamera.DepthEntry> mHits = new BetterList<UICamera.DepthEntry>();
  private static RaycastHit mEmpty = new RaycastHit();
  private static Plane m2DPlane = new Plane(Vector3.back, 0.0f);
  private static bool mNotifying = false;

  [Obsolete("Use new OnDragStart / OnDragOver / OnDragOut / OnDragEnd events instead")]
  public bool stickyPress => true;

  public static Ray currentRay
  {
    get
    {
      return Object.op_Inequality((Object) UICamera.currentCamera, (Object) null) && UICamera.currentTouch != null ? UICamera.currentCamera.ScreenPointToRay(Vector2.op_Implicit(UICamera.currentTouch.pos)) : new Ray();
    }
  }

  private bool handlesEvents => Object.op_Equality((Object) UICamera.eventHandler, (Object) this);

  public Camera cachedCamera
  {
    get
    {
      if (Object.op_Equality((Object) this.mCam, (Object) null))
        this.mCam = ((Component) this).GetComponent<Camera>();
      return this.mCam;
    }
  }

  public static GameObject selectedObject
  {
    get => UICamera.mCurrentSelection;
    set => UICamera.SetSelection(value, UICamera.currentScheme);
  }

  public static bool IsPressed(GameObject go)
  {
    for (int index = 0; index < 3; ++index)
    {
      if (Object.op_Equality((Object) UICamera.mMouse[index].pressed, (Object) go))
        return true;
    }
    foreach (KeyValuePair<int, UICamera.MouseOrTouch> mTouch in UICamera.mTouches)
    {
      if (Object.op_Equality((Object) mTouch.Value.pressed, (Object) go))
        return true;
    }
    return Object.op_Equality((Object) UICamera.controller.pressed, (Object) go);
  }

  protected static void SetSelection(GameObject go, UICamera.ControlScheme scheme)
  {
    if (Object.op_Inequality((Object) UICamera.mNextSelection, (Object) null))
    {
      UICamera.mNextSelection = go;
    }
    else
    {
      if (!Object.op_Inequality((Object) UICamera.mCurrentSelection, (Object) go))
        return;
      UICamera.mNextSelection = go;
      UICamera.mNextScheme = scheme;
      if (UICamera.list.size <= 0)
        return;
      UICamera uiCamera = !Object.op_Inequality((Object) UICamera.mNextSelection, (Object) null) ? UICamera.list[0] : UICamera.FindCameraForLayer(UICamera.mNextSelection.layer);
      if (!Object.op_Inequality((Object) uiCamera, (Object) null))
        return;
      uiCamera.StartCoroutine(uiCamera.ChangeSelection());
    }
  }

  [DebuggerHidden]
  private IEnumerator ChangeSelection()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UICamera.\u003CChangeSelection\u003Ec__IteratorA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static int touchCount
  {
    get
    {
      int touchCount = 0;
      foreach (KeyValuePair<int, UICamera.MouseOrTouch> mTouch in UICamera.mTouches)
      {
        if (Object.op_Inequality((Object) mTouch.Value.pressed, (Object) null))
          ++touchCount;
      }
      for (int index = 0; index < UICamera.mMouse.Length; ++index)
      {
        if (Object.op_Inequality((Object) UICamera.mMouse[index].pressed, (Object) null))
          ++touchCount;
      }
      if (Object.op_Inequality((Object) UICamera.controller.pressed, (Object) null))
        ++touchCount;
      return touchCount;
    }
  }

  public static int dragCount
  {
    get
    {
      int dragCount = 0;
      foreach (KeyValuePair<int, UICamera.MouseOrTouch> mTouch in UICamera.mTouches)
      {
        if (Object.op_Inequality((Object) mTouch.Value.dragged, (Object) null))
          ++dragCount;
      }
      for (int index = 0; index < UICamera.mMouse.Length; ++index)
      {
        if (Object.op_Inequality((Object) UICamera.mMouse[index].dragged, (Object) null))
          ++dragCount;
      }
      if (Object.op_Inequality((Object) UICamera.controller.dragged, (Object) null))
        ++dragCount;
      return dragCount;
    }
  }

  public static Camera mainCamera
  {
    get
    {
      UICamera eventHandler = UICamera.eventHandler;
      return Object.op_Inequality((Object) eventHandler, (Object) null) ? eventHandler.cachedCamera : (Camera) null;
    }
  }

  public static UICamera eventHandler
  {
    get
    {
      for (int index = 0; index < UICamera.list.size; ++index)
      {
        UICamera eventHandler = UICamera.list.buffer[index];
        if (!Object.op_Equality((Object) eventHandler, (Object) null) && ((Behaviour) eventHandler).enabled && NGUITools.GetActive(((Component) eventHandler).gameObject))
          return eventHandler;
      }
      return (UICamera) null;
    }
  }

  private static int CompareFunc(UICamera a, UICamera b)
  {
    if ((double) a.cachedCamera.depth < (double) b.cachedCamera.depth)
      return 1;
    return (double) a.cachedCamera.depth > (double) b.cachedCamera.depth ? -1 : 0;
  }

  public static bool Raycast(Vector3 inPos, out RaycastHit hit)
  {
    for (int index1 = 0; index1 < UICamera.list.size; ++index1)
    {
      UICamera uiCamera = UICamera.list.buffer[index1];
      if (((Behaviour) uiCamera).enabled && NGUITools.GetActive(((Component) uiCamera).gameObject))
      {
        UICamera.currentCamera = uiCamera.cachedCamera;
        Vector3 viewportPoint = UICamera.currentCamera.ScreenToViewportPoint(inPos);
        if (!float.IsNaN(viewportPoint.x) && !float.IsNaN(viewportPoint.y) && (double) viewportPoint.x >= 0.0 && (double) viewportPoint.x <= 1.0 && (double) viewportPoint.y >= 0.0 && (double) viewportPoint.y <= 1.0)
        {
          Ray ray = UICamera.currentCamera.ScreenPointToRay(inPos);
          int num1 = UICamera.currentCamera.cullingMask & LayerMask.op_Implicit(uiCamera.eventReceiverMask);
          float num2 = (double) uiCamera.rangeDistance <= 0.0 ? UICamera.currentCamera.farClipPlane - UICamera.currentCamera.nearClipPlane : uiCamera.rangeDistance;
          if (uiCamera.eventType == UICamera.EventType.World)
          {
            if (Physics.Raycast(ray, ref hit, num2, num1))
            {
              UICamera.hoveredObject = ((Component) ((RaycastHit) ref hit).collider).gameObject;
              return true;
            }
          }
          else if (uiCamera.eventType == UICamera.EventType.UI)
          {
            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, num2, num1);
            if (raycastHitArray.Length > 1)
            {
              for (int index2 = 0; index2 < raycastHitArray.Length; ++index2)
              {
                GameObject gameObject = ((Component) ((RaycastHit) ref raycastHitArray[index2]).collider).gameObject;
                UIWidget component = gameObject.GetComponent<UIWidget>();
                if (Object.op_Inequality((Object) component, (Object) null))
                {
                  if (!component.isVisible || component.hitCheck != null && !component.hitCheck(((RaycastHit) ref raycastHitArray[index2]).point))
                    continue;
                }
                else
                {
                  UIRect inParents = NGUITools.FindInParents<UIRect>(gameObject);
                  if (Object.op_Inequality((Object) inParents, (Object) null) && (double) inParents.finalAlpha < 1.0 / 1000.0)
                    continue;
                }
                UICamera.mHit.depth = NGUITools.CalculateRaycastDepth(gameObject);
                if (UICamera.mHit.depth != int.MaxValue)
                {
                  UICamera.mHit.hit = raycastHitArray[index2];
                  UICamera.mHits.Add(UICamera.mHit);
                }
              }
              UICamera.mHits.Sort((BetterList<UICamera.DepthEntry>.CompareFunc) ((r1, r2) => r2.depth.CompareTo(r1.depth)));
              for (int i = 0; i < UICamera.mHits.size; ++i)
              {
                if (UICamera.IsVisible(ref UICamera.mHits.buffer[i]))
                {
                  hit = UICamera.mHits[i].hit;
                  UICamera.hoveredObject = ((Component) ((RaycastHit) ref hit).collider).gameObject;
                  UICamera.mHits.Clear();
                  return true;
                }
              }
              UICamera.mHits.Clear();
            }
            else if (raycastHitArray.Length == 1)
            {
              Collider collider = ((RaycastHit) ref raycastHitArray[0]).collider;
              UIWidget component = ((Component) collider).GetComponent<UIWidget>();
              if (Object.op_Inequality((Object) component, (Object) null))
              {
                if (!component.isVisible || component.hitCheck != null && !component.hitCheck(((RaycastHit) ref raycastHitArray[0]).point))
                  continue;
              }
              else
              {
                UIRect inParents = NGUITools.FindInParents<UIRect>(((Component) collider).gameObject);
                if (Object.op_Inequality((Object) inParents, (Object) null) && (double) inParents.finalAlpha < 1.0 / 1000.0)
                  continue;
              }
              if (UICamera.IsVisible(ref raycastHitArray[0]))
              {
                hit = raycastHitArray[0];
                UICamera.hoveredObject = ((Component) ((RaycastHit) ref hit).collider).gameObject;
                return true;
              }
            }
          }
          else if (uiCamera.eventType == UICamera.EventType.Unity2D && ((Plane) ref UICamera.m2DPlane).Raycast(ray, ref num2))
          {
            Collider2D collider2D = Physics2D.OverlapPoint(Vector2.op_Implicit(((Ray) ref ray).GetPoint(num2)), num1);
            if (Object.op_Implicit((Object) collider2D))
            {
              hit = UICamera.lastHit;
              ((RaycastHit) ref hit).point = viewportPoint;
              UICamera.hoveredObject = ((Component) collider2D).gameObject;
              return true;
            }
          }
        }
      }
    }
    hit = UICamera.mEmpty;
    return false;
  }

  private static bool IsVisible(ref RaycastHit hit)
  {
    UIPanel inParents = NGUITools.FindInParents<UIPanel>(((Component) ((RaycastHit) ref hit).collider).gameObject);
    return Object.op_Equality((Object) inParents, (Object) null) || inParents.IsVisible(((RaycastHit) ref hit).point);
  }

  private static bool IsVisible(ref UICamera.DepthEntry de)
  {
    UIPanel inParents = NGUITools.FindInParents<UIPanel>(((Component) ((RaycastHit) ref de.hit).collider).gameObject);
    return Object.op_Equality((Object) inParents, (Object) null) || inParents.IsVisible(((RaycastHit) ref de.hit).point);
  }

  public static bool IsHighlighted(GameObject go)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Mouse)
      return Object.op_Equality((Object) UICamera.hoveredObject, (Object) go);
    return UICamera.currentScheme == UICamera.ControlScheme.Controller && Object.op_Equality((Object) UICamera.selectedObject, (Object) go);
  }

  public static UICamera FindCameraForLayer(int layer)
  {
    int num = 1 << layer;
    for (int index = 0; index < UICamera.list.size; ++index)
    {
      UICamera cameraForLayer = UICamera.list.buffer[index];
      Camera cachedCamera = cameraForLayer.cachedCamera;
      if (Object.op_Inequality((Object) cachedCamera, (Object) null) && (cachedCamera.cullingMask & num) != 0)
        return cameraForLayer;
    }
    return (UICamera) null;
  }

  private static int GetDirection(KeyCode up, KeyCode down)
  {
    if (Input.GetKeyDown(up))
      return 1;
    return Input.GetKeyDown(down) ? -1 : 0;
  }

  private static int GetDirection(KeyCode up0, KeyCode up1, KeyCode down0, KeyCode down1)
  {
    if (Input.GetKeyDown(up0) || Input.GetKeyDown(up1))
      return 1;
    return Input.GetKeyDown(down0) || Input.GetKeyDown(down1) ? -1 : 0;
  }

  private static int GetDirection(string axis)
  {
    float time = RealTime.time;
    if ((double) UICamera.mNextEvent < (double) time && !string.IsNullOrEmpty(axis))
    {
      float axis1 = Input.GetAxis(axis);
      if ((double) axis1 > 0.75)
      {
        UICamera.mNextEvent = time + 0.25f;
        return 1;
      }
      if ((double) axis1 < -0.75)
      {
        UICamera.mNextEvent = time + 0.25f;
        return -1;
      }
    }
    return 0;
  }

  public static void Notify(GameObject go, string funcName, object obj)
  {
    if (UICamera.mNotifying)
      return;
    UICamera.mNotifying = true;
    if (NGUITools.GetActive(go))
    {
      go.SendMessage(funcName, obj, (SendMessageOptions) 1);
      if (Object.op_Inequality((Object) UICamera.genericEventHandler, (Object) null) && Object.op_Inequality((Object) UICamera.genericEventHandler, (Object) go))
        UICamera.genericEventHandler.SendMessage(funcName, obj, (SendMessageOptions) 1);
    }
    UICamera.mNotifying = false;
  }

  public static UICamera.MouseOrTouch GetMouse(int button) => UICamera.mMouse[button];

  public static UICamera.MouseOrTouch GetTouch(int id)
  {
    UICamera.MouseOrTouch touch = (UICamera.MouseOrTouch) null;
    if (id < 0)
      return UICamera.GetMouse(-id - 1);
    if (!UICamera.mTouches.TryGetValue(id, out touch))
    {
      touch = new UICamera.MouseOrTouch();
      touch.touchBegan = true;
      UICamera.mTouches.Add(id, touch);
    }
    return touch;
  }

  public static void RemoveTouch(int id) => UICamera.mTouches.Remove(id);

  private void Awake()
  {
    UICamera.mWidth = Screen.width;
    UICamera.mHeight = Screen.height;
    if (Application.platform == 11 || Application.platform == 8 || Application.platform == 21 || Application.platform == 22)
    {
      this.useMouse = false;
      this.useTouch = true;
      if (Application.platform == 8)
      {
        this.useKeyboard = false;
        this.useController = false;
      }
    }
    else if (Application.platform == 9 || Application.platform == 10)
    {
      this.useMouse = false;
      this.useTouch = false;
      this.useKeyboard = false;
      this.useController = true;
    }
    UICamera.mMouse[0].pos.x = Input.mousePosition.x;
    UICamera.mMouse[0].pos.y = Input.mousePosition.y;
    for (int index = 1; index < 3; ++index)
    {
      UICamera.mMouse[index].pos = UICamera.mMouse[0].pos;
      UICamera.mMouse[index].lastPos = UICamera.mMouse[0].pos;
    }
    UICamera.lastTouchPosition = UICamera.mMouse[0].pos;
  }

  private void OnEnable()
  {
    UICamera.list.Add(this);
    UICamera.list.Sort(new BetterList<UICamera>.CompareFunc(UICamera.CompareFunc));
  }

  private void OnDisable() => UICamera.list.Remove(this);

  private void Start()
  {
    if (this.eventType != UICamera.EventType.World && this.cachedCamera.transparencySortMode != 2)
      this.cachedCamera.transparencySortMode = (TransparencySortMode) 2;
    if (Application.isPlaying)
      this.cachedCamera.eventMask = 0;
    if (!this.handlesEvents)
      return;
    NGUIDebug.debugRaycast = this.debug;
  }

  private void Update()
  {
    if (!Application.isPlaying || !this.handlesEvents)
      return;
    UICamera.current = this;
    int width = Screen.width;
    int height = Screen.height;
    if (width != UICamera.mWidth || height != UICamera.mHeight)
    {
      UICamera.mWidth = width;
      UICamera.mHeight = height;
      if (UICamera.onScreenResize != null)
        UICamera.onScreenResize();
    }
    if (this.useTouch)
      this.ProcessTouches();
    else if (this.useMouse)
      this.ProcessMouse();
    if (UICamera.onCustomInput != null)
      UICamera.onCustomInput();
    if (this.useMouse && Object.op_Inequality((Object) UICamera.mCurrentSelection, (Object) null))
    {
      if (this.cancelKey0 != null && Input.GetKeyDown(this.cancelKey0))
      {
        UICamera.currentScheme = UICamera.ControlScheme.Controller;
        UICamera.currentKey = this.cancelKey0;
        UICamera.selectedObject = (GameObject) null;
      }
      else if (this.cancelKey1 != null && Input.GetKeyDown(this.cancelKey1))
      {
        UICamera.currentScheme = UICamera.ControlScheme.Controller;
        UICamera.currentKey = this.cancelKey1;
        UICamera.selectedObject = (GameObject) null;
      }
    }
    if (Object.op_Equality((Object) UICamera.mCurrentSelection, (Object) null))
      UICamera.inputHasFocus = false;
    if (Object.op_Inequality((Object) UICamera.mCurrentSelection, (Object) null))
      this.ProcessOthers();
    if (this.useMouse && Object.op_Inequality((Object) UICamera.mHover, (Object) null))
    {
      float num = string.IsNullOrEmpty(this.scrollAxisName) ? 0.0f : Input.GetAxis(this.scrollAxisName);
      if ((double) num != 0.0)
        UICamera.Notify(UICamera.mHover, "OnScroll", (object) num);
      if (UICamera.showTooltips && (double) this.mTooltipTime != 0.0 && ((double) this.mTooltipTime < (double) RealTime.time || Input.GetKey((KeyCode) 304) || Input.GetKey((KeyCode) 303)))
      {
        this.mTooltip = UICamera.mHover;
        this.ShowTooltip(true);
      }
    }
    UICamera.current = (UICamera) null;
  }

  public void ProcessMouse()
  {
    UICamera.lastTouchPosition = Vector2.op_Implicit(Input.mousePosition);
    UICamera.mMouse[0].delta = Vector2.op_Subtraction(UICamera.lastTouchPosition, UICamera.mMouse[0].pos);
    UICamera.mMouse[0].pos = UICamera.lastTouchPosition;
    bool flag1 = (double) ((Vector2) ref UICamera.mMouse[0].delta).sqrMagnitude > 1.0 / 1000.0;
    for (int index = 1; index < 3; ++index)
    {
      UICamera.mMouse[index].pos = UICamera.mMouse[0].pos;
      UICamera.mMouse[index].delta = UICamera.mMouse[0].delta;
    }
    bool flag2 = false;
    bool flag3 = false;
    for (int index = 0; index < 3; ++index)
    {
      if (Input.GetMouseButtonDown(index))
      {
        UICamera.currentScheme = UICamera.ControlScheme.Mouse;
        flag3 = true;
        flag2 = true;
      }
      else if (Input.GetMouseButton(index))
      {
        UICamera.currentScheme = UICamera.ControlScheme.Mouse;
        flag2 = true;
      }
    }
    if (flag2 || flag1 || (double) this.mNextRaycast < (double) RealTime.time)
    {
      this.mNextRaycast = RealTime.time + 0.02f;
      if (!UICamera.Raycast(Input.mousePosition, out UICamera.lastHit))
        UICamera.hoveredObject = UICamera.fallThrough;
      if (Object.op_Equality((Object) UICamera.hoveredObject, (Object) null))
        UICamera.hoveredObject = UICamera.genericEventHandler;
      for (int index = 0; index < 3; ++index)
        UICamera.mMouse[index].current = UICamera.hoveredObject;
    }
    bool flag4 = Object.op_Inequality((Object) UICamera.mMouse[0].last, (Object) UICamera.mMouse[0].current);
    if (flag4)
      UICamera.currentScheme = UICamera.ControlScheme.Mouse;
    if (flag2)
      this.mTooltipTime = 0.0f;
    else if (flag1 && (!this.stickyTooltip || flag4))
    {
      if ((double) this.mTooltipTime != 0.0)
        this.mTooltipTime = RealTime.time + this.tooltipDelay;
      else if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
        this.ShowTooltip(false);
    }
    if ((flag3 || !flag2) && Object.op_Inequality((Object) UICamera.mHover, (Object) null) && flag4)
    {
      UICamera.currentScheme = UICamera.ControlScheme.Mouse;
      if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
        this.ShowTooltip(false);
      UICamera.Notify(UICamera.mHover, "OnHover", (object) false);
      UICamera.mHover = (GameObject) null;
    }
    for (int index = 0; index < 3; ++index)
    {
      bool mouseButtonDown = Input.GetMouseButtonDown(index);
      bool mouseButtonUp = Input.GetMouseButtonUp(index);
      if (mouseButtonDown || mouseButtonUp)
        UICamera.currentScheme = UICamera.ControlScheme.Mouse;
      UICamera.currentTouch = UICamera.mMouse[index];
      UICamera.currentTouchID = -1 - index;
      UICamera.currentKey = (KeyCode) (323 + index);
      if (mouseButtonDown)
        UICamera.currentTouch.pressedCam = UICamera.currentCamera;
      else if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) null))
        UICamera.currentCamera = UICamera.currentTouch.pressedCam;
      this.ProcessTouch(mouseButtonDown, mouseButtonUp);
      UICamera.currentKey = (KeyCode) 0;
    }
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
    if (!flag2 && flag4)
    {
      UICamera.currentScheme = UICamera.ControlScheme.Mouse;
      this.mTooltipTime = RealTime.time + this.tooltipDelay;
      UICamera.mHover = UICamera.mMouse[0].current;
      UICamera.Notify(UICamera.mHover, "OnHover", (object) true);
    }
    UICamera.mMouse[0].last = UICamera.mMouse[0].current;
    for (int index = 1; index < 3; ++index)
      UICamera.mMouse[index].last = UICamera.mMouse[0].last;
  }

  public void ProcessTouches()
  {
    UICamera.currentScheme = UICamera.ControlScheme.Touch;
    for (int index = 0; index < Input.touchCount; ++index)
    {
      Touch touch = Input.GetTouch(index);
      UICamera.currentTouchID = !this.allowMultiTouch ? 1 : ((Touch) ref touch).fingerId;
      UICamera.currentTouch = UICamera.GetTouch(UICamera.currentTouchID);
      bool pressed = ((Touch) ref touch).phase == null || UICamera.currentTouch.touchBegan;
      bool unpressed = ((Touch) ref touch).phase == 4 || ((Touch) ref touch).phase == 3;
      UICamera.currentTouch.touchBegan = false;
      UICamera.currentTouch.delta = !pressed ? Vector2.op_Subtraction(((Touch) ref touch).position, UICamera.currentTouch.pos) : Vector2.zero;
      UICamera.currentTouch.pos = ((Touch) ref touch).position;
      if (!UICamera.Raycast(Vector2.op_Implicit(UICamera.currentTouch.pos), out UICamera.lastHit))
        UICamera.hoveredObject = UICamera.fallThrough;
      if (Object.op_Equality((Object) UICamera.hoveredObject, (Object) null))
        UICamera.hoveredObject = UICamera.genericEventHandler;
      UICamera.currentTouch.last = UICamera.currentTouch.current;
      UICamera.currentTouch.current = UICamera.hoveredObject;
      UICamera.lastTouchPosition = UICamera.currentTouch.pos;
      if (pressed)
        UICamera.currentTouch.pressedCam = UICamera.currentCamera;
      else if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) null))
        UICamera.currentCamera = UICamera.currentTouch.pressedCam;
      if (((Touch) ref touch).tapCount > 1)
        UICamera.currentTouch.clickTime = RealTime.time;
      this.ProcessTouch(pressed, unpressed);
      if (unpressed)
        UICamera.RemoveTouch(UICamera.currentTouchID);
      UICamera.currentTouch.last = (GameObject) null;
      UICamera.currentTouch = (UICamera.MouseOrTouch) null;
      if (!this.allowMultiTouch)
        break;
    }
    if (Input.touchCount != 0 || !this.useMouse)
      return;
    this.ProcessMouse();
  }

  private void ProcessFakeTouches()
  {
    bool mouseButtonDown = Input.GetMouseButtonDown(0);
    bool mouseButtonUp = Input.GetMouseButtonUp(0);
    bool mouseButton = Input.GetMouseButton(0);
    if (!mouseButtonDown && !mouseButtonUp && !mouseButton)
      return;
    UICamera.currentTouchID = 1;
    UICamera.currentTouch = UICamera.mMouse[0];
    UICamera.currentTouch.touchBegan = mouseButtonDown;
    Vector2 vector2 = Vector2.op_Implicit(Input.mousePosition);
    UICamera.currentTouch.delta = !mouseButtonDown ? Vector2.op_Subtraction(vector2, UICamera.currentTouch.pos) : Vector2.zero;
    UICamera.currentTouch.pos = vector2;
    if (!UICamera.Raycast(Vector2.op_Implicit(UICamera.currentTouch.pos), out UICamera.lastHit))
      UICamera.hoveredObject = UICamera.fallThrough;
    if (Object.op_Equality((Object) UICamera.hoveredObject, (Object) null))
      UICamera.hoveredObject = UICamera.genericEventHandler;
    UICamera.currentTouch.last = UICamera.currentTouch.current;
    UICamera.currentTouch.current = UICamera.hoveredObject;
    UICamera.lastTouchPosition = UICamera.currentTouch.pos;
    if (mouseButtonDown)
      UICamera.currentTouch.pressedCam = UICamera.currentCamera;
    else if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) null))
      UICamera.currentCamera = UICamera.currentTouch.pressedCam;
    this.ProcessTouch(mouseButtonDown, mouseButtonUp);
    if (mouseButtonUp)
      UICamera.RemoveTouch(UICamera.currentTouchID);
    UICamera.currentTouch.last = (GameObject) null;
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
  }

  public void ProcessOthers()
  {
    UICamera.currentTouchID = -100;
    UICamera.currentTouch = UICamera.controller;
    UICamera.inputHasFocus = Object.op_Inequality((Object) UICamera.mCurrentSelection, (Object) null) && Object.op_Inequality((Object) UICamera.mCurrentSelection.GetComponent<UIInput>(), (Object) null);
    bool pressed = false;
    bool unpressed = false;
    if (this.submitKey0 != null && Input.GetKeyDown(this.submitKey0))
    {
      UICamera.currentKey = this.submitKey0;
      pressed = true;
    }
    if (this.submitKey1 != null && Input.GetKeyDown(this.submitKey1))
    {
      UICamera.currentKey = this.submitKey1;
      pressed = true;
    }
    if (this.submitKey0 != null && Input.GetKeyUp(this.submitKey0))
    {
      UICamera.currentKey = this.submitKey0;
      unpressed = true;
    }
    if (this.submitKey1 != null && Input.GetKeyUp(this.submitKey1))
    {
      UICamera.currentKey = this.submitKey1;
      unpressed = true;
    }
    if (pressed || unpressed)
    {
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.currentTouch.last = UICamera.currentTouch.current;
      UICamera.currentTouch.current = UICamera.mCurrentSelection;
      this.ProcessTouch(pressed, unpressed);
      UICamera.currentTouch.last = (GameObject) null;
    }
    int num1 = 0;
    int num2 = 0;
    if (this.useKeyboard)
    {
      if (UICamera.inputHasFocus)
      {
        num1 += UICamera.GetDirection((KeyCode) 273, (KeyCode) 274);
        num2 += UICamera.GetDirection((KeyCode) 275, (KeyCode) 276);
      }
      else
      {
        num1 += UICamera.GetDirection((KeyCode) 119, (KeyCode) 273, (KeyCode) 115, (KeyCode) 274);
        num2 += UICamera.GetDirection((KeyCode) 100, (KeyCode) 275, (KeyCode) 97, (KeyCode) 276);
      }
    }
    if (this.useController)
    {
      if (!string.IsNullOrEmpty(this.verticalAxisName))
        num1 += UICamera.GetDirection(this.verticalAxisName);
      if (!string.IsNullOrEmpty(this.horizontalAxisName))
        num2 += UICamera.GetDirection(this.horizontalAxisName);
    }
    if (num1 != 0)
    {
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.Notify(UICamera.mCurrentSelection, "OnKey", (object) (KeyCode) (num1 <= 0 ? 274 : 273));
    }
    if (num2 != 0)
    {
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.Notify(UICamera.mCurrentSelection, "OnKey", (object) (KeyCode) (num2 <= 0 ? 276 : 275));
    }
    if (this.useKeyboard && Input.GetKeyDown((KeyCode) 9))
    {
      UICamera.currentKey = (KeyCode) 9;
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.Notify(UICamera.mCurrentSelection, "OnKey", (object) (KeyCode) 9);
    }
    if (this.cancelKey0 != null && Input.GetKeyDown(this.cancelKey0))
    {
      UICamera.currentKey = this.cancelKey0;
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.Notify(UICamera.mCurrentSelection, "OnKey", (object) (KeyCode) 27);
    }
    if (this.cancelKey1 != null && Input.GetKeyDown(this.cancelKey1))
    {
      UICamera.currentKey = this.cancelKey1;
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.Notify(UICamera.mCurrentSelection, "OnKey", (object) (KeyCode) 27);
    }
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
    UICamera.currentKey = (KeyCode) 0;
  }

  public void ProcessTouch(bool pressed, bool unpressed)
  {
    bool flag1 = UICamera.currentScheme == UICamera.ControlScheme.Mouse;
    float num1 = !flag1 ? this.touchDragThreshold : this.mouseDragThreshold;
    float num2 = !flag1 ? this.touchClickThreshold : this.mouseClickThreshold;
    float num3 = num1 * num1;
    float num4 = num2 * num2;
    if (pressed)
    {
      if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
        this.ShowTooltip(false);
      UICamera.currentTouch.pressStarted = true;
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) false);
      UICamera.currentTouch.pressed = UICamera.currentTouch.current;
      UICamera.currentTouch.dragged = UICamera.currentTouch.current;
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
      UICamera.currentTouch.totalDelta = Vector2.zero;
      UICamera.currentTouch.dragStarted = false;
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) true);
      if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) UICamera.mCurrentSelection))
      {
        if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
          this.ShowTooltip(false);
        UICamera.currentScheme = UICamera.ControlScheme.Touch;
        UICamera.selectedObject = (GameObject) null;
      }
    }
    else if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) null) && ((double) ((Vector2) ref UICamera.currentTouch.delta).sqrMagnitude != 0.0 || Object.op_Inequality((Object) UICamera.currentTouch.current, (Object) UICamera.currentTouch.last)))
    {
      UICamera.MouseOrTouch currentTouch = UICamera.currentTouch;
      currentTouch.totalDelta = Vector2.op_Addition(currentTouch.totalDelta, UICamera.currentTouch.delta);
      float sqrMagnitude = ((Vector2) ref UICamera.currentTouch.totalDelta).sqrMagnitude;
      bool flag2 = false;
      if (!UICamera.currentTouch.dragStarted && Object.op_Inequality((Object) UICamera.currentTouch.last, (Object) UICamera.currentTouch.current))
      {
        UICamera.currentTouch.dragStarted = true;
        UICamera.currentTouch.delta = UICamera.currentTouch.totalDelta;
        UICamera.isDragging = true;
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDragStart", (object) null);
        UICamera.Notify(UICamera.currentTouch.last, "OnDragOver", (object) UICamera.currentTouch.dragged);
        UICamera.isDragging = false;
      }
      else if (!UICamera.currentTouch.dragStarted && (double) num3 < (double) sqrMagnitude)
      {
        flag2 = true;
        UICamera.currentTouch.dragStarted = true;
        UICamera.currentTouch.delta = UICamera.currentTouch.totalDelta;
      }
      if (UICamera.currentTouch.dragStarted)
      {
        if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
          this.ShowTooltip(false);
        UICamera.isDragging = true;
        bool flag3 = UICamera.currentTouch.clickNotification == UICamera.ClickNotification.None;
        if (flag2)
        {
          UICamera.Notify(UICamera.currentTouch.dragged, "OnDragStart", (object) null);
          UICamera.Notify(UICamera.currentTouch.current, "OnDragOver", (object) UICamera.currentTouch.dragged);
        }
        else if (Object.op_Inequality((Object) UICamera.currentTouch.last, (Object) UICamera.currentTouch.current))
        {
          UICamera.Notify(UICamera.currentTouch.last, "OnDragOut", (object) UICamera.currentTouch.dragged);
          UICamera.Notify(UICamera.currentTouch.current, "OnDragOver", (object) UICamera.currentTouch.dragged);
        }
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDrag", (object) UICamera.currentTouch.delta);
        UICamera.currentTouch.last = UICamera.currentTouch.current;
        UICamera.isDragging = false;
        if (flag3)
          UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
        else if (UICamera.currentTouch.clickNotification == UICamera.ClickNotification.BasedOnDelta && (double) num4 < (double) sqrMagnitude)
          UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      }
    }
    if (!unpressed)
      return;
    UICamera.currentTouch.pressStarted = false;
    if (Object.op_Inequality((Object) this.mTooltip, (Object) null))
      this.ShowTooltip(false);
    if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) null))
    {
      if (UICamera.currentTouch.dragStarted)
      {
        UICamera.Notify(UICamera.currentTouch.last, "OnDragOut", (object) UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDragEnd", (object) null);
      }
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) false);
      if (flag1)
        UICamera.Notify(UICamera.currentTouch.current, "OnHover", (object) true);
      UICamera.mHover = UICamera.currentTouch.current;
      if (Object.op_Equality((Object) UICamera.currentTouch.dragged, (Object) UICamera.currentTouch.current) || UICamera.currentScheme != UICamera.ControlScheme.Controller && UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && (double) ((Vector2) ref UICamera.currentTouch.totalDelta).sqrMagnitude < (double) num3)
      {
        if (Object.op_Inequality((Object) UICamera.currentTouch.pressed, (Object) UICamera.mCurrentSelection))
        {
          UICamera.mNextSelection = (GameObject) null;
          UICamera.mCurrentSelection = UICamera.currentTouch.pressed;
          UICamera.Notify(UICamera.currentTouch.pressed, "OnSelect", (object) true);
        }
        else
        {
          UICamera.mNextSelection = (GameObject) null;
          UICamera.mCurrentSelection = UICamera.currentTouch.pressed;
        }
        if (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) UICamera.currentTouch.current))
        {
          float time = RealTime.time;
          UICamera.Notify(UICamera.currentTouch.pressed, "OnClick", (object) null);
          if ((double) UICamera.currentTouch.clickTime + 0.34999999403953552 > (double) time)
            UICamera.Notify(UICamera.currentTouch.pressed, "OnDoubleClick", (object) null);
          UICamera.currentTouch.clickTime = time;
        }
      }
      else if (UICamera.currentTouch.dragStarted)
        UICamera.Notify(UICamera.currentTouch.current, "OnDrop", (object) UICamera.currentTouch.dragged);
    }
    UICamera.currentTouch.dragStarted = false;
    UICamera.currentTouch.pressed = (GameObject) null;
    UICamera.currentTouch.dragged = (GameObject) null;
  }

  public void ShowTooltip(bool val)
  {
    this.mTooltipTime = 0.0f;
    UICamera.Notify(this.mTooltip, "OnTooltip", (object) val);
    if (val)
      return;
    this.mTooltip = (GameObject) null;
  }

  private void OnApplicationPause()
  {
    UICamera.MouseOrTouch currentTouch = UICamera.currentTouch;
    if (this.useTouch)
    {
      BetterList<int> betterList = new BetterList<int>();
      foreach (KeyValuePair<int, UICamera.MouseOrTouch> mTouch in UICamera.mTouches)
      {
        if (mTouch.Value != null && Object.op_Implicit((Object) mTouch.Value.pressed))
        {
          UICamera.currentTouch = mTouch.Value;
          UICamera.currentTouchID = mTouch.Key;
          UICamera.currentScheme = UICamera.ControlScheme.Touch;
          UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
          this.ProcessTouch(false, true);
          betterList.Add(UICamera.currentTouchID);
        }
      }
      for (int i = 0; i < betterList.size; ++i)
        UICamera.RemoveTouch(betterList[i]);
    }
    if (this.useMouse)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (Object.op_Implicit((Object) UICamera.mMouse[index].pressed))
        {
          UICamera.currentTouch = UICamera.mMouse[index];
          UICamera.currentTouchID = -1 - index;
          UICamera.currentKey = (KeyCode) (323 + index);
          UICamera.currentScheme = UICamera.ControlScheme.Mouse;
          UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
          this.ProcessTouch(false, true);
        }
      }
    }
    if (this.useController && Object.op_Implicit((Object) UICamera.controller.pressed))
    {
      UICamera.currentTouch = UICamera.controller;
      UICamera.currentTouchID = -100;
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
      UICamera.currentTouch.last = UICamera.currentTouch.current;
      UICamera.currentTouch.current = UICamera.mCurrentSelection;
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      this.ProcessTouch(false, true);
      UICamera.currentTouch.last = (GameObject) null;
    }
    UICamera.currentTouch = currentTouch;
  }

  public enum ControlScheme
  {
    Mouse,
    Touch,
    Controller,
  }

  public enum ClickNotification
  {
    None,
    Always,
    BasedOnDelta,
  }

  public class MouseOrTouch
  {
    public Vector2 pos;
    public Vector2 lastPos;
    public Vector2 delta;
    public Vector2 totalDelta;
    public Camera pressedCam;
    public GameObject last;
    public GameObject current;
    public GameObject pressed;
    public GameObject dragged;
    public float clickTime;
    public UICamera.ClickNotification clickNotification = UICamera.ClickNotification.Always;
    public bool touchBegan = true;
    public bool pressStarted;
    public bool dragStarted;
  }

  public enum EventType
  {
    World,
    UI,
    Unity2D,
  }

  private struct DepthEntry
  {
    public int depth;
    public RaycastHit hit;
  }

  public delegate void OnScreenResize();

  public delegate void OnCustomInput();
}
