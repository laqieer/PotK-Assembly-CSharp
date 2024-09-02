// Decompiled with JetBrains decompiler
// Type: Quest00214Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C4()
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
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C5()
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
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C6()
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
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool is_change_combi)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C8()
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
