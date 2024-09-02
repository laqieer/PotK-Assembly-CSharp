// Decompiled with JetBrains decompiler
// Type: Quest00220Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00220Scene : NGSceneBase
{
  private static bool isInit;
  public Quest00220Menu menu;
  public BGChange bgchange;
  private static bool keyQuest;

  public static void ChangeScene00220(bool stack, int L, int M, bool Guerrilla = false)
  {
    Quest00220Scene.isInit = true;
    Quest00220Scene.keyQuest = false;
    Quest00220SceneData quest00220SceneData = new Quest00220SceneData(L, M, Guerrilla);
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_20", (stack ? 1 : 0) != 0, (object) quest00220SceneData);
  }

  public static void ChangeScene00220(int id, bool isKeyQuest = false)
  {
    Quest00220Scene.isInit = true;
    Quest00220Scene.keyQuest = isKeyQuest;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_20", false, (object) id);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00220Scene.\u003ConStartSceneAsync\u003Ec__Iterator1FF()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Quest00220SceneData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00220Scene.\u003ConStartSceneAsync\u003Ec__Iterator200()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(int id)
  {
    this.menu.HscrollButtonsAction();
    this.menu.SceneStart = true;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene(Quest00220SceneData data)
  {
    this.menu.SceneStart = true;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public override void onEndScene()
  {
    foreach (GameObject hscrollButton in this.menu.hscrollButtons)
      hscrollButton.GetComponent<Quest0022Hscroll>().centerAnimation(false);
    this.menu.indicator.SeEnable = false;
    this.menu.nowCenterObj = (GameObject) null;
    this.menu.SceneStart = false;
    this.menu.ButtonMove = false;
    this.menu.onEndScene();
  }
}
