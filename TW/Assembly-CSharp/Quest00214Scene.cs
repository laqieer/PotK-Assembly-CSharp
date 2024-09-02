// Decompiled with JetBrains decompiler
// Type: Quest00214Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  [SerializeField]
  private Quest00214aMenu subMenu;
  private bool isInit = true;

  public static void ChangeScene(bool stack, int unitId)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", (stack ? 1 : 0) != 0, (object) unitId);
  }

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", stack);
  }

  public static void ChangeScene(bool stack, int unitOrQuestId, bool is_change_combi)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_14", (stack ? 1 : 0) != 0, (object) unitOrQuestId, (object) is_change_combi);
  }

  [DebuggerHidden]
  public override IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003CStart\u003Ec__Iterator1F0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int? unitId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1F1()
    {
      unitId = unitId,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int? unitOrQuestId, bool is_change_combi)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1F2()
    {
      is_change_combi = is_change_combi,
      unitOrQuestId = unitOrQuestId,
      \u003C\u0024\u003Eis_change_combi = is_change_combi,
      \u003C\u0024\u003EunitOrQuestId = unitOrQuestId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int unitId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1F3()
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
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int unitOrQuestId, bool is_change_combi)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1F5()
    {
      unitOrQuestId = unitOrQuestId,
      is_change_combi = is_change_combi,
      \u003C\u0024\u003EunitOrQuestId = unitOrQuestId,
      \u003C\u0024\u003Eis_change_combi = is_change_combi,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(int unitId) => Singleton<CommonRoot>.GetInstance().isLoading = false;

  public void onStartScene(int unitOrQuestId, bool is_change_combi)
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
}
