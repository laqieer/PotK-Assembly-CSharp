// Decompiled with JetBrains decompiler
// Type: Quest00228Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00228Scene : NGSceneBase
{
  [SerializeField]
  private Quest00228Menu menu;

  public static void ChangeScene(QuestScoreCampaignProgress qscp, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_28", (stack ? 1 : 0) != 0, (object) qscp);
  }

  public static void ChangeScene(Description description, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_28", (stack ? 1 : 0) != 0, (object) description);
  }

  public static void ChangeScene(QuestExtraDescription[] descriptions, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_28", (stack ? 1 : 0) != 0, (object[]) new QuestExtraDescription[1][]
    {
      descriptions
    });
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Scene.\u003ConStartSceneAsync\u003Ec__Iterator28C()
    {
      qscp = qscp,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Description description)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Scene.\u003ConStartSceneAsync\u003Ec__Iterator28D()
    {
      description = description,
      \u003C\u0024\u003Edescription = description,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(QuestExtraDescription[] descriptions)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Scene.\u003ConStartSceneAsync\u003Ec__Iterator28E()
    {
      descriptions = descriptions,
      \u003C\u0024\u003Edescriptions = descriptions,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => DetailController.Release();
}
