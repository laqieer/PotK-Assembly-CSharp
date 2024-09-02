// Decompiled with JetBrains decompiler
// Type: Prologue0501Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using Earth;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Prologue0501Scene : NGSceneBase
{
  private string moviePath;
  private bool isFinish;
  private bool callChangeScene;

  public static void ChangeScene(bool stack, bool isCloudAnim)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("prologue050_1", (stack ? 1 : 0) != 0, (object) isCloudAnim);
  }

  public void onStartScene(bool isCloudAnime)
  {
    CommonEarthHeader earthHeaderComponent = Singleton<CommonRoot>.GetInstance().GetEarthHeaderComponent();
    if (Object.op_Inequality((Object) earthHeaderComponent, (Object) null))
      earthHeaderComponent.isActive = false;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.moviePath = Singleton<EarthDataManager>.GetInstance().questProgress.GetPrologueData().arg1;
    if (isCloudAnime)
      Singleton<CommonRoot>.GetInstance().StartCloudAnimEnd((System.Action) (() => this.StartCoroutine(this.PlayMovie())));
    else
      this.StartCoroutine(this.PlayMovie());
  }

  private void Update()
  {
    if (!this.isFinish || this.callChangeScene)
      return;
    Singleton<EarthDataManager>.GetInstance().NextPrologueScene();
    this.callChangeScene = true;
  }

  private string GetMoviePath() => "android/" + this.moviePath;

  [DebuggerHidden]
  private IEnumerator PlayMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Prologue0501Scene.\u003CPlayMovie\u003Ec__Iterator723()
    {
      \u003C\u003Ef__this = this
    };
  }
}
