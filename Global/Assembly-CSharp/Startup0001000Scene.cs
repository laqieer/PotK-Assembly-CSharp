// Decompiled with JetBrains decompiler
// Type: Startup0001000Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Startup0001000Scene : MonoBehaviour
{
  public UIRoot uiRoot;
  public UIButton uiButton;
  private System.Action callback;

  public System.Action Callback
  {
    get => this.callback;
    set => this.callback = value;
  }

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  private static void DestroyIfExists(MonoBehaviour instance)
  {
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    ((Component) instance).gameObject.SingletonDestory();
  }

  private void Update()
  {
    if (!Input.GetKeyDown((KeyCode) 27))
      return;
    MasterDataCache.CacheClear();
    Singleton<ResourceManager>.GetInstance().ClearPathCache();
    Startup0001000Scene.DestroyIfExists((MonoBehaviour) Singleton<NGSceneManager>.GetInstance());
    Startup0001000Scene.DestroyIfExists((MonoBehaviour) Singleton<CommonRoot>.GetInstance());
    Startup0001000Scene.DestroyIfExists((MonoBehaviour) Singleton<TutorialRoot>.GetInstance());
    Startup0001000Scene.DestroyIfExists((MonoBehaviour) Singleton<NGSoundManager>.GetInstance());
    WebQueue.ResetAuthToken();
    MasterDataCache.CacheClear();
    SceneManager.LoadScene("startup000_6");
    Singleton<ResourceManager>.GetInstance().ClearCache();
  }

  public void SceneChange()
  {
    if (this.Callback != null)
      this.Callback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
