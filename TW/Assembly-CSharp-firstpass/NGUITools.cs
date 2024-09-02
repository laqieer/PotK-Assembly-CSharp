// Decompiled with JetBrains decompiler
// Type: NGUITools
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

#nullable disable
public static class NGUITools
{
  private static AudioListener mListener;
  private static bool mLoaded = false;
  private static float mGlobalVolume = 1f;
  private static Vector3[] mSides = new Vector3[4];

  public static float soundVolume
  {
    get
    {
      if (!NGUITools.mLoaded)
      {
        NGUITools.mLoaded = true;
        NGUITools.mGlobalVolume = PlayerPrefs.GetFloat("Sound", 1f);
      }
      return NGUITools.mGlobalVolume;
    }
    set
    {
      if ((double) NGUITools.mGlobalVolume == (double) value)
        return;
      NGUITools.mLoaded = true;
      NGUITools.mGlobalVolume = value;
      PlayerPrefs.SetFloat("Sound", value);
    }
  }

  public static bool fileAccess => Application.platform != 5 && Application.platform != 3;

  public static AudioSource PlaySound(AudioClip clip) => NGUITools.PlaySound(clip, 1f, 1f);

  public static AudioSource PlaySound(AudioClip clip, float volume)
  {
    return NGUITools.PlaySound(clip, volume, 1f);
  }

  public static AudioSource PlaySound(AudioClip clip, float volume, float pitch)
  {
    volume *= NGUITools.soundVolume;
    if (Object.op_Inequality((Object) clip, (Object) null) && (double) volume > 0.0099999997764825821)
    {
      if (Object.op_Equality((Object) NGUITools.mListener, (Object) null) || !NGUITools.GetActive((Behaviour) NGUITools.mListener))
      {
        NGUITools.mListener = Object.FindObjectOfType(typeof (AudioListener)) as AudioListener;
        if (Object.op_Equality((Object) NGUITools.mListener, (Object) null))
        {
          Camera camera = Camera.main;
          if (Object.op_Equality((Object) camera, (Object) null))
            camera = Object.FindObjectOfType(typeof (Camera)) as Camera;
          if (Object.op_Inequality((Object) camera, (Object) null))
            NGUITools.mListener = ((Component) camera).gameObject.AddComponent<AudioListener>();
        }
      }
      if (Object.op_Inequality((Object) NGUITools.mListener, (Object) null) && ((Behaviour) NGUITools.mListener).enabled && NGUITools.GetActive(((Component) NGUITools.mListener).gameObject))
      {
        AudioSource audioSource = ((Component) NGUITools.mListener).GetComponent<AudioSource>();
        if (Object.op_Equality((Object) audioSource, (Object) null))
          audioSource = ((Component) NGUITools.mListener).gameObject.AddComponent<AudioSource>();
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(clip, volume);
        return audioSource;
      }
    }
    return (AudioSource) null;
  }

