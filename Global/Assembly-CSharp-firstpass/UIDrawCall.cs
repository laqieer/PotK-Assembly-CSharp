// Decompiled with JetBrains decompiler
// Type: UIDrawCall
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Internal/Draw Call")]
[ExecuteInEditMode]
public class UIDrawCall : MonoBehaviour
{
  private const int maxIndexBufferCache = 10;
  private static BetterList<UIDrawCall> mActiveList = new BetterList<UIDrawCall>();
  private static BetterList<UIDrawCall> mInactiveList = new BetterList<UIDrawCall>();
  [HideInInspector]
  [NonSerialized]
  public int depthStart = int.MaxValue;
  [HideInInspector]
  [NonSerialized]
  public int depthEnd = int.MinValue;
  [HideInInspector]
  [NonSerialized]
  public UIPanel manager;
  [HideInInspector]
  [NonSerialized]
  public UIPanel panel;
  [HideInInspector]
  [NonSerialized]
  public bool alwaysOnScreen;
  [HideInInspector]
  [NonSerialized]
  public BetterList<Vector3> verts = new BetterList<Vector3>();
  [HideInInspector]
  [NonSerialized]
  public BetterList<Vector3> norms = new BetterList<Vector3>();
  [HideInInspector]
  [NonSerialized]
  public BetterList<Vector4> tans = new BetterList<Vector4>();
  [HideInInspector]
  [NonSerialized]
  public BetterList<Vector2> uvs = new BetterList<Vector2>();
  [HideInInspector]
  [NonSerialized]
  public BetterList<Color32> cols = new BetterList<Color32>();
  private Material mMaterial;
  private Texture mTexture;
  private Shader mShader;
  private UIDrawCall.Clipping mClipping;
  private Vector4 mClipRange;
  private Vector2 mClipSoft;
  private Transform mTrans;
  private Mesh mMesh;
  private MeshFilter mFilter;
  private MeshRenderer mRenderer;
  private Material mDynamicMat;
  private int[] mIndices;
  private bool mRebuildMat = true;
  private bool mReset = true;
  private int mRenderQueue = 3000;
  private UIDrawCall.Clipping mLastClip;
  private int mTriangles;
  [NonSerialized]
  public bool isDirty;
  private static List<int[]> mCache = new List<int[]>(10);

  [Obsolete("Use UIDrawCall.activeList")]
  public static BetterList<UIDrawCall> list => UIDrawCall.mActiveList;

  public static BetterList<UIDrawCall> activeList => UIDrawCall.mActiveList;

  public static BetterList<UIDrawCall> inactiveList => UIDrawCall.mInactiveList;

  public int renderQueue
  {
    get => this.mRenderQueue;
    set
    {
      if (this.mRenderQueue == value)
        return;
      this.mRenderQueue = value;
      if (!Object.op_Inequality((Object) this.mDynamicMat, (Object) null))
        return;
      this.mDynamicMat.renderQueue = value;
    }
  }

