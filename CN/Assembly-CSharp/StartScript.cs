// Decompiled with JetBrains decompiler
// Type: StartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  private void Awake()
  {
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartScript.\u003CStart\u003Ec__IteratorA68()
    {
      \u003C\u003Ef__this = this
    };
  }

  public enum StartScene
  {
    Movie,
  }
}
