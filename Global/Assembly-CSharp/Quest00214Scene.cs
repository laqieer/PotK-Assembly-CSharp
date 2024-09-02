// Decompiled with JetBrains decompiler
// Type: Quest00214Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00214Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Quest00214Menu menu;
  private bool isInit = true;

  public static void ChangeScene(bool stack, int unitId)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", (stack ? 1 : 0) != 0, (object) unitId);
  }

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", stack);
  }

  public static void ChangeScene(bool stack, bool is_change_combi)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", (stack ? 1 : 0) != 0, (object) is_change_combi);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int? unitId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator18A()
    {
      unitId = unitId,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int? unitId, bool is_change_combi)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator18B()
    {
      is_change_combi = is_change_combi,
      unitId = unitId,
      \u003C\u0024\u003Eis_change_combi = is_change_combi,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int unitId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator18C()
    {
      unitId = unitId,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator18D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool is_change_combi)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator18E()
    {
      is_change_combi = is_change_combi,
      \u003C\u0024\u003Eis_change_combi = is_change_combi,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(int unitId) => Singleton<CommonRoot>.GetInstance().isLoading = false;

  public void onStartScene(int unitId, bool is_change_combi)
  {
    if (is_change_combi)
      this.menu.IbtnCombi();
    else
      this.menu.InitCombiQuestButton();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene()
  {
  }

  public void onStartScene(bool is_change_combi)
  {
    if (is_change_combi)
      this.menu.IbtnCombi();
    else
      this.menu.InitCombiQuestButton();
  }
}
