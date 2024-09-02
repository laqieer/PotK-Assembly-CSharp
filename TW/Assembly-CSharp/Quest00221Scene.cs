// Decompiled with JetBrains decompiler
// Type: Quest00221Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00221Scene : NGSceneBase
{
  private static string defaultSceneName = "quest002_2_1";
  private Quest00221DetailMenu mainMenu_;

  public Quest00221DetailMenu mainMenu
  {
    get
    {
      if (Object.op_Equality((Object) this.mainMenu_, (Object) null))
        this.mainMenu_ = this.menuBase as Quest00221DetailMenu;
      return this.mainMenu_;
    }
  }

  public static void changeDetailScene(QuestDetailData data, bool isStack = false)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene(Quest00221Scene.defaultSceneName, (isStack ? 1 : 0) != 0, (object) data);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestDetailData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00221Scene.\u003ConStartSceneAsync\u003Ec__Iterator297()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }
}
