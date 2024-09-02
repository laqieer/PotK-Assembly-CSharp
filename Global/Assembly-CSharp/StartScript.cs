// Decompiled with JetBrains decompiler
// Type: StartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using gu3.Device;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class StartScript : MonoBehaviour
{
  public StartScript.StartScene startScene;
  public Font defaultFont;

  [DebuggerHidden]
  public static IEnumerator Restart(float waitTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartScript.\u003CRestart\u003Ec__Iterator8D5()
    {
      waitTime = waitTime,
      \u003C\u0024\u003EwaitTime = waitTime
    };
  }

  public static void Restart()
  {
    MasterDataCache.CacheClear();
    Singleton<ResourceManager>.GetInstance().ClearPathCache();
    StartScript.destroyIfExists((MonoBehaviour) Singleton<NGSceneManager>.GetInstance());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<CommonRoot>.GetInstance());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<TutorialRoot>.GetInstance());
    StartScript.destroyIfExists((MonoBehaviour) Singleton<NGSoundManager>.GetInstance());
    WebQueue.ResetAuthToken();
    MasterDataCache.CacheClear();
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
    string operatingSystem = SystemInfo.operatingSystem;
    int num = 5;
    if (!string.IsNullOrEmpty(operatingSystem))
    {
      string[] strArray = operatingSystem.Split('.')[0].Split(' ');
      int result;
      if (strArray.Length > 1 && int.TryParse(strArray[strArray.Length - 1], out result))
        num = result;
    }
    if (num >= 5)
      return;
    bool flag = DeviceManager.VerifyBinarySignature(new byte[16]
    {
      (byte) 252,
      (byte) 43,
      (byte) 50,
      (byte) 232,
      (byte) 207,
      (byte) 245,
      (byte) 144,
      (byte) 100,
      (byte) 129,
      (byte) 78,
      (byte) 161,
      (byte) 250,
      (byte) 79,
      (byte) 92,
      (byte) 183,
      (byte) 221
    });
    if (flag)
      return;
    Debug.LogError((object) ("***** binary check: " + (object) flag));
    Application.Quit();
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartScript.\u003CStart\u003Ec__Iterator8D6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public enum StartScene
  {
    Movie,
  }
}
