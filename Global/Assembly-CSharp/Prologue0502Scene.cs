// Decompiled with JetBrains decompiler
// Type: Prologue0502Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Prologue0502Scene : NGSceneBase
{
  [SerializeField]
  private string iosMoviePath;
  [SerializeField]
  private string androidMoviePath;
  private bool isFinish;
  private bool callChangeScene;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Prologue0502Scene.\u003ConStartSceneAsync\u003Ec__Iterator5E8 asyncCIterator5E8 = new Prologue0502Scene.\u003ConStartSceneAsync\u003Ec__Iterator5E8();
    return (IEnumerator) asyncCIterator5E8;
  }

  public void onStartScene() => this.StartCoroutine(this.PlayMovie());

  private void Update()
  {
    if (!this.isFinish || this.callChangeScene)
      return;
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Mypage051Scene.ChangeScene(false, false);
    this.callChangeScene = true;
  }

  private string moviePath() => this.androidMoviePath;

  [DebuggerHidden]
  private IEnumerator PlayMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Prologue0502Scene.\u003CPlayMovie\u003Ec__Iterator5E9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
