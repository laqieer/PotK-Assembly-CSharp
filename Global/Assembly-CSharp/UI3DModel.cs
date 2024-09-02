// Decompiled with JetBrains decompiler
// Type: UI3DModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UI3DModel : MonoBehaviour
{
  public bool lightOn = true;
  [SerializeField]
  private Transform ActionTarget;
  public Transform ModelTarget;
  public Camera ModelCamera;
  [SerializeField]
  private UITexture ui_texture;
  public List<string> PlayAnimStateList;
  public float SetScale = 220f;
  public UI3DModelCreate model_creater_;
  private GameObject Model;
  private Transform ModelTrans;
  private GameObject lightGameObject;
  private int debug_number;
  private bool isPlay;
  private bool isGear;
  private bool pick_up;
  private bool unit_edit;
  private float wait_counter;
  public UIWidget widget;
  public UIRoot root;

  public UITexture uiTexture => this.ui_texture;

  public Texture GetRenderTexture() => (Texture) this.ModelCamera.targetTexture;

  private void Awake()
  {
    this.root = Object.FindObjectOfType<UIRoot>();
    this.widget = ((Component) this).GetComponent<UIWidget>();
  }

  public void SetActiveAlpha(bool flag)
  {
    if (flag)
      this.widget.alpha = 1f;
    else
      this.widget.alpha = 0.0f;
  }

  public void Remove()
  {
    if (!Object.op_Inequality((Object) this.Model, (Object) null))
      return;
    Object.Destroy((Object) this.Model);
  }

  [DebuggerHidden]
  public IEnumerator UnitEdit(PlayerUnit pu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModel.\u003CUnitEdit\u003Ec__Iterator3A1()
    {
      pu = pu,
      \u003C\u0024\u003Epu = pu,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Unit(PlayerUnit pu, System.Action callback = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModel.\u003CUnit\u003Ec__Iterator3A2()
    {
      pu = pu,
      callback = callback,
      \u003C\u0024\u003Epu = pu,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator HistoryUnit(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModel.\u003CHistoryUnit\u003Ec__Iterator3A3()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PickUpUnit(UnitUnit uu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModel.\u003CPickUpUnit\u003Ec__Iterator3A4()
    {
      uu = uu,
      \u003C\u0024\u003Euu = uu,
      \u003C\u003Ef__this = this
    };
  }

  public void Action()
  {
    this.StartCoroutine(this.CenterRotate());
    if (Object.op_Equality((Object) this.model_creater_.UnitAnimator, (Object) null) || this.isPlay)
      return;
    AnimatorStateInfo animatorStateInfo = this.model_creater_.UnitAnimator.GetCurrentAnimatorStateInfo(0);
    if (!((AnimatorStateInfo) ref animatorStateInfo).IsName("wait"))
      return;
    this.AnimAction();
  }

  private void PickUpUnitInit(UnitCameraPattern cameraData)
  {
    if (Object.op_Equality((Object) this.ModelCamera.targetTexture, (Object) null))
    {
      this.ModelCamera.targetTexture = new RenderTexture(512, 512, 16);
      this.ModelCamera.targetTexture.antiAliasing = 1;
      ((Texture) this.ModelCamera.targetTexture).wrapMode = (TextureWrapMode) 1;
      ((Texture) this.ModelCamera.targetTexture).filterMode = (FilterMode) 1;
      this.ModelCamera.targetTexture.enableRandomWrite = false;
      this.ModelCamera.clearFlags = (CameraClearFlags) 2;
      this.ModelCamera.backgroundColor = Color.clear;
      UITexture component = ((Component) this).gameObject.GetComponent<UITexture>();
      component.mainTexture = (Texture) this.ModelCamera.targetTexture;
      float width = (float) this.ModelCamera.targetTexture.width;
      float height = (float) this.ModelCamera.targetTexture.height;
      component.SetDimensions((int) width, (int) height);
      component.uvRect = new Rect(0.25f, 0.0f, 1f, 1f);
    }
    this.isPlay = false;
    this.ModelTrans = this.model_creater_.BaseModel.transform;
    this.Model = this.model_creater_.BaseModel;
    ((Object) this.Model).name = ((Object) this.Model).name + (object) this.debug_number;
    this.Model.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
    ((Component) this.ModelCamera).transform.parent = (Transform) null;
    ((Component) this.ModelCamera).transform.localScale = new Vector3(1f, 1f, 1f);
    this.ModelCamera.fieldOfView = cameraData.angle_of_view;
    this.ModelTrans.localScale = new Vector3(1f, 1f, 1f);
    this.ModelTrans.localPosition = new Vector3(cameraData.unit_x, cameraData.unit_y, cameraData.unit_z);
    this.ModelTrans.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.ModelTarget.localPosition = new Vector3(cameraData.camera_x, cameraData.camera_y, cameraData.camera_z);
    this.ActionTarget.localPosition = new Vector3(0.0f, -1f, -99999f);
    this.LayerChange(((Component) this.ModelTarget).gameObject.layer, this.ModelTrans);
    if (Object.op_Inequality((Object) this.lightGameObject, (Object) null) || !this.lightOn)
      return;
    this.lightGameObject = new GameObject("Directional Light");
    this.lightGameObject.AddComponent<Light>();
    this.lightGameObject.GetComponent<Light>().type = (LightType) 1;
    this.lightGameObject.GetComponent<Light>().color = Color.white;
    this.lightGameObject.GetComponent<Light>().intensity = 0.1f;
    this.lightGameObject.transform.position = new Vector3(0.0f, 1f, 0.0f);
    this.lightGameObject.transform.localEulerAngles = Consts.GetInstance().UI3DMODEL_DIRECTIONAL_LIGHT_ROUTATE;
    this.lightGameObject.transform.parent = ((Component) this).transform;
    this.lightGameObject.layer = ((Component) this.ModelTarget).gameObject.layer;
  }

  private void UnitEditInit(UnitCameraPattern cameraData)
  {
    if (Object.op_Equality((Object) this.ModelCamera.targetTexture, (Object) null))
    {
      this.ModelCamera.targetTexture = new RenderTexture(512, 512, 16);
      this.ModelCamera.targetTexture.antiAliasing = 1;
      ((Texture) this.ModelCamera.targetTexture).wrapMode = (TextureWrapMode) 1;
      ((Texture) this.ModelCamera.targetTexture).filterMode = (FilterMode) 1;
      this.ModelCamera.targetTexture.enableRandomWrite = false;
      this.ModelCamera.clearFlags = (CameraClearFlags) 2;
      this.ModelCamera.backgroundColor = Color.clear;
      ((Component) this).gameObject.GetComponent<UITexture>().mainTexture = (Texture) this.ModelCamera.targetTexture;
    }
    this.isPlay = false;
    this.ModelTrans = this.model_creater_.BaseModel.transform;
    this.Model = this.model_creater_.BaseModel;
    ((Object) this.Model).name = ((Object) this.Model).name + (object) this.debug_number;
    this.SetScale = 1f;
    this.ui_texture.SetDimensions(360, 360);
    this.LayerChange(((Component) this.ModelTarget).gameObject.layer, this.ModelTrans);
    Object.Destroy((Object) ((Component) this).GetComponent<UIPanel>());
    Object.Destroy((Object) ((Component) this).GetComponent<UIButton>());
    this.widget.depth = 14;
    ((Component) this.ModelCamera).transform.parent = (Transform) null;
    ((Component) this.ModelCamera).transform.localScale = new Vector3(1f, 1f, 1f);
    this.ModelTrans.localScale = new Vector3(1f, 1f, 1f);
    this.ModelTrans.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.ModelTrans.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.ModelTarget.localPosition = new Vector3(0.0f, -1.8f, 5f);
    this.ActionTarget.localPosition = new Vector3(0.0f, 0.0f, 1f);
    if (Object.op_Inequality((Object) this.lightGameObject, (Object) null) || !this.lightOn)
      return;
    this.lightGameObject = new GameObject("Directional Light");
    this.lightGameObject.AddComponent<Light>();
    this.lightGameObject.GetComponent<Light>().type = (LightType) 1;
    this.lightGameObject.GetComponent<Light>().color = Color.white;
    this.lightGameObject.GetComponent<Light>().intensity = 0.1f;
    this.lightGameObject.transform.position = new Vector3(0.0f, 1f, 0.0f);
    this.lightGameObject.transform.localEulerAngles = Consts.GetInstance().UI3DMODEL_DIRECTIONAL_LIGHT_ROUTATE;
    this.lightGameObject.transform.parent = ((Component) this).transform;
    this.lightGameObject.layer = ((Component) this.ModelTarget).gameObject.layer;
  }

  private void Init(UnitCameraPattern cameraData)
  {
    if (Object.op_Equality((Object) this.ModelCamera.targetTexture, (Object) null))
    {
      this.ModelCamera.targetTexture = new RenderTexture(316, 376, 16);
      this.ModelCamera.targetTexture.antiAliasing = 1;
      ((Texture) this.ModelCamera.targetTexture).wrapMode = (TextureWrapMode) 1;
      ((Texture) this.ModelCamera.targetTexture).filterMode = (FilterMode) 1;
      this.ModelCamera.targetTexture.enableRandomWrite = false;
      this.ModelCamera.clearFlags = (CameraClearFlags) 2;
      this.ModelCamera.backgroundColor = Color.clear;
      ((Component) this).gameObject.GetComponent<UITexture>().mainTexture = (Texture) this.ModelCamera.targetTexture;
    }
    this.isPlay = false;
    this.ModelTrans = this.model_creater_.BaseModel.transform;
    this.Model = this.model_creater_.BaseModel;
    this.ui_texture.SetDimensions(158, 188);
    ((Component) this.ModelCamera).transform.parent = (Transform) null;
    ((Component) this.ModelCamera).transform.localScale = new Vector3(1f, 1f, 1f);
    this.ActionTarget.localPosition = new Vector3(0.0f, -1f, -99999f);
    this.ModelCamera.fieldOfView = cameraData.angle_of_view;
    this.ModelTrans.localScale = new Vector3(1f, 1f, 1f);
    this.ModelTrans.localPosition = new Vector3(cameraData.unit_x, cameraData.unit_y, cameraData.unit_z);
    this.ModelTrans.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.ModelTarget.localPosition = new Vector3(cameraData.camera_x, cameraData.camera_y, cameraData.camera_z);
    this.LayerChange(((Component) this.ModelTarget).gameObject.layer, this.ModelTrans);
    if (Object.op_Inequality((Object) this.lightGameObject, (Object) null) || !this.lightOn)
      return;
    this.lightGameObject = new GameObject("Directional Light");
    this.lightGameObject.AddComponent<Light>();
    this.lightGameObject.GetComponent<Light>().type = (LightType) 1;
    this.lightGameObject.GetComponent<Light>().color = Color.white;
    this.lightGameObject.GetComponent<Light>().intensity = 0.1f;
    this.lightGameObject.transform.position = new Vector3(0.0f, 1f, 0.0f);
    this.lightGameObject.transform.localEulerAngles = Consts.GetInstance().UI3DMODEL_DIRECTIONAL_LIGHT_ROUTATE;
    this.lightGameObject.transform.parent = ((Component) this).transform;
    this.lightGameObject.layer = ((Component) this.ModelTarget).gameObject.layer;
  }

  private void HistoryInit(UnitCameraPattern cameraData)
  {
    if (Object.op_Equality((Object) this.ModelCamera.targetTexture, (Object) null))
    {
      this.ModelCamera.targetTexture = new RenderTexture(316, 396, 16);
      this.ModelCamera.targetTexture.antiAliasing = 1;
      ((Texture) this.ModelCamera.targetTexture).wrapMode = (TextureWrapMode) 1;
      ((Texture) this.ModelCamera.targetTexture).filterMode = (FilterMode) 1;
      this.ModelCamera.targetTexture.enableRandomWrite = false;
      this.ModelCamera.farClipPlane = 30f;
      ((Component) this).gameObject.GetComponent<UITexture>().mainTexture = (Texture) this.ModelCamera.targetTexture;
    }
    this.isPlay = false;
    this.SetScale = 0.001760563f / ((Component) this.root).transform.localScale.x;
    this.ModelTrans = this.model_creater_.BaseModel.transform;
    this.Model = this.model_creater_.BaseModel;
    this.ui_texture.SetDimensions(158, 198);
    ((Component) this.ModelCamera).transform.parent = (Transform) null;
    ((Component) this.ModelCamera).transform.localScale = new Vector3(1f, 1f, 1f);
    this.ActionTarget.localPosition = new Vector3(0.0f, -1f, -99999f);
    this.ModelCamera.fieldOfView = cameraData.angle_of_view;
    this.ModelTrans.localScale = new Vector3(1f, 1f, 1f);
    this.ModelTrans.localPosition = new Vector3(cameraData.unit_x, cameraData.unit_y, cameraData.unit_z);
    this.ModelTrans.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.ModelTarget.localPosition = new Vector3(cameraData.camera_x, cameraData.camera_y, cameraData.camera_z);
    this.LayerChange(((Component) this.ModelTarget).gameObject.layer, this.ModelTrans);
    if (Object.op_Inequality((Object) this.lightGameObject, (Object) null) || !this.lightOn)
      return;
    this.lightGameObject = new GameObject("Directional Light");
    this.lightGameObject.AddComponent<Light>();
    this.lightGameObject.GetComponent<Light>().type = (LightType) 1;
    this.lightGameObject.GetComponent<Light>().color = Color.white;
    this.lightGameObject.GetComponent<Light>().intensity = 0.1f;
    this.lightGameObject.transform.position = new Vector3(0.0f, 1f, 0.0f);
    this.lightGameObject.transform.localEulerAngles = Consts.GetInstance().UI3DMODEL_DIRECTIONAL_LIGHT_ROUTATE;
    this.lightGameObject.transform.parent = ((Component) this).transform;
    this.lightGameObject.layer = ((Component) this.ModelTarget).gameObject.layer;
  }

  private void Update()
  {
    if (this.unit_edit || Object.op_Equality((Object) this.Model, (Object) null) || Object.op_Equality((Object) this.model_creater_.UnitAnimator, (Object) null))
      return;
    if (!this.isPlay)
    {
      if (this.isGear)
      {
        this.ModelTarget.Rotate(Vector3.op_Multiply(new Vector3(0.0f, 30f, 0.0f), Time.deltaTime));
      }
      else
      {
        AnimatorStateInfo animatorStateInfo = this.model_creater_.UnitAnimator.GetCurrentAnimatorStateInfo(0);
        if (((AnimatorStateInfo) ref animatorStateInfo).IsName("wait") || this.pick_up)
          this.ModelTarget.Rotate(Vector3.op_Multiply(new Vector3(0.0f, 30f, 0.0f), Time.deltaTime));
      }
    }
    if (this.pick_up)
      return;
    AnimatorStateInfo animatorStateInfo1 = this.model_creater_.UnitAnimator.GetCurrentAnimatorStateInfo(0);
    if (((AnimatorStateInfo) ref animatorStateInfo1).IsName("wait"))
      this.wait_counter = 0.0f;
    else
      this.wait_counter += Time.deltaTime;
    if ((double) this.wait_counter <= 3.0)
      return;
    this.model_creater_.UnitAnimator.SetTrigger("to_wait");
    if (Object.op_Equality((Object) this.model_creater_.VehicleAnimator, (Object) null))
      return;
    this.model_creater_.VehicleAnimator.SetTrigger("to_wait");
  }

  private void LayerChange(int layer, Transform to)
  {
    ((Component) to).gameObject.layer = layer;
    foreach (Transform to1 in to)
      this.LayerChange(layer, to1);
  }

  private Future<GameObject> LoadModel(int id)
  {
    Future<GameObject> future = !this.isGear ? MasterData.UnitUnit[id].LoadModelDuel() : MasterData.GearGear[id].LoadModel();
    if (future == null)
    {
      Debug.LogWarning((object) ("Model could not be loaded for id " + (object) id));
      MasterData.UnitUnit[100111].LoadModelDuel();
    }
    return future;
  }

  private void AnimAction()
  {
    this.isPlay = true;
    string str = NC.RandomChoice<string>(this.PlayAnimStateList);
    this.model_creater_.UnitAnimator.Play(str, 0);
    this.model_creater_.UnitAnimator.SetBool("to_wait", false);
    if (Object.op_Equality((Object) this.model_creater_.VehicleAnimator, (Object) null))
      return;
    this.model_creater_.VehicleAnimator.Play(str, 0);
    this.model_creater_.VehicleAnimator.SetBool("to_wait", false);
  }

  [DebuggerHidden]
  private IEnumerator CenterRotate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModel.\u003CCenterRotate\u003Ec__Iterator3A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDestroy()
  {
    if (!Object.op_Implicit((Object) this.ModelCamera))
      return;
    Object.Destroy((Object) ((Component) this.ModelCamera).gameObject);
  }

  public void DestroyModelCamera()
  {
    if (!Object.op_Implicit((Object) this.ModelCamera))
      return;
    Object.Destroy((Object) ((Component) this.ModelCamera).gameObject);
  }
}
