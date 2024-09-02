// Decompiled with JetBrains decompiler
// Type: NGSceneManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGSceneManager : Singleton<NGSceneManager>
{
  private Stack<NGSceneManager.SceneWrapper> sceneStack = new Stack<NGSceneManager.SceneWrapper>();
  private Dictionary<string, NGSceneManager.SceneWrapper> loadedScenes = new Dictionary<string, NGSceneManager.SceneWrapper>();
  private NGSceneManager.SceneWrapper tempScene;
  private NGSceneManager.SceneWrapper currentScene;
  private AsyncOperation loadAsync;
  private List<NGSceneManager.SceneWrapper> destroyedSceneList;
  private Queue<IEnumerator> changeSceneQueue = new Queue<IEnumerator>();
  private bool isError;
  private bool isStartSceneInit;
  private bool m_isOpenInfo;

  public void SetIsOpenInfo(bool bIsOpen) => this.m_isOpenInfo = bIsOpen;

  public bool GetIsOpenInfo() => this.m_isOpenInfo;

  public void OpenInfoScene()
  {
    this.SetIsOpenInfo(false);
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_1", true);
  }

  public bool isSceneInitialized
  {
    get => !this.isStartSceneInit && this.tempScene == null && this.loadAsync == null;
  }

  public int changeSceneQueueCount => this.changeSceneQueue.Count;

  protected override void Initialize()
  {
    this.tempScene = (NGSceneManager.SceneWrapper) null;
    this.currentScene = (NGSceneManager.SceneWrapper) null;
    this.loadAsync = (AsyncOperation) null;
    this.destroyedSceneList = new List<NGSceneManager.SceneWrapper>();
  }

  public void ChangeErrorPage()
  {
    this.destroyLoadedScenes();
    this.isError = true;
  }

  [DebuggerHidden]
  private IEnumerator doLoadLevelAdditiveAsync(NGSceneManager.SceneWrapper scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CdoLoadLevelAdditiveAsync\u003Ec__IteratorB56()
    {
      scene = scene,
      \u003C\u0024\u003Escene = scene,
      \u003C\u003Ef__this = this
    };
  }

  public Coroutine loadResource(GameObject gameObject)
  {
    return this.StartCoroutine(Singleton<ResourceManager>.GetInstance().LoadResource(gameObject));
  }

  [DebuggerHidden]
  private IEnumerator invokeMethod(object obj, string methodName, object[] parameters)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CinvokeMethod\u003Ec__IteratorB57()
    {
      obj = obj,
      methodName = methodName,
      parameters = parameters,
      \u003C\u0024\u003Eobj = obj,
      \u003C\u0024\u003EmethodName = methodName,
      \u003C\u0024\u003Eparameters = parameters,
      \u003C\u003Ef__this = this
    };
  }

  private string getTypeName(IEnumerable<System.Type> xs)
  {
    return string.Join(", ", xs.Select<System.Type, string>((Func<System.Type, string>) (x => x.ToString())).ToArray<string>());
  }

  [DebuggerHidden]
  private IEnumerator changeSceneUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CchangeSceneUpdate\u003Ec__IteratorB58()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool errorCheck() => this.isError;

  private bool changeSceneCore(string sceneName, object[] args, bool isStack)
  {
    this.enqueueScene(sceneName, args, isStack);
    return true;
  }

  private void enqueueScene(string sceneName, object[] args, bool isStack)
  {
    IEnumerator enumerator = this.processChangeSceneQueueCore(new NGSceneManager.ChangeSceneParam(sceneName, args, isStack));
    this.isStartSceneInit = true;
    this.changeSceneQueue.Enqueue(enumerator);
    if (this.changeSceneQueue.Count != 1)
      return;
    this.StartCoroutine(this.processChangeSceneQueueLoop());
  }

  [DebuggerHidden]
  private IEnumerator processChangeSceneQueueLoop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CprocessChangeSceneQueueLoop\u003Ec__IteratorB59()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator processChangeSceneQueueCore(NGSceneManager.ChangeSceneParam nextScene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CprocessChangeSceneQueueCore\u003Ec__IteratorB5A()
    {
      nextScene = nextScene,
      \u003C\u0024\u003EnextScene = nextScene,
      \u003C\u003Ef__this = this
    };
  }

  public bool changeScene(string sceneName, bool isStack = false, params object[] args)
  {
    ModelUnits.Instance.currentSceneName = sceneName;
    return this.changeSceneCore(sceneName, args, isStack);
  }

  public void waitSceneAction(System.Action callback)
  {
    this.StartCoroutine(this.waitSceneActionImpl(callback));
  }

  [DebuggerHidden]
  private IEnumerator waitSceneActionImpl(System.Action callback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CwaitSceneActionImpl\u003Ec__IteratorB5B()
    {
      callback = callback,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  public bool backScene()
  {
    if (this.sceneStack.Count == 0)
      return false;
    if (!this.currentScene.sceneBase.isDontAutoDestroy)
      this.destroyScene(this.currentScene);
    this.destoryNonStackScenes();
    NGSceneManager.SceneWrapper sceneWrapper = this.sceneStack.Pop();
    return this.changeSceneCore(sceneWrapper.name, sceneWrapper.args, false);
  }

  public bool backScene(string sceneName)
  {
    if (!this.sceneStack.Any<NGSceneManager.SceneWrapper>((Func<NGSceneManager.SceneWrapper, bool>) (x => x.name == sceneName)))
      return false;
    if (!this.currentScene.sceneBase.isDontAutoDestroy)
      this.destroyScene(this.currentScene);
    NGSceneManager.SceneWrapper scene;
    for (scene = this.sceneStack.Pop(); scene.name != sceneName; scene = this.sceneStack.Pop())
    {
      if (!scene.sceneBase.isDontAutoDestroy)
        this.destroyScene(scene);
    }
    this.destoryNonStackScenes();
    return this.changeSceneCore(scene.name, scene.args, false);
  }

  public bool backSceneToBattleMap()
  {
    if (this.sceneStack.Count == 0 && this.currentScene.name.Contains("BattleUI_01"))
      return this.changeSceneCore(this.currentScene.name, this.currentScene.args, false);
    if (!this.currentScene.sceneBase.isDontAutoDestroy)
      this.destroyScene(this.currentScene);
    if (this.sceneStack.Count <= 0)
      return this.changeSceneCore(this.currentScene.name, this.currentScene.args, false);
    NGSceneManager.SceneWrapper sceneWrapper = this.sceneStack.Pop();
    return this.changeSceneCore(sceneWrapper.name, sceneWrapper.args, false);
  }

  public void clearStack()
  {
    foreach (NGSceneManager.SceneWrapper scene in this.sceneStack)
    {
      if (!scene.sceneBase.isDontAutoDestroy)
        this.destroyScene(scene);
    }
    this.sceneStack.Clear();
  }

  public void destoryNonStackScenes()
  {
    foreach (NGSceneManager.SceneWrapper scene in this.loadedScenes.Values)
    {
      if (!this.sceneStack.Contains(scene) && !scene.sceneBase.isDontAutoDestroy)
        this.destroyScene(scene);
    }
  }

  private bool destroyScene(NGSceneManager.SceneWrapper scene)
  {
    if (!this.destroyedSceneList.Contains(scene))
      this.destroyedSceneList.Add(scene);
    return true;
  }

  public bool destroyScene(string sceneName)
  {
    return this.loadedScenes.ContainsKey(sceneName) && this.destroyScene(this.loadedScenes[sceneName]);
  }

  public bool destroyScene(GameObject sceneObject)
  {
    NGSceneManager.SceneWrapper scene = (NGSceneManager.SceneWrapper) null;
    foreach (NGSceneManager.SceneWrapper sceneWrapper in this.loadedScenes.Values)
    {
      if (Object.op_Equality((Object) sceneWrapper.sceneObject, (Object) sceneObject))
      {
        scene = sceneWrapper;
        break;
      }
    }
    return scene != null && this.destroyScene(scene);
  }

  public bool destroyCurrentScene()
  {
    return this.currentScene != null && this.destroyScene(this.currentScene);
  }

  public void destroyLoadedScenes()
  {
    this.clearStack();
    foreach (NGSceneManager.SceneWrapper scene in this.loadedScenes.Values)
      this.destroyScene(scene);
  }

  [DebuggerHidden]
  public IEnumerator destroyLoadedScenesImmediate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSceneManager.\u003CdestroyLoadedScenesImmediate\u003Ec__IteratorB5C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onChangeSceneAwake(NGSceneBase sceneBase)
  {
    if (sceneBase.isAlphaActive)
      ((Component) sceneBase).gameObject.GetComponent<UIPanel>().alpha = 0.0f;
    else
      ((Component) sceneBase).gameObject.SetActive(false);
    this.tempScene.sceneBase = sceneBase;
    this.loadedScenes[this.tempScene.name] = this.tempScene;
    sceneBase.sceneName = this.tempScene.name;
    foreach (Component componentsInChild in ((Component) sceneBase).GetComponentsInChildren<UICamera>(true))
      Object.Destroy((Object) componentsInChild.gameObject);
    UIRoot component1 = ((Component) sceneBase).gameObject.GetComponent<UIRoot>();
    if (!Object.op_Inequality((Object) component1, (Object) null))
      return;
    UIRoot component2 = ((Component) Singleton<CommonRoot>.GetInstance()).GetComponent<UIRoot>();
    component1.manualHeight = component2.manualHeight;
    component1.minimumHeight = component2.minimumHeight;
  }

  public string sceneName
  {
    get
    {
      if (this.tempScene != null)
        return this.tempScene.name;
      return this.currentScene != null ? this.currentScene.name : (string) null;
    }
  }

  public NGSceneBase sceneBase
  {
    get
    {
      if (this.tempScene != null)
        return this.tempScene.sceneBase;
      return this.currentScene != null ? this.currentScene.sceneBase : (NGSceneBase) null;
    }
  }

  public void RestartGame() => this.StartCoroutine(this.RestartCoroutine());

  [DebuggerHidden]
  private IEnumerator RestartCoroutine()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneManager.\u003CRestartCoroutine\u003Ec__IteratorB5D coroutineCIteratorB5D = new NGSceneManager.\u003CRestartCoroutine\u003Ec__IteratorB5D();
    return (IEnumerator) coroutineCIteratorB5D;
  }

  public void StartTimer()
  {
  }

  public void StopTimer(string title)
  {
  }

  private class SceneWrapper
  {
    public string name;
    public object[] args;
    public bool isStack;
    public NGSceneBase sceneBase;
    public List<Transform> destroyList;

    public SceneWrapper(string n, object[] a, bool s)
    {
      this.name = n;
      this.args = a;
      this.isStack = s;
      this.sceneBase = (NGSceneBase) null;
      this.destroyList = (List<Transform>) null;
    }

    public GameObject sceneObject
    {
      get
      {
        return Object.op_Inequality((Object) this.sceneBase, (Object) null) ? ((Component) this.sceneBase).gameObject : (GameObject) null;
      }
    }

    public override string ToString()
    {
      return string.Format("SceneWrapper {0} : {1} : {2} : {3} : {4}", (object) this.name, (object) this.args, (object) this.isStack, (object) this.sceneObject, (object) this.sceneBase);
    }
  }

  private class ChangeSceneParam
  {
    public readonly string sceneName;
    public readonly object[] args;
    public readonly bool isStack;

    public ChangeSceneParam(string sceneName_, object[] args_, bool isStack_)
    {
      this.sceneName = sceneName_;
      this.args = args_;
      this.isStack = isStack_;
    }
  }
}
