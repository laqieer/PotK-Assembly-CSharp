// Decompiled with JetBrains decompiler
// Type: StartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Language;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class StartScript : MonoBehaviour
{
  public StartScript.StartScene startScene;
  public Font defaultFont;

  public static void Restart()
  {
    MasterDataCache.CacheClear();
    Singleton<ResourceManager>.GetInstance().ClearPathCache();
    OnDemandDownload.InitVariable();
    SceneManager.UnloadScene("common");
    SceneManager.UnloadScene("tutorial");
    StartScript.destroyIfExists((MonoBehaviour) Singleton<NGSceneManager>.GetInstanceOrNull());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<CommonRoot>.GetInstanceOrNull());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<TutorialRoot>.GetInstanceOrNull());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<NGSoundManager>.GetInstanceOrNull());
    SceneManager.LoadScene("start");
    Singleton<ResourceManager>.GetInstance().ClearCache();
  }

  private static void destroyIfExists(MonoBehaviour instance)
  {
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    ((Component) instance).gameObject.SingletonDestory();
  }

  private void Awake() => LanguageService.Instance.Language = new LanguageInfo("CHT");

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartScript.\u003CStart\u003Ec__IteratorB49()
    {
      \u003C\u003Ef__this = this
    };
  }

  public enum StartScene
  {
    Movie,
  }
}