  public static WWW OpenURL(string url)
  {
    WWW www = (WWW) null;
    try
    {
      www = new WWW(url);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.Message);
    }
    return www;
  }

  public static WWW OpenURL(string url, WWWForm form)
  {
    if (form == null)
      return NGUITools.OpenURL(url);
    WWW www = (WWW) null;
    try
    {
      www = new WWW(url, form);
    }
    catch (Exception ex)
    {
      Debug.LogError(ex == null ? (object) "<null>" : (object) ex.Message);
    }
    return www;
  }

  public static int RandomRange(int min, int max) => min == max ? min : Random.Range(min, max + 1);

  public static string GetHierarchy(GameObject obj)
  {
    string hierarchy = ((Object) obj).name;
    while (Object.op_Inequality((Object) obj.transform.parent, (Object) null))
    {
      obj = ((Component) obj.transform.parent).gameObject;
      hierarchy = ((Object) obj).name + "\\" + hierarchy;
    }
    return hierarchy;
  }

  public static T[] FindActive<T>() where T : Component
  {
    return Object.FindObjectsOfType(typeof (T)) as T[];
  }

  public static Camera FindCameraForLayer(int layer)
  {
    int num = 1 << layer;
    for (int index = 0; index < UICamera.list.size; ++index)
    {
      Camera cachedCamera = UICamera.list.buffer[index].cachedCamera;
      if (Object.op_Inequality((Object) cachedCamera, (Object) null) && (cachedCamera.cullingMask & num) != 0)
        return cachedCamera;
    }
    Camera main = Camera.main;
    if (Object.op_Inequality((Object) main, (Object) null) && (main.cullingMask & num) != 0)
      return main;
    Camera[] active = NGUITools.FindActive<Camera>();
    int index1 = 0;
    for (int length = active.Length; index1 < length; ++index1)
    {
      Camera cameraForLayer = active[index1];
      if ((cameraForLayer.cullingMask & num) != 0)
        return cameraForLayer;
    }
    return (Camera) null;
  }

  public static BoxCollider AddWidgetCollider(GameObject go)
  {
    return NGUITools.AddWidgetCollider(go, false);
  }

  public static BoxCollider AddWidgetCollider(GameObject go, bool considerInactive)
  {
    if (!Object.op_Inequality((Object) go, (Object) null))
      return (BoxCollider) null;
    Collider component1 = go.GetComponent<Collider>();
    BoxCollider box = component1 as BoxCollider;
    if (Object.op_Equality((Object) box, (Object) null))
    {
      if (Object.op_Inequality((Object) component1, (Object) null))
      {
        if (Application.isPlaying)
          Object.Destroy((Object) component1);
        else
          Object.DestroyImmediate((Object) component1);
      }
      box = go.AddComponent<BoxCollider>();
      ((Collider) box).isTrigger = true;
      UIWidget component2 = go.GetComponent<UIWidget>();
      if (Object.op_Inequality((Object) component2, (Object) null))
        component2.autoResizeBoxCollider = true;
    }
    NGUITools.UpdateWidgetCollider(box, considerInactive);
    return box;
  }

  public static void UpdateWidgetCollider(GameObject go)
  {
    NGUITools.UpdateWidgetCollider(go, false);
  }

  public static void UpdateWidgetCollider(GameObject go, bool considerInactive)
  {
    if (!Object.op_Inequality((Object) go, (Object) null))
      return;
    NGUITools.UpdateWidgetCollider(go.GetComponent<BoxCollider>(), considerInactive);
  }

  public static void UpdateWidgetCollider(BoxCollider bc)
  {
    NGUITools.UpdateWidgetCollider(bc, false);
  }

  public static void UpdateWidgetCollider(BoxCollider box, bool considerInactive)
  {
    if (!Object.op_Inequality((Object) box, (Object) null))
      return;
    GameObject gameObject = ((Component) box).gameObject;
    UIWidget component = gameObject.GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      Vector4 drawingDimensions = component.drawingDimensions;
      box.center = new Vector3((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
      box.size = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
    }
    else
    {
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
      box.center = ((Bounds) ref relativeWidgetBounds).center;
      box.size = new Vector3(((Bounds) ref relativeWidgetBounds).size.x, ((Bounds) ref relativeWidgetBounds).size.y, 0.0f);
    }
  }

  public static string GetTypeName<T>()
  {
    string typeName = typeof (T).ToString();
    if (typeName.StartsWith("UI"))
      typeName = typeName.Substring(2);
    else if (typeName.StartsWith("UnityEngine."))
      typeName = typeName.Substring(12);
    return typeName;
  }

  public static string GetTypeName(Object obj)
  {
    if (Object.op_Equality(obj, (Object) null))
      return "Null";
    string typeName = obj.GetType().ToString();
    if (typeName.StartsWith("UI"))
      typeName = typeName.Substring(2);
    else if (typeName.StartsWith("UnityEngine."))
      typeName = typeName.Substring(12);
    return typeName;
  }

  public static void RegisterUndo(Object obj, string name)
  {
  }

  public static void SetDirty(Object obj)
  {
  }

  public static GameObject AddChild(GameObject parent) => NGUITools.AddChild(parent, true);

  public static GameObject AddChild(GameObject parent, bool undo)
  {
    GameObject gameObject = new GameObject();
    if (Object.op_Inequality((Object) parent, (Object) null))
    {
      Transform transform = gameObject.transform;
      transform.parent = parent.transform;
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.identity;
      transform.localScale = Vector3.one;
      gameObject.layer = parent.layer;
    }
    return gameObject;
  }

  public static GameObject AddChild(GameObject parent, GameObject prefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(prefab);
    if (Object.op_Inequality((Object) gameObject, (Object) null) && Object.op_Inequality((Object) parent, (Object) null))
    {
      Transform transform = gameObject.transform;
      transform.parent = parent.transform;
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.identity;
      transform.localScale = Vector3.one;
      gameObject.layer = parent.layer;
    }
    return gameObject;
  }

  public static int CalculateRaycastDepth(GameObject go)
  {
    UIWidget component = go.GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
      return component.raycastDepth;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    if (componentsInChildren.Length == 0)
      return 0;
    int raycastDepth = int.MaxValue;
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      if (((Behaviour) componentsInChildren[index]).enabled)
        raycastDepth = Mathf.Min(raycastDepth, componentsInChildren[index].raycastDepth);
    }
    return raycastDepth;
  }

  public static int CalculateNextDepth(GameObject go)
  {
    int num = -1;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
      num = Mathf.Max(num, componentsInChildren[index].depth);
    return num + 1;
  }

  public static int CalculateNextDepth(GameObject go, bool ignoreChildrenWithColliders)
  {
    if (!ignoreChildrenWithColliders)
      return NGUITools.CalculateNextDepth(go);
    int num = -1;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      UIWidget uiWidget = componentsInChildren[index];
      if (!Object.op_Inequality((Object) uiWidget.cachedGameObject, (Object) go) || !Object.op_Inequality((Object) ((Component) uiWidget).GetComponent<Collider>(), (Object) null))
        num = Mathf.Max(num, uiWidget.depth);
    }
    return num + 1;
  }

  public static int AdjustDepth(GameObject go, int adjustment)
  {
    if (!Object.op_Inequality((Object) go, (Object) null))
      return 0;
    if (Object.op_Inequality((Object) go.GetComponent<UIPanel>(), (Object) null))
    {
      foreach (UIPanel componentsInChild in go.GetComponentsInChildren<UIPanel>(true))
        componentsInChild.depth += adjustment;
      return 1;
    }
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>(true);
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
      componentsInChildren[index].depth += adjustment;
    return 2;
  }

  public static void BringForward(GameObject go)
  {
    switch (NGUITools.AdjustDepth(go, 1000))
    {
      case 1:
        NGUITools.NormalizePanelDepths();
        break;
      case 2:
        NGUITools.NormalizeWidgetDepths();
        break;
    }
  }

  public static void PushBack(GameObject go)
  {
    switch (NGUITools.AdjustDepth(go, -1000))
    {
      case 1:
        NGUITools.NormalizePanelDepths();
        break;
      case 2:
        NGUITools.NormalizeWidgetDepths();
        break;
    }
  }

  public static void NormalizeDepths()
  {
    NGUITools.NormalizeWidgetDepths();
    NGUITools.NormalizePanelDepths();
  }

  public static void NormalizeWidgetDepths()
  {
    UIWidget[] active = NGUITools.FindActive<UIWidget>();
    int length = active.Length;
    if (length <= 0)
      return;
    Array.Sort<UIWidget>(active, new Comparison<UIWidget>(UIWidget.FullCompareFunc));
    int num = 0;
    int depth = active[0].depth;
    for (int index = 0; index < length; ++index)
    {
      UIWidget uiWidget = active[index];
      if (uiWidget.depth == depth)
      {
        uiWidget.depth = num;
      }
      else
      {
        depth = uiWidget.depth;
        uiWidget.depth = ++num;
      }
    }
  }

  public static void NormalizePanelDepths()
  {
    UIPanel[] active = NGUITools.FindActive<UIPanel>();
    int length = active.Length;
    if (length <= 0)
      return;
    Array.Sort<UIPanel>(active, new Comparison<UIPanel>(UIPanel.CompareFunc));
    int num = 0;
    int depth = active[0].depth;
    for (int index = 0; index < length; ++index)
    {
      UIPanel uiPanel = active[index];
      if (uiPanel.depth == depth)
      {
        uiPanel.depth = num;
      }
      else
      {
        depth = uiPanel.depth;
        uiPanel.depth = ++num;
      }
    }
  }

  public static UIPanel CreateUI(bool advanced3D)
  {
    return NGUITools.CreateUI((Transform) null, advanced3D, -1);
  }

  public static UIPanel CreateUI(bool advanced3D, int layer)
  {
    return NGUITools.CreateUI((Transform) null, advanced3D, layer);
  }

  public static UIPanel CreateUI(Transform trans, bool advanced3D, int layer)
  {
    UIRoot uiRoot = !Object.op_Inequality((Object) trans, (Object) null) ? (UIRoot) null : NGUITools.FindInParents<UIRoot>(((Component) trans).gameObject);
    if (Object.op_Equality((Object) uiRoot, (Object) null) && UIRoot.list.Count > 0)
      uiRoot = UIRoot.list[0];
    if (Object.op_Equality((Object) uiRoot, (Object) null))
    {
      GameObject gameObject = NGUITools.AddChild((GameObject) null, false);
      uiRoot = gameObject.AddComponent<UIRoot>();
      if (layer == -1)
        layer = LayerMask.NameToLayer("UI");
      if (layer == -1)
        layer = LayerMask.NameToLayer("2D UI");
      gameObject.layer = layer;
      if (advanced3D)
      {
        ((Object) gameObject).name = "UI Root (3D)";
        uiRoot.scalingStyle = UIRoot.Scaling.FixedSize;
      }
      else
      {
        ((Object) gameObject).name = "UI Root";
        uiRoot.scalingStyle = UIRoot.Scaling.PixelPerfect;
      }
    }
    UIPanel ui = ((Component) uiRoot).GetComponentInChildren<UIPanel>();
    if (Object.op_Equality((Object) ui, (Object) null))
    {
      Camera[] active1 = NGUITools.FindActive<Camera>();
      float num1 = -1f;
      bool flag = false;
      int num2 = 1 << ((Component) uiRoot).gameObject.layer;
      for (int index = 0; index < active1.Length; ++index)
      {
        Camera camera = active1[index];
        if (camera.clearFlags == 2 || camera.clearFlags == 1)
          flag = true;
        num1 = Mathf.Max(num1, camera.depth);
        camera.cullingMask &= ~num2;
      }
      Camera camera1 = NGUITools.AddChild<Camera>(((Component) uiRoot).gameObject, false);
      ((Component) camera1).gameObject.AddComponent<UICamera>();
      camera1.clearFlags = !flag ? (CameraClearFlags) 2 : (CameraClearFlags) 3;
      camera1.backgroundColor = Color.grey;
      camera1.cullingMask = num2;
      camera1.depth = num1 + 1f;
      if (advanced3D)
      {
        camera1.nearClipPlane = 0.1f;
        camera1.farClipPlane = 4f;
        ((Component) camera1).transform.localPosition = new Vector3(0.0f, 0.0f, -700f);
      }
      else
      {
        camera1.orthographic = true;
        camera1.orthographicSize = 1f;
        camera1.nearClipPlane = -10f;
        camera1.farClipPlane = 10f;
      }
      AudioListener[] active2 = NGUITools.FindActive<AudioListener>();
      if (active2 == null || active2.Length == 0)
        ((Component) camera1).gameObject.AddComponent<AudioListener>();
      ui = ((Component) uiRoot).gameObject.AddComponent<UIPanel>();
    }
    if (Object.op_Inequality((Object) trans, (Object) null))
    {
      while (Object.op_Inequality((Object) trans.parent, (Object) null))
        trans = trans.parent;
      if (NGUITools.IsChild(trans, ((Component) ui).transform))
      {
        ui = ((Component) trans).gameObject.AddComponent<UIPanel>();
      }
      else
      {
        trans.parent = ((Component) ui).transform;
        trans.localScale = Vector3.one;
        trans.localPosition = Vector3.zero;
        NGUITools.SetChildLayer(ui.cachedTransform, ui.cachedGameObject.layer);
      }
    }
    return ui;
  }

  public static void SetChildLayer(Transform t, int layer)
  {
    for (int index = 0; index < t.childCount; ++index)
    {
      Transform child = t.GetChild(index);
      ((Component) child).gameObject.layer = layer;
      NGUITools.SetChildLayer(child, layer);
    }
  }

  public static T AddChild<T>(GameObject parent) where T : Component
  {
    GameObject gameObject = NGUITools.AddChild(parent);
    ((Object) gameObject).name = NGUITools.GetTypeName<T>();
    return gameObject.AddComponent<T>();
  }

  public static T AddChild<T>(GameObject parent, bool undo) where T : Component
  {
    GameObject gameObject = NGUITools.AddChild(parent, undo);
    ((Object) gameObject).name = NGUITools.GetTypeName<T>();
    return gameObject.AddComponent<T>();
  }

  public static T AddWidget<T>(GameObject go) where T : UIWidget
  {
    int nextDepth = NGUITools.CalculateNextDepth(go);
    T obj = NGUITools.AddChild<T>(go);
    obj.width = 100;
    obj.height = 100;
    obj.depth = nextDepth;
    obj.gameObject.layer = go.layer;
    return obj;
  }

  public static UISprite AddSprite(GameObject go, UIAtlas atlas, string spriteName)
  {
    UISpriteData sprite = !Object.op_Inequality((Object) atlas, (Object) null) ? (UISpriteData) null : atlas.GetSprite(spriteName);
    UISprite uiSprite = NGUITools.AddWidget<UISprite>(go);
    uiSprite.type = sprite == null || !sprite.hasBorder ? UISprite.Type.Simple : UISprite.Type.Sliced;
    uiSprite.atlas = atlas;
    uiSprite.spriteName = spriteName;
    return uiSprite;
  }

  public static GameObject GetRoot(GameObject go)
  {
    Transform transform = go.transform;
    while (true)
    {
      Transform parent = transform.parent;
      if (!Object.op_Equality((Object) parent, (Object) null))
        transform = parent;
      else
        break;
    }
    return ((Component) transform).gameObject;
  }

  public static T FindInParents<T>(GameObject go) where T : Component
  {
    if (Object.op_Equality((Object) go, (Object) null))
      return (T) null;
    T component = go.GetComponent<T>();
    if (Object.op_Equality((Object) (object) component, (Object) null))
    {
      for (Transform parent = go.transform.parent; Object.op_Inequality((Object) parent, (Object) null) && Object.op_Equality((Object) (object) component, (Object) null); parent = parent.parent)
        component = ((Component) parent).gameObject.GetComponent<T>();
    }
    return component;
  }

  public static T FindInParents<T>(Transform trans) where T : Component
  {
    if (Object.op_Equality((Object) trans, (Object) null))
      return (T) null;
    T component = ((Component) trans).GetComponent<T>();
    if (Object.op_Equality((Object) (object) component, (Object) null))
    {
      for (Transform parent = ((Component) trans).transform.parent; Object.op_Inequality((Object) parent, (Object) null) && Object.op_Equality((Object) (object) component, (Object) null); parent = parent.parent)
        component = ((Component) parent).gameObject.GetComponent<T>();
    }
    return component;
  }

  public static void Destroy(Object obj)
  {
    if (!Object.op_Inequality(obj, (Object) null))
      return;
    if (Application.isPlaying)
    {
      if (obj is GameObject)
        (obj as GameObject).transform.parent = (Transform) null;
      Object.Destroy(obj);
    }
    else
      Object.DestroyImmediate(obj);
  }

  public static void DestroyImmediate(Object obj)
  {
    if (!Object.op_Inequality(obj, (Object) null))
      return;
    if (Application.isEditor)
      Object.DestroyImmediate(obj);
    else
      Object.Destroy(obj);
  }

  public static void Broadcast(string funcName)
  {
    GameObject[] objectsOfType = Object.FindObjectsOfType(typeof (GameObject)) as GameObject[];
    int index = 0;
    for (int length = objectsOfType.Length; index < length; ++index)
      objectsOfType[index].SendMessage(funcName, (SendMessageOptions) 1);
  }

  public static void Broadcast(string funcName, object param)
  {
    GameObject[] objectsOfType = Object.FindObjectsOfType(typeof (GameObject)) as GameObject[];
    int index = 0;
    for (int length = objectsOfType.Length; index < length; ++index)
      objectsOfType[index].SendMessage(funcName, param, (SendMessageOptions) 1);
  }

  public static bool IsChild(Transform parent, Transform child)
  {
    if (Object.op_Equality((Object) parent, (Object) null) || Object.op_Equality((Object) child, (Object) null))
      return false;
    for (; Object.op_Inequality((Object) child, (Object) null); child = child.parent)
    {
      if (Object.op_Equality((Object) child, (Object) parent))
        return true;
    }
    return false;
  }

  private static void Activate(Transform t) => NGUITools.Activate(t, true);

  private static void Activate(Transform t, bool compatibilityMode)
  {
    NGUITools.SetActiveSelf(((Component) t).gameObject, true);
    if (!compatibilityMode)
      return;
    int num1 = 0;
    for (int childCount = t.childCount; num1 < childCount; ++num1)
    {
      if (((Component) t.GetChild(num1)).gameObject.activeSelf)
        return;
    }
    int num2 = 0;
    for (int childCount = t.childCount; num2 < childCount; ++num2)
      NGUITools.Activate(t.GetChild(num2), true);
  }

  private static void Deactivate(Transform t)
  {
    NGUITools.SetActiveSelf(((Component) t).gameObject, false);
  }

  public static void SetActive(GameObject go, bool state) => NGUITools.SetActive(go, state, true);

  public static void SetActive(GameObject go, bool state, bool compatibilityMode)
  {
    if (!Object.op_Implicit((Object) go))
      return;
    if (state)
    {
      NGUITools.Activate(go.transform, compatibilityMode);
      NGUITools.CallCreatePanel(go.transform);
    }
    else
      NGUITools.Deactivate(go.transform);
  }

  [DebuggerStepThrough]
  [DebuggerHidden]
  private static void CallCreatePanel(Transform t)
  {
    UIWidget component = ((Component) t).GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.CreatePanel();
    int num = 0;
    for (int childCount = t.childCount; num < childCount; ++num)
      NGUITools.CallCreatePanel(t.GetChild(num));
  }

  public static void SetActiveChildren(GameObject go, bool state)
  {
    Transform transform = go.transform;
    if (state)
    {
      int num = 0;
      for (int childCount = transform.childCount; num < childCount; ++num)
        NGUITools.Activate(transform.GetChild(num));
    }
    else
    {
      int num = 0;
      for (int childCount = transform.childCount; num < childCount; ++num)
        NGUITools.Deactivate(transform.GetChild(num));
    }
  }

  [Obsolete("Use NGUITools.GetActive instead")]
  public static bool IsActive(Behaviour mb)
  {
    return Object.op_Inequality((Object) mb, (Object) null) && mb.enabled && ((Component) mb).gameObject.activeInHierarchy;
  }

  public static bool GetActive(Behaviour mb)
  {
    return Object.op_Inequality((Object) mb, (Object) null) && mb.enabled && ((Component) mb).gameObject.activeInHierarchy;
  }

  public static bool GetActive(GameObject go)
  {
    return Object.op_Implicit((Object) go) && go.activeInHierarchy;
  }

  public static void SetActiveSelf(GameObject go, bool state) => go.SetActive(state);

  public static void SetLayer(GameObject go, int layer)
  {
    go.layer = layer;
    Transform transform = go.transform;
    int num = 0;
    for (int childCount = transform.childCount; num < childCount; ++num)
      NGUITools.SetLayer(((Component) transform.GetChild(num)).gameObject, layer);
  }

  public static Vector3 Round(Vector3 v)
  {
    v.x = Mathf.Round(v.x);
    v.y = Mathf.Round(v.y);
    v.z = Mathf.Round(v.z);
    return v;
  }

  public static void MakePixelPerfect(Transform t)
  {
    UIWidget component = ((Component) t).GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.MakePixelPerfect();
    if (Object.op_Equality((Object) ((Component) t).GetComponent<UIAnchor>(), (Object) null) && Object.op_Equality((Object) ((Component) t).GetComponent<UIRoot>(), (Object) null))
    {
      t.localPosition = NGUITools.Round(t.localPosition);
      t.localScale = NGUITools.Round(t.localScale);
    }
    int num = 0;
    for (int childCount = t.childCount; num < childCount; ++num)
      NGUITools.MakePixelPerfect(t.GetChild(num));
  }

  public static bool Save(string fileName, byte[] bytes)
  {
    if (!NGUITools.fileAccess)
      return false;
    string path = Application.persistentDataPath + "/" + fileName;
    if (bytes == null)
    {
      if (File.Exists(path))
        File.Delete(path);
      return true;
    }
    FileStream fileStream;
    try
    {
      fileStream = File.Create(path);
    }
    catch (Exception ex)
    {
      NGUIDebug.Log((object) ex.Message);
      return false;
    }
    fileStream.Write(bytes, 0, bytes.Length);
    fileStream.Close();
    return true;
  }

  public static byte[] Load(string fileName)
  {
    if (!NGUITools.fileAccess)
      return (byte[]) null;
    string path = Application.persistentDataPath + "/" + fileName;
    return File.Exists(path) ? File.ReadAllBytes(path) : (byte[]) null;
  }

  public static Color ApplyPMA(Color c)
  {
    if ((double) c.a != 1.0)
    {
      c.r *= c.a;
      c.g *= c.a;
      c.b *= c.a;
    }
    return c;
  }

  public static void MarkParentAsChanged(GameObject go)
  {
    UIRect[] componentsInChildren = go.GetComponentsInChildren<UIRect>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
      componentsInChildren[index].ParentHasChanged();
  }

  public static string clipboard
  {
    get
    {
      TextEditor textEditor = new TextEditor();
      textEditor.Paste();
      return textEditor.content.text;
    }
    set
    {
      TextEditor textEditor = new TextEditor();
      textEditor.content = new GUIContent(value);
      textEditor.OnFocus();
      textEditor.Copy();
    }
  }

  [Obsolete("Use NGUIText.EncodeColor instead")]
  public static string EncodeColor(Color c) => NGUIText.EncodeColor(c);

  [Obsolete("Use NGUIText.ParseColor instead")]
  public static Color ParseColor(string text, int offset) => NGUIText.ParseColor(text, offset);

  [Obsolete("Use NGUIText.StripSymbols instead")]
  public static string StripSymbols(string text) => NGUIText.StripSymbols(text);

  public static T AddMissingComponent<T>(this GameObject go) where T : Component
  {
    T obj = go.GetComponent<T>();
    if (Object.op_Equality((Object) (object) obj, (Object) null))
      obj = go.AddComponent<T>();
    return obj;
  }

  public static Vector3[] GetSides(this Camera cam)
  {
    return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), (Transform) null);
  }

  public static Vector3[] GetSides(this Camera cam, float depth)
  {
    return cam.GetSides(depth, (Transform) null);
  }

  public static Vector3[] GetSides(this Camera cam, Transform relativeTo)
  {
    return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
  }

  public static Vector3[] GetSides(this Camera cam, float depth, Transform relativeTo)
  {
    NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0.0f, 0.5f, depth));
    NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, depth));
    NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, depth));
    NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, depth));
    if (Object.op_Inequality((Object) relativeTo, (Object) null))
    {
      for (int index = 0; index < 4; ++index)
        NGUITools.mSides[index] = relativeTo.InverseTransformPoint(NGUITools.mSides[index]);
    }
    return NGUITools.mSides;
  }

  public static Vector3[] GetWorldCorners(this Camera cam)
  {
    return cam.GetWorldCorners(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), (Transform) null);
  }

  public static Vector3[] GetWorldCorners(this Camera cam, float depth)
  {
    return cam.GetWorldCorners(depth, (Transform) null);
  }

  public static Vector3[] GetWorldCorners(this Camera cam, Transform relativeTo)
  {
    return cam.GetWorldCorners(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
  }

  public static Vector3[] GetWorldCorners(this Camera cam, float depth, Transform relativeTo)
  {
    NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, depth));
    NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.0f, 1f, depth));
    NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 1f, depth));
    NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(1f, 0.0f, depth));
    if (Object.op_Inequality((Object) relativeTo, (Object) null))
    {
      for (int index = 0; index < 4; ++index)
        NGUITools.mSides[index] = relativeTo.InverseTransformPoint(NGUITools.mSides[index]);
    }
    return NGUITools.mSides;
  }
}
