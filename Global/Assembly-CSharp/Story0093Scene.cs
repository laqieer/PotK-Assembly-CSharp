﻿// Decompiled with JetBrains decompiler
// Type: Story0093Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0093Scene : NGSceneBase
{
  public StoryExecuter executer;
  public bool test;

  public static void changeScene009_3(bool stack, int scriptId)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_3", true, (object) scriptId);
  }

  public IEnumerator onStartSceneAsync()
  {
    return this.onStartSceneAsync(MasterData.ScriptScriptList[0].ID);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int scriptId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0093Scene.\u003ConStartSceneAsync\u003Ec__Iterator482()
    {
      scriptId = scriptId,
      \u003C\u0024\u003EscriptId = scriptId,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => Singleton<CommonRoot>.GetInstance().isLoading = false;

  public void onStartScene(int scriptId) => this.onStartScene();

  public override void onEndScene()
  {
    if (Object.op_Inequality((Object) this.executer, (Object) null))
      this.executer.onEndScene();
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    instanceOrNull.isStoryPlayBackMode = false;
  }
}