  public int sortingOrder
  {
    get
    {
      return Object.op_Inequality((Object) this.mRenderer, (Object) null) ? ((Renderer) this.mRenderer).sortingOrder : 0;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.mRenderer, (Object) null) || ((Renderer) this.mRenderer).sortingOrder == value)
        return;
      ((Renderer) this.mRenderer).sortingOrder = value;
    }
  }

  public int finalRenderQueue
  {
    get
    {
      return Object.op_Inequality((Object) this.mDynamicMat, (Object) null) ? this.mDynamicMat.renderQueue : this.mRenderQueue;
    }
  }

  public Transform cachedTransform
  {
    get
    {
      if (Object.op_Equality((Object) this.mTrans, (Object) null))
        this.mTrans = ((Component) this).transform;
      return this.mTrans;
    }
  }

  public Material baseMaterial
  {
    get => this.mMaterial;
    set
    {
      if (!Object.op_Inequality((Object) this.mMaterial, (Object) value))
        return;
      this.mMaterial = value;
      this.mRebuildMat = true;
    }
  }

  public Material dynamicMaterial => this.mDynamicMat;

  public Texture mainTexture
  {
    get => this.mTexture;
    set
    {
      this.mTexture = value;
      if (!Object.op_Inequality((Object) this.mDynamicMat, (Object) null))
        return;
      this.mDynamicMat.mainTexture = value;
    }
  }

  public Shader shader
  {
    get => this.mShader;
    set
    {
      if (!Object.op_Inequality((Object) this.mShader, (Object) value))
        return;
      this.mShader = value;
      this.mRebuildMat = true;
    }
  }

  public int triangles
  {
    get => Object.op_Inequality((Object) this.mMesh, (Object) null) ? this.mTriangles : 0;
  }

  public bool isClipped => this.mClipping != UIDrawCall.Clipping.None;

  public UIDrawCall.Clipping clipping
  {
    get => this.mClipping;
    set
    {
      if (this.mClipping == value)
        return;
      this.mClipping = value;
      this.mReset = true;
    }
  }

  public Vector4 clipRange
  {
    get => this.mClipRange;
    set => this.mClipRange = value;
  }

  public Vector2 clipSoftness
  {
    get => this.mClipSoft;
    set => this.mClipSoft = value;
  }

  private void CreateMaterial()
  {
    string str = (!Object.op_Inequality((Object) this.mShader, (Object) null) ? (!Object.op_Inequality((Object) this.mMaterial, (Object) null) ? "Unlit/Transparent Colored" : ((Object) this.mMaterial.shader).name) : ((Object) this.mShader).name).Replace("GUI/Text Shader", "Unlit/Text").Replace(" (AlphaClip)", string.Empty).Replace(" (SoftClip)", string.Empty);
    Shader shader = this.mClipping != UIDrawCall.Clipping.SoftClip ? (this.mClipping != UIDrawCall.Clipping.AlphaClip ? Shader.Find(str) : Shader.Find(str + " (AlphaClip)")) : Shader.Find(str + " (SoftClip)");
    if (Object.op_Inequality((Object) this.mMaterial, (Object) null))
    {
      this.mDynamicMat = new Material(this.mMaterial);
      ((Object) this.mDynamicMat).hideFlags = (HideFlags) 60;
      this.mDynamicMat.CopyPropertiesFromMaterial(this.mMaterial);
    }
    else
    {
      this.mDynamicMat = new Material(shader);
      ((Object) this.mDynamicMat).hideFlags = (HideFlags) 60;
    }
    if (Object.op_Inequality((Object) shader, (Object) null))
    {
      this.mDynamicMat.shader = shader;
    }
    else
    {
      if (this.mClipping == UIDrawCall.Clipping.None)
        return;
      this.mClipping = UIDrawCall.Clipping.None;
    }
  }

  private Material RebuildMaterial()
  {
    NGUITools.DestroyImmediate((Object) this.mDynamicMat);
    this.CreateMaterial();
    this.mDynamicMat.renderQueue = this.mRenderQueue;
    this.mLastClip = this.mClipping;
    if (Object.op_Inequality((Object) this.mTexture, (Object) null))
      this.mDynamicMat.mainTexture = this.mTexture;
    if (Object.op_Inequality((Object) this.mRenderer, (Object) null))
      ((Renderer) this.mRenderer).sharedMaterials = new Material[1]
      {
        this.mDynamicMat
      };
    return this.mDynamicMat;
  }

  private void UpdateMaterials()
  {
    if (this.mRebuildMat || Object.op_Equality((Object) this.mDynamicMat, (Object) null) || this.mClipping != this.mLastClip)
    {
      this.RebuildMaterial();
      this.mRebuildMat = false;
    }
    else
    {
      if (!Object.op_Inequality((Object) ((Renderer) this.mRenderer).sharedMaterial, (Object) this.mDynamicMat))
        return;
      ((Renderer) this.mRenderer).sharedMaterials = new Material[1]
      {
        this.mDynamicMat
      };
    }
  }

  public void UpdateGeometry()
  {
    int size = this.verts.size;
    if (size > 0 && size == this.uvs.size && size == this.cols.size && size % 4 == 0)
    {
      if (Object.op_Equality((Object) this.mFilter, (Object) null))
        this.mFilter = ((Component) this).gameObject.GetComponent<MeshFilter>();
      if (Object.op_Equality((Object) this.mFilter, (Object) null))
        this.mFilter = ((Component) this).gameObject.AddComponent<MeshFilter>();
      if (this.verts.size < 65000)
      {
        int indexCount = (size >> 1) * 3;
        bool flag1 = this.mIndices == null || this.mIndices.Length != indexCount;
        if (Object.op_Equality((Object) this.mMesh, (Object) null))
        {
          this.mMesh = new Mesh();
          ((Object) this.mMesh).hideFlags = (HideFlags) 52;
          ((Object) this.mMesh).name = !Object.op_Inequality((Object) this.mMaterial, (Object) null) ? "Mesh" : ((Object) this.mMaterial).name;
          this.mMesh.MarkDynamic();
          flag1 = true;
        }
        bool flag2 = this.uvs.buffer.Length != this.verts.buffer.Length || this.cols.buffer.Length != this.verts.buffer.Length || this.norms.buffer != null && this.norms.buffer.Length != this.verts.buffer.Length || this.tans.buffer != null && this.tans.buffer.Length != this.verts.buffer.Length;
        if (!flag2 && this.panel.renderQueue != UIPanel.RenderQueue.Automatic)
          flag2 = Object.op_Equality((Object) this.mMesh, (Object) null) || this.mMesh.vertexCount != this.verts.buffer.Length;
        if (!flag2 && this.verts.size << 1 < this.verts.buffer.Length)
          flag2 = true;
        this.mTriangles = this.verts.size >> 1;
        if (flag2 || this.verts.buffer.Length > 65000)
        {
          if (flag2 || this.mMesh.vertexCount != this.verts.size)
          {
            this.mMesh.Clear();
            flag1 = true;
          }
          this.mMesh.vertices = this.verts.ToArray();
          this.mMesh.uv = this.uvs.ToArray();
          this.mMesh.colors32 = this.cols.ToArray();
          if (this.norms != null)
            this.mMesh.normals = this.norms.ToArray();
          if (this.tans != null)
            this.mMesh.tangents = this.tans.ToArray();
        }
        else
        {
          if (this.mMesh.vertexCount != this.verts.buffer.Length)
          {
            this.mMesh.Clear();
            flag1 = true;
          }
          this.mMesh.vertices = this.verts.buffer;
          this.mMesh.uv = this.uvs.buffer;
          this.mMesh.colors32 = this.cols.buffer;
          if (this.norms != null)
            this.mMesh.normals = this.norms.buffer;
          if (this.tans != null)
            this.mMesh.tangents = this.tans.buffer;
        }
        if (flag1)
        {
          this.mIndices = this.GenerateCachedIndexBuffer(size, indexCount);
          this.mMesh.triangles = this.mIndices;
        }
        if (flag2 || !this.alwaysOnScreen)
          this.mMesh.RecalculateBounds();
        this.mFilter.mesh = this.mMesh;
      }
      else
      {
        this.mTriangles = 0;
        if (Object.op_Inequality((Object) this.mFilter.mesh, (Object) null))
          this.mFilter.mesh.Clear();
        Debug.LogError((object) ("Too many vertices on one panel: " + (object) this.verts.size));
      }
      if (Object.op_Equality((Object) this.mRenderer, (Object) null))
        this.mRenderer = ((Component) this).gameObject.GetComponent<MeshRenderer>();
      if (Object.op_Equality((Object) this.mRenderer, (Object) null))
        this.mRenderer = ((Component) this).gameObject.AddComponent<MeshRenderer>();
      this.UpdateMaterials();
    }
    else
    {
      if (Object.op_Inequality((Object) this.mFilter.mesh, (Object) null))
        this.mFilter.mesh.Clear();
      Debug.LogError((object) ("UIWidgets must fill the buffer with 4 vertices per quad. Found " + (object) size));
    }
    this.verts.Clear();
    this.uvs.Clear();
    this.cols.Clear();
    this.norms.Clear();
    this.tans.Clear();
  }

  private int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
  {
    int index1 = 0;
    for (int count = UIDrawCall.mCache.Count; index1 < count; ++index1)
    {
      int[] cachedIndexBuffer = UIDrawCall.mCache[index1];
      if (cachedIndexBuffer != null && cachedIndexBuffer.Length == indexCount)
        return cachedIndexBuffer;
    }
    int[] cachedIndexBuffer1 = new int[indexCount];
    int num1 = 0;
    for (int index2 = 0; index2 < vertexCount; index2 += 4)
    {
      int[] numArray1 = cachedIndexBuffer1;
      int index3 = num1;
      int num2 = index3 + 1;
      int num3 = index2;
      numArray1[index3] = num3;
      int[] numArray2 = cachedIndexBuffer1;
      int index4 = num2;
      int num4 = index4 + 1;
      int num5 = index2 + 1;
      numArray2[index4] = num5;
      int[] numArray3 = cachedIndexBuffer1;
      int index5 = num4;
      int num6 = index5 + 1;
      int num7 = index2 + 2;
      numArray3[index5] = num7;
      int[] numArray4 = cachedIndexBuffer1;
      int index6 = num6;
      int num8 = index6 + 1;
      int num9 = index2 + 2;
      numArray4[index6] = num9;
      int[] numArray5 = cachedIndexBuffer1;
      int index7 = num8;
      int num10 = index7 + 1;
      int num11 = index2 + 3;
      numArray5[index7] = num11;
      int[] numArray6 = cachedIndexBuffer1;
      int index8 = num10;
      num1 = index8 + 1;
      int num12 = index2;
      numArray6[index8] = num12;
    }
    if (UIDrawCall.mCache.Count > 10)
      UIDrawCall.mCache.RemoveAt(0);
    UIDrawCall.mCache.Add(cachedIndexBuffer1);
    return cachedIndexBuffer1;
  }

  private void OnWillRenderObject()
  {
    if (this.mReset)
    {
      this.mReset = false;
      this.UpdateMaterials();
    }
    if (!Object.op_Inequality((Object) this.mDynamicMat, (Object) null) || !this.isClipped || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
      return;
    this.mDynamicMat.mainTextureOffset = new Vector2(-this.mClipRange.x / this.mClipRange.z, -this.mClipRange.y / this.mClipRange.w);
    this.mDynamicMat.mainTextureScale = new Vector2(1f / this.mClipRange.z, 1f / this.mClipRange.w);
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(1000f, 1000f);
    if ((double) this.mClipSoft.x > 0.0)
      vector2.x = this.mClipRange.z / this.mClipSoft.x;
    if ((double) this.mClipSoft.y > 0.0)
      vector2.y = this.mClipRange.w / this.mClipSoft.y;
    this.mDynamicMat.SetVector("_ClipSharpness", Vector4.op_Implicit(vector2));
  }

  private void OnEnable() => this.mRebuildMat = true;

  private void OnDisable()
  {
    this.depthStart = int.MaxValue;
    this.depthEnd = int.MinValue;
    this.panel = (UIPanel) null;
    this.manager = (UIPanel) null;
    this.mMaterial = (Material) null;
    this.mTexture = (Texture) null;
    NGUITools.DestroyImmediate((Object) this.mDynamicMat);
    this.mDynamicMat = (Material) null;
  }

  private void OnDestroy() => NGUITools.DestroyImmediate((Object) this.mMesh);

  public static UIDrawCall Create(UIPanel panel, Material mat, Texture tex, Shader shader)
  {
    return UIDrawCall.Create((string) null, panel, mat, tex, shader);
  }

  private static UIDrawCall Create(
    string name,
    UIPanel pan,
    Material mat,
    Texture tex,
    Shader shader)
  {
    UIDrawCall uiDrawCall = UIDrawCall.Create(name);
    ((Component) uiDrawCall).gameObject.layer = pan.cachedGameObject.layer;
    uiDrawCall.clipping = pan.clipping;
    uiDrawCall.baseMaterial = mat;
    uiDrawCall.mainTexture = tex;
    uiDrawCall.shader = shader;
    uiDrawCall.renderQueue = pan.startingRenderQueue;
    uiDrawCall.sortingOrder = pan.sortingOrder;
    uiDrawCall.manager = pan;
    return uiDrawCall;
  }

  private static UIDrawCall Create(string name)
  {
    if (UIDrawCall.mInactiveList.size > 0)
    {
      UIDrawCall uiDrawCall = UIDrawCall.mInactiveList.Pop();
      UIDrawCall.mActiveList.Add(uiDrawCall);
      if (name != null)
        ((Object) uiDrawCall).name = name;
      NGUITools.SetActive(((Component) uiDrawCall).gameObject, true);
      return uiDrawCall;
    }
    GameObject gameObject = new GameObject(name);
    Object.DontDestroyOnLoad((Object) gameObject);
    UIDrawCall uiDrawCall1 = gameObject.AddComponent<UIDrawCall>();
    UIDrawCall.mActiveList.Add(uiDrawCall1);
    return uiDrawCall1;
  }

  public static void ClearAll()
  {
    bool isPlaying = Application.isPlaying;
    int size = UIDrawCall.mActiveList.size;
    while (size > 0)
    {
      UIDrawCall mActive = UIDrawCall.mActiveList[--size];
      if (Object.op_Implicit((Object) mActive))
      {
        if (isPlaying)
          NGUITools.SetActive(((Component) mActive).gameObject, false);
        else
          NGUITools.DestroyImmediate((Object) ((Component) mActive).gameObject);
      }
    }
    UIDrawCall.mActiveList.Clear();
  }

  public static void ReleaseAll()
  {
    UIDrawCall.ClearAll();
    UIDrawCall.ReleaseInactive();
  }

  public static void ReleaseInactive()
  {
    int size = UIDrawCall.mInactiveList.size;
    while (size > 0)
    {
      UIDrawCall mInactive = UIDrawCall.mInactiveList[--size];
      if (Object.op_Implicit((Object) mInactive))
        NGUITools.DestroyImmediate((Object) ((Component) mInactive).gameObject);
    }
    UIDrawCall.mInactiveList.Clear();
  }

  public static int Count(UIPanel panel)
  {
    int num = 0;
    for (int i = 0; i < UIDrawCall.mActiveList.size; ++i)
    {
      if (Object.op_Equality((Object) UIDrawCall.mActiveList[i].manager, (Object) panel))
        ++num;
    }
    return num;
  }

  public static void Destroy(UIDrawCall dc)
  {
    if (!Object.op_Implicit((Object) dc))
      return;
    if (Application.isPlaying)
    {
      if (!UIDrawCall.mActiveList.Remove(dc))
        return;
      NGUITools.SetActive(((Component) dc).gameObject, false);
      UIDrawCall.mInactiveList.Add(dc);
    }
    else
    {
      UIDrawCall.mActiveList.Remove(dc);
      NGUITools.DestroyImmediate((Object) ((Component) dc).gameObject);
    }
  }

  public enum Clipping
  {
    None = 0,
    AlphaClip = 2,
    SoftClip = 3,
    ConstrainButDontClip = 4,
  }
}
