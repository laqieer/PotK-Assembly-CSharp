// Decompiled with JetBrains decompiler
// Type: ModelUnits
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ModelUnits : MonoBehaviour
{
  public Dictionary<int, GameObject> Characters = new Dictionary<int, GameObject>();
  [HideInInspector]
  public List<GameObject> ModelList = new List<GameObject>();
  private static ModelUnits instance;
  [HideInInspector]
  public GameObject teamEdit;
  [HideInInspector]
  public GameObject ChangeSceneUnit0041;
  [HideInInspector]
  public GameObject ChangeScene004682;
  private CoroutineData<bool> coroutineMemory;
  [HideInInspector]
  public string currentSceneName = string.Empty;
  [HideInInspector]
  public PlayerDeck[] PlayerDecks;
  private List<UI3DModel> ui3DModels = new List<UI3DModel>();
  private bool stop;
  private bool loaded;
  private static bool isInitialized;
  private GameObject ui3DModelPrefab;
  private float prevTime;

  public static ModelUnits Instance => ModelUnits.instance;

  private void Awake()
  {
    if (ModelUnits.isInitialized)
      Object.Destroy((Object) this);
    else
      ModelUnits.instance = this;
    ModelUnits.isInitialized = true;
  }

  private void OnDestroy()
  {
    if (!Object.op_Equality((Object) ModelUnits.instance, (Object) this))
      return;
    ModelUnits.isInitialized = false;
  }

  private static void GetModelUnit() => new GameObject("ModelUnit").AddComponent<ModelUnits>();

  [DebuggerHidden]
  private IEnumerator LoadSLC3DModel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ModelUnits.\u003CLoadSLC3DModel\u003Ec__Iterator8C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator PreLoad3DModel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ModelUnits.\u003CPreLoad3DModel\u003Ec__Iterator8C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void LoadPlayerDeck(PlayerDeck[] pd)
  {
    if (this.loaded)
      return;
    this.loaded = true;
    this.PlayerDecks = pd;
    this.StartCoroutine(this.PreLoad3DModel());
  }

  public void SetScene(string str = "")
  {
    this.ChangeSceneUnit0041.SetActive(false);
    this.StartCoroutine("unit_0041SetActive");
  }

  public GameObject InstantiateModelUnits(GameObject character)
  {
    return this.Characters.ContainsValue(character) ? ObjectPoolController.Instantiate(character) : (GameObject) null;
  }

  public void DestroyModelUnits()
  {
    for (int index = 0; index < this.ModelList.Count; ++index)
    {
      if (Object.op_Implicit((Object) this.ModelList[index]) && Object.op_Implicit((Object) this.ModelList[index].gameObject))
        ObjectPoolController.Destroy(this.ModelList[index].gameObject);
    }
    if (this.ModelList.Count <= 500)
      return;
    this.DidReceiveMemoryWarning(this.ModelList.Count.ToString());
  }

  private void LayerChange(int layer, Transform to)
  {
    ((Component) to).gameObject.layer = layer;
    foreach (Component componentsInChild in ((Component) to).GetComponentsInChildren<Transform>())
      componentsInChild.gameObject.layer = layer;
  }

  [DebuggerHidden]
  private IEnumerator StartCheckMemory()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ModelUnits.\u003CStartCheckMemory\u003Ec__Iterator8C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CheckUsedMemory()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ModelUnits.\u003CCheckUsedMemory\u003Ec__Iterator8C5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MyUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ModelUnits.\u003CMyUpdate\u003Ec__Iterator8C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnApplicationPause(bool paused)
  {
    if (!paused || this.coroutineMemory == null)
      return;
    this.coroutineMemory.Stop();
  }

  public void DidReceiveMemoryWarning(string message)
  {
    if ((double) Time.realtimeSinceStartup - (double) this.prevTime < 300.0)
      return;
    this.prevTime = Time.realtimeSinceStartup;
    for (int index = 0; index < this.ModelList.Count; ++index)
    {
      if (Object.op_Implicit((Object) this.ModelList[index].gameObject))
      {
        this.ModelList[index].SetActive(false);
        Object.Destroy((Object) this.ModelList[index]);
      }
    }
    this.ModelList.Clear();
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Singleton<ResourceManager>.GetInstance().ClearCache();
    Resources.UnloadUnusedAssets();
  }
}
